using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;

namespace CodeRuner.Control
{
    public static class WindowHelper
    {
        public enum WindowCompositionAttribute
        {
            WcaAccentPolicy = 19
        }

        public static Rect GetCurrentWindowRect()
        {
            var screen = Screen.FromPoint(Cursor.Position).WorkingArea;
            var scale = DpiHelper.GetCurrentScaleFactor();
            return new Rect(
                new Point(screen.X / scale.Horizontal, screen.Y / scale.Vertical),
                new Size(screen.Width / scale.Horizontal, screen.Height / scale.Vertical));
        }

        public static void BringToFront(this Window window, bool keep)
        {
            var handle = new WindowInteropHelper(window).Handle;
            User32.SetWindowPos(handle, User32.HWND_TOPMOST, 0, 0, 0, 0,
                User32.SWP_NOMOVE | User32.SWP_NOSIZE | User32.SWP_NOACTIVATE);

            if (!keep)
                User32.SetWindowPos(handle, User32.HWND_NOTOPMOST, 0, 0, 0, 0,
                    User32.SWP_NOMOVE | User32.SWP_NOSIZE | User32.SWP_NOACTIVATE);
        }

        public static void MoveWindow(this Window window,
            double left,
            double top,
            double width,
            double height)
        {
            int pxLeft = 0, pxTop = 0;
            if (left != 0 || top != 0)
                TransformToPixels(window, left, top,
                    out pxLeft, out pxTop);

            TransformToPixels(window, width, height,
                out var pxWidth, out var pxHeight);

            User32.MoveWindow(new WindowInteropHelper(window).Handle, pxLeft, pxTop, pxWidth, pxHeight, true);
        }

        private static void TransformToPixels(this Visual visual,
            double unitX,
            double unitY,
            out int pixelX,
            out int pixelY)
        {
            Matrix matrix;
            var source = PresentationSource.FromVisual(visual);
            if (source != null)
                matrix = source.CompositionTarget.TransformToDevice;
            else
                using (var src = new HwndSource(new HwndSourceParameters()))
                {
                    matrix = src.CompositionTarget.TransformToDevice;
                }

            pixelX = (int)Math.Round(matrix.M11 * unitX);
            pixelY = (int)Math.Round(matrix.M22 * unitY);
        }

        public static bool IsForegroundWindowBelongToSelf()
        {
            var hwnd = User32.GetForegroundWindow();
            if (hwnd == IntPtr.Zero)
                return false;

            User32.GetWindowThreadProcessId(hwnd, out var procId);
            return procId == Process.GetCurrentProcess().Id;
        }

        public static void SetNoactivate(WindowInteropHelper window)
        {
            User32.SetWindowLong(window.Handle, User32.GWL_EXSTYLE,
                User32.GetWindowLong(window.Handle, User32.GWL_EXSTYLE) |
                User32.WS_EX_NOACTIVATE);
        }

        public static void EnableBlur(Window window)
        {
            var accent = new AccentPolicy();
            var accentStructSize = Marshal.SizeOf(accent);
            accent.AccentState = AccentState.AccentEnableBlurbehind;
            accent.AccentFlags = 2;
            accent.GradientColor = 0x99FFFFFF;

            var accentPtr = Marshal.AllocHGlobal(accentStructSize);
            Marshal.StructureToPtr(accent, accentPtr, false);

            var data = new WindowCompositionAttributeData
            {
                Attribute = WindowCompositionAttribute.WcaAccentPolicy,
                SizeOfData = accentStructSize,
                Data = accentPtr
            };

            User32.SetWindowCompositionAttribute(new WindowInteropHelper(window).Handle, ref data);

            Marshal.FreeHGlobal(accentPtr);
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct WindowCompositionAttributeData
        {
            public WindowCompositionAttribute Attribute;
            public IntPtr Data;
            public int SizeOfData;
        }

        private enum AccentState
        {
            AccentDisabled = 0,
            AccentEnableGradient = 1,
            AccentEnableTransparentgradient = 2,
            AccentEnableBlurbehind = 3,
            AccentInvalidState = 4
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct AccentPolicy
        {
            public AccentState AccentState;
            public int AccentFlags;
            public uint GradientColor;
            public readonly int AnimationId;
        }
    }
}

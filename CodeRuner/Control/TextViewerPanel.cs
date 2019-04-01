using ICSharpCode.AvalonEdit;
using ICSharpCode.AvalonEdit.Document;
using ICSharpCode.AvalonEdit.Highlighting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;
using UtfUnknown;

namespace CodeRuner.Control
{
    public class TextViewerPanel : TextEditor, IDisposable
    {
        private readonly ContextObject _context;
        private bool _disposed;

        public TextViewerPanel(string path, ContextObject context)
        {
            _context = context;

            Background = new SolidColorBrush(Color.FromArgb(0xAA, 255, 255, 255));
            FontSize = 14;
            ShowLineNumbers = true;
            WordWrap = true;
            IsReadOnly = true;
            IsManipulationEnabled = true;

            ManipulationInertiaStarting += Viewer_ManipulationInertiaStarting;
            ManipulationStarting += Viewer_ManipulationStarting;
            ManipulationDelta += Viewer_ManipulationDelta;

            PreviewMouseWheel += Viewer_MouseWheel;

            FontFamily = new FontFamily("Consolas,Malgun Gothic,Batang");

            LoadFileAsync(path);
        }

        public void Dispose()
        {
            _disposed = true;
        }

        private void Viewer_ManipulationInertiaStarting(object sender, ManipulationInertiaStartingEventArgs e)
        {
            e.TranslationBehavior = new InertiaTranslationBehavior
            {
                InitialVelocity = e.InitialVelocities.LinearVelocity,
                DesiredDeceleration = 10.0 * 96.0 / (1000.0 * 1000.0)
            };
        }

        private void Viewer_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            e.Handled = true;

            ScrollToVerticalOffset(VerticalOffset - e.Delta);
        }

        private void Viewer_ManipulationDelta(object sender, ManipulationDeltaEventArgs e)
        {
            e.Handled = true;

            var delta = e.DeltaManipulation;
            ScrollToVerticalOffset(VerticalOffset - delta.Translation.Y);
        }

        private void Viewer_ManipulationStarting(object sender, ManipulationStartingEventArgs e)
        {
            e.Mode = ManipulationModes.Translate;
        }

        private void LoadFileAsync(string path)
        {
            Task.Run(() =>
            {
                const int maxLength = 50 * 1024 * 1024;
                var buffer = new MemoryStream();
                bool tooLong;

                using (var s = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    tooLong = s.Length > maxLength;
                    while (s.Position < s.Length && buffer.Length < maxLength)
                    {
                        if (_disposed)
                            break;

                        var lb = new byte[8192];
                        var count = s.Read(lb, 0, lb.Length);
                        buffer.Write(lb, 0, count);
                    }
                }

                if (_disposed)
                    return;

                if (tooLong)
                    _context.Title += " (0 ~ 50MB)";

                var bufferCopy = buffer.ToArray();
                buffer.Dispose();

                var encoding = CharsetDetector.DetectFromBytes(bufferCopy).Detected?.Encoding ??
                               Encoding.Default;

                var doc = new TextDocument(encoding.GetString(bufferCopy));
                doc.SetOwnerThread(Dispatcher.Thread);

                if (_disposed)
                    return;

                Dispatcher.BeginInvoke(new Action(() =>
                {
                    Encoding = encoding;
                    SyntaxHighlighting = HighlightingManager.Instance.GetDefinitionByExtension(Path.GetExtension(path));
                    Document = doc;

                    _context.IsBusy = false;
                }), DispatcherPriority.Render);
            });
        }
    }
}

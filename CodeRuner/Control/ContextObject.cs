﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Runtime.CompilerServices;
namespace CodeRuner.Control
{
    public class ContextObject : INotifyPropertyChanged
    {
        private bool _canResize = true;
        private bool _fullWindowDragging;
        private bool _isBusy;
        private string _title = string.Empty;
        private bool _titlebarAutoHide;
        private bool _titlebarBlurVisibility;
        private bool _titlebarColourVisibility = true;
        private bool _titlebarOverlap;
        private Themes _theme = Themes.None;
        private object _viewerContent;

        /// <summary>
        ///     Get or set the title of Viewer window.
        /// </summary>
        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        ///     Get or set the viewer content control.
        /// </summary>
        public object ViewerContent
        {
            get => _viewerContent;
            set
            {
                _viewerContent = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        ///     Show or hide the busy indicator icon.
        /// </summary>
        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                _isBusy = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        ///     Set the exact size you want.
        /// </summary>
        public Size PreferredSize { get; set; } = new Size { Width = 800, Height = 600 };

        /// <summary>
        ///     Set whether user are allowed to resize the viewer window.
        /// </summary>
        public bool CanResize
        {
            get => _canResize;
            set
            {
                _canResize = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        ///     Set whether the full viewer window can be used for mouse dragging.
        /// </summary>
        public bool FullWindowDragging
        {
            get => _fullWindowDragging;
            set
            {
                _fullWindowDragging = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        ///     Set whether the viewer content is overlapped by the title bar
        /// </summary>
        public bool TitlebarOverlap
        {
            get => _titlebarOverlap;
            set
            {
                _titlebarOverlap = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        ///     Set whether the title bar shows a blurred background
        /// </summary>
        public bool TitlebarBlurVisibility
        {
            get => _titlebarBlurVisibility;
            set
            {
                if (value == _titlebarBlurVisibility) return;
                _titlebarBlurVisibility = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        ///     Set whether the title bar shows a colour overlay
        /// </summary>
        public bool TitlebarColourVisibility
        {
            get => _titlebarColourVisibility;
            set
            {
                if (value == _titlebarColourVisibility) return;
                _titlebarColourVisibility = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        ///     Should the titlebar hides itself after a short period of inactivity?
        /// </summary>
        public bool TitlebarAutoHide
        {
            get => _titlebarAutoHide;
            set
            {
                if (value == _titlebarAutoHide) return;
                _titlebarAutoHide = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        ///     Switch to dark theme?
        /// </summary>
        public Themes Theme
        {
            get => _theme;
            set
            {
                _theme = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        ///     Set the size of viewer window, scale or shrink to fit (to screen resolution).
        ///     The window can take maximum (maxRatio*resolution) space.
        /// </summary>
        /// <param name="size">The desired size.</param>
        /// <param name="maxRatio">The maximum percent (over screen resolution) it can take.</param>
        public double SetPreferredSizeFit(Size size, double maxRatio)
        {
            if (maxRatio > 1)
                maxRatio = 1;

            var max = WindowHelper.GetCurrentWindowRect();

            var widthRatio = max.Width * maxRatio / size.Width;
            var heightRatio = max.Height * maxRatio / size.Height;

            var ratio = Math.Min(widthRatio, heightRatio);
            if (ratio > 1) ratio = 1;

            PreferredSize = new Size { Width = size.Width * ratio, Height = size.Height * ratio };

            return ratio;
        }

        public void Reset()
        {
            Title = string.Empty;
            // set to False to prevent showing loading icon
            IsBusy = false;
            PreferredSize = new Size();
            CanResize = true;
            FullWindowDragging = false;

            Theme = Themes.None;
            TitlebarOverlap = false;
            TitlebarAutoHide = false;
            TitlebarBlurVisibility = false;
            TitlebarColourVisibility = true;

            ViewerContent = null;
        }

        [NotifyPropertyChangedInvocator]
        protected void OnPropertyChanged( string propertyName = null)//[CallerMemberName]
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

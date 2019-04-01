using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace CodeRuner
{
    public class AttachedProperties
    {
        #region BindableLineCount AttachedProperty
        public static int GetBindableLineCount(DependencyObject obj)
        {
            return (int)obj.GetValue(BindableLineCountProperty);
        }

        public static void SetBindableLineCount(DependencyObject obj, int value)
        {
            obj.SetValue(BindableLineCountProperty, value);
        }

        // Using a DependencyProperty as the backing store for BindableLineCount.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BindableLineCountProperty =
            DependencyProperty.RegisterAttached(
            "BindableLineCount",
            typeof(int),
            typeof(MainWindow),
            new UIPropertyMetadata(-1));

        #endregion // BindableLineCount AttachedProperty

        #region HasBindableLineCount AttachedProperty
        public static bool GetHasBindableLineCount(DependencyObject obj)
        {
            return (bool)obj.GetValue(HasBindableLineCountProperty);
        }

        public static void SetHasBindableLineCount(DependencyObject obj, bool value)
        {
            obj.SetValue(HasBindableLineCountProperty, value);
        }

        // Using a DependencyProperty as the backing store for HasBindableLineCount.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HasBindableLineCountProperty =
            DependencyProperty.RegisterAttached(
            "HasBindableLineCount",
            typeof(bool),
            typeof(MainWindow),
            new UIPropertyMetadata(
                false,
                new PropertyChangedCallback(OnHasBindableLineCountChanged)));

        private static void OnHasBindableLineCountChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            var textBox = (TextBox)o;
            if ((e.NewValue as bool?) == true)
            {
                textBox.SetValue(BindableLineCountProperty, textBox.LineCount);
                textBox.SizeChanged += new SizeChangedEventHandler(box_SizeChanged);
            }
            else
            {
                textBox.SizeChanged -= new SizeChangedEventHandler(box_SizeChanged);
            }
        }

        static void box_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            var textBox = (TextBox)sender;
            (textBox).SetValue(BindableLineCountProperty, (textBox).LineCount);
        }
        #endregion // HasBindableLineCount AttachedProperty
    }
}

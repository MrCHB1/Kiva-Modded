using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Kiva_MIDI
{
    /// <summary>
    /// Interaction logic for BetterTextInput.xaml
    /// </summary>
    public partial class BetterTextInput : UserControl
    {
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(BetterTextInput), new PropertyMetadata("Text", (s, e) => ((BetterTextInput)s).OnTextPropertyChanged(e)));

        public static readonly RoutedEvent ValueChangedEvent = EventManager.RegisterRoutedEvent(
           "ValueChanged", RoutingStrategy.Bubble,
           typeof(RoutedPropertyChangedEventHandler<string>), typeof(BetterTextInput));

        public event RoutedPropertyChangedEventHandler<string> ValueChanged
        {
            add { AddHandler(ValueChangedEvent, value); }
            remove { RemoveHandler(ValueChangedEvent, value); }
        }

        public BetterTextInput()
        {
            InitializeComponent();
        }

        void OnTextPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            SaveString();
            RaiseEvent(new RoutedPropertyChangedEventArgs<string>((string)e.OldValue, (string)e.NewValue, ValueChangedEvent));
        }

        void SaveString()
        {
            string s = Text;
            if (rawText.Text != s)
                rawText.Text = s;
        }

        private void rawText_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                Text = rawText.Text;
            }
            catch { }
        }

        private void rawText_LostFocus(object sender, RoutedEventArgs e)
        {
            SaveString();
        }

        private void UserControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                SaveString();
                e.Handled = true;
                Keyboard.ClearFocus();

                FrameworkElement parent = (FrameworkElement)rawText.Parent;
                while (parent != null && parent is IInputElement && !((IInputElement)parent).Focusable)
                {
                    parent = (FrameworkElement)parent.Parent;
                }

                DependencyObject scope = FocusManager.GetFocusScope(rawText);
                FocusManager.SetFocusedElement(scope, parent as IInputElement);
            }
        }
    }
}

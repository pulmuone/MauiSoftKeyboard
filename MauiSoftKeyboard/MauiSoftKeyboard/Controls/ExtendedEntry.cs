using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiSoftKeyboard.Controls
{
    public class ExtendedEntry : Entry
    {
        public static readonly BindableProperty EnableKeyboardProperty
            = BindableProperty.Create("EnableKeyboard", typeof(bool), typeof(ExtendedEntry), false);

        public static readonly BindableProperty ShowVirtualKeyboardOnFocusProperty = BindableProperty.Create(nameof(ShowVirtualKeyboardOnFocus), typeof(bool), typeof(ExtendedEntry), false);

        public bool EnableKeyboard
        {
            get => (bool)this.GetValue(EnableKeyboardProperty);
            set => this.SetValue(EnableKeyboardProperty, value);
        }

        public bool ShowVirtualKeyboardOnFocus
        {
            get => (bool)this.GetValue(ShowVirtualKeyboardOnFocusProperty);
            set => this.SetValue(ShowVirtualKeyboardOnFocusProperty, value);
        }

        //public static readonly BindableProperty EnableRequestFocusProperty
        //    = BindableProperty.Create("EnableRequestFocus", typeof(bool), typeof(ExtendedEntry), false);

        //public bool EnableRequestFocus
        //{
        //    get => (bool)this.GetValue(EnableRequestFocusProperty);
        //    set => this.SetValue(EnableRequestFocusProperty, value);
        //}

        public ExtendedEntry()
        {
            this.Focused += OnFocused;
            this.Unfocused -= OnFocused;
        }

        private void OnFocused(object sender, FocusEventArgs e)
        {
            if (e.IsFocused)
            {
                if (ShowVirtualKeyboardOnFocus)
                {
                    //Main-Thread에서 처리해야 한다.
                    Application.Current.Dispatcher.Dispatch(() =>
                    {
                        //포커스 될때 키보드가 보이게 하려면
                        EnableKeyboard = true;
                    });
                }
                else
                {
                    Application.Current.Dispatcher.Dispatch(() =>
                    {
                        //포커스 될때 키보드가 보이게 하려면
                        EnableKeyboard = false;
                    });                    
                }
            }
        }

        public new bool Focus()
        {
            if (ShowVirtualKeyboardOnFocus)
            {
                Application.Current.Dispatcher.Dispatch(() =>
                {
                    //포커스 될때 키보드가 보이게 하려면
                    EnableKeyboard = true;
                });
            }
            else
            {
                Application.Current.Dispatcher.Dispatch(() =>
                {
                    //포커스 될때 키보드가 보이게 하려면
                    EnableKeyboard = false;
                });
            }

            return true;

        }
    }
}

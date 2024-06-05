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

        public bool EnableKeyboard
        {
            get => (bool)this.GetValue(EnableKeyboardProperty);
            set => this.SetValue(EnableKeyboardProperty, value);
        }



        //public static readonly BindableProperty EnableRequestFocusProperty
        //    = BindableProperty.Create("EnableRequestFocus", typeof(bool), typeof(ExtendedEntry), false);

        //public bool EnableRequestFocus
        //{
        //    get => (bool)this.GetValue(EnableRequestFocusProperty);
        //    set => this.SetValue(EnableRequestFocusProperty, value);
        //}



    }
}

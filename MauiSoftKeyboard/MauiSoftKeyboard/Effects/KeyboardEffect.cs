using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiSoftKeyboard.Effects
{
    public static class KeyboardEffect
    {
        /// <summary>
        /// Bindable property to Enable keyboard
        /// </summary>
        public static readonly BindableProperty EnableKeyboardProperty 
            = BindableProperty.Create("EnableKeyboard", typeof(bool), typeof(KeyboardEffect), false, propertyChanged: OnEnableKeyboardChanged);

        /// <summary>
        /// Bindable property to focus control
        /// 화면 처음에 보여 질때 해당 Entry에 Focus주는 것인데 ViewModel로 개발할 경우 단점이 있기 때문에 Task.Delay(300); Entry.Focus()로 대체 한다.
        /// </summary>
        public static readonly BindableProperty RequestFocusProperty 
            = BindableProperty.Create("RequestFocus", typeof(bool), typeof(KeyboardEffect), false);

        /// <summary>
        /// Get EnableKeyboard value
        /// </summary>
        /// <param name="view"></param>
        /// <returns></returns>
        public static bool GetEnableKeyboard(BindableObject view)
        {
            return (bool)view.GetValue(EnableKeyboardProperty);
        }

        /// <summary>
        /// Get RequestFocus value
        /// </summary>
        /// <param name="view"></param>
        /// <returns></returns>
        public static bool GetRequestFocus(BindableObject view)
        {
            return (bool)view.GetValue(RequestFocusProperty);
        }

        /// <summary>
        /// Set EnableKeyboard Value
        /// </summary>
        /// <param name="view"></param>
        /// <param name="value"></param>
        public static void SetEnableKeyboard(BindableObject view, bool value)
        {
            view.SetValue(EnableKeyboardProperty, value);
        }

        /// <summary>
        /// Set RequestFocus Value
        /// </summary>
        /// <param name="view"></param>
        /// <param name="value"></param>
        public static void SetRequestFocus(BindableObject view, bool value)
        {
            view.SetValue(RequestFocusProperty, value);
        }

        private static void OnEnableKeyboardChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (!(bindable is View view))
            {
                return;
            }

            var enableKeyboard = (bool)newValue;

            if (enableKeyboard)
            {
                var toRemove = view.Effects.FirstOrDefault(e => e is KeyboardEnableEffect);
                if (toRemove != null)
                {
                    view.Effects.Remove(toRemove);
                }
            }
            else
            {
                view.Effects.Add(new KeyboardEnableEffect());
            }
        }
    }
}

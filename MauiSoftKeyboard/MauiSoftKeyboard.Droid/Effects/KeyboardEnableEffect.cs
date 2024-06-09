using Android.Content;
using Android.Views.InputMethods;
using Android.Widget;
using Google.Android.Material.TextField;
using MauiSoftKeyboard.Effects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Controls.Platform;

namespace MauiSoftKeyboard.Droid.Effects
{
    public class KeyboardEnableEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            try
            {
                EditText editText;
                # region Material Design
                if (Control is TextInputLayout inputLayout)
                {
                    editText = inputLayout.EditText;
                }
                #endregion
                else if (Control is EditText text)
                {
                    editText = text;
                }
                else
                {
                    return;
                }

                 editText.ShowSoftInputOnFocus = KeyboardEffect.GetEnableKeyboard(Element);

                if (!editText.ShowSoftInputOnFocus)
                {
                    editText.FocusChange += HideMethod; 
                }

                var imm = (InputMethodManager)Platform.CurrentActivity?.GetSystemService(Context.InputMethodService);
                imm?.HideSoftInputFromWindow(Control.WindowToken, HideSoftInputFlags.None);

                SoftKeyboard.Current.InvokeVisibilityChanged(false);

                var requestFocus = KeyboardEffect.GetRequestFocus(Element);
                if (requestFocus)
                {
                    editText.RequestFocus();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }
        }

        protected override void OnDetached()
        {
            try
            {
                if (Element == null || Control == null)
                {
                    return;
                }

                EditText editText;

                #region Material Design
                if (Control is TextInputLayout inputLayout)
                {
                    editText = inputLayout.EditText;
                }
                #endregion
                else if (Control is EditText text)
                {
                    editText = text;
                }
                else
                {
                    return;
                }

                var visibilityEffect = Element.Effects.OfType<KeyboardEnableEffect>().FirstOrDefault();

                if (visibilityEffect != null)
                {
                    return;
                }

                editText.ShowSoftInputOnFocus = KeyboardEffect.GetEnableKeyboard(Element);
                editText.FocusChange -= HideMethod;

                var imm = (InputMethodManager)Platform.CurrentActivity?.GetSystemService(Context.InputMethodService);
                imm?.ShowSoftInput(Control, ShowFlags.Implicit);

                SoftKeyboard.Current.InvokeVisibilityChanged(true);

                var requestFocus = KeyboardEffect.GetRequestFocus(Element);
                if (requestFocus)
                {
                    editText.RequestFocus();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }
        }

        private void HideMethod(object? sender, Android.Views.View.FocusChangeEventArgs e)
        {
            try
            {
                //hide keyboard for current focused control.
                var imm = (InputMethodManager)Platform.CurrentActivity?.GetSystemService(Context.InputMethodService);
                imm?.HideSoftInputFromWindow(Control.WindowToken, HideSoftInputFlags.None);

                SoftKeyboard.Current.InvokeVisibilityChanged(!e.HasFocus);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }
        }
    }
}

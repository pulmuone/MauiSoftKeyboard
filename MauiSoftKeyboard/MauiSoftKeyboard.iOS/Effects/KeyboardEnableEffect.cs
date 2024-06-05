using MauiSoftKeyboard.Effects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIKit;
using Microsoft.Maui.Controls.Platform;

namespace MauiSoftKeyboard.iOS.Effects
{
    public class KeyboardEnableEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            try
            {
                if (!(Control is UITextField nativeTextField) || KeyboardEffect.GetEnableKeyboard(Element))
                {
                    return;
                }

                nativeTextField.InputView = new UIView();

                nativeTextField.InputAssistantItem.LeadingBarButtonGroups = null;
                nativeTextField.InputAssistantItem.TrailingBarButtonGroups = null;

                var requestFocus = KeyboardEffect.GetRequestFocus(Element);
                if (requestFocus)
                {
                    nativeTextField.BecomeFirstResponder();
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
                if (!(Control is UITextField nativeTextField))
                {
                    return;
                }

                nativeTextField.InputView = null;
                var requestFocus = KeyboardEffect.GetRequestFocus(Element);
                if (requestFocus)
                {
                    nativeTextField.BecomeFirstResponder();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }
        }
    }
}

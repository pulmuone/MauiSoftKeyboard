﻿using MauiSoftKeyboard.Effects;
using System;
using UIKit;
using Microsoft.Maui.Controls.Platform;
using CoreFoundation;

namespace MauiSoftKeyboard.iOS.Effects
{
    [Foundation.Preserve(AllMembers = true)]
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

                SoftKeyboard.Current.InvokeVisibilityChanged(false);

                var requestFocus = KeyboardEffect.GetRequestFocus(Element);
                if (requestFocus)
                {
                    nativeTextField.ResignFirstResponder();
                    nativeTextField.BecomeFirstResponder(); //ShowKeyboard
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

                SoftKeyboard.Current.InvokeVisibilityChanged(true);

                if (requestFocus)
                {
                    nativeTextField.ResignFirstResponder(); //HideKeyboard, 포커스도 아웃됨.
                    nativeTextField.BecomeFirstResponder(); //ShowKeyboard

                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }
        }
    }
}

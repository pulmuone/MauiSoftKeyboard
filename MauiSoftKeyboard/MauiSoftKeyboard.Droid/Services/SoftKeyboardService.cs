﻿using Android.Content;
using Android.Views;
using Android.Views.InputMethods;
using Android.Widget;
using Google.Android.Material.TextField;

namespace MauiSoftKeyboard.Droid.Services
{
    //public class SoftKeyboardService : Java.Lang.Object, ViewTreeObserver.IOnGlobalLayoutListener
    //{
    //    private static InputMethodManager _inputManager;

    //    private static bool _wasAcceptingText;

    //    public void OnGlobalLayout()
    //    {
    //        try
    //        {
    //            if (_inputManager is null || _inputManager.Handle == IntPtr.Zero)
    //            {
    //                _inputManager = (InputMethodManager)Platform.CurrentActivity.GetSystemService(Context.InputMethodService);
    //            }

    //            // Set visibility to false when focus on background view.
    //            var currentFocus = Platform.CurrentActivity.CurrentFocus;

    //            if (currentFocus.AccessibilityClassName == "android.view.ViewGroup")
    //            {
    //                _wasAcceptingText = _inputManager.IsAcceptingText;
    //                return;
    //            }

    //            EditText editText;

    //            if (currentFocus is TextInputLayout inputLayout)
    //            {
    //                editText = inputLayout.EditText;
    //            }
    //            else if (currentFocus is EditText text)
    //            {
    //                editText = text;
    //            }
    //            else
    //            {
    //                return;
    //            }

    //            if (!editText.ShowSoftInputOnFocus)
    //            {
    //                _inputManager?.HideSoftInputFromWindow(currentFocus.WindowToken, HideSoftInputFlags.None);
    //            }

    //            if (_wasAcceptingText == _inputManager?.IsAcceptingText)
    //            {
    //                // Fixed entry get focused by code pop up keyboard
    //                if (!editText.ShowSoftInputOnFocus)
    //                {

    //                }
    //                return;
    //            }

    //            _wasAcceptingText = _inputManager.IsAcceptingText;
    //        }
    //        catch (Exception ex)
    //        {
    //            System.Diagnostics.Debug.WriteLine(ex);
    //        }
    //    }
    //}
}
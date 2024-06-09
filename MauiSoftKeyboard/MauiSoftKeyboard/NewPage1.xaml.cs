using MauiSoftKeyboard.Controls;
using CommunityToolkit.Maui.Core.Platform;
using Microsoft.Maui.Platform;
using System.Diagnostics;

namespace MauiSoftKeyboard;

public partial class NewPage1 : ContentPage
{
    ExtendedEntry _entry;

    public NewPage1()
    {
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        await Task.Delay(300); // 250이나 300정도해도 작동
        this.Entry1.Focus();
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();

        SoftKeyboard.Current.VisibilityChanged -= Current_VisibilityChanged;
    }

    private void Current_VisibilityChanged(SoftKeyboardEventArgs e)
    {
        Debug.WriteLine($"KeyBoard is visible : {(e.IsVisible ? "Yes" : "No")}");
    }


    void ToolbarItem_Clicked(System.Object sender, System.EventArgs e)
    {
        KeyboardShowHide();
    }

    void Btn1_Clicked(System.Object sender, System.EventArgs e)
    {
        KeyboardShowHide();
    }

    void Btn2_Clicked(System.Object sender, System.EventArgs e)
    {
        KeyboardShowHide();
    }

    void Entry1_Focused(System.Object sender, Microsoft.Maui.Controls.FocusEventArgs e)
    {
        _entry = (sender as ExtendedEntry);
    }

    void Entry2_Focused(System.Object sender, Microsoft.Maui.Controls.FocusEventArgs e)
    {
        _entry = (sender as ExtendedEntry);
    }

    private void KeyboardShowHide()
    {
        if (this._entry != null)
        {
            if (this.IsSoftInputShowing)
            {
                if (DeviceInfo.Platform == DevicePlatform.iOS)
                {
                    _entry.EnableKeyboard = false;
                    //_entry.Unfocus();
                }
                else if (DeviceInfo.Platform == DevicePlatform.Android)
                {
                    _entry.EnableKeyboard = false;
                    //_entry.Unfocus();
                    //_entry.Focus();
                }
            }
            else
            {
                if (DeviceInfo.Platform == DevicePlatform.iOS)
                {
                    _entry.EnableKeyboard = true;
                    //_entry.Focus();

                }
                else if (DeviceInfo.Platform == DevicePlatform.Android)
                {
                    _entry.EnableKeyboard = true;
                    //_entry.Unfocus();
                    //_entry.Focus();
                }
            }
        }
    }
}

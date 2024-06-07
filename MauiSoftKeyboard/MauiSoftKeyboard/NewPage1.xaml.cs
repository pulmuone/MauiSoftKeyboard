using MauiSoftKeyboard.Controls;
using CommunityToolkit.Maui.Core.Platform;
using Microsoft.Maui.Platform;
using System.Diagnostics;

namespace MauiSoftKeyboard;

public partial class NewPage1 : ContentPage
{
    bool IsSoftInputShowing;
    ExtendedEntry _entry;

    public NewPage1()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        SoftKeyboard.Current.VisibilityChanged += Current_VisibilityChanged;

        //await Task.Delay(500); // 250이나 300정도해도 작동

        //this.Entry1.Focus();

        //this._entry = this.Entry1;
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();

        SoftKeyboard.Current.VisibilityChanged -= Current_VisibilityChanged;
    }


    private void Current_VisibilityChanged(SoftKeyboardEventArgs e)
    {
        IsSoftInputShowing = e.IsVisible;
        //LabelMessage.Text = $"KeyBoard is visible : {(e.IsVisible ? "Yes" : "No")}";
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
            //if (this.IsSoftInputShowing)
            //if(this._entry.IsSoftKeyboardShowing())
            if (_entry.IsSoftInputShowing())
            {
                if (DeviceInfo.Platform == DevicePlatform.iOS)
                {
                    _entry.EnableKeyboard = false;
                    _entry.Unfocus();
                    _entry.Focus();
                }
                else if (DeviceInfo.Platform == DevicePlatform.Android)
                {
                    _entry.Unfocus();
                    _entry.Focus();
                    _entry.EnableKeyboard = false;
                    
                }
            }
            else
            {
                if (DeviceInfo.Platform == DevicePlatform.iOS)
                {
                    _entry.EnableKeyboard = true;
                    _entry.Unfocus();
                    _entry.Focus();
                }
                else if (DeviceInfo.Platform == DevicePlatform.Android)
                {
                    _entry.Unfocus();
                    _entry.Focus();
                    _entry.EnableKeyboard = true;                    
                }
            }
        }
    }
}

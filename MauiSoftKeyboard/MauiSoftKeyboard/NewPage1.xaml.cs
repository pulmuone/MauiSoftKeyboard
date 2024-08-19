using MauiSoftKeyboard.Controls;
using CommunityToolkit.Maui.Core.Platform;
using Microsoft.Maui.Platform;
using System.Diagnostics;

namespace MauiSoftKeyboard;

public partial class NewPage1 : ContentPage
{
    //bool IsSoftInputShowing;
    ExtendedEntry _entry;

    public NewPage1()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        //SoftKeyboard.Current.VisibilityChanged += Current_VisibilityChanged;

    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();

        //SoftKeyboard.Current.VisibilityChanged -= Current_VisibilityChanged;
    }

    //private void Current_VisibilityChanged(SoftKeyboardEventArgs e)
    //{
    //    IsSoftInputShowing = e.IsVisible;
    //    Debug.WriteLine($"KeyBoard is visible : {(e.IsVisible ? "Yes" : "No")}");
    //}


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

        ////Main-Thread에서 처리해야 한다.
        //Application.Current.Dispatcher.Dispatch(() =>
        //{
        //    //포커스 될때 키보드가 보이게 하려면
        //    _entry.EnableKeyboard = true;
        //});
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
            if (this._entry.IsSoftInputShowing())
            {
                Application.Current.Dispatcher.Dispatch(() =>
                {
                    _entry.EnableKeyboard = false;
                });

            }
            else
            {
                Application.Current.Dispatcher.Dispatch(() =>
                {
                    _entry.EnableKeyboard = true;
                });
            }
        }
    }

    private void ContentPage_Loaded(object sender, EventArgs e)
    {
        //Entry2.EnableKeyboard = true;
        //Entry2.ShowKeyboardAsync();

    }
}

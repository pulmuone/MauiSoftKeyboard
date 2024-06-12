using Microsoft.Maui;
using System.Diagnostics;

namespace MauiSoftKeyboard;

public partial class NewPage2 : ContentPage
{
    bool IsSoftInputShowing;

    Entry _entry;

    public NewPage2()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        SoftKeyboard.Current.VisibilityChanged += Current_VisibilityChanged;
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();

        SoftKeyboard.Current.VisibilityChanged -= Current_VisibilityChanged;
    }

    private void Current_VisibilityChanged(SoftKeyboardEventArgs e)
    {
        IsSoftInputShowing = e.IsVisible;
        Debug.WriteLine($"KeyBoard is visible : {(e.IsVisible ? "Yes" : "No")}");
    }



    void ToolbarItem_Clicked(System.Object sender, System.EventArgs e)
    {
        KeyboardShowHide();
    }

    void Entry1_Focused(System.Object sender, Microsoft.Maui.Controls.FocusEventArgs e)
    {
        this._entry = (sender as Entry);
    }

    void Entry2_Focused(System.Object sender, Microsoft.Maui.Controls.FocusEventArgs e)
    {
        this._entry = (sender as Entry);
    }

    private void KeyboardShowHide()
    {
        if (this._entry != null)
        {
            if (this.IsSoftInputShowing)
            {
                this.vm.IsEnableKeyboard = false;
            }
            else
            {
                this.vm.IsEnableKeyboard = true;
            }
        }
    }
}

using MauiSoftKeyboard.Controls;
using MauiSoftKeyboard.Effects;

namespace MauiSoftKeyboard;

public partial class MainPage : ContentPage
{
    ExtendedEntry _entry;

    public MainPage()
    {
        InitializeComponent();
    }


    protected override async void OnAppearing()
    {
        base.OnAppearing();

        await Task.Delay(500); // 250이나 300정도해도 작동

        this.Entry1.Focus();
    }


    private void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        KeyboardShowHide();
    }

    private void KeyboardShowHide()
    {
        if (this._entry != null)
        {
            if (_entry.IsSoftInputShowing())
            {
                _entry.Unfocus();
                _entry.EnableKeyboard = false;
            }
            else
            {
                _entry.Focus();
                _entry.EnableKeyboard = true;
            }
        }
    }


    private void Btn1_Clicked(object sender, EventArgs e)
    {
        KeyboardShowHide();
    }
    private void Btn2_Clicked(object sender, EventArgs e)
    {
        KeyboardShowHide();
    }

    private void Btn3_Clicked(object sender, EventArgs e)
    {
        KeyboardShowHide();
    }

    private void Entry3_Focused(object sender, FocusEventArgs e)
    {
        _entry = sender as ExtendedEntry;
    }

    private void Entry2_Focused(object sender, FocusEventArgs e)
    {
        _entry = sender as ExtendedEntry;
    }

    private void Entry1_Focused(object sender, FocusEventArgs e)
    {
        _entry = sender as ExtendedEntry;
    }


    private void entry_Unfocused(object sender, FocusEventArgs e)
    {
        //if (this._entry != null)
        //{
        //    if (this._entry.IsSoftInputShowing())
        //    {
        //        this._entry.Unfocus();
        //        this._entry.EnableKeyboard = false;
        //    }
        //}
    }

    private void Entry4_Focused(object sender, FocusEventArgs e)
    {

    }

    private void Btn4_Clicked(object sender, EventArgs e)
    {

    }
}


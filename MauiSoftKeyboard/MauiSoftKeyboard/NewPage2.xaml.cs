using Microsoft.Maui;

namespace MauiSoftKeyboard;

public partial class NewPage2 : ContentPage
{
    bool IsSoftInputShowing;

    Entry _entry;

	public NewPage2()
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
            if (_entry.IsSoftInputShowing())
            {
                if (DeviceInfo.Platform == DevicePlatform.iOS)
                {
                    this.vm.IsEnableKeyboard = false;
                    _entry.Unfocus();
                }
                else if (DeviceInfo.Platform == DevicePlatform.Android)
                {
                    _entry.Unfocus();
                    _entry.Focus();
                    this.vm.IsEnableKeyboard = false;
                }
            }
            else
            {
                if (DeviceInfo.Platform == DevicePlatform.iOS)
                {
                    this.vm.IsEnableKeyboard = true;
                    _entry.Focus();

                }
                else if (DeviceInfo.Platform == DevicePlatform.Android)
                {
                    _entry.Unfocus();
                    _entry.Focus();
                    this.vm.IsEnableKeyboard = true;
                }
            }
        }
    }
}

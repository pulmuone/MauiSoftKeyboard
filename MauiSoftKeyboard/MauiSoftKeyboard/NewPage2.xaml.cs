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
                //바인딩된 IsEnableKeyboard이 모두 동작하기 때문에 문제가 된다
                _entry.Unfocus();
                _entry.Focus();
                this.vm.IsEnableKeyboard = false;                
            }
            else
            {
                _entry.Unfocus();
                _entry.Focus();
                this.vm.IsEnableKeyboard = true;
                
            }
        }
    }
}

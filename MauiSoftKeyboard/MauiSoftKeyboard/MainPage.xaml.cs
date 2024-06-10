using System.Threading;
using MauiSoftKeyboard.Controls;
using MauiSoftKeyboard.Effects;
using MauiSoftKeyboard.ViewModels;

namespace MauiSoftKeyboard;

public partial class MainPage : ContentPage
{

    public MainPage()
    {
        InitializeComponent();
    }


    async void NonMvvm_Clicked(System.Object sender, System.EventArgs e)
    {
        NewPage1 page = new NewPage1();

        await this.Navigation.PushAsync(page, false);
    }

    async void Mvvm_Clicked(System.Object sender, System.EventArgs e)
    {
        NewPage2 page = new NewPage2();

        await this.Navigation.PushAsync(page, false);
    }
}


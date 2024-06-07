using System;
namespace MauiSoftKeyboard.ViewModels
{
	public class NewPage2ViewModel : ViewModelBase
	{

        private bool _isEnableKeyboard = false;

        public bool IsEnableKeyboard
        {
            get => _isEnableKeyboard;
            set => SetProperty(ref this._isEnableKeyboard, value);
        }

        public NewPage2ViewModel()
		{
		}
	}
}


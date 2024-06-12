# MauiSoftKeyboard

초기 포커스 지정하려면 RequestFocus에  True를 지정한다.
effects:KeyboardEffect.RequestFocus="True"

만약 UI에 여러개의 ExtendedEntry가 있다면 화면 로딩되는 초기에
포커스가 지정되는 하나의 Entry에만 RequestFocus="True"를 지정하고 나머지는 False로 되어야 한다.

https://github.com/pulmuone/MauiSoftKeyboard/assets/42885949/055cc317-4c2a-47f9-8db1-2e4d8fba618b

original source
https://github.com/masonyc/Xamarin.KeyboardHelper

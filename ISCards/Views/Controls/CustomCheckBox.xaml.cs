namespace ISCards.Views.Controls;

public partial class CustomCheckBox : ContentView
{
    public string Title
    {
        get
        {
            return (string)GetValue(TitleProperty);
        }

        set
        {
            SetValue(TitleProperty, value);
        }
    }

    public static readonly BindableProperty TitleProperty =
        BindableProperty.Create(nameof(Title),
            typeof(string),
            typeof(CustomCheckBox),
            defaultValue: string.Empty,
            defaultBindingMode: BindingMode.TwoWay,
            propertyChanged: TitlePropertyChanged);

    private static void TitlePropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var control = (CustomCheckBox)bindable;
        control.Label.Text = newValue?.ToString();
    }

    public bool IsChecked
    {
        get
        {
            return (bool)GetValue(IsCheckedProperty);
        }

        set
        {
            SetValue(IsCheckedProperty, value);
        }
    }

    public static readonly BindableProperty IsCheckedProperty =
        BindableProperty.Create(nameof(Title),
            typeof(bool),
            typeof(CustomCheckBox),
            defaultValue: false,
            defaultBindingMode: BindingMode.TwoWay,
            propertyChanged: IsCheckedPropertyChanged);

    private static void IsCheckedPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var control = (CustomCheckBox)bindable;
        control.CheckBox.IsChecked = (bool)newValue;
    }

    public CustomCheckBox()
	{
		InitializeComponent();
	}
}
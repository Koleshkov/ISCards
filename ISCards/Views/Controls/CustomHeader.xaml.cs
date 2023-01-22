namespace ISCards.Views.Controls;

public partial class CustomHeader : ContentView
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
            typeof(CustomHeader),
            defaultValue: string.Empty,
            defaultBindingMode: BindingMode.TwoWay,
            propertyChanged: TitleTextPropertyChanged);

    private static void TitleTextPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var control = (CustomHeader)bindable;
        control.Label.Text = newValue?.ToString();
    }

    public CustomHeader()
	{
		InitializeComponent();
	}
}
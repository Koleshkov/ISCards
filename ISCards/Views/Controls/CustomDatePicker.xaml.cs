namespace ISCards.Views.Controls;

public partial class CustomDatePicker : ContentView
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
            typeof(CustomDatePicker),
            defaultValue: string.Empty,
            defaultBindingMode: BindingMode.TwoWay,
            propertyChanged: TitleTextPropertyChanged);

    private static void TitleTextPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var control = (CustomDatePicker)bindable;
        control.Label.Text = newValue?.ToString();

    }

    public DateTime Date
    {
        get
        {
            return (DateTime)GetValue(DateProperty);
        }

        set
        {
            SetValue(DateProperty, value);
        }
    }

    public static readonly BindableProperty DateProperty =
        BindableProperty.Create(nameof(Date),
            typeof(DateTime),
            typeof(CustomDatePicker),
            defaultValue: DateTime.Now,
            defaultBindingMode: BindingMode.TwoWay,
            propertyChanged: DatePropertyChanged);

    private static void DatePropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var control = (CustomDatePicker)bindable;
        control.DatePicker.Date = (DateTime)newValue;
    }

    public CustomDatePicker()
	{
		InitializeComponent();
	}
}
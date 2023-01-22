namespace ISCards.Views.Controls;

public partial class CustomEntry : ContentView
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
            typeof(CustomEntry),
            defaultValue: string.Empty,
            defaultBindingMode: BindingMode.TwoWay,
            propertyChanged: TitlePropertyChanged);

    private static void TitlePropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var control = (CustomEntry)bindable;
        control.Label.Text = newValue?.ToString();
    }


    public string Text
    {
        get
        {
            return (string)GetValue(TextProperty);
        }

        set
        {
            SetValue(TextProperty, value);
        }
    }

    public static readonly BindableProperty TextProperty =
        BindableProperty.Create(nameof(Text),
            typeof(string),
            typeof(CustomEntry),
            defaultValue: string.Empty,
            defaultBindingMode: BindingMode.TwoWay,
            propertyChanged: TextPropertyChanged);

    private static void TextPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var control = (CustomEntry)bindable;
        control.Entry.Text = newValue?.ToString();
    }


    public string Placeholder
    {
        get
        {
            return (string)GetValue(PlaceholderProperty);
        }

        set
        {
            SetValue(PlaceholderProperty, value);
        }
    }

    public static readonly BindableProperty PlaceholderProperty =
        BindableProperty.Create(nameof(Placeholder),
            typeof(string),
            typeof(CustomEntry),
            defaultValue: string.Empty,
            defaultBindingMode: BindingMode.TwoWay,
            propertyChanged: PlaceholderPropertyChanged);

    private static void PlaceholderPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var control = (CustomEntry)bindable;
        control.Entry.Placeholder = newValue?.ToString();
    }

    public bool IsPassword
    {
        get
        {
            return (bool)GetValue(IsPasswordProperty);
        }

        set
        {
            SetValue(IsPasswordProperty, value);
        }
    }

    public static readonly BindableProperty IsPasswordProperty =
        BindableProperty.Create(nameof(IsPassword),
            typeof(bool),
            typeof(CustomEntry),
            defaultValue: false,
            defaultBindingMode: BindingMode.TwoWay,
            propertyChanged: IsPasswordPropertyChanged);

    private static void IsPasswordPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var control = (CustomEntry)bindable;
        control.Entry.IsPassword = (bool)newValue;
    }

    public CustomEntry()
	{
		InitializeComponent();
	}
}
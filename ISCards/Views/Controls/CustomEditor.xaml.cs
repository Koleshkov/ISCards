namespace ISCards.Views.Controls;

public partial class CustomEditor : ContentView
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
            typeof(CustomEditor),
            defaultValue: string.Empty,
            defaultBindingMode: BindingMode.TwoWay,
            propertyChanged: TitlePropertyChanged);

    private static void TitlePropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var control = (CustomEditor)bindable;
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
            typeof(CustomEditor),
            defaultValue: string.Empty,
            defaultBindingMode: BindingMode.TwoWay,
            propertyChanged: TextPropertyChanged);

    private static void TextPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var control = (CustomEditor)bindable;
        control.Editor.Text = newValue?.ToString();
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
            typeof(CustomEditor),
            defaultValue: string.Empty,
            defaultBindingMode: BindingMode.TwoWay,
            propertyChanged: PlaceholderPropertyChanged);

    private static void PlaceholderPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var control = (CustomEditor)bindable;
        control.Editor.Placeholder = newValue?.ToString();
    }

    public CustomEditor()
	{
		InitializeComponent();
	}
}
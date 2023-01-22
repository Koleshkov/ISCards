using System.Collections;

namespace ISCards.Views.Controls;

public partial class CustomPicker : ContentView
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
            typeof(CustomPicker),
            defaultValue: string.Empty,
            defaultBindingMode: BindingMode.TwoWay,
            propertyChanged: TitlePropertyChanged);

    private static void TitlePropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var control = (CustomPicker)bindable;
        control.Label.Text = newValue?.ToString();
    }

    public IList ItemSource
    {
        get
        {
            return (IList)GetValue(ItemSourceProperty);
        }

        set
        {
            SetValue(ItemSourceProperty, value);
        }
    }

    public static readonly BindableProperty ItemSourceProperty =
        BindableProperty.Create(nameof(ItemSource),
            typeof(IList),
            typeof(CustomPicker),
            defaultBindingMode: BindingMode.TwoWay,
            propertyChanged: ItemSourcePropertyChanged);

    private static void ItemSourcePropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var control = (CustomPicker)bindable;
        control.Picker.ItemsSource = (IList)newValue;
    }

    public object SelectedItem
    {
        get
        {
            return (object)GetValue(SelectedItemProperty);
        }

        set
        {
            SetValue(SelectedItemProperty, value);
        }
    }

    public static readonly BindableProperty SelectedItemProperty =
        BindableProperty.Create(nameof(SelectedItem),
            typeof(object),
            typeof(CustomPicker),
            defaultValue: string.Empty,
            defaultBindingMode: BindingMode.TwoWay,
            propertyChanged: SelectedItemPropertyChanged);

    private static void SelectedItemPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var control = (CustomPicker)bindable;
        control.Picker.SelectedItem = newValue;
    }


    public int SelectedIndex
    {
        get
        {
            return (int)GetValue(SelectedIndexProperty);
        }

        set
        {
            SetValue(SelectedIndexProperty, value);
        }
    }

    public static readonly BindableProperty SelectedIndexProperty =
        BindableProperty.Create(nameof(SelectedIndex),
            typeof(int),
            typeof(CustomPicker),
            defaultValue: 0,
            defaultBindingMode: BindingMode.TwoWay,
            propertyChanged: SelectedIndexPropertyChanged);

    private static void SelectedIndexPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var control = (CustomPicker)bindable;
        control.Picker.SelectedIndex =(int)newValue;
    }

    public object PickerTitle
    {
        get
        {
            return (string)GetValue(PickerTitleProperty);
        }

        set
        {
            SetValue(PickerTitleProperty, value);
        }
    }

    public static readonly BindableProperty PickerTitleProperty =
        BindableProperty.Create(nameof(PickerTitle),
            typeof(string),
            typeof(CustomPicker),
            defaultValue: string.Empty,
            defaultBindingMode: BindingMode.TwoWay,
            propertyChanged: PickerTitlePropertyChanged);

    private static void PickerTitlePropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var control = (CustomPicker)bindable;
        control.Picker.Title = newValue?.ToString();
    }

    public CustomPicker()
	{
		InitializeComponent();
	}
}
namespace BMICalculator.Controls;

public partial class GenderControl : ContentView
{
    public static readonly BindableProperty IconImageSourceProperty =
        BindableProperty.Create(nameof(IconImageSource), typeof(string), typeof(GenderControl), string.Empty);

    public static readonly BindableProperty TextProperty =
        BindableProperty.Create(nameof(Text), typeof(string), typeof(GenderControl), string.Empty);

    public static readonly BindableProperty ColorProperty =
        BindableProperty.Create(nameof(Color), typeof(string), typeof(GenderControl), string.Empty, propertyChanged: OnColorChanged);

    public static readonly BindableProperty BgColorProperty =
        BindableProperty.Create(nameof(BgColor), typeof(string), typeof(GenderControl), string.Empty, propertyChanged: OnBgColorChanged);


    public GenderControl()
    {
        InitializeComponent();
    }

    public string IconImageSource
    {
        get => (string)GetValue(IconImageSourceProperty);
        set => SetValue(IconImageSourceProperty, value);
    }
    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }
    public string Color
    {
        get => (string)GetValue(ColorProperty);
        set => SetValue(ColorProperty, value);
    }
    public string BgColor
    {
        get => (string)GetValue(BgColorProperty);
        set => SetValue(BgColorProperty, value);
    }

    private Color _tintColor = Colors.White;
    public Color TintColor
    {
        get => _tintColor;
        set
        {
            if (_tintColor != value)
            {
                _tintColor = value;
                OnPropertyChanged(nameof(TintColor));
            }
        }
    }

    private Color _backgroundColor = Colors.White;
    public Color BackgroundColor
    {
        get => _backgroundColor;
        set
        {
            if (_backgroundColor != value)
            {
                _backgroundColor = value;
                OnPropertyChanged(nameof(BackgroundColor));
            }
        }
    }

    private static void OnColorChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is GenderControl genderControl)
        {
            if (oldValue != newValue && newValue is not null)
            {
                genderControl.TintColor = Microsoft.Maui.Graphics.Color.FromArgb(newValue.ToString());
            }
        }
    }
    private static void OnBgColorChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is GenderControl genderControl)
        {
            if (oldValue != newValue && newValue is not null)
            {
                genderControl.BackgroundColor = Microsoft.Maui.Graphics.Color.FromArgb(newValue.ToString());
            }
        }
    }
}
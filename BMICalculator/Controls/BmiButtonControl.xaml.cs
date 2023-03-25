using Microsoft.Maui;

namespace BMICalculator.Controls;

public partial class BmiButtonControl : ContentView
{
    public static readonly BindableProperty IconImageSourceProperty =
        BindableProperty.Create(nameof(IconImageSource), typeof(string), typeof(BmiButtonControl), string.Empty);

    public BmiButtonControl()
	{
		InitializeComponent();
	}

    public string IconImageSource
    {
        get => (string)GetValue(IconImageSourceProperty);
        set => SetValue(IconImageSourceProperty, value);
    }

    public event EventHandler ButtonPressed;

    private void Button_Pressed(object sender, EventArgs e)
    {
        ButtonPressed?.Invoke(this, EventArgs.Empty);
    }
}
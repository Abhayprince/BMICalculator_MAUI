using System.ComponentModel;

namespace BMICalculator;

public partial class MainPage : ContentPage
{
    private BmiViewModel _viewModel;
    public MainPage()
    {
        InitializeComponent();
        _viewModel = new BmiViewModel();
        BindingContext = _viewModel;
    }

    private void CalculateBMI_Pressed(object sender, EventArgs e)
    {
        var heightInMeter = heightSlider.Value / 100;
        var weightInKg = weightSlider.Value;

        var bmi = weightInKg / (heightInMeter * heightInMeter);

        _viewModel.Bmi = bmi.ToString("N2");
        (_viewModel.BmiStatus, _viewModel.StatusColor) = GetBmiStatus(bmi);
        _viewModel.IsCalculated = true;
    }
    private static (string status, Color color) GetBmiStatus(double bmi)
    {
        if (bmi < 18.5)
            return ("You are Underweight", Colors.Blue);
        else if (bmi <= 24.9)
            return ("You have a Normal body weight, Great Job!", Colors.Green);
        else if (bmi <= 29.9)
            return ("You are Overweight", Colors.Yellow);
        else
            return ("You are Obese", Colors.DarkRed);
    }

    private void ResetBMI_Pressed(object sender, EventArgs e)
    {
        heightSlider.Value = 10;
        weightSlider.Value = 10;
        _viewModel.Reset();
    }
}

public class BmiViewModel : INotifyPropertyChanged
{
    private string _bmi;
    public string Bmi
    {
        get => _bmi;
        set
        {
            _bmi = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Bmi)));
        }
    }

    private string _bmiStatus;
    public string BmiStatus
    {
        get => _bmiStatus;
        set
        {
            _bmiStatus = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(BmiStatus)));
        }
    }
    private Color _statusColor = Colors.Blue;
    public Color StatusColor
    {
        get => _statusColor;
        set
        {
            _statusColor = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(StatusColor)));
        }
    }

    private bool _isCalculated;
    public bool IsCalculated
    {
        get => _isCalculated;
        set
        {
            _isCalculated = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsCalculated)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsNotCalculated)));
        }
    }

    public bool IsNotCalculated => !IsCalculated;

    public event PropertyChangedEventHandler PropertyChanged;

    public void Reset()
    {
        Bmi = string.Empty;
        BmiStatus = string.Empty;
        StatusColor = Colors.Blue;
        IsCalculated = false;
    }
}

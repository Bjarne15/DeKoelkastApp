using DeKoelkastApp.ViewModels;
using ZXing.Net.Maui;

namespace DeKoelkastApp.Views
{
    public partial class FridgeSelectionPage : ContentPage
    {
        private FridgeSelectionPageViewModel _viewModel;

        public FridgeSelectionPage()
        {
            InitializeComponent();
            _viewModel = new FridgeSelectionPageViewModel();
            BindingContext = _viewModel;
        }

        private void barcodeReader_BarcodesDetected(object sender, BarcodeDetectionEventArgs e)
        {
            if (e.Results.Any())
            {
                var result = e.Results.First();
                _viewModel.OnBarcodeDetected(result.Value);
            }
        }
    }
}
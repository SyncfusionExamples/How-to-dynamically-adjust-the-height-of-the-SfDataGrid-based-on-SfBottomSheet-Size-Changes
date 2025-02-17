namespace SfDataGridSample
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        
        private void BtnSelCon_OnClicked(object sender, EventArgs e)
        {

        }


        private void Button_Clicked(object sender, EventArgs e)
        {
            double screenHeight = DeviceDisplay.MainDisplayInfo.Height / DeviceDisplay.MainDisplayInfo.Density;

            double ratio = CalculateExpandRatio(bottomSheet.BottomSheetContent, screenHeight);

            bottomSheet.HalfExpandedRatio = ratio;

            bottomSheet.Show();
        }

        public double CalculateExpandRatio(View bottomSheetContent, double screenHeight)
        {

            double contentHeight = 0;

            contentHeight = bottomSheetContent.Measure(double.PositiveInfinity, double.PositiveInfinity).Height;

            // Define minimum and maximum ratios

            double minRatio = 0.4;

            double maxRatio = 0.9;


            // Calculate the ratio based on content height relative to screen height

            double calculatedRatio = contentHeight / screenHeight;


            // Ensure ratio stays within platform-specific bounds

            double finalRatio = Math.Clamp(calculatedRatio, minRatio, maxRatio);

            return finalRatio;

        }
    }
}

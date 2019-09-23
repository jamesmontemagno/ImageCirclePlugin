using Xamarin.Forms;
using Xamarin.Forms.Platform.WPF;
using System.Windows;

namespace TestAppsCircles.WPF
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : FormsApplicationPage
	{
		public MainWindow()
		{
			InitializeComponent();
            LoadApplication(new TestAppsCircles.App());
		}
	}
}

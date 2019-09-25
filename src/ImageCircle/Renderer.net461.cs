using ImageCircle.Forms.Plugin.WPF;
using System;
using Xamarin.Forms;
using ImageCircle.Forms.Plugin.Abstractions;
using Xamarin.Forms.Platform.WPF;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Color = System.Windows.Media.Color;
using ImageSource = Xamarin.Forms.ImageSource;
using System.ComponentModel;
using System.Diagnostics;

[assembly: ExportRenderer(typeof(CircleImage), typeof(ImageCircleRenderer))]
namespace ImageCircle.Forms.Plugin.WPF
{
	/// <summary>
	/// ImageCircle Implementation
	/// </summary>
	public class ImageCircleRenderer : ViewRenderer<Image, Ellipse>
	{
#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
		/// <summary>
		/// Used for registration with dependency service
		/// </summary>
		public async static void Init()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
#pragma warning restore CS0108 // Member hides inherited member; missing new keyword
		{
			var temp = DateTime.Now;
		}

		private ImageSource file;

		/// <summary>
		///     Register circle
		/// </summary>
		/// <param name="e"></param>
		protected override void OnElementChanged(ElementChangedEventArgs<Image> e)
		{
			base.OnElementChanged(e);
			if (e.OldElement != null || Element == null)
				return;

			var ellipse = new Ellipse();
			SetNativeControl(ellipse);
		}

		/// <summary>
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected override async void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged(sender, e);

			if (Control == null)
				return;

			var min = Math.Min(Element.Width, Element.Height);
			if (min / 2.0f <= 0)
				return;

			try
			{
				Control.Width = min;
				Control.Height = min;

				// Fill background color
				var color = ((CircleImage)Element).FillColor;
				Control.Fill = new SolidColorBrush(Color.FromArgb(
					(byte)(color.A * 255),
					(byte)(color.R * 255),
					(byte)(color.G * 255),
					(byte)(color.B * 255)));

				// Fill stroke
				color = ((CircleImage)Element).BorderColor;
				Control.StrokeThickness = ((CircleImage)Element).BorderThickness;
				Control.Stroke = new SolidColorBrush(Color.FromArgb(
					(byte)(color.A * 255),
					(byte)(color.R * 255),
					(byte)(color.G * 255),
					(byte)(color.B * 255)));

				var force = e.PropertyName == VisualElement.XProperty.PropertyName ||
							e.PropertyName == VisualElement.YProperty.PropertyName ||
							e.PropertyName == VisualElement.WidthProperty.PropertyName ||
							e.PropertyName == VisualElement.HeightProperty.PropertyName ||
							e.PropertyName == VisualElement.ScaleProperty.PropertyName ||
							e.PropertyName == VisualElement.TranslationXProperty.PropertyName ||
							e.PropertyName == VisualElement.TranslationYProperty.PropertyName ||
							e.PropertyName == VisualElement.RotationYProperty.PropertyName ||
							e.PropertyName == VisualElement.RotationXProperty.PropertyName ||
							e.PropertyName == VisualElement.RotationProperty.PropertyName ||
							e.PropertyName == CircleImage.BorderThicknessProperty.PropertyName ||
							e.PropertyName == CircleImage.BorderColorProperty.PropertyName ||
							e.PropertyName == CircleImage.FillColorProperty.PropertyName ||
							e.PropertyName == VisualElement.AnchorXProperty.PropertyName ||
							e.PropertyName == VisualElement.AnchorYProperty.PropertyName;

				//already set
				if (file == Element.Source && !force)
					return;

				file = Element.Source;

				BitmapImage bitmapImage = null;

				// Handle file images
				if (file is FileImageSource) throw new NotImplementedException();

				if (file is UriImageSource)
				{
					bitmapImage = new BitmapImage((Element.Source as UriImageSource).Uri);
				}
				else if (file is StreamImageSource)
				{
					var handler = new StreamImageSourceHandler();
					var imageSource = await handler.LoadImageAsync(file);

					if (imageSource != null)
						Control.Fill = new ImageBrush
						{
							ImageSource = imageSource,
							Stretch = Stretch.UniformToFill
						};
					return;
				}

				if (bitmapImage != null)
					Control.Fill = new ImageBrush
					{
						ImageSource = bitmapImage,
						Stretch = Stretch.UniformToFill
					};
			}
			catch
			{
				Debug.WriteLine("Unable to create circle image, falling back to background color.");
			}
		}
	}

}
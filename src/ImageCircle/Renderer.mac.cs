using ImageCircle.Forms.Plugin.Abstractions;
using System;
using Xamarin.Forms;
using ImageCircle.Forms.Plugin.Mac;
using Xamarin.Forms.Platform.MacOS;
using System.ComponentModel;
using System.Diagnostics;
using Foundation;
using CoreAnimation;
using CoreGraphics;
using System.Linq;

[assembly: ExportRenderer(typeof(CircleImage), typeof(ImageCircleRenderer))]
namespace ImageCircle.Forms.Plugin.Mac
{
	[Preserve(AllMembers = true)]
	public class ImageCircleRenderer : ImageRenderer
	{
		/// <summary>
		/// Used for registration with dependency service
		/// </summary>
		public async static void Init()
		{
			var temp = DateTime.Now;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="e">E.</param>
		protected override void OnElementChanged(ElementChangedEventArgs<Image> e)
		{
			base.OnElementChanged(e);
			if (Element == null)
				return;
			CreateCircle();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged(sender, e);
			if (e.PropertyName == VisualElement.HeightProperty.PropertyName ||
				e.PropertyName == VisualElement.WidthProperty.PropertyName ||
			  e.PropertyName == CircleImage.BorderColorProperty.PropertyName ||
			  e.PropertyName == CircleImage.BorderThicknessProperty.PropertyName ||
			  e.PropertyName == CircleImage.FillColorProperty.PropertyName)
			{
				CreateCircle();
			}
		}

		void CreateCircle()
		{
			try
			{
				var min = Math.Min(Element.Width, Element.Height);
				Control.Layer.CornerRadius = (nfloat)(min / 2.0);
				Control.Layer.MasksToBounds = true;
				Control.Layer.BackgroundColor = ((CircleImage)Element).FillColor.ToCGColor();

				var borderThickness = ((CircleImage)Element).BorderThickness;

				//Remove previously added layers
				var tempLayer = Control.Layer.Sublayers?
									   .Where(p => p.Name == borderName)
									   .FirstOrDefault();
				tempLayer?.RemoveFromSuperLayer();

				var externalBorder = new CALayer();
				externalBorder.Name = borderName;
				externalBorder.CornerRadius = Control.Layer.CornerRadius;
				externalBorder.Frame = new CGRect(-.5, -.5, min + 1, min + 1);
				externalBorder.BorderColor = ((CircleImage)Element).BorderColor.ToCGColor();
				externalBorder.BorderWidth = ((CircleImage)Element).BorderThickness;

				Control.Layer.AddSublayer(externalBorder);
			}
			catch(Exception ex)
			{
				Debug.WriteLine($"Unable to create circle image: {ex}");
			}
		}

		const string borderName = "borderLayerName";
	}
}

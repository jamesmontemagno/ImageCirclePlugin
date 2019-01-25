using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace ImageCircle.Forms.Plugin.Abstractions
{
	/// <summary>
	/// ImageCircle Interface
	/// </summary>
	[DesignTimeVisible(true)]
	public class CircleImage : Image
	{
		/// <summary>
		/// Thickness property of border
		/// </summary>
		public static readonly BindableProperty BorderThicknessProperty =
		  BindableProperty.Create(propertyName: nameof(BorderThickness),
			  returnType: typeof(float),
			  declaringType: typeof(CircleImage),
			  defaultValue: 0F);

		/// <summary>
		/// Border thickness of circle image
		/// </summary>
		public float BorderThickness
		{
			get { return (float)GetValue(BorderThicknessProperty); }
			set { SetValue(BorderThicknessProperty, value); }
		}

		/// <summary>
		/// Color property of border
		/// </summary>
		public static readonly BindableProperty BorderColorProperty =
			BindableProperty.Create(propertyName: nameof(BorderColor),
			  returnType: typeof(Color),
			  declaringType: typeof(CircleImage),
			  defaultValue: Color.White);


		/// <summary>
		/// Border Color of circle image
		/// </summary>
		public Color BorderColor
		{
			get { return (Color)GetValue(BorderColorProperty); }
			set { SetValue(BorderColorProperty, value); }
		}

		/// <summary>
		/// Color property of fill
		/// </summary>
		public static readonly BindableProperty FillColorProperty =
			BindableProperty.Create(propertyName: nameof(FillColor),
			  returnType: typeof(Color),
			  declaringType: typeof(CircleImage),
			  defaultValue: Color.Transparent);

		/// <summary>
		/// Fill color of circle image
		/// </summary>
		public Color FillColor
		{
			get { return (Color)GetValue(FillColorProperty); }
			set { SetValue(FillColorProperty, value); }
		}

	}
}
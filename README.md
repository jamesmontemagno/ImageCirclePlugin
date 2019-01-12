## Circle Image Control Plugin for Xamarin.Forms

A simple and elegant way of displaying circle images in your Xamarin.Forms projects.

## When upgrading to 3.0
 Be sure to change the DLL name to:
 
 ```xml
 xmlns:controls="clr-namespace:ImageCircle.Forms.Plugin.Abstractions;assembly=ImageCircle.Forms.Plugin"
 ```
	
If using 2.0 it is:
	
```xml
 xmlns:controls="clr-namespace:ImageCircle.Forms.Plugin.Abstractions;assembly=ImageCircle.Forms.Plugin.Abstractions"
 ```

#### Setup
* Available on NuGet: [![NuGet](https://img.shields.io/nuget/v/Xam.Plugins.Forms.ImageCircle.svg?label=NuGet)](https://www.nuget.org/packages/Xam.Plugins.Forms.ImageCircle/)
  *  [https://www.nuget.org/packages/Xam.Plugins.Forms.ImageCircle](https://www.nuget.org/packages/Xam.Plugins.Forms.ImageCircle)
* Install into your PCL project and Client projects.
* Build status: ![Build status](https://jamesmontemagno.visualstudio.com/_apis/public/build/definitions/6b79a378-ddd6-4e31-98ac-a12fcd68644c/16/badge)


In your iOS, Android, and Windows projects call:

```csharp
Xamarin.Forms.Init(); //platform specific init
ImageCircleRenderer.Init();
```

You must do this AFTER you call `Xamarin.Forms.Init();`

**Platform Support**

|Platform|Version|
| -------------------  | :------------------: |
|Xamarin.iOS|iOS 7+|
|Xamarin.Android|API 14+|
|Windows 10 UWP|10+|

#### Usage
Instead of using an Image simply use a CircleImage instead!

You **MUST** set the width & height requests to the same value and you will want to use `Aspect.AspectFill` for the value of the `Aspect` property. Here is a sample:

```csharp
new CircleImage
{
  BorderColor = Color.White,
  BorderThickness = 3,
  HeightRequest = 150,
  WidthRequest = 150,
  Aspect = Aspect.AspectFill,
  HorizontalOptions = LayoutOptions.Center,
  Source = UriImageSource.FromUri(new Uri("http://upload.wikimedia.org/wikipedia/commons/5/55/Tamarin_portrait.JPG"))
}
```

**XAML:**

First add the xmlns namespace:
```xml
xmlns:controls="clr-namespace:ImageCircle.Forms.Plugin.Abstractions;assembly=ImageCircle.Forms.Plugin"
```

If using 2.0 it is:
	
```xml
 xmlns:controls="clr-namespace:ImageCircle.Forms.Plugin.Abstractions;assembly=ImageCircle.Forms.Plugin.Abstractions"
 ```

Then add the xaml:

```xml
<controls:CircleImage Source="{Binding Image}" Aspect="AspectFill">
  <controls:CircleImage.WidthRequest>
    <OnPlatform x:TypeArguments="x:Double">
      <On Platform="Android, iOS">55</On>
      <On Platform="WinPhone">75</On>
    </OnPlatform>
  </controls:CircleImage.WidthRequest>
  <controls:CircleImage.HeightRequest>
    <OnPlatform x:TypeArguments="x:Double">
      <On Platform="Android, iOS">55</On>
      <On Platform="WinPhone">75</On>
    </OnPlatform>
  </controls:CircleImage.HeightRequest>
</controls:CircleImage>
```

**Bindable Properties**

You are able to set the ```BorderColor``` to a Forms.Color to display a border around your image and also ```BorderThickness``` for how thick you want it. 

You can also set ```FillColor``` to the Forms.Color to fill the circle. DO NOT set ```BackgroundColor``` as that will be the square the entire image takes up.

These are supported in iOS, Android, WinRT, and UWP (not on Windows Phone 8 Silverlight).

### Final Builds
For linking you may need to add:

#### Android:
```
ImageCircle.Forms.Plugin.Abstractions;ImageCircle.Forms.Plugin.Android;
```

#### iOS:
```
--linkskip=ImageCircle.Forms.Plugin.iOS --linkskip=ImageCircle.Forms.Plugin.Abstractions
```

#### UWP:
Be sure to read through the [troubleshooting for UWP with .NET Native](https://developer.xamarin.com/guides/xamarin-forms/platform-features/windows/installation/universal/#Troubleshooting) for your final package. You should add the package to the Init call of Xamarin.Forms such as:

```csharp
var rendererAssemblies = new[]
{
    typeof(ImageCircleRenderer).GetTypeInfo().Assembly
};
Xamarin.Forms.Forms.Init(e, rendererAssemblies);

```


#### License
Licensed under MIT, see license file

### Want To Support This Project?
All I have ever asked is to be active by submitting bugs, features, and sending those pull requests down! Want to go further? Make sure to subscribe to my weekly development podcast [Merge Conflict](http://mergeconflict.fm), where I talk all about awesome Xamarin goodies and you can optionally support the show by becoming a [supporter on Patreon](https://www.patreon.com/mergeconflictfm).

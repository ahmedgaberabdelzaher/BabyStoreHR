using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using ImageCircle.Forms.Plugin.iOS;
using Syncfusion.SfPdfViewer.XForms.iOS;
using Syncfusion.SfRangeSlider.XForms.iOS;
using UIKit;
using Xamarin;

namespace HrApp.iOS
{
    public class Application
    {
        // This is the main entry point of the application.
        static void Main(string[] args)
        {
            // if you want to use a different Application Delegate class from "AppDelegate"
            // you can specify it here.
            AiForms.Effects.iOS.Effects.Init();
           // SfPdfDocumentViewRenderer.Init();

         //   SfRangeSliderRenderer.Init();
            ImageCircleRenderer.Init();
          IQKeyboardManager.SharedManager.Enable = true;

            UIApplication.Main(args, null, "AppDelegate");
        }

    }
}

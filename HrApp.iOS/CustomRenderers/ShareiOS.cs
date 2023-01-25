using Foundation;
using HrApp.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(HrApp.iOS.CustomRenderers.ShareiOS))]

namespace HrApp.iOS.CustomRenderers
{
  //Register the iOS implementation of IShare with DependencyService
 
    
        public class ShareiOS : IShare
        {
            // MUST BE CALLED FROM THE UI THREAD
            public async Task Show(string title, string message, string filePath)
            {


                var items = new NSObject[] { NSObject.FromObject(title), NSUrl.FromFilename(filePath) };
                var activityController = new UIActivityViewController(items, null);
                var rootController = UIApplication.SharedApplication.KeyWindow.RootViewController;


                NSString[] excludedActivityTypes = null;
                excludedActivityTypes = new NSString[] { UIActivityType.AssignToContact, UIActivityType.AddToReadingList, UIActivityType.CopyToPasteboard, UIActivityType.SaveToCameraRoll };

                if (excludedActivityTypes != null && excludedActivityTypes.Length > 0)
                    activityController.ExcludedActivityTypes = excludedActivityTypes;

                await rootController.PresentViewControllerAsync(activityController, true);
            }
        }
    }

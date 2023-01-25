using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using HrApp.Services.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(HrApp.Droid.CustomeRenderers.ShareAndroid))]

namespace HrApp.Droid.CustomeRenderers
{
   //Register the Android implementation of ISave with DependencyService
  
    //Register the Android implementation of IShare with DependencyService
  
    
        class ShareAndroid : IShare
        {
            private readonly Context context;
            public ShareAndroid()
            {
                context = Android.App.Application.Context;
            }
            public Task Show(string title, string message, string filePath)
            {
            try
            {
                var uri = Android.Net.Uri.Parse("file://" + filePath);
                var contentType = "application/pdf";
                var intent = new Intent(Intent.ActionSend);
                intent.PutExtra(Intent.ExtraStream, uri);
                intent.PutExtra(Intent.ExtraText, string.Empty);
                intent.PutExtra(Intent.ExtraSubject, message ?? string.Empty);
                intent.SetType(contentType);
                var chooserIntent = Intent.CreateChooser(intent, title ?? string.Empty);
                chooserIntent.SetFlags(ActivityFlags.ClearTop);
                chooserIntent.SetFlags(ActivityFlags.NewTask);
                context.StartActivity(chooserIntent);

                return Task.FromResult(true);
            }
            catch (Exception ex)
            {
                return null;

            }
        }
        }
    }



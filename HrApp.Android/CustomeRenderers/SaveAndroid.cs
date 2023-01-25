

using HrApp.Services.Interface;
using System;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(HrApp.Droid.CustomeRenderers.SaveAndroid))]

namespace HrApp.Droid.CustomeRenderers
{
    public class SaveAndroid : ISave
    {
        public string Save(MemoryStream stream, string Filename)
        {
            try
            {


                string root = null;
             //   string fileName = "SavedDocument.pdf";
                //Get the root folder of the application
                /*  if (Android.OS.Environment.IsExternalStorageEmulated)
                  {
                      root = Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryDownloads).AbsolutePath;
                  }*/
                if (Android.OS.Environment.IsExternalStorageEmulated)
                {
                   // root = Android.OS.Environment.ExternalStorageDirectory.ToString();

                   root = Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryDownloads).AbsolutePath;

                 //   root = Android.OS.Environment.ExternalStorageDirectory.ToString();
                }
                //Create a new folder with name Syncfusion
          /*      Java.IO.File myDir = new Java.IO.File(root + "/HRAlseef");
                myDir.Mkdir();*/
                //Create a new file with the name fileName in the folder Syncfusion
                Java.IO.File file = new Java.IO.File(root, Filename);
                string filePath = file.Path;
                //If the file already exists delete it
                if (file.Exists()) file.Delete();
                
                File.WriteAllBytes(file.ToString(), stream.ToArray());
              //  Java.IO.FileOutputStream outs = new Java.IO.FileOutputStream(file);
                //Save the input stream to the created file
               // outs.Write(stream.ToArray());
                var ab = file.Path;
              //  outs.Flush();
               // outs.Close();
                return filePath;
            }
            catch (Exception ex)
            {
                return "";
            }
            }
    }

}
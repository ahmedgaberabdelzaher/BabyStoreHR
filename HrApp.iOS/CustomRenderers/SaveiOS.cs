using Foundation;
using HrApp.Services.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(HrApp.iOS.CustomRenderers.SaveiOS))]

namespace HrApp.iOS.CustomRenderers
{
    //Register the iOS implementation of ISave with DependencyService
  

    
        public class SaveiOS : ISave
        {
            public string Save(MemoryStream fileStream,string Filename)
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                //The path to which the file is to be saved
                string filepath = Path.Combine(path, Filename);

                FileStream outputFileStream = File.Open(filepath, FileMode.Create);
                fileStream.Position = 0;
                //Save the input stream of the PDF to the file
                fileStream.CopyTo(outputFileStream);
                outputFileStream.Close();
                return filepath;
            }
        }
    }

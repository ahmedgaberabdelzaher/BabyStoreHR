using HrApp.Services.Interface;
using HrApp.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HrApp.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PdfViwerControler : ContentPage
    {
        public PdfViwerControler()
        {
            InitializeComponent();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            
           /* var httpClient = new HttpClient();
            var vm = BindingContext as PdfVM;

           
            var stream = await httpClient.GetStreamAsync(vm.URL);

            pdfViewerControl.LoadDocument(stream);*/
        }
        private async void OnShareButtonClicked(object sender, EventArgs e)
        {
            try
            {
                var status = await Permissions.CheckStatusAsync<Permissions.StorageWrite>();
                if (status == PermissionStatus.Granted)
                { 
                
                

                string FileName = $"hrDoc{DateTime.Now.ToString("HHmmss")}";
                FileName= pdfname.Text;
                string filePath = DependencyService.Get<ISave>().Save(pdfViewerControl.SaveDocument() as MemoryStream, pdfname.Text);
                if (!string.IsNullOrEmpty(filePath))
                {
                    await Share.RequestAsync(new ShareFileRequest
                    {
                        Title = "Share File",
                        File = new ShareFile(filePath)
                    });
                }
                else
                { 
               await App.Current.MainPage.DisplayAlert("Error", "An error occurred while saving PDF file", "Ok");

                }
                
                }else
                    {
                    await App.Current.MainPage.DisplayAlert("Error", "You Have to Allow Permission Storage", "Ok");

                    var requst =  await Permissions.RequestAsync<Permissions.StorageWrite>();
                    }

                //  DependencyService.Get<IShare>().Show("Share", "Sharing PDF", filePath);
            }
            catch(Exception ex)
            {
               await App.Current.MainPage.DisplayAlert("Error",ex.Message,"Cancel");
            } }
            
    }
}
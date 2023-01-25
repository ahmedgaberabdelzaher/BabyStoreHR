using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HrApp.ViewModel
{
    public class PdfVM : ViewModelBase
    {

        private Stream _Url;

        public Stream URL
        {
            get { return _Url; }
            set { _Url = value; RaisePropertyChanged(); }
        }
        
       private string _PDFNAME;

        public string PDFNAME
        {
            get { return _PDFNAME; }
            set { _PDFNAME = value; RaisePropertyChanged(); }
        }
        public PdfVM(INavigationService navigationService, IPageDialogService dialogService) : base(navigationService, dialogService)
        {

        }
        public override void OnNavigatedFrom(INavigationParameters parameters)
        {
            base.OnNavigatedFrom(parameters);   
        }
        public override async void Initialize(INavigationParameters parameters)
        {
            if (parameters != null &&parameters.Count>0)
            {
               string Url = parameters["URL"] as string;
                PDFNAME = parameters["PDFNAME"] as string;
                if (!string.IsNullOrEmpty(Url))
                {
                    URL = await DownloadPdfStream(Url);

                }
            }
        


            base.Initialize(parameters);    
        }

        private async Task<Stream> DownloadPdfStream(string URL)
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = await httpClient.GetAsync(URL);
            //Check whether redirection is needed
            if ((int)response.StatusCode == 302)
            {
                //The URL to redirect is in the header location of the response message
                HttpResponseMessage redirectedResponse = await httpClient.GetAsync(response.Headers.Location.AbsoluteUri);
                return await redirectedResponse.Content.ReadAsStreamAsync();
            }
            return await response.Content.ReadAsStreamAsync();
        }
    }
}

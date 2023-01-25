using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using HrApp.Model;
using HrApp.Services.Interface;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
namespace HrApp.ViewModel
{
    public class DigitalValetPageViewModel : ViewModelBase
    {
        private readonly IUserServices userServices;

        
        public DigitalValetPageViewModel(INavigationService navigationService,
            IUserServices userServices,
            IPageDialogService dialogService) : base(navigationService, dialogService)
        {
            this.userServices = userServices;
        }



        #region Methods

        public async override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            await GetLinks();
            // await GetEvents(false);
        }

        private async Task GetLinks()
        {
            IsLoading = true;
            try
            {


                var request = await userServices.GetDigitalValet();

                if (request.Item2)
                {

                    Links = request.Item1;// new ObservableCollection<EventModel>();

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            IsLoading = false;
        }




        #endregion

        #region props

        private ObservableCollection<DigitalValidModel> links;

        public ObservableCollection<DigitalValidModel> Links
        {
            get
            {
                return links;
            }
            set
            {
                SetProperty(ref links, value);
            }
        }

        public DelegateCommand<DigitalValidModel> SelectLinkCommand
        {
            get
            {
                return new DelegateCommand<DigitalValidModel>(async (url) =>
                {
                    try
                    {
                        IsLoading = true;
                        await openpdfAsync(url.url);
                        IsLoading = false;
                        // await Xamarin.Essentials.Launcher.OpenAsync(url.url);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    
                });

            }
        }

        #endregion
    }
}

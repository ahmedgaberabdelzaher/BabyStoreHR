using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using HrApp.Model;
using HrApp.Services.Interface;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;

namespace HrApp.ViewModel
{
    public class QuickLinksPageViewModel : ViewModelBase
    {
        private readonly IUserServices userServices;

        public QuickLinksPageViewModel(INavigationService navigationService,
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


                var request = await userServices.GetCategoryLinks();

                if (request.Item2)
                {
                    linklist = new List<CategoryLink>();
                    linklist.AddRange(request.Item1);
                    Links = request.Item1;
                    // new ObservableCollection<EventModel>();
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

        private List<CategoryLink> linklist;

        private ObservableCollection<CategoryLink> links;
       
        public ObservableCollection<CategoryLink> Links
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

        public DelegateCommand<string> SelectLinkCommand
        {
            get
            {
                return new DelegateCommand<string>(async (url) =>
                {
                    try
                    {
                        foreach (var l in linklist)
                        {
                            if (l.titles.Contains(url)) {
                                url = l.UrLs[l.titles.IndexOf(url)];
                                break;
                                }   
                        }
                         await Xamarin.Essentials.Launcher.OpenAsync(url);
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

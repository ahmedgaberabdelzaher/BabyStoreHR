using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;

namespace HrApp.ViewModel.OnlineServicesViewModels
{
	public class OnlineServicesViewModel:ViewModelBase
	{

        ObservableCollection<Model.LookUpModel> onlineServicesMenuItems = new ObservableCollection<Model.LookUpModel>();
        public ObservableCollection<Model.LookUpModel> OnlineServicesMenuItems { get { return onlineServicesMenuItems; } set { onlineServicesMenuItems = value; RaisePropertyChanged(); } }


        Services.Interface.IOnlineServices _onlineServices;

        public OnlineServicesViewModel(Services.Interface.IOnlineServices onlineServices, INavigationService navigationService, IPageDialogService pageDialogService) : base(navigationService, pageDialogService)
        {
            _onlineServices = onlineServices;
        }

        public DelegateCommand GoToDetailsCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                  

                });

            }
        }



        public async override void OnNavigatedTo(INavigationParameters parameters)
        {
            await GetOnlineServices();
            base.OnNavigatedTo(parameters);
        }
        async Task GetOnlineServices()
        {
            try
            {
                IsLoading = true;
                var resp = await _onlineServices.GetOnlineServicesLst();
                if (resp.Item2)
                {
                    var menu = resp.Item1;
                    if (menu.result!=null)
                    {
                        var data = menu.result.data;
                        foreach (var item in data)
                        {
                            OnlineServicesMenuItems.Add(new Model.LookUpModel()
                            {
                                Id = int.Parse(item.Key),
                                Name = item.Value
                            });
                        }
                    }
                }
                IsLoading = false;
            }
            catch (Exception ex)
            {
                IsLoading = false;

            }
        }


    }
}


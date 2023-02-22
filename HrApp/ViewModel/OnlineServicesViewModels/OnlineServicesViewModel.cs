using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;

namespace HrApp.ViewModel.OnlineServicesViewModels
{
	public class OnlineServicesMenuViewModel:ViewModelBase
	{

        ObservableCollection<Model.LookUpModel> onlineServicesMenuItems = new ObservableCollection<Model.LookUpModel>();
        public ObservableCollection<Model.LookUpModel> OnlineServicesMenuItems { get { return onlineServicesMenuItems; } set { onlineServicesMenuItems = value; RaisePropertyChanged(); } }

        Model.LookUpModel selectedRequestType;
        public Model.LookUpModel SelectedRequestType { get { return selectedRequestType; } set { selectedRequestType = value;RaisePropertyChanged(); } }

        Services.Interface.IOnlineServices _onlineServices;

        public OnlineServicesMenuViewModel(Services.Interface.IOnlineServices onlineServices, INavigationService navigationService, IPageDialogService pageDialogService) : base(navigationService, pageDialogService)
        {
            _onlineServices = onlineServices;
            OnlineServicesMenuItems = new ObservableCollection<Model.LookUpModel>()
            {
                 new Model.LookUpModel(){  icon="leaverequest.svg",Id=1,Name="Leave Request"},
                              new Model.LookUpModel(){  icon="leaverequest.svg",Id=1,Name="Leave Request"},
                                           new Model.LookUpModel(){  icon="leaverequest",Id=1,Name="Leave Request"},
                                                        new Model.LookUpModel(){  icon="leaverequest.svg",Id=1,Name="Leave Request"},
                                                                     new Model.LookUpModel(){  icon="leaverequest.svg",Id=1,Name="Leave Request"},
                                                                                  new Model.LookUpModel(){  icon="leaverequest.svg",Id=1,Name="Leave Request"},             new Model.LookUpModel(){  icon="leaverequest",Id=1,Name="Leave Request"},
                                                                                               new Model.LookUpModel(){  icon="leaverequest",Id=1,Name="Leave Request"}
            };
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

      public DelegateCommand SelectedRequestTypeChangedCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {

                    if (SelectedRequestType!=null)
                    {
                        var navParameters = new NavigationParameters();
                        navParameters.Add("RequesttypeId", SelectedRequestType.Id);
                          navParameters.Add("List", 1);
                          navParameters.Add("IsFromManager", "1");
                          navParameters.Add("RequesttypeName", SelectedRequestType.Name);
                        navParameters.Add("PageTitle", "Leaves");
                        await NavigationService.NavigateAsync("LeavesList", navParameters);
                
                 
                    }
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
                
                var resp = await _onlineServices.GetOnlineServicesLst(new Model.OnlineServicesModels.OnlineServiceMenuModel());
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


using System;
using HrApp.Model;
using HrApp.Model.OdooModels;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Essentials;
using System.Linq;
using Xamarin.Forms;
using HrApp.Helpers;

namespace HrApp.ViewModel.OnlineServicesViewModels
{

    public class SalleryTransferRequestVIewModel : DetailsandActionsViewModel<SlleryTransferLst>
    {

        ObservableCollection<SlleryTransferLst> requests = new ObservableCollection<SlleryTransferLst>();
        public ObservableCollection<SlleryTransferLst> Requests { get { return requests; } set { requests = value; RaisePropertyChanged(); } }

        ObservableCollection<CustodyProperityLst> bankLst = new ObservableCollection<CustodyProperityLst>();
        public ObservableCollection<CustodyProperityLst> BankLst { get { return bankLst; } set { bankLst = value; RaisePropertyChanged(); } }

        CustodyProperityLst slectedBank;
        public CustodyProperityLst SlectedBank { get { return slectedBank; } set { slectedBank = value; RaisePropertyChanged(); } }


        string name;
        public string Name { get { return name; } set { name = value; RaisePropertyChanged(); } }

        string iBANNo="";
        public string IBANNo { get { return iBANNo; } set { iBANNo = value; RaisePropertyChanged(); } }

        ObservableCollection<userData> empLst = new ObservableCollection<userData>();
        public ObservableCollection<userData> EmpLst { get { return empLst; } set { empLst = value; RaisePropertyChanged(); } }

        userData selectedEmployee;
        public userData SelectedEmployee { get { return selectedEmployee; } set { selectedEmployee = value; RaisePropertyChanged(); } }

        bool isNewRequest;
        public bool IsNewRequest { get { return isNewRequest; } set { isNewRequest = value; RaisePropertyChanged(); } }


        Services.Interface.IOnlineServices _onlineServices;
        public SalleryTransferRequestVIewModel(Services.Interface.IOnlineServices onlineServices, INavigationService navigationService, IPageDialogService pageDialogService, Services.Interface.IUserServices userServices) : base(onlineServices,navigationService, pageDialogService, userServices)
        {
            _onlineServices = onlineServices;
            GetSalleryTransferLst();

        }



        public DelegateCommand SelectBankCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    var Assests = await GetBankLst();
                    if (Assests != null)
                    {
                        var rs = await DialogService.DisplayActionSheetAsync("Select Request Type", "Cancel", "", Assests.Select(c => c.name).ToArray());
                        if (rs != null && rs != "Cancel")
                        {
                            Name = rs;
                            SlectedBank = Assests.First(c => c.name == Name);
                        }
                    }
                    else
                    {
                        await DialogService.DisplayAlertAsync("", "No assets Found", "Ok");
                        IsLoading = false;
                    }
                    IsLoading = false;


                });
            }
        }


        public DelegateCommand<SlleryTransferLst> CancelRequestCommand
        {
            get
            {
                return new DelegateCommand<SlleryTransferLst>(async (e) =>
                {
                    try
                    {
                        IsLoading = true;
                        if (e != null)
                        {
                            var body = new GetRequestDetailsBody()
                            {
                                res_id = e.id,
                                res_model = "ess.salary.transfer.request"
                            };
                            await Cancelrequest(body);
                            await GetSalleryTransferLst();
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                    finally
                    {
                        IsLoading = false;
                    }


                });

            }
        }

        public DelegateCommand AddNewRequestCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    IsNewRequest = true;
                });
            }
        }

        public DelegateCommand CloseNewRequestCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    CleareNewRequestData();
                });
            }
        }

        private void CleareNewRequestData()
        {
            IsNewRequest = false;
            SlectedBank = new Model.OdooModels.CustodyProperityLst();
            IBANNo = "";
        }

       

        public DelegateCommand SendSalleryTransferRequestCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    await SendSalleryTransferRequest();
                });
            }
        }


        async Task SendSalleryTransferRequest()
        {
            try
            {
                IsLoading = true;
                if (!string.IsNullOrEmpty(IBANNo))
                {


                    var model = new SallertTransferBody()
                    {

                        employee_id = Preferences.Get("userId", 0),
                        new_bank_id= SlectedBank.id,
                        new_iban_number=IBANNo
                    };
                    var body = new BaseOdoModel<SallertTransferBody>()
                    {
                        @params = model
                    };
                    var resp = await _onlineServices.SendSalleytransferRequest(body);
                    var result = await resp.Content.ReadAsStringAsync();
                    if (resp.IsSuccessStatusCode)
                    {
                        CleareNewRequestData();
                        // await DialogService.DisplayAlertAsync("", "Your request has been submitted successfully", "Ok");
                        await DialogService.DisplayAlertAsync("", "Your request has been submitted successfully", "Ok");
                        await GetSalleryTransferLst();

                    }
                    else
                    {
                        await DialogService.DisplayAlertAsync("", "Erro Occured", "Cancel");

                    }




                }
                else
                {
                    await DialogService.DisplayAlertAsync("", "Enter All request Data", "Ok");

                }
            }

            //   }
            catch (Exception ex)
            {
                IsLoading = false;

            }
            finally
            {
                IsLoading = false;
            }

        }

        async Task GetSalleryTransferLst()
        {
            try
            {
                IsLoading = true;
                var resp = await _onlineServices.SalleytransferRequestLst(new BaseOdoModel<GetLeavesBody>()
                {
                    @params = new GetLeavesBody()
                    {
                        employee_id = Preferences.Get("userId", 0)
                    }
                });

                if (resp.Item2)
                {

                    Requests = resp.Item1.result.data;
                }
                IsLoading = false;
            }
            catch (Exception ex)
            {
                IsLoading = false;

            }
        }

        async Task<ObservableCollection<CustodyProperityLst>> GetBankLst()
        {
            try
            {
                IsLoading = true;
                var resp = await _onlineServices.GetBankLst(new BaseOdoModel<GetLeavesBody>()
                {
                    @params = new GetLeavesBody()
                    {

                    }
                });

                if (resp.Item2)
                {

                    var data = resp.Item1.result.data;
                    return data;
                }
                IsLoading = false;

                return null;

            }
            catch (Exception ex)
            {
                IsLoading = false;

                return null;


            }
        }

        public override async void OnNavigatedTo(INavigationParameters parameters)
        {
            try
            {
                if (parameters != null && parameters.Count > 0)
                {

                    res_model = parameters["res_model"].ToString();
                    res_id = int.Parse(parameters["res_id"].ToString());
                    var data = await GetRequestDetails();
                    SetDetailsData(data);
                }

            }
            catch (Exception ex)
            {

            }
        }
        public void SetDetailsData(SlleryTransferLst data)
        {
            EmployeeName = data.employee_id?[1].ToString();

            Name = ConvertDynamicToValue.Convert(data.new_bank_id);
            IBANNo = ConvertDynamicToValue.Convert(data.new_iban_number); 

            User.bank = ConvertDynamicToValue.Convert(data.current_bank_name);
            User.iban = ConvertDynamicToValue.Convert(data.current_iban_number);

        }


    }

}


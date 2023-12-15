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

namespace HrApp.ViewModel.OnlineServicesViewModels
{
	
    public class LettersViewModel : DetailsandActionsViewModel<LetterRequests>
    {

        ObservableCollection<LetterRequests> requests = new ObservableCollection<LetterRequests>();
        public ObservableCollection<LetterRequests> Requests { get { return requests; } set { requests = value; RaisePropertyChanged(); } }

       
        ObservableCollection<CustodyProperityLst> letterTypes = new ObservableCollection<CustodyProperityLst>();
        public ObservableCollection<CustodyProperityLst> LetterTypes { get { return letterTypes; } set { letterTypes = value; RaisePropertyChanged(); } }


        CustodyProperityLst selectedletterTypes;
        public CustodyProperityLst SelectedletterTypes { get { return selectedletterTypes; } set { selectedletterTypes = value; RaisePropertyChanged(); } }

        ObservableCollection<CustodyProperityLst> letterDetails = new ObservableCollection<CustodyProperityLst>();
        public ObservableCollection<CustodyProperityLst> LetterDetails { get { return letterDetails; } set { letterDetails = value; RaisePropertyChanged(); } }


        CustodyProperityLst selectedletterDetails;
        public CustodyProperityLst SelectedletterDetails { get { return selectedletterDetails; } set { selectedletterDetails = value; RaisePropertyChanged(); } }


        ObservableCollection<CustodyProperityLst> letterCompany = new ObservableCollection<CustodyProperityLst>();
        public ObservableCollection<CustodyProperityLst> LetterCompany { get { return letterCompany; } set { letterCompany = value; RaisePropertyChanged(); } }

        CustodyProperityLst selctedletterCompany;
        public CustodyProperityLst SelctedletterCompany { get { return selctedletterCompany; } set { selctedletterCompany = value; RaisePropertyChanged(); } }


        string name;
        public string Name { get { return name; } set { name = value; RaisePropertyChanged(); } }

        string typeName;
        public string TypeName { get { return typeName; } set { typeName = value; RaisePropertyChanged(); } }

        string companyName;
        public string CompanyName { get { return companyName; } set { companyName = value; RaisePropertyChanged(); } }

        string detailsName;
        public string DetailsName { get { return detailsName; } set { detailsName = value; RaisePropertyChanged(); } }


        string redirectedTo="";
        public string RedirectedTo { get { return redirectedTo; } set { redirectedTo = value; RaisePropertyChanged(); } }

        ObservableCollection<userData> empLst = new ObservableCollection<userData>();
        public ObservableCollection<userData> EmpLst { get { return empLst; } set { empLst = value; RaisePropertyChanged(); } }

        userData selectedEmployee;
        public userData SelectedEmployee { get { return selectedEmployee; } set { selectedEmployee = value; RaisePropertyChanged(); } }

        bool isNewRequest;
        public bool IsNewRequest { get { return isNewRequest; } set { isNewRequest = value; RaisePropertyChanged(); } }

        bool isElectronicLetter;
        public bool IsElectronicLetter { get { return isElectronicLetter; } set { isElectronicLetter = value; RaisePropertyChanged(); } }


        Services.Interface.IOnlineServices _onlineServices;
        public LettersViewModel(Services.Interface.IOnlineServices onlineServices, INavigationService navigationService, IPageDialogService pageDialogService, Services.Interface.IUserServices userServices) : base(onlineServices,navigationService, pageDialogService, userServices)
        {
            _onlineServices = onlineServices;
            GetLetterRequestsst();

        }

        public DelegateCommand<LetterRequests> CancelRequestCommand
        {
            get
            {
                return new DelegateCommand<LetterRequests>(async (e) =>
                {
                    try
                    {
                        IsLoading = true;
                        if (e != null)
                        {
                            var body = new GetRequestDetailsBody()
                            {
                                res_id = e.id,
                                res_model = "ess.letter.request"
                            };
                            await Cancelrequest(body);
                            await GetLetterRequestsst();
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


        public DelegateCommand SelectLetterTypeCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    var Data = await GetLetterTypes();
                    if (Data != null)
                    {
                        var rs = await DialogService.DisplayActionSheetAsync("Select Letter Type", "Cancel", "", Data.Select(c => c.name).ToArray());
                        if (rs != null && rs != "Cancel")
                        {
                            TypeName = rs;
                            SelectedletterTypes = Data.First(c => c.name == TypeName);
                        }
                    }
                    else
                    {
                        await DialogService.DisplayAlertAsync("", "No Types Found", "Ok");
                        IsLoading = false;
                    }
                    IsLoading = false;


                });
            }
        }

        public DelegateCommand SelectLetterCompanyCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    var Data = await GetLetterCompany();
                    if (Data != null)
                    {
                        var rs = await DialogService.DisplayActionSheetAsync("Select Letter Company", "Cancel", "", Data.Select(c => c.name).ToArray());
                        if (rs != null && rs != "Cancel")
                        {
                            CompanyName = rs;
                          SelctedletterCompany = Data.First(c => c.name == CompanyName);
                        }
                    }
                    else
                    {
                        await DialogService.DisplayAlertAsync("", "No Data Found", "Ok");
                        IsLoading = false;
                    }
                    IsLoading = false;


                });
            }
        }

        public DelegateCommand SelectLetterDetailsCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    var Data = await GetLetterDetails();
                    if (Data != null)
                    {
                        var rs = await DialogService.DisplayActionSheetAsync("Select Letter Details", "Cancel", "", Data.Select(c => c.name).ToArray());
                        if (rs != null && rs != "Cancel")
                        {
                            DetailsName = rs;
                            selectedletterDetails = Data.First(c => c.name == DetailsName);
                        }
                    }
                    else
                    {
                        await DialogService.DisplayAlertAsync("", "No Data Found", "Ok");
                        IsLoading = false;
                    }
                    IsLoading = false;


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
            SelectedletterDetails = new Model.OdooModels.CustodyProperityLst();
            SelctedletterCompany = new Model.OdooModels.CustodyProperityLst();
            SelectedletterTypes = new Model.OdooModels.CustodyProperityLst();
            RedirectedTo = "";

        }



        public DelegateCommand SendLetterRequestCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    await SendLetterRequest();
                });
            }
        }


        async Task SendLetterRequest()
        {
            try
            {
                IsLoading = true;
                if (!string.IsNullOrEmpty(RedirectedTo))
                {


                    var model = new LetterRequestBody()
                    {

                        employee_id = Preferences.Get("userId", 0),
                        certified_company_id = SelctedletterCompany.id,
                        directed_to = RedirectedTo,
                         electronic_letter=IsElectronicLetter,
                          letter_detail_id=SelectedletterDetails.id,
                           letter_type_id=SelectedletterTypes.id
                          
                    };
                    var body = new BaseOdoModel<LetterRequestBody>()
                    {
                        @params = model
                    };
                    var resp = await _onlineServices.SendLetterRequest(body);
                    var result = await resp.Content.ReadAsStringAsync();
                    if (resp.IsSuccessStatusCode)
                    {
                        CleareNewRequestData();
                        // await DialogService.DisplayAlertAsync("", "Your request has been submitted successfully", "Ok");
                        await DialogService.DisplayAlertAsync("", "Your request has been submitted successfully", "Ok");
                        await GetLetterRequestsst();

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

        async Task GetLetterRequestsst()
        {
            try
            {
                IsLoading = true;
                var resp = await _onlineServices.LetterRequestLst(new BaseOdoModel<GetLeavesBody>()
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

        async Task<ObservableCollection<CustodyProperityLst>> GetLetterTypes()
        {
            try
            {
                IsLoading = true;
                var resp = await _onlineServices.GetLetterTypes(new BaseOdoModel<GetLeavesBody>()
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

        async Task<ObservableCollection<CustodyProperityLst>> GetLetterCompany()
        {
            try
            {
                IsLoading = true;
                var resp = await _onlineServices.GetLetterCompany(new BaseOdoModel<GetLeavesBody>()
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

        async Task<ObservableCollection<CustodyProperityLst>> GetLetterDetails()
        {
            try
            {
                IsLoading = true;
                var resp = await _onlineServices.GetLetterDetails(new BaseOdoModel<GetLeavesBody>()
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
        public void SetDetailsData(LetterRequests data)
        {

            CompanyName = data.certified_company_id[1]?.ToString();
                       RedirectedTo = data.directed_to;
            IsElectronicLetter = data.electronic_letter;
            DetailsName = data.letter_detail_id[1]?.ToString(); 
                    EmployeeName = data.employee_id[1].ToString();

        }

    }

}


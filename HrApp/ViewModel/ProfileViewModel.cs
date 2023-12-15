using System;
using HrApp.Helpers;
using HrApp.Model;
using Newtonsoft.Json;
using Prism.Navigation;
using Prism.Services;
using Xamarin.Essentials;

namespace HrApp.ViewModel
{
    public class ProfileViewModel:ViewModelBase
    {

        public string ProfileSvgPath => "HrApp.Images.Profile.svg";
        int _years;

        public int Years { get { return _years; } set { _years = value; RaisePropertyChanged(); } }
 int _Month;

        public int Month { get { return _Month; } set { _Month = value; RaisePropertyChanged(); } }

        bool _isMoretenYears;

        public bool IsMoretenYears { get { return _isMoretenYears; } set { _isMoretenYears = value; RaisePropertyChanged(); } }


        public ProfileViewModel(INavigationService navigationService,IPageDialogService pageDialogService):base(navigationService,pageDialogService)
        {


              var days = DateTimeHelper.DateTimeFormater(DateTime.Now) - DateTime.Parse(User.joining_date);
            //var days = DateTime.Now - DateTime.Now.AddDays(300);

            Years = days.Days / 365;
            var months = days.Days - (Years * 365);
            Month = months / 30;
            if (Years>=10)
            {
                IsMoretenYears = true;
            }
        }
      
    }
}

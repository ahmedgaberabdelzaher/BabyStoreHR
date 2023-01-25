using System;
using HrApp.Model;
using Newtonsoft.Json;
using Prism.Navigation;
using Prism.Services;
using Xamarin.Essentials;

namespace HrApp.ViewModel
{
    public class ProfileViewModel:ViewModelBase
    {
      

        int _years;

        public int Years { get { return _years; } set { _years = value; RaisePropertyChanged(); } }
 int _Month;

        public int Month { get { return _Month; } set { _Month = value; RaisePropertyChanged(); } }

        bool _isMoretenYears;

        public bool IsMoretenYears { get { return _isMoretenYears; } set { _isMoretenYears = value; RaisePropertyChanged(); } }


        public ProfileViewModel(INavigationService navigationService,IPageDialogService pageDialogService):base(navigationService,pageDialogService)
        {
          
            var days = DateTime.Now - User.joininG_DATE;
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

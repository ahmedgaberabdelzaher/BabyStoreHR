using HrApp.Helpers;
using HrApp.Model.FAQModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace HrApp.Services.Interface
{
    public interface IFAQServices
    {
        Task<Tuple<ObservableCollection<FAQModel>, bool, string>> GetFAQList();



    }
}

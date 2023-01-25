using HrApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HrApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LiveChatList : ContentPage
    {
        public LiveChatList()
        {
            InitializeComponent();
         
        }

       

        private async void Listview_Scrolled(object sender, ItemsViewScrolledEventArgs e)
        {
            int lastindex = e.LastVisibleItemIndex + 1;
            if (BindingContext != null)
            {
                var vm = BindingContext as ChatViewModel;

                if (vm.canLoadmore&&!vm.IsLoading)
                {
                    if ((lastindex) == vm.UsersLst.Count)
                    {

                        await vm.LoadMoreAsync();
                        await Task.Delay(100);

                    }
                }

            }

        }

    }
        /*  private async void Listview_ItemAppearing(object sender, ItemVisibilityEventArgs e)
 {
     if (BindingContext != null)
     {
         var vm = BindingContext as ChatViewModel;
         if (vm.AutoScrollDown || e.ItemIndex == vm.MessagesList.Count - 5)
         {

             Device.BeginInvokeOnMainThread(() =>
             {


                 Listview?.ScrollToLast();
             });
             vm.AutoScrollDown = false;
         }
         else
         {
             if (e.ItemIndex == vm.MessagesList.Count - 1)
             {
                 vm.ScrollDown = false;
                 vm.Scrollpaging = false;
             }
             else if (e.ItemIndex == 0)
             {
                 if (vm.canLoadmore)
                 {

                     vm.Scrollpaging = true;
                 }

             }

         }


     }
 }
*/
    }

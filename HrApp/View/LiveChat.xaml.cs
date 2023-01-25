using HrApp.ViewModel;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HrApp.View
{
    public partial class LiveChat : ContentPage
    {
        bool fristtime;
        public LiveChat()
        {
            InitializeComponent();
            fristtime=true;
        }

       

        protected override  void OnAppearing()
        {
            base.OnAppearing();
           /* if (BindingContext != null)
            {
                var vm = BindingContext as LiveChatVM;
                for (int i = 0; i < 25; i++)
                {
                    if (!vm.IsLoading)
                    {

                        Device.BeginInvokeOnMainThread(() =>
                        {


                            Listview?.ScrollToLast();
                        });
                        break;

                    }

                    await Task.Delay(1000);

                }

            }
      */ 
        }
        public void ScrollTap(object sender, System.EventArgs e)
        {
            lock (new object())
            {
                if (BindingContext != null)
                {
                    var vm = BindingContext as LiveChatVM;

                    Device.BeginInvokeOnMainThread(() =>
                    {


                        Listview?.ScrollToLast();
                    });
                    vm.ScrollDown = false;

                }

            }
        }

        private  void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            if (BindingContext != null)
            {
                var vm = BindingContext as LiveChatVM;

                if (vm.AutoScrollDown)
                {
                    
                    Device.BeginInvokeOnMainThread(() =>
                    {


                        Listview?.ScrollToLast();
                    });
                    vm.AutoScrollDown = false;
                }



            }


        }

        private async void Listview_Scrolled(object sender, ScrolledEventArgs e)
        {
           

           /* if (BindingContext != null)
            {
                var vm = BindingContext as LiveChatVM;
                if (vm.canLoadmore && !vm.IsLoading && !vm.FristLoad)
                {
                    if (e.ScrollY ==0)
                    {

                        await vm.GetPagingreplysAsync();

                        await Task.Delay(100);

                    }
                }
             
            }*/
        }

        private async void Listview_ItemAppearing(object sender, ItemVisibilityEventArgs e)
        {
            if (BindingContext != null)
            {
                var vm = BindingContext as LiveChatVM;
                if (e.ItemIndex == vm.MessagesList.Count - 1)
                {
                    if (vm.canLoadmore && !vm.IsLoading)
                    {
                        await vm.GetPagingreplysAsync();
                        await Task.Delay(100);
                    }
                }
             /*   if (vm.AutoScrollDown|| e.ItemIndex == vm.MessagesList.Count - 5)
                {

                    Device.BeginInvokeOnMainThread(() =>
                    {


                        Listview?.ScrollToLast();
                    });
                    vm.AutoScrollDown = false;
                }
                else if(e.ItemIndex==vm.MessagesList.Count-1)
                {

                    if (vm.canLoadmore && !vm.IsLoading )
                    {
                        await vm.GetPagingreplysAsync();
                        await Task.Delay(100);
                    }
                    else
                    {
                        fristtime = false;
                    }

                }
*/

            }
        }

        private async void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {

              if (BindingContext != null)
             {
              var vm = BindingContext as LiveChatVM;


            await vm.GetPagingreplysAsync();

              await Task.Delay(300);
             vm.Scrollpaging = false;

         }

         }
        }
    }

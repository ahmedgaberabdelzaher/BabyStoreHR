//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

[assembly: global::Xamarin.Forms.Xaml.XamlResourceIdAttribute("HrApp.View.MgrStaffSchedulePage.xaml", "View/MgrStaffSchedulePage.xaml", typeof(global::HrApp.View.MgrStaffSchedulePage))]

namespace HrApp.View {
    
    
    [global::Xamarin.Forms.Xaml.XamlFilePathAttribute("View/MgrStaffSchedulePage.xaml")]
    public partial class MgrStaffSchedulePage : global::Xamarin.Forms.ContentPage {
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private global::Xamarin.Forms.Picker fromPicker;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private global::XamForms.Controls.Calendar MyCalendar;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private global::Xamarin.Forms.Label YearMonthLab;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private void InitializeComponent() {
            global::Xamarin.Forms.Xaml.Extensions.LoadFromXaml(this, typeof(MgrStaffSchedulePage));
            fromPicker = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::Xamarin.Forms.Picker>(this, "fromPicker");
            MyCalendar = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::XamForms.Controls.Calendar>(this, "MyCalendar");
            YearMonthLab = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::Xamarin.Forms.Label>(this, "YearMonthLab");
        }
    }
}

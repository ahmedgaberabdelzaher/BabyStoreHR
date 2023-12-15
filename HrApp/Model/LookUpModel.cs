using System;
using System.Reflection;

namespace HrApp.Model
{
    public class LookUpModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string icon { get; set; }
        public string PageName { get; set; }
        public Assembly SvgAssembly
        {
            get { return typeof(App).GetTypeInfo().Assembly; }
        }
      //  public string IconPath { get{ return "HrApp.Images." + icon; } }
    }
}

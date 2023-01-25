using System;
using System.Collections.Generic;
using System.Text;

namespace HrApp.Model.ChatModels
{
    public class GetChatUsers
    {
        public int id { get; set; }
        public DateTime creationDate { get; set; }
        public DateTime modificationDate { get; set; }
        public int userOneID { get; set; }
        public int userTwoID { get; set; }
        public string FileContent { get; set; }
        public string FileName { get; set; }
        public int IsReadByStuff { get; set; }
        public int IsReadByAgent { get; set; }
        public string userOneName { get; set; }
        public string userOnePhotography { get; set; }
        public string userOneDepartment { get; set; }
    }
}

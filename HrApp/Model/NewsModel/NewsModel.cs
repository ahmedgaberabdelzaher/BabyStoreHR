using System;
using System.Collections.Generic;
using System.Text;

namespace HrApp.Model.NewsModel
{
  public  class NewsModel
    {
        public int id { get; set; }
        public int siteId { get; set; }
        public object url { get; set; }
        public object siteUrl { get; set; }
        public string siteName { get; set; }
        public string titleArabic { get; set; }
        public object titleEnglis { get; set; }
        public string FileName { get; set; } = null;
        public int? Type { get; set; } = 0;
        public string CircularFileURL { get; set; } = null;
        public int pageLayoutId { get; set; }
        public DateTime pageDate { get; set; }
        public string descriptionArabic { get; set; }
        public object descriptionEnglish { get; set; }
        public string contentArabic { get; set; }
        public object contentEnglish { get; set; }
        public int status { get; set; }
        public int orderId { get; set; }
        private object _fileContentString;

        public object fileContentString
        {
            get { return _fileContentString; }
            set { _fileContentString = value; }
        }

        public DateTime  createdDate { get; set; }
        public object createdBy { get; set; }
      //  public object fileContentString { get; set; }
        public bool openInNewWindow { get; set; }
        public int version { get; set; }
        public int sharedPageId { get; set; }
        public bool isLatesVersion { get; set; }
        public bool isFinalApproved { get; set; }
    }
}

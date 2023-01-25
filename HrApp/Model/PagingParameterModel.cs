using System;
using System.Collections.Generic;
using System.Text;

namespace HrApp.Model
{
    public class PagingParameterModel
    {
        
        public int pageNumber { get; set; } 
        public int _pageSize { get; set; } 
        public int pageSize { get; set; } 
      
        public int staffId { get; set; } 
        public int conversationId { get; set; } 
    }

}

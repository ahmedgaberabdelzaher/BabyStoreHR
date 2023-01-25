using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace HrApp.Services.Interface
{
    public interface ISave

    {
        string Save(MemoryStream fileStream,string filename);
    }
}

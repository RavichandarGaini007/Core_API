using Common.BusinessLogicLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.BusinessLogicLayer.IServices
{
    public interface ICommonServices
    {
        public Task<ResponseModel> fgrnEntry(fgrnReqModel req, string uname, string pass);
        public Task<ResponseModel> empPendAckCount(string userid);

    }
}

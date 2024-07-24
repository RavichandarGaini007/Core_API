using Common.BusinessLogicLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.BusinessLogicLayer.IServices
{
    public interface IRPLServices
    {
        public Task<ResponseModel> getMasterData(rplModel rplModel);
        public Task<ResponseModel> getDesigEmpMasterData(rplModel rplModel);
        public Task<ResponseModel> getfinalrpldata(rplFinalData_get rplFinalData);
        public Task<ResponseModel> getrmcodedata(rplFinalData rplFinalData);
        public Task<ResponseModel> getrplmiscode(rplmiscode rplFinalData);
        public Task<ResponseModel> getreportdata(reportmodel reportmodel);
        
    }
}

using Common.BusinessLogicLayer.IServices;
using Common.BusinessLogicLayer.Model;
using Login_API.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Login_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RPLController : Controller
    {
        private readonly IRPLServices _rPLServices;
        public RPLController(IRPLServices rPLServices)
        {
            _rPLServices=rPLServices;
        }
        [HttpPost]
        [Route("getdesignation")]
        [Authorize]
        public async Task<ActionResult<ResponseModel>> getDesignation(rplModel rplModel)
        {
            var a = await _rPLServices.getMasterData(rplModel);
            return Ok(a);
        }
        [HttpPost]
        [Route("getempcode")]
        //[Authorize]
        public async Task<ActionResult<ResponseModel>> getDesignationEmp(rplModel rplModel)
        {
            var a = await _rPLServices.getDesigEmpMasterData(rplModel);
            return Ok(a);
        }
        [HttpPost]
        [Route("getfinalrpldata")]
        [Authorize]
        public async Task<ActionResult<ResponseModel>> getRPLFinalData(rplFinalData_get _rplFinalData)
        {
            var a = await _rPLServices.getfinalrpldata(_rplFinalData);
            return Ok(a);
        }
        [HttpPost]
        [Route("getrmcode")]
        [Authorize]
        public async Task<ActionResult<ResponseModel>> getRPLRMCode(rplFinalData _rplFinalData)
        {
            var a = await _rPLServices.getrmcodedata(_rplFinalData);
            return Ok(a);
        }
        [HttpPost]
        [Route("getmiscode")]
        [Authorize]
        public async Task<ActionResult<ResponseModel>> getmiscode(rplmiscode _rplmiscode)
        {
            var a = await _rPLServices.getrplmiscode(_rplmiscode);
            return Ok(a);
        }
        [HttpPost]
        [Route("getreportdata")]
        [Authorize]
        public async Task<ActionResult<ResponseModel>> getreportdata(reportmodel _reportmodel)
        {
            var a = await _rPLServices.getreportdata(_reportmodel);
            return Ok(a);
        }

    }
}

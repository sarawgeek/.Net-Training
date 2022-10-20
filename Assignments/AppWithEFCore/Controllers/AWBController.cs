using AppWithEFCore.Models;
using AppWithEFCore.Repository;
using Microsoft.AspNetCore.Mvc;

namespace AppWithEFCore.Controllers
{
    [ApiController]
    [Route("AWBController")]
    public class AWBController : ControllerBase
    {
        IAWBRepository _repository;

        public AWBController(IAWBRepository repository)
        {
            _repository = repository;
        }

        [Route("GetAllAWBs")]
        [HttpGet]
        public IEnumerable<AWB> GetAllAwbs()
        {
            return _repository.GetAllAWBs();
        }

        [Route("CreateAWB")]
        [HttpPost]
        public int CreateAWB(AWB awb)
        {
            return _repository.CreateAWB(awb);
        }

        [Route("UpdateAWB")]
        [HttpPut]
        public int UpdateAWB(AWB awb)
        {
            return _repository.UpdateAWB(awb);
        }

        [Route("DeleteAWB")]
        [HttpDelete]
        public int DeleteAWB(int awb)
        {
            return _repository.DeleteAWB(awb);
        }
    }
}

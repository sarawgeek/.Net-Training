using Microsoft.AspNetCore.Mvc;
using LogisticsManagement.Repository;
using LogisticsManagement.Models;

namespace LogisticsManagement.Controllers
{
    [ApiController]
    [Route("DeliveryController")]
    public class DeliveryStatusController : ControllerBase
    {
        IConfiguration _config;
        AWBRepository _repo;

        public DeliveryStatusController(IConfiguration config, AWBRepository repo)
        {
            _config = config;
            _repo = repo;
        }

        [Route("GetAWB")]
        [HttpGet()]
        public AWB Get(int awb)
        {
            return _repo.GetStatus(awb);
        }

        [Route("GetAllAWBs")]
        [HttpGet()]
        public List<AWB> GetAllAWBs()
        {
            return _repo.GetAllAWBs();
        }

        [Route("UpdateStatus")]
        [HttpPut()]
        public int UpdateStatus(int awb, int status)
        {
            return _repo.ChangeStatus(awb, status);
        }

        [Route("AddAWB")]
        [HttpPost()]
        public int AddNewAWB(int status_type, string sender, string reciever)
        {
            return _repo.AddNewAWB(status_type, sender, reciever);
        }

        [Route("DeleteAWB")]
        [HttpDelete()]
        public int DeleteAWB(int AWBNumber)
        {
            return _repo.DeleteAWB(AWBNumber);
        }

    }
}

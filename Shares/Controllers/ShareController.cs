using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Shares.Models;
using Shares.Repository;

namespace Shares.Controllers
{
    [Route("Share-api/[controller]")]
    [ApiController]
    public class ShareController : Controller
    {
        //  ShareController shareRepository = new ShareController();


        [HttpGet("~/test")]
        public double GetTest()
        {
            return ShareRepository.GetTest();

        }

        [HttpGet(Name = "get")]
        public List<Stock> Get()
        {
            return ShareRepository.GetAllShares();
        }
        [HttpPost]
        public PostShare PostNewShare([FromBody] PostShare postShare)
        {
            ShareRepository shareRepository = new ShareRepository();
            shareRepository.InsertTheShare(postShare);

            return postShare;
        }
    }
}

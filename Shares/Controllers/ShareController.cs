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

        [HttpGet]
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

        [HttpDelete("{shareId}")]
        public List<Stock> Delete(int shareId)
        { ShareRepository shareRepository = new ShareRepository();
            shareRepository.DeleteShare(shareId);

            return Get();
        }


         [HttpPut("{shareId}")]
          public string Put(int shareId, [FromBody] PostShare postShare)
          {
            ShareRepository shareRepository = new ShareRepository();
            shareRepository.UpdateShare(shareId, postShare);

              return "Updated share ID: " + shareId + " with " + postShare.stocks + " stocks";

          }
        [HttpPut("UpdateValue/{shareId}")]
        public string putValue(int shareId, [FromBody] PostShare postShare)
        {
            ShareRepository shareRepository = new ShareRepository();
            shareRepository.UpdateShareValue(shareId, postShare);

            return "Updated share ID: " + shareId + " with " + postShare.boughtPrice + " value";

        }
    }
}

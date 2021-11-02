using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Shares.Models;
using Shares.Repository;

namespace Shares.Controllers
{
    /// <summary>
    /// Controller for Stocks requests.
    /// </summary>
    /// 
    [Route("Share-api/[controller]")]
    [ApiController]
    public class ShareController : Controller
    {
        /// <summary>
        /// Request to get all Stocks from the database.
        /// 
        /// <c>GET: Share-api/Share</c>
        /// </summary>
        /// <returns>Returns all Stocks</returns>

        [HttpGet]
        public List<Stock> GetAllShares()
        {
            return ShareRepository.GetAllShares();
        }

        /// <summary>
        /// Request to add a new Stocks to the database.
        /// 
        /// <c>POST: Share-api/Share</c>
        /// </summary>
        /// <param name="postShare">Stocks which comes from the request body</param>
        /// <returns>Returns the added Stocks</returns>

        [HttpPost]
        public PostShare PostNewShare([FromBody] PostShare postShare)
        {
            ShareRepository shareRepository = new ShareRepository();
            shareRepository.InsertTheShare(postShare);

            return postShare;
        }

        /// <summary>
        /// Request to delete a Stocks from the database by shareId.
        /// 
        /// <c>DELETE: Share-api/Share/{shareId}</c>
        /// </summary>
        /// <param name="shareId">shareId which comes from the request</param>
        /// <returns>Returns all Stocks after deletion</returns>

        [HttpDelete("{shareId}")]
        public List<Stock> Delete(int shareId)
        { ShareRepository shareRepository = new ShareRepository();
            shareRepository.DeleteShare(shareId);

            return GetAllShares();
        }

        /// <summary>
        /// Request to update a Stocks by it's id.
        /// 
        /// <c>IMPORTANT: Can only change Stock value to lower one, changing to higher might provide incorrect information</c>
        /// 
        /// <c>PUT: Share-api/Share/{shareId}</c>
        /// </summary>
        /// <param name="shareId">shareId which comes from the request</param>
        /// <param name="postShare">Stock information which comes from the request (Only coins are needed to update)</param>
        /// <returns>Returns information about the update</returns>

        [HttpPut("{shareId}")]
          public string PutStocks(int shareId, [FromBody] PostShare postShare)
          {
            ShareRepository shareRepository = new ShareRepository();
            shareRepository.UpdateShare(shareId, postShare);

              return "Updated share ID: " + shareId + " with " + postShare.stocks + " stocks";

          }

        /// <summary>
        /// Request to update a Stocks by it's id.
        /// 
        /// <c>IMPORTANT: Can only change BoughtValue value.</c>
        /// 
        /// <c>PUT: Share-api/Share/{shareId}</c>
        /// </summary>
        /// <param name="shareId">shareId which comes from the request</param>
        /// <param name="postShare">Stock information which comes from the request (Only coins are needed to update)</param>
        /// <returns>Returns information about the update</returns>

        [HttpPut("UpdateValue/{shareId}")]
        public string putValue(int shareId, [FromBody] PostShare postShare)
        {
            ShareRepository shareRepository = new ShareRepository();
            shareRepository.UpdateShareValue(shareId, postShare);

            return "Updated share ID: " + shareId + " with " + postShare.boughtPrice + " value";

        }
    }
}

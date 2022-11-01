using memberApp.Server.Helpers;
using memberApp.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace memberApp.Server.Controllers
{
    [ApiController]
    [Route("api/members")]
   
    public class MemberController : ControllerBase
    {

        [HttpGet]
        [Route("member-list")]
        public async Task<IEnumerable<MemberModel>> GetMemberList()
        {
            return  await DbHelper.GetMemberlist();
        }





    }

}

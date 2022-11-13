using memberApp.Server.Helpers;
using memberApp.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace memberApp.Server.Controllers
{
    [ApiController]
    [Route("api/members")]


    //추가 수정 삭제 회원 권한 부여 ,  --->포인트 관리<--- 사이버머니 겸 아바타 / 무기 쓸수있는 화폐 
    public class MemberController : ControllerBase
    {


      
        /// <summary>
        /// 멤버 리스트 받아오기 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("member-list")]
        public async Task<IEnumerable<MemberModel>> GetMemberList()
        {
            return  await DbHelper.GetMemberlist();
        }

        [HttpPost, Route("insert-member")]
        public async Task <CommonResponse<int>> InsertMember([FromBody]MemberModel member)
        {
            var response = new CommonResponse<int>();
            var affectedRow = DbHelper.InsertMember(member);
            if(!TryValidateModel(member))
            {
                response.IsSuccess = false;
                response.Message = "insert proper values";
                response.Data = affectedRow;
            }
            else
            {
                response.Data = 0;
                response.IsSuccess = true;
                response.Message = "Welcome ! ";
            }
            return response;
        }
        /// <summary>
        /// 멤버정보 수정
        /// </summary>
        /// <param name="member"></param>
        /// <returns></returns>
        [HttpPost, Route("update-member")]
        public async Task<CommonResponse<int>> UpdateMember([FromBody] MemberModel member)
        {
            var response = new CommonResponse<int>();
            var affectedRow =  DbHelper.UpdateMember(member);
            if (affectedRow > 0)
            {
                response.IsSuccess = true;
                response.Message = "success";
                response.Data = affectedRow;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = "insert proper values";
                response.Data = 0;
            }
            return response;
        }

        /// <summary>
        /// 멤버삭제 
        /// </summary>
        /// <param name="seq"></param>
        /// <returns></returns>
        [HttpPost, Route("delete-member")]
        public async Task<CommonResponse<int>> DeleteMember(int seq)
        {
            var response = new CommonResponse<int>();
            var affectedRow = DbHelper.DeleteMember(seq);
            if (affectedRow > 0)
            {
                response.IsSuccess = true;
                response.Message = "success";
                response.Data = affectedRow;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = "Member does not exist";
                response.Data = 0;
            }
            return response;
        }


        /// <summary>
        /// 멤버등급 변경 
        /// </summary>
        /// <param name="seq"></param>
        /// <param name="cls"></param>
        /// <returns></returns>
        [HttpPost, Route("change-class")]
        public async Task<CommonResponse<int>> ChangeClass(int seq, string cls)
        {
            var response = new CommonResponse<int>();
            var affectedRow = DbHelper.UpdateClass(seq, cls);
            if (affectedRow > 0)
            {
                response.IsSuccess = true;
                response.Message = "success";
                response.Data = affectedRow;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = "Member does not exist";
                response.Data = 0;
            }
            return response;
        }

        [HttpGet, Route("duplicated-id-check")]
        public async Task <CommonResponse<int>> IsDuplicatedID(string id)
        {
            var response = new CommonResponse<int>();
            var cnt =  DbHelper.IsDuplicatedId(id);
            if (cnt > 1)
            {
                response.Data = cnt;
                response.IsSuccess = false;
                response.Message = "아이디 있음";
                
            }
            else
            {
                response.Data = cnt;
                response.IsSuccess = true;
                response.Message = "아이디 사용가능";

            }

            return response;
        }



    }

}

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using perpusapi.DataModel;
using perpusapi.Services;
using perpusapi.Validator;

namespace perpusapi.Controllers
{
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly ILogger<MembersController> _logger;
        private readonly IMemberService _memberService;

        public MembersController(ILogger<MembersController> logger, IMemberService memberService)
        {
            _logger = logger;
            _memberService = memberService;
        }

        [HttpGet]
        [Route("api/members")]
        public IActionResult GetMembers()
        {
            return Ok(_memberService.GetMembers());
        }

        [HttpGet]
        [Route("api/members/{id}")]
        public IActionResult GetMember(int id)
        {
            return Ok(_memberService.GetMember(id));
        }

        [HttpPost]
        [Route("api/members")]
        public IActionResult AddMember([FromBody]Member member)
        {
            var validator = new MemberValidator();
            if(validator.Validate(member).IsValid){
                _memberService.AddMember(member);
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut]
        [Route("api/members/{id}")]
        public IActionResult UpdateMember([FromBody]Member member, int id)
        {
            var validator = new MemberValidator();
            if(validator.Validate(member).IsValid){
                member.Id = id;
                _memberService.UpdateMember(member);
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete]
        [Route("api/members/{id}")]
        public IActionResult DeleteMember(int id)
        {
            _memberService.DeleteMember(id);
            return NoContent();
        }
    }
}
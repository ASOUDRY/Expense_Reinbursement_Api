using User;
using ModelsLayer;
using BusinessLayer;
using Microsoft.AspNetCore.Mvc;

namespace ReinbursementApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReinbursementApiController : ControllerBase
    {
        BusinessLayerClass Bl = new BusinessLayerClass();

        [HttpGet("PullTickets")]
        public async Task<ActionResult<List<Ticket>>> Get()
         {
            if (!ModelState.IsValid) {
             UnprocessableEntity(User);
            }
            else {
               List<Ticket> ret = await Bl.PullTicket();
               if (ret.Count > 0)
               {
              return new JsonResult(ret);
               }
               return NoContent();
            }
            return BadRequest();
        }

        [HttpGet("PullMyTickets/{user}")]
         public async Task<ActionResult<List<Ticket>>> Get(string user)
         {
            if (!ModelState.IsValid) {
             UnprocessableEntity(User);
            }
            else {
               List<Ticket> ret = await Bl.FetchTicket(user);
              if (ret.Count > 0)
               {
              return new JsonResult(ret);
               }
               return NoContent();
            }
            return BadRequest(user);
        }

        [HttpPost("Register")]
        public async Task<ActionResult<UserInfo>> RegisterANewUser(UserQuery user) 
        {
            if (!ModelState.IsValid) {
             UnprocessableEntity(User);
            }
            else {
              UserInfo ret = await Bl.RegisterANewUser(user);
              if (ret.Name == "The Username is not available") {
            //    return Created("Invalid Request", ret.Name);

                return ValidationProblem("The Username you selected is already being used. Please choose a different one.");
              }
              else {
              return Created("Made it", ret);
              }    
            }
            return BadRequest(user);
        }
// fix the ones below
        [HttpGet("Login/{name}/{Password}")]
        public async Task<ActionResult<UserInfo>> LoginUser(string name, string Password) 
        {
            if (!ModelState.IsValid) {
             UnprocessableEntity(User);
            }
            else {
              UserInfo ret = await Bl.LoginUser(name, Password);
            if (ret.Id.Length > 0) {
                return Created("Made it", ret);
            } else 
              return NotFound("There is no account with that username and password. Please consider registering a account with us instead.");
            }
            return BadRequest(name);
        }

        [HttpPost("SubmitTicket")]
        public async Task<ActionResult<Ticket>> SubmitTicket(Ticket t) 
        {
            if (!ModelState.IsValid) {
             UnprocessableEntity(User);
            }
            else {
              Ticket ret = await Bl.SubmitTicket(t);
              return Created("Made it", ret);
            }
            return BadRequest(t);
        }

        [HttpPut("TicketProcessing")]
        public async Task<ActionResult<Ticket>> TicketProcessing(Ticket t) 
        {
            if (!ModelState.IsValid) {
             UnprocessableEntity(User);
            }
            else {
              Ticket ret = await Bl.TicketProcessing(t);
              return Created("Made it", ret);
            }
            return BadRequest(t);
        }
    }
}
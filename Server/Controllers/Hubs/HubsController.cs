using System.Threading.Tasks;
using AspNet.Security.OAuth.Validation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Server.Controllers.Hubs
{
	[Authorize(AuthenticationSchemes = OAuthValidationDefaults.AuthenticationScheme)]
	[Route("[controller]")]
	public class HubsController : BaseController
	{
		readonly Models.DbContext _ctx;


		public HubsController(Models.DbContext ctx)
		{
			_ctx = ctx;
		}

		// Sending the userId from the request body as this is just a demo. 
		// On your application you probably want to fetch this from your authentication context and not receive it as a parameter
		[HttpPost("[action]")]
		public IActionResult ListFriends([FromBody] dynamic payload)
		{
			return Json(GroupChatHub.ConnectedParticipants((string)payload.currentUserId));

			// Use the following for group chats
			// Make sure you have [pollFriendsList] set to true for this simple group chat example to work as
			// broadcasting with group was not implemented here
			// return Json(GroupChatHub.ConnectedParticipants((string)payload.currentUserId));
		}


		[HttpPost("[action]")]
		public async Task<IActionResult> MessageHistory([FromBody] dynamic payload)
		{
			string mailA = payload.mailA;
			string b = payload.mailB;
			string[] mailB = b.Split(",");
			var msgList = (from m in this._ctx.ChatMessages
                            .Include(d => d.FromUser)
                            .Include(d => d.ChatGroup.Participants) 
						   where (m.FromUser.Email == mailA ||
							   mailB.Contains(m.FromUser.Email)) &&
							   (m.ChatGroup.Participants.Any(p => p.User.Email == mailA 
							   || mailB.Contains(m.FromUser.Email)))
						   orderby m.DateSent
						   select m);

			System.Console.WriteLine(msgList.ToString());
			return Json(msgList);
		}
	}
}
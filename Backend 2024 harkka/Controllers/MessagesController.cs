using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend_2024_harkka.Models;
using Backend_2024_harkka.Services;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Backend_2024_harkka.Middleware;

namespace Backend_2024_harkka.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IMessageService _messageService;
        private readonly IUserAuthenticationService _userAuthenticationService;

        public MessagesController(IMessageService service, IUserAuthenticationService authenticationService)
        {
            _messageService = service;
            _userAuthenticationService = authenticationService;
        }

        // GET: api/Messages
        /// <summary>
        /// hakee kaikki viestit
        /// </summary>
        /// <returns>Kaikki viestit</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Message>>> GetMessages()
        {
            return Ok(await _messageService.GetMessagesAsync());
        }

        // GET: api/Messages/5
        /// <summary>
        /// Hakee tietyn viestin
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Tietyn viestin</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<MessageDTO>> GetMessage(long id)
        {
            // var message = await _context.Messages.FindAsync(id);

            MessageDTO? message = await _messageService.GetMessageAsync(id);

            if (message == null)
            {
                return NotFound();
            }

            return message;
        }

        // PUT: api/Messages/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMessage(long id, MessageDTO message)
        {
            if (id != message.Id)
            {
                return BadRequest();
            }

            bool result = await _messageService.UpdateMessageAsync(message);

            if (result)
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/Messages
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MessageDTO>> PostMessage(MessageDTO message)
        {
            MessageDTO? newMessage = await _messageService.NewMessageAsync(message);

            if (newMessage == null)
            {
                return Problem();
            }

            return CreatedAtAction("GetMessage", new { id = message.Id }, message);
        }

        // DELETE: api/Messages/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteMessage(long id)
        {
            string username = this.User.FindFirst(ClaimTypes.Name).Value;
            if(!await _userAuthenticationService.isMyMessage(username, id))
            {
                return BadRequest();
            }
            bool result = await _messageService.DeleteMessageAsync(id);
            if ((!result))
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QueenCar.Application.Features.CQRS.Commands.ContactCommands;
using QueenCar.Application.Features.CQRS.Handlers.ContactHandlers;
using QueenCar.Application.Features.CQRS.Queries.ContactQueries;

namespace QueenCar.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly CreateContactCommandHandler _createContactCommandHandler;
        private readonly GetContactQueryHandler _getContactQueryHandler;
        private readonly GetContactByIdQueryHandler _getContactByIdQueryHandler;
        private readonly UpdateContactCommandHandler _updateContactCommandHandler;
        private readonly RemoveContactCommandHandler _deleteContactCommandHandler;

        public ContactsController(CreateContactCommandHandler createContactCommandHandler, GetContactQueryHandler getContactQueryHandler, GetContactByIdQueryHandler getContactByIdQueryHandler, UpdateContactCommandHandler updateContactCommandHandler, RemoveContactCommandHandler deleteContactCommandHandler)
        {
            _createContactCommandHandler = createContactCommandHandler;
            _getContactQueryHandler = getContactQueryHandler;
            _getContactByIdQueryHandler = getContactByIdQueryHandler;
            _updateContactCommandHandler = updateContactCommandHandler;
            _deleteContactCommandHandler = deleteContactCommandHandler;
        }
        [HttpGet]
        public async Task<IActionResult> ContactList()
        {
            var values = await _getContactQueryHandler.Handle();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetContact(int id)
        {
            var value = await _getContactByIdQueryHandler.Handle(new GetContactByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateContact(CreateContactCommand command)
        {
            await _createContactCommandHandler.Handle(command);
            return Ok("Hakkında Bilgisi Eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveContact(int id)
        {
            await _deleteContactCommandHandler.Handle(new RemoveContactCommand(id));
            return Ok("Hakkında Bilgisi Silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateContact(UpdateContactCommand command)
        {
            await _updateContactCommandHandler.Handle(command);
            return Ok("Hakkında Bilgisi Güncellendi");
        }
    }
}

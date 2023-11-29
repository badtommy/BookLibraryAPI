using AutoMapper;
using BookLibrary.Contracts.DTOs.Books;
using BookLibraryAPI.AppLayer.Books.Commands.CreateBook;
using BookLibraryAPI.AppLayer.Books.Commands.DeleteBook;
using BookLibraryAPI.AppLayer.Books.Commands.UpdateBook;
using BookLibraryAPI.AppLayer.Books.Queries.GetAllBooks;
using BookLibraryAPI.AppLayer.Books.Queries.GetBook;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace BookLibraryAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    [Consumes("application/json")]

    public class BookController : ControllerBase
    {
        private readonly ISender _sender;
        private readonly IMapper _mapper;
        private readonly ILogger<BookController> _logger;

        public BookController(ISender sender, IMapper mapper, ILogger<BookController> logger)
        {
            _sender = sender;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpPost("CreateBookAsync")]

        [ProducesResponseType(typeof(BookDTO), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]

        public async Task<IActionResult> CreateBookAsync([FromBody] CreateBookDTO createBookDTO)
        {
            try
            {
                _logger.LogInformation($"CreateBook called by {createBookDTO.Title} ");

                var command = _mapper.Map<CreateBookDTO, CreateBookCommand>(createBookDTO);
                var result = await _sender.Send(command);

                return result.Match(
                                   book => CreatedAtAction("GetBookById", new { id = book.Book.Id }, _mapper.Map<BookDTO>(book)),
                                                  //Ok(_mapper.Map<DeleteBookDTO>(book)),
                                                  error => Problem(error.Message, statusCode: (int)error.StatusCode)
                                                             );
            }
            catch (ValidationException ex)
            {
                var errors = ex.Errors.Select(x => x.ErrorMessage).ToList();
                _logger.LogError($"CreateBook called by {createBookDTO.Title} with errors {errors} ");
                return BadRequest(new { errors });
                //return Problem(ex.Message);
            }
        }

        [HttpGet("GetAllBooksAsync")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetAllBooksAsync()
        {
            var result = await _sender.Send(new GetAllBooksQuery());
            return Ok(result);
        }

        [HttpGet("GetBookByIdAsync/{id}", Name = "GetBookById")]
        [ProducesResponseType(typeof(BookDTO), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetBookByIdAsync(Guid id)
        {
            _logger.LogInformation($"GetBookById called by {id.ToString()} ");

            var result = await _sender.Send(new GetBookQuery(id));
            return result.Match(
                            book => Ok(_mapper.Map<BookDTO>(book)),
                                error => Problem(error.Message, statusCode: (int)error.StatusCode));
        }

        [HttpDelete("DeleteBookByIdAsync/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> DeleteBookByIdAsync(Guid id)
        {
            _logger.LogInformation($"DeleteBookById called by {id.ToString()} ");

            var result = await _sender.Send(new DeleteBookCommand(id));
            return result.Match(
                         book => Ok(_mapper.Map<DeleteBookDTO>(book)),
                              error => Problem(error.Message, statusCode: (int)error.StatusCode));
        }

        [HttpPut("UpdateBookByIdAsync/{id}")]
        [ProducesResponseType(typeof(BookDTO), 200)]
        [ProducesResponseType(typeof(BadRequest), 400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> UpdateBookByIdAsync(Guid id, [FromBody] BookDTO updateBookDTO)
        {
            try
            {
                _logger.LogInformation($"UpdateBookById called by {id.ToString()} ");
                var command = _mapper.Map<BookDTO, UpdateBookCommand>(updateBookDTO);
                command.Id = id;
                var result = await _sender.Send(command);
                return result.Match(
                             book => Ok(_mapper.Map<BookDTO>(book)),
                                error => Problem(error.Message, statusCode: (int)error.StatusCode));
            }
            catch (ValidationException ex)
            {
                var errors = ex.Errors.Select(x => x.ErrorMessage).ToList();
                _logger.LogError($"UpdateBookById called by {id.ToString()} with errors {errors}");
                return BadRequest(new { errors });
                //return Problem(ex.Message);
            }
        }
    }
}

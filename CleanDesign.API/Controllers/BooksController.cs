using CleanDesign.Core.DTOs;
using CleanDesign.Core.Exceptions;
using CleanDesign.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CleanDesign.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }
        [HttpGet]
        public async Task<ActionResult<BookDTO>> GetAll()
        {
            try
            {
                var books = await _bookService.GetAllAsync();
                return Ok(books);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookDTO>> GetBookById(int id)
        {
            try
            {
                var book = await _bookService.GetBookByIdAsync(id);
                return Ok(book);
            }
            catch (ResourceNotFoundException nfEx)
            {
                return NotFound(nfEx.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("isbn/{isbn}")]
        public async Task<ActionResult<BookDTO>> GetBookByISBN(string isbn)
        {
            try
            {
                var book = await _bookService.GetBookByISBNAsync(isbn);
                return Ok(book);
            }
            catch (ResourceNotFoundException nfEx)
            {
                return NotFound(nfEx.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }            
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<BookDTO>>> SearchBookByTitle([FromQuery] string title)
        {            
            try
            {
                var books = await _bookService.SearchBookByTitleAsync(title);
                return Ok(books);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost("checkout/{id}")]
        public async Task<IActionResult> CheckOutBook(int id)
        {
            try
            {
                await _bookService.CheckOutBookAsync(id);
                return Ok();
            }
            catch (ResourceNotFoundException nfEx)
            {
                return NotFound(nfEx.Message);
            }
            catch (InvalidOperationException ivEx)
            {
                return Conflict(ivEx.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost("checkin/{id}")]
        public async Task<IActionResult> CheckInBook(int id)
        {
            try
            {
                await _bookService.CheckInBookAsync(id);
                return Ok();
            }
            catch (ResourceNotFoundException nfEx)
            {
                return NotFound(nfEx.Message);
            }
            catch (InvalidOperationException ivEx)
            {
                return Conflict(ivEx.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost("add/{isbn}")]
        public async Task<ActionResult<BookDTO>> AddBookToCollection(string isbn)
        {
            try
            {
                var book = await _bookService.AddBookToCollectionAsync(isbn);
                return Ok(book);
            }
            catch (InvalidOperationException ivEx)
            {
                return Conflict(ivEx.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}

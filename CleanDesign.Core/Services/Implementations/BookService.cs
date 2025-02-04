using AutoMapper;
using CleanDesign.Core.Data.Repositories;
using CleanDesign.Core.DTOs;
using CleanDesign.Core.Entities;
using CleanDesign.Core.Exceptions;
using CleanDesign.Core.ThirdPartyServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanDesign.Core.Services.Implementations
{
    public class BookService : IBookService
    {
        private readonly IMapper _mapper;
        private readonly IBookRepository _bookRepository;
        private readonly IISBNSearchService _iSBNSearchService;

        public BookService(IMapper mapper, IBookRepository bookRepository, IISBNSearchService iSBNSearchService)
        {
            _mapper = mapper;
            _bookRepository = bookRepository;
            _iSBNSearchService = iSBNSearchService;
        }

        public async Task<BookDTO> AddBookToCollectionAsync(string isbn)
        {
            var existingBook = await _bookRepository.GetBookByISBNAsync(isbn);

            if (existingBook != null)
                throw new InvalidOperationException($"Book with ISBN {isbn} already exists in the collection");

            var book = await _iSBNSearchService.GetBookByISBNAsync(isbn);

            if (book == null)
                throw new Exception("Unable to find this book with search provider");

            var savedBook = await _bookRepository.AddBookAsync(book);

            return _mapper.Map<BookDTO>(book);
        }

        public async Task CheckInBookAsync(int id)
        {
            var book = await _bookRepository.GetBookByIdAsync(id);

            if (book == null)
                throw new ResourceNotFoundException($"Book with Id {id} not found");

            book.CheckIn();
            await _bookRepository.UpdateBookAsync(book);
        }

        public async Task CheckOutBookAsync(int id)
        {
            var book = await _bookRepository.GetBookByIdAsync(id);

            if (book == null)
                throw new ResourceNotFoundException($"Book with Id {id} not found");

            book.CheckOut();
            await _bookRepository.UpdateBookAsync(book);
        }

        public async Task<IEnumerable<BookDTO>> GetAllAsync()
        {
            var books = await _bookRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<BookDTO>>(books);
        }

        public async Task<BookDTO> GetBookByIdAsync(int id)
        {
            var book = await _bookRepository.GetBookByIdAsync(id);

            if (book == null)
                throw new ResourceNotFoundException($"Book with Id {id} not found");

            return _mapper.Map<BookDTO>(book);
        }

        public async Task<BookDTO> GetBookByISBNAsync(string isbn)
        {
            var book = await _bookRepository.GetBookByISBNAsync(isbn);

            if (book == null)
                throw new ResourceNotFoundException($"Book with Id {isbn} not found");

            return _mapper.Map<BookDTO>(book);
        }

        public async Task<IEnumerable<BookDTO>> SearchBookByTitleAsync(string title)
        {
            var results = await _bookRepository.SearchBookByTitleAsync(title);

            return _mapper.Map<IEnumerable<BookDTO>>(results);  
        }
    }
}

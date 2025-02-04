using CleanDesign.Core.Data.Repositories;
using CleanDesign.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanDesign.Data.EntityFramework.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly BooksDbContext _dbContext;

        public BookRepository(BooksDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Book> AddBookAsync(Book book)
        {
            await _dbContext.AddAsync(book);
            await _dbContext.SaveChangesAsync();
            return book;
        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await _dbContext.Books.ToListAsync();
        }

        public async Task<Book> GetBookByIdAsync(int id)
        {
            return await _dbContext.Books.FirstOrDefaultAsync(x => x.BookId == id);
        }

        public async Task<Book> GetBookByISBNAsync(string isbn)
        {
            return await _dbContext.Books.FirstOrDefaultAsync(x => x.ISBN == isbn);
        }

        public async Task<IEnumerable<Book>> SearchBookByTitleAsync(string title)
        {
            return await _dbContext.Books.Where(x => x.ISBN.Contains(title)).ToListAsync();
        }

        public async Task UpdateBookAsync(Book book)
        {
            _dbContext.Books.Update(book);
            await _dbContext.SaveChangesAsync();
        }
    }
}

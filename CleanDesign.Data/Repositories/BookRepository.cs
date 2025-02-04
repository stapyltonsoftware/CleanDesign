using CleanDesign.Core.Data.Repositories;
using CleanDesign.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanDesign.Data.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly IDbConnection _dbConnection;

        public BookRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public Task<Book> AddBookAsync(Book book)
        {
            
        }

        public Task<Book> GetBookByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Book> GetBookByISBNAsync(string isbn)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Book>> SearchBookByTitleAsync(string isbn)
        {
            throw new NotImplementedException();
        }

        public Task UpdateBookAsync(Book book)
        {
            throw new NotImplementedException();
        }
    }
}

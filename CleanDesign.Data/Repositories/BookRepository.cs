using CleanDesign.Core.Data.Repositories;
using CleanDesign.Core.Entities;
using Dapper;
using Microsoft.Data.SqlClient;
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

        public async Task<Book> GetBookByIdAsync(int id)
        {

            return await _dbConnection.QuerySingleOrDefaultAsync<Book>(
                "SELECT * FROM Books WHERE BookId = @Id", new { Id = id });
        }

        public async Task<Book> GetBookByISBNAsync(string isbn)
        {

            return await _dbConnection.QuerySingleOrDefaultAsync<Book>(
                "SELECT * FROM Books WHERE ISBN = @ISBN", new { ISBN = isbn });
        }

        public async Task<IEnumerable<Book>> SearchBookByTitleAsync(string title)
        {

            return await _dbConnection.QueryAsync<Book>(
                "SELECT * FROM Books WHERE Title LIKE @Title", new { Title = $"%{title}%" });
        }

        public async Task<Book> AddBookAsync(Book book)
        {

            var id = await _dbConnection.ExecuteScalarAsync<int>(
                "INSERT INTO Books (Title, Author, ISBN, IsCheckedOut) OUTPUT INSERTED.BookId " +
                "VALUES (@Title, @Author, @ISBN, @IsCheckedOut)", book);
            book.BookId = id;
            return book;
        }

        public async Task UpdateBookAsync(Book book)
        {

            await _dbConnection.ExecuteAsync(
                "UPDATE Books SET Title = @Title, Author = @Author, ISBN = @ISBN, IsCheckedOut = @IsCheckedOut " +
                "WHERE BookId = @BookId", book);
        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await _dbConnection.QueryAsync<Book>($@"SELECT * FROM Books");
        }
    }
}

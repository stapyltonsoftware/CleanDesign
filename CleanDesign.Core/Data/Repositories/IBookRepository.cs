using CleanDesign.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanDesign.Core.Data.Repositories
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAllAsync();
        Task<Book> GetBookByIdAsync(int id);
        Task<Book> GetBookByISBNAsync(string isbn);
        Task<IEnumerable<Book>> SearchBookByTitleAsync(string title);
        Task<Book> AddBookAsync(Book book);
        Task UpdateBookAsync(Book book);
    }
}

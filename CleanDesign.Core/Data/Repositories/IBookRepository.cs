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
        Task<Book> GetBookByIdAsync(int id);
        Task<Book> GetBookByISBNAsync(string isbn);
        Task<IEnumerable<Book>> SearchBookByTitleAsync(string isbn);
        Task<Book> AddBookAsync(Book book);
        Task UpdateBookAsync(Book book);
    }
}

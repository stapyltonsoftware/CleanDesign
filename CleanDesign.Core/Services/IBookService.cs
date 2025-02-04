using CleanDesign.Core.DTOs;
using CleanDesign.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanDesign.Core.Services
{
    public interface IBookService
    {
        Task<BookDTO> GetBookByIdAsync(int id);
        Task<BookDTO> GetBookByISBNAsync(string isbn);
        Task<IEnumerable<BookDTO>> SearchBookByTitleAsync(string isbn);
        Task CheckOutBookAsync(int id);
        Task CheckInBookAsync(int id);
        Task<BookDTO> AddBookToCollectionAsync(string isbn);
    }
}

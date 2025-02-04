using CleanDesign.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanDesign.Core.ThirdPartyServices
{
    public interface IISBNSearchService
    {
        Task<Book> GetBookByISBNAsync(string isbn);
    }
}

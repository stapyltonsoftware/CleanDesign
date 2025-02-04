using CleanDesign.Core.Entities;
using CleanDesign.Core.ThirdPartyServices;
using CleanDesign.ISBNService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanDesign.ISBNService
{
    public class Service : IISBNSearchService
    {
        public async Task<Book> GetBookByISBNAsync(string isbn)
        {
            // probably a http request somewhere

            var result = _data.FirstOrDefault(x => x.ISBN == isbn);

            if (result != null)
            {
                return await Task.FromResult<Book>(new Book
                {
                    Author = result.Author,
                    ISBN = result.ISBN,
                    Title = result.Title,
                });
            }

            return null;
        }

        private List<ThirdPartyBookModel> _data = new List<ThirdPartyBookModel>
            {
                new ThirdPartyBookModel { Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", ISBN = "9780743273565" },
                new ThirdPartyBookModel { Title = "To Kill a Mockingbird", Author = "Harper Lee", ISBN = "9780061120084" },
                new ThirdPartyBookModel { Title = "1984", Author = "George Orwell", ISBN = "9780451524935" },
                new ThirdPartyBookModel { Title = "Pride and Prejudice", Author = "Jane Austen", ISBN = "9780141439518" },
                new ThirdPartyBookModel { Title = "Moby-Dick", Author = "Herman Melville", ISBN = "9781503280786" },
                new ThirdPartyBookModel { Title = "War and Peace", Author = "Leo Tolstoy", ISBN = "9780199232765" },
                new ThirdPartyBookModel { Title = "The Catcher in the Rye", Author = "J.D. Salinger", ISBN = "9780316769488" },
                new ThirdPartyBookModel { Title = "The Hobbit", Author = "J.R.R. Tolkien", ISBN = "9780547928227" },
                new ThirdPartyBookModel { Title = "Brave New World", Author = "Aldous Huxley", ISBN = "9780060850524" },
                new ThirdPartyBookModel { Title = "Crime and Punishment", Author = "Fyodor Dostoevsky", ISBN = "9780140449136" },
                new ThirdPartyBookModel { Title = "The Lord of the Rings", Author = "J.R.R. Tolkien", ISBN = "9780618640157" },
                new ThirdPartyBookModel { Title = "Harry Potter and the Sorcerer's Stone", Author = "J.K. Rowling", ISBN = "9780439708180" },
                new ThirdPartyBookModel { Title = "The Alchemist", Author = "Paulo Coelho", ISBN = "9780062315007" },
                new ThirdPartyBookModel { Title = "Dune", Author = "Frank Herbert", ISBN = "9780441013593" },
                new ThirdPartyBookModel { Title = "The Road", Author = "Cormac McCarthy", ISBN = "9780307387899" },
                new ThirdPartyBookModel { Title = "The Name of the Wind", Author = "Patrick Rothfuss", ISBN = "9780756404741" },
                new ThirdPartyBookModel { Title = "The Shining", Author = "Stephen King", ISBN = "9780307743657" },
                new ThirdPartyBookModel { Title = "A Game of Thrones", Author = "George R.R. Martin", ISBN = "9780553103540" },
                new ThirdPartyBookModel { Title = "The Handmaid's Tale", Author = "Margaret Atwood", ISBN = "9780385490818" },
                new ThirdPartyBookModel { Title = "Fahrenheit 451", Author = "Ray Bradbury", ISBN = "9781451673319" }
            };
    }
}

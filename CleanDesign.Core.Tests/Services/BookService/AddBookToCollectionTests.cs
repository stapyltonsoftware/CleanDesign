using AutoMapper;
using CleanDesign.Core.Data.Repositories;
using CleanDesign.Core.DTOs;
using CleanDesign.Core.Entities;
using CleanDesign.Core.ThirdPartyServices;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanDesign.Core.Tests.Services.BookService
{
    public class AddBookToCollectionTests
    {
        private FakeData _fakeData;

        public AddBookToCollectionTests()
        {
            _fakeData = new();
        }

        [Fact]
        public async void ShouldReturnBook_WhenBookFound()
        {
            //Arrange
            var mockIsbnService = new Mock<IISBNSearchService>();
            var mockBookRepo = new Mock<IBookRepository>();
            var mockMapper = new Mock<IMapper>();

            mockIsbnService.Setup(m => m.GetBookByISBNAsync(It.IsAny<string>())).ReturnsAsync((string isbn) => _fakeData.Books.FirstOrDefault(x => x.ISBN == isbn));
            mockBookRepo.Setup(x => x.AddBookAsync(It.IsAny<Book>())).ReturnsAsync((Book b) => b);
            mockMapper.Setup(x => x.Map<BookDTO>(It.IsAny<Book>())).Returns((Book book) => new BookDTO { BookId = 6, Title = book.Title, Author = book.Author, ISBN = book.ISBN });

            //Act
            var bookService = new Core.Services.Implementations.BookService(mockMapper.Object, mockBookRepo.Object, mockIsbnService.Object);
            var book = await bookService.AddBookToCollectionAsync("9780553103540");

            //Assert
            Assert.NotNull(book);
            Assert.Equal("A Game of Thrones", book.Title );
            Assert.Equal(6, book.BookId);

            mockIsbnService.Verify(x => x.GetBookByISBNAsync(It.IsAny<string>()), Times.Once);
            mockBookRepo.Verify(x => x.GetBookByISBNAsync(It.IsAny<string>()), Times.Once);
            mockBookRepo.Verify(x => x.AddBookAsync(It.IsAny<Book>()), Times.Once);            
        }
    }

    public class FakeData
    {
        public List<Book> Books { get; set; } = new()
        {
            new Book { Title = "The Name of the Wind", Author = "Patrick Rothfuss", ISBN = "9780756404741" },
                new Book { Title = "The Shining", Author = "Stephen King", ISBN = "9780307743657" },
                new Book { Title = "A Game of Thrones", Author = "George R.R. Martin", ISBN = "9780553103540" },
                new Book { Title = "The Handmaid's Tale", Author = "Margaret Atwood", ISBN = "9780385490818" },
                new Book { Title = "Fahrenheit 451", Author = "Ray Bradbury", ISBN = "9781451673319" }
        };
    }
}

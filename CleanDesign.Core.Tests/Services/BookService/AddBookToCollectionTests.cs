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

        private Mock<IISBNSearchService> _mockISBNSearchService;
        private Mock<IBookRepository> _mockBookRepository;
        private Mock<IMapper> _mockMapper;

        public AddBookToCollectionTests()
        {
            _fakeData = new();
            _mockISBNSearchService = new Mock<IISBNSearchService>();
            _mockBookRepository = new Mock<IBookRepository>();
            _mockMapper = new Mock<IMapper>();
        }

        [Fact]
        public async void ShouldReturnBook_WhenBookFound()
        {
            //Arrange           

            _mockISBNSearchService.Setup(m => m.GetBookByISBNAsync(It.IsAny<string>())).ReturnsAsync((string isbn) => _fakeData.ISBNSearchBooks.FirstOrDefault(x => x.ISBN == isbn));
            _mockBookRepository.Setup(x => x.GetBookByISBNAsync(It.IsAny<string>())).ReturnsAsync((string isbn) => _fakeData.DatabaseBooks.FirstOrDefault(x => x.ISBN == isbn));
            _mockBookRepository.Setup(x => x.AddBookAsync(It.IsAny<Book>())).ReturnsAsync((Book b) => b);
            _mockMapper.Setup(x => x.Map<BookDTO>(It.IsAny<Book>())).Returns((Book book) => new BookDTO { BookId = 6, Title = book.Title, Author = book.Author, ISBN = book.ISBN });
            var bookService = new Core.Services.Implementations.BookService(_mockMapper.Object, _mockBookRepository.Object, _mockISBNSearchService.Object);

            //Act
            var book = await bookService.AddBookToCollectionAsync("9780743273565");

            //Assert
            Assert.NotNull(book);
            Assert.Equal("The Great Gatsby", book.Title );
            Assert.Equal(6, book.BookId);

            _mockISBNSearchService.Verify(x => x.GetBookByISBNAsync(It.IsAny<string>()), Times.Once);
            _mockBookRepository.Verify(x => x.GetBookByISBNAsync(It.IsAny<string>()), Times.Once);
            _mockBookRepository.Verify(x => x.AddBookAsync(It.IsAny<Book>()), Times.Once);            
        }

        [Fact]
        public async Task ShouldThrowException_WhenBookWithISBNAlreadyExists()
        {
            // Arrange
            _mockISBNSearchService.Setup(m => m.GetBookByISBNAsync(It.IsAny<string>())).ReturnsAsync((string isbn) => _fakeData.ISBNSearchBooks.FirstOrDefault(x => x.ISBN == isbn));
            _mockBookRepository.Setup(x => x.GetBookByISBNAsync(It.IsAny<string>())).ReturnsAsync((string isbn) => _fakeData.DatabaseBooks.FirstOrDefault(x => x.ISBN == isbn));
            _mockBookRepository.Setup(x => x.AddBookAsync(It.IsAny<Book>())).ReturnsAsync((Book b) => b);
            _mockMapper.Setup(x => x.Map<BookDTO>(It.IsAny<Book>())).Returns((Book book) => new BookDTO { BookId = 6, Title = book.Title, Author = book.Author, ISBN = book.ISBN });
            var bookService = new Core.Services.Implementations.BookService(_mockMapper.Object, _mockBookRepository.Object, _mockISBNSearchService.Object);

            // Act & Assert
            Assert.ThrowsAsync<InvalidOperationException>(async () => await bookService.AddBookToCollectionAsync("9780756404741"));
        }

        [Fact]
        public async Task ShouldThrowException_WhenSearchCantFindISBN()
        {
            // Arrange
            _mockISBNSearchService.Setup(m => m.GetBookByISBNAsync(It.IsAny<string>())).ReturnsAsync((string isbn) => _fakeData.ISBNSearchBooks.FirstOrDefault(x => x.ISBN == isbn));
            _mockBookRepository.Setup(x => x.GetBookByISBNAsync(It.IsAny<string>())).ReturnsAsync((string isbn) => _fakeData.DatabaseBooks.FirstOrDefault(x => x.ISBN == isbn));
            _mockBookRepository.Setup(x => x.AddBookAsync(It.IsAny<Book>())).ReturnsAsync((Book b) => b);
            _mockMapper.Setup(x => x.Map<BookDTO>(It.IsAny<Book>())).Returns((Book book) => new BookDTO { BookId = 6, Title = book.Title, Author = book.Author, ISBN = book.ISBN });
            var bookService = new Core.Services.Implementations.BookService(_mockMapper.Object, _mockBookRepository.Object, _mockISBNSearchService.Object);

            // Act & Assert
            Assert.ThrowsAsync<Exception>(async () => await bookService.AddBookToCollectionAsync("9780756404747"));
        }
    }

    public class FakeData
    {
        public List<Book> DatabaseBooks { get; set; } = new()
        {
            new Book { Title = "The Name of the Wind", Author = "Patrick Rothfuss", ISBN = "9780756404741" },
                new Book { Title = "The Shining", Author = "Stephen King", ISBN = "9780307743657" },
                new Book { Title = "A Game of Thrones", Author = "George R.R. Martin", ISBN = "9780553103540" },
                new Book { Title = "The Handmaid's Tale", Author = "Margaret Atwood", ISBN = "9780385490818" },
                new Book { Title = "Fahrenheit 451", Author = "Ray Bradbury", ISBN = "9781451673319" }
        };

        public List<Book> ISBNSearchBooks { get; set; } = new()
        {
            new Book { Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", ISBN = "9780743273565" },
                new Book { Title = "To Kill a Mockingbird", Author = "Harper Lee", ISBN = "9780061120084" },
                new Book { Title = "1984", Author = "George Orwell", ISBN = "9780451524935" },
                new Book { Title = "Pride and Prejudice", Author = "Jane Austen", ISBN = "9780141439518" },
                new Book { Title = "Moby-Dick", Author = "Herman Melville", ISBN = "9781503280786" },
                new Book { Title = "War and Peace", Author = "Leo Tolstoy", ISBN = "9780199232765" },
                new Book { Title = "The Catcher in the Rye", Author = "J.D. Salinger", ISBN = "9780316769488" },
                new Book { Title = "The Hobbit", Author = "J.R.R. Tolkien", ISBN = "9780547928227" },
                new Book { Title = "Brave New World", Author = "Aldous Huxley", ISBN = "9780060850524" },
                new Book { Title = "Crime and Punishment", Author = "Fyodor Dostoevsky", ISBN = "9780140449136" },
                new Book { Title = "The Lord of the Rings", Author = "J.R.R. Tolkien", ISBN = "9780618640157" },
                new Book { Title = "Harry Potter and the Sorcerer's Stone", Author = "J.K. Rowling", ISBN = "9780439708180" },
                new Book { Title = "The Alchemist", Author = "Paulo Coelho", ISBN = "9780062315007" },
                new Book { Title = "Dune", Author = "Frank Herbert", ISBN = "9780441013593" },
                new Book { Title = "The Road", Author = "Cormac McCarthy", ISBN = "9780307387899" },
                new Book { Title = "The Name of the Wind", Author = "Patrick Rothfuss", ISBN = "9780756404741" },
                new Book { Title = "The Shining", Author = "Stephen King", ISBN = "9780307743657" },
                new Book { Title = "A Game of Thrones", Author = "George R.R. Martin", ISBN = "9780553103540" },
                new Book { Title = "The Handmaid's Tale", Author = "Margaret Atwood", ISBN = "9780385490818" },
                new Book { Title = "Fahrenheit 451", Author = "Ray Bradbury", ISBN = "9781451673319" }
        };
    }
}

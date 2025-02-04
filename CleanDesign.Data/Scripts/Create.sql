CREATE TABLE Books (
    BookId INT IDENTITY(1,1) PRIMARY KEY,
    Title NVARCHAR(255) NOT NULL,
    Author NVARCHAR(255) NOT NULL,
    ISBN NVARCHAR(13) NOT NULL UNIQUE,
    IsCheckedOut BIT NOT NULL DEFAULT 0
);
GO

INSERT INTO Books (Title, Author, ISBN, IsCheckedOut) VALUES
('The Great Gatsby', 'F. Scott Fitzgerald', '9780743273565', 0),
('To Kill a Mockingbird', 'Harper Lee', '9780061120084', 0),
('1984', 'George Orwell', '9780451524935', 1),
('Pride and Prejudice', 'Jane Austen', '9780141439518', 0),
('Moby-Dick', 'Herman Melville', '9781503280786', 0),
('War and Peace', 'Leo Tolstoy', '9780199232765', 1),
('The Catcher in the Rye', 'J.D. Salinger', '9780316769488', 0),
('The Hobbit', 'J.R.R. Tolkien', '9780547928227', 1),
('Brave New World', 'Aldous Huxley', '9780060850524', 0),
('Crime and Punishment', 'Fyodor Dostoevsky', '9780140449136', 1);
GO

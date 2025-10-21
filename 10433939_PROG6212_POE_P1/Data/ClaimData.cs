using AspNetCoreGeneratedDocument;
using _10433939_PROG6212_POE_P1.Models;

namespace _10433939_PROG6212_POE_P1.Data
{
    public class ClaimData
    {
        private static List<Lecturer> _books = new List<Book>()
{
    new Book
    {
        Id = 1,
        Title = "Clean Code",
        Author = "Robert Martin",
        Category = "Programming",
        ISBN = "",
        Description = "A guide to writing clean, readable and maintainable code",
        SubmittedDate = DateTime.Now.AddDays(-5),
        Status = BookStatus.Pending,
        Documents = new List<UploadedDocument>()
    },
    new Book
    {
        Id = 2,
        Title = "JavaScript Guide",
        Author = "Mozilla Foundation",
        Category = "Web Development",
        ISBN = "",
        Description = "A complete guide to JavaScript programming.",
        SubmittedDate = DateTime.Now.AddDays(-12),
        Status = BookStatus.Approved,
        Documents = new List<UploadedDocument>()
    },
    new Book
    {
        Id = 3,
        Title = "Pro C# 9 with .NET 5",
        Author = "Andrew Troelsen and Philip Japikse",
        Category = "Programming",
        ISBN = "",
        Description = "A guide to building C# .NET applications",
        SubmittedDate = DateTime.Now.AddDays(-18),
        Status = BookStatus.Declined,
        Documents = new List<UploadedDocument>()
    }
};

        private static int _nextId = 4;
        private static int _nextReviewId = 1;

        public static List<Book> GetAllBooks() => _books.ToList();

        public static Book? GetBookById(int id) =>
            _books.FirstOrDefault(b => b.Id == id);

        public static List<Book> GetBooksByStatus(BookStatus status) =>
            _books.Where(b => b.Status == status).ToList();

        public static void AddBook(Book book)
        {
            book.Id = _nextId;
            _nextId++;
            book.SubmittedDate = DateTime.Now;
            book.Status = BookStatus.Pending;
            _books.Add(book);
        }

        public static bool UpdateBookStatus(int id, BookStatus newStatus, string reviewedBy, string comments)
        {
            var book = GetBookById(id);
            if (book == null) return false;

            // CREATE REVIEW RECORD
            var review = new BookReview
            {

                Id = _nextReviewId,
                BookId = id,
                ReviewerName = reviewedBy,
                ReviewerRole = "Administrator",
                ReviewDate = DateTime.Now,
                Decision = newStatus,
                Comments = comments
            };
            _nextReviewId++;

            book.Reviews.Add(review);

            // UPDATE BOOK STATUS
            book.Status = newStatus;
            book.ReviewedBy = reviewedBy;
            book.ReviewedDate = DateTime.Now;

            return true;
        }

        public static int GetPendingCount() =>
            _books.Count(b => b.Status == BookStatus.Pending);

        public static int GetApprovedCount() =>
            _books.Count(b => b.Status == BookStatus.Approved);

        public static int GetVerifiedCount() =>
            _books.Count(b => b.Status == BookStatus.Verified);

        public static int GetDeclinedCount() =>
            _books.Count(b => b.Status == BookStatus.Declined);
    }
}

    

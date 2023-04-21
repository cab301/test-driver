public class ExampleTests
{
    [Test("Test 1 + 1 = 2")]
    public TestResult TestAddition()
    {
        return new TestResult("1 + 1", "2", "2", 1 + 1 == 2);
    }

    [Test("Test 1 + 1 = 3 should be false")]
    public TestResult TestAdditionFail()
    {
        return new TestResult("1 + 1", "3", "2", 1 + 1 == 3);
    }

    public class ExampleADTTests
    {
        [Test("Test Book Constructor Valid")]
        public TestResult TestBookConstructorValid()
        {
            Book book = new Book("The Hobbit", "J.R.R. Tolkien", 1937);
            return new TestResult("The Hobbit", "J.R.R. Tolkien", book.Title, book.Title == "The Hobbit");
        }

        [Test("Test Book Constructor Empty Title")]
        public TestResult TestBookConstructorInvalidTitle()
        {
            return Assertions.AssertThrows(() => new Book("", "J.R.R. Tolkien", 1937), "Book with empty title", typeof(ArgumentException));
        }

        [Test("Test Book Constructor Empty Author")]
        public TestResult TestBookConstructorInvalidAuthor()
        {
            return Assertions.AssertThrows(() => new Book("The Hobbit", "", 1937), "Book with empty author", typeof(ArgumentException));
        }

        [Test("Test Book Constructor Negative Year")]
        public TestResult TestBookConstructorInvalidYear()
        {
            return Assertions.AssertThrows(() => new Book("The Hobbit", "J.R.R. Tolkien", -1), "Book with negative year", typeof(ArgumentException));
        }

        [Test("Test Book Constructor Zero Year")]
        public TestResult TestBookConstructorInvalidYearZero()
        {
            return Assertions.AssertThrows(() => new Book("The Hobbit", "J.R.R. Tolkien", 0), "Book with zero year", typeof(ArgumentException));
        }

        [Test("Test Book Constructor Null Title")]
        public TestResult TestBookConstructorNullTitle()
        {
            return Assertions.AssertThrows(() => new Book(null, "J.R.R. Tolkien", 1937), "Book with null title", typeof(ArgumentNullException));
        }

        [Test("Test Book Constructor Null Author")]
        public TestResult TestBookConstructorNullAuthor()
        {
            return Assertions.AssertThrows(() => new Book("The Hobbit", null, 1937), "Book with null author", typeof(ArgumentNullException));
        }

        [Test("Test Book ToString")]
        public TestResult TestBookToString()
        {
            Book book = new Book("The Hobbit", "J.R.R. Tolkien", 1937);
            return new TestResult("The Hobbit by J.R.R. Tolkien (1937)", "The Hobbit by J.R.R. Tolkien (1937)", book.ToString(), book.ToString() == "The Hobbit by J.R.R. Tolkien (1937)");
        }
    }
}

class Book
{
    private string title;
    private string author;
    private int year;
    public string Title
    {
        get { return title; }
        private set
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }
            if (value.Length == 0)
            {
                throw new ArgumentException("Title cannot be empty", nameof(value));
            }
            title = value;
        }
    }
    public string Author
    {
        get { return author; }
        private set
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }
            if (value.Length == 0)
            {
                throw new ArgumentException("Author cannot be empty", nameof(value));
            }
            author = value;
        }
    }
    public int Year
    {
        get { return year; }
        private set
        {
            if (value < 0)
            {
                throw new ArgumentException("Year cannot be negative", nameof(value));
            }
            year = value;
        }
    }

    public Book(string title, string author, int year)
    {
        Title = title;
        Author = author;
        Year = year;
    }

    public override string ToString()
    {
        return $"{Title} by {Author} ({Year})";
    }
}
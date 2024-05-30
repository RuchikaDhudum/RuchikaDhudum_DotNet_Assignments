using LibraryManagementSystem.Entities;
using LibraryManagementSystem.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Cosmos;



namespace RuchikaDhudum_LibraryManagementSystem.Controllers
{

    [Route("api/[Controller]/[Action]")]
    [ApiController]
    public class LibraryController : Controller
    {

        public Container Container;
        public LibraryController()
        {
            Container = GetContainer();
        }

        public string URI = "https://localhost:8081";
        public string PrimaryKey = "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==";
        public string DatabaseName = "LibrarySystem";
        public string ContainerName = "Library";

        //Book
        [HttpPost]
        public async Task<Book>AddBookEntity(Book book)
        {
            BookEntity bookEntity = new BookEntity();
            bookEntity.Title = book.Title;
            bookEntity.Author = book.Author;
            bookEntity.PublishedDate = book.PublishedDate;
            bookEntity.ISBN = book.ISBN;
            bookEntity.IsIssued = book.IsIssued;

            bookEntity.Id = Guid.NewGuid().ToString();
            bookEntity.UId = bookEntity.Id;
            bookEntity.DocumentType = "LibraryBook";
            bookEntity.CreatedBy = "Ruchika";
            bookEntity.CreatedOn = DateTime.Now;
            bookEntity.UpdatedBy = "";
            bookEntity.UpdatedOn = DateTime.Now;
            bookEntity.Version = 1;
            bookEntity.Active = true;
            bookEntity.Archived = false;

            BookEntity response = await Container.CreateItemAsync(bookEntity);

            Book responseModel = new Book();
            responseModel.Title = response.Title;
            responseModel.Author = response.Author;
            responseModel.PublishedDate = response.PublishedDate;
            responseModel.ISBN = response.ISBN;
            responseModel.IsIssued = response.IsIssued;
            return responseModel;

        }

        [HttpGet]
        public async Task<Book> GetBookByUId(String UId)
        {
            var library = Container.GetItemLinqQueryable<BookEntity>(true).Where(q => q.UId == UId && q.Active == true && q.Archived == false).FirstOrDefault();

            Book book = new Book();
            book.UId = library.UId;
            book.Title = library.Title;
            book.Author = library.Author;
            book.PublishedDate = library.PublishedDate;
            book.ISBN = library.ISBN;
            book.IsIssued = library.IsIssued;

            return book;

        }

        [HttpGet]
        public async Task<Book> GetBookByTitle(String Title)
        {
            var library = Container.GetItemLinqQueryable<BookEntity>(true).Where(q => q.Title == Title && q.Active == true && q.Archived == false).FirstOrDefault();

            Book book = new Book();
          
            book.Title = library.Title;
            book.UId = library.UId; 
            book.Author = library.Author;
            book.PublishedDate = library.PublishedDate;
            book.ISBN = library.ISBN;
            book.IsIssued = library.IsIssued;

            return book;

        }
        [HttpGet]
        public async Task<List<Book>> GetAllBooks()
        {
            var books = Container.GetItemLinqQueryable<BookEntity>(true).Where(q => q.Active == true && q.Archived == false && q.DocumentType =="LibraryBook").ToList();

            List<Book> book1 = new List<Book>();

            foreach(var book in books)
            {
                Book bookModel = new Book();
                bookModel.UId = book.UId;
                bookModel.Title = book.Title;
                bookModel.Author = book.Author;
                bookModel.PublishedDate = book.PublishedDate;
                bookModel.ISBN = book.ISBN;
                bookModel.IsIssued = book.IsIssued;

                book1.Add(bookModel);
            }
            return book1;
        }

        [HttpGet]
        public async Task<List<Book>> GetAllNotIssuedBooks()
        {
            var books = Container.GetItemLinqQueryable<BookEntity>(true).Where(q => q.Active == true && q.Archived == false && q.DocumentType == "LibrarySystem" && q.IsIssued == false).ToList();

            List<Book> book1 = new List<Book>();

            foreach (var book in books)
            {
                Book bookModel = new Book();
                bookModel.UId = book.UId;
                bookModel.Title = book.Title;
                bookModel.Author = book.Author;
                bookModel.PublishedDate = book.PublishedDate;
                bookModel.ISBN = book.ISBN;
                bookModel.IsIssued = book.IsIssued;

                book1.Add(bookModel);
            }
            return book1;
        }

        [HttpGet]
        public async Task<List<Book>> GetAllIssuedBooks()
        {
            var books = Container.GetItemLinqQueryable<BookEntity>(true).Where(q => q.Active == true && q.Archived == false && q.DocumentType == "LibrarySystem" && q.IsIssued == true).ToList();

            List<Book> book1 = new List<Book>();

            foreach (var book in books)
            {
                Book bookModel = new Book();
                bookModel.UId = book.UId;
                bookModel.Title = book.Title;
                bookModel.Author = book.Author;
                bookModel.PublishedDate = book.PublishedDate;
                bookModel.ISBN = book.ISBN;
                bookModel.IsIssued = book.IsIssued;

                book1.Add(bookModel);
            }
            return book1;
        }

        [HttpPost]
        public async Task<Book> UpdateBook(Book book)
        {
            var existingBook = Container.GetItemLinqQueryable<BookEntity>(true).Where(q => q.UId == book.UId && q.Active == true && q.Archived == false).FirstOrDefault();

            
            existingBook.Archived = true;
            existingBook.Active = false;
            await Container.ReplaceItemAsync(existingBook, existingBook.Id);

            existingBook.Id = Guid.NewGuid().ToString();
            existingBook.UpdatedBy = "Ruchika";
            existingBook.UpdatedOn = DateTime.Today;
            existingBook.Version = existingBook.Version + 1;
            existingBook.Active = true;
            existingBook.Archived = false;

            existingBook.Title = book.Title;
            existingBook.Author = book.Author;
            existingBook.PublishedDate = book.PublishedDate;
            existingBook.ISBN = book.ISBN.ToString();
            existingBook.IsIssued = book.IsIssued;

            existingBook = await Container.CreateItemAsync(existingBook);

            Book response = new Book();
            response.UId = existingBook.UId;
            response.Title = existingBook.Title;
            response.Author = existingBook.Author;
            response.PublishedDate = existingBook.PublishedDate;
            response.ISBN = existingBook.ISBN.ToString();
            response.IsIssued = existingBook.IsIssued;
            return response;
        }

        //member

        [HttpPost]
        public async Task<Member> AddMember(Member member)
        {
            MemberEntity memberEntity = new MemberEntity();
            memberEntity.Name = member.Name;
            memberEntity.DateOfBirth = member.DateOfBirth;
            memberEntity.Email = member.Email;

            memberEntity.Id = Guid.NewGuid().ToString();
            memberEntity.UId = memberEntity.Id;
            memberEntity.DocumentType = "LibraryMember";
            memberEntity.CreatedBy = "Ruchika";
            memberEntity.CreatedOn = DateTime.Now;
            memberEntity.UpdatedBy = "";
            memberEntity.UpdatedOn = DateTime.Now;
            memberEntity.Version = 1;
            memberEntity.Active = true;
            memberEntity.Archived = false;

            MemberEntity response = await Container.CreateItemAsync(memberEntity);

            Member memberModel = new Member();
            memberModel.Name = response.Name;
            memberModel.DateOfBirth = response.DateOfBirth;
            memberModel.Email = response.Email;
            return memberModel;

        }

        [HttpGet]

        public async Task<Member> GetMemberByUId(String UId)
        {
            var member = Container.GetItemLinqQueryable<MemberEntity>(true).Where(q => q.UId == UId && q.Active == true && q.Archived == false).FirstOrDefault();

            Member members = new Member();
            members.UId = member.UId;
            members.Name = member.Name;
            members.DateOfBirth = member.DateOfBirth;
            members.Email = member.Email;
            return members;

        }

        [HttpGet]

        public async Task<List<Member>> GetAllMembers()
        {
            var members = Container.GetItemLinqQueryable<MemberEntity>(true).Where(q => q.Active == true && q.Archived == false && q.DocumentType == "LibraryMember").ToList();

            List<Member> result = new List<Member>();

            foreach(var member in members)
            {
                Member memberModel = new Member();
                memberModel.UId = member.UId;
                memberModel.Name = member.Name;
                memberModel.DateOfBirth = member.DateOfBirth;
                memberModel.Email = member.Email;
                
                result.Add(memberModel);
            }
            return result;
        }

        [HttpPost]

        public async Task<Member> updateMember(Member member)
        {
            var existingMember = Container.GetItemLinqQueryable<MemberEntity>(true).Where(q => q.UId == member.UId && q.Active == true && q.Archived == false).FirstOrDefault();

            existingMember.Archived = true;
            existingMember.Active = false;
            await Container.ReplaceItemAsync(existingMember, existingMember.Id);

            existingMember.Id = Guid.NewGuid().ToString();
            existingMember.UpdatedBy = "Ruchika";
            existingMember.UpdatedOn = DateTime.Now;
            existingMember.Version = existingMember.Version + 1;
            existingMember.Active = true;
            existingMember.Archived = false;

            existingMember.Name = member.Name;
            existingMember.DateOfBirth = (DateTime)member.DateOfBirth;
            existingMember.Email = member.Email;

            existingMember = await Container.CreateItemAsync(existingMember);

            Member response = new Member();
            response.UId = existingMember.UId;
            response.Name = existingMember.Name;
            response.DateOfBirth = (DateTime)existingMember.DateOfBirth;
            response.Email = existingMember.Email;
            return response;
        }

        //issue

        [HttpPost]

        public async Task<Issue> createIssueEntity(Issue issue)
        {
            IssueEntity issueEntity = new IssueEntity();
            

            issueEntity.BookId = issue.BookId;
            issueEntity.MemberId = issue.MemberId;
            issueEntity.IssueDate = issue.IssueDate;
            issueEntity.ReturnDate =issue.ReturnDate;
            issueEntity.isReturned = issue.isReturned;

            issueEntity.Id = Guid.NewGuid().ToString();
            issueEntity.UId = issueEntity.Id;
            issueEntity.DocumentType = "LibraryIssue";
            issueEntity.CreatedBy = "Ruchika";
            issueEntity.CreatedOn = DateTime.Now;
            issueEntity.UpdatedBy = "";
            issueEntity.UpdatedOn = DateTime.Now;
            issueEntity.Version = 1;
            issueEntity.Active = true;
            issueEntity.Archived = false;

            IssueEntity response = await Container.CreateItemAsync(issueEntity);

            Issue issueModel = new Issue();
            issueModel.BookId = response.BookId;
            issueModel.MemberId = response.MemberId;
            issueModel.IssueDate = response.IssueDate;
            issueModel.ReturnDate = response.ReturnDate;
            issueModel.isReturned = response.isReturned;
            return issueModel;

        }

        [HttpGet]

        public async Task<Issue> GetIssueBookByUId(String UId)
        {
            var issuebook = Container.GetItemLinqQueryable<IssueEntity>(true).Where(q => q.UId == UId && q.Active == true && q.Archived == false).FirstOrDefault();

            Issue issue = new Issue();
            issue.UId = issuebook.UId;
            issue.BookId = issuebook.BookId;
            issue.MemberId = issuebook.MemberId;
            issue.IssueDate = issuebook.IssueDate;
            issue.ReturnDate = issuebook.ReturnDate;
            issue.isReturned = issuebook.isReturned;

            return issue;
        }

        [HttpPost]

        public async Task<Issue> updateIssueEntity(Issue issue)
        {
            var existingIssueEntity= Container.GetItemLinqQueryable<IssueEntity>(true).Where(q => q.UId == issue.UId && q.Active == true && q.Archived == false).FirstOrDefault();

            existingIssueEntity.Archived = true;
            existingIssueEntity.Active = false;
            await Container.ReplaceItemAsync(existingIssueEntity, existingIssueEntity.Id);

            existingIssueEntity.Id = Guid.NewGuid().ToString();
            existingIssueEntity.UpdatedBy = "Ruchika";
            existingIssueEntity.UpdatedOn = DateTime.Now;
            existingIssueEntity.Version = existingIssueEntity.Version + 1;
            existingIssueEntity.Active = true;
            existingIssueEntity.Archived = false;

            existingIssueEntity.BookId = issue.BookId;
            existingIssueEntity.MemberId = issue.MemberId;
            existingIssueEntity.IssueDate = issue.IssueDate;
            existingIssueEntity.ReturnDate = issue.ReturnDate;
            existingIssueEntity.isReturned = issue.isReturned;

            existingIssueEntity =  await Container.CreateItemAsync(existingIssueEntity);

            Issue response = new Issue();
            response.UId = existingIssueEntity.UId;
            response.BookId = existingIssueEntity.BookId;
            response.MemberId = existingIssueEntity.MemberId;
            response.IssueDate = existingIssueEntity.IssueDate;
            response.ReturnDate = existingIssueEntity.ReturnDate;
            response.isReturned = existingIssueEntity.isReturned;
            return response;
        }



        private Container GetContainer()
        {
            CosmosClient cosmosClient = new CosmosClient(URI, PrimaryKey);
            Database database = cosmosClient.GetDatabase(DatabaseName);
            Container container = database.GetContainer(ContainerName);
            return container;
        }
    }


}

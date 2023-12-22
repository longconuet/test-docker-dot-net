namespace TestGraphQL
{
    public class Query
    {
        public Book GetBook() =>
        new Book
        {
            Title = "C# in depth.",
            Author = new Author
            {
                Name = "Jon Skeet"
            }
        };

        public Author GetAuthor12() =>
       new Author
       {
           Name = "Long"
       };
    }
}

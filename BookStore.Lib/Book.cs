namespace BookStore.Lib;
public record Book
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Author { get; set; }
    public string? Description { get; set; }
    public string? Review { get; set; }

    public static List<Book> GetSampleData()
    {
        return new List<Book>
        {
            new Book { Id = 1, Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", Review = "A classic novel about the American Dream", Description = "The Great Gatsby is a novel by American author F. Scott Fitzgerald. The story takes place in 1922, during the Roaring Twenties, a time of prosperity in the United States after World War I. The book received critical acclaim and is widely regarded as a classic of American literature." },
            new Book { Id = 2, Title = "To Kill a Mockingbird", Author = "Harper Lee", Review = "A novel about racism and social injustice", Description = "To Kill a Mockingbird is a novel by Harper Lee published in 1960. It was immediately successful, winning the Pulitzer Prize, and has become a classic of modern American literature. The plot and characters are loosely based on the author's observations of her family, her neighbors and an event that occurred near her hometown of Monroeville, Alabama, in 1936, when she was 10 years old." },
            new Book { Id = 3, Title = "1984", Author = "George Orwell", Review = "A dystopian novel about totalitarianism", Description = "1984 is a dystopian novel by George Orwell published in 1949. The story follows the life of Winston Smith, a low-ranking member of the ruling Party in London, Airstrip One, the capital of the superstate Oceania. Smith works in the Ministry of Truth, where he alters historical records to fit the government's propaganda. Smith starts a secret love affair with Julia, a fellow Party member, which is against the rules of the Party." },
            new Book { Id = 4, Title = "Pride and Prejudice", Author = "Jane Austen", Review = "A romantic novel about love and marriage", Description = "Pride and Prejudice is a romantic novel by Jane Austen published in 1813. The story follows the main character, Elizabeth Bennet, as she deals with issues of manners, upbringing, morality, education, and marriage in the society of the landed gentry of the British Regency. Elizabeth is the second of five daughters of a country gentleman living near the fictional town of Meryton in Hertfordshire, near London." },
        };
    }
}
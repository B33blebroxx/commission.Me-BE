namespace CommissionMe.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? PostImg { get; set; }
        public int ProfileId { get; set; }
        public string? Uid { get; set; }
        public bool Private { get; set; }
    }
}

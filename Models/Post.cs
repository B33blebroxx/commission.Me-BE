namespace CommissionMe.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? PostImg { get; set; }
        public string? Description { get; set; }
        public int ProfileId { get; set; }
        public int StyleId { get; set; }
        public bool Private { get; set; }
        public ICollection<PostTag>? PostTags { get; set; }
    }
}

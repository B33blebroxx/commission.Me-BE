namespace CommissionMe.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string? TagName { get; set; }
        public ICollection<PostTag>? PostTags { get; set; }
    }
}

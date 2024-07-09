namespace CommissionMe.Models
{
    public class Profile
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Image { get; set; }
        public string? Rates { get; set; }
        public string? Style { get; set; }
        public string? Experience { get; set; }
        public string? Bio {  get; set; }
        public string? Uid { get; set; }
        public ICollection<Post>? Posts {  get; set; }
    }
}

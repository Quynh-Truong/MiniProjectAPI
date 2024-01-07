namespace MiniProjectAPI.Models
{
    public class InterestLink
    {
        public int Id { get; set; }
        public string Link { get; set; }

        public virtual User User { get; set; }
        public virtual Interest Interest { get; set; }
    }
}

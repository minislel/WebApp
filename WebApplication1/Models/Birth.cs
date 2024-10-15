namespace WebApplication1.Models
{
    public class Birth
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public bool isValid => Name != null && Date != null;

        public int Years => (int)(Date - DateTime.Now).TotalDays / 365;
    }
}

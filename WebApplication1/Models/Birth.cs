namespace WebApplication1.Models
{
    public class Birth
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int Years => (int)( DateTime.Now - Date).TotalDays / 365;

        public bool isValid()
        {
            return Name != null && Name != String.Empty;
        }
    }
}

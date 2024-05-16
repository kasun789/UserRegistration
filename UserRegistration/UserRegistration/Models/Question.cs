namespace UserRegistration.Models
{
    public class Question
    {
        private int Id { get; set; }
        private string Type { get; set; }
        private string Description { get; set; }
        private string[] Choice { get; set; }
    }
}

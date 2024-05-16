namespace UserRegistration.Models
{
    public class Person
    {
        private int Id {get; set;}
        private string FirstName { get; set;}
        private string LastName { get; set;}
        private string Email { get; set;}
        private string Phone { get; set;}
        private string Nationality { get; set;}
        private string CurrentResidence { get; set;}
        private string IdNumber { get; set;}
        private DateOnly DateOfBirth { get; set;}
        private string Gender { get; set;}
        private int[] QuestionsId { get; set;}

    }
}

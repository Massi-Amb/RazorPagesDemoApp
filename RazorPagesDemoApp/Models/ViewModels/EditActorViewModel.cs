namespace RazorPagesDemoApp.Models.ViewModels
{
    public class EditActorViewModel
    {
        public Guid ActorId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Awards { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Movies { get; set; }
    }
}

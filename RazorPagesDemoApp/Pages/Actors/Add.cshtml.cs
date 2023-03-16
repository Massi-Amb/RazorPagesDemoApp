using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesDemoApp.Context;
using RazorPagesDemoApp.Models.Domain;
using RazorPagesDemoApp.Models.ViewModels;

namespace RazorPagesDemoApp.Pages.Actors
{
    public class AddModel : PageModel
    {
        private readonly RazorPagesDbContext dbContext;

        public AddModel(RazorPagesDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [BindProperty]
        public AddActorViewModel AddActorRequest { get; set; }  


        public void OnGet()
        {
        }

        public void OnPost()
        {
            //convert view Model to DomainModel

            var actorDomainModel = new Actor()
            {
                FullName = AddActorRequest.FullName,
                Email = AddActorRequest.Email,
                Awards = AddActorRequest.Awards,
                DateOfBirth = AddActorRequest.DateOfBirth,
                Movies = AddActorRequest.Movies,
            };

            dbContext.Actors.Add(actorDomainModel);
            dbContext.SaveChanges();
            ViewData["Message"] = "Actor created successfully!";
        }
    }
}

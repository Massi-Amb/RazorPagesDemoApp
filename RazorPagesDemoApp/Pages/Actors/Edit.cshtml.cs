using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RazorPagesDemoApp.Context;
using RazorPagesDemoApp.Models.ViewModels;

namespace RazorPagesDemoApp.Pages.Actors
{
    public class EditModel : PageModel
    {
        private readonly RazorPagesDbContext dbContext;

        [BindProperty]
        public EditActorViewModel EditActorViewModel { get; set; }

        public EditModel(RazorPagesDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void OnGet(Guid id)
        {
            var actor = dbContext.Actors.Find(id);

            if(actor != null)
            {
                //convert domain model to view model.
                EditActorViewModel = new EditActorViewModel()
                {
                    ActorId = actor.ActorId,
                    FullName = actor.FullName,
                    Email = actor.Email,
                    Awards = actor.Awards,
                    DateOfBirth = actor.DateOfBirth,
                    Movies = actor.Movies
                };
            }
        }
        public void OnPostUpdate()
        {
             if (EditActorViewModel != null)
             {
                var existingActor = dbContext.Actors.Find(EditActorViewModel.ActorId);

                if (existingActor != null)
                {
                  //Convert ViewModel to Domain Model.                  
                    existingActor.FullName = EditActorViewModel.FullName;
                    existingActor.Email = EditActorViewModel.Email;
                    existingActor.Awards = EditActorViewModel.Awards;
                    existingActor.DateOfBirth = EditActorViewModel.DateOfBirth;
                    existingActor.Movies = EditActorViewModel.Movies;

                    dbContext.SaveChanges();
                    ViewData["Message"] = "Actor Updated successfully";
                }
             }
        }
        public IActionResult OnPostDelete()
        {
            var exisitingActor = dbContext.Actors.Find(EditActorViewModel.ActorId);

            if (exisitingActor != null)
            {
                dbContext.Actors.Remove(exisitingActor);
                dbContext.SaveChanges();

                return RedirectToPage("/Actors/ActorsList");
            }

            return Page();
        }
    }
}

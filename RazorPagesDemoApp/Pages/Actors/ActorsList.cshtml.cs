using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesDemoApp.Context;

namespace RazorPagesDemoApp.Pages.Actors
{
    public class ActorsListModel : PageModel
    {
        //This private field is used to communicate with the database.
        private readonly RazorPagesDbContext dbContext;

        public List<Models.Domain.Actor> Actors { get; set; }  

        public ActorsListModel(RazorPagesDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void OnGet()
        {
           Actors = dbContext.Actors.ToList();
        }
    }
}

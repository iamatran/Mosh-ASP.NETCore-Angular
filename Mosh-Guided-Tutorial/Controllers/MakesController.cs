using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mosh_Guided_Tutorial.Models;
using Mosh_Guided_Tutorial.Persistence;

namespace Mosh_Guided_Tutorial.Controllers
{

    // NOW we're building our first API. Notice that Makes is plural
    // First we must derive this class to the controller class of ASPNET Core (other .NET might have more controller ver. for MVC controllers and api controllers)
    public class MakesController : Controller
    {
        private readonly VegaDbContext context;

        // In order for these actions to retrive data from the database, we need our context
        // First we need to define the constructor and add the context as a paremeter
        // Next we need to initialize context as a field - this will initialize the variable 'context' in a private var and set the local this.context var to the parameter
        public MakesController(VegaDbContext context)
        {
            this.context = context;
        }


        //Now we want to make an Action to return an array of Makes
        // We need to explicitly apply an [attribute] to show that this function is for HTTP calls
        // In the HTTPGet, we can specify the endpoint for this action
        [HttpGet("/api/makes")]
        // Bc we're using Async we must add Task<>
        // Async methods need an Await method that yields the result, and Task<> is an Await method
        // the old synchronous way: public IEnumerable<Make> GetMakes()
        public async Task<IEnumerable<Make>> GetMakes()
        {
            // To access the Db, you need your context
            // We only have the .ToListAsync method, not the synchronous version, so we must add await to make this asynchronous
            return await context.Makes.Include(m => m.Models).ToListAsync();
        }
        
    }
}
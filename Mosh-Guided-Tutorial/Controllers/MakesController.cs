using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mosh_Guided_Tutorial.Controllers.Resources;
using Mosh_Guided_Tutorial.Models;
using Mosh_Guided_Tutorial.Persistence;

namespace Mosh_Guided_Tutorial.Controllers
{

    // NOW we're building our first API. Notice that Makes is plural
    // First we must derive this class to the controller class of ASPNET Core (other .NET might have more controller ver. for MVC controllers and api controllers)
    public class MakesController : Controller
    {

        // In order for these actions to retrive data from the database, we need our context
        // First we need to define the constructor and add the context as a paremeter
        // Next we need to initialize context as a field - this will initialize the variable 'context' in a private var and set the local this.context var to the parameter
        // Now that we have automapper setup on Startup.cs, we can configure it here in the contructor and initialize the mapper variable
        private readonly VegaDbContext context;
        // When using Mapper, we need to create a mapping profile so that Automap knows how to map the properties from one class to another
        // Please see the /Mapping folder
        private readonly IMapper mapper;
        public MakesController(VegaDbContext context, IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;
        }


        //Now we want to make an Action to return an array of Makes
        // We need to explicitly apply an [attribute] to show that this function is for HTTP calls
        // In the HTTPGet, we can specify the endpoint for this action
        [HttpGet("/api/makes")]
        // Bc we're using Async we must add Task<>
        // Async methods need an Await method that yields the result, and Task<> is an Await method
        // the old synchronous way: public IEnumerable<Make> GetMakes()

        // Currently this has an exception due to a circular reference
        // This is bc we're using the model, which references itself - we need to separate it out with a Dto
        // This would separate our model from our controller so that the ui can't access/update things it should not access like system generated columns like Id's
        // Please see ../Resources/MakeDto.cs to see the abstraction

        // Since we're now using the Dto, we need to map these dto to our Model objects using automapper
        // First we replace <Make> with <MakeDto>
        public async Task<IEnumerable<MakeDto>> GetMakes()
        {
            // To access the Db, you need your context
            // We only have the .ToListAsync method, not the synchronous version, so we must add await to make this asynchronous
            // older version without automapper: return await context.Makes.Include(m => m.Models).ToListAsync();

            // New version with automapper using new DTO object
            var makes = await context.Makes.Include(m => m.Models).ToListAsync();
            // .Map is a generic method that takes in 2 paremeters, source type and target type
            // Then we supply the makes object as an (argument) to .Map
            return mapper.Map<List<Make>, List<MakeDto>>(makes);
        }

        [HttpGet("/api/make/{makeId}")]
        public async Task<ActionResult<MakeDto>> GetMake([FromRoute] int makeId)
        {
            var make = await context.Makes.Include(m=>m.Models).FirstOrDefaultAsync(m=>m.Id == makeId);
            return mapper.Map<Make, MakeDto>(make);
        }

    }
}
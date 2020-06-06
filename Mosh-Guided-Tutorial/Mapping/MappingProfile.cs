using AutoMapper;
using Mosh_Guided_Tutorial.Controllers.Resources;
using Mosh_Guided_Tutorial.Models;

namespace Mosh_Guided_Tutorial.Mapping
{
    // We're going to derive this class to the Profile Class from Automapper
    public class MappingProfile : Profile
    {
        // Constructor
        public MappingProfile()
        {
            // We're mapping our model to our resource dto
            // if the properties of these models match, they will automatcially map, if not we need to supply additional configuration
            // Please note that this mapping is one direction, if you want the other direction, use reversemap
            CreateMap<Make, MakeDto>();
            CreateMap<Model, ModelDto>().ReverseMap();
        }
        
    }
}
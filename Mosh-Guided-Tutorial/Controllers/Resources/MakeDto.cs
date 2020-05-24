using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Mosh_Guided_Tutorial.Controllers.Resources
{
    public class MakeDto
    {
        public int Id { get; set; }
        // Here in the Dto resource, we don't need the [dataAnnotation] like [Required]
        public string Name { get; set; }
        // Now we're referencing our new ModelDto, and not the model object for our database
        public ICollection<ModelDto> Models { get; set; }

        // This is the constructor which will initialize this object whenever something calls on the Make Class
        public MakeDto()
        {
            Models = new Collection<ModelDto>();
        }

    }
}
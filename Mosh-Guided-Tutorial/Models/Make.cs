using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Mosh_Guided_Tutorial.Models

{
    public class Make
    {
        public int Id { get; set; }
        // if you don't add the [dataAnnotation] here, this column will be nullable in the database
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        //This relationship of Model to Make will allow migrations to discover this without having to add it to the db context
        public ICollection<Model> Models { get; set; }

        public Make()
        {
            Models = new Collection<Model>();
        }
    }
}
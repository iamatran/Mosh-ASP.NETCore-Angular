using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mosh_Guided_Tutorial.Models
{
    // This will name the table to 'Models'. If not there, it will be named 'Model'
    // [dataAnnotations] work ok for these small projects, but bigger projects will use Fluent API
    // It would be better to only use Fluent API to reduce technical debt when you outgrow [dataAnnotations]
    [Table("Models")]
    public class Model
    {
        public int Id { get; set; }
        // if you don't add the [dataAnnotation] here, this column will be nullable in the database
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public Make Make { get; set; }
        public int MakeId { get; set; }
    }
}
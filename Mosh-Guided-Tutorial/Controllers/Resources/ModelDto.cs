namespace Mosh_Guided_Tutorial.Controllers.Resources
{
    public class ModelDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        // This was copied from the Model.cs model but we have it commented out on this Dto
        // This was causing our circular reference, back when we used the model as our dto
        // but now since we comment these out, the references to Make are cut off

        // public Make Make { get; set; }
        // public int MakeId { get; set; }
    }
}
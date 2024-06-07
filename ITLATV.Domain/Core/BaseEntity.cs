
namespace TVPlus.Domain.Core
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
 
    }
}

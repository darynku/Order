using Order.Core.Common;
using Order.Core.ValueObjects;

namespace Order.Core.Entities
{
    public class Seller : Entity
    {
      
        public FullName FullName { get; private set; } = null!;
        public string Description { get; private set; } = null!;
        public int YearsExperience { get; private set; }
        public int Rating { get; private set; } 




    }
}

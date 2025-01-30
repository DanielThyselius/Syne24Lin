using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models
{
    // TODO: Do we need an abstract class AND an interface?
    internal abstract class Resource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsAvailable
        {
            //get => BookedBy == null;
            get; protected set;
        }

        // TODO: move to bookable?
        public string? BookedBy { get; protected set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models
{
    internal abstract class Resource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsAvailable
        {
            //get => BookedBy == null;
            get; protected set;
        }

        public string? BookedBy { get; protected set; }
    }
}

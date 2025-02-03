using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadCodeDemo
{
    public interface IDateTimeWrapper
    {
        DateTime Now { get; }
    }

    public class DateTimeWrapper : IDateTimeWrapper
    {
        public DateTime Now => DateTime.Now;
    }
}

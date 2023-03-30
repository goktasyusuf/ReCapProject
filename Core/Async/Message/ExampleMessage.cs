using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Async.Message
{
    public class ExampleMessage : IMessage
    {
        public string Mail { get; set; }
    }
}

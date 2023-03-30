using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Async.RabbitMQ.Publisher.Abstract
{
    public interface IMailPublisher
    {
        void Publish(string key);
    }
}

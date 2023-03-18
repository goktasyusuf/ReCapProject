using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        public string Message { get; set; }
        public bool Success { get; set; }
        public Result(bool success)
        {
            this.Success = success;
        }
        public Result(string message,bool success):this(success)
        {
            this.Message = message;
        }

    }
}

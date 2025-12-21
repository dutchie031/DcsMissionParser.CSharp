using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DcsMissionParser.Net
{
    public class ParseResult<T>
    {
        public bool Success { get; private set; }
        public string FailureReason { get; set; } = string.Empty;
        public T? Result { get; set; } = default;

        private ParseResult() { }

        public static ParseResult<T> Ok(T? mizObject)
        {
            return new ParseResult<T>
            {
                Success = true,
                Result = mizObject
            };
        }
        public static ParseResult<T> Fail(string reason)
        {
            return new ParseResult<T>
            {
                Success = false,
                FailureReason = reason
            };
        }

    }
}

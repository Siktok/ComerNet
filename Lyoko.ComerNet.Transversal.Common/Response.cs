using FluentValidation;
using FluentValidation.Results;
using System.Collections.Generic;

namespace Lyoko.ComerNet.Transversal.Common
{
    public class Response<T>
    {

        public T Data { get; set; }
        public bool IsSucess { get; set; }
        public string Message { get; set; }
        public IEnumerable<ValidationFailure> Errors { get; set; }

    }
}

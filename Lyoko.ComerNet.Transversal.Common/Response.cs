

namespace Lyoko.ComerNet.Transversal.Common
{
    public class Response<T>
    {

        public T Data { get; set; }
        public bool IsSucess { get; set; }
        public string Message { get; set; }

    }
}

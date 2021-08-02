using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chat.ApplicationService.Dtos
{
    public class ItemReponse
    {
        public bool Success { get; set; }

        public string Error { get; set; }

        public int? ErrorCode { get; set; }

        public string ErrorMessage { get; set; }

    }

    public class ItemDataReponse<T> : ItemReponse
    {
        public T Data { get; set; }
    }
}

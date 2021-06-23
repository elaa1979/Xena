using System;
using System.Collections.Generic;

namespace Xena.Application.Common.Models
{
    public class BaseResult<T>
    {
        public List<T> Data { get; set; }
        public int CurrPage { get; set; }
        public int PerPage { get; set; }
        public int Total { get; set; }
        public int LastPage => PerPage == 0 ? 0 : (int)Math.Ceiling((decimal)Total / PerPage);
        public int? NextPage => CurrPage >= LastPage ? null : CurrPage + 1;
        public int? PrevPage => CurrPage > 1 ? CurrPage - 1 : null;
    }
}
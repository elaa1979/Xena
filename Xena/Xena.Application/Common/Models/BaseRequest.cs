using System;
using System.Collections.Generic;
using Xena.Application.Common.Exceptions;
using Newtonsoft.Json;

namespace Xena.Application.Common.Models
{
    public class BaseRequest
    {
        public int Page { get; set; }
        public int PerPage { get; set; }
        // public string Filters { get; set; }
        public List<Where> Filter { get; set; }
        // public List<Where> GetFilters()
        // {
        //     if (Filters is null)
        //         return null;
        //     try
        //     {
        //         return JsonConvert.DeserializeObject<List<Where>>(Filters);
        //     }
        //     catch
        //     {
        //         throw new BadRequestException(ErrorCodes.InvalidFilter);
        //     }

        // }

    }
}
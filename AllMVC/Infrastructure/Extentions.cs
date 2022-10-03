using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace AllMVC.Infrastructure
{
    public static class Extentions
    {
        public static string PathAndQuery(this HttpRequest request) => request.QueryString.HasValue
            ? request.Path.ToString() + request.QueryString.ToString()
            : request.Path.ToString();
    }
}

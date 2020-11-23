using AutoMapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace EServicesWithAngular.Domain.Common
{
    public class StaticClass
    {
        public static IConfiguration Configuration { get; set; }

        public static IMapper Mapper { get; set; }

        public static IHttpClientFactory HttpClientFactory { get; set; }
    }
}

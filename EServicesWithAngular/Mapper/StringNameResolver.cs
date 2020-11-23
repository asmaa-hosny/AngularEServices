using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ERB_TrainingServices;
using ERP_BusinessTripServices;
using EServicesWithAngular.Domain;

namespace EServicesWithAngular.Mapper
{
    public class BTCountryNameResolver : IValueResolver<mandateRequest, BusinessTripLine, string>
    {

        public string Resolve(mandateRequest source, BusinessTripLine destination, string destMember, ResolutionContext context)
        {
            return source.country.name ?? string.Empty;
        }

    }


    public class BTCityNameResolver : IValueResolver<mandateRequest, BusinessTripLine, string>
    {

        public string Resolve(mandateRequest source, BusinessTripLine destination, string destMember, ResolutionContext context)
        {
            return source.city.name ?? string.Empty;
        }

    }


    public class TRCountryNameResolver : IValueResolver<trainingRequestLine, BusinessTripLine, string>
    {

        public string Resolve(trainingRequestLine source, BusinessTripLine destination, string destMember, ResolutionContext context)
        {
            return source.country.name ?? string.Empty;
        }
    }

    public class TRCityNameResolver : IValueResolver<trainingRequestLine, BusinessTripLine, string>
    {

        public string Resolve(trainingRequestLine source, BusinessTripLine destination, string destMember, ResolutionContext context)
        {
            return source.city.name ?? string.Empty;
        }
    }


}

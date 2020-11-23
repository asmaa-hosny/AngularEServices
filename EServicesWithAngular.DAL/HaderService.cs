using EServicesWithAngular.Domain.Common;
using EServicesWithAngular.Domain.HaderExternalService;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EServicesWithAngular.DAL
{
    public class HaderService
    {

        public static async Task<IList<RequestViewModel>> GetRequests(string employeeId, int days = 30)
        {
            var response = await RestAPICaller.Get<IList<RequestViewModel>>(StaticClass.Configuration["ServiceName:HadirAPIName"], $"Requests/{employeeId}/{days}").ConfigureAwait(false);
            return response;
        }

        public static async Task<HRShortageViewModel> GetGabs(string employeeId, int days = 0)
        {
            var response = await RestAPICaller.Get<HRShortageViewModel>(StaticClass.Configuration["ServiceName:HadirAPIName"], $"Gabs/{employeeId}/{days}").ConfigureAwait(false);
            return response;
        }

        public static async Task<CheckInViewModel> GetCheckInTime(string employeeId, int days = 0)
        {
            var response = await RestAPICaller.Get<CheckInViewModel>(StaticClass.Configuration["ServiceName:HadirAPIName"], $"Today/{employeeId}").ConfigureAwait(false);
            response.ShortTime=response.CheckINDateTime.ToString("HH:mm");
            return response;
        }

      
    }
}

using EServicesWithAngular.Domain.Common;
using EServicesWithAngular.Domain.HRIExternalServiceModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EServicesWithAngular.DAL
{
    public class DashboardService
    {
        public static async Task<IList<PurchaseOrder>> GetPurchaseOrdersAsync(long employeeId)
        {
            var response = await RestAPICaller.Get<IList<PurchaseOrder>>(StaticClass.Configuration["ServiceName:ERPWebAPIName"], $"PurchaseOrder/GetAllByEmpId/{employeeId}").ConfigureAwait(false);
            return response;
        }

        public static async Task<IList<CertificateAccomplishWithOrder>> GetCOAWithOrdersAsync(long employeeId)
        {
            var response = await RestAPICaller.Get<IList<CertificateAccomplishWithOrder>>(StaticClass.Configuration["ServiceName:ERPWebAPIName"], $"COA/GetCOAWithOrders/{employeeId}").ConfigureAwait(false);
            return response;
        }

        public static async Task<IList<Employee>> FindSubordinatesAsync(string email)
        {
            var response = await RestAPICaller.Get<IList<Employee>>(StaticClass.Configuration["ServiceName:ERPWebAPIName"], $"Employee/FindSubordinates?email={email}").ConfigureAwait(false);
            return response;
        }

        public static async Task<IList<EmpTransModel>> GetEmployeeScheduleAsync(long employeeId)
        {
            var response = await RestAPICaller.Get<IList<EmpTransModel>>(StaticClass.Configuration["ServiceName:ERPWebAPIName"], $"Employee/GetEmployeeSchedule/{employeeId}").ConfigureAwait(false);
            return response;
        }

        public static async Task<IList<EmpTransModel>> GetEmployeeScheduleByTypeAsync(long employeeId,int scheduleType)
        {
            var response = await RestAPICaller.Get<IList<EmpTransModel>>(StaticClass.Configuration["ServiceName:ERPWebAPIName"], $"Employee/GetEmployeeSchedule/{employeeId}/{scheduleType}").ConfigureAwait(false);
            return response;
        }

        public static async Task<IList<EmpTransModel>> GetTeamAvilabilityAsync(string email)
        {
            var response = await RestAPICaller.Get<IList<EmpTransModel>>(StaticClass.Configuration["ServiceName:ERPWebAPIName"], $"Employee/GetTeamAvilability?email={email}").ConfigureAwait(false);
            return response;
        }
    }
}

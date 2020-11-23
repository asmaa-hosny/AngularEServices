using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EServicesApplication.Service.dashboard;
using EservicesDomain.ExternalDomain.KTA;
using EservicesDomain.SearchParameters;
using EServicesWithAngular.DataStore;
using Microsoft.AspNetCore.Mvc;


namespace EServicesWithAngular.Controllers
{

    public class DashboardController : BaseController
    {
        private IWorkqueueService _wqService;

        public DashboardController(IWorkqueueService wqService)
        {
            _wqService = wqService;
           
        }

        [HttpGet("GetTasks")]
        public IActionResult GetTasks()
        {
            return Ok(DashboardStore.Current.Tasks);
        }


        [HttpGet("GetDashboardData/{empId}")]
        public IActionResult GetDashboardData(int empId)

        {
            var store = DashboardStore.Current;
            store.CheckinTime = "07:30";
            store.AttendanceGab = "2";
            store.NextPrayingTime = "00:15:00";
            store.PendingRequests = "40";
            store.LeaveBalance = "22";
            store.TimeRemaining = "4";
            store.RequestTime = DateTime.UtcNow;

            if (empId != 0) { store.TimeRemaining = "10"; store.LeaveBalance = "55"; }
            return Ok(store);

        }

        [HttpGet("GetEmployees")]
        public IActionResult GetEmployees()
        {
            return Ok(DashboardStore.Current.Employees);

        }

        [HttpGet("GetCheckinTime/{Id}")]
        public async Task<IActionResult> GetCheckinTime(string Id)
        {
           // var model = await HaderService.GetCheckInTime(Id);

            return Ok();
        }

        [HttpGet("GetAttendanceGap/{Id}")]
        public async Task<IActionResult> GetAttendanceGap(string Id)
        {
            //var model = await HaderService.GetGabs(Id);

            return Ok();
        }

        [HttpGet("GetHaderRequests/{Id}")]
        public async Task<IActionResult> GetHaderRequests(string Id)
        {
            //var model = await HaderService.GetRequests(Id);

            return Ok();
        }

        [HttpGet("GetMeetings")]
        public IActionResult GetMeetings()
        {
            return Ok(DashboardStore.Current.Meetings);
        }

        [HttpGet("GetHaderServices")]
        public IActionResult GetHaderServices()
        {
            return Ok(DashboardStore.Current.HaderServices);
        }

        [HttpGet("GetCTSServices")]
        public IActionResult GetCTSServices()
        {
            return Ok(DashboardStore.Current.CTSServices);
        }

        [HttpGet("GetEServices")]
        public async Task<IActionResult> GetEServices()
        {
            Logger.LogDebug($"Connect to KTA Service and get workQueue for {CurrentUserEmail}");
            var wq = await KtaService.LoadWorkQueueAsync(await base.getUserSession(enforceRefresh: true));
            return Ok(wq);
        }

        [HttpPost("GetMyRequests",Name = "GetMyRequests")]
        public async Task<IActionResult> GetMyRequests([FromBody] RequestQueryParameters parameters)
       {
            parameters.UserEmail = CurrentUserEmail;

            var requestsfromrepo = await _wqService.LoadMyRequests(parameters);

            var data = Mapper.Map<IEnumerable<AllRequestPassedItem>>(requestsfromrepo);

            CreatePagingMetadata(requestsfromrepo, "GetMyRequests", parameters);

            return Ok(data);
        }

        [HttpGet("GetITCareRequests")]
        public async Task<IActionResult> GetITCareRequests()
        {
            var data = await _wqService.LoadITcareRequests(CurrentUserEmail);

            return Ok(data);
        }

        [HttpGet("GetPendingRequests")]
        public IActionResult GetPendingRequests()
        {
            return Ok(11);
        }



        [HttpGet("GetLeaveBalance")]
        public IActionResult GetLeaveBalance()
        {
            return Ok("20");
        }


        [HttpGet("GetTimeRemaining")]
        public IActionResult GetTimeRemaining()
        {
            return Ok("04:30:00");
        }

        [HttpGet("GetNextPrayingTime")]
        public IActionResult GetNextPrayingTime()
        {
            return Ok("00:15:20");
        }

        [HttpGet("FindSubordinates")]
        public async Task<IActionResult> FindSubordinates(string email)
        {
            //var result = await EServicesWithAngular.DAL.DashboardService.FindSubordinatesAsync(email);
            return Ok();
        }


        [HttpGet("GetUpcomingRequests/{employeeId}")]
        public async Task<IActionResult> GetUpcomingRequests(long employeeId)
        {
            //var result = await EServicesWithAngular.DAL.DashboardService.GetEmployeeScheduleByTypeAsync(employeeId, (int)ScheduleType.Upcoming);
            return Ok();
        }

        [HttpGet("GetTeamAvilability")]
        public async Task<IActionResult> GetTeamAvilability(string email)
        {
            //var result = await EServicesWithAngular.DAL.DashboardService.GetTeamAvilabilityAsync(email);
            return Ok();
        }


        [HttpGet("GetAllSchedule/{employeeId}")]
        public async Task<IActionResult> GetAllSchedule(long employeeId)
        {
            //var result = await EServicesWithAngular.DAL.DashboardService.GetEmployeeScheduleByTypeAsync(employeeId, (int)ScheduleType.AllWithHistory);
            //return Ok(StaticClass.Mapper.Map<List<Event>>(result));
            return Ok();
        }


        [HttpGet("GetHistoryRequests/{employeeId}")]
        public async Task<IActionResult> GetHistoryRequests(long employeeId)
        {
            //var result = await EServicesWithAngular.DAL.DashboardService.GetEmployeeScheduleByTypeAsync(employeeId, (int)ScheduleType.History);
            return Ok();
        }

        [HttpGet("GetPendingRequests/{employeeId}")]
        public async Task<IActionResult> GetPendingRequests(long employeeId)
        {
            //var result = await EServicesWithAngular.DAL.DashboardService.GetEmployeeScheduleByTypeAsync(employeeId, (int)ScheduleType.Pending);
            return Ok();

        }

        [HttpGet("GetPOInvoices/{employeeId}")]
        public async Task<IActionResult> GetPOInvoices(long employeeId)
        {
            //var result = await EServicesWithAngular.DAL.DashboardService.GetCOAWithOrdersAsync(employeeId);
            return Ok();
        }

        [HttpGet("GetPOs/{employeeId}")]
        public async Task<IActionResult> GetPOs(long employeeId)
        {
           // var result = await EServicesWithAngular.DAL.DashboardService.GetPurchaseOrdersAsync(employeeId);
            return Ok();
        }
    }
}
using EServicesWithAngular.DAL;
using ERP_MissionCompletionService;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using ERP_BusinessTripServices;
using ERB_TrainingServices;
using ERP_OvertimeServices;
using EServicesWithAngular.Domain.Common;
using EServicesWithAngular.DAL.Enums;
using System.Threading.Tasks;
using EServicesWithAngular.Domain.HRIExternalServiceModel;


namespace EServicesWithAngular.Logic
{
    public class MissionCompletionLService
    {
       
        public static  async Task<IList<EmpMission>> GetAllEmployeeMissionsAsync(long employeeId)
        {
            var response = await RestAPICaller.Get<IList<EmpMission>>(StaticClass.Configuration["ServiceName:ERPWebAPIName"], $"MissionCompletion/GetAllByEmpId/{employeeId}").ConfigureAwait(false);
            return response;
        }   

        public static async Task<EmpMission> GetMissionCompletionDetailsAsync(long missionId)
        {
            var response = await RestAPICaller.Get<EmpMission>(StaticClass.Configuration["ServiceName:ERPWebAPIName"], $"MissionCompletion/GetOne/{missionId}").ConfigureAwait(false);
            return response;
        }


        public static async Task<IList<BusinessTripLine>> GetMandateLinesAsync(long missionId)
        {
            var response = await RestAPICaller.Get<BusinessTrip>(StaticClass.Configuration["ServiceName:ERPWebAPIName"], $"BusinessTrip/GetOne/{missionId}").ConfigureAwait(false);
            return response.Lines.ToList();
         
        }

        public static async Task<IList<TrainingLine>> GetTrainingLinesAsync(long missionId)
        {
            var response = await RestAPICaller.Get<Training>(StaticClass.Configuration["ServiceName:ERPWebAPIName"], $"Training/GetOne/{missionId}").ConfigureAwait(false);
            return response.Lines.ToList();

        }

        public static async Task<IList<OvertimeLine>> GetOverTimeLinesAsync(long missionId)
        {
            var response = await RestAPICaller.Get<Overtime>(StaticClass.Configuration["ServiceName:ERPWebAPIName"], $"Overtime/GetOne/{missionId}").ConfigureAwait(false);
            return response.OvertimeLines.ToList();

        }

        public static async Task<MissionCompletion> SaveNewAsync(MissionCompletion missioncompletion)
        {
            var response = await RestAPICaller.Post<MissionCompletion, MissionCompletion>(StaticClass.Configuration["ServiceName:ERPWebAPIName"], $"MissionCompletion/AddNew", missioncompletion).ConfigureAwait(false);
            return response;
        }

        public static async Task<MissionCompletion> FindOneAsync(long missionId)
        {
            var response = await RestAPICaller.Get<MissionCompletion>(StaticClass.Configuration["ServiceName:ERPWebAPIName"], $"MissionCompletion/GetOne/{missionId}").ConfigureAwait(false);
            return response;
        }


        public static async Task<MissionCompletion> FindOneByJobIdAsync(string ktajobid)
        {
            var response = await RestAPICaller.Get<MissionCompletion>(StaticClass.Configuration["ServiceName:ERPWebAPIName"], $"MissionCompletion/GetByKtaJobId/{ktajobid}").ConfigureAwait(false);
            return response;
        }


        public static async Task<MissionCompletion> UpdateRequestAsync(int id, MissionCompletion missioncompletion)
        {
            var response = await RestAPICaller.Put<MissionCompletion, MissionCompletion>(StaticClass.Configuration["ServiceName:ERPWebAPIName"], $"MissionCompletion/Update/{id}", missioncompletion).ConfigureAwait(false);
            return response;
        }


        public static async Task<MissionCompletion> UpdateKtaJobIdAsync(int id, string ktaJobId)
        {
            var response = await RestAPICaller.Put<MissionCompletion>(StaticClass.Configuration["ServiceName:ERPWebAPIName"], $"MissionCompletion/UpdateKtaJobId/{id}/{ktaJobId}").ConfigureAwait(false);
            return response;
        }

        public static async Task<IList<EmpMission>> GetEmployeeMissionsAsync(long employeeId)
        {
            var response = await RestAPICaller.Get<IList<EmpMission>>(StaticClass.Configuration["ServiceName:ERPWebAPIName"], $"MissionCompletion/GetEmpMissions/{employeeId}").ConfigureAwait(false);
            return response;
        }



        public static IList<mandateRequest> GetMandateLines(long missionId)
        {
            using (MandateRequestMasterServiceClient client = new MandateRequestMasterServiceClient())
            {
                var lines = client.findoneAsync(missionId).GetAwaiter().GetResult().mandaterequestmaster.lines;
                return lines.ToList();
            }
        }

        public static List<trainingRequestLine> GetTrainingLines(long missionId)
        {
            using (TrainingRequestServiceClient client = new TrainingRequestServiceClient())
            {
                var lines = client.findoneAsync(missionId).GetAwaiter().GetResult().trainingrequest.lines;
                return lines.ToList();
            }
        }

        public static IList<overtimeRequestLine> GetOverTimeLines(long missionId)
        {
            using (OvertimeRequestServiceClient client = new OvertimeRequestServiceClient())
            {
                var lines = client.findoneAsync(missionId).GetAwaiter().GetResult().overtimeRequest.Lines;
                return lines.ToList();
            }
        }

        public static missionCompletion SaveNew(missionCompletion missioncompletion)
        {
            using (MissionCompletionServiceClient client = new MissionCompletionServiceClient())
            {
                var newRequest = new ERP_MissionCompletionService.saveNew();
                newRequest.MissionCompletion = missioncompletion;
                var result = client.saveNewAsync(newRequest).GetAwaiter().GetResult().MissionCompletion;
                return result.missioncompletion;
            }
        }

        public static void updateKtaJobId(long requestNo, string jobID)
        {
            using (MissionCompletionServiceClient client = new MissionCompletionServiceClient())
            {
                client.updateKTAJOBIDAsync(requestNo, jobID).GetAwaiter().GetResult();
            }
        }

        public static missionCompletion findOne(string jobId)
        {
            using (MissionCompletionServiceClient client = new MissionCompletionServiceClient())
            {
                var result = client.findoneByKTAJOBIDAsync(jobId).GetAwaiter().GetResult().MissionCompletion;
                return result;
            }

        }

    
        public static missionCompletion findOne(long missionID)
        {
            using (MissionCompletionServiceClient client = new MissionCompletionServiceClient())
            {
                var result = client.findoneAsync(missionID).GetAwaiter().GetResult().MissionCompletion;
                return result;
            }
        }

        public static missionCompletion UpdateRequest( missionCompletion mission)
        {
            using (MissionCompletionServiceClient client = new MissionCompletionServiceClient())
            {
                updateExistingMissionCompletion updatedData = new updateExistingMissionCompletion();
                updatedData.MissionCompletion = mission;
                updatedData.MissionCompletion.isApproved = "Y";
                updatedData.MissionCompletion.statuscode = "IP";
                var result = client.updateExistingMissionCompletionAsync(updatedData).GetAwaiter().GetResult().MissionCompletion.missioncompletion;
                return result;
            }

        }
        public static missionCompletion ReCalcuateMissionAccurals(missionCompletion mission)
        {
            using (MissionCompletionServiceClient client = new MissionCompletionServiceClient())
            {
                updateExistingMissionCompletion updatedData = new updateExistingMissionCompletion();
                updatedData.MissionCompletion = mission;
                var result = client.reCalcuateMissionAccuralsAsync(mission.id,mission.livingdeductdays,mission.transdeductdays,mission.fooddeductdays,mission.otherdeduction,mission.otherallowance,otherdeductionsReason: mission.otherdeductionreason).GetAwaiter().GetResult().MissionCompletion.missioncompletion;
                return result;
            }

        }

        //public static List<empMission> GetEmployeeMissions(long employeeId)
        //{
        //    using (MissionCompletionServiceClient client = new MissionCompletionServiceClient())
        //    {
        //        var result = client.getEmpMissionsAsync(employeeId).GetAwaiter().GetResult().MissionCompletion;
        //        if (result != null && result.Length > 0)
        //            return result.ToList();
        //        else
        //            return null;
        //    }
        //}

        public static empMission GetMissionCompletionDetails(long missionId)
        {
            using (MissionCompletionServiceClient client = new MissionCompletionServiceClient())
            {
                var result = client.getEmpMissionAsync(missionId).GetAwaiter().GetResult().MissionCompletion;
                return result;

            }
        }


    }
}

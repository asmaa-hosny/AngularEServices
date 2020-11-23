using CommonLibrary.Configuaration;
using CommonLibrary.Logging;
using EServicesApplication.Clients;
using EServicesApplication.Interfaces.Infrastructure;
using EServicesCommon.DI;
using EservicesDomain.ExternalDomain.Common;
using EservicesDomain.ExternalDomain.UAC;
using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EServicesInfrustructure.Network
{
    public class UACService : IUACService
    {
        private UACClient _uacClient;
        private IRestWrapper _restService ;
        private ICoreConfigurations _configuaration ;
        public ILoggerManager logger = FactoryManager.Instance.Resolve<ILoggerManager>();
        public UACService(UACClient client, IRestWrapper restService, ICoreConfigurations configuaration)
        {
            _uacClient = client;
            _restService = restService;
            _configuaration = configuaration;
        }

        
        //this Method should be called when reqired user data(require authentication),if anonmous no need to call it
        private async Task GetAccess()
        {
            await _restService.GetAccessToken(_uacClient.Client, _configuaration.UACToken);

        }

        public async Task<IList<UniversityModel>> GetAllUniversity()
        {  
            await GetAccess();
            var response = await _restService.GetWithStream<IList<UniversityModel>>(_uacClient.Client, _configuaration.UACUniversity);
            return response;
        }

        public async Task<IList<FellowModel>> GetFellows(FellowQueryModel querymodel)
        {
            await GetAccess();
            var response = await _restService.PostWithReadStream<FellowQueryModel, IList<FellowModel>>(_uacClient.Client, _configuaration.UACFellows, querymodel);
            return response;
        }

        public async Task<IList<FellowModel>> GetFellowsByUniversity(int universityId)
        {
            //if need access token ,if anonmous do not add this line
            await GetAccess();
            var queryModel = new FellowQueryModel() { UniversityId = universityId };
            var response = await _restService.PostWithReadStream<FellowQueryModel, IList<FellowModel>>(_uacClient.Client, _configuaration.UACFellows, queryModel);
            return response;
        }

        public async Task<IList<ListModel>> GetFellowResearchAreas(string email)
        {
            //if need access token ,if anonmous do not add this line
            await GetAccess();
            var response = await _restService.GetWithStream<FellowModel>(_uacClient.Client, $"{ _configuaration.UACFellowResearchArea}/{email}?isPublication=false");
            return response.UserTags;
        }

        public async Task<ConsultationViewModel> PostConsultationData(NewConsultationViewModel model)
        {
            //if need access token ,if anonmous do not add this line
            await GetAccess();
            var response = await _restService.PostWithReadStream<NewConsultationViewModel, ConsultationViewModel>(_uacClient.Client, _configuaration.PostConsultation, model);
            return response;
        }

        //Update when conmpletion request
        public async Task<ConsultationViewModel> PatchConsultationData(JsonPatchDocument<EditConsultationDataViewModel> jsonPatch, string jobId)
        {
            //if need access token ,if anonmous do not add this line
            await GetAccess();
            logger.LogDebug("PatchConsultationData : jsonPatch , jobId ", (jsonPatch , jobId));

            var response = await _restService.PatchWithReadStream<EditConsultationDataViewModel, ConsultationViewModel>(_uacClient.Client, _configuaration.PatchConsultation, jsonPatch, jobId);
            return response;
        }





    }
}

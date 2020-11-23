using ADService;
using CommonLibrary.Configuaration;
using EServicesApplication.Interfaces.Infrastructure;
using EServicesCommon.DI;
using EservicesDomain.Common;
using System;
using System.Threading.Tasks;

namespace EServicesInfrustructure.Network
{
    public class ADServiceDetail : IADServiceD
    {
        private ICoreConfigurations Configuaration => FactoryManager.Instance.Resolve<ICoreConfigurations>();

        public async Task<bool> EmployeeEvaluationNotification(string eMailBody, string eMailSubject, string responsibleDepartment, string phoneExtension, string toAddress, string ccAddress, string bccAddress, DateTime? deliveryDate = null, string from = null)
        {
            AppSendService.SendClient client = new AppSendService.SendClient();
            await client.sendEMAILAsync(Configuaration.ServiceEmail, eMailBody, eMailSubject, toAddress, ccAddress, bccAddress, deliveryDate);
            return true;
        }

        public async Task<ADReturned> GetDataFromAD(string email)
        {

            ADService.ADServiceClient client = new ADService.ADServiceClient();
            var userModel = await client.GetDataFromADAsync(email);
            return userModel;
        }

        public async Task<bool> SendEmailNotfication(String eMailBody, String eMailSubject, String toAddress, String ccAddress, String bccAddress, DateTime? deliveryDate = null, string from = null)
        {

            AppSendService.SendClient client = new AppSendService.SendClient();
            await client.sendEMAILAsync(Configuaration.ServiceEmail, eMailBody, eMailSubject, toAddress, ccAddress, bccAddress, deliveryDate);
            return true;

        }

      
        public async Task<bool> SendSMS(string AccountName, string Cellphone, string MsgContent)
        {
            AppSendService.SendClient client = new AppSendService.SendClient();
            switch (AccountName)
            {
                case SMSAccounts.smsDGPUsername:
                    await client.sendDGPSMSAsync(Cellphone, MsgContent);
                    break;
                case SMSAccounts.smsVPNUsername:
                    await client.sendVPNSMSAsync(Cellphone, MsgContent);
                    break;
                case SMSAccounts.smsHadirUsername:
                    await client.sendHadirSMSAsync(Cellphone, MsgContent);
                    break;
                case SMSAccounts.smsSPUsername:
                    await client.sendSPSMSAsync(Cellphone, MsgContent);
                    break;
                case SMSAccounts.smsTest:
                    await client.sendNCRPSMSAsync(Cellphone, MsgContent);
                    break;
                default:
                    return false;
            }
            return true;
        }
    }
}

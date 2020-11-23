using System;
using System.Threading.Tasks;

namespace EServicesApplication.Interfaces.Infrastructure
{
    public interface IADServiceD
    {
        Task<bool> SendEmailNotfication(String eMailBody, String eMailSubject, String toAddress, String ccAddress, String bccAddress, DateTime? deliveryDate = null, string from = null);

        Task<bool> EmployeeEvaluationNotification(String eMailBody, String eMailSubject, String responsibleDepartment, String phoneExtension, String toAddress, String ccAddress, String bccAddress, DateTime? deliveryDate = null, string from = null);

        Task<bool> SendSMS(String AccountName, String Cellphone, String MsgContent);

        Task<ADService.ADReturned> GetDataFromAD(string email);
    }
}

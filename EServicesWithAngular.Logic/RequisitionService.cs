using EServicesWithAngular.DAL;
using EServicesWithAngular.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading;
using EServicesWithAngular.Domain.Common;

namespace EServicesWithAngular.Logic
{
    public class RequisitionService
    {



        public static int AddNewRequest(PrcRequisition prcRequisition)
        {
            using (var context = new EServicesDBContext())
            {
                if (prcRequisition.RequisitionNatureId == 18)
                {
                    PrcRequisitionNature newNature = new PrcRequisitionNature();
                    newNature.RequisitionNatureAr = prcRequisition.RequisitionNature.RequisitionNatureAr;
                    newNature.RequisitionNatureEn = prcRequisition.RequisitionNature.RequisitionNatureEn;
                    newNature.Default = false;
                    context.PrcRequisitionNature.Add(newNature);
                    context.SaveChanges();
                    prcRequisition.RequisitionNatureId = newNature.Id;

                }
               
                context.PrcRequisition.Add(prcRequisition);
                context.SaveChanges();
            }

            return prcRequisition.Id;
        }

        public static void UpdateJobID(PrcRequisition prcRequisition)
        {
            using (var context = new EServicesDBContext())
            {
                PrcRequisition request = context.PrcRequisition.Where(x => x.Id == prcRequisition.Id).FirstOrDefault();
                request.JobId = prcRequisition.JobId;

                context.SaveChanges();
            }
        }

        public static PrcRequisition LoadRequest(string jobID)
        {
            using (var context = new EServicesDBContext())
            {
                PrcRequisition requisition = context.PrcRequisition
                 .Where(p => p.JobId == jobID).Include(x => x.PrcRequisitionVendors)
                 .Include(x => x.RequisitionNature)
                 .FirstOrDefault();
                return requisition;
            }


        }

        public static void UpdateRequest(PrcRequisition prcRequisition, List<JsonFieldsDTO> fields)
        {
            using (var context = new EServicesDBContext())
            {
                //Context.Entry<PrcRequisition>(prcRequisition).Property(x => prop.Name).IsModified = false;
                context.PrcRequisition.Update(prcRequisition);
                if (fields != null && fields.Count > 0)
                    foreach (var prop in typeof(PrcRequisition).GetProperties())
                    {
                        var match = fields.FirstOrDefault(x => x.FieldName == prop.Name);
                        if (!match.Editable)
                            context.Entry<PrcRequisition>(prcRequisition).Property(x => prop.Name).IsModified = false;

                    }
                context.SaveChanges();
            }



        }

        public static List<SelectListItem> GetRequisitionNatures(short NodeID)
        {
            using (var context = new EServicesDBContext())
            {
                List<SelectListItem> returnedData = new List<SelectListItem>();
                List<PrcRequisitionNature> RequisitionNatures = context.PrcRequisitionNature.ToList();
                if (NodeID == 0)
                    RequisitionNatures = RequisitionNatures.Where(n => n.Default == true).ToList();
                foreach (PrcRequisitionNature nature in RequisitionNatures)
                {
                    returnedData.Add(new SelectListItem { Text = nature.RequisitionNatureAr, Value = nature.Id.ToString() });
                }

                return returnedData;
            }
        }

        public static List<SelectListItem> GetProjectTypes()
        {
            using (var context = new EServicesDBContext())
            {
                List<SelectListItem> returnedData = new List<SelectListItem>();
                var RequisitionProjectTypes = context.PrcRequisitionProjectTypes.OrderBy(n => n.Id);
                foreach (PrcRequisitionProjectTypes type in RequisitionProjectTypes)
                {
                    returnedData.Add(new SelectListItem { Text = type.ProjectType, Value = type.Id.ToString() });
                }

                return returnedData;
            }
        }

        public static List<SelectListItem> getAllAccounts()
        {

            using (ERP_AccountsService.AccountsServiceClient client = new ERP_AccountsService.AccountsServiceClient())
            {
                ERP_AccountsService.accounts[] AllAccounts = null;
                AllAccounts = client.findAllAccounts();

                List<SelectListItem> returnedData = new List<SelectListItem>();

                foreach (ERP_AccountsService.accounts acc in AllAccounts)
                {
                    returnedData.Add(new SelectListItem { Text = acc.account_code + " " + acc.account_name, Value = acc.id.ToString() });
                }

                return returnedData;
            }

        }

        public static ERP_AccountsService.accountsInfo getAccountInfo(int accountID)
        {
            using (ERP_AccountsService.AccountsServiceClient client = new ERP_AccountsService.AccountsServiceClient())
            {
                ERP_AccountsService.accountsInfo AccountsInfo = null;
                AccountsInfo = client.getAccountBudgetInfo(accountID);


                return AccountsInfo;
            }
        }

        public static List<SelectListItem> getTenderingTypes(bool Arabic)
        {

            using (ERP_RefListService.RefListServiceClient client = new ERP_RefListService.RefListServiceClient())
            {
                ERP_RefListService.refList[] TenderingTypes = null;
                TenderingTypes = client.getTenderingTypes();

                List<SelectListItem> returnedData = new List<SelectListItem>();

                if (TenderingTypes == null)
                    return returnedData;

                if (Arabic)
                    foreach (ERP_RefListService.refList tt in TenderingTypes)
                    {
                        returnedData.Add(new SelectListItem { Text = tt.description, Value = tt.code });

                    }
                else
                    foreach (ERP_RefListService.refList tt in TenderingTypes)
                    {
                        returnedData.Add(new SelectListItem { Text = tt.name, Value = tt.code });
                    }


                return returnedData;
            }
        }

    }
}

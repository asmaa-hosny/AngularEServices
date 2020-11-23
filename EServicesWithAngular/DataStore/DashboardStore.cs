using EservicesDomain.ExternalModel.KTA;
using EServicesWithAngular.Models;
using System;
using System.Collections.Generic;

namespace EServicesWithAngular.DataStore
{
    public class DashboardStore
    {
        public static DashboardStore Current = new DashboardStore();

        public List<WorkQueueItem> EServices { get; set; }

        public List<TaskDto> Tasks { get; set; }

        public List<Event> Meetings { get; set; }

        //public List<EServiceDto> EServices { get; set; }

        public List<EServiceDto> HaderServices { get; set; }

        public List<EServiceDto> CTSServices { get; set; }

        public List<ListViewModel> Employees { get; set; }

        public List<WorkFlow> WorkflowHistory { get; set; }

        public List<ListViewModel> ProjectTypes { get; set; }

        public List<LisItemtViewModel> RequisitionTypes { get; set; }

        public List<ListViewModel> RequisitionNature { get; set; }

        //public List<WFDecisionDTO> Decisions { get; set; }

        //public List<RequisitionDTO> Requisitions { get; set; }

        //public List<POInvoiceDTO> POInvoices { get; set; }

        public List<ListViewModel> accounts { get; set; }

        //public List<RequisitionBudgetViewModel> BudgetAccount { get; set; }

        //public List<IdentificationLetterDTO> IdentificationLetter { get; set; }

        public EmployeeModel EmployeesData { get; set; }

        public string PendingRequests { get; set; }

        public string CheckinTime { get; set; }

        public string AttendanceGab { get; set; }

        public string LeaveBalance { get; set; }

        public string TimeRemaining { get; set; }

        public string NextPrayingTime { get; set; }

        public DateTime RequestTime { get; set; }

        public DashboardStore()
        {

            Tasks = new List<TaskDto> {

                new TaskDto()
                {

                    Id="101",
                    Type="Annual Leave",
                    Name="Mohhamed Al Sallum",
                    From=new DateTime(2019,4,1),
                    To=new DateTime(2019,5,1),
                },

                  new TaskDto()
                {

                    Id="102",
                    Type="Sick Leave",
                     Name="Attiya Al shurrab",
                    From=new DateTime(2019,3,1),
                    To=new DateTime(2019,4,1),
                },

                   new TaskDto()
                {

                    Id="501",
                    Type="Business Trip",
                    Name="Mohammed Bukhari",
                    From=new DateTime(2019,6,1),
                    To=new DateTime(2019,6,7),
                },

             };

            //POInvoices = new List<POInvoiceDTO> {

            //    new POInvoiceDTO()
            //    {

            //        Id="101",
            //        Title="Purchase Invoice-101",
            //        Status="Pending",
            //        Amount=100,
            //        Vendor="Eman Nasr"

            //    },

            //      new POInvoiceDTO()
            //    {

            //        Id="102",
            //        Title="Purchase Invoice-102",
            //        Status="Manager approval",
            //        Amount=100000,
            //        Vendor="Reem Nasr"
            //    },

            //       new POInvoiceDTO()
            //    {

            //        Id="103",
            //        Title="Purchase Invoice-103",
            //        Status="Rejected",
            //        Amount=1000000,
            //        Vendor="Deema Nasr"
            //    },

            //      new POInvoiceDTO()
            //    {

            //        Id="104",
            //        Title="Purchase Invoice-104",
            //        Status="Pending",
            //        Amount=50000,
            //        Vendor="Hassan Ahmed"
            //    },

            //      new POInvoiceDTO()
            //    {

            //        Id="105",
            //        Title="Purchase Invoice-105",
            //        Status="Approved",
            //        Amount=50000,
            //        Vendor="Hassan Ahmed"
            //    },

            //      new POInvoiceDTO()
            //    {

            //        Id="106",
            //        Title="Purchase Invoice-106",
            //        Status="Cancelled",
            //        Amount=50000,
            //        Vendor="Hassan Ahmed"
            //    },

            // };

            Meetings = new List<Event> {

                new Event()
                {

                    Title="Gathering",
                    Start=new DateTime(2019,1,1),
                    End=new DateTime(2019,1,3),

                },

                  new Event()
                {


                    Title="Achivement",
                    Start=new DateTime(2019,1,7),
                    End=new DateTime(2019,1,10),

                },

                    new Event()
                {


                    Title="Atlas",
                    Start=new DateTime(2019,1,10,13,0,0),
                    End=new DateTime(2019,1,10,15,0,0),

                },

             };

            //EServices = new List<EServiceDto> {

            //    new EServiceDto()
            //    {

            //        Id="100",
            //        Requester="Eman Nasr",
            //        Type="Annual leave",
            //        Brief="Annual leave Data"

            //    },

            //      new EServiceDto()
            //    {

            //        Id="200",
            //        Requester="Deema Al khudiri",
            //        Type="Permit leave ",
            //        Brief="Permit leave Data"
            //    },

            //       new EServiceDto()
            //    {

            //        Id="300",
            //        Requester="Reem Al Draiwaish",
            //        Type="Business Trip",
            //        Brief="Business Trip Data"
            //    },


            // };

            CTSServices = new List<EServiceDto> {

                new EServiceDto()
                {

                    Id = "101",
                    Requester = "Essam Ahmed",
                    Brief = "CTS Request"

                },

                new EServiceDto()
                {

                    Id = "201",
                    Requester = "Emmam Al Emmam",
                    Brief = "CTS Work"
                },

                new EServiceDto()
                {

                    Id = "301",
                    Requester = "attia Al Draiwaish",
                    Brief = "CTS Work"
                },

                   new EServiceDto()
                {

                    Id = "304",
                    Requester = "Sallum Al Draiwaish",
                    Brief = "CTS Work"
                },


             };

            HaderServices = new List<EServiceDto> {

                new EServiceDto()
                {

                    Id = "101",
                    Requester = "Mohhamed El Bukhari",
                    Brief = "Hadir Request"

                },

                new EServiceDto()
                {

                    Id = "201",
                    Requester = "Ibrahim Emam",
                    Brief = "Hadir Data"
                },

                new EServiceDto()
                {

                    Id = "301",
                    Requester = "Eman Nasr",
                    Brief = "Hadir Work"
                },


             };

            Employees = new List<ListViewModel> {
                 new ListViewModel()
                {

                    Id = 0,
                    Name = "My Dashboard"

                },

                new ListViewModel()
                {

                    Id = 100,
                    Name = "Mohhamed El Bukhari"

                },

                new ListViewModel()
                {

                    Id = 201,
                    Name = "Essam Emam",

                },

                new ListViewModel()
                {

                    Id = 301,
                    Name = "Deema Mohamed",

                }



             };

            WorkflowHistory = new List<WorkFlow> {

                new WorkFlow()
                {

                    JobId="fa9170cf63734e46a3d6ef78057e1e55",
                    Action="Approve",
                    Date=DateTime.Now,
                    Name="ENERGY\\s.dosari",
                    Role="Direct Manager Approval"
                },

                  new WorkFlow()
                {

                    JobId="fa9170cf63734e46a3d6ef78057e1e55",
                    Action="Done",
                    Date=DateTime.Now,
                    Name="ENERGY\\m.towayan",
                    Role="AdminServices - Costs Approval"
                },

                    new WorkFlow()
                {

                    JobId="fa9170cf63734e46a3d6ef78057e1e55",
                    Action="Approve",
                    Date=new DateTime(2019,1,10,13,0,0),
                    Name="ENERGY\\a.bahgat.c",
                    Role ="Budget Team"
                },

                     new WorkFlow()
                {

                   JobId="fa9170cf63734e46a3d6ef78057e1e55",
                    Action="Not Done",
                    Date=new DateTime(2019,1,10,13,0,0),
                    Name="ENERGY\\a.bahgat.c",
                    Role ="Personnel Approval"
                     }


             };

            ProjectTypes = new List<ListViewModel> {

                new ListViewModel()
            {

                Id = 1,
               Name="Project Type1"

            },

                new ListViewModel()
            {

                Id = 2,
               Name="project  Type2"

            },
                new ListViewModel()
            {

                Id = 3,
               Name="project Type3"

            },
            };

            RequisitionTypes = new List<LisItemtViewModel> {

                new LisItemtViewModel()
            {
                Id = "1",
               Name="Requisition Type1"

            },

                new LisItemtViewModel()
            {
                Id = "2",
               Name="Requisition Type2"

            },
                new LisItemtViewModel()
            {
                Id = "3",
               Name="Requisition Type3"

            },


                new LisItemtViewModel()
            {
                Id = "T",
               Name="T"

            },

            };

            RequisitionNature = new List<ListViewModel> {

                new ListViewModel()
            {

                Id = 1,
                Name="Requisition Nature1"

            },

                new ListViewModel()
            {

                Id = 2,
                Name="Requisition Nature2"

            },
                new ListViewModel()
            {

                Id = 3,
                Name="Requisition Nature3"

            },

            };
            accounts = new List<ListViewModel>
            {
                new ListViewModel()
                {
                    Id=1201,
                    Name="ACCOUNT-1201"


                },
                  new ListViewModel()
                {
                    Id=1202,
                    Name="ACCOUNT-1202"


                },
                   new ListViewModel()
                {
                    Id=1203,
                    Name="ACCOUNT-1203"


                },
                    new ListViewModel()
                {
                    Id=2239,
                    Name="ACCOUNT-2239"


                },



            };

           

        

            //BudgetAccount = new List<RequisitionBudgetViewModel>()
            //{
            //    new RequisitionBudgetViewModel()
            //    {

            //        AccountID=1038387,
            //        ActualAmount=12000,
            //        allyearsbudget=12565475,
            //        opencommitment=1321300,
            //        totalCommitment=1000000,
            //        originalbudgetamt=100,
            //        remBudget=10000000,
            //        TotalBudget=1234,
            //        notissuedamt=100,


            //    }
            //};



        }



    }
}

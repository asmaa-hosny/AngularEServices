using System;
using EServicesWithAngular.Domain;
using EServicesWithAngular.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.SqlServer;


namespace EServicesWithAngular.DAL
{
    public partial class EServicesDBContext : DbContext
    {
        public EServicesDBContext()
        {
        }

        public EServicesDBContext(DbContextOptions<EServicesDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CarRequest> CarRequest { get; set; }
        public virtual DbQuery<view_DecisionChoices> view_DecisionChoices { get; set; }
        public virtual DbQuery<view_Approvals> view_Approvals { get; set; }
        public virtual DbSet<CarRequestPurpose> CarRequestPurpose { get; set; }
        public virtual DbSet<CarRequestStatuses> CarRequestStatuses { get; set; }
        public virtual DbSet<CarRequestTimes> CarRequestTimes { get; set; }
        public virtual DbSet<Cars> Cars { get; set; }
        public virtual DbSet<CarsTypes> CarsTypes { get; set; }
        public virtual DbSet<CertificateOfAchievement> CertificateOfAchievement { get; set; }
        public virtual DbSet<CoreApprovals> CoreApprovals { get; set; }
        public virtual DbSet<CoreEmailRequestDetails> CoreEmailRequestDetails { get; set; }
        public virtual DbSet<CoreEmailTemplates> CoreEmailTemplates { get; set; }
        public virtual DbSet<CoreExceptions> CoreExceptions { get; set; }
        public virtual DbSet<CoreExceptionsSolutions> CoreExceptionsSolutions { get; set; }
        public virtual DbSet<CoreLookupItems> CoreLookupItems { get; set; }
        public virtual DbSet<CoreStatus> CoreStatus { get; set; }
        public virtual DbSet<ExceptionLogger> ExceptionLogger { get; set; }
        public virtual DbSet<GeneralTasksManager> GeneralTasksManager { get; set; }
        public virtual DbSet<GeneralTasksManagerTaskAction> GeneralTasksManagerTaskAction { get; set; }
        public virtual DbSet<GeneralTwoFactorAuthentication> GeneralTwoFactorAuthentication { get; set; }
        public virtual DbSet<HrEvaluationBatchEmployees> HrEvaluationBatchEmployees { get; set; }
        public virtual DbSet<HrEvaluationBatchMaster> HrEvaluationBatchMaster { get; set; }
        public virtual DbSet<HrEvaluationBatchRelations> HrEvaluationBatchRelations { get; set; }
        public virtual DbSet<HrEvaluationDevelopmentNeeds> HrEvaluationDevelopmentNeeds { get; set; }
        public virtual DbSet<HrEvaluationEmpEvaluationLine> HrEvaluationEmpEvaluationLine { get; set; }
        public virtual DbSet<HrEvaluationEmpEvaluationMaster> HrEvaluationEmpEvaluationMaster { get; set; }
        public virtual DbSet<HrEvaluationTrainingNeeds> HrEvaluationTrainingNeeds { get; set; }
        public virtual DbSet<HrOnBehalfOf> HrOnBehalfOf { get; set; }
        public virtual DbSet<HrOnBoarding> HrOnBoarding { get; set; }
        public virtual DbSet<HrOnBoardingCustody> HrOnBoardingCustody { get; set; }
        public virtual DbSet<HrProbationaryPeriod> HrProbationaryPeriod { get; set; }
        public virtual DbSet<HrTrainingSurvey> HrTrainingSurvey { get; set; }
        public virtual DbSet<HrUpdateProfile> HrUpdateProfile { get; set; }
        public virtual DbSet<IaeaAdmins> IaeaAdmins { get; set; }
        public virtual DbSet<IaeaConditions> IaeaConditions { get; set; }
        public virtual DbSet<IaeaDeliverables> IaeaDeliverables { get; set; }
        public virtual DbSet<IaeaIssues> IaeaIssues { get; set; }
        public virtual DbSet<IaeaOwners> IaeaOwners { get; set; }
        public virtual DbSet<IaeaPhases> IaeaPhases { get; set; }
        public virtual DbSet<ItEmailGroup> ItEmailGroup { get; set; }
        public virtual DbSet<ItEmailGroupMembers> ItEmailGroupMembers { get; set; }
        public virtual DbSet<ItInk> ItInk { get; set; }
        public virtual DbSet<ItInkColors> ItInkColors { get; set; }
        public virtual DbSet<ItInkDetails> ItInkDetails { get; set; }
        public virtual DbSet<ItInkPrinters> ItInkPrinters { get; set; }
        public virtual DbSet<ItRepositoryAssignment> ItRepositoryAssignment { get; set; }
        public virtual DbSet<ItRepositoryCategory> ItRepositoryCategory { get; set; }
        public virtual DbSet<ItRepositoryProduct> ItRepositoryProduct { get; set; }
        public virtual DbSet<ItRequest> ItRequest { get; set; }
        public virtual DbSet<ItRequestContractor> ItRequestContractor { get; set; }
        public virtual DbSet<ItrequestCustodyReturned> ItrequestCustodyReturned { get; set; }
        public virtual DbSet<ItrequestData> ItrequestData { get; set; }
        public virtual DbSet<ItrequestDataList> ItrequestDataList { get; set; }
        public virtual DbSet<ItrequestList> ItrequestList { get; set; }
        public virtual DbSet<ItrequestListTypes> ItrequestListTypes { get; set; }
        public virtual DbSet<ItrequestOtherDataList> ItrequestOtherDataList { get; set; }
        public virtual DbSet<ItRequestStatus> ItRequestStatus { get; set; }
        public virtual DbSet<ItrequestStatus1> ItrequestStatus1 { get; set; }
        public virtual DbSet<ItServerAccess> ItServerAccess { get; set; }
        public virtual DbSet<ItServerAccessServersList> ItServerAccessServersList { get; set; }
        public virtual DbSet<ItSms> ItSms { get; set; }
        public virtual DbSet<ItSoftware> ItSoftware { get; set; }
        public virtual DbSet<ItSoftwareApps> ItSoftwareApps { get; set; }
        public virtual DbSet<ItSoftwareCategory> ItSoftwareCategory { get; set; }
        public virtual DbSet<ItSoftwareContractor> ItSoftwareContractor { get; set; }
        public virtual DbSet<ItsoftwareList> ItsoftwareList { get; set; }
        public virtual DbSet<ItSoftwareRequestItems> ItSoftwareRequestItems { get; set; }
        public virtual DbSet<ItSpsiteCreation> ItSpsiteCreation { get; set; }
        public virtual DbSet<ItSpsiteCreationListsAndLibraries> ItSpsiteCreationListsAndLibraries { get; set; }
        public virtual DbSet<ItSpsiteCreationSiteMembers> ItSpsiteCreationSiteMembers { get; set; }
        public virtual DbSet<ItStatuses> ItStatuses { get; set; }
        public virtual DbSet<ItUserAndEmailRequest> ItUserAndEmailRequest { get; set; }
        public virtual DbSet<ItVpn> ItVpn { get; set; }
        public virtual DbSet<ItVpnRequestedGroups> ItVpnRequestedGroups { get; set; }
        public virtual DbSet<ItVpnVpngroups> ItVpnVpngroups { get; set; }
        public virtual DbSet<PrBusinessCardQuantity> PrBusinessCardQuantity { get; set; }
        public virtual DbSet<PrBusinessCardRequest> PrBusinessCardRequest { get; set; }
        public virtual DbSet<PrcRequisition> PrcRequisition { get; set; }
        public virtual DbSet<PrcRequisitionNature> PrcRequisitionNature { get; set; }
        public virtual DbSet<PrcRequisitionProjectTypes> PrcRequisitionProjectTypes { get; set; }
        public virtual DbSet<PrcRequisitionVendors> PrcRequisitionVendors { get; set; }
        public virtual DbSet<PrEvent> PrEvent { get; set; }
        public virtual DbSet<PrEventEventLocations> PrEventEventLocations { get; set; }
        public virtual DbSet<PrEventEventType> PrEventEventType { get; set; }
        public virtual DbSet<PrEventGuests> PrEventGuests { get; set; }
        public virtual DbSet<PrEventGuestType> PrEventGuestType { get; set; }
        public virtual DbSet<PrEventHospitalities> PrEventHospitalities { get; set; }
        public virtual DbSet<PrEventHospitalitiesType> PrEventHospitalitiesType { get; set; }
        public virtual DbSet<PrEventLogistic> PrEventLogistic { get; set; }
        public virtual DbSet<PrEventLogisticResponsible> PrEventLogisticResponsible { get; set; }
        public virtual DbSet<PrEventLogisticType> PrEventLogisticType { get; set; }
        public virtual DbSet<PrEventMedia> PrEventMedia { get; set; }
        public virtual DbSet<PrEventMediaType> PrEventMediaType { get; set; }
        public virtual DbSet<PrEventPrograms> PrEventPrograms { get; set; }
        public virtual DbSet<PrEventProgramType> PrEventProgramType { get; set; }
        public virtual DbSet<PrStatuses> PrStatuses { get; set; }
        public virtual DbSet<PublicRelationsEvents> PublicRelationsEvents { get; set; }
        public virtual DbSet<PublicRelationsEventsAirportRec> PublicRelationsEventsAirportRec { get; set; }
        public virtual DbSet<PublicRelationsEventsAssociatedPrograms> PublicRelationsEventsAssociatedPrograms { get; set; }
        public virtual DbSet<PublicRelationsEventsAssociatedProgramsList> PublicRelationsEventsAssociatedProgramsList { get; set; }
        public virtual DbSet<PublicRelationsEventsEventTypesList> PublicRelationsEventsEventTypesList { get; set; }
        public virtual DbSet<PublicRelationsEventsGifts> PublicRelationsEventsGifts { get; set; }
        public virtual DbSet<PublicRelationsEventsGiftsList> PublicRelationsEventsGiftsList { get; set; }
        public virtual DbSet<PublicRelationsEventsHospitalities> PublicRelationsEventsHospitalities { get; set; }
        public virtual DbSet<PublicRelationsEventsHospitalitiesList> PublicRelationsEventsHospitalitiesList { get; set; }
        public virtual DbSet<PublicRelationsEventsKacarerec> PublicRelationsEventsKacarerec { get; set; }
        public virtual DbSet<PublicRelationsEventsNeeds> PublicRelationsEventsNeeds { get; set; }
        public virtual DbSet<PublicRelationsEventsNeedsList> PublicRelationsEventsNeedsList { get; set; }
        public virtual DbSet<StrResourcesMatrix> StrResourcesMatrix { get; set; }
        public virtual DbSet<StrResourcesMatrixResources> StrResourcesMatrixResources { get; set; }

        // Unable to generate entity type for table 'dbo.Core_Lookups'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.testFloat'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.ITRequest_ItemsStatusHistory'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.ITRequest_StatusRules'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.ITRequest_VPN'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.ITRequestListPermissions'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.KTA_Notification_Source'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.Temp_ITRequestDataList'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer(StaticClass.Configuration["ConnectionStrings:DefaultConnection"]);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasSequence<int>("RequisitionSeq", schema: "dbo")
            .StartsAt(1000)
            .IncrementsBy(5);
            modelBuilder.Entity<CarRequest>(entity =>
            {
                

                entity.Property(e => e.JobId).ValueGeneratedNever();

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.RefId)
                    .IsUnicode(false)
                    .HasComputedColumnSql("([dbo].[GenerateCarReqREFID]([ID]))");

                entity.Property(e => e.Returned).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Car)
                    .WithMany(p => p.CarRequest)
                    .HasForeignKey(d => d.CarId)
                    .HasConstraintName("FK_CarRequest_Cars");

                entity.HasOne(d => d.RequestPurpose)
                    .WithMany(p => p.CarRequest)
                    .HasForeignKey(d => d.RequestPurposeId)
                    .HasConstraintName("FK_CarRequest_CarRequestPurpose");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.CarRequest)
                    .HasForeignKey(d => d.StatusId)
                    .HasConstraintName("FK_CarRequest_CarRequest_Statuses");
            });

            modelBuilder.Entity<Cars>(entity =>
            {
                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Cars)
                    .HasForeignKey(d => d.TypeId)
                    .HasConstraintName("FK_Cars_CarsTypes");
            });

            modelBuilder.Entity<CertificateOfAchievement>(entity =>
            {
                entity.Property(e => e.JobId).ValueGeneratedNever();

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Refid)
                    .IsUnicode(false)
                    .HasComputedColumnSql("([dbo].[GenerateCertificateOfAchievementREFID]([id]))");

                entity.Property(e => e.RequestDate).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<CoreApprovals>(entity =>
            {
                entity.Property(e => e.Date).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<CoreEmailRequestDetails>(entity =>
            {
                entity.Property(e => e.Name).ValueGeneratedNever();
            });

            modelBuilder.Entity<CoreEmailTemplates>(entity =>
            {
                entity.Property(e => e.Name).ValueGeneratedNever();
            });

            modelBuilder.Entity<CoreExceptions>(entity =>
            {
                entity.Property(e => e.JobId).ValueGeneratedNever();

                entity.HasOne(d => d.SolutionNavigation)
                    .WithMany(p => p.CoreExceptions)
                    .HasForeignKey(d => d.Solution)
                    .HasConstraintName("FK_Core_Exceptions_Core_Exceptions_Solutions");
            });

            modelBuilder.Entity<CoreExceptionsSolutions>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<CoreLookupItems>(entity =>
            {
                entity.Property(e => e.LookupItemId).ValueGeneratedNever();
            });

            modelBuilder.Entity<GeneralTasksManager>(entity =>
            {
                entity.Property(e => e.RefId)
                    .IsUnicode(false)
                    .HasComputedColumnSql("([dbo].[GenerateGeneral_TSK_REFID]([id]))");

                entity.HasOne(d => d.ParentTask)
                    .WithMany(p => p.InverseParentTask)
                    .HasForeignKey(d => d.ParentTaskId)
                    .HasConstraintName("FK_General_TasksManager_General_TasksManager1");
            });

            modelBuilder.Entity<GeneralTasksManagerTaskAction>(entity =>
            {
                entity.HasOne(d => d.Task)
                    .WithMany(p => p.GeneralTasksManagerTaskAction)
                    .HasForeignKey(d => d.TaskId)
                    .HasConstraintName("FK_General_TasksManager_TaskAction_General_TasksManager");
            });

            modelBuilder.Entity<HrEvaluationBatchEmployees>(entity =>
            {
                entity.HasOne(d => d.Batch)
                    .WithMany(p => p.HrEvaluationBatchEmployees)
                    .HasForeignKey(d => d.BatchId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HR_Evaluation_BatchEmployees_HR_Evaluation_BatchMaster");

                entity.HasOne(d => d.Evaluation)
                    .WithMany(p => p.HrEvaluationBatchEmployees)
                    .HasForeignKey(d => d.EvaluationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HR_Evaluation_BatchEmployees_HR_Evaluation_EmpEvaluationMaster");
            });

            modelBuilder.Entity<HrEvaluationBatchMaster>(entity =>
            {
                entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<HrEvaluationBatchRelations>(entity =>
            {
                entity.HasOne(d => d.DestinationBatchNavigation)
                    .WithMany(p => p.HrEvaluationBatchRelationsDestinationBatchNavigation)
                    .HasForeignKey(d => d.DestinationBatch)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HR_Evaluation_BatchRelations_HR_Evaluation_BatchMaster_DetinationBatch");

                entity.HasOne(d => d.SourceBatchNavigation)
                    .WithMany(p => p.HrEvaluationBatchRelationsSourceBatchNavigation)
                    .HasForeignKey(d => d.SourceBatch)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<HrEvaluationDevelopmentNeeds>(entity =>
            {
                entity.HasOne(d => d.EvaluationMaster)
                    .WithMany(p => p.HrEvaluationDevelopmentNeeds)
                    .HasForeignKey(d => d.EvaluationMasterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HR_Evaluation_DevelopmentNeeds_HR_Evaluation_EmpEvaluationMaster");
            });

            modelBuilder.Entity<HrEvaluationEmpEvaluationLine>(entity =>
            {
                entity.HasOne(d => d.Master)
                    .WithMany(p => p.HrEvaluationEmpEvaluationLine)
                    .HasForeignKey(d => d.MasterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HR_Evaluation_EmpEvaluationLine_HR_Evaluation_EmpEvaluationMaster");
            });

            modelBuilder.Entity<HrEvaluationEmpEvaluationMaster>(entity =>
            {
                entity.Property(e => e.Created).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<HrEvaluationTrainingNeeds>(entity =>
            {
                entity.HasOne(d => d.EvaluationMaster)
                    .WithMany(p => p.HrEvaluationTrainingNeeds)
                    .HasForeignKey(d => d.EvaluationMasterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HR_Evaluation_TrainingNeeds_HR_Evaluation_TrainingNeeds");
            });

            modelBuilder.Entity<HrOnBoarding>(entity =>
            {
                entity.Property(e => e.RefId)
                    .IsUnicode(false)
                    .HasComputedColumnSql("([dbo].[GenerateHROnBoardingREFID]([id]))");
            });

            modelBuilder.Entity<HrOnBoardingCustody>(entity =>
            {
                entity.HasOne(d => d.AssociatedToNavigation)
                    .WithMany(p => p.HrOnBoardingCustody)
                    .HasForeignKey(d => d.AssociatedTo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HR_OnBoarding_Custody_HR_OnBoarding");
            });

            modelBuilder.Entity<HrProbationaryPeriod>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Rdate).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<HrUpdateProfile>(entity =>
            {
                entity.Property(e => e.RefId)
                    .IsUnicode(false)
                    .HasComputedColumnSql("([dbo].[GenerateHRUpdateProfileREFID]([id]))");
            });

            modelBuilder.Entity<IaeaAdmins>(entity =>
            {
                entity.Property(e => e.EmployeeEmail).ValueGeneratedNever();
            });

            modelBuilder.Entity<IaeaConditions>(entity =>
            {
                entity.HasOne(d => d.Phase)
                    .WithMany(p => p.IaeaConditions)
                    .HasForeignKey(d => d.PhaseId)
                    .HasConstraintName("FK_IAEA_Conditions_IAEA_Phases");
            });

            modelBuilder.Entity<IaeaDeliverables>(entity =>
            {
                entity.Property(e => e.StartDate).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Condition)
                    .WithMany(p => p.IaeaDeliverables)
                    .HasForeignKey(d => d.ConditionId)
                    .HasConstraintName("FK_IAEA_Deliverables_IAEA_Conditions");
            });

            modelBuilder.Entity<IaeaPhases>(entity =>
            {
                entity.HasOne(d => d.Issue)
                    .WithMany(p => p.IaeaPhases)
                    .HasForeignKey(d => d.IssueId)
                    .HasConstraintName("FK_IAEA_Phases_IAEA_Issues");
            });

            modelBuilder.Entity<ItInk>(entity =>
            {
                entity.Property(e => e.Rdate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.RefId)
                    .IsUnicode(false)
                    .HasComputedColumnSql("([dbo].[GenerateIT_Ink_REFID]([id]))");
            });

            modelBuilder.Entity<ItInkColors>(entity =>
            {
                entity.HasOne(d => d.Printer)
                    .WithMany(p => p.ItInkColors)
                    .HasForeignKey(d => d.PrinterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IT_Ink_Colors_IT_Ink_Printers");
            });

            modelBuilder.Entity<ItInkDetails>(entity =>
            {
                entity.HasOne(d => d.Color)
                    .WithMany(p => p.ItInkDetails)
                    .HasForeignKey(d => d.ColorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IT_Ink_Details_IT_Ink_Colors1");

                entity.HasOne(d => d.Request)
                    .WithMany(p => p.ItInkDetails)
                    .HasForeignKey(d => d.RequestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IT_Ink_Details_IT_Ink");

                entity.HasOne(d => d.StatusNavigation)
                    .WithMany(p => p.ItInkDetails)
                    .HasForeignKey(d => d.Status)
                    .HasConstraintName("FK_IT_Ink_Details_IT_Statuses");
            });

            modelBuilder.Entity<ItRepositoryAssignment>(entity =>
            {
                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ItRepositoryAssignment)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IT_Repository_Assignmetns_IT_Repository_Products");

                entity.HasOne(d => d.Request)
                    .WithMany(p => p.ItRepositoryAssignment)
                    .HasForeignKey(d => d.RequestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IT_Repository_Assignmetns_IT_Requests");
            });

            modelBuilder.Entity<ItRepositoryCategory>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.InverseIdNavigation)
                    .HasForeignKey<ItRepositoryCategory>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IT_Repository_Categories_IT_Repository_Categories");
            });

            modelBuilder.Entity<ItRepositoryProduct>(entity =>
            {
                entity.HasOne(d => d.CategoryNavigation)
                    .WithMany(p => p.ItRepositoryProduct)
                    .HasForeignKey(d => d.Category)
                    .HasConstraintName("FK_IT_Repository_Products_IT_Repository_Categories");
            });

            modelBuilder.Entity<ItRequest>(entity =>
            {
                entity.Property(e => e.RefId)
                    .IsUnicode(false)
                    .HasComputedColumnSql("([dbo].[GenerateIT_ServerAccess_REFID]([id]))");
            });

            modelBuilder.Entity<ItRequestContractor>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.ItRequest)
                    .WithMany(p => p.ItRequestContractor)
                    .HasForeignKey(d => d.ItRequestId)
                    .HasConstraintName("FK_IT_Requests_Contractors_IT_Requests");
            });

            modelBuilder.Entity<ItrequestCustodyReturned>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<ItrequestData>(entity =>
            {
                entity.Property(e => e.JobId).ValueGeneratedNever();

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Refid)
                    .IsUnicode(false)
                    .HasComputedColumnSql("([dbo].[GenerateITReq_REFID]([id],[OtherItems]))");

                entity.Property(e => e.Requestdate).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.StatusNavigation)
                    .WithMany(p => p.ItrequestData)
                    .HasForeignKey(d => d.Status)
                    .HasConstraintName("FK_ITRequestData_Core_Status");
            });

            modelBuilder.Entity<ItrequestDataList>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.InverseIdNavigation)
                    .HasForeignKey<ItrequestDataList>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ITRequestDataList_ITRequestDataList");

                entity.HasOne(d => d.ItrequestData)
                    .WithMany(p => p.ItrequestDataList)
                    .HasForeignKey(d => d.ItrequestDataId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ITRequestDataList_ITRequestData");

                entity.HasOne(d => d.ItrequestList)
                    .WithMany(p => p.ItrequestDataList)
                    .HasForeignKey(d => d.ItrequestListId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ITRequestDataList_ITRequestList2");

                entity.HasOne(d => d.ItrequestStatus)
                    .WithMany(p => p.ItrequestDataList)
                    .HasForeignKey(d => d.ItrequestStatusId)
                    .HasConstraintName("FK_ITRequestDataList_ITRequestStatus");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.ItrequestDataList)
                    .HasForeignKey(d => d.TypeId)
                    .HasConstraintName("FK_ITRequestDataList_ITRequestListTypes");
            });

            modelBuilder.Entity<ItrequestListTypes>(entity =>
            {
                entity.HasOne(d => d.RequestList)
                    .WithMany(p => p.ItrequestListTypes)
                    .HasForeignKey(d => d.RequestListId)
                    .HasConstraintName("FK_ITRequestListTypes_ITRequestList");
            });

            modelBuilder.Entity<ItrequestOtherDataList>(entity =>
            {
                entity.HasOne(d => d.ItrequestList)
                    .WithMany(p => p.ItrequestOtherDataList)
                    .HasForeignKey(d => d.ItrequestListId)
                    .HasConstraintName("FK_ITRequestOtherDataList_ITRequestList");

                entity.HasOne(d => d.ItrequestStatus)
                    .WithMany(p => p.ItrequestOtherDataList)
                    .HasForeignKey(d => d.ItrequestStatusId)
                    .HasConstraintName("FK_ITRequestOtherDataList_ITRequestStatus");
            });

            modelBuilder.Entity<ItRequestStatus>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Assignment)
                    .WithMany(p => p.ItRequestStatus)
                    .HasForeignKey(d => d.AssignmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IT_Requests_Status_IT_Repository_Assignmetns");
            });

            modelBuilder.Entity<ItServerAccess>(entity =>
            {
                entity.Property(e => e.RefId)
                    .IsUnicode(false)
                    .HasComputedColumnSql("([dbo].[GenerateIT_ServerAccess_REFID]([id]))");
            });

            modelBuilder.Entity<ItSoftware>(entity =>
            {
                entity.Property(e => e.Qty).HasDefaultValueSql("((1))");

                entity.Property(e => e.RefId)
                    .IsUnicode(false)
                    .HasComputedColumnSql("([dbo].[GenerateIT_Software_REFID]([id]))");

                entity.HasOne(d => d.Contractor)
                    .WithMany(p => p.ItSoftware)
                    .HasForeignKey(d => d.ContractorId)
                    .HasConstraintName("FK_IT_Software_IT_Software_Contractor");
            });

            modelBuilder.Entity<ItSoftwareApps>(entity =>
            {
                entity.HasOne(d => d.Category)
                    .WithMany(p => p.ItSoftwareApps)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IT_Software_Apps_IT_Software_Category");
            });

            modelBuilder.Entity<ItsoftwareList>(entity =>
            {
                entity.Property(e => e.IsEa).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<ItSoftwareRequestItems>(entity =>
            {
                entity.HasOne(d => d.App)
                    .WithMany(p => p.ItSoftwareRequestItems)
                    .HasForeignKey(d => d.AppId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IT_Software_RequestItems_IT_Software_Apps");

                entity.HasOne(d => d.Request)
                    .WithMany(p => p.ItSoftwareRequestItems)
                    .HasForeignKey(d => d.RequestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IT_Software_RequestItems_IT_Software");

                entity.HasOne(d => d.StatusNavigation)
                    .WithMany(p => p.ItSoftwareRequestItems)
                    .HasForeignKey(d => d.Status)
                    .HasConstraintName("FK_IT_Software_RequestItems_IT_Statuses");
            });

            modelBuilder.Entity<ItSpsiteCreation>(entity =>
            {
                entity.Property(e => e.RefId)
                    .IsUnicode(false)
                    .HasComputedColumnSql("([dbo].[GenerateIT_SPSiteCreation_REFID]([id]))");
            });

            modelBuilder.Entity<ItSpsiteCreationListsAndLibraries>(entity =>
            {
                entity.HasOne(d => d.Request)
                    .WithMany(p => p.ItSpsiteCreationListsAndLibraries)
                    .HasForeignKey(d => d.RequestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IT_SPSiteCreation_ListsAndLibraries_IT_SPSiteCreation");
            });

            modelBuilder.Entity<ItSpsiteCreationSiteMembers>(entity =>
            {
                entity.HasOne(d => d.Request)
                    .WithMany(p => p.ItSpsiteCreationSiteMembers)
                    .HasForeignKey(d => d.RequestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IT_SPSiteCreation_SiteMembers_IT_SPSiteCreation");
            });

            modelBuilder.Entity<ItStatuses>(entity =>
            {
                entity.Property(e => e.Code).ValueGeneratedNever();
            });

            modelBuilder.Entity<ItUserAndEmailRequest>(entity =>
            {
                entity.Property(e => e.RefId)
                    .IsUnicode(false)
                    .HasComputedColumnSql("([dbo].[GenerateIT_SYS_REFID]([id]))");
            });

            modelBuilder.Entity<ItVpn>(entity =>
            {
                entity.Property(e => e.RefId)
                    .IsUnicode(false)
                    .HasComputedColumnSql("([dbo].[GenerateIT_VPN_REFID]([id]))");
            });

            modelBuilder.Entity<ItVpnRequestedGroups>(entity =>
            {
                entity.HasOne(d => d.AssociatedToNavigation)
                    .WithMany(p => p.ItVpnRequestedGroups)
                    .HasForeignKey(d => d.AssociatedTo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IT_VPN_Servers_IT_VPN");

                entity.HasOne(d => d.Vpngroup)
                    .WithMany(p => p.ItVpnRequestedGroups)
                    .HasForeignKey(d => d.VpngroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IT_VPN_RequestedGroups_IT_VPN_VPNGroups");
            });

            modelBuilder.Entity<ItVpnVpngroups>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<PrBusinessCardQuantity>(entity =>
            {
                entity.HasIndex(e => e.Id)
                    .HasName("IX_PR_BusinessCard_Quantity");
            });

            modelBuilder.Entity<PrBusinessCardRequest>(entity =>
            {
                entity.Property(e => e.RequestDate).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.QuantityNavigation)
                    .WithMany(p => p.PrBusinessCardRequest)
                    .HasForeignKey(d => d.Quantity)
                    .HasConstraintName("FK_PR_BusinessCardRequest_PR_BusinessCard_Quantity");
            });

            modelBuilder.Entity<PrcRequisition>(entity =>
            {
               
                entity.Property(e => e.RefId)
                    
                    .HasDefaultValueSql("next value for RequisitionSeq");

                entity.HasOne(d => d.ProjectType)
                    .WithMany(p => p.PrcRequisition)
                    .HasForeignKey(d => d.ProjectTypeId)
                    .HasConstraintName("FK_PRC_Requisition_PRC_Requisition_ProjectTypes");

                entity.HasOne(d => d.RequisitionNature)
                    .WithMany(p => p.PrcRequisition)
                    .HasForeignKey(d => d.RequisitionNatureId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PRC_RequisitionNature_PRC_Requisition");

                entity.Ignore(d => d.AttachementListName);
             
            });

            modelBuilder.Entity<PrcRequisitionNature>(entity =>
            {
                entity.Property(e => e.Default).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<PrcRequisitionVendors>(entity =>
            {
                entity.HasOne(d => d.Requisition)
                    .WithMany(p => p.PrcRequisitionVendors)
                    .HasForeignKey(d => d.RequisitionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PRC_Requisition_Vendors_PRC_Requisition");
            });

            modelBuilder.Entity<PrEvent>(entity =>
            {
                entity.HasOne(d => d.EventLocationNavigation)
                    .WithMany(p => p.PrEvent)
                    .HasForeignKey(d => d.EventLocation)
                    .HasConstraintName("FK_PR_Event_PR_Event_EventLocations");

                entity.HasOne(d => d.EventTypeNavigation)
                    .WithMany(p => p.PrEvent)
                    .HasForeignKey(d => d.EventType)
                    .HasConstraintName("FK_PR_Event_PR_Event_EventType");

                entity.HasOne(d => d.GuestTypeNavigation)
                    .WithMany(p => p.PrEvent)
                    .HasForeignKey(d => d.GuestType)
                    .HasConstraintName("FK_PR_Event_PR_Event_GuestType");
            });

            modelBuilder.Entity<PrEventGuests>(entity =>
            {
                entity.Property(e => e.IsExternal).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.PrEventGuests)
                    .HasForeignKey(d => d.EventId)
                    .HasConstraintName("FK_PR_Event_Guests_PR_Event");
            });

            modelBuilder.Entity<PrEventHospitalities>(entity =>
            {
                entity.HasOne(d => d.Event)
                    .WithMany(p => p.PrEventHospitalities)
                    .HasForeignKey(d => d.EventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PR_Event_Hospitalities_PR_Event");

                entity.HasOne(d => d.HospitalitiesNavigation)
                    .WithMany(p => p.PrEventHospitalities)
                    .HasForeignKey(d => d.Hospitalities)
                    .HasConstraintName("FK_PR_Event_Hospitalities_PR_Event_HospitalitiesType");

                entity.HasOne(d => d.StatusNavigation)
                    .WithMany(p => p.PrEventHospitalities)
                    .HasForeignKey(d => d.Status)
                    .HasConstraintName("FK_PR_Event_Hospitalities_PR_Status");
            });

            modelBuilder.Entity<PrEventLogistic>(entity =>
            {
                entity.HasOne(d => d.Event)
                    .WithMany(p => p.PrEventLogistic)
                    .HasForeignKey(d => d.EventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PR_Event_Logistic_PR_Event");

                entity.HasOne(d => d.Logistic)
                    .WithMany(p => p.PrEventLogistic)
                    .HasForeignKey(d => d.LogisticId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PR_Event_Logistic_PR_Event_LogisticType");

                entity.HasOne(d => d.StatusNavigation)
                    .WithMany(p => p.PrEventLogistic)
                    .HasForeignKey(d => d.Status)
                    .HasConstraintName("FK_PR_Event_Logistic_PR_Statuses");
            });

            modelBuilder.Entity<PrEventLogisticType>(entity =>
            {
                entity.HasOne(d => d.Responsible)
                    .WithMany(p => p.PrEventLogisticType)
                    .HasForeignKey(d => d.ResponsibleId)
                    .HasConstraintName("FK_PR_Event_LogisticType_PR_Event_Logistic_Responsible");
            });

            modelBuilder.Entity<PrEventMedia>(entity =>
            {
                entity.HasOne(d => d.Event)
                    .WithMany(p => p.PrEventMedia)
                    .HasForeignKey(d => d.EventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PR_Event_Media_PR_Event");

                entity.HasOne(d => d.MediaTypeNavigation)
                    .WithMany(p => p.PrEventMedia)
                    .HasForeignKey(d => d.MediaType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PR_Event_Media_PR_Event_MediaType");

                entity.HasOne(d => d.StatusNavigation)
                    .WithMany(p => p.PrEventMedia)
                    .HasForeignKey(d => d.Status)
                    .HasConstraintName("FK_PR_Event_Media_PR_Statuses");
            });

            modelBuilder.Entity<PrEventPrograms>(entity =>
            {
                entity.HasOne(d => d.Event)
                    .WithMany(p => p.PrEventPrograms)
                    .HasForeignKey(d => d.EventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PR_Event_Programs_PR_Event");

                entity.HasOne(d => d.Program)
                    .WithMany(p => p.PrEventPrograms)
                    .HasForeignKey(d => d.ProgramId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PR_Event_Programs_PR_Event_ProgramType");

                entity.HasOne(d => d.StatusNavigation)
                    .WithMany(p => p.PrEventPrograms)
                    .HasForeignKey(d => d.Status)
                    .HasConstraintName("FK_PR_Event_Programs_PR_Statuses");
            });

            modelBuilder.Entity<PrStatuses>(entity =>
            {
                entity.Property(e => e.Code).ValueGeneratedNever();
            });

            modelBuilder.Entity<PublicRelationsEvents>(entity =>
            {
                entity.Property(e => e.RefId)
                    .IsUnicode(false)
                    .HasComputedColumnSql("([dbo].[GeneratePublicRelations_EVENTS_REFID]([id]))");
            });

            modelBuilder.Entity<PublicRelationsEventsAssociatedProgramsList>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<PublicRelationsEventsEventTypesList>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<PublicRelationsEventsGiftsList>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<PublicRelationsEventsHospitalitiesList>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<PublicRelationsEventsNeedsList>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<StrResourcesMatrix>(entity =>
            {
                entity.Property(e => e.RefId)
                    .IsUnicode(false)
                    .HasComputedColumnSql("([dbo].[GenerateSTR_ResourcesMatrix_REFID]([id]))");
            });

            modelBuilder.Entity<StrResourcesMatrixResources>(entity =>
            {
                entity.HasOne(d => d.Request)
                    .WithMany(p => p.StrResourcesMatrixResources)
                    .HasForeignKey(d => d.RequestId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_STR_ResourcesMatrix_Resources_STR_ResourcesMatrix");
            });
        }
    }
}

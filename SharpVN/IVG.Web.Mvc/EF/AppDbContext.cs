using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace IVG.Web.Mvc.EF
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext()
            : base("name=AppDbContext")
        {
        }
        public virtual DbSet<AllJobAndRequest> AllJobAndRequests { get; set; }
        public virtual DbSet<DanhSachCaseRequest> DanhSachCaseRequest { get; set; }
        public virtual DbSet<tbl_Areas> tbl_Areas { get; set; }
        public virtual DbSet<tbl_Attribute> tbl_Attribute { get; set; }
        public virtual DbSet<tbl_AuditConfigurations> tbl_AuditConfigurations { get; set; }
        public virtual DbSet<tbl_AuditLogs> tbl_AuditLogs { get; set; }
        public virtual DbSet<tbl_CalendarJobs> tbl_CalendarJobs { get; set; }
        public virtual DbSet<tbl_Cases> tbl_Cases { get; set; }
        public virtual DbSet<tbl_CasesBackup> tbl_CasesBackup { get; set; }
        public virtual DbSet<tbl_CasesRequest> tbl_CasesRequest { get; set; }
        public virtual DbSet<tbl_CasesRequestStatus> tbl_CasesRequestStatus { get; set; }
        public virtual DbSet<tbl_Category> tbl_Category { get; set; }
        public virtual DbSet<tbl_CategoryOfServiceCenter> tbl_CategoryOfServiceCenter { get; set; }
        public virtual DbSet<tbl_CategoryOfTechnicalStaff> tbl_CategoryOfTechnicalStaff { get; set; }
        public virtual DbSet<tbl_ColumnView> tbl_ColumnView { get; set; }
        public virtual DbSet<tbl_Conditions> tbl_Conditions { get; set; }
        public virtual DbSet<tbl_Countries> tbl_Countries { get; set; }
        public virtual DbSet<tbl_Currencies> tbl_Currencies { get; set; }
        public virtual DbSet<tbl_Customers> tbl_Customers { get; set; }
        public virtual DbSet<tbl_DefectCodes> tbl_DefectCodes { get; set; }
        public virtual DbSet<tbl_Districts> tbl_Districts { get; set; }
        public virtual DbSet<tbl_Documents> tbl_Documents { get; set; }
        public virtual DbSet<tbl_Entities> tbl_Entities { get; set; }
        public virtual DbSet<tbl_EWarrantyRole> tbl_EWarrantyRole { get; set; }
        public virtual DbSet<tbl_ExchangeRates> tbl_ExchangeRates { get; set; }
        public virtual DbSet<tbl_ExchangeReasons> tbl_ExchangeReasons { get; set; }
        public virtual DbSet<tbl_Exchanges> tbl_Exchanges { get; set; }
        public virtual DbSet<tbl_Files> tbl_Files { get; set; }
        public virtual DbSet<tbl_ImportResult> tbl_ImportResult { get; set; }
        public virtual DbSet<tbl_Introduction> tbl_Introduction { get; set; }
        public virtual DbSet<tbl_IntroductionDetail> tbl_IntroductionDetail { get; set; }
        public virtual DbSet<tbl_LabourCosts> tbl_LabourCosts { get; set; }
        public virtual DbSet<tbl_Maplocations> tbl_Maplocations { get; set; }
        public virtual DbSet<tbl_Model> tbl_Model { get; set; }
        public virtual DbSet<tbl_ModelUsed> tbl_ModelUsed { get; set; }
        public virtual DbSet<tbl_NotFoundSerial> tbl_NotFoundSerial { get; set; }
        public virtual DbSet<tbl_OptionSets> tbl_OptionSets { get; set; }
        public virtual DbSet<tbl_OrderItems> tbl_OrderItems { get; set; }
        public virtual DbSet<tbl_OrderTransaction> tbl_OrderTransaction { get; set; }
        public virtual DbSet<tbl_PageNews> tbl_PageNews { get; set; }
        public virtual DbSet<tbl_PartInTransaction> tbl_PartInTransaction { get; set; }
        public virtual DbSet<tbl_PartReplace> tbl_PartReplace { get; set; }
        public virtual DbSet<tbl_Parts> tbl_Parts { get; set; }
        public virtual DbSet<tbl_PartsInModel> tbl_PartsInModel { get; set; }
        public virtual DbSet<tbl_PartsInOrder> tbl_PartsInOrder { get; set; }
        public virtual DbSet<tbl_PartsInStock> tbl_PartsInStock { get; set; }
        public virtual DbSet<tbl_PositionDefect> tbl_PositionDefect { get; set; }
        public virtual DbSet<tbl_Prices> tbl_Prices { get; set; }
        public virtual DbSet<tbl_ProcessingTime> tbl_ProcessingTime { get; set; }
        public virtual DbSet<tbl_Provinces> tbl_Provinces { get; set; }
        public virtual DbSet<tbl_Reimburses> tbl_Reimburses { get; set; }
        public virtual DbSet<tbl_RepairCodes> tbl_RepairCodes { get; set; }
        public virtual DbSet<tbl_Reports> tbl_Reports { get; set; }
        public virtual DbSet<tbl_ReportsAssign> tbl_ReportsAssign { get; set; }
        public virtual DbSet<tbl_Roles> tbl_Roles { get; set; }
        public virtual DbSet<tbl_SafetyStock> tbl_SafetyStock { get; set; }
        public virtual DbSet<tbl_Serial> tbl_Serial { get; set; }
        public virtual DbSet<tbl_SerialActivate> tbl_SerialActivate { get; set; }
        public virtual DbSet<tbl_SerialLog> tbl_SerialLog { get; set; }
        public virtual DbSet<tbl_SerialNo> tbl_SerialNo { get; set; }
        public virtual DbSet<tbl_ServiceCenters> tbl_ServiceCenters { get; set; }
        public virtual DbSet<tbl_ShippingCompany> tbl_ShippingCompany { get; set; }
        public virtual DbSet<tbl_SI> tbl_SI { get; set; }
        public virtual DbSet<tbl_SimilarParts> tbl_SimilarParts { get; set; }
        public virtual DbSet<tbl_SMS> tbl_SMS { get; set; }
        public virtual DbSet<tbl_SMSTemplate> tbl_SMSTemplate { get; set; }
        public virtual DbSet<tbl_Stocks> tbl_Stocks { get; set; }
        public virtual DbSet<tbl_Suppliers> tbl_Suppliers { get; set; }
        public virtual DbSet<tbl_SystemQueryBases> tbl_SystemQueryBases { get; set; }
        public virtual DbSet<tbl_TechnicalStaffs> tbl_TechnicalStaffs { get; set; }
        public virtual DbSet<tbl_TicketProblems> tbl_TicketProblems { get; set; }
        public virtual DbSet<tbl_Transaction> tbl_Transaction { get; set; }
        public virtual DbSet<tbl_UserRoles> tbl_UserRoles { get; set; }
        public virtual DbSet<tbl_Users> tbl_Users { get; set; }
        public virtual DbSet<tbl_Wards> tbl_Wards { get; set; }
        public virtual DbSet<tbl_WarrantyCards> tbl_WarrantyCards { get; set; }
        public virtual DbSet<tbl_WarrantyPolicy> tbl_WarrantyPolicy { get; set; }
        public virtual DbSet<Query> Queries { get; set; }
        public virtual DbSet<tbl_AutoNumbers> tbl_AutoNumbers { get; set; }
        public virtual DbSet<tbl_OptionSetValues> tbl_OptionSetValues { get; set; }
        public virtual DbSet<tbl_SystemPermissions> tbl_SystemPermissions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tbl_Cases>()
                .Property(e => e.CaseCode)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_CasesBackup>()
                .Property(e => e.CaseCode)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Conditions>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Countries>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Currencies>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Customers>()
                .Property(e => e.Ext)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_DefectCodes>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_ExchangeReasons>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_OrderItems>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_PositionDefect>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_RepairCodes>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_ServiceCenters>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_TechnicalStaffs>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_TechnicalStaffs>()
                .Property(e => e.Ext)
                .IsUnicode(false);

            modelBuilder.Entity<Query>()
                .Property(e => e.CaseCode)
                .IsUnicode(false);

            modelBuilder.Entity<Query>()
                .Property(e => e.BoughtDate)
                .HasPrecision(3);

            modelBuilder.Entity<Query>()
                .Property(e => e.EndDate)
                .HasPrecision(3);

            modelBuilder.Entity<Query>()
                .Property(e => e.MadeDate)
                .HasPrecision(3);

            modelBuilder.Entity<Query>()
                .Property(e => e.ReceivedDate)
                .HasPrecision(3);

            modelBuilder.Entity<Query>()
                .Property(e => e.ScheduleStart)
                .HasPrecision(3);

            modelBuilder.Entity<Query>()
                .Property(e => e.ScheduleEnd)
                .HasPrecision(3);

            modelBuilder.Entity<Query>()
                .Property(e => e.StartDate)
                .HasPrecision(3);

            modelBuilder.Entity<Query>()
                .Property(e => e.CompleteDate)
                .HasPrecision(3);

            modelBuilder.Entity<Query>()
                .Property(e => e.ApprovalDate)
                .HasPrecision(3);

            modelBuilder.Entity<Query>()
                .Property(e => e.CreatedOn)
                .HasPrecision(3);

            modelBuilder.Entity<Query>()
                .Property(e => e.ModifiedOn)
                .HasPrecision(3);

            modelBuilder.Entity<Query>()
                .Property(e => e.CompletedSVNOn)
                .HasPrecision(3);

            modelBuilder.Entity<Query>()
                .Property(e => e.TechnicalCheckedOn)
                .HasPrecision(3);

            modelBuilder.Entity<Query>()
                .Property(e => e.CompletedASCOn)
                .HasPrecision(3);
        }
    }
}

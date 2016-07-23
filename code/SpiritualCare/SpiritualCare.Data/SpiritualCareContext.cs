using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpiritualCare.Data
{
    public class SpiritualCareContext:DbContext
    {
        public SpiritualCareContext():base("SpiritualCareDB")
        { }
        #region tables
        #region Activity
        #region CareContact
        public DbSet<SpiritualCare.Model.Activity.CareContact.A_CC_CareContact> A_CC_CareContacts { get; set; }
        public DbSet<SpiritualCare.Model.Activity.CareContact.A_CC_CareContactPerson> A_CC_CareContactPersons { get; set; }
        public DbSet<SpiritualCare.Model.Activity.CareContact.A_CC_CareContactServant> A_CC_CareContactServants { get; set; }
        #endregion
        #endregion
        #region Lookup
        public DbSet<SpiritualCare.Model.Lookup.L_Address> L_AddressTypes { get; set; }
        public DbSet<SpiritualCare.Model.Lookup.L_Church> L_Churches { get; set; }
        public DbSet<SpiritualCare.Model.Lookup.L_ChurchService> L_ChurchServices { get; set; }
        public DbSet<SpiritualCare.Model.Lookup.L_City> L_Cities { get; set; }
        public DbSet<SpiritualCare.Model.Lookup.L_ContactMean> L_ContactMeans { get; set; }
        public DbSet<SpiritualCare.Model.Lookup.L_ContactSort> L_ContactSorts { get; set; }
        public DbSet<SpiritualCare.Model.Lookup.L_Country> L_Countries { get; set; }
        public DbSet<SpiritualCare.Model.Lookup.L_Diocese> L_Dioceses { get; set; }
        public DbSet<SpiritualCare.Model.Lookup.L_Education> L_EducationKinds { get; set; }
        public DbSet<SpiritualCare.Model.Lookup.L_FamilyRole> L_FamilyRoles { get; set; }
        public DbSet<SpiritualCare.Model.Lookup.L_Father> L_Fathers { get; set; }
        public DbSet<SpiritualCare.Model.Lookup.L_Job> L_Jobs { get; set; }
        public DbSet<SpiritualCare.Model.Lookup.L_Meeting> L_Meetings { get; set; }
        public DbSet<SpiritualCare.Model.Lookup.L_Profession> L_Professions { get; set; }
        public DbSet<SpiritualCare.Model.Lookup.L_SocialStatus> L_SocialStatuses { get; set; }
        public DbSet<SpiritualCare.Model.Lookup.L_Street> L_Streets { get; set; }
        public DbSet<SpiritualCare.Model.Lookup.L_TaskStatus> L_TaskStatuses { get; set; }
        #endregion
        #region Person
        public DbSet<SpiritualCare.Model.Person.P_Address> P_Addresses { get; set; }
        public DbSet<SpiritualCare.Model.Person.P_ContactWay1> P_ContactWay1 { get; set; }
        public DbSet<SpiritualCare.Model.Person.P_ContactWay2> P_ContactWay2 { get; set; }
        public DbSet<SpiritualCare.Model.Person.P_ContactWay3> P_ContactWay3 { get; set; }
        public DbSet<SpiritualCare.Model.Person.P_Education> P_Educations { get; set; }
        public DbSet<SpiritualCare.Model.Person.P_Email> P_Emails { get; set; }
        public DbSet<SpiritualCare.Model.Person.P_Facebook> P_Facebooks { get; set; }
        public DbSet<SpiritualCare.Model.Person.P_Job> P_Jobs { get; set; }
        public DbSet<SpiritualCare.Model.Person.P_Person> P_Persons { get; set; }
        public DbSet<SpiritualCare.Model.Person.P_Person_Actual_Meeting> P_Person_Actual_Meetings { get; set; }
        public DbSet<SpiritualCare.Model.Person.P_Person_Address> P_Person_Addresses { get; set; }
        public DbSet<SpiritualCare.Model.Person.P_Person_Education> P_Person_Educations { get; set; }
        public DbSet<SpiritualCare.Model.Person.P_Person_Expected_Meeting> P_Person_Expected_Meetings { get; set; }
        public DbSet<SpiritualCare.Model.Person.P_Person_Job> P_Person_Jobs { get; set; }
        public DbSet<SpiritualCare.Model.Person.P_Person_Person> P_Person_Persons { get; set; }
        public DbSet<SpiritualCare.Model.Person.P_Phone> P_Phones { get; set; }
        public DbSet<SpiritualCare.Model.Person.P_Viber> P_Vibers { get; set; }
        public DbSet<SpiritualCare.Model.Person.P_WhatsApp> P_WhatsApps { get; set; }
        #endregion
        #region Task
        public DbSet<SpiritualCare.Model.Task.T_Task> T_Tasks { get; set; }
        public DbSet<SpiritualCare.Model.Task.T_TaskDefinition> T_TaskDefinitions { get; set; }
        public DbSet<SpiritualCare.Model.Task.T_TaskPerson> T_TaskPersons { get; set; }
        public DbSet<SpiritualCare.Model.Task.T_TaskServant> T_TaskServants { get; set; }
        #endregion
        #endregion

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SpiritualCare.Model.Person.P_Address>().Property(a => a.GPS_Lat).HasPrecision(9, 6);
            modelBuilder.Entity<SpiritualCare.Model.Person.P_Address>().Property(a => a.GPS_Long).HasPrecision(9, 6);
        }
    }
}

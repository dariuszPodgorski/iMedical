using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace iMedicalApi.Models
{
    public partial class iMedical_angContext : DbContext
    {
        public iMedical_angContext()
        {
        }

        public iMedical_angContext(DbContextOptions<iMedical_angContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Administration> Administrations { get; set; }
        public virtual DbSet<BillingTenure> BillingTenures { get; set; }
        public virtual DbSet<Contract> Contracts { get; set; }
        public virtual DbSet<ContractType> ContractTypes { get; set; }
        public virtual DbSet<Doctor> Doctors { get; set; }
        public virtual DbSet<DoctorSpecialization> DoctorSpecializations { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<JobType> JobTypes { get; set; }
        public virtual DbSet<Login> Logins { get; set; }
        public virtual DbSet<MedicBranchType> MedicBranchTypes { get; set; }
        public virtual DbSet<MedicalExamination> MedicalExaminations { get; set; }
        public virtual DbSet<MedicalExaminationType> MedicalExaminationTypes { get; set; }
        public virtual DbSet<MedicalFacility> MedicalFacilities { get; set; }
        public virtual DbSet<Paramedical> Paramedicals { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<PaymentDetail> PaymentDetails { get; set; }
        public virtual DbSet<Prescription> Prescriptions { get; set; }
        public virtual DbSet<PriceList> PriceLists { get; set; }
        public virtual DbSet<Referral> Referrals { get; set; }
        public virtual DbSet<Specialization> Specializations { get; set; }
        public virtual DbSet<Tenure> Tenures { get; set; }
        public virtual DbSet<TenureType> TenureTypes { get; set; }
        public virtual DbSet<TitleType> TitleTypes { get; set; }
        public virtual DbSet<Visit> Visits { get; set; }
        public virtual DbSet<VisitType> VisitTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-0DVVGHT\\SQLExpress;Database=iMedical_ang;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Polish_CI_AS");

            modelBuilder.Entity<Administration>(entity =>
            {
                entity.HasKey(e => e.IdAdministration)
                    .HasName("PK_ADMINISTRATION");

                entity.ToTable("Administration");

                entity.Property(e => e.IdAdministration).HasColumnName("ID_Administration");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(3);
            });

            modelBuilder.Entity<BillingTenure>(entity =>
            {
                entity.HasKey(e => e.IdBillingTenure)
                    .HasName("PK_BILLING_TENURE");

                entity.ToTable("Billing_tenure");

                entity.HasIndex(e => e.IdEmployee, "Relationship_15_FK");

                entity.HasIndex(e => e.IdTenure, "Relationship_16_FK");

                entity.Property(e => e.IdBillingTenure).HasColumnName("ID_Billing_tenure");

                entity.Property(e => e.Comments).HasMaxLength(256);

                entity.Property(e => e.DateFrom)
                    .HasColumnType("datetime")
                    .HasColumnName("Date_from");

                entity.Property(e => e.DateTo)
                    .HasColumnType("datetime")
                    .HasColumnName("Date_to");

                entity.Property(e => e.Description).HasMaxLength(512);

                entity.Property(e => e.HoursExtraNumber).HasColumnName("hours_extra_number");

                entity.Property(e => e.HoursNumber).HasColumnName("Hours_number");

                entity.Property(e => e.IdEmployee).HasColumnName("ID_Employee");

                entity.Property(e => e.IdTenure).HasColumnName("ID_Tenure");

                entity.Property(e => e.InsertionDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Insertion_date");

                entity.Property(e => e.TreatmentsPaid).HasColumnName("treatments_paid");

                entity.Property(e => e.TreatmentsReimbursed).HasColumnName("treatments_reimbursed");

                entity.Property(e => e.VisitsPaid).HasColumnName("visits_paid");

                entity.Property(e => e.VisitsReimbursed).HasColumnName("visits_reimbursed");

                entity.HasOne(d => d.IdEmployeeNavigation)
                    .WithMany(p => p.BillingTenures)
                    .HasForeignKey(d => d.IdEmployee)
                    .HasConstraintName("FK_BILLING__RELATIONS_EMPLOYEE");

                entity.HasOne(d => d.IdTenureNavigation)
                    .WithMany(p => p.BillingTenures)
                    .HasForeignKey(d => d.IdTenure)
                    .HasConstraintName("FK_BILLING__RELATIONS_TENURE");
            });

            modelBuilder.Entity<Contract>(entity =>
            {
                entity.HasKey(e => e.IdContract)
                    .HasName("PK_CONTRACT");

                entity.ToTable("Contract");

                entity.HasIndex(e => e.IdMedicalFacility, "Relationship_10_FK");

                entity.HasIndex(e => e.IdMedicalBranchType, "Relationship_28_FK");

                entity.HasIndex(e => e.IdTenure, "Relationship_8_FK");

                entity.HasIndex(e => e.IdContractType, "Relationship_9_FK");

                entity.Property(e => e.IdContract).HasColumnName("ID_Contract");

                entity.Property(e => e.Comments).HasMaxLength(256);

                entity.Property(e => e.CompletionDate).HasColumnType("datetime");

                entity.Property(e => e.ConclusionDate).HasColumnType("datetime");

                entity.Property(e => e.IdContractType).HasColumnName("ID_Contract_Type");

                entity.Property(e => e.IdMedicalBranchType).HasColumnName("ID_Medical_Branch_Type");

                entity.Property(e => e.IdMedicalFacility).HasColumnName("ID_Medical_Facility");

                entity.Property(e => e.IdTenure).HasColumnName("ID_Tenure");

                entity.Property(e => e.NumberAccount)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.HasOne(d => d.IdContractTypeNavigation)
                    .WithMany(p => p.Contracts)
                    .HasForeignKey(d => d.IdContractType)
                    .HasConstraintName("FK_CONTRACT_RELATIONS_CONTRACT");

                entity.HasOne(d => d.IdMedicalBranchTypeNavigation)
                    .WithMany(p => p.Contracts)
                    .HasForeignKey(d => d.IdMedicalBranchType)
                    .HasConstraintName("FK_CONTRACT_RELATIONS_MEDIC_BR");

                entity.HasOne(d => d.IdMedicalFacilityNavigation)
                    .WithMany(p => p.Contracts)
                    .HasForeignKey(d => d.IdMedicalFacility)
                    .HasConstraintName("FK_CONTRACT_RELATIONS_MEDICAL_");

                entity.HasOne(d => d.IdTenureNavigation)
                    .WithMany(p => p.Contracts)
                    .HasForeignKey(d => d.IdTenure)
                    .HasConstraintName("FK_CONTRACT_RELATIONS_TENURE");
            });

            modelBuilder.Entity<ContractType>(entity =>
            {
                entity.HasKey(e => e.IdContractType)
                    .HasName("PK_CONTRACT_TYPE");

                entity.ToTable("Contract_Type");

                entity.Property(e => e.IdContractType).HasColumnName("ID_Contract_Type");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(64);
            });

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.HasKey(e => e.IdDoctor)
                    .HasName("PK_DOCTOR");

                entity.ToTable("Doctor");

                entity.HasIndex(e => e.IdTytleType, "Relationship_13_FK");

                entity.Property(e => e.IdDoctor).HasColumnName("ID_Doctor");

                entity.Property(e => e.CertificateNumber)
                    .IsRequired()
                    .HasMaxLength(32);

                entity.Property(e => e.Email).HasMaxLength(128);

                entity.Property(e => e.IdTytleType).HasColumnName("ID_Tytle_type");

                entity.Property(e => e.Phone).HasMaxLength(16);

                entity.Property(e => e.Pwz)
                    .IsRequired()
                    .HasMaxLength(12)
                    .HasColumnName("PWZ");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(3);

                entity.HasOne(d => d.IdTytleTypeNavigation)
                    .WithMany(p => p.Doctors)
                    .HasForeignKey(d => d.IdTytleType)
                    .HasConstraintName("FK_DOCTOR_RELATIONS_TITLE_TY");
            });

            modelBuilder.Entity<DoctorSpecialization>(entity =>
            {
                entity.HasKey(e => new { e.IdDoctor, e.IdSpecialization, e.IdDoctorSpecialization })
                    .HasName("PK_DOCTORSPECIALIZATION");

                entity.ToTable("DoctorSpecialization");

                entity.HasIndex(e => e.IdDoctor, "Relationship_11_FK");

                entity.HasIndex(e => e.IdSpecialization, "Relationship_12_FK");

                entity.Property(e => e.IdDoctor)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID_Doctor");

                entity.Property(e => e.IdSpecialization).HasColumnName("ID_Specialization");

                entity.Property(e => e.IdDoctorSpecialization).HasColumnName("ID_DoctorSpecialization");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.HasOne(d => d.IdDoctorNavigation)
                    .WithMany(p => p.DoctorSpecializations)
                    .HasForeignKey(d => d.IdDoctor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DOCTORSP_RELATIONS_DOCTOR");

                entity.HasOne(d => d.IdSpecializationNavigation)
                    .WithMany(p => p.DoctorSpecializations)
                    .HasForeignKey(d => d.IdSpecialization)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DOCTORSP_RELATIONS_SPECIALI");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.IdEmployee)
                    .HasName("PK_EMPLOYEE");

                entity.ToTable("Employee");

                entity.Property(e => e.IdEmployee).HasColumnName("ID_Employee");

                entity.Property(e => e.BuildingNumberResidence)
                    .IsRequired()
                    .HasMaxLength(11);

                entity.Property(e => e.CityResidence)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.Property(e => e.CountryResidence)
                    .IsRequired()
                    .HasMaxLength(32);

                entity.Property(e => e.DateOfBirth).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(128);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(32);

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(1);

                entity.Property(e => e.HousingNumberResidence).HasMaxLength(11);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.Property(e => e.MiddleName).HasMaxLength(32);

                entity.Property(e => e.Pesel)
                    .IsRequired()
                    .HasMaxLength(16)
                    .HasColumnName("PESEL");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.PostalCodeResidence)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.StreetResidence)
                    .IsRequired()
                    .HasMaxLength(64);
            });

            modelBuilder.Entity<JobType>(entity =>
            {
                entity.HasKey(e => e.IdJobType)
                    .HasName("PK_JOB_TYPE");

                entity.ToTable("Job_Type");

                entity.Property(e => e.IdJobType).HasColumnName("ID_Job_Type");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(64);
            });

            modelBuilder.Entity<Login>(entity =>
            {
                entity.HasKey(e => e.IdLogin)
                    .HasName("PK_LOGIN");

                entity.ToTable("Login");

                entity.HasIndex(e => e.IdEmployee, "Relationship_1_FK");

                entity.HasIndex(e => e.IdPatient, "Relationship_2_FK");

                entity.Property(e => e.IdLogin).HasColumnName("ID_Login");

                entity.Property(e => e.IdEmployee).HasColumnName("ID_Employee");

                entity.Property(e => e.IdPatient).HasColumnName("ID_Patient");

                entity.Property(e => e.Login1)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Login");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(512);

                entity.HasOne(d => d.IdEmployeeNavigation)
                    .WithMany(p => p.Logins)
                    .HasForeignKey(d => d.IdEmployee)
                    .HasConstraintName("FK_LOGIN_RELATIONS_EMPLOYEE");

                entity.HasOne(d => d.IdPatientNavigation)
                    .WithMany(p => p.Logins)
                    .HasForeignKey(d => d.IdPatient)
                    .HasConstraintName("FK_LOGIN_RELATIONS_PATIENT");
            });

            modelBuilder.Entity<MedicBranchType>(entity =>
            {
                entity.HasKey(e => e.IdMedicalBranchType)
                    .HasName("PK_MEDIC_BRANCH_TYPE");

                entity.ToTable("Medic_Branch_Type");

                entity.Property(e => e.IdMedicalBranchType).HasColumnName("ID_Medical_Branch_Type");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MedicalExamination>(entity =>
            {
                entity.HasKey(e => e.IdMedicalExamination)
                    .HasName("PK_MEDICAL_EXAMINATION");

                entity.ToTable("Medical_examination");

                entity.HasIndex(e => e.IdPriceList, "Relationship_32_FK");

                entity.HasIndex(e => e.IdMedicalExaminationType, "Relationship_33_FK");

                entity.HasIndex(e => e.IdReferral, "Relationship_34_FK");

                entity.HasIndex(e => e.IdPatient, "Relationship_35_FK");

                entity.Property(e => e.IdMedicalExamination).HasColumnName("ID_Medical_examination");

                entity.Property(e => e.DateEpiration).HasColumnType("datetime");

                entity.Property(e => e.IdMedicalExaminationType).HasColumnName("ID_medical_examination_type");

                entity.Property(e => e.IdPatient).HasColumnName("ID_Patient");

                entity.Property(e => e.IdPriceList).HasColumnName("ID_Price_list");

                entity.Property(e => e.IdReferral).HasColumnName("ID_Referral");

                entity.Property(e => e.IssueDate).HasColumnType("datetime");

                entity.Property(e => e.NumberReferral)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.HasOne(d => d.IdMedicalExaminationTypeNavigation)
                    .WithMany(p => p.MedicalExaminations)
                    .HasForeignKey(d => d.IdMedicalExaminationType)
                    .HasConstraintName("FK_MEDICAL__RELATIONS_MEDICAL_");

                entity.HasOne(d => d.IdPatientNavigation)
                    .WithMany(p => p.MedicalExaminations)
                    .HasForeignKey(d => d.IdPatient)
                    .HasConstraintName("FK_MEDICAL__RELATIONS_PATIENT");

                entity.HasOne(d => d.IdPriceListNavigation)
                    .WithMany(p => p.MedicalExaminations)
                    .HasForeignKey(d => d.IdPriceList)
                    .HasConstraintName("FK_MEDICAL__RELATIONS_PRICE_LI");

                entity.HasOne(d => d.IdReferralNavigation)
                    .WithMany(p => p.MedicalExaminations)
                    .HasForeignKey(d => d.IdReferral)
                    .HasConstraintName("FK_MEDICAL__RELATIONS_REFERRAL");
            });

            modelBuilder.Entity<MedicalExaminationType>(entity =>
            {
                entity.HasKey(e => e.IdMedicalExaminationType)
                    .HasName("PK_MEDICAL_EXAMINATION_TYPE");

                entity.ToTable("Medical_examination_type");

                entity.Property(e => e.IdMedicalExaminationType).HasColumnName("ID_medical_examination_type");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(64);
            });

            modelBuilder.Entity<MedicalFacility>(entity =>
            {
                entity.HasKey(e => e.IdMedicalFacility)
                    .HasName("PK_MEDICAL_FACILITY");

                entity.ToTable("Medical_Facility");

                entity.HasIndex(e => e.IdMedicalBranchType, "Relationship_36_FK");

                entity.Property(e => e.IdMedicalFacility).HasColumnName("ID_Medical_Facility");

                entity.Property(e => e.BuildingNumber)
                    .IsRequired()
                    .HasMaxLength(11);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.Property(e => e.HouseNumber).HasMaxLength(11);

                entity.Property(e => e.IdMedicalBranchType).HasColumnName("ID_Medical_Branch_Type");

                entity.Property(e => e.LongName)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("Long_name");

                entity.Property(e => e.Nip)
                    .IsRequired()
                    .HasMaxLength(16)
                    .HasColumnName("NIP");

                entity.Property(e => e.PostCode)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.ShortName)
                    .HasMaxLength(64)
                    .HasColumnName("Short_name");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(3);

                entity.Property(e => e.Street)
                    .IsRequired()
                    .HasMaxLength(32);

                entity.HasOne(d => d.IdMedicalBranchTypeNavigation)
                    .WithMany(p => p.MedicalFacilities)
                    .HasForeignKey(d => d.IdMedicalBranchType)
                    .HasConstraintName("FK_MEDICAL__RELATIONS_MEDIC_BR");
            });

            modelBuilder.Entity<Paramedical>(entity =>
            {
                entity.HasKey(e => e.IdParamedical)
                    .HasName("PK_PARAMEDICAL");

                entity.ToTable("Paramedical");

                entity.HasIndex(e => e.IdTytleType, "Relationship_14_FK");

                entity.Property(e => e.IdParamedical).HasColumnName("ID_Paramedical");

                entity.Property(e => e.CerificateNumber)
                    .IsRequired()
                    .HasMaxLength(32);

                entity.Property(e => e.IdTytleType).HasColumnName("ID_Tytle_type");

                entity.Property(e => e.Pwz)
                    .IsRequired()
                    .HasMaxLength(12)
                    .HasColumnName("PWZ");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(3);

                entity.HasOne(d => d.IdTytleTypeNavigation)
                    .WithMany(p => p.Paramedicals)
                    .HasForeignKey(d => d.IdTytleType)
                    .HasConstraintName("FK_PARAMEDI_RELATIONS_TITLE_TY");
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.HasKey(e => e.IdPatient)
                    .HasName("PK_PATIENT");

                entity.ToTable("Patient");

                entity.Property(e => e.IdPatient).HasColumnName("ID_Patient");

                entity.Property(e => e.BuildingNumberRegistration)
                    .IsRequired()
                    .HasMaxLength(11);

                entity.Property(e => e.BuildingNumberResidence).HasMaxLength(11);

                entity.Property(e => e.CityRegistration)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.Property(e => e.CityResidence).HasMaxLength(64);

                entity.Property(e => e.CountryRegistration)
                    .IsRequired()
                    .HasMaxLength(32);

                entity.Property(e => e.CountryResidence).HasMaxLength(32);

                entity.Property(e => e.DateOfBirth).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(128);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(32);

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(1);

                entity.Property(e => e.HouseNumberResidence).HasMaxLength(11);

                entity.Property(e => e.HousingNumberRegistration).HasMaxLength(11);

                entity.Property(e => e.InsuranceNumber).HasMaxLength(15);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.Property(e => e.MiddleName).HasMaxLength(32);

                entity.Property(e => e.Pesel)
                    .IsRequired()
                    .HasMaxLength(16)
                    .HasColumnName("PESEL");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(16);

                entity.Property(e => e.PostalCodeRegistration)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.PostalCodeResidence).HasMaxLength(6);

                entity.Property(e => e.StreetRegistration)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.StreetResidence).HasMaxLength(128);
            });

            modelBuilder.Entity<PaymentDetail>(entity =>
            {
                entity.HasKey(e => e.IdPaymentDetails)
                    .HasName("PK_PAYMENT_DETAILS");

                entity.ToTable("Payment_Details");

                entity.HasIndex(e => e.IdEmployee, "Relationship_17_FK");

                entity.HasIndex(e => e.IdTenure, "Relationship_18_FK");

                entity.HasIndex(e => e.IdBillingTenure, "Relationship_19_FK");

                entity.HasIndex(e => e.IdContract, "Relationship_20_FK");

                entity.Property(e => e.IdPaymentDetails).HasColumnName("ID_Payment_Details");

                entity.Property(e => e.Comments).HasMaxLength(256);

                entity.Property(e => e.IdBillingTenure).HasColumnName("ID_Billing_tenure");

                entity.Property(e => e.IdContract).HasColumnName("ID_Contract");

                entity.Property(e => e.IdEmployee).HasColumnName("ID_Employee");

                entity.Property(e => e.IdTenure).HasColumnName("ID_Tenure");

                entity.Property(e => e.PaymentDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Payment_date");

                entity.Property(e => e.PaymentDueDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Payment_due_date");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.HasOne(d => d.IdBillingTenureNavigation)
                    .WithMany(p => p.PaymentDetails)
                    .HasForeignKey(d => d.IdBillingTenure)
                    .HasConstraintName("FK_PAYMENT__RELATIONS_BILLING_");

                entity.HasOne(d => d.IdContractNavigation)
                    .WithMany(p => p.PaymentDetails)
                    .HasForeignKey(d => d.IdContract)
                    .HasConstraintName("FK_PAYMENT__RELATIONS_CONTRACT");

                entity.HasOne(d => d.IdEmployeeNavigation)
                    .WithMany(p => p.PaymentDetails)
                    .HasForeignKey(d => d.IdEmployee)
                    .HasConstraintName("FK_PAYMENT__RELATIONS_EMPLOYEE");

                entity.HasOne(d => d.IdTenureNavigation)
                    .WithMany(p => p.PaymentDetails)
                    .HasForeignKey(d => d.IdTenure)
                    .HasConstraintName("FK_PAYMENT__RELATIONS_TENURE");
            });

            modelBuilder.Entity<Prescription>(entity =>
            {
                entity.HasKey(e => e.IdPrescription)
                    .HasName("PK_PRESCRIPTION");

                entity.ToTable("Prescription");

                entity.Property(e => e.IdPrescription).HasColumnName("ID_Prescription");

                entity.Property(e => e.DateExpiration).HasColumnType("datetime");

                entity.Property(e => e.IssueDate).HasColumnType("datetime");

                entity.Property(e => e.Medication1)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("Medication_1");

                entity.Property(e => e.Medication2)
                    .HasMaxLength(64)
                    .HasColumnName("Medication_2");

                entity.Property(e => e.Medication3)
                    .HasMaxLength(64)
                    .HasColumnName("Medication_3");

                entity.Property(e => e.Medication4)
                    .HasMaxLength(64)
                    .HasColumnName("Medication_4");

                entity.Property(e => e.Medication5)
                    .HasMaxLength(64)
                    .HasColumnName("Medication_5");

                entity.Property(e => e.Medication6)
                    .HasMaxLength(64)
                    .HasColumnName("Medication_6");

                entity.Property(e => e.Medication7)
                    .HasMaxLength(64)
                    .HasColumnName("Medication_7");

                entity.Property(e => e.NumberPrescription)
                    .IsRequired()
                    .HasMaxLength(15);
            });

            modelBuilder.Entity<PriceList>(entity =>
            {
                entity.HasKey(e => e.IdPriceList)
                    .HasName("PK_PRICE_LIST");

                entity.ToTable("Price_list");

                entity.Property(e => e.IdPriceList).HasColumnName("ID_Price_list");

                entity.Property(e => e.Description).HasMaxLength(256);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(64);
            });

            modelBuilder.Entity<Referral>(entity =>
            {
                entity.HasKey(e => e.IdReferral)
                    .HasName("PK_REFERRAL");

                entity.ToTable("Referral");

                entity.HasIndex(e => e.IdMedicalExaminationType, "Relationship_29_FK");

                entity.HasIndex(e => e.IdDoctor, "Relationship_30_FK");

                entity.HasIndex(e => e.IdPatient, "Relationship_31_FK");

                entity.Property(e => e.IdReferral).HasColumnName("ID_Referral");

                entity.Property(e => e.ExpirationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Expiration_Date");

                entity.Property(e => e.IdDoctor).HasColumnName("ID_Doctor");

                entity.Property(e => e.IdMedicalExaminationType).HasColumnName("ID_medical_examination_type");

                entity.Property(e => e.IdPatient).HasColumnName("ID_Patient");

                entity.Property(e => e.IssueDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Issue_Date");

                entity.Property(e => e.ReferralNumber)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("Referral_number");

                entity.HasOne(d => d.IdDoctorNavigation)
                    .WithMany(p => p.Referrals)
                    .HasForeignKey(d => d.IdDoctor)
                    .HasConstraintName("FK_REFERRAL_RELATIONS_DOCTOR");

                entity.HasOne(d => d.IdMedicalExaminationTypeNavigation)
                    .WithMany(p => p.Referrals)
                    .HasForeignKey(d => d.IdMedicalExaminationType)
                    .HasConstraintName("FK_REFERRAL_RELATIONS_MEDICAL_");

                entity.HasOne(d => d.IdPatientNavigation)
                    .WithMany(p => p.Referrals)
                    .HasForeignKey(d => d.IdPatient)
                    .HasConstraintName("FK_REFERRAL_RELATIONS_PATIENT");
            });

            modelBuilder.Entity<Specialization>(entity =>
            {
                entity.HasKey(e => e.IdSpecialization)
                    .HasName("PK_SPECIALIZATION");

                entity.ToTable("Specialization");

                entity.Property(e => e.IdSpecialization).HasColumnName("ID_Specialization");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(64);
            });

            modelBuilder.Entity<Tenure>(entity =>
            {
                entity.HasKey(e => e.IdTenure)
                    .HasName("PK_TENURE");

                entity.ToTable("Tenure");

                entity.HasIndex(e => e.IdTenureType, "Relationship_3_FK");

                entity.HasIndex(e => e.IdParamedical, "Relationship_4_FK");

                entity.HasIndex(e => e.IdDoctor, "Relationship_5_FK");

                entity.HasIndex(e => e.IdAdministration, "Relationship_6_FK");

                entity.HasIndex(e => e.IdEmployee, "Relationship_7_FK");

                entity.Property(e => e.IdTenure).HasColumnName("ID_Tenure");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.IdAdministration).HasColumnName("ID_Administration");

                entity.Property(e => e.IdDoctor).HasColumnName("ID_Doctor");

                entity.Property(e => e.IdEmployee).HasColumnName("ID_Employee");

                entity.Property(e => e.IdParamedical).HasColumnName("ID_Paramedical");

                entity.Property(e => e.IdTenureType).HasColumnName("ID_Tenure_type");

                entity.Property(e => e.Phone).HasMaxLength(16);

                entity.HasOne(d => d.IdAdministrationNavigation)
                    .WithMany(p => p.Tenures)
                    .HasForeignKey(d => d.IdAdministration)
                    .HasConstraintName("FK_TENURE_RELATIONS_ADMINIST");

                entity.HasOne(d => d.IdDoctorNavigation)
                    .WithMany(p => p.Tenures)
                    .HasForeignKey(d => d.IdDoctor)
                    .HasConstraintName("FK_TENURE_RELATIONS_DOCTOR");

                entity.HasOne(d => d.IdEmployeeNavigation)
                    .WithMany(p => p.Tenures)
                    .HasForeignKey(d => d.IdEmployee)
                    .HasConstraintName("FK_TENURE_RELATIONS_EMPLOYEE");

                entity.HasOne(d => d.IdParamedicalNavigation)
                    .WithMany(p => p.Tenures)
                    .HasForeignKey(d => d.IdParamedical)
                    .HasConstraintName("FK_TENURE_RELATIONS_PARAMEDI");

                entity.HasOne(d => d.IdTenureTypeNavigation)
                    .WithMany(p => p.Tenures)
                    .HasForeignKey(d => d.IdTenureType)
                    .HasConstraintName("FK_TENURE_RELATIONS_TENURE_T");
            });

            modelBuilder.Entity<TenureType>(entity =>
            {
                entity.HasKey(e => e.IdTenureType)
                    .HasName("PK_TENURE_TYPE");

                entity.ToTable("Tenure_type");

                entity.Property(e => e.IdTenureType).HasColumnName("ID_Tenure_type");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(64);
            });

            modelBuilder.Entity<TitleType>(entity =>
            {
                entity.HasKey(e => e.IdTytleType)
                    .HasName("PK_TITLE_TYPE");

                entity.ToTable("Title_Type");

                entity.Property(e => e.IdTytleType).HasColumnName("ID_Tytle_type");

                entity.Property(e => e.Code).HasMaxLength(128);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(128);
            });

            modelBuilder.Entity<Visit>(entity =>
            {
                entity.HasKey(e => e.IdVisit)
                    .HasName("PK_VISIT");

                entity.ToTable("Visit");

                entity.HasIndex(e => e.IdDoctor, "Relationship_22_FK");

                entity.HasIndex(e => e.IdPatient, "Relationship_23_FK");

                entity.HasIndex(e => e.IdPriceList, "Relationship_24_FK");

                entity.HasIndex(e => e.IdMedicalFacility, "Relationship_25_FK");

                entity.HasIndex(e => e.IdVisitType, "Relationship_26_FK");

                entity.HasIndex(e => e.IdPrescription, "Relationship_27_FK");

                entity.Property(e => e.IdVisit).HasColumnName("ID_Visit");

                entity.Property(e => e.ActivitiesPerformed)
                    .IsRequired()
                    .HasMaxLength(512)
                    .HasColumnName("Activities_performed");

                entity.Property(e => e.Comments).HasMaxLength(512);

                entity.Property(e => e.DateVisit)
                    .HasColumnType("datetime")
                    .HasColumnName("Date_visit");

                entity.Property(e => e.DosageOfMedication)
                    .HasMaxLength(512)
                    .HasColumnName("Dosage_of_medication");

                entity.Property(e => e.GeneralInformation)
                    .IsRequired()
                    .HasMaxLength(512)
                    .HasColumnName("General_information");

                entity.Property(e => e.IdDoctor).HasColumnName("ID_Doctor");

                entity.Property(e => e.IdMedicalFacility).HasColumnName("ID_Medical_Facility");

                entity.Property(e => e.IdPatient).HasColumnName("ID_Patient");

                entity.Property(e => e.IdPrescription).HasColumnName("ID_Prescription");

                entity.Property(e => e.IdPriceList).HasColumnName("ID_Price_list");

                entity.Property(e => e.IdVisitType).HasColumnName("ID_Visit_type");

                entity.Property(e => e.Recomendations)
                    .IsRequired()
                    .HasMaxLength(512);

                entity.Property(e => e.RegistrationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Registration_date");

                entity.HasOne(d => d.IdDoctorNavigation)
                    .WithMany(p => p.Visits)
                    .HasForeignKey(d => d.IdDoctor)
                    .HasConstraintName("FK_VISIT_RELATIONS_DOCTOR");

                entity.HasOne(d => d.IdMedicalFacilityNavigation)
                    .WithMany(p => p.Visits)
                    .HasForeignKey(d => d.IdMedicalFacility)
                    .HasConstraintName("FK_VISIT_RELATIONS_MEDICAL_");

                entity.HasOne(d => d.IdPatientNavigation)
                    .WithMany(p => p.Visits)
                    .HasForeignKey(d => d.IdPatient)
                    .HasConstraintName("FK_VISIT_RELATIONS_PATIENT");

                entity.HasOne(d => d.IdPrescriptionNavigation)
                    .WithMany(p => p.Visits)
                    .HasForeignKey(d => d.IdPrescription)
                    .HasConstraintName("FK_VISIT_RELATIONS_PRESCRIP");

                entity.HasOne(d => d.IdPriceListNavigation)
                    .WithMany(p => p.Visits)
                    .HasForeignKey(d => d.IdPriceList)
                    .HasConstraintName("FK_VISIT_RELATIONS_PRICE_LI");

                entity.HasOne(d => d.IdVisitTypeNavigation)
                    .WithMany(p => p.Visits)
                    .HasForeignKey(d => d.IdVisitType)
                    .HasConstraintName("FK_VISIT_RELATIONS_VISIT_TY");
            });

            modelBuilder.Entity<VisitType>(entity =>
            {
                entity.HasKey(e => e.IdVisitType)
                    .HasName("PK_VISIT_TYPE");

                entity.ToTable("Visit_type");

                entity.Property(e => e.IdVisitType).HasColumnName("ID_Visit_type");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(64);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

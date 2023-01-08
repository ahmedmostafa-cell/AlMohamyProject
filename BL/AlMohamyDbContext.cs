using System;
using Domains;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BL
{
    public partial class AlMohamyDbContext : IdentityDbContext<ApplicationUser>
    {
        public AlMohamyDbContext()
        {
        }

        public AlMohamyDbContext(DbContextOptions<AlMohamyDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TbAboutApp> TbAboutApps { get; set; }
        public virtual DbSet<TbApprovedOffice> TbApprovedOffices { get; set; }
        public virtual DbSet<TbCharge> TbCharges { get; set; }
        public virtual DbSet<TbComplainsAndSuggestion> TbComplainsAndSuggestions { get; set; }
        public virtual DbSet<TbConsultingEstablish> TbConsultingEstablishes { get; set; }
        public virtual DbSet<TbConsultingType> TbConsultingTypes { get; set; }
        public virtual DbSet<TbDocumentationOfContract> TbDocumentationOfContracts { get; set; }
        public virtual DbSet<TbEvaluation> TbEvaluations { get; set; }
        public virtual DbSet<TbMainConsulting> TbMainConsultings { get; set; }
        public virtual DbSet<TbNotification> TbNotifications { get; set; }
        public virtual DbSet<TbOffer> TbOffers { get; set; }
        public virtual DbSet<TbPoliciesAndPrivacy> TbPoliciesAndPrivacies { get; set; }
        public virtual DbSet<TbPromocode> TbPromocodes { get; set; }
        public virtual DbSet<TbSetting> TbSettings { get; set; }
        public virtual DbSet<TbSubMainConsulting> TbSubMainConsultings { get; set; }
        public virtual DbSet<TbTermAndCondition> TbTermAndConditions { get; set; }

      

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<TbAboutApp>(entity =>
            {
                entity.HasKey(e => e.AboutAppId);

                entity.ToTable("TbAboutApp");

                entity.Property(e => e.AboutAppId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.AboutAppDescription).HasMaxLength(200);

                entity.Property(e => e.AboutAppForWhom).HasMaxLength(200);

                entity.Property(e => e.AboutAppTitle).HasMaxLength(200);

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CurrentState).HasDefaultValueSql("((1))");

                entity.Property(e => e.Notes).HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TbApprovedOffice>(entity =>
            {
                entity.HasKey(e => e.ApprovedOfficeId);

                entity.ToTable("TbApprovedOffice");

                entity.Property(e => e.ApprovedOfficeId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.ApprovalStatus).HasMaxLength(200);

                entity.Property(e => e.ApprovedOfficeLicenseDoc).HasMaxLength(200);

                entity.Property(e => e.ApprovedOfficeLogo).HasMaxLength(200);

                entity.Property(e => e.ApprovedOfficeName).HasMaxLength(200);

                entity.Property(e => e.AreaName).HasMaxLength(200);

                entity.Property(e => e.CityName).HasMaxLength(200);

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CurrentState).HasDefaultValueSql("((1))");

                entity.Property(e => e.Notes).HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TbCharge>(entity =>
            {
                entity.HasKey(e => e.ChargeId);

                entity.ToTable("TbCharge");

                entity.Property(e => e.ChargeId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.ChargeType).HasMaxLength(200);

                entity.Property(e => e.ChargeValue).HasMaxLength(200);

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CurrentState).HasDefaultValueSql("((1))");

                entity.Property(e => e.Id).HasMaxLength(200);

                entity.Property(e => e.Notes).HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TbComplainsAndSuggestion>(entity =>
            {
                entity.HasKey(e => e.ComplaintsAndSuggestionsId);

                entity.ToTable("TbComplainsAndSuggestion");

                entity.Property(e => e.ComplaintsAndSuggestionsId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.ComplaintsAndSuggestionsText).HasMaxLength(200);

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CurrentState).HasDefaultValueSql("((1))");

                entity.Property(e => e.Email).HasMaxLength(200);

                entity.Property(e => e.Id).HasMaxLength(200);

                entity.Property(e => e.Name).HasMaxLength(200);

                entity.Property(e => e.Notes).HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TbConsultingEstablish>(entity =>
            {
                entity.HasKey(e => e.ConsultingId);

                entity.ToTable("TbConsultingEstablish");

                entity.Property(e => e.ConsultingId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.AreaName).HasMaxLength(200);

                entity.Property(e => e.CityName).HasMaxLength(200);

                entity.Property(e => e.ConsultingDateAndTime).HasMaxLength(200);

                entity.Property(e => e.ConsultingPeriod).HasMaxLength(200);

                entity.Property(e => e.ConsultingPeriodCost).HasMaxLength(200);

                entity.Property(e => e.ConsultingType).HasMaxLength(200);

                entity.Property(e => e.ConsultingTypeId).HasMaxLength(200);

                entity.Property(e => e.ConsultingVatvalue)
                    .HasMaxLength(200)
                    .HasColumnName("ConsultingVATValue");

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CurrentState).HasDefaultValueSql("((1))");

                entity.Property(e => e.DelegationRejectionCause).HasMaxLength(200);

                entity.Property(e => e.DelegationReplyBack).HasMaxLength(200);

                entity.Property(e => e.DelegationValueApproved).HasMaxLength(200);

                entity.Property(e => e.DelegationValueSentFromLawyer).HasMaxLength(200);

                entity.Property(e => e.DelegationValueSentFromUser).HasMaxLength(200);

                entity.Property(e => e.IsDelegationAsked).HasMaxLength(200);

                entity.Property(e => e.LawyerId).HasMaxLength(200);

                entity.Property(e => e.LawyerImage).HasMaxLength(200);

                entity.Property(e => e.LawyerName).HasMaxLength(200);

                entity.Property(e => e.MainConsultingId).HasMaxLength(200);

                entity.Property(e => e.MainConsultingName).HasMaxLength(200);

                entity.Property(e => e.NoOfOffers).HasMaxLength(200);

                entity.Property(e => e.Notes).HasMaxLength(200);

                entity.Property(e => e.PromocodeDiscountValue).HasMaxLength(200);

                entity.Property(e => e.RequestAudio).HasMaxLength(200);

                entity.Property(e => e.RequestDocument).HasMaxLength(200);

                entity.Property(e => e.RequestNo).HasMaxLength(200);

                entity.Property(e => e.RequestStatus).HasMaxLength(200);

                entity.Property(e => e.RequestText).HasMaxLength(200);

                entity.Property(e => e.RequestType).HasMaxLength(200);

                entity.Property(e => e.SubConsultingId).HasMaxLength(200);

                entity.Property(e => e.SubConsultingName).HasMaxLength(200);

                entity.Property(e => e.TheConsultingPaidValue).HasMaxLength(200);

                entity.Property(e => e.TheTotal).HasMaxLength(200);

                entity.Property(e => e.TimeRemainingForConsultingToStart).HasMaxLength(200);

                entity.Property(e => e.TransactionType).HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.UserEmail).HasMaxLength(200);

                entity.Property(e => e.UserFamilyName).HasMaxLength(200);

                entity.Property(e => e.UserFirstName).HasMaxLength(200);

                entity.Property(e => e.UserId).HasMaxLength(200);

                entity.Property(e => e.UserImage).HasMaxLength(200);
            });

            modelBuilder.Entity<TbConsultingType>(entity =>
            {
                entity.HasKey(e => e.ConsultingTypeId);

                entity.ToTable("TbConsultingType");

                entity.Property(e => e.ConsultingTypeId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.ConsultingTypeDescription).HasMaxLength(200);

                entity.Property(e => e.ConsultingTypeTitle).HasMaxLength(200);

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CurrentState).HasDefaultValueSql("((1))");

                entity.Property(e => e.Notes).HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TbDocumentationOfContract>(entity =>
            {
                entity.HasKey(e => e.DocumentationOfContractId);

                entity.ToTable("TbDocumentationOfContract");

                entity.Property(e => e.DocumentationOfContractId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CurrentState).HasDefaultValueSql("((1))");

                entity.Property(e => e.DocumentationOfContractCost).HasMaxLength(200);

                entity.Property(e => e.DocumentationOfContractDescription).HasMaxLength(200);

                entity.Property(e => e.DocumentationOfContractImage).HasMaxLength(200);

                entity.Property(e => e.DocumentationOfContractTilte).HasMaxLength(200);

                entity.Property(e => e.Notes).HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TbEvaluation>(entity =>
            {
                entity.HasKey(e => e.EvaluationId);

                entity.ToTable("TbEvaluation");

                entity.Property(e => e.EvaluationId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.ConsultationServiceId).HasMaxLength(200);

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CurrentState).HasDefaultValueSql("((1))");

                entity.Property(e => e.EvaluaterId).HasMaxLength(200);

                entity.Property(e => e.EvaluaterImage).HasMaxLength(200);

                entity.Property(e => e.EvaluationText).HasMaxLength(200);

                entity.Property(e => e.Notes).HasMaxLength(200);

                entity.Property(e => e.StartsNo).HasMaxLength(200);

                entity.Property(e => e.ToBeEvaluatedId).HasMaxLength(200);

                entity.Property(e => e.ToBeEvaluatedImage).HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TbMainConsulting>(entity =>
            {
                entity.HasKey(e => e.MainConsultingId);

                entity.ToTable("TbMainConsulting");

                entity.Property(e => e.MainConsultingId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Consulting30MinutesCost).HasMaxLength(200);

                entity.Property(e => e.Consulting60MinutesCost).HasMaxLength(200);

                entity.Property(e => e.Consulting90MinutesCost).HasMaxLength(200);

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CurrentState).HasDefaultValueSql("((1))");

                entity.Property(e => e.MainConsultingImage).HasMaxLength(200);

                entity.Property(e => e.MainConsultingTitle).HasMaxLength(200);

                entity.Property(e => e.Notes).HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TbNotification>(entity =>
            {
                entity.HasKey(e => e.NotificationId);

                entity.ToTable("TbNotification");

                entity.Property(e => e.NotificationId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CurrentState).HasDefaultValueSql("((1))");

                entity.Property(e => e.Notes).HasMaxLength(200);

                entity.Property(e => e.NotificationType).HasMaxLength(200);

                entity.Property(e => e.SenderId).HasMaxLength(200);

                entity.Property(e => e.SenderName).HasMaxLength(200);

                entity.Property(e => e.Text).HasMaxLength(200);

                entity.Property(e => e.ToWhomId).HasMaxLength(200);

                entity.Property(e => e.ToWhomName).HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TbOffer>(entity =>
            {
                entity.HasKey(e => e.OfferId);

                entity.ToTable("TbOffer");

                entity.Property(e => e.OfferId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.CreatedDate)
                    .HasMaxLength(10)
                    .HasDefaultValueSql("(getdate())")
                    .IsFixedLength(true);

                entity.Property(e => e.CurrentState)
                    .HasMaxLength(10)
                    .HasDefaultValueSql("((1))")
                    .IsFixedLength(true);

                entity.Property(e => e.LawyerEvalNoStarts).HasMaxLength(200);

                entity.Property(e => e.LawyerId).HasMaxLength(200);

                entity.Property(e => e.LawyerImage).HasMaxLength(200);

                entity.Property(e => e.LawyerName).HasMaxLength(200);

                entity.Property(e => e.LawyerShortDescription).HasMaxLength(200);

                entity.Property(e => e.LawyersEvalNumerical).HasMaxLength(200);

                entity.Property(e => e.LawyersExperinceYears).HasMaxLength(200);

                entity.Property(e => e.Notes)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.OfferEndDate).HasMaxLength(200);

                entity.Property(e => e.OfferStatus).HasMaxLength(200);

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.UpdatedDate)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.UserId).HasMaxLength(200);

                entity.Property(e => e.UserName).HasMaxLength(200);
            });

            modelBuilder.Entity<TbPoliciesAndPrivacy>(entity =>
            {
                entity.HasKey(e => e.PoliciesAndPrivacyId);

                entity.ToTable("TbPoliciesAndPrivacy");

                entity.Property(e => e.PoliciesAndPrivacyId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CurrentState).HasDefaultValueSql("((1))");

                entity.Property(e => e.Notes).HasMaxLength(200);

                entity.Property(e => e.PoliciesAndPrivacyDescription).HasMaxLength(200);

                entity.Property(e => e.PoliciesAndPrivacyForWhom).HasMaxLength(200);

                entity.Property(e => e.PoliciesAndPrivacyTitle).HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TbPromocode>(entity =>
            {
                entity.HasKey(e => e.PromocodeId);

                entity.ToTable("TbPromocode");

                entity.Property(e => e.PromocodeId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CurrentState).HasDefaultValueSql("((1))");

                entity.Property(e => e.Notes).HasMaxLength(200);

                entity.Property(e => e.PromocodeDiscountPercent).HasMaxLength(200);

                entity.Property(e => e.PromocodeTitle).HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TbSetting>(entity =>
            {
                entity.HasKey(e => e.SettingId);

                entity.ToTable("TbSetting");

                entity.Property(e => e.SettingId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.AppProfitPercent).HasMaxLength(200);

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CurrentState).HasDefaultValueSql("((1))");

                entity.Property(e => e.Notes).HasMaxLength(200);

                entity.Property(e => e.OffersValidityDays).HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.ValueAddedTax).HasMaxLength(200);
            });

            modelBuilder.Entity<TbSubMainConsulting>(entity =>
            {
                entity.HasKey(e => e.SubMainConsultingId);

                entity.ToTable("TbSubMainConsulting");

                entity.Property(e => e.SubMainConsultingId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CurrentState).HasDefaultValueSql("((1))");

                entity.Property(e => e.Notes).HasMaxLength(200);

                entity.Property(e => e.SubMainConsulting)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.SubMainConsultingDescription).HasMaxLength(200);

                entity.Property(e => e.SubMainConsultingImage).HasMaxLength(200);

                entity.Property(e => e.SubMainConsultingTitle).HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TbTermAndCondition>(entity =>
            {
                entity.HasKey(e => e.TermsAndConditionsId);

                entity.ToTable("TbTermAndCondition");

                entity.Property(e => e.TermsAndConditionsId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CurrentState).HasDefaultValueSql("((1))");

                entity.Property(e => e.Notes).HasMaxLength(200);

                entity.Property(e => e.TermsAndConditionsDescription).HasMaxLength(200);

                entity.Property(e => e.TermsAndConditionsForWhom).HasMaxLength(200);

                entity.Property(e => e.TermsAndConditionsTitle).HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

using Entities.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Repository.Configuration;
using Repository.Configurations;
using System.Data;


namespace Repository
{
    public class RepositoryContext : IdentityDbContext<User>
    {
        public DbSet<AdminPermission> AdminPermissions { get; set; }
        public DbSet<Batch> Batches { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Cosmetic> Cosmetics { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<DoctorFeedback> DoctorFeedbacks { get; set; }
        public DbSet<DoctorPrescription> DoctorPrescriptions { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Government> Governments { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<Message> Message { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Permission> Permissions { get; set; }

        public DbSet<Pharmacy> Pharmacies { get; set; }
        public DbSet<PharmacyRequest> PharmacyRequests { get; set; }
        public DbSet<PharmacyEmployee> PharmacyEmployees { get; set; }
        public DbSet<PharmacyEmployeeRole> PharmacyEmployeeRoles { get; set; }
        public DbSet<PharmacyEmployeeRequest> PharmacyEmployeeRequests { get; set; }
        public DbSet<PharmacyEmployeePermission> PharmacyEmployeePermissions { get; set; }
        public DbSet<PharmacyFeedback> PharmacyFeedbacks { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductIngredient> ProductIngredients { get; set; }
        public DbSet<PharmacyProduct> ProductPharmacies { get; set; }
        public DbSet<PrescriptionProduct> ProductPrescriptions { get; set; }
        public DbSet<SearchHistory> SearchHistories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Support> Supports { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserChat> UserChats { get; set; }
        public DbSet<UserNotification> UserNotifications { get; set; }
        public DbSet<UserPrescription> UserPrescriptions { get; set; }
        public DbSet<PharmacyProductNotificationPreference> PharmacyProductNotificationPreferences { get; set; }
        
        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new SuperAdminConfiguration());
            modelBuilder.ApplyConfiguration(new SuperAdminRoleConfiguration());
            //modelBuilder.ApplyConfiguration(new UserRoleConfiguration());
           
            modelBuilder.ApplyConfiguration(new AdminPermissionConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());

            modelBuilder.ApplyConfiguration(new BatchConfiguration());
            modelBuilder.Entity<Batch>().HasQueryFilter(b => !b.IsDeleted);

            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.Entity<Category>().HasQueryFilter(c => !c.IsDeleted);

            modelBuilder.ApplyConfiguration(new ChatConfiguration());
            modelBuilder.Entity<Chat>().HasQueryFilter(c => !c.IsDeleted);

            modelBuilder.ApplyConfiguration(new CityConfiguration());
            modelBuilder.Entity<City>().HasQueryFilter(c => !c.IsDeleted);

            modelBuilder.ApplyConfiguration(new CosmeticConfiguration());

            modelBuilder.ApplyConfiguration(new DoctorConfiguration());
            modelBuilder.Entity<Doctor>().HasQueryFilter(d => !d.IsDeleted);

            modelBuilder.ApplyConfiguration(new DoctorFeedbackConfiguration());

            modelBuilder.ApplyConfiguration(new DoctorPrescriptionConfiguration());

            modelBuilder.ApplyConfiguration(new FeedbackConfiguration());
            modelBuilder.Entity<Feedback>().HasQueryFilter(f => !f.IsDeleted);

            modelBuilder.ApplyConfiguration(new GovernmentConfiguration());
            modelBuilder.Entity<Government>().HasQueryFilter(g => !g.IsDeleted);

            modelBuilder.ApplyConfiguration(new IngredientConfiguration());
            modelBuilder.Entity<Ingredient>().HasQueryFilter(i => !i.IsDeleted);

            modelBuilder.ApplyConfiguration(new LocationConfiguration());
            modelBuilder.Entity<Location>().HasQueryFilter(l => !l.IsDeleted);

            modelBuilder.ApplyConfiguration(new MedicineConfiguration());

            modelBuilder.ApplyConfiguration(new MessageConfiguration());

            modelBuilder.ApplyConfiguration(new NotificationConfiguration());
            modelBuilder.Entity<Notification>().HasQueryFilter(n => !n.IsDeleted);

            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.Entity<Order>().HasQueryFilter(o => !o.IsDeleted);

            modelBuilder.ApplyConfiguration(new OrderItemConfiguration());

            modelBuilder.ApplyConfiguration(new PermissionConfiguration());

            modelBuilder.ApplyConfiguration(new PharmacyConfiguration());
            modelBuilder.Entity<Pharmacy>().HasQueryFilter(p => !p.IsDeleted);

            modelBuilder.ApplyConfiguration(new PharmacyRequestConfiguration());

            modelBuilder.ApplyConfiguration(new PharmacyEmployeeConfiguration());
            modelBuilder.Entity<PharmacyEmployee>().HasQueryFilter(pe => !pe.IsDeleted);
            
            modelBuilder.ApplyConfiguration(new PharmacyEmployeeRoleConfiguration());

            modelBuilder.ApplyConfiguration(new PharmacyEmployeeRequestConfiguration());

            modelBuilder.ApplyConfiguration(new PharmacyEmployeePermissionConfiguration());

            modelBuilder.ApplyConfiguration(new PharmacyFeedbackConfiguration());

            modelBuilder.ApplyConfiguration(new PrescriptionConfiguration());

            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.Entity<Product>().HasQueryFilter(p => !p.IsDeleted);

            modelBuilder.ApplyConfiguration(new ProductIngredientConfiguration());

            modelBuilder.ApplyConfiguration(new PharmacyProductConfiguration());

            modelBuilder.ApplyConfiguration(new PrescriptionProductConfiguration());

            modelBuilder.ApplyConfiguration(new SearchHistoryConfiguration());
            modelBuilder.Entity<SearchHistory>().HasQueryFilter(sh => !sh.IsDeleted);

            modelBuilder.ApplyConfiguration(new SubCategoryConfiguration());
            modelBuilder.Entity<SubCategory>().HasQueryFilter(sc => !sc.IsDeleted);

            modelBuilder.ApplyConfiguration(new SupportConfiguration());
            modelBuilder.Entity<Support>().HasQueryFilter(s => !s.IsDeleted);

            modelBuilder.ApplyConfiguration(new UserAddressConfiguration());


            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.Entity<User>().HasQueryFilter(u => !u.IsDeleted);

            modelBuilder.ApplyConfiguration(new UserChatConfiguration());

            modelBuilder.ApplyConfiguration(new UserNotificationConfiguration());

            modelBuilder.ApplyConfiguration(new PharmacyProductNotificationPreferenceConfiguration());
        }
    }
}

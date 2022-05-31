using System.Data.Entity;

namespace FlowersStore.Models
{
    public partial class FlowersStoreDB : DbContext
    {
        public FlowersStoreDB()
            : base("name=FlowersStoreDB")
        {
        }

        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<Bouquet> Bouquets { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Delivery> Deliveries { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Flower> Flowers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Payment_method> Payment_method { get; set; }
        public virtual DbSet<Sale> Sales { get; set; }
        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<Supply> Supplies { get; set; }
        public virtual DbSet<sysdiagram> Sysdiagrams { get; set; }
        public virtual DbSet<Type> Types { get; set; }
        public virtual DbSet<Ordered> Ordereds { get; set; }
        public virtual DbSet<Ordered_services> Ordered_services { get; set; }
        public virtual DbSet<Cart> Carts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRole>()
                .HasMany(e => e.AspNetUsers)
                .WithMany(e => e.AspNetRoles)
                .Map(m => m.ToTable("AspNetUserRoles").MapLeftKey("RoleId").MapRightKey("UserId"));

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserClaims)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserLogins)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<Bouquet>()
                .Property(e => e.Bouquet_name)
                .IsUnicode(false);

            modelBuilder.Entity<Bouquet>()
                .Property(e => e.Bouquet_composition)
                .IsUnicode(false);

            modelBuilder.Entity<Bouquet>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Bouquet>()
                .HasMany(e => e.Ordereds)
                .WithOptional(e => e.Bouquet)
                .HasForeignKey(e => e.Id_bouquets);

            modelBuilder.Entity<Bouquet>()
                .HasMany(e => e.Sales)
                .WithOptional(e => e.bouquet)
                .HasForeignKey(e => e.id_bouquets);

            modelBuilder.Entity<Bouquet>()
                .HasMany(e => e.Supplies)
                .WithOptional(e => e.bouquet)
                .HasForeignKey(e => e.id_bouquets);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.orders)
                .WithRequired(e => e.Customer)
                .HasForeignKey(e => e.Id_customer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.sales)
                .WithRequired(e => e.customer)
                .HasForeignKey(e => e.id_customer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Delivery>()
                .HasMany(e => e.orders)
                .WithRequired(e => e.Delivery)
                .HasForeignKey(e => e.Id_delivery)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.sales)
                .WithRequired(e => e.employee)
                .HasForeignKey(e => e.id_employee)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Flower>()
                .Property(e => e.Flower_name)
                .IsUnicode(false);

            modelBuilder.Entity<Flower>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Flower>()
                .HasMany(e => e.Ordereds)
                .WithOptional(e => e.Flower)
                .HasForeignKey(e => e.Id_flower);

            modelBuilder.Entity<Flower>()
                .HasMany(e => e.Sales)
                .WithOptional(e => e.flower)
                .HasForeignKey(e => e.id_flowers);

            modelBuilder.Entity<Flower>()
                .HasMany(e => e.Supplies)
                .WithOptional(e => e.flower)
                .HasForeignKey(e => e.id_flowers);

            modelBuilder.Entity<Order>()
                .Property(e => e.Delivery_cost)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.OrderDetails)
                .WithRequired(e => e.Order)
                .HasForeignKey(e => e.Id_order)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.ordered_services)
                .WithRequired(e => e.order)
                .HasForeignKey(e => e.id_order)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Payment_method>()
                .HasOptional(e => e.customer)
                .WithRequired(e => e.payment_method);

            modelBuilder.Entity<Service>()
                .Property(e => e.price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Service>()
                .HasMany(e => e.ordered_services)
                .WithRequired(e => e.service)
                .HasForeignKey(e => e.id_services)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Supplier>()
                .HasMany(e => e.supplies)
                .WithRequired(e => e.supplier)
                .HasForeignKey(e => e.id_supplier)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Supply>()
                .Property(e => e.price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Type>()
                .HasMany(e => e.flowers)
                .WithRequired(e => e.Type)
                .HasForeignKey(e => e.Id_type)
                .WillCascadeOnDelete(false);           
        }     
    }
}

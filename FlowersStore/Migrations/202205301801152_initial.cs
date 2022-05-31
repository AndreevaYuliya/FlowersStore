namespace FlowersStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        RecordId = c.Int(nullable: false, identity: true),
                        CartId = c.String(),
                        BouquetId = c.Int(nullable: false),
                        FlowerId = c.Int(nullable: false),
                        FlowerName = c.String(),
                        BouquetName = c.String(),
                        FlowerPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BouquetPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.RecordId)
                .ForeignKey("dbo.Bouquets", t => t.BouquetId, cascadeDelete: true)
                .ForeignKey("dbo.Flowers", t => t.FlowerId, cascadeDelete: true)
                .Index(t => t.BouquetId)
                .Index(t => t.FlowerId);
            
            CreateTable(
                "dbo.Bouquets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Bouquet_name = c.String(nullable: false, maxLength: 50),
                        Bouquet_composition = c.String(nullable: false, maxLength: 50),
                        Price = c.Decimal(nullable: false, storeType: "money"),
                        Id_supplier = c.Int(nullable: false),
                        Markup = c.Int(nullable: false),
                        Account_number = c.Int(nullable: false),
                        Actual_quantity = c.Int(nullable: false),
                        Picture = c.Binary(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ordered",
                c => new
                    {
                        Id_order = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Id_flower = c.Int(),
                        Id_bouquets = c.Int(),
                        Unit_priceFlower = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Unit_priceBouquet = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Flower_name = c.String(),
                        Bouquet_name = c.String(),
                        Bouquet_Id = c.Int(),
                        Flower_Id = c.Int(),
                        Order_Id = c.Int(),
                    })
                .PrimaryKey(t => new { t.Id_order, t.Quantity })
                .ForeignKey("dbo.Bouquets", t => t.Bouquet_Id)
                .ForeignKey("dbo.Flowers", t => t.Flower_Id)
                .ForeignKey("dbo.order", t => t.Order_Id)
                .Index(t => t.Bouquet_Id)
                .Index(t => t.Flower_Id)
                .Index(t => t.Order_Id);
            
            CreateTable(
                "dbo.Flowers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Id_type = c.Short(nullable: false),
                        Flower_name = c.String(nullable: false, maxLength: 50),
                        Price = c.Decimal(nullable: false, storeType: "money"),
                        Id_supplier = c.Int(nullable: false),
                        Markup = c.Int(nullable: false),
                        Account_number = c.Int(nullable: false),
                        Actual_quantity = c.Int(nullable: false),
                        Picture = c.Binary(storeType: "image"),
                        Flower_size = c.Int(nullable: false),
                        Type_id = c.Short(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.type", t => t.Type_id)
                .Index(t => t.Type_id);
            
            CreateTable(
                "dbo.Sales",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        id_employee = c.Int(nullable: false),
                        id_flowers = c.Int(),
                        id_bouquets = c.Int(),
                        id_customer = c.Int(nullable: false),
                        quantity = c.Int(nullable: false),
                        date_sale = c.DateTime(nullable: false),
                        bouquet_Id = c.Int(),
                        customer_id = c.Int(),
                        employee_id = c.Int(),
                        flower_Id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Bouquets", t => t.bouquet_Id)
                .ForeignKey("dbo.Customers", t => t.customer_id)
                .ForeignKey("dbo.Employees", t => t.employee_id)
                .ForeignKey("dbo.Flowers", t => t.flower_Id)
                .Index(t => t.bouquet_Id)
                .Index(t => t.customer_id)
                .Index(t => t.employee_id)
                .Index(t => t.flower_Id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        id = c.Int(nullable: false),
                        surname = c.String(nullable: false, maxLength: 255),
                        customer_name = c.String(nullable: false, maxLength: 255),
                        last_name = c.String(maxLength: 255),
                        phone_number = c.String(maxLength: 255),
                        eMail = c.String(nullable: false, maxLength: 255),
                        customer_discount = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Payment_method", t => t.id)
                .Index(t => t.id);
            
            CreateTable(
                "dbo.order",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Id_customer = c.Int(nullable: false),
                        Customer_city = c.String(nullable: false, maxLength: 255),
                        Customer_address = c.String(nullable: false, maxLength: 255),
                        Registration_date = c.DateTime(nullable: false),
                        Delivery_date = c.DateTime(nullable: false),
                        Id_delivery = c.Int(nullable: false),
                        Delivery_cost = c.Decimal(nullable: false, storeType: "money"),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Customer_id = c.Int(),
                        Delivery_id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.Customer_id)
                .ForeignKey("dbo.delivery", t => t.Delivery_id)
                .Index(t => t.Customer_id)
                .Index(t => t.Delivery_id);
            
            CreateTable(
                "dbo.delivery",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        delivery_method = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Ordered_services",
                c => new
                    {
                        id_order = c.Int(nullable: false),
                        id_services = c.Int(nullable: false),
                        quantity = c.Int(nullable: false),
                        order_Id = c.Int(),
                        service_id = c.Int(),
                    })
                .PrimaryKey(t => new { t.id_order, t.id_services, t.quantity })
                .ForeignKey("dbo.order", t => t.order_Id)
                .ForeignKey("dbo.Services", t => t.service_id)
                .Index(t => t.order_Id)
                .Index(t => t.service_id);
            
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        service_name = c.String(nullable: false, maxLength: 255),
                        price = c.Decimal(nullable: false, storeType: "money"),
                        picture = c.Binary(storeType: "image"),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Payment_method",
                c => new
                    {
                        id_customer = c.Int(nullable: false, identity: true),
                        payment_method = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.id_customer);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        surname = c.String(nullable: false, maxLength: 255),
                        name_employee = c.String(nullable: false, maxLength: 255),
                        last_name = c.String(nullable: false, maxLength: 255),
                        adress = c.String(nullable: false, maxLength: 255),
                        phone_number = c.Int(nullable: false),
                        eMail = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.supply",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        id_supplier = c.Int(nullable: false),
                        id_flowers = c.Int(),
                        id_bouquets = c.Int(),
                        quantity = c.Int(nullable: false),
                        price = c.Decimal(nullable: false, storeType: "money"),
                        date_supply = c.DateTime(nullable: false),
                        bouquet_Id = c.Int(),
                        flower_Id = c.Int(),
                        supplier_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Bouquets", t => t.bouquet_Id)
                .ForeignKey("dbo.Flowers", t => t.flower_Id)
                .ForeignKey("dbo.Suppliers", t => t.supplier_id)
                .Index(t => t.bouquet_Id)
                .Index(t => t.flower_Id)
                .Index(t => t.supplier_id);
            
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        supplier_name = c.String(nullable: false, maxLength: 255),
                        country = c.String(nullable: false, maxLength: 255),
                        city = c.String(nullable: false, maxLength: 255),
                        address = c.String(nullable: false, maxLength: 255),
                        phone_number = c.String(nullable: false, maxLength: 255),
                        eMail = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.type",
                c => new
                    {
                        id = c.Short(nullable: false, identity: true),
                        type_of_flowers = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.EditUserViewModels",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                        Description = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.RoleViewModels",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Carts", "FlowerId", "dbo.Flowers");
            DropForeignKey("dbo.Carts", "BouquetId", "dbo.Bouquets");
            DropForeignKey("dbo.Flowers", "Type_id", "dbo.type");
            DropForeignKey("dbo.supply", "supplier_id", "dbo.Suppliers");
            DropForeignKey("dbo.supply", "flower_Id", "dbo.Flowers");
            DropForeignKey("dbo.supply", "bouquet_Id", "dbo.Bouquets");
            DropForeignKey("dbo.Sales", "flower_Id", "dbo.Flowers");
            DropForeignKey("dbo.Sales", "employee_id", "dbo.Employees");
            DropForeignKey("dbo.Sales", "customer_id", "dbo.Customers");
            DropForeignKey("dbo.Customers", "id", "dbo.Payment_method");
            DropForeignKey("dbo.Ordered_services", "service_id", "dbo.Services");
            DropForeignKey("dbo.Ordered_services", "order_Id", "dbo.order");
            DropForeignKey("dbo.ordered", "Order_Id", "dbo.order");
            DropForeignKey("dbo.order", "Delivery_id", "dbo.delivery");
            DropForeignKey("dbo.order", "Customer_id", "dbo.Customers");
            DropForeignKey("dbo.Sales", "bouquet_Id", "dbo.Bouquets");
            DropForeignKey("dbo.ordered", "Flower_Id", "dbo.Flowers");
            DropForeignKey("dbo.ordered", "Bouquet_Id", "dbo.Bouquets");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.supply", new[] { "supplier_id" });
            DropIndex("dbo.supply", new[] { "flower_Id" });
            DropIndex("dbo.supply", new[] { "bouquet_Id" });
            DropIndex("dbo.Ordered_services", new[] { "service_id" });
            DropIndex("dbo.Ordered_services", new[] { "order_Id" });
            DropIndex("dbo.order", new[] { "Delivery_id" });
            DropIndex("dbo.order", new[] { "Customer_id" });
            DropIndex("dbo.Customers", new[] { "id" });
            DropIndex("dbo.Sales", new[] { "flower_Id" });
            DropIndex("dbo.Sales", new[] { "employee_id" });
            DropIndex("dbo.Sales", new[] { "customer_id" });
            DropIndex("dbo.Sales", new[] { "bouquet_Id" });
            DropIndex("dbo.Flowers", new[] { "Type_id" });
            DropIndex("dbo.ordered", new[] { "Order_Id" });
            DropIndex("dbo.ordered", new[] { "Flower_Id" });
            DropIndex("dbo.ordered", new[] { "Bouquet_Id" });
            DropIndex("dbo.Carts", new[] { "FlowerId" });
            DropIndex("dbo.Carts", new[] { "BouquetId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.RoleViewModels");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.EditUserViewModels");
            DropTable("dbo.type");
            DropTable("dbo.Suppliers");
            DropTable("dbo.supply");
            DropTable("dbo.Employees");
            DropTable("dbo.Payment_method");
            DropTable("dbo.Services");
            DropTable("dbo.Ordered_services");
            DropTable("dbo.delivery");
            DropTable("dbo.order");
            DropTable("dbo.Customers");
            DropTable("dbo.Sales");
            DropTable("dbo.Flowers");
            DropTable("dbo.ordered");
            DropTable("dbo.Bouquets");
            DropTable("dbo.Carts");
        }
    }
}

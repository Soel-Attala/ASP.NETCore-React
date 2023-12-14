using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SalesSystem.Entity;

namespace SalesSystem.DAL.DBContext
{
    public partial class SALESDBContext : DbContext
    {
        public SALESDBContext()
        {
        }

        public SALESDBContext(DbContextOptions<SALESDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Business> Businesses { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Configuration> Configurations { get; set; } = null!;
        public virtual DbSet<CorrelativeNumber> CorrelativeNumbers { get; set; } = null!;
        public virtual DbSet<Menu> Menus { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<RoleMenu> RoleMenus { get; set; } = null!;
        public virtual DbSet<Sale> Sales { get; set; } = null!;
        public virtual DbSet<SaleDetail> SaleDetails { get; set; } = null!;
        public virtual DbSet<SalesDocumentType> SalesDocumentTypes { get; set; } = null!;
        public virtual DbSet<UserData> UserData { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Business>(entity =>
            {
                entity.HasKey(e => e.IdBusiness)
                    .HasName("PK__Business__79BC445DD4D7E5FD");

                entity.ToTable("Business");

                entity.Property(e => e.IdBusiness)
                    .ValueGeneratedNever()
                    .HasColumnName("idBusiness");

                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.CurrencySymbol)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("currencySymbol");

                entity.Property(e => e.DocumentNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("documentNumber");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.LogoName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("logoName");

                entity.Property(e => e.LogoUrl)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("logoUrl");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Phone)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("phone");

                entity.Property(e => e.TaxPercentage)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("taxPercentage");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.IdCategory)
                    .HasName("PK__Category__79D361B69B1B5AA0");

                entity.ToTable("Category");

                entity.Property(e => e.IdCategory).HasColumnName("idCategory");

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.RegistrationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("registrationDate")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Configuration>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Configuration");

                entity.Property(e => e.Property)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("property");

                entity.Property(e => e.Resource)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("resource");

                entity.Property(e => e.Value)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("value");
            });

            modelBuilder.Entity<CorrelativeNumber>(entity =>
            {
                entity.HasKey(e => e.IdCorrelativeNumber)
                    .HasName("PK__Correlat__D71CDFB0F4B9228B");

                entity.ToTable("CorrelativeNumber");

                entity.Property(e => e.IdCorrelativeNumber).HasColumnName("idCorrelativeNumber");

                entity.Property(e => e.DigitCount).HasColumnName("digitCount");

                entity.Property(e => e.LastNumber).HasColumnName("lastNumber");

                entity.Property(e => e.Management)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("management");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("updateDate");
            });

            modelBuilder.Entity<Menu>(entity =>
            {
                entity.HasKey(e => e.IdMenu)
                    .HasName("PK__Menu__C26AF483EE5496F0");

                entity.ToTable("Menu");

                entity.Property(e => e.IdMenu).HasColumnName("idMenu");

                entity.Property(e => e.ActionPage)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("actionPage");

                entity.Property(e => e.Controller)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("controller");

                entity.Property(e => e.Description)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.Icon)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("icon");

                entity.Property(e => e.IdParentMenu).HasColumnName("idParentMenu");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.RegistrationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("registrationDate")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.IdParentMenuNavigation)
                    .WithMany(p => p.InverseIdParentMenuNavigation)
                    .HasForeignKey(d => d.IdParentMenu)
                    .HasConstraintName("FK__Menu__idParentMe__24927208");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.IdProduct)
                    .HasName("PK__Product__5EEC79D1CFB79BD0");

                entity.ToTable("Product");

                entity.Property(e => e.IdProduct).HasColumnName("idProduct");

                entity.Property(e => e.Barcode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("barcode");

                entity.Property(e => e.Brand)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("brand");

                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.IdCategory).HasColumnName("idCategory");

                entity.Property(e => e.ImageName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("imageName");

                entity.Property(e => e.ImageUrl)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("imageUrl");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.Price)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("price");

                entity.Property(e => e.RegistrationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("registrationDate")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Stock).HasColumnName("stock");

                entity.HasOne(d => d.IdCategoryNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.IdCategory)
                    .HasConstraintName("FK__Product__idCateg__36B12243");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.IdRole)
                    .HasName("PK__Role__E5045C545281B941");

                entity.ToTable("Role");

                entity.Property(e => e.IdRole).HasColumnName("idRole");

                entity.Property(e => e.Description)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.RegistrationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("registrationDate")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<RoleMenu>(entity =>
            {
                entity.HasKey(e => e.IdRoleMenu)
                    .HasName("PK__RoleMenu__50A394F9E9C78D48");

                entity.ToTable("RoleMenu");

                entity.Property(e => e.IdRoleMenu).HasColumnName("idRoleMenu");

                entity.Property(e => e.IdMenu).HasColumnName("idMenu");

                entity.Property(e => e.IdRole).HasColumnName("idRole");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.RegistrationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("registrationDate")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.IdMenuNavigation)
                    .WithMany(p => p.RoleMenus)
                    .HasForeignKey(d => d.IdMenu)
                    .HasConstraintName("FK__RoleMenu__idMenu__2C3393D0");

                entity.HasOne(d => d.IdRoleNavigation)
                    .WithMany(p => p.RoleMenus)
                    .HasForeignKey(d => d.IdRole)
                    .HasConstraintName("FK__RoleMenu__idRole__2B3F6F97");
            });

            modelBuilder.Entity<Sale>(entity =>
            {
                entity.HasKey(e => e.IdSale)
                    .HasName("PK__Sale__C4AEB198996CD07F");

                entity.ToTable("Sale");

                entity.Property(e => e.IdSale).HasColumnName("idSale");

                entity.Property(e => e.CustomerDocument)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("customerDocument");

                entity.Property(e => e.CustomerName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("customerName");

                entity.Property(e => e.IdSalesDocumentType).HasColumnName("idSalesDocumentType");

                entity.Property(e => e.IdUser).HasColumnName("idUser");

                entity.Property(e => e.RegistrationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("registrationDate")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SaleNumber)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("saleNumber");

                entity.Property(e => e.SubTotal)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("subTotal");

                entity.Property(e => e.TotalAmount)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("totalAmount");

                entity.Property(e => e.TotalTax)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("totalTax");

                entity.HasOne(d => d.IdSalesDocumentTypeNavigation)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.IdSalesDocumentType)
                    .HasConstraintName("FK__Sale__idSalesDoc__3F466844");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.IdUser)
                    .HasConstraintName("FK__Sale__idUser__403A8C7D");
            });

            modelBuilder.Entity<SaleDetail>(entity =>
            {
                entity.HasKey(e => e.IdSaleDetail)
                    .HasName("PK__SaleDeta__B23385CDE8B1319C");

                entity.ToTable("SaleDetail");

                entity.Property(e => e.IdSaleDetail).HasColumnName("idSaleDetail");

                entity.Property(e => e.IdProduct).HasColumnName("idProduct");

                entity.Property(e => e.IdSale).HasColumnName("idSale");

                entity.Property(e => e.Price)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("price");

                entity.Property(e => e.ProductBrand)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("productBrand");

                entity.Property(e => e.ProductCategory)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("productCategory");

                entity.Property(e => e.ProductDescription)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("productDescription");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.TotalAmount)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("totalAmount");

                entity.HasOne(d => d.IdSaleNavigation)
                    .WithMany(p => p.SaleDetails)
                    .HasForeignKey(d => d.IdSale)
                    .HasConstraintName("FK__SaleDetai__idSal__440B1D61");
            });

            modelBuilder.Entity<SalesDocumentType>(entity =>
            {
                entity.HasKey(e => e.IdSalesDocumentType)
                    .HasName("PK__SalesDoc__2A8495D73D50A2F1");

                entity.ToTable("SalesDocumentType");

                entity.Property(e => e.IdSalesDocumentType).HasColumnName("idSalesDocumentType");

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.RegistrationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("registrationDate")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<UserData>(entity =>
            {
                entity.HasKey(e => e.IdUser)
                    .HasName("PK__UserData__3717C9827B31E422");

                entity.Property(e => e.IdUser).HasColumnName("idUser");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.IdRole).HasColumnName("idRole");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Password)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.Phone)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("phone");

                entity.Property(e => e.PhotoName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("photoName");

                entity.Property(e => e.PhotoUrl)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("photoUrl");

                entity.Property(e => e.RegistrationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("registrationDate")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.IdRoleNavigation)
                    .WithMany(p => p.UserData)
                    .HasForeignKey(d => d.IdRole)
                    .HasConstraintName("FK__UserData__idRole__300424B4");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

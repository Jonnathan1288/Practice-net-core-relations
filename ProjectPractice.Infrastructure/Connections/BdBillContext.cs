using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ProjectPractice.Domain.Entities.Public;

public partial class BdBillContext : DbContext
{
    public BdBillContext()
    {
    }

    public BdBillContext(DbContextOptions<BdBillContext> options) : base(options) {}
    public virtual DbSet<Bill> Bills { get; set; }

    public virtual DbSet<Brand> Brands { get; set; }

    public virtual DbSet<DetailsBill> DetailsBills { get; set; }

    public virtual DbSet<Model> Models { get; set; }

    public virtual DbSet<Parent> Parents { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Vehicle> Vehicles { get; set; }

    public virtual DbSet<VehicleStatus> VehicleStatuses { get; set; }

    public virtual DbSet<VehiclesType> VehiclesTypes { get; set; }

    private static string GenerateCode(short length = 20)
    {
        char[] _chars = new char[]
        {
                'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J',
                'k', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T',
                'U', 'V', 'W', 'X', 'Y', 'Z', 'a', 'b', 'c', 'd',
                'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'o',
                'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y',
                'z', '0', '1', '2', '3', '4', '5', '6', '7', '8',
                '9'
        };
        StringBuilder sb = new();
        Random random = new();
        for (int i = 0; i < length; i++)
        {
            sb.Append(_chars[random.Next(0, _chars.Length)]);
        }
        return sb.ToString();
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        IEnumerable<EntityEntry> entries = ChangeTracker.Entries().Where(entry =>
        {
            return entry.State == EntityState.Added || entry.State == EntityState.Modified;
        });
        foreach (EntityEntry entry in entries)
        {
            if (entry.Entity.GetType().GetProperty("UpdateDate") != null) Entry(entry.Entity).Property("UpdateDate").CurrentValue = DateTime.Now;
            if (entry.State == EntityState.Added)
            {
                if (entry.Entity.GetType().GetProperty("VehiCode") != null) Entry(entry.Entity).Property("VehiCode").CurrentValue = GenerateCode();
                if (entry.Entity.GetType().GetProperty("Active") != null) Entry(entry.Entity).Property("Active").CurrentValue = true;
                if (entry.Entity.GetType().GetProperty("CreationDate") != null) Entry(entry.Entity).Property("CreationDate").CurrentValue = DateTime.Now;
            }
            else if (entry.State == EntityState.Modified)
            {
                if (entry.Entity.GetType().GetProperty("CreationDate") != null) Entry(entry.Entity).Property("CreationDate").IsModified = false;
                if (entry.Entity.GetType().GetProperty("VehiCode") != null) Entry(entry.Entity).Property("VehiCode").IsModified = false;
            }
        }
        return base.SaveChangesAsync(cancellationToken);
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bill>(entity =>
        {
            entity.HasKey(e => e.BillNumber).HasName("bills_pkey");

            entity.ToTable("bills");

            entity.Property(e => e.BillNumber)
                .ValueGeneratedNever()
                .HasColumnName("bill_number");
            entity.Property(e => e.Amount)
                .HasPrecision(10)
                .HasColumnName("amount");
            entity.Property(e => e.PaymentMethod)
                .HasMaxLength(50)
                .HasColumnName("payment_method");
            entity.Property(e => e.PurchaseDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("purchase_date");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Bills)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("bills_user_id_fkey");
        });

        modelBuilder.Entity<Brand>(entity =>
        {
            entity.HasKey(e => e.BrandId).HasName("brands_pkey");

            entity.ToTable("brands");

            entity.HasIndex(e => e.BrandName, "brands_brand_name_key").IsUnique();

            entity.Property(e => e.BrandId)
                .UseIdentityAlwaysColumn()
                .HasColumnName("brand_id");
            entity.Property(e => e.BrandName)
                .HasMaxLength(50)
                .HasColumnName("brand_name");
            entity.Property(e => e.BrandStatus).HasColumnName("brand_status");
        });

        modelBuilder.Entity<DetailsBill>(entity =>
        {
            entity.HasKey(e => new { e.BillDetailNumber, e.BillNumber }).HasName("details_bills_pkey");

            entity.ToTable("details_bills");

            entity.Property(e => e.BillDetailNumber).HasColumnName("bill_detail_number");
            entity.Property(e => e.BillNumber).HasColumnName("bill_number");
            entity.Property(e => e.PricePerItem)
                .HasPrecision(10, 2)
                .HasColumnName("price_per_item");
            entity.Property(e => e.VehiId).HasColumnName("vehi_id");

            entity.HasOne(d => d.BillNumberNavigation).WithMany(p => p.DetailsBills)
                .HasForeignKey(d => d.BillNumber)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("details_bills_bill_number_fkey");

            entity.HasOne(d => d.Vehi).WithMany(p => p.DetailsBills)
                .HasForeignKey(d => d.VehiId)
                .HasConstraintName("details_bills_vehi_id_fkey");
        });

        modelBuilder.Entity<Model>(entity =>
        {
            entity.HasKey(e => e.ModelId).HasName("models_pkey");

            entity.ToTable("models");

            entity.HasIndex(e => e.ModelName, "models_model_name_key").IsUnique();

            entity.Property(e => e.ModelId)
                .UseIdentityAlwaysColumn()
                .HasColumnName("model_id");
            entity.Property(e => e.BrandId).HasColumnName("brand_id");
            entity.Property(e => e.ModelAvailableQuantity).HasColumnName("model_available_quantity");
            entity.Property(e => e.ModelName)
                .HasMaxLength(50)
                .HasColumnName("model_name");
            entity.Property(e => e.ModelPrice)
                .HasPrecision(10, 2)
                .HasColumnName("model_price");
            entity.Property(e => e.ModelStatus).HasColumnName("model_status");

            entity.HasOne(d => d.Brand).WithMany(p => p.Models)
                .HasForeignKey(d => d.BrandId)
                .HasConstraintName("models_brand_id_fkey");
        });

        modelBuilder.Entity<Parent>(entity =>
        {
            entity.HasKey(e => e.ParentId).HasName("parents_pkey");

            entity.ToTable("parents");

            entity.Property(e => e.ParentId)
                .UseIdentityAlwaysColumn()
                .HasColumnName("parent_id");
            entity.Property(e => e.ParentName)
                .HasMaxLength(50)
                .HasColumnName("parent_name");
            entity.Property(e => e.ParentStatus).HasColumnName("parent_status");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("users_pkey");

            entity.ToTable("users");

            entity.HasIndex(e => e.UserUsername, "users_user_username_key").IsUnique();

            entity.Property(e => e.UserId)
                .UseIdentityAlwaysColumn()
                .HasColumnName("user_id");
            entity.Property(e => e.UserStatus).HasColumnName("user_status");
            entity.Property(e => e.UserUsername)
                .HasMaxLength(20)
                .HasColumnName("user_username");
        });

        modelBuilder.Entity<Vehicle>(entity =>
        {
            entity.HasKey(e => e.VehiId).HasName("vehicles_pkey");

            entity.ToTable("vehicles");

            entity.HasIndex(e => e.VehiPlate, "vehicles_vehi_plate_key").IsUnique();

            entity.Property(e => e.VehiId)
                .UseIdentityAlwaysColumn()
                .HasColumnName("vehi_id");
            entity.Property(e => e.ModelId).HasColumnName("model_id");
            entity.Property(e => e.VehiCode)
                .HasMaxLength(30)
                .HasColumnName("vehi_code");
            entity.Property(e => e.VehiPlate)
                .HasMaxLength(30)
                .HasColumnName("vehi_plate");
            entity.Property(e => e.VehiStatus)
                .HasMaxLength(1)
                .HasColumnName("vehi_status");
            entity.Property(e => e.VehiTypeId).HasColumnName("vehi_type_id");
            entity.Property(e => e.VsId).HasColumnName("vs_id");

            entity.HasOne(d => d.Model).WithMany(p => p.Vehicles)
                .HasForeignKey(d => d.ModelId)
                .HasConstraintName("vehicles_model_id_fkey");

            entity.HasOne(d => d.VehiType).WithMany(p => p.Vehicles)
                .HasForeignKey(d => d.VehiTypeId)
                .HasConstraintName("vehicles_vehi_type_id_fkey");

            entity.HasOne(d => d.Vs).WithMany(p => p.Vehicles)
                .HasForeignKey(d => d.VsId)
                .HasConstraintName("vehicles_vs_id_fkey");
        });

        modelBuilder.Entity<VehicleStatus>(entity =>
        {
            entity.HasKey(e => e.VsId).HasName("vehicle_status_pkey");

            entity.ToTable("vehicle_status");

            entity.HasIndex(e => e.VsName, "vehicle_status_vs_name_key").IsUnique();

            entity.Property(e => e.VsId)
                .UseIdentityAlwaysColumn()
                .HasColumnName("vs_id");
            entity.Property(e => e.VsName)
                .HasMaxLength(20)
                .HasColumnName("vs_name");
            entity.Property(e => e.VsStatus).HasColumnName("vs_status");
        });

        modelBuilder.Entity<VehiclesType>(entity =>
        {
            entity.HasKey(e => e.VehiTypeId).HasName("vehicles_types_pkey");

            entity.ToTable("vehicles_types");

            entity.HasIndex(e => e.VehiTypeName, "vehicles_types_vehi_type_name_key").IsUnique();

            entity.Property(e => e.VehiTypeId)
                .UseIdentityAlwaysColumn()
                .HasColumnName("vehi_type_id");
            entity.Property(e => e.VehiTypeName)
                .HasMaxLength(50)
                .HasColumnName("vehi_type_name");
            entity.Property(e => e.VehiTypeStatus).HasColumnName("vehi_type_status");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
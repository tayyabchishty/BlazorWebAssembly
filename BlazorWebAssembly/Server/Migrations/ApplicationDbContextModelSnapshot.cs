// <auto-generated />
using System;
using BlazorWebAssembly.Server.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BlazorWebAssembly.Server.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BlazorWebAssembly.Shared.Department", b =>
                {
                    b.Property<int>("DepartmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DepartmentName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DepartmentId");

                    b.ToTable("Departments");

                    b.HasData(
                        new
                        {
                            DepartmentId = 1,
                            DepartmentName = "IT"
                        },
                        new
                        {
                            DepartmentId = 2,
                            DepartmentName = "HR"
                        },
                        new
                        {
                            DepartmentId = 3,
                            DepartmentName = "Admin"
                        },
                        new
                        {
                            DepartmentId = 4,
                            DepartmentName = "Finance"
                        });
                });

            modelBuilder.Entity("BlazorWebAssembly.Shared.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhotoPath")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmployeeId");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            EmployeeId = 1,
                            DateOfBirth = new DateTime(1980, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DepartmentId = 1,
                            Email = "jhon@gmail.com",
                            FirstName = "Jhon",
                            Gender = 0,
                            LastName = "Hasting",
                            PhotoPath = "images/jhon.jpg"
                        },
                        new
                        {
                            EmployeeId = 2,
                            DateOfBirth = new DateTime(1982, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DepartmentId = 2,
                            Email = "carter@gmail.com",
                            FirstName = "Carter",
                            Gender = 0,
                            LastName = "hugh",
                            PhotoPath = "images/carter.jpg"
                        },
                        new
                        {
                            EmployeeId = 3,
                            DateOfBirth = new DateTime(1991, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DepartmentId = 3,
                            Email = "julie@gmail.com",
                            FirstName = "Julie",
                            Gender = 1,
                            LastName = "James",
                            PhotoPath = "images/julie.jpg"
                        },
                        new
                        {
                            EmployeeId = 4,
                            DateOfBirth = new DateTime(1990, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DepartmentId = 4,
                            Email = "sam@gmail.com",
                            FirstName = "Sam",
                            Gender = 1,
                            LastName = "Ali",
                            PhotoPath = "images/sam.jpg"
                        });
                });

            modelBuilder.Entity("BlazorWebAssembly.Shared.Employee", b =>
                {
                    b.HasOne("BlazorWebAssembly.Shared.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });
#pragma warning restore 612, 618
        }
    }
}

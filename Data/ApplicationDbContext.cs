using System.CodeDom.Compiler;
using MedicalAppointment.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;

namespace MedicalAppointment.Data;

//public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string,
//        ApplicationUserClaim, ApplicationUserRole, ApplicationUserLogin,
//        ApplicationRoleClaim, ApplicationUserToken>

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>

{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public virtual DbSet<Specialization> Specializations { set; get; }
    public virtual DbSet<Appointment> Appointments { set; get; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        var admin = new IdentityRole("Admin");
        admin.NormalizedName = "ADMIN";

        var patients = new IdentityRole("Patients");
        patients.NormalizedName = "PATIENTS";

        var doctor = new IdentityRole("Doctor");
        doctor.NormalizedName = "DOCTOR";

        builder.Entity<IdentityRole>().HasData(admin,patients,doctor);
    }
}




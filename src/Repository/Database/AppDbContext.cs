using MedicalAPI.Domain.Entities.Entity.Documents;
using MedicalAPI.Domain.Entities.User;
using Microsoft.EntityFrameworkCore;

namespace MedicalAPI.Repository.Database;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<PatientModel> Patients { get; set; } 
    public DbSet<DoctorModel> Doctors { get; set; } 
    public DbSet<AppointmentModel> Appointments { get; set; } 
    public DbSet<PrescriptionModel> Prescriptions { get; set; } 
}
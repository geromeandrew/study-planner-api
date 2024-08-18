using System;
using Microsoft.EntityFrameworkCore;
using StudyPlannerAPI.Models;

namespace StudyPlannerAPI.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<StudyPlan> StudyPlans { get; set; }


}

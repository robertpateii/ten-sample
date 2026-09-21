using Microsoft.EntityFrameworkCore;

class ApptDb : DbContext
{
    public ApptDb(DbContextOptions<ApptDb> options)
        : base(options) { }

    public DbSet<Appt> Appts => Set<Appt>();
}
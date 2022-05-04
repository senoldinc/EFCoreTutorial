using Microsoft.EntityFrameworkCore.Design;

namespace EFCoreTutorial.Data.Context;

public class ApplicationDbContextDesignTimeFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var context = new ApplicationDbContext();
        return context;
    }
}
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PenguageMvc.Models;

namespace PenguageMvc.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        
        public DbSet<PenguageMvc.Models.MultipleChoiceQuestion> MultipleChoiceQuestion { get; set; } = default!;

        public DbSet<PenguageMvc.Models.FillInBlankQuestion> FillInBlankQuestion { get; set; } = default!;

        public DbSet<PenguageMvc.Models.Question> Question { get; set; } = default!;

        public DbSet<PenguageMvc.Models.LearningRecord> LearningRecord { get; set; } = default!;
    }
}
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PenguageMvc.Data
{
    public class ApplicationDbContext : IdentityDbContext
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
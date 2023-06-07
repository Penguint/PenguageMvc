using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace PenguageMvc.Models
{
    public class LearningRecord
    {
        public int Id { get; set; }

        public IdentityUser? User { get; set; }

        public Question? Question { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime? CompleteDate { get; set; }

        public bool Correct { get; set; }
    }
}

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StajyerUygulamasi.Model
{
    public class Education
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Stajyer")]
        [Required]
        public int StajyerID { get; set; }
        [Required]
        public Stajyer Stajyer { get; set; }
        [Required]
        public String EducationName { get; set; }
        [Required]
        public DateTime StartTime { get; set; }
        [Required]
        public DateTime FinishTime { get; set; }
    }
}

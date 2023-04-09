using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StajyerUygulamasi.Model
{
    public class InternSubmitted
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Stajyer")]
        [Required]
        public int StajyerID { get; set; }
        [Required]
        public Stajyer Stajyer { get; set; }

        [ForeignKey("Intern")]
        [Required]
        public int InternID { get; set; }
        [Required]
        public Intern Intern { get; set; }
        [Required]
        public DateTime SubmitTime { get; set; }
    }
}

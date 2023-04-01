using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StajyerUygulamasi.Model
{
    public class Experience
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Stajyer")]
        [Required]
        public int StajyerID { get; set; }
        [Required]
        public Stajyer Stajyer { get; set; }
        [Required]
        public String CompanyName { get; set; }
        [Required]
        public String Position { get; set; }
        [Required]
        public String StartTime { get; set; }
        [Required]
        public String FinishTime { get; set; }
    }
}

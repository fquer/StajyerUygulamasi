using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StajyerUygulamasi.Model
{
    public class Intern
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public String CompanyName { get; set; }
        [Required]
        public String Position { get; set; }
        [Required]
        public String Details { get; set; }
        [Required]
        public DateTime OpenTime { get; set; }
        [Required]
        public int ApplicantsCounter { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StajyerUygulamasi.Model
{
    public class About
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Stajyer")]
        [Required]
        public int StajyerID { get; set; }
        [Required]
        public Stajyer Stajyer { get; set; }
        public DateTime DateOfBirth { get; set; }
        public String AboutText { get; set; }
    }
}

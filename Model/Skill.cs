using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StajyerUygulamasi.Model
{
    
    public class Skill
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Stajyer")]
        [Required]
        public int StajyerID { get; set; }
        [Required]
        public Stajyer Stajyer { get; set; }
        [Required]
        public String SkillName { get; set; }
    }
}

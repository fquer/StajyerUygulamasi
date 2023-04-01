using System.ComponentModel.DataAnnotations;

namespace StajyerUygulamasi.Model
{
    public class Stajyer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public String Name { get; set; }
        [Required]
        public String Surname { get; set; }
        [Required]
        public String Email { get; set; }
        [Required]
        public String Password { get; set; }

    }
}

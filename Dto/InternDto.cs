using System.ComponentModel.DataAnnotations;

namespace StajyerUygulamasi.Dto
{
    public class InternDto
    {
  
        public int Id { get; set; }

        public String CompanyName { get; set; }
 
        public String Position { get; set; }

        public String Details { get; set; }
  
        public DateTime OpenTime { get; set; }

        public int ApplicantsCounter { get; set; }

        public bool isAplied { get; set; }
    }
}

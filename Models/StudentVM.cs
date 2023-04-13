using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SchoolApp.Models
{
    public class StudentVM
    {
        
        public string FName { get; set; }
        public string LName { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }


        //Navigation Properties
        public ClassRoom ClassRoom { get; set; }
        public string ClassRoomID { get; set; }
    }
}

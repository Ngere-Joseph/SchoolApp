using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SchoolApp.Models
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }


        //Navigation Properties
        public ClassRoom ClassRoom { get; set; }

        
        [ForeignKey("ClassRoom")]
        public int ClassRoomID { get; set; }
    }
}

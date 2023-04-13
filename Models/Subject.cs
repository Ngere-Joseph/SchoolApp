using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolApp.Models
{
    public class Subject
    {
        public int Id { get; set; }
        public string SubjectName { get; set; }
        public string SubjectDescription { get; set; }
        public DateTime StartDate { get; set; }


        //Navigation Properties

        public ClassRoom ClassRoom { get; set; }

        [Key]
        [ForeignKey("ClassRoom")]
        public int ClassRoomID { get; set; }

    }
}

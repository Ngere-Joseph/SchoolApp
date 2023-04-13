using SchoolApp.Models;

namespace SchoolApp.Data
{
    public class DropDownVM
    {
        public DropDownVM()
        {
            ClassRooms = new List<ClassRoom>();
        }

        public List<ClassRoom> ClassRooms { get; set; }
    }
}

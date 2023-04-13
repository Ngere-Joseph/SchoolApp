namespace SchoolApp.Models
{
    public class ClassRoom
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }


        //Navigation Properties
        public virtual List<Subject> Subjects { get; set; }
        public virtual List<Student> Students { get; set; }


        //public Student Student { get; set; }
        //public int StudentId { get; set; }

        //public Subject Subject { get; set; }
        //public int SubjectId { get; set; }




    }
}

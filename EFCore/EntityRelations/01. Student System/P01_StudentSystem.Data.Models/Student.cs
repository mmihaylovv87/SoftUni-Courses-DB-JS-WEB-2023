namespace P01_StudentSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Student
    {
        public Student()
        {
            this.Homeworks = new HashSet<Homework>();

            this.StudentsCourses = new HashSet<StudentCourse>();
        }

        [Key]
        public int StudentId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        [Required]
        public DateTime RegisteredOn { get; set; }

        public DateTime? Birthday { get; set; }

        public virtual ICollection<Homework> Homeworks { get; set; }

        public virtual ICollection<StudentCourse> StudentsCourses { get; set; }
    }
}
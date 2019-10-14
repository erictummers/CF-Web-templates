
namespace EF_codefirst_migration.Context 
{
    public class Student 
    {
        /// <summary>Technical key of a Student</summary>
        public int StudentId { get; set; }
        
        /// <summary>First and last name</summary>
        public string Name { get; set; }
    }
}
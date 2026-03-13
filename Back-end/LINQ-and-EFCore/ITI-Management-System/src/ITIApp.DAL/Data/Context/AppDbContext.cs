using Microsoft.EntityFrameworkCore;

namespace ITIApp.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base() { }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    string connectionString = "Server=.\\SQLEXPRESS;DataBase=SchoolApp;Trusted_Connection=true;TrustServerCertificate=true";
        //    optionsBuilder.UseSqlServer(connectionString);
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            // ── Seed Data ─────────────────────────────────────────────

            modelBuilder.Entity<Department>().HasData(
                new Department { Id = 1, Name = "Computer Science", Location = "Building A" },
                new Department { Id = 2, Name = "Mathematics", Location = "Building B" },
                new Department { Id = 3, Name = "Physics", Location = "Building C" }
            );

            modelBuilder.Entity<Instructor>().HasData(
                new Instructor { Id = 1, FirstName = "Ahmed", LastName = "Ali", Phone = "010-1234-5678", DeptId = 1 },
                new Instructor { Id = 2, FirstName = "Sara", LastName = "Mohamed", Phone = "011-2345-6789", DeptId = 1 },
                new Instructor { Id = 3, FirstName = "Omar", LastName = "Hassan", Phone = "012-3456-7890", DeptId = 2 },
                new Instructor { Id = 4, FirstName = "Nadia", LastName = "Kamal", Phone = "010-4567-8901", DeptId = 3 }
            );

            modelBuilder.Entity<Course>().HasData(
                new Course { Id = 1, Name = "C# Programming", Duration = 40, DepartmentId = 1, InstructorId = 1 },
                new Course { Id = 2, Name = "Data Structures", Duration = 35, DepartmentId = 1, InstructorId = 2 },
                new Course { Id = 3, Name = "Calculus I", Duration = 45, DepartmentId = 2, InstructorId = 3 },
                new Course { Id = 4, Name = "Linear Algebra", Duration = 30, DepartmentId = 2, InstructorId = 3 },
                new Course { Id = 5, Name = "Mechanics", Duration = 40, DepartmentId = 3, InstructorId = 4 }
            );

            modelBuilder.Entity<Student>().HasData(
                new Student { Id = 1, FirstName = "Ali", LastName = "Hassan", Phone = "010-1111-2222" },
                new Student { Id = 2, FirstName = "Mona", LastName = "Ahmed", Phone = "011-2222-3333" },
                new Student { Id = 3, FirstName = "Khaled", LastName = "Ibrahim", Phone = "012-3333-4444" },
                new Student { Id = 4, FirstName = "Yasmine", LastName = "Omar", Phone = "010-4444-5555" },
                new Student { Id = 5, FirstName = "Tarek", LastName = "Samir", Phone = "011-5555-6666" }
            );

            modelBuilder.Entity<StCourses>().HasData(
                new StCourses { CrsId = 1, StId = 1 },
                new StCourses { CrsId = 1, StId = 2 },
                new StCourses { CrsId = 2, StId = 1 },
                new StCourses { CrsId = 2, StId = 3 },
                new StCourses { CrsId = 3, StId = 4 },
                new StCourses { CrsId = 4, StId = 4 },
                new StCourses { CrsId = 4, StId = 5 },
                new StCourses { CrsId = 5, StId = 3 }
            );

            modelBuilder.Entity<CourseSession>().HasData(
                new CourseSession { Id = 1, CrsId = 1, InsId = 1, SessionDate = new DateTime(2024, 9, 2), Title = "Intro to C#" },
                new CourseSession { Id = 2, CrsId = 1, InsId = 1, SessionDate = new DateTime(2024, 9, 9), Title = "OOP Basics" },
                new CourseSession { Id = 3, CrsId = 2, InsId = 2, SessionDate = new DateTime(2024, 9, 3), Title = "Arrays & Lists" },
                new CourseSession { Id = 4, CrsId = 3, InsId = 3, SessionDate = new DateTime(2024, 9, 4), Title = "Limits" },
                new CourseSession { Id = 5, CrsId = 4, InsId = 3, SessionDate = new DateTime(2024, 9, 5), Title = "Vectors" },
                new CourseSession { Id = 6, CrsId = 5, InsId = 4, SessionDate = new DateTime(2024, 9, 6), Title = "Newton's Laws" }
            );

            modelBuilder.Entity<CourseSessionAttendance>().HasData(
                new CourseSessionAttendance { Id = 1, CrsSessionId = 1, StId = 1, Grade = 90, Notes = "Excellent" },
                new CourseSessionAttendance { Id = 2, CrsSessionId = 1, StId = 2, Grade = 75, Notes = "Good" },
                new CourseSessionAttendance { Id = 3, CrsSessionId = 2, StId = 1, Grade = 85, Notes = "Very Good" },
                new CourseSessionAttendance { Id = 4, CrsSessionId = 3, StId = 1, Grade = 70, Notes = null },
                new CourseSessionAttendance { Id = 5, CrsSessionId = 3, StId = 3, Grade = 95, Notes = "Top scorer" },
                new CourseSessionAttendance { Id = 6, CrsSessionId = 4, StId = 4, Grade = 80, Notes = null },
                new CourseSessionAttendance { Id = 7, CrsSessionId = 5, StId = 5, Grade = 88, Notes = "Good effort" },
                new CourseSessionAttendance { Id = 8, CrsSessionId = 6, StId = 3, Grade = 100, Notes = "Absent" }
            );

            // ── Relationship 1: Instructor works to Department
            modelBuilder.Entity<Instructor>()
                .HasOne(i => i.Department)
                .WithMany(d => d.Instuctors)
                .HasForeignKey(i => i.DeptId)
                .OnDelete(DeleteBehavior.Restrict);

            // ── Relationship 2: Department has one Manager
            modelBuilder.Entity<Department>()
                .HasOne(d => d.Manager)
                .WithMany()
                .HasForeignKey(d => d.ManagerId)
                .OnDelete(DeleteBehavior.Restrict);

            // ── Course → Instructor ───────────────────────────────────
            modelBuilder.Entity<Course>()
                .HasOne(c => c.Instructor)
                .WithMany(i => i.Courses)
                .HasForeignKey(c => c.InstructorId)
                .OnDelete(DeleteBehavior.Restrict);  

            // ── CourseSession → Instructor ────────────────────────────
            modelBuilder.Entity<CourseSession>()
                .HasOne(cs => cs.Instructor)
                .WithMany(i => i.CourseSessions)
                .HasForeignKey(cs => cs.InsId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Course>().HasQueryFilter(c => !c.IsDeleted);
            modelBuilder.Entity<StCourses>().HasQueryFilter(stCrs => !stCrs.IsDeleted);
            modelBuilder.Entity<CourseSession>().HasQueryFilter(cs => !cs.IsDeleted);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }

        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<StCourses> StCourses { get; set; }
        public virtual DbSet<Instructor> Instructors { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<CourseSession> CourseSessios { get; set; }
        public virtual DbSet<CourseSessionAttendance> CourseSessionAttendances { get; set; }
    }
}

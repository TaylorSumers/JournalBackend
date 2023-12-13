using Journal.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Journal.Application.Interfaces
{
    public interface IJournalDbContext
    {
        DbSet<Group> Groups { get; set; }

        DbSet<Lesson> Lessons { get; set; }

        DbSet<Mark> Marks { get; set; }

        DbSet<Speciality> Specialities { get; set; }

        DbSet<Student> Students { get; set; }

        DbSet<StudentLesson> StudentLessons { get; set; }

        DbSet<Subject> Subjects { get; set; }

        DbSet<Teacher> Teachers { get; set; }

        DbSet<TeacherSubject> TeacherSubjects { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}

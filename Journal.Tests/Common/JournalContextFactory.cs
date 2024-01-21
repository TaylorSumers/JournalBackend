using Journal.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Journal.Tests.Common
{
    internal class JournalContextFactory
    {
        public static Guid studentLessonIdForUpdate = Guid.NewGuid();

        public static Guid groupId = Guid.Parse("E5727CA4-C745-4DD7-BFCB-3CFA5204684F");
        public static Guid subjectId = Guid.Parse("E05AFCE6-6E78-4242-8FCE-9E11166A26F8");
        public static Guid teacherId = Guid.Parse("A491FF83-9D0A-4789-AA17-A539EEFE7FE9");


        public static JournalDbContext Create()
        {
            var options = new DbContextOptionsBuilder<JournalDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new JournalDbContext(options);
            context.Database.EnsureCreated();
            context.StudentLessons.AddRange(
                new StudentLesson
                {
                    Id = studentLessonIdForUpdate,
                    MarkId = Guid.Parse("b13e6810-878b-45f2-b804-70d6498d7788")
                },
                new StudentLesson
                {
                    Id = Guid.NewGuid(),
                    Student = new Student 
                    {
                        Id = Guid.NewGuid(),
                        Name = "name1",
                        Surname = "surname1",
                        GroupId = groupId 
                    },
                    Lesson = new Lesson
                    {
                        Id = Guid.NewGuid(),
                        Date = DateTime.Today,
                        SubjectId = subjectId,
                        TeacherId = teacherId
                    }
                },
                new StudentLesson
                {
                    Id = Guid.NewGuid(),
                    Student = new Student
                    {
                        Id = Guid.NewGuid(),
                        Name = "name2",
                        Surname = "surname2",
                        GroupId = groupId
                    },
                    Lesson = new Lesson
                    {
                        Id = Guid.NewGuid(),
                        Date = DateTime.Today,
                        SubjectId = subjectId,
                        TeacherId = teacherId
                    }
                }
            );
            context.SaveChanges();
            return context;
        }

        public static void Destroy(JournalDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}

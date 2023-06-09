﻿using HTD.DataAccess.EntityTypeConfigurations;
using HTD.DataEntities;
using System;
using System.Data.Entity;

namespace HTD.DataAccess.DbContexts
{
    internal class MainDbContext : DbContext, IDisposable
    {
        public MainDbContext(string connectionString)
            : base(connectionString)
        {
        }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Group> Groups { get; set; }

        public DbSet<Lesson> Lessons { get; set; }

        public DbSet<Pupil> Pupils { get; set; }

        public DbSet<PupilGroup> PupilGroups { get; set; }

        public DbSet<Teacher> Teachers { get; set; }

        public DbSet<TeacherCourse> TeacherCourses { get; set; }

        public DbSet<CourseType> CourseTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CourseConfiguration());
            modelBuilder.Configurations.Add(new GroupConfiguration());
            modelBuilder.Configurations.Add(new LessonConfiguration());
            modelBuilder.Configurations.Add(new PupilConfiguration());
            modelBuilder.Configurations.Add(new PupilGroupConfiguration());
            modelBuilder.Configurations.Add(new TeacherConfiguration());
            modelBuilder.Configurations.Add(new TeacherCourseConfiguration());
            modelBuilder.Configurations.Add(new CourseTypeConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}

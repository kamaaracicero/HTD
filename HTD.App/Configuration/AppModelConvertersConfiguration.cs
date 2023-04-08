﻿using HTD.BusinessLogic.ModelConverters;
using HTD.BusinessLogic.Models;
using HTD.DataEntities;

namespace HTD.App.Configuration
{
    internal static class AppModelConvertersConfiguration
    {
        static AppModelConvertersConfiguration()
        {
            AddCourseTypeConverter = new CourseTypeModelConverter();
            AddTeacherConverter = new TeacherModelConverter();
            AddPupilConverter = new PupilModelConverter();
        }

        public static IModelConverter<CourseModel, Course> AddCourseConverter { get; }

        public static IModelConverter<CourseTypeModel, CourseType> AddCourseTypeConverter { get; }

        public static IModelConverter<GroupModel, Group> AddGroupConverter { get; }

        public static IModelConverter<LessonModel, Lesson> AddLessonConverter { get; }

        public static IModelConverter<PupilModel, Pupil> AddPupilConverter { get; }

        public static IModelConverter<TeacherModel, Teacher> AddTeacherConverter { get; }
    }
}

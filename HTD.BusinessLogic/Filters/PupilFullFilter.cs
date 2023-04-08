﻿using HTD.BusinessLogic.DataSearchs;
using HTD.BusinessLogic.Filters.Settings;
using HTD.DataEntities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HTD.BusinessLogic.Filters
{
    internal class PupilFullFilter : IFilter<Pupil>
    {
        public IEnumerable<Pupil> Filter(IEnumerable<Pupil> values, IFilterSettings<Pupil> settings)
        {
            IEnumerable<Pupil> res = null;
            var config = settings as PupilsFullFilterSettings;
            if (config != null)
            {
                res = values.Where(p => p.IsExpelled == false);
                res = FilterByName(config, res);
                res = FilterByTeacherName(config, res);
                res = FilterByPayment(config, res);
                res = FilterBySelectedGroup(config, res);
                res = FilterBySelectedCourseType(config, res);
            }
            return res;
        }

        private IEnumerable<Pupil> FilterByName(PupilsFullFilterSettings settings, IEnumerable<Pupil> pupils)
        {
            if (string.IsNullOrEmpty(settings.PupilNameTB))
                return pupils;
            else
                return pupils.Where(p => p.Name.StartsWith(settings.PupilNameTB, StringComparison.OrdinalIgnoreCase));
        }

        private IEnumerable<Pupil> FilterByTeacherName(PupilsFullFilterSettings settings, IEnumerable<Pupil> pupils)
        {
            if (string.IsNullOrEmpty(settings.TeacherNameTB))
                return pupils;
            else
            {
                var teachers = settings.Teachers.Where(t =>
                    t.Name.StartsWith(settings.TeacherNameTB, StringComparison.OrdinalIgnoreCase));
                if (teachers.Count() == 0)
                    return new Pupil[0];

                var courses = DependencySearch.FindTeachersCourses(teachers,
                    settings.TeacherCourses, settings.Courses);
                if (courses.Count() == 0)
                    return new Pupil[0];

                var groups = DependencySearch.FindCoursesGroups(courses, settings.Groups);
                if (groups.Count() == 0)
                    return new Pupil[0];

                return DependencySearch.FindGroupsPupils(groups, settings.PupilGroups, pupils);
            }
        }

        private IEnumerable<Pupil> FilterByPayment(PupilsFullFilterSettings settings, IEnumerable<Pupil> pupils)
        {
            if (settings.PaymentTrueCB && settings.PaymentFalseCB)
                return pupils;
            else if (settings.PaymentTrueCB && !settings.PaymentFalseCB)
            {
                var groups = settings.Groups.Where(g => g.Payment == true);
                return DependencySearch.FindGroupsPupils(groups, settings.PupilGroups, pupils);
            }
            else if (!settings.PaymentTrueCB && settings.PaymentFalseCB)
            {
                var groups = settings.Groups.Where(g => g.Payment == false);
                return DependencySearch.FindGroupsPupils(groups, settings.PupilGroups, pupils);
            }
            else
                return new Pupil[0];
        }

        private IEnumerable<Pupil> FilterBySelectedGroup(PupilsFullFilterSettings settings, IEnumerable<Pupil> pupils)
        {
            if (settings.SelectedGroupCB == null)
                return pupils;
            else
            {
                var group = settings.Groups.FirstOrDefault(g => g.Id == settings.SelectedGroupCB.Id);
                return DependencySearch.FindGroupPupils(group, settings.PupilGroups, pupils);
            }
        }

        private IEnumerable<Pupil> FilterBySelectedCourseType(PupilsFullFilterSettings settings,
            IEnumerable<Pupil> pupils)
        {
            if (settings.SelectedGroupCB == null)
                return pupils;
            else
            {
                var courses = settings.Courses.Where(c => c.TypeId == settings.SelectedCourseTypeCB.Id);

                var groups = DependencySearch.FindCoursesGroups(courses, settings.Groups);
                if (groups.Count() == 0)
                    return new Pupil[0];

                return DependencySearch.FindGroupsPupils(groups, settings.PupilGroups, pupils);
            }
        }
    }
}

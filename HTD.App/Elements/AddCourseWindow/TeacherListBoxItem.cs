﻿using HTD.DataEntities;
using System.Windows.Controls;

namespace HTD.App.Elements.AddCourseWindow
{
    internal class TeacherListBoxItem : ListBoxItem
    {
        public TeacherListBoxItem(Teacher instance)
            : base()
        {
            Instance = instance;

            Content = instance.Name;
        }

        public Teacher Instance { get; }
    }
}

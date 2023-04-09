﻿using HTD.DataEntities;
using System.Windows.Controls;

namespace HTD.App.Elements.GroupsMonitoring
{
    internal class PupilListBoxItem : ListBoxItem
    {
        public PupilListBoxItem(Pupil instance)
             : base()
        {
            Instance = instance;

            Content = instance.Name;
        }

        public Pupil Instance { get; }
    }
}

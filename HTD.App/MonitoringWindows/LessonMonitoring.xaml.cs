using HTD.App.Elements.ListBoxItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HTD.App.MonitoringWindows
{
    public partial class LessonMonitoring : Window
    {
        public LessonMonitoring()
        {
            InitializeComponent();

            ConflictLessonsLB.ItemsSource = new List<Temp>
            {
                new Temp
                {
                    Time = "14.40-15-40",
                    Lesson1 = "Разработка на Питоне",
                    Lesson2 = "Робототехника",
                },
                new Temp
                {
                    Time = "14.40-15-40",
                    Lesson1 = "Разработка на Питоне",
                    Lesson2 = "Робототехника",
                },
            };
            ConflictLessonsLB.Items.Refresh();

            MondayLB.ItemsSource = new ScheduleListBoxItem[]
            {
                new ScheduleListBoxItem(null, null, null, null)
                {
                    Time = "14:15-16:45",
                    Course = "Разработка на питоне",
                    Teacher = "Оленик Кирилл Александрович",
                    Group = "Группа маленьких дошколят",
                    Place = "104 кабинет",
                },
                new ScheduleListBoxItem(null, null, null, null)
                {
                    Time = "14:15-16:45",
                    Course = "Разработка на питоне",
                    Teacher = "Оленик Кирилл Александрович",
                    Group = "Группа маленьких дошколят",
                    Place = "104 кабинет",
                },
            };
            MondayLB.Items.Refresh();
        }

        private class Temp
        {
            public string Time { get; set; }

            public string Lesson1 { get; set; }

            public string Lesson2 { get; set; }
        }
    }
}

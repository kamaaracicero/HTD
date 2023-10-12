using HTD.App.AddWindows;
using HTD.App.Configuration;
using HTD.App.Elements.LessonMonitoring;
using HTD.BusinessLogic.Filters;
using HTD.BusinessLogic.Filters.Settings;
using HTD.BusinessLogic.Services;
using HTD.DataEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace HTD.App.MonitoringWindows
{
    public partial class LessonMonitoring : Window
    {
        private readonly IService<Group> _groupService;
        private readonly IService<Teacher> _teacherService;
        private readonly IService<Lesson> _lessonService;
        private readonly IService<Course> _courseService;

        private readonly IFilter<Lesson> _filter;

        public LessonMonitoring()
        {
            _groupService = AppConfiguration.GroupService;
            _teacherService = AppConfiguration.TeacherService;
            _lessonService = AppConfiguration.LessonService;
            _courseService = AppConfiguration.CourseService;

            _filter = AppConfiguration.LessonFilter;

            InitializeComponent();
        }

        public List<Group> Groups { get; set; }

        public List<Teacher> Teachers { get; set; }

        public List<Lesson> Lessons { get; set; }

        public List<Course> Courses { get; set; }

        private async void Window_Initialized(object sender, System.EventArgs e)
        {
            await LoadGroupsData();
            await LoadTeachersData();
            await LoadLessonsData();
            await LoadCoursesData();

            UpdateTeachersComboBoxView();
            UpdateGroupsComboBoxView();
            UpdateLessonsView();
        }

        private async void RefreshB_Click(object sender, RoutedEventArgs e)
        {
            await LoadGroupsData();
            await LoadTeachersData();
            await LoadLessonsData();
            await LoadCoursesData();

            UpdateTeachersComboBoxView();
            UpdateGroupsComboBoxView();
            UpdateLessonsView();
        }

        private void UpdateLessonsView()
        {
            if (GroupsCB.SelectedItem == null || TeachersCB.SelectedItem == null)
                return;

            var filteredLessons = _filter.Filter(Lessons, new LessonFilterSettings
            {
                SelectedTeacherCB = (TeachersCB.SelectedItem as TeacherComboBoxItem).Instance,
                SelectedGroupCB = (GroupsCB.SelectedItem as GroupComboBoxItem).Instance,
            });

            CheckConflictLessons(filteredLessons);

            MondayLB.ItemsSource = GetLessonsForDay(Day.Monday, filteredLessons);
            MondayLB.Items.Refresh();

            TuesdayLB.ItemsSource = GetLessonsForDay(Day.Tuesday, filteredLessons);
            TuesdayLB.Items.Refresh();

            WednesdayLB.ItemsSource = GetLessonsForDay(Day.Wednesday, filteredLessons);
            WednesdayLB.Items.Refresh();

            ThursdayLB.ItemsSource = GetLessonsForDay(Day.Thursday, filteredLessons);
            ThursdayLB.Items.Refresh();

            FridayLB.ItemsSource = GetLessonsForDay(Day.Friday, filteredLessons);
            FridayLB.Items.Refresh();

            SaturdayLB.ItemsSource = GetLessonsForDay(Day.Saturday, filteredLessons);
            SaturdayLB.Items.Refresh();

            SundayLB.ItemsSource = GetLessonsForDay(Day.Sunday, filteredLessons);
            SundayLB.Items.Refresh();
        }

        private void CheckConflictLessons(IEnumerable<Lesson> filteredLessons)
        {
            List<ConflictLessonListBoxItem> source = new List<ConflictLessonListBoxItem>();
            for (int i = 0; i < Lessons.Count - 1; i++)
            {
                for (int j = i + 1; j < Lessons.Count; j++)
                {
                    if (Lessons[i].Id != Lessons[j].Id
                        && Lessons[i].TeacherId == Lessons[j].TeacherId
                        && Lessons[i].Day == Lessons[j].Day
                        && CheckTime(Lessons[i], Lessons[j]))
                    {
                        source.Add(new ConflictLessonListBoxItem(Lessons[i], Lessons[j],
                            Groups.FirstOrDefault(g => Lessons[i].GroupId == g.Id),
                            Groups.FirstOrDefault(g => Lessons[j].GroupId == g.Id),
                            Teachers.FirstOrDefault(t => Lessons[i].TeacherId == t.Id),
                            Teachers.FirstOrDefault(t => Lessons[j].TeacherId == t.Id)));
                    }
                    else if (Lessons[i].Id != Lessons[j].Id
                        && Lessons[i].GroupId == Lessons[j].GroupId
                        && Lessons[i].Day == Lessons[j].Day
                        && CheckTime(Lessons[i], Lessons[j]))
                    {
                        source.Add(new ConflictLessonListBoxItem(Lessons[i], Lessons[j],
                            Groups.FirstOrDefault(g => Lessons[i].GroupId == g.Id),
                            Groups.FirstOrDefault(g => Lessons[j].GroupId == g.Id),
                            Teachers.FirstOrDefault(t => Lessons[i].TeacherId == t.Id),
                            Teachers.FirstOrDefault(t => Lessons[j].TeacherId == t.Id)));
                    }
                }
            }

            ConflictLessonsLB.ItemsSource = source;
            ConflictLessonsLB.Items.Refresh();
        }

        private bool CheckTime(Lesson lesson1, Lesson lesson2)
        {
            if ((lesson1.Begin < lesson2.End)
             && (lesson2.Begin < lesson1.End))
                return true;
            else
                return false;
        }

        private async void AddLessonB_Click(object sender, RoutedEventArgs e)
        {
            AddLessonWindow window = new AddLessonWindow();
            if (window.ShowDialog().Value)
            {
                var res = await _lessonService.Insert(window.Value);
                if (res.Successfully)
                {
                    await LoadLessonsData();
                    UpdateLessonsView();
                }
                else
                {
                    MessageBox.Show("Не удалось добавить занятие", "Ошибка");
                    await LoadLessonsData();
                    UpdateLessonsView();
                }
            }
        }

        private async Task DeleteLesson(Lesson lesson)
        {
            if (MessageBox.Show($"Удалить выбранное занятие?", "Предупреждение",
                MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                var res = await _lessonService.Delete(lesson);
                if (res.Successfully)
                {
                    await LoadLessonsData();
                    UpdateLessonsView();
                }
                else
                {
                    MessageBox.Show("Не удалось удалить занятие", "Ошибка");
                    await LoadLessonsData();
                    UpdateLessonsView();
                }
            }
        }

        private IEnumerable<LessonListBoxItem> GetLessonsForDay(Day day, IEnumerable<Lesson> filteredLessons)
        {
            var lessons = filteredLessons.Where(l => l.Day == (int)day);
            List<LessonListBoxItem> source = new List<LessonListBoxItem>();
            foreach (var lessson in lessons)
            {
                var group = Groups.FirstOrDefault(g => lessson.GroupId == g.Id);
                var course = group == null ? null : Courses.FirstOrDefault(c => group.CourseId == c.Id);
                var teacher = Teachers.FirstOrDefault(t => t.Id == lessson.TeacherId);
                source.Add(new LessonListBoxItem(lessson, course, teacher, group));
            }

            return source.OrderBy(s => s.Instance.Begin).ToList(); ;
        }

        private void UpdateTeachersComboBoxView()
        {
            List<TeacherComboBoxItem> items = new List<TeacherComboBoxItem>
            {
                new TeacherComboBoxItem(null, "Без выбора"),
            };
            items.AddRange(Teachers.Select(t => new TeacherComboBoxItem(t)));

            TeachersCB.ItemsSource = items;
            TeachersCB.Items.Refresh();
            TeachersCB.SelectedIndex = 0;
        }

        private void UpdateGroupsComboBoxView()
        {
            List<GroupComboBoxItem> items = new List<GroupComboBoxItem>
            {
                new GroupComboBoxItem(null, "Без выбора"),
            };
            items.AddRange(Groups.Select(g => new GroupComboBoxItem(g)));

            GroupsCB.ItemsSource = items;
            GroupsCB.Items.Refresh();
            GroupsCB.SelectedIndex = 0;
        }

        private async Task LoadCoursesData()
        {
            var res = await _courseService.Select();
            if (!res.Successfully)
            {
                MessageBox.Show("Ошибка в загрузке данных кружков", "Ошибка");
                return;
            }
            else
            {
                Courses = res.Value.Where(c => c.IsActive == true).ToList();
            }
        }

        private async Task LoadGroupsData()
        {
            var res = await _groupService.Select();
            if (!res.Successfully)
            {
                MessageBox.Show("Ошибка в загрузке данных групп", "Ошибка");
                return;
            }
            else
            {
                Groups = res.Value.Where(g => g.IsActive == true).ToList();
            }
        }

        private async Task LoadTeachersData()
        {
            var res = await _teacherService.Select();
            if (!res.Successfully)
            {
                MessageBox.Show("Ошибка в загрузке данных преподавателей", "Ошибка");
                return;
            }
            else
            {
                Teachers = res.Value.ToList();
            }
        }

        private async Task LoadLessonsData()
        {
            var res = await _lessonService.Select();
            if (!res.Successfully)
            {
                MessageBox.Show("Ошибка в загрузке данных занятий", "Ошибка");
                return;
            }
            else
            {
                Lessons = res.Value.ToList();
            }
        }

        private void GroupsCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
            => UpdateLessonsView();

        private void TeachersCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
            => UpdateLessonsView();

        private async void DeleteMondayLessonMI_Click(object sender, RoutedEventArgs e)
        {
            if (MondayLB.SelectedItem == null)
                return;

            var temp = MondayLB.SelectedItem as LessonListBoxItem;
            await DeleteLesson(temp.Instance);
        }

        private async void DeleteTuesdayLessonMI_Click(object sender, RoutedEventArgs e)
        {
            if (TuesdayLB.SelectedItem == null)
                return;

            var temp = TuesdayLB.SelectedItem as LessonListBoxItem;
            await DeleteLesson(temp.Instance);
        }

        private async void DeleteWednesdayLessonMI_Click(object sender, RoutedEventArgs e)
        {
            if (WednesdayLB.SelectedItem == null)
                return;

            var temp = WednesdayLB.SelectedItem as LessonListBoxItem;
            await DeleteLesson(temp.Instance);
        }

        private async void DeleteThursdayLessonMI_Click(object sender, RoutedEventArgs e)
        {
            if (ThursdayLB.SelectedItem == null)
                return;

            var temp = ThursdayLB.SelectedItem as LessonListBoxItem;
            await DeleteLesson(temp.Instance);
        }

        private async void DeleteFridayLessonMI_Click(object sender, RoutedEventArgs e)
        {
            if (FridayLB.SelectedItem == null)
                return;

            var temp = FridayLB.SelectedItem as LessonListBoxItem;
            await DeleteLesson(temp.Instance);
        }

        private async void DeleteSaturdayLessonMI_Click(object sender, RoutedEventArgs e)
        {
            if (SaturdayLB.SelectedItem == null)
                return;

            var temp = SaturdayLB.SelectedItem as LessonListBoxItem;
            await DeleteLesson(temp.Instance);
        }

        private async void DeleteSundayLessonMI_Click(object sender, RoutedEventArgs e)
        {
            if (SundayLB.SelectedItem == null)
                return;

            var temp = SundayLB.SelectedItem as LessonListBoxItem;
            await DeleteLesson(temp.Instance);
        }

        private void CloseB_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}

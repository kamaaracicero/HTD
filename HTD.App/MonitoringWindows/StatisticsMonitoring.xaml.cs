using HTD.App.Configuration;
using HTD.App.Elements.StatisticsMonitoring;
using HTD.BusinessLogic.DataSearchs;
using HTD.BusinessLogic.Services;
using HTD.DataEntities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace HTD.App.MonitoringWindows
{
    public partial class StatisticsMonitoring : Window
    {
        public readonly IService<Pupil> _pupilService;
        public readonly IService<PupilGroup> _pupilGroupService;
        public readonly IService<Group> _groupService;
        public readonly IService<Course> _courseService;
        public readonly IService<CourseType> _courseTypeService;
        public readonly IService<Teacher> _teacherService;

        public StatisticsMonitoring()
        {
            _pupilService = AppConfiguration.PupilService;
            _pupilGroupService = AppConfiguration.PupilGroupService;
            _groupService = AppConfiguration.GroupService;
            _courseService = AppConfiguration.CourseService;
            _courseTypeService = AppConfiguration.CourseTypeService;
            _teacherService = AppConfiguration.TeacherService;

            InitializeComponent();
        }

        public List<Pupil> Pupils { get; set; }

        public List<PupilGroup> PupilGroups { get; set; }

        public List<Group> Groups { get; set; }

        public List<Course> Courses { get; set; }

        public List<CourseType> CourseTypes { get; set; }

        public List<Teacher> Teachers { get; set; }

        private async void Window_Initialized(object sender, System.EventArgs e)
        {
            await LoadPupilsData();
            await LoadPupilGroupsData();
            await LoadGroupsData();
            await LoadCoursesData();
            await LoadCourseTypesData();
            await LoadTeachersData();

            UpdateTotalStatisticsView();
            UpdateCourseTypesView();
            UpdatePupilsView();
            UpdatePupilInfoView();
            UpdateGroupsView();
            UpdateGroupInfoView();
            UpdateCoursesView();
            UpdateCourseInfoView();
        }

        private async void RefreshB_Click(object sender, RoutedEventArgs e)
        {
            await LoadPupilsData();
            await LoadPupilGroupsData();
            await LoadGroupsData();
            await LoadCoursesData();
            await LoadCourseTypesData();
            await LoadTeachersData();

            UpdateTotalStatisticsView();
            UpdateCourseTypesView();
            UpdateCourseTypeInfoView();
            UpdatePupilsView();
            UpdatePupilInfoView();
            UpdateGroupsView();
            UpdateGroupInfoView();
            UpdateCoursesView();
            UpdateCourseInfoView();
        }

        public void UpdateTotalStatisticsView()
        {
            TotalPupilCountTB.Text = Pupils.Count.ToString();
            TotalTeachersCountTB.Text = Teachers.Count.ToString();
            TotalCoursesCountTB.Text = Courses.Count.ToString();
            TotalGroupsCountTB.Text = Groups.Count.ToString();
        }

        private void UpdateCoursesView()
        {
            CoursesLB.ItemsSource = Courses.Where(c => !c.IsActive)
                .Select(c => new CourseListBoxItem(c));
            CoursesLB.Items.Refresh();
        }

        private void UpdatePupilsView()
        {
            PupilsLB.ItemsSource = Pupils.Where(p => p.IsExpelled)
                .Select(p => new PupilListBoxItem(p));
            PupilsLB.Items.Refresh();
        }

        private void UpdateGroupsView()
        {
            GroupsLB.ItemsSource = Groups.Where(g => !g.IsActive)
                .Select(g => new GroupListBoxItem(g));
            GroupsLB.Items.Refresh();
        }

        private void UpdateCourseTypesView()
        {
            CourseTypesLB.ItemsSource = CourseTypes
                .Select(c => new CourseTypeListBoxItem(c));
            CourseTypesLB.Items.Refresh();
        }

        private void UpdatePupilInfoView()
        {
            PupilGroupsCountTB.Text = string.Empty;
            PupilNameTB.Text = string.Empty;
            PupilParentNameTB.Text = string.Empty;
            PupilContactPhoneTB.Text = string.Empty;
        }

        private void UpdatePupilInfoView(Pupil pupil)
        {
            PupilGroupsCountTB.Text = PupilGroups
                .Where(p => p.PupilId == pupil.Id).Count().ToString();
            PupilNameTB.Text = pupil.Name;
            PupilParentNameTB.Text = pupil.ParentName;
            PupilContactPhoneTB.Text = pupil.ContactPhone;
        }

        private void UpdateGroupInfoView()
        {
            GroupPupilCountTB.Text = string.Empty;
            GroupNameTB.Text = string.Empty;
            GroupYearTB.Text = string.Empty;
            GroupPaymentTB.Text = string.Empty;
            GroupCourseIsActiveTB.Text = string.Empty;
        }

        private void UpdateGroupInfoView(Group group)
        {
            GroupPupilCountTB.Text = PupilGroups.Where(p => p.GroupId == group.Id).Count().ToString();
            GroupNameTB.Text = group.Name;
            GroupYearTB.Text = group.Year.ToString();
            GroupPaymentTB.Text = group.Payment ? "Да" : "Нет";
            GroupCourseIsActiveTB.Text = Courses
                .First(c => c.Id == group.CourseId).IsActive ? "Нет" : "Да";
        }

        private void UpdateCourseInfoView()
        {
            CourseGroupsCountTB.Text = string.Empty;
        }

        private void UpdateCourseInfoView(Course course)
        {
            CourseGroupsCountTB.Text = Groups.Where(g => g.CourseId == course.Id).Count().ToString();
        }

        private void UpdateCourseTypeInfoView()
        {
            CourseTypeCoursesCountTB.Text = string.Empty;
        }

        private void UpdateCourseTypeInfoView(CourseType courseType)
        {
            CourseTypeCoursesCountTB.Text = Courses
                .Where(c => c.TypeId == courseType.Id).Count().ToString();
        }

        private async Task LoadPupilsData()
        {
            var res = await _pupilService.Select();
            if (!res.Successfully)
            {
                MessageBox.Show("Ошибка в загрузке данных учеников", "Ошибка");
                return;
            }
            else
            {
                Pupils = res.Value.ToList();
            }
        }

        private async Task LoadPupilGroupsData()
        {
            var res = await _pupilGroupService.Select();
            if (!res.Successfully)
            {
                MessageBox.Show("Ошибка в загрузке зависимостей", "Ошибка");
                return;
            }
            else
            {
                PupilGroups = res.Value.ToList();
            }
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
                Courses = res.Value.ToList();
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
                Groups = res.Value.ToList();
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

        private async Task LoadCourseTypesData()
        {
            var res = await _courseTypeService.Select();
            if (!res.Successfully)
            {
                MessageBox.Show("Ошибка в загрузке данных типов кружков", "Ошибка");
                return;
            }
            else
            {
                CourseTypes = res.Value.ToList();
            }
        }

        private void PupilsLB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (PupilsLB.SelectedItem == null)
                return;

            var instance = (PupilsLB.SelectedItem as PupilListBoxItem).Instance;
            UpdatePupilInfoView(instance);
        }

        private void GroupsLB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (GroupsLB.SelectedItem == null)
                return;

            var instance = (GroupsLB.SelectedItem as GroupListBoxItem).Instance;
            UpdateGroupInfoView(instance);
        }

        private void CourseTypesLB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CourseTypesLB.SelectedItem == null)
                return;

            var instance = (CourseTypesLB.SelectedItem as CourseTypeListBoxItem).Instance;
            UpdateCourseTypeInfoView(instance);
        }

        private void CoursesLB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CoursesLB.SelectedItem == null)
                return;

            var instance = (CoursesLB.SelectedItem as CourseListBoxItem).Instance;
            UpdateCourseInfoView(instance);
        }

        private async void RestorePupilB_Click(object sender, RoutedEventArgs e)
        {
            if (PupilsLB.SelectedItem == null)
                return;

            var pupil = (PupilsLB.SelectedItem as PupilListBoxItem).Instance;
            if (MessageBox.Show("Восстановить выбранного ученика?", "Предупреждение", MessageBoxButton.YesNo)
                == MessageBoxResult.Yes)
            {
                pupil.IsExpelled = false;
                var res = await _pupilService.Update(pupil);
                if (res.Successfully)
                {
                    await LoadPupilsData();
                    UpdatePupilsView();
                }
                else
                {
                    MessageBox.Show("Не удалось восстановить учащегося", "Ошибка");
                    await LoadPupilsData();
                    UpdatePupilsView();
                }
            }
        }

        private async void DeletePupilB_Click(object sender, RoutedEventArgs e)
        {
            if (PupilsLB.SelectedItem == null)
                return;

            var pupil = (PupilsLB.SelectedItem as PupilListBoxItem).Instance;
            if (MessageBox.Show("Удалить выбранного ученика?", "Предупреждение", MessageBoxButton.YesNo)
                == MessageBoxResult.Yes)
            {
                var res = await _pupilService.Delete(pupil);
                if (res.Successfully)
                {
                    await LoadPupilsData();
                    await LoadPupilGroupsData();
                    UpdatePupilsView();
                }
                else
                {
                    MessageBox.Show("Не удалось удалить учащегося", "Ошибка");
                    await LoadPupilsData();
                    await LoadPupilGroupsData();
                    UpdatePupilsView();
                }
            }
        }

        private async void RestoreGroupB_Click(object sender, RoutedEventArgs e)
        {
            if (GroupsLB.SelectedItem == null)
                return;

            var group = (GroupsLB.SelectedItem as GroupListBoxItem).Instance;
            var course = Courses.First(c => c.Id == group.CourseId);

            if (MessageBox.Show("Восстановить выбранную группу?\n" +
                " Если кружок этой группы был архивирован, то он будет восстановлен",
                "Предупреждение", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                group.IsActive = true;
                course.IsActive = true;
                var groupRes = await _groupService.Update(group);
                var courseRes = await _courseService.Update(course);
                if (!groupRes.Successfully)
                    MessageBox.Show("Не удалось восстановить группу", "Ошибка");
                else if (!courseRes.Successfully)
                    MessageBox.Show("Не удалось восстановить кружок", "Ошибка");

                await LoadGroupsData();
                await LoadCoursesData();
                UpdateGroupsView();
                UpdateCoursesView();
            }
        }

        private async void DeleteGroupB_Click(object sender, RoutedEventArgs e)
        {
            if (GroupsLB.SelectedItem == null)
                return;

            var group = (GroupsLB.SelectedItem as GroupListBoxItem).Instance;
            if (MessageBox.Show("Удалить выбранную группу?", "Предупреждение", MessageBoxButton.YesNo)
                == MessageBoxResult.Yes)
            {
                var res = await _groupService.Delete(group);
                if (res.Successfully)
                {
                    await LoadGroupsData();
                    await LoadPupilGroupsData();
                    UpdateGroupsView();
                }
                else
                {
                    MessageBox.Show("Не удалось удалить группу", "Ошибка");
                    await LoadGroupsData();
                    await LoadPupilGroupsData();
                    UpdateGroupsView();
                }
            }
        }

        private async void FullDeleteGroupB_Click(object sender, RoutedEventArgs e)
        {
            if (GroupsLB.SelectedItem == null)
                return;

            var group = (GroupsLB.SelectedItem as GroupListBoxItem).Instance;
            if (MessageBox.Show("Удалить группу вместе с учениками?", "Предупреждение",
                MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                var pupils = DependencyHelper.FindGroupPupils(group, PupilGroups, Pupils);
                var flag = false;
                foreach (var pupil in pupils)
                {
                    var pupilRes = await _pupilService.Delete(pupil);
                    if (!pupilRes.Successfully)
                        flag = true;
                }
                if (flag)
                    MessageBox.Show("Не удалось удалить некоторых учеников", "Ошибка");

                var groupRes = await _groupService.Delete(group);
                if (!groupRes.Successfully)
                    MessageBox.Show("Не удалось удалить группу", "Ошибка");

                await LoadPupilsData();
                await LoadGroupsData();
                await LoadPupilGroupsData();
                UpdateGroupsView();
                UpdatePupilsView();
            }
        }

        private async void RestoreCourseB_Click(object sender, RoutedEventArgs e)
        {
            if (CoursesLB.SelectedItem == null)
                return;

            var course = (CoursesLB.SelectedItem as CourseListBoxItem).Instance;
            if (MessageBox.Show("Восстановить выбранный кружок?", "Предупреждение", MessageBoxButton.YesNo)
                == MessageBoxResult.Yes)
            {
                course.IsActive = true;
                var res = await _courseService.Update(course);
                if (res.Successfully)
                {
                    await LoadCoursesData();
                    UpdateCoursesView();
                }
                else
                {
                    MessageBox.Show("Не удалось восстановить кружок", "Ошибка");
                    await LoadCoursesData();
                    UpdateCoursesView();
                }
            }
        }

        private async void DeleteCourseB_Click(object sender, RoutedEventArgs e)
        {
            if (CoursesLB.SelectedItem == null)
                return;

            var course = (CoursesLB.SelectedItem as CourseListBoxItem).Instance;
            if (MessageBox.Show("Удалить выбранный кружок?\n" +
                " Удаление кружка приведет к удалению всех групп," +
                " которые были к нему привязаны", "Предупреждение",
                MessageBoxButton.YesNo)
                == MessageBoxResult.Yes)
            {
                var res = await _courseService.Delete(course);
                if (res.Successfully)
                {
                    await LoadCoursesData();
                    await LoadGroupsData();
                    UpdateCoursesView();
                    UpdateGroupsView();
                }
                else
                {
                    MessageBox.Show("Не удалось удалить кружок", "Ошибка");
                    await LoadCoursesData();
                    await LoadGroupsData();
                    UpdateCoursesView();
                    UpdateGroupsView();
                }
            }
        }

        private async void DeleteCourseTypeB_Click(object sender, RoutedEventArgs e)
        {
            if (CourseTypesLB.SelectedItem == null)
                return;

            var courseType = (CourseTypesLB.SelectedItem as CourseTypeListBoxItem).Instance;
            if (MessageBox.Show("Удалить выбранный тип кружка?\n" +
                " Удаление типа кружка приведет к удаление всех кружков," +
                " которые были к нему привязаны", "Предупреждение",
                MessageBoxButton.YesNo)
                == MessageBoxResult.Yes)
            {
                var res = await _courseTypeService.Delete(courseType);
                if (res.Successfully)
                {
                    await LoadCourseTypesData();
                    await LoadCoursesData();
                    UpdateCourseTypesView();
                    UpdateCoursesView();
                }
                else
                {
                    MessageBox.Show("Не удалось удалить тип кружка", "Ошибка");
                    await LoadCourseTypesData();
                    await LoadCoursesData();
                    UpdateCourseTypesView();
                    UpdateCoursesView();
                }
            }
        }
    }
}

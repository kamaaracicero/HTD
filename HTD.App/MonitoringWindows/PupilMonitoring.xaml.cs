using HTD.App.AddWindows;
using HTD.App.Configuration;
using HTD.App.Elements.PupilMonitoring;
using HTD.App.UpdateWindows;
using HTD.BusinessLogic.DataSearchs;
using HTD.BusinessLogic.Excel;
using HTD.BusinessLogic.Filters;
using HTD.BusinessLogic.Filters.Settings;
using HTD.BusinessLogic.Services;
using HTD.DataEntities;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace HTD.App.MonitoringWindows
{
    public partial class PupilMonitoring : Window
    {
        private readonly IService<Pupil> _pupilService;
        private readonly IService<PupilGroup> _pupilGroupService;
        private readonly IService<Group> _groupService;
        private readonly IService<Course> _courseService;
        private readonly IService<CourseType> _courseTypeService;
        private readonly IService<TeacherCourse> _teacherCourseService;
        private readonly IService<Teacher> _teacherService;

        private readonly IFilter<Pupil> _filter;

        private readonly IExcelParser<Pupil> _excelParser;

        public PupilMonitoring()
        {
            _pupilService = AppConfiguration.PupilService;
            _pupilGroupService = AppConfiguration.PupilGroupService;
            _groupService = AppConfiguration.GroupService;
            _courseService = AppConfiguration.CourseService;
            _courseTypeService = AppConfiguration.CourseTypeService;
            _teacherCourseService = AppConfiguration.TeacherCourseService;
            _teacherService = AppConfiguration.TeacherService;

            _filter = AppConfiguration.PupilFilter;

            _excelParser = AppConfiguration.PupilExcelParser;

            InitializeComponent();
            PupilsDG.BeginningEdit += (s, ss) => ss.Cancel = true;
        }

        public List<Pupil> Pupils { get; set; }
        public List<PupilGroup> PupilGroups { get; set; }
        public List<Group> Groups { get; set; }
        public List<Course> Courses { get; set; }
        public List<CourseType> CourseTypes { get; set; }
        public List<TeacherCourse> TeacherCourses { get; set; }
        public List<Teacher> Teachers { get; set; }

        private async void Window_Initialized(object sender, System.EventArgs e)
        {
            await LoadPupilsData();
            await LoadPupilGroupsData();
            await LoadGroupsData();
            await LoadCoursesData();
            await LoadCourseTypesData();
            await LoadTeacherCoursesData();
            await LoadTeachersData();

            UpdateCourseTypesComboBoxView();
            UpdateGroupsComboBoxView();
            UpdatePupilsView();
        }

        private async void RefreshTableB_Click(object sender, RoutedEventArgs e)
        {
            await LoadPupilsData();
            await LoadPupilGroupsData();
            await LoadGroupsData();
            await LoadCoursesData();
            await LoadCourseTypesData();
            await LoadTeacherCoursesData();
            await LoadTeachersData();

            UpdateCourseTypesComboBoxView();
            UpdateGroupsComboBoxView();
            UpdatePupilsView();
        }

        private void UpdatePupilsView()
        {
            if (GroupsCB.SelectedItem == null || CourseTypesCB.SelectedItem == null)
                return;

            var temp = _filter.Filter(Pupils, new PupilFilterSettings
            {
                PupilNameTB = SearchNameTB.Text,
                TeacherNameTB = SearchTeacherNameTB.Text,
                PaymentTrueCB = PaymentTrueCB.IsChecked.Value,
                PaymentFalseCB = PaymentFalseCB.IsChecked.Value,
                SelectedGroupCB = (GroupsCB.SelectedItem as GroupComboBoxItem).Instance,
                SelectedCourseTypeCB = (CourseTypesCB.SelectedItem as CourseTypeComboBoxItem).Instance,
                Teachers = Teachers,
                TeacherCourses = TeacherCourses,
                Courses = Courses,
                CourseTypes = CourseTypes,
                Groups = Groups,
                PupilGroups = PupilGroups,
            });

            UpdateDetailsView();

            PupilsDG.ItemsSource = temp.Select(t => new PupilDataGridRow(t));
            PupilsDG.Items.Refresh();
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

        private void UpdateCourseTypesComboBoxView()
        {
            List<CourseTypeComboBoxItem> items = new List<CourseTypeComboBoxItem>
            {
                new CourseTypeComboBoxItem(null, "Без выбора"),
            };
            items.AddRange(CourseTypes.Select(c => new CourseTypeComboBoxItem(c)));

            CourseTypesCB.ItemsSource = items;
            CourseTypesCB.Items.Refresh();
            CourseTypesCB.SelectedIndex = 0;
        }

        private void UpdateDetailsView()
        {
            PupilNameTB.Text = string.Empty;
            ParentNameTB.Text = string.Empty;
            ContactPhoneTB.Text = string.Empty;
            PupilCoursesLB.ItemsSource = null;
            PupilCoursesLB.Items.Refresh();
        }

        private void UpdateDetailsView(Pupil pupil)
        {
            PupilNameTB.Text = pupil.Name;
            ParentNameTB.Text = pupil.ParentName;
            ContactPhoneTB.Text = pupil.ContactPhone;
            PupilCoursesLB.ItemsSource = DependencyHelper
                .FindPupilCourses(pupil, PupilGroups, Groups, Courses)
                .Select(p => new CourseListBoxItem(p));
            PupilCoursesLB.Items.Refresh();
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
                Pupils = res.Value.Where(p => p.IsExpelled == false).ToList();
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
                Courses = res.Value.Where(c => c.IsActive == true).ToList();
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

        private async Task LoadTeacherCoursesData()
        {
            var res = await _teacherCourseService.Select();
            if (!res.Successfully)
            {
                MessageBox.Show("Ошибка в загрузке зависимостей", "Ошибка");
                return;
            }
            else
            {
                TeacherCourses = res.Value.ToList();
            }
        }

        private async void AddPupilB_Click(object sender, RoutedEventArgs e)
        {
            AddPupilWindow window = new AddPupilWindow();
            if (window.ShowDialog().Value)
            {
                if (СheckPupilRepetition(window.Value))
                    return;

                var res = await _pupilService.Insert(window.Value);
                if (!res.Successfully)
                {
                    MessageBox.Show("Не удалось добавить ученика", "Ошибка");
                }
                else
                {
                    await LoadPupilsData();
                    UpdatePupilsView();
                }
            }
        }

        private void CloseB_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void SearchNameTB_TextChanged(object sender, TextChangedEventArgs e) => UpdatePupilsView();

        private void SearchTeacherNameTB_TextChanged(object sender, TextChangedEventArgs e) => UpdatePupilsView();

        private void PaymentTrueCB_Click(object sender, RoutedEventArgs e) => UpdatePupilsView();

        private void PaymentFalseCB_Click(object sender, RoutedEventArgs e) => UpdatePupilsView();

        private void GroupsCB_SelectionChanged(object sender, SelectionChangedEventArgs e) => UpdatePupilsView();

        private void CourseTypesCB_SelectionChanged(object sender, SelectionChangedEventArgs e) => UpdatePupilsView();

        private async void UpdatePupilB_Click(object sender, RoutedEventArgs e)
        {
            if (PupilsDG.SelectedItem == null)
                return;

            var pupil = (PupilsDG.SelectedItem as PupilDataGridRow).Instance;
            UpdatePupilWindow window = new UpdatePupilWindow(pupil);
            if (window.ShowDialog().Value)
            {
                var res = await _pupilService.Update(window.Value);
                if (res.Successfully)
                {
                    await LoadPupilsData();
                    UpdatePupilsView();
                }
                else
                {
                    MessageBox.Show("Не удалось редактировать ученика", "Ошибка");
                    await LoadPupilsData();
                    UpdatePupilsView();
                }
            }
        }

        private async void ExpellPupilB_Click(object sender, RoutedEventArgs e)
        {
            if (PupilsDG.SelectedItem == null)
                return;

            var pupil = (PupilsDG.SelectedItem as PupilDataGridRow).Instance;
            if (MessageBox.Show("Отчислить выбранного ученика?", "Предупреждение", MessageBoxButton.YesNo)
                == MessageBoxResult.Yes)
            {
                pupil.IsExpelled = true;
                var res = await _pupilService.Update(pupil);
                if (res.Successfully)
                {
                    await LoadPupilsData();
                    await LoadPupilGroupsData();
                    UpdatePupilsView();
                }
                else
                {
                    MessageBox.Show("Не удалось отчислить учащегося", "Ошибка");
                    await LoadPupilsData();
                    await LoadPupilGroupsData();
                    UpdatePupilsView();
                }
            }
        }

        private void PupilsDG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (PupilsDG.SelectedItem != null)
            {
                var temp = PupilsDG.SelectedItem as PupilDataGridRow;
                UpdateDetailsView(temp.Instance);
            }
        }

        private bool СheckPupilRepetition(Pupil check)
        {
            var flag = false;
            foreach (var pupil in Pupils)
            {
                if (string.Compare(pupil.Name, check.Name, true) == 0)
                {
                    MessageBox.Show("Данный ученик уже занес в учет", "Ошибка");
                    flag = true;

                    break;
                }
            }

            return flag;
        }


        private void SaveTableAsExcelB_Click(object sender, RoutedEventArgs e)
        {
            var folderBrowsingDialog = new System.Windows.Forms.FolderBrowserDialog();
            if (folderBrowsingDialog.ShowDialog()
                == System.Windows.Forms.DialogResult.OK)
            {
                string path = folderBrowsingDialog.SelectedPath;
                var temp = _filter.Filter(Pupils, new PupilFilterSettings
                {
                    PupilNameTB = SearchNameTB.Text,
                    TeacherNameTB = SearchTeacherNameTB.Text,
                    PaymentTrueCB = PaymentTrueCB.IsChecked.Value,
                    PaymentFalseCB = PaymentFalseCB.IsChecked.Value,
                    SelectedGroupCB = (GroupsCB.SelectedItem as GroupComboBoxItem).Instance,
                    SelectedCourseTypeCB = (CourseTypesCB.SelectedItem as CourseTypeComboBoxItem).Instance,
                    Teachers = Teachers,
                    TeacherCourses = TeacherCourses,
                    Courses = Courses,
                    CourseTypes = CourseTypes,
                    Groups = Groups,
                    PupilGroups = PupilGroups,
                });

                try
                {
                    _excelParser.Parse(temp, Path.Combine(path, "Ученики.xlsx"));
                }
                catch
                {
                    MessageBox.Show("Закройте файл, прежде чем сохранять!", "Ошибка");
                }
                
            }
        }
    }
}

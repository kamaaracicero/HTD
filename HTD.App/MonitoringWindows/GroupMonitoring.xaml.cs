using HTD.App.AddWindows;
using HTD.App.Configuration;
using HTD.App.Elements.CourseMonitoring;
using HTD.App.Elements.GroupsMonitoring;
using HTD.App.UpdateWindows;
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
    public partial class GroupMonitoring : Window
    {
        private readonly IService<Pupil> _pupilService;
        private readonly IService<PupilGroup> _pupilGroupService;
        private readonly IService<Group> _groupService;

        public GroupMonitoring(Course course)
        {
            _pupilService = AppServicesConfiguration.PupilService;
            _pupilGroupService = AppServicesConfiguration.PupilGroupService;
            _groupService = AppServicesConfiguration.GroupService;

            SelectedCourse = course;

            InitializeComponent();

            CourseNameL.Content = course.Name;
        }

        private Course SelectedCourse { get; }

        public List<Pupil> Pupils { get; set; }

        public List<PupilGroup> PupilGroups { get; set; }

        public List<Group> Groups { get; set; }

        private async void Window_Initialized(object sender, System.EventArgs e)
        {
            await LoadGroupsData();
            await LoadPupilsData();
            await LoadPupilGroupsData();

            UpdateGroupsView();
        }

        private async void RefreshTableB_Click(object sender, RoutedEventArgs e)
        {
            await LoadGroupsData();
            await LoadPupilsData();
            await LoadPupilGroupsData();

            UpdateGroupsView();
        }

        private void UpdateGroupsView()
        {
            UpdateDetailsView();

            GroupsDG.ItemsSource = Groups.Select(g => new GroupDataGridRow(g,
                DependencyHelper.FindGroupPupils(g, PupilGroups, Pupils)));
            GroupsDG.Items.Refresh();
        }

        private void UpdateDetailsView()
        {
            PupilCountTB.Text = string.Empty;
            YearTB.Text = string.Empty;
            PaymentTB.Text = string.Empty;

            PupilsLB.ItemsSource = null;
            PupilsLB.Items.Refresh();
        }

        private void UpdateDetailsView(Group group, IEnumerable<Pupil> pupils)
        {
            PupilCountTB.Text = pupils.Count().ToString();
            YearTB.Text = group.Year.ToString();
            PaymentTB.Text = group.Payment ? "Да" : "Нет";

            PupilsLB.ItemsSource = pupils.Select(p => new PupilListBoxItem(p));
            PupilsLB.Items.Refresh();
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
                Groups = res.Value.Where(g => (g.IsActive == true) && (g.CourseId == SelectedCourse.Id)).ToList();
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

        private async void OpenNewGroupB_Click(object sender, RoutedEventArgs e)
        {
            AddGroupWindow window = new AddGroupWindow(SelectedCourse);
            if (window.ShowDialog().Value)
            {
                var res = await _groupService.Insert(window.Value);
                if (!res.Successfully)
                {
                    MessageBox.Show("Не удалось добавить группу", "Ошибка");
                }
                else
                {
                    await LoadGroupsData();
                    UpdateGroupsView();
                }
            }
        }

        private void GroupsDG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (GroupsDG.SelectedItem == null)
                return;

            GroupDataGridRow row = GroupsDG.SelectedItem as GroupDataGridRow;
            UpdateDetailsView(row.Instance, row.Pupils);
        }

        private async void RedactPupilB_Click(object sender, RoutedEventArgs e)
        {
            if (GroupsDG.SelectedItem == null)
                return;

            var group = (GroupsDG.SelectedItem as GroupDataGridRow).Instance;
            UpdatePupilsListWindow window = new UpdatePupilsListWindow(group);
            if (window.ShowDialog().Value)
            {
                await LoadPupilGroupsData();
                UpdateGroupsView();
            }
        }

        private async void ArchiveGroupB_Click(object sender, RoutedEventArgs e)
        {
            if (GroupsDG.SelectedItem == null)
                return;

            var group = (GroupsDG.SelectedItem as GroupDataGridRow).Instance;
            if (MessageBox.Show("Поместить выбранную группу в архив?", "Предупреждение", MessageBoxButton.YesNo)
                == MessageBoxResult.Yes)
            {
                group.IsActive = false;
                var res = await _groupService.Update(group);
                if (res.Successfully)
                {
                    await LoadGroupsData();
                    UpdateGroupsView();
                }
                else
                {
                    MessageBox.Show("Не удалось архивировать группу", "Ошибка");
                    await LoadGroupsData();
                    UpdateGroupsView();
                }
            }
        }
    }
}

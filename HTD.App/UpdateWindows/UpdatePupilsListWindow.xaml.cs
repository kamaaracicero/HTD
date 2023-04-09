using HTD.App.Configuration;
using HTD.App.Elements.UpdatePupilsListWindow;
using HTD.BusinessLogic.DataSearchs;
using HTD.BusinessLogic.Services;
using HTD.DataEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace HTD.App.UpdateWindows
{
    public partial class UpdatePupilsListWindow : Window
    {
        public IService<Pupil> _pupilService;
        public IService<PupilGroup> _pupilGroupService;

        public UpdatePupilsListWindow(Group group)
        {
            _pupilService = AppConfiguration.PupilService;
            _pupilGroupService = AppConfiguration.PupilGroupService;

            Group = group;

            InitializeComponent();
        }

        public Group Group { get; set; }

        public List<Pupil> AddedPupils { get; set; }

        public List<Pupil> Pupils { get; set; }

        public List<PupilGroup> PupilGroups { get; set; }

        private async void Window_Initialized(object sender, System.EventArgs e)
        {
            await LoadPupilsData();
            await LoadPupilGroupsData();

            LoadAddedPupils();

            UpdateAddedPupilsView();
            UpdatePupilsView();
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

        private void LoadAddedPupils()
        {
            AddedPupils = new List<Pupil>();
            AddedPupils.AddRange(DependencyHelper.FindGroupPupils(Group, PupilGroups, Pupils));
        }

        private void UpdateAddedPupilsView()
        {
            AddedPupilsLB.ItemsSource = AddedPupils.Select(p => new PupilListBoxItem(p));
            AddedPupilsLB.Items.Refresh();
        }

        private void UpdatePupilsView()
        {
            var temp = Pupils.Where(p => p.Name.StartsWith(SearchByPupilNameTB.Text,
                StringComparison.OrdinalIgnoreCase));
            PupilsLB.ItemsSource = temp
                .Where(p => !AddedPupils.Contains(p))
                .Select(p => new PupilListBoxItem(p));
            PupilsLB.Items.Refresh();
        }

        private async void DeleteAddedPupilMI_Click(object sender, RoutedEventArgs e)
        {
            if (AddedPupilsLB.SelectedItem == null)
                return;

            var pupil = (AddedPupilsLB.SelectedItem as PupilListBoxItem).Instance;
            var dependency = PupilGroups.FirstOrDefault(d => d.GroupId == Group.Id && d.PupilId == pupil.Id);
            if (dependency == null)
            {
                MessageBox.Show("Не удалось найти зависимость. Откройте окно заново", "Ошибка");
                DialogResult = false;
                Close();
            }

            var res = await _pupilGroupService.Delete(dependency);
            if (res.Successfully)
            {
                await LoadPupilGroupsData();

                LoadAddedPupils();
                UpdateAddedPupilsView();
                UpdatePupilsView();
            }
            else
            {
                MessageBox.Show("Не удалось удалить ученика из группы", "Ошибка");
                await LoadPupilsData();
                await LoadPupilGroupsData();

                LoadAddedPupils();
                UpdateAddedPupilsView();
                UpdatePupilsView();
            }
        }

        private async void AddPupilB_Click(object sender, RoutedEventArgs e)
        {
            if (PupilsLB.SelectedItem == null)
                return;

            var pupil = (PupilsLB.SelectedItem as PupilListBoxItem).Instance;
            var res = await _pupilGroupService.Insert(new PupilGroup(0, pupil.Id, Group.Id));
            if (res.Successfully)
            {
                await LoadPupilGroupsData();

                LoadAddedPupils();
                UpdateAddedPupilsView();
                UpdatePupilsView();
            }
            else
            {
                MessageBox.Show("Не удалось добавить ученика в группу", "Ошибка");
                await LoadPupilsData();
                await LoadPupilGroupsData();

                LoadAddedPupils();
                UpdateAddedPupilsView();
                UpdatePupilsView();
            }
        }

        private void CloseB_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            DialogResult = true;
        }

        private void SearchByPupilNameTB_TextChanged(object sender, TextChangedEventArgs e) => UpdatePupilsView();
    }
}

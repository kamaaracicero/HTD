﻿using HTD.BusinessLogic.ErrorMessageGenerators;
using HTD.BusinessLogic.Loggers;
using HTD.BusinessLogic.ModelConverters;
using HTD.BusinessLogic.Models.Dev.AddWindowModels;
using HTD.DataEntities;
using System.Windows;

namespace HTD.App.Dev.AddWindows
{
    public partial class AddGroup : Window
    {
        private readonly IModelConverter<AddGroupModel, Group> _converter;

        public AddGroup(IModelConverter<AddGroupModel, Group> converter)
        {
            _converter = converter;

            Model = new AddGroupModel();
            Value = null;

            InitializeComponent();
        }

        public AddGroupModel Model { get; private set; }

        public Group Value { get; private set; }

        private void AddB_Click(object sender, RoutedEventArgs e)
        {
            DevLogger.AddLog("AddB Click", 2, LogClass.Event, LogItem.Group);

            Model.CourseIdTB = this.CourseIdTB.Text;
            Model.NameTB = this.NameTB.Text;
            Model.YearTB = this.YearTB.Text;
            Model.IsActiveCB = this.IsActiveCB.IsChecked.Value;
            Model.PaymentCB = this.PaymentCB.IsChecked.Value;

            var res = _converter.ConvertModel(Model);
            if (res.IsError)
            {
                DevLogger.AddLog("Convert error", 3, LogClass.Error, LogItem.Group);

                MessageBox.Show(MessageBoxListErrors.GenerateMessage("Error in convert", res.Errors));
                return;
            }
            else
            {
                DevLogger.AddLog("Item converted", 3, LogClass.Success, LogItem.Group);

                Value = res.Value;
                DialogResult = true;
                Close();
            }
        }
    }
}
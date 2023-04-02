using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace HTD.App.AddWindows
{
    public partial class AddPupilWindow : Window
    {
        public AddPupilWindow()
        {
            InitializeComponent();
        }

        private void BirthDayDP_Loaded(object sender, RoutedEventArgs e)
        {
            DatePicker datePicker = sender as DatePicker;
            if (datePicker != null)
            {
                DatePickerTextBox datePickerTextBox = FindVisualChild<DatePickerTextBox>(datePicker);
                if (datePickerTextBox != null)
                {

                    ContentControl watermark = datePickerTextBox
                        .Template.FindName("PART_Watermark", datePickerTextBox) as ContentControl;
                    if (watermark != null)
                    {
                        watermark.Content = "Введите дату...";
                    }
                }
            }
        }

        private T FindVisualChild<T>(DependencyObject depencencyObject)
            where T : DependencyObject
        {
            if (depencencyObject != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depencencyObject); ++i)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depencencyObject, i);
                    T result = (child as T) ?? FindVisualChild<T>(child);
                    if (result != null)
                        return result;
                }
            }

            return null;
        }
    }
}

using MD.PersianDateTime;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ShamsiCalendar
{
    /// <summary>
    /// Interaction logic for ShamsiCalendar.xaml
    /// </summary>
    public partial class ShamsiCalendar : UserControl
    {
        public ShamsiCalendar()
        {
            InitializeComponent();
            SelectedDates = new List<PersianDateTime>();

            ShamsiToday = PersianDateTime.Now;
            CurrentMonthOnDisplay = ShamsiToday;

            PopulateCalender(ShamsiToday);
        }

        private readonly int totalCalendarDays = 35;
        public PersianDateTime ShamsiToday { get; set; }

        public PersianDateTime CurrentMonthOnDisplay { get; set; }

        public List<PersianDateTime> SelectedDates { get; set; }


        private void PopulateCalender(PersianDateTime startDate)
        {
            CalendarDays.Children.Clear();

            CurrentYear.Content = startDate.Year.ToString();
            CurrentMonth.Content = startDate.MonthName;

            var firstDayOfMonth = new PersianDateTime(startDate.Year, startDate.Month, 1);
            var lastDayOfLastMonth = firstDayOfMonth.AddMonths(-1).GetPersianDateOfLastDayOfMonth();
            var firstDayOfNextMonth = firstDayOfMonth.AddMonths(1);

            var dayBeforeFirstSaturday = (int)firstDayOfMonth.DayOfWeek + 1;

            if (dayBeforeFirstSaturday == 7)
                dayBeforeFirstSaturday = 0;

            // add days from last month
            for (int i = dayBeforeFirstSaturday; i > 0; i--)
            {
                ShamsiDayLabel labelDay = new ShamsiDayLabel
                {
                    ShowingCalanderMonth = startDate.Month,
                    PersianDay = firstDayOfMonth.AddDays(-1 * i)
                };
                labelDay.MouseDown += LabelDay_MouseDown;
                CalendarDays.Children.Add(labelDay);
            }

            for (int i = 0; i < startDate.GetMonthDays; i++)
            {
                ShamsiDayLabel labelDay = new ShamsiDayLabel
                {
                    ShowingCalanderMonth = startDate.Month,
                    PersianDay = firstDayOfMonth.AddDays(i)
                };
                labelDay.MouseDown += LabelDay_MouseDown;
                CalendarDays.Children.Add(labelDay);
            }

            // add days from next month
            for (int i = 0; i < totalCalendarDays - startDate.GetMonthDays - dayBeforeFirstSaturday; i++)
            {
                ShamsiDayLabel labelDay = new ShamsiDayLabel
                {
                    ShowingCalanderMonth = startDate.Month,
                    PersianDay = firstDayOfNextMonth.AddDays(i)
                };
                labelDay.MouseDown += LabelDay_MouseDown;
                CalendarDays.Children.Add(labelDay);
            }
        }

        private void LabelDay_MouseDown(object sender, MouseButtonEventArgs e)
        {
            (sender as ShamsiDayLabel).IsSelected = !(sender as ShamsiDayLabel).IsSelected;

            if ((sender as ShamsiDayLabel).IsSelected)
            {
                SelectedDates.Add((sender as ShamsiDayLabel).PersianDay);
            }
            else
            {
                SelectedDates.Remove((sender as ShamsiDayLabel).PersianDay);
            }
        }

        private void PrevMonth_Click(object sender, RoutedEventArgs e)
        {
            CurrentMonthOnDisplay = CurrentMonthOnDisplay.AddMonths(-1);
            PopulateCalender(CurrentMonthOnDisplay);
        }

        private void NextMonth_Click(object sender, RoutedEventArgs e)
        {
            CurrentMonthOnDisplay = CurrentMonthOnDisplay.AddMonths(1);
            PopulateCalender(CurrentMonthOnDisplay);
        }
    }
}

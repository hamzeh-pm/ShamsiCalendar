using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using MD.PersianDateTime;

namespace ShamsiCalendar
{
    class ShamsiDayLabel : System.Windows.Controls.Label
    {
        public ShamsiDayLabel()
        {
            Width = 32;
            Height = 32;
            FontWeight = System.Windows.FontWeights.Bold;
        }

        private bool _isSelected = false;
        private Brush _defaultBackground;
        private double _defaultOpacity;

        public int ShowingCalanderMonth { get; set; }

        private PersianDateTime _persianDay;
        public PersianDateTime PersianDay
        {
            get => _persianDay;
            set
            {
                _persianDay = value;
                Content = _persianDay.Day.ToString();

                // diffrent style if day is not for current month
                if (ShowingCalanderMonth != _persianDay.Month)
                {
                    _defaultBackground = Brushes.White;
                    _defaultOpacity = 0.5;
                    Opacity = _defaultOpacity;
                }

                // diffrent style for fridays
                if (_persianDay.DayOfWeek == DayOfWeek.Friday)
                {
                    Foreground = Brushes.Red;
                }

                // diffrent style for today
                if (_persianDay.Date == PersianDateTime.Now.Date)
                {
                    FontWeight = System.Windows.FontWeights.ExtraBold;
                    BorderThickness = new System.Windows.Thickness(1);
                    BorderBrush = Brushes.Red;
                }

                _defaultBackground = Background;
                _defaultOpacity = Opacity;
            }
        }

        public bool IsSelected
        {
            get => _isSelected;
            set
            {
                _isSelected = value;

                if (_isSelected)
                    Background = Brushes.CadetBlue;
                else
                    Background = _defaultBackground;
            }
        }
    }
}

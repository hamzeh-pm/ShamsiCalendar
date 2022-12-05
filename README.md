# Shamsi Calender

this project is simple wpf custom control Shamsi(Persian) calender, you can change showing month back and forth and select the non-consecutive dates to use on you forms
the selected dates stores on **SelectedDates**

## version

_1.0.0_

## usage

```
// in xaml file

<Window x:Class="datepicker.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:datepicker"
        xmlns:shamsiCalendar="clr-namespace:ShamsiCalendar;assembly=ShamsiCalendar"
        mc:Ignorable="d"
        Title="MainWindow" Height="450" Width="800">
    <StackPanel x:Name="stack">
        <shamsiCalendar:ShamsiCalendar x:Name="CustomCalendar"></shamsiCalendar:ShamsiCalendar>
    </StackPanel>
</Window>

// in code behind

// contains List<MD.PersianDateTime.PersianDateTime>
CustomCalendar.SelectedDates;
```

## dependencies

nuget packages: MD.PersianDateTime

https://www.nuget.org/packages/MD.PersianDateTime

using System;
using System.Diagnostics;
using System.Threading;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using TimerPowerOff.Commands;

namespace TimerPowerOff.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        #region Свойства
        //Таймер обратного отсчёта
        private Timer _countDownTimer;
        //Таймер выключения
        private Timer _powerOffTimer;
        //Время начала отсчёта
        private DateTime _startTime;

        private ICommand _startTimerCommand;

        private ICommand _stopTimerCommand;

        public ICommand StartTimerCommand
        {
            get
            {
                if (_startTimerCommand == null)
                    _startTimerCommand = new DelegateCommand(StartTimer, CanStartTimer);
                return _startTimerCommand;
            }
        }

        private bool CanStartTimer()
        {
            return Minutes > 0;
        }

        public ICommand StopTimerCommand
        {
            get
            {
                if (_stopTimerCommand == null)
                    _stopTimerCommand = new DelegateCommand(StopTimer);
                return _stopTimerCommand;
            }
            set
            {
                _stopTimerCommand = value;
            }
        }

        public static readonly DependencyProperty MinutesProperty = DependencyProperty.Register(
            "Minutes", typeof(double), typeof(MainViewModel), new PropertyMetadata(0.5, MinutesChangedCallback));

        public bool Enabled { get; set; } = true;

        private static void MinutesChangedCallback(DependencyObject dependencyObject,
                                                   DependencyPropertyChangedEventArgs e)
        {
            var vm = dependencyObject as MainViewModel;
            if (vm == null)
                return;
            vm.TimeUntil = TimeSpan.FromMinutes((double)e.NewValue);
        }

        public double Minutes
        {
            get
            {
                return (double)GetValue(MinutesProperty);
            }
            set
            {
                SetValue(MinutesProperty, value);
            }
        }

        public static readonly DependencyProperty TimeUntilProperty = DependencyProperty.Register(
            "TimeUntil", typeof(TimeSpan), typeof(MainViewModel), new PropertyMetadata(default(TimeSpan)));

        public TimeSpan TimeUntil
        {
            get
            {
                return (TimeSpan)GetValue(TimeUntilProperty);
            }
            set
            {
                SetValue(TimeUntilProperty, value);
            }
        }

        #endregion

        private void CountDownCallback(object state)
        {
            Dispatcher.Invoke(
                DispatcherPriority.Background, new Action(
                    () => { TimeUntil = TimeSpan.FromMinutes(Minutes) - (DateTime.Now - _startTime); }));
        }

        private void PowerOffCallback(object state)
        {
            Dispatcher.Invoke(DispatcherPriority.Background, new Action(StopTimer));
            var result = MessageBox.Show(
                "Выключить компьютер?", "Таймер выключения", MessageBoxButton.YesNo, MessageBoxImage.Question,
                MessageBoxResult.No, MessageBoxOptions.ServiceNotification);
            if (result == MessageBoxResult.No)
            {
                Dispatcher.Invoke(DispatcherPriority.Background, new Action(() => TimeUntil = TimeSpan.FromMinutes(Minutes)));
                return;
            }
            var psi = new ProcessStartInfo("shutdown", "/s /t 0")
            {
                CreateNoWindow = true,
                UseShellExecute = false
            };
            Process.Start(psi);
        }

        private void StartTimer()
        {
            _startTime = DateTime.Now;
            Enabled = false;
            OnPropertyChanged("Enabled");
            _countDownTimer = new Timer(CountDownCallback, null, 0, 1000);
            _powerOffTimer = new Timer(
                PowerOffCallback, null, TimeSpan.FromMinutes(Minutes), TimeSpan.FromMilliseconds(-1));
        }

        private void StopTimer()
        {
            _powerOffTimer.Dispose();
            _countDownTimer.Dispose();
            _countDownTimer = null;
            _powerOffTimer = null;
            Enabled = true;
            OnPropertyChanged("Enabled");
        }
    }
}
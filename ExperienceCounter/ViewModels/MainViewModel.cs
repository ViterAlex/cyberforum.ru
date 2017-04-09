using System;
using System.Windows;

namespace ExperienceCounter.ViewModels
{
    public class MainViewModel : ViewModelBase
    {

        public static readonly DependencyProperty ExperienceStartProperty = DependencyProperty.Register(
            "ExperienceStart", typeof (DateTime), typeof (MainViewModel), new PropertyMetadata(default(DateTime)));
        /// <summary>
        /// Начало трудовой деятельности
        /// </summary>
        public DateTime ExperienceStart
        {
            get { return (DateTime) GetValue(ExperienceStartProperty); }
            set { SetValue(ExperienceStartProperty, value); }
        }

        public static readonly DependencyProperty ExperienceEndProperty = DependencyProperty.Register(
            "ExperienceEnd", typeof (DateTime), typeof (MainViewModel), new PropertyMetadata(default(DateTime)));
        /// <summary>
        /// Конец трудовой деятельности
        /// </summary>
        public DateTime ExperienceEnd
        {
            get { return (DateTime) GetValue(ExperienceEndProperty); }
            set { SetValue(ExperienceEndProperty, value); }
        }

        #region Constructor

        public MainViewModel()
        {
            ExperienceStart = DateTime.Now.AddYears(-20);
            ExperienceEnd = DateTime.Now;
        }

        #endregion
    }
}

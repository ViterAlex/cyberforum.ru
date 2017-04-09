using System.Windows;
using SentenceStatistic.Models;

namespace SentenceStatistic.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public static readonly DependencyProperty IsRandomProperty = DependencyProperty.Register(
            "IsRandom", typeof(bool), typeof(MainViewModel), new PropertyMetadata(true, IsRandomChangedCallback));

        private static void IsRandomChangedCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            var vm = dependencyObject as MainViewModel;
            vm.GetRandomString();
        }

        public bool IsRandom
        {
            get
            {
                return (bool)GetValue(IsRandomProperty);
            }
            set
            {
                SetValue(IsRandomProperty, value);
            }
        }

        public static readonly DependencyProperty TextProperty = DependencyProperty.Register(
            "Text", typeof(string), typeof(MainViewModel), new PropertyMetadata(default(string), TextChangedCallback));

        private static void TextChangedCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            var vm = dependencyObject as MainViewModel;
            vm.GetAnswer();
            
        }

        private void GetAnswer()
        {
            if (string.IsNullOrEmpty(Text))
            {
                return;
            }
            Answer = Sentence.Answer(Text);
            UppersCount = Sentence.getCountUpperLetters(Text);
            LowersCount = Sentence.getCountLowerLetters(Text);
            OnPropertyChanged("UppersCount");
            OnPropertyChanged("LowersCount");
        }

        public string Text
        {
            get
            {
                return (string)GetValue(TextProperty);
            }
            set
            {
                SetValue(TextProperty, value);
            }
        }

        public static readonly DependencyProperty LengthProperty = DependencyProperty.Register(
            "Length", typeof(int), typeof(MainViewModel), new PropertyMetadata(45, LengthChangedCallback));

        private static void LengthChangedCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            var vm = dependencyObject as MainViewModel;
            vm.GetRandomString();
        }

        public int Length
        {
            get
            {
                return (int)GetValue(LengthProperty);
            }
            set
            {
                SetValue(LengthProperty, value);
            }
        }

        public static readonly DependencyProperty AnswerProperty = DependencyProperty.Register(
            "Answer", typeof(SentenceKind), typeof(MainViewModel), new PropertyMetadata(default(SentenceKind)));

        public SentenceKind Answer
        {
            get
            {
                return (SentenceKind) GetValue(AnswerProperty);
            }
            private set
            {
                SetValue(AnswerProperty, value);
            }
        }

        public int UppersCount { get; set; }
        public int LowersCount { get; set; }

        #region Constructor

        public MainViewModel()
        {
            Length = 35;
        }

        #endregion

        private void GetRandomString()
        {
            if (!IsRandom)
            {
                Text = string.Empty;
                return;
            }
            Text = Sentence.getRandomSetSymbols(Length);
        }
    }
}

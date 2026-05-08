using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace task1
{
    public partial class MainWindow : Window
    {
        private MainViewModel _vm = null!;

        public MainWindow(UserModel currentUser)
        {
            InitializeComponent();
            _vm = new MainViewModel(currentUser);
            DataContext = _vm;

            _vm.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == nameof(MainViewModel.Balance))
                    CheckBudgetWarning();
            };
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            var sb = (Storyboard)this.Resources["FadeInAnimation"];
            Storyboard.SetTarget(sb, MainGrid);
            sb.Begin();
        }

        private void CheckBudgetWarning()
        {
            if (_vm.Balance < 0)
            {
                var sb = (Storyboard)this.Resources["BudgetWarningAnimation"];
                sb.Begin();
            }
        }

        private void AnimateButtonClick(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn)
            {
                var sb = (Storyboard)this.Resources["ButtonClickAnimation"];
                Storyboard.SetTarget(sb, btn);
                sb.Begin();
            }
        }

        private void PrevMonth_Click(object sender, RoutedEventArgs e)
        {
            PlaySlideAnimation(fromRight: false);
        }

        // Анимация перелистывания месяца вправо
        private void NextMonth_Click(object sender, RoutedEventArgs e)
        {
            PlaySlideAnimation(fromRight: true);
        }

        private void PlaySlideAnimation(bool fromRight)
        {
            var sb = new System.Windows.Media.Animation.Storyboard();
            double from = fromRight ? 50 : -50;

            var slideOut = new DoubleAnimation
            {
                From = 0,
                To = -from,
                Duration = System.Windows.Duration.Automatic
            };
            slideOut.Duration = new System.Windows.Duration(
                System.TimeSpan.FromSeconds(0.15));

            var fadeOut = new DoubleAnimation
            {
                From = 1,
                To = 0,
                Duration = new System.Windows.Duration(
                    System.TimeSpan.FromSeconds(0.15))
            };

            Storyboard.SetTarget(slideOut, MonthPanel);
            Storyboard.SetTargetProperty(slideOut,
                new PropertyPath("RenderTransform.(TranslateTransform.X)"));
            Storyboard.SetTarget(fadeOut, MonthPanel);
            Storyboard.SetTargetProperty(fadeOut, new PropertyPath("Opacity"));

            sb.Children.Add(slideOut);
            sb.Children.Add(fadeOut);

            sb.Completed += (s, _) =>
            {
                // После исчезновения — показываем новый месяц
                var sbIn = new System.Windows.Media.Animation.Storyboard();

                var slideIn = new DoubleAnimation
                {
                    From = from,
                    To = 0,
                    Duration = new System.Windows.Duration(
                        System.TimeSpan.FromSeconds(0.2))
                };
                slideIn.EasingFunction = new CubicEase { EasingMode = EasingMode.EaseOut };

                var fadeIn = new DoubleAnimation
                {
                    From = 0,
                    To = 1,
                    Duration = new System.Windows.Duration(
                        System.TimeSpan.FromSeconds(0.2))
                };

                Storyboard.SetTarget(slideIn, MonthPanel);
                Storyboard.SetTargetProperty(slideIn,
                    new PropertyPath("RenderTransform.(TranslateTransform.X)"));
                Storyboard.SetTarget(fadeIn, MonthPanel);
                Storyboard.SetTargetProperty(fadeIn, new PropertyPath("Opacity"));

                sbIn.Children.Add(slideIn);
                sbIn.Children.Add(fadeIn);
                sbIn.Begin();
            };

            sb.Begin();
        }

        private void Exit_Click(object sender, RoutedEventArgs e) =>
            Application.Current.Shutdown();

        protected override void OnClosed(System.EventArgs e)
        {
            base.OnClosed(e);
            Application.Current.Shutdown();
        }
    }
}
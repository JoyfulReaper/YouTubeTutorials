using APIConsumeLibrary;
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

namespace WpfAppDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int _maxNumber = 0;
        private int _currentNumber = 0;

        public MainWindow()
        {
            InitializeComponent();
            ApiHelper.InitializeClient();
            nextImageButton.IsEnabled = false;
        }

        private async Task LoadImage(int imageNumber = 0)
        {
            var comic = await ComicProcessor.LoadComic(imageNumber);

            if (imageNumber == 0)
            {
                _maxNumber = comic.Num;
            }

            _currentNumber = comic.Num;

            var uriSource = new Uri(comic.Img, UriKind.Absolute);
            comicImage.Source = new BitmapImage(uriSource);
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await LoadImage();
        }

        private async void previousImageButton_Click(object sender, RoutedEventArgs e)
        {
            if(_currentNumber > 1)
            {
                _currentNumber--;
                nextImageButton.IsEnabled = true;

                await LoadImage(_currentNumber);

                if (_currentNumber == 1)
                {
                    previousImageButton.IsEnabled = false;
                }
            }
        }

        private async void nextImageButton_Click(object sender, RoutedEventArgs e)
        {
            if(_currentNumber < _maxNumber)
            {
                _currentNumber++;
                previousImageButton.IsEnabled = true;

                await LoadImage(_currentNumber);

                if(_currentNumber == _maxNumber)
                {
                    nextImageButton.IsEnabled = false;
                }
            }
        }

        private void sunInformationButton_Click(object sender, RoutedEventArgs e)
        {
            Suninfo suninfo = new Suninfo();
            suninfo.Show();
        }
    }
}

using System.IO;
using System.Net.Http;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SynchronousUiProblem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ShowImage(Image1, "https://http.cat/images/500.jpg");
            ShowImage(Image2, "https://http.cat/images/400.jpg");
            ShowImage(Image3, "https://http.cat/images/404.jpg");
            ShowImage(Image4, "https://http.cat/images/200.jpg");
            ShowImage(Image5, "https://http.cat/images/302.jpg");
            ShowImage(Image6, "https://http.cat/images/503.jpg");
        }

        private async Task ShowImage(Image image, string url)
        {
            HttpClient httpClient = new HttpClient();
            var response = httpClient.GetAsync(url).GetAwaiter().GetResult();
            byte[] imageBytes = response.Content.ReadAsByteArrayAsync().GetAwaiter().GetResult();
            image.Source = LoadImage(imageBytes);
        }

        private static BitmapImage LoadImage(byte[] imageData)
        {
            if (imageData == null || imageData.Length == 0) return null;
            var image = new BitmapImage();
            using (var mem = new MemoryStream(imageData))
            {
                mem.Position = 0;
                image.BeginInit();
                image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.UriSource = null;
                image.StreamSource = mem;
                image.EndInit();
            }
            image.Freeze();
            return image;
        }
    }
}
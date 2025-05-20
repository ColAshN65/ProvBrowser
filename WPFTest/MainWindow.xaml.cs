using ApiConnector.AssemblyUi.Services;
using Services.Audio;
using Services.Notification;
using Services.Transcribing;
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

namespace Testing
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            string filePath = "RecordResult.wav";
            AssemblyUiApiService assemblyUiApiService = new AssemblyUiApiService();

            var notificationService = new DebugNotificationService();
            transcribationService = new AssemblyUiTranscribationService(notificationService, assemblyUiApiService, filePath);
            recordingService = new NAudioRecordingService(notificationService, filePath);
        }

        private AssemblyUiTranscribationService transcribationService;
        private NAudioRecordingService recordingService;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            recordingService.StartRecording();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            recordingService.StopRecording();
        }

        private async void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var result = await transcribationService.SpeechToTextAsync();
            MessageBox.Show(result.Text);
        }
    }
}
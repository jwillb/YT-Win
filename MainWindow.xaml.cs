using System.Linq;
using System.Windows;



namespace YouTubeDownloader
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool hideTerminal;

        public MainWindow()
        {
            InitializeComponent();
            FFBox.Text = Properties.Settings.Default.FFPath;
            string outputDir = System.IO.Directory.GetCurrentDirectory() + @"\Videos\%(title)s-%(id)s.%(ext)s";
        }

        private void DownloadButton_Click(object sender, RoutedEventArgs e)
        {
            string outputDir = System.IO.Directory.GetCurrentDirectory() + @"\Videos\%(title)s-%(id)s.%(ext)s";

            if (hideTerminal == true)
            {
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                startInfo.FileName = "cmd.exe";
                startInfo.Arguments = $"/C youtube-dl --no-mark-watched --geo-bypass --yes-playlist --format bestvideo+bestaudio --output {outputDir} --ffmpeg-location {this.FFBox.Text} {this.DownloadBox.Text}";
                process.StartInfo = startInfo;
                process.Start();
            }
            else
            {
                string strCmdText;
                strCmdText = $"/C youtube-dl --no-mark-watched --geo-bypass --yes-playlist --format bestvideo+bestaudio --output {outputDir} --ffmpeg-location {this.FFBox.Text} {this.DownloadBox.Text}";
                System.Diagnostics.Process.Start("CMD.exe", strCmdText);
            }



            

            
        }

        private void FFBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            Properties.Settings.Default.FFPath = FFBox.Text;
            Properties.Settings.Default.Save();
        }

        private void TerminalCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            hideTerminal = true;
        }

        private void TerminalCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            hideTerminal = false;
        }
    }
}

using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Assignment1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TagLib.File currentFile;

        bool isPlaying = false;
        bool isPaused = false;
        bool isStopped = true;

        bool isScrubbing = false;

        public MainWindow()
        {
            InitializeComponent();

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();
        }

        //sets slider scale from 0 to song end time
        //increments slider per tick
        //pauses when user scrubs through the slider
        private void timer_Tick(object sender, EventArgs e)
        {
            if (myMedia.Source != null && myMedia.NaturalDuration.HasTimeSpan && !isScrubbing)
            {
                mySlider.Minimum = 0;
                mySlider.Maximum = myMedia.NaturalDuration.TimeSpan.TotalSeconds;
                mySlider.Value = myMedia.Position.TotalSeconds;
            }
        }

        //updates time text when slider moves
        private void mySlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            myTimer.Text = TimeSpan.FromSeconds(mySlider.Value).ToString(@"hh\:mm\:ss");
        }

        //tracks when scrubbing to pause timer ticks
        private void mySlider_DragStarted(object sender, DragStartedEventArgs e)
        {
            isScrubbing = true;
        }

        //tracks when scrubbing stopped so timer ticks can continue
        //skips to part of the song scrubbed to
        private void mySlider_DragCompleted(object sender, DragCompletedEventArgs e)
        {
            isScrubbing = false;
            myMedia.Position = TimeSpan.FromSeconds(mySlider.Value);
        }



        //private void OpenCommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        //{
        //    e.CanExecute = true;
        //}

        //Can always open files
        private void Open_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        //Opens file and loads meta data into display
        private void Open_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {
                OpenFileDialog fileDlg = new OpenFileDialog();

                fileDlg.Filter = "MP3 files (*.mp3)|*.mp3";

                if (fileDlg.ShowDialog() == true)
                {
                    currentFile = TagLib.File.Create(fileDlg.FileName);
                    myMedia.Source = new Uri(fileDlg.FileName);

                    var title = currentFile.Tag.Title;
                    var artist = currentFile.Tag.FirstAlbumArtist;
                    var album = currentFile.Tag.Album;
                    var year = currentFile.Tag.Year;

                    myMeta.songTitle.Text = title;
                    myMeta.songArtist.Text = artist;
                    myMeta.songAlbum.Text = album;
                    myMeta.songYear.Text = year.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        //editable only when there is a source
        private void Edit_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = myMedia.Source != null;
        }
        
        //Stops song, stops myMedia from using it, saves metadata, regives it to myMedia, restarts song
        private void Edit_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {
                var temp = myMedia.Source;
                myMedia.Stop();
                myMedia.Source = null;
                currentFile.Tag.Title = myMeta.songTitle.Text;
                currentFile.Tag.Album = myMeta.songAlbum.Text;
                currentFile.Tag.AlbumArtists[0] = myMeta.songArtist.Text;
                currentFile.Tag.Year = uint.Parse(myMeta.songYear.Text);
                currentFile.Save();
                myMedia.Source = temp;
                myMedia.Play();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //playable when appropriate
        private void Play_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = (isPlaying == false) && ((isPaused == true) || (isStopped == true)) && (myMedia.Source != null);
        }

        //starts song, tracks state
        private void Play_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            myMedia.Play();
            isPlaying = true;
            isPaused = false;
            isStopped = false;
        }

        //pausable when appropriate
        private void Pause_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = isPlaying;

        }

        //pauses song, tracks state
        private void Pause_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            myMedia.Pause();
            isPlaying = false;
            isPaused = true;
            isStopped = false;
        }

        //stoppable when appropriate
        private void Stop_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = (isPlaying || isPaused) && !isStopped;

        }

        //stops song, tracks state
        private void Stop_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            myMedia.Stop();
            isStopped = true;
            isPlaying = false;
            isPaused = true;
        }
    }
}

using HeroAutoGame.Images;
using NAudio.Wave;
using System;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Windows.Forms;


namespace HeroAutoGame
{
    public partial class StartForm : Form
    {
        private Frame frame;
        bool isFramePainted = false;
        Label desc = new Label();
        PrivateFontCollection fontCollection = new PrivateFontCollection();
        Description description = new Description();
        Timer DescrTimer = new Timer();
        Timer DescrHidingTimer = new Timer();
        Panel panel = new Panel();
        Timer introMusicTimer = new Timer();
        WaveStream buttonClickSound;
        WaveStream hoverSound;
        WaveStream introMusic;
        WaveOut buttonClickSoundOut;
        WaveOut hoverSoundOut;
        WaveOut introSoundOut;
        WeatherForm weatherForm = new WeatherForm();
        public StartForm()
        {

            InitializeComponent();
            frame = new Frame();
            loadFont();
            DescrTimer.Tick += DescrTimer_Tick;
            DescrTimer.Interval = 50;
            DescrHidingTimer.Interval = 50;
            DescrHidingTimer.Tick += DescrHidingTimer_Tick;
            descriptionOfGame();
            loadSoundClickButton();
            introMusicTimer.Interval = 1000;
            introMusicTimer.Tick += IntroMusicTimer_Tick;
        }

        private void startGame()
        {
            weatherForm.loadWeather(this.Controls,buttonClickSound, buttonClickSoundOut,hoverSound,hoverSoundOut, fontCollection);
        }

        private void setStartButtonColor(bool red)
        {
            if (red) this.startButton.BackgroundImage = global::HeroAutoGame.Properties.Resources.start;
            else this.startButton.BackgroundImage = global::HeroAutoGame.Properties.Resources.startGreen;
        }
        private void loadSoundClickButton()
        {
            buttonClickSoundOut = new WaveOut();
            hoverSoundOut = new WaveOut(); 
            introSoundOut = new WaveOut();
            string soundPath = @"..\..\Resources\Sounds\click.wav";
            soundPath = Path.Combine(Application.StartupPath, soundPath);
            buttonClickSound = new AudioFileReader(soundPath);
            buttonClickSoundOut.Init(buttonClickSound);

            soundPath = @"..\..\Resources\Sounds\clickHover.wav";
            soundPath = Path.Combine(Application.StartupPath, soundPath);
            hoverSound = new AudioFileReader(soundPath);
            hoverSoundOut.Init(hoverSound);

            soundPath = @"..\..\Resources\Sounds\intro.wav";
            soundPath = Path.Combine(Application.StartupPath, soundPath);
            introMusic = new AudioFileReader(soundPath);
            introSoundOut.Init(introMusic);
            introMusicTimer.Start();
        }

        private void IntroMusicTimer_Tick(object sender, EventArgs e)
        {
            if (introMusic.CurrentTime.TotalSeconds > 47)
            {
                introMusic.CurrentTime = new TimeSpan(0L);
            }
        }

        private void loadFont()
        {
            string fontPath = @"..\..\Resources\KnightWarrior-w16n8.otf";
            fontPath = Path.Combine(Application.StartupPath, fontPath);
            fontCollection.AddFontFile(fontPath);


        }
        private void descriptionOfGameShowChar(Label label, string text)
        {
            DescrTimer.Start();
            description.showChars(text, label);
        }

        private void DescrTimer_Tick(object sender, EventArgs e) //перевіряє чи загружений опис гри і робить видимим кнопку кнопку
        {
            if (description.getIsDescriptionLoaded())
            {
                DescrTimer.Stop();
                this.startButton.Visible = true;
                bool initialColorRed = true;
                setStartButtonColor(initialColorRed);
            }
        }

        private void DescrHidingTimer_Tick(object sender, EventArgs e)
        {
            if (!description.getIsDescriptionLoaded())
            {
                DescrHidingTimer.Stop();
                startGame();
            }
        }

        private void descriptionOfGame()
        {
            Font discFont = new Font(fontCollection.Families[0], 20);
            desc.AutoSize = false;
            desc.Size = new Size(300, 250);
            desc.Font = discFont;
            desc.Location = new Point(ClientSize.Width / 4 + 10, ClientSize.Height / 2 - ClientSize.Height / 4 - 40);
            desc.AutoSize = true;
            desc.TextAlign = ContentAlignment.MiddleCenter;
            Controls.Add(desc);
            descriptionOfGameShowChar(desc, GameProccess.gameIntro());
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (!isFramePainted) frame.drawFrame(e.Graphics, this.ClientSize);

        }

        private void startButton_Click(object sender, EventArgs e)
        {
            buttonClickSound.CurrentTime = new TimeSpan(0L);
            buttonClickSoundOut.Play();
            startButton.MouseLeave -= startButton_MouseLeave;
            startButton.MouseHover -= startButton_MouseEnter;
            startButton.Visible = false;
            startButton.Click -= startButton_Click;
            description.hideChars(desc);
            DescrHidingTimer.Start();
        }
        private void startButton_MouseLeave(object sender, EventArgs e)
        {
            bool red = true;
            setStartButtonColor(red);
        }
        private void startButton_MouseEnter(object sender, EventArgs e)
        {
            hoverSound.CurrentTime = new TimeSpan(0L);
            hoverSoundOut.Play();
            bool red = true;
            bool green = !red;
            setStartButtonColor(green);
        }

        private void StartForm_Load(object sender, EventArgs e)
        {
            introSoundOut.Volume = 0.1f; 
            introSoundOut.Play();
        }


    }

}

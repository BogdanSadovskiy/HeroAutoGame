using HeroAutoGame.Images;
using System;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;
namespace HeroAutoGame
{
    public partial class StartForm : Form
    {
        private Frame frame;
        bool isFramePainted = false;
        PrivateFontCollection fontCollection = new PrivateFontCollection();
        Description description = new Description();
        Timer DescrTimer = new Timer();
        Panel panel = new Panel();

        public StartForm()
        {

            InitializeComponent();
            frame = new Frame();
            loadFont();
            DescrTimer.Tick += DescrTimer_Tick;
            DescrTimer.Interval = 50;
            descriptionOfGame();
        }
        private void setStartButtomColor(bool red)
        {
            if (red) this.startButton.BackgroundImage = global::HeroAutoGame.Properties.Resources.start;
            else this.startButton.BackgroundImage = global::HeroAutoGame.Properties.Resources.startGreen;
        }

        private void loadFont()
        {

            fontCollection.AddFontFile(@"C:\Users\HighestInARoom\source\repos\HeroAutoGame\Resources\KnightWarrior-w16n8.otf");

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
                setStartButtomColor(initialColorRed);
            }
        }



        private void descriptionOfGame()
        {
            Font discFont = new Font(fontCollection.Families[0], 20);
            Label desc = new Label();
            desc.Font = discFont;
            desc.Location = new Point(ClientSize.Width / 4 - ClientSize.Width / 8 + 20, ClientSize.Height / 2 - ClientSize.Height / 4);
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

        }
        private void startButton_MouseLeave(object sender, EventArgs e)
        {
            bool red = true;
            setStartButtomColor(red);
        }
        private void startButton_MouseHover(object sender, EventArgs e)
        {
            bool red = true;
            bool green = !red;
            setStartButtomColor(green);
        }
    }

}

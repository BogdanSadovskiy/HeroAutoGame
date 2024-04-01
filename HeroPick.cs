using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Label = System.Windows.Forms.Label;

namespace HeroAutoGame
{
    public static class HeroPick
    {
        static Label heroPickMenu;
        static List<PictureBox> HeroIcons;
        static Button playerButton;
        static PictureBox playerPicture;
        static bool leftPlayer;
        static bool isHeroChosen;
        static bool isHeroSelected;
        static Hero hero;
        static Timer listenerIfHeroChosen;

        public static Hero startPick(Label heroPickMenu_, List<PictureBox> HeroIcons_, Button playerButton_, PictureBox playerPicture_, bool leftPlayer_)
        {
            heroPickMenu = heroPickMenu_;
            playerPicture = playerPicture_;
            leftPlayer = leftPlayer_;
            HeroIcons = HeroIcons_;
            playerButton = playerButton_;
            isHeroChosen = false;
            isHeroSelected = false;
            
            initializeListeners();
            while (!isHeroChosen)
            {
                Application.DoEvents();
            }
            return hero;
        }

        private static void uploadPicture(string path)
        {
            string imgPath = path;
            if (leftPlayer)
            {
                Image image = new Bitmap(Path.Combine(Application.StartupPath, imgPath));
                Image flippedImage = new Bitmap(image.Width, image.Height);
                using (Graphics g = Graphics.FromImage(flippedImage))
                {

                    image.RotateFlip(RotateFlipType.RotateNoneFlipX);
                    Rectangle destRect = new Rectangle(0, 0, image.Width, image.Height);
                    g.DrawImage(image, destRect, new Rectangle(0, 0, image.Width, image.Height), GraphicsUnit.Pixel);
                    
                }
                playerPicture.BackgroundImage = new Bitmap(flippedImage, playerPicture.Size);
                return;
            }
            playerPicture.BackgroundImage = new Bitmap(Path.Combine(Application.StartupPath, imgPath));
        }
 

    
        private static void heroIcon_Click(object sender, System.EventArgs e)
        {
            PictureBox pictureBox = sender as PictureBox;
            if (pictureBox.Equals(HeroIcons[0]))
            {
                uploadPicture(@"..\..\Images\Juggernaut\JuggPicture.png");
                playerPicture.Visible = true;
                hero = new Juggernaut();
            }
            if (pictureBox.Equals(HeroIcons[1]))
            {
                uploadPicture(@"..\..\Images\Alchemist\Dota-Alchemist.png");
                playerPicture.Visible = true;
                hero = new Alchemist();
            }
            isHeroSelected = true;
        }
        private static void initializeListeners()
        {
            foreach (PictureBox pictureBox in HeroIcons)
            {
                pictureBox.Click += heroIcon_Click;
            }
            listenerIfHeroChosen = new Timer();
            listenerIfHeroChosen.Interval = 200;
            listenerIfHeroChosen.Tick += ListenerIfHeroChosen_Tick;
            listenerIfHeroChosen.Start();

            playerButton.Click += PlayerButton_Click;
        }

        private static void PlayerButton_Click(object sender, System.EventArgs e)
        {
            isHeroChosen = true;
            playerButton.Visible = false;
            playerButton.Dispose();
        }

        private static void ListenerIfHeroChosen_Tick(object sender, System.EventArgs e)
        {
            if (isHeroSelected)
            {
                playerButton.Visible = true;
                listenerIfHeroChosen.Stop();
                listenerIfHeroChosen.Dispose();

            }
        }
    }
}

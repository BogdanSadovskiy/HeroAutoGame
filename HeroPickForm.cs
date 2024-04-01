using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace HeroAutoGame
{
    internal class HeroPickForm
    {
        Label heroPickMenu = new Label();
        Button playerLeftButton = new Button();
        Button playerRightButton = new Button();
        List<PictureBox> HeroIcons = new List<PictureBox>();
        PictureBox playerLeftPicture = new PictureBox();
        PictureBox playerRightPicture = new PictureBox();
        Form thisForm;
        Hero playerLeft;
        Hero playerRight;
        public HeroPickForm(Form thisForm)
        {
            this.thisForm = thisForm;
            initializeComponents();

            playerLeft = HeroPick.startPick(heroPickMenu, HeroIcons, playerLeftButton, playerLeftPicture, true);
            playerRight = HeroPick.startPick(heroPickMenu, HeroIcons, playerRightButton, playerRightPicture, false);
        }
        public Hero getPlayerLeftHero()
        {
            return playerLeft;
        }
        public Hero getPlayerRightHero() { return playerRight; }
        private void initializeComponents()
        {
            HeroIcons.Add(new PictureBox());
            HeroIcons.Add(new PictureBox());
            for (int i = 0; i < 2; i++)
            {
                HeroIcons[i].BackColor = Color.Transparent;
                HeroIcons[i].Size = new Size(31, 32);
                HeroIcons[i].BackgroundImageLayout = ImageLayout.Stretch;
                thisForm.Controls.Add(HeroIcons[i]);
            }


            heroPickMenu.BackColor = Color.Transparent;
            heroPickMenu.Font = new Font(FontFamily.GenericMonospace, 40);
            heroPickMenu.AutoSize = false;
            heroPickMenu.Size = new Size(300, 300);
            heroPickMenu.Location = new Point(thisForm.ClientSize.Width / 2 - heroPickMenu.Width / 2,
                thisForm.ClientSize.Height / 2 - heroPickMenu.Size.Height / 2);
            heroPickMenu.SendToBack();
            heroPickMenu.Visible = false;

            HeroIcons[0].Location = new Point((heroPickMenu.Location.X + heroPickMenu.Size.Width / 2) - HeroIcons[0].Width / 2,
                heroPickMenu.Location.Y + heroPickMenu.Height + 40);
            HeroIcons[1].Location = new Point(HeroIcons[0].Location.X + HeroIcons[0].Width + 20, HeroIcons[0].Location.Y);

            playerLeftPicture.BackColor = Color.Transparent;
            playerLeftPicture.Location = new Point(80, 80);
            playerLeftPicture.Visible = false;
            playerLeftPicture.Size = new Size(237, 452);
            playerLeftPicture.BackgroundImageLayout = ImageLayout.Stretch;

            playerRightPicture.BackColor = Color.Transparent;
            playerRightPicture.Location = new Point(thisForm.ClientSize.Width - 380, 80);
            playerRightPicture.Visible = false;
            playerRightPicture.Size = new Size(237, 452);
            playerRightPicture.BackgroundImageLayout = ImageLayout.Stretch;

            playerLeftButton.Size = new Size(125, 50);
            playerLeftButton.Text = "Choose";
            playerLeftButton.Location = new Point((playerLeftPicture.Location.X + 237) / 2 - 30,
                playerLeftPicture.Location.Y + playerLeftPicture.Size.Height + 20);
            playerLeftButton.Visible = false;

            playerRightButton.Size = new Size(125, 50);
            playerRightButton.Text = "Choose";
            playerRightButton.Location = new Point((playerRightPicture.Location.X + playerRightPicture.Location.X + 237) / 2 - 30,
                playerLeftButton.Location.Y);
            playerRightButton.Visible = false;

            addImageForHeroIcons();
            thisForm.Controls.Add(heroPickMenu);
            thisForm.Controls.Add(playerLeftPicture);
            thisForm.Controls.Add(playerRightPicture);
            thisForm.Controls.Add(playerLeftButton);
            thisForm.Controls.Add(playerRightButton);
        }
        private void addImageForHeroIcons()
        {
            string imgPath = @"..\..\Images\Juggernaut\JuggerHeroIcon.png";
            HeroIcons[0].BackgroundImage = new Bitmap(Path.Combine(Application.StartupPath, imgPath));

            imgPath = @"..\..\Images\Alchemist\AlchemistHeroIcons.png";
            HeroIcons[1].BackgroundImage = new Bitmap(Path.Combine(Application.StartupPath, imgPath));
        }
    }
}

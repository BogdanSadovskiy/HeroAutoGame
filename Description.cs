using System;
using System.Linq;
using System.Windows.Forms;

namespace HeroAutoGame
{
    internal class Description
    {
        string text;
        string newText;
        int currentIndex = 0;
        bool isDescriptionloaded = false;
        Label formatLabel;
        Timer descrTimer = new Timer();


        public Description()
        {
            descrTimer.Tick += DescrTimer_Tick; ;
            newText = "";

        }
        public bool getIsDescriptionLoaded()
        {
            return isDescriptionloaded;
        }
        private void showing()
        {
            if (text.Length != newText.Length)
            {
                newText += text[currentIndex];
                currentIndex++;
                formatLabel.Text = newText;
            }
            else
            {
                descrTimer.Stop();
                isDescriptionloaded = true;
            }
        }
        private void hiding()
        {
            if (formatLabel.Text != "")
            {
                formatLabel.Text = formatLabel.Text.Substring(0, formatLabel.Text.Length - 1);
            }
            else
            {
                descrTimer.Stop();
                currentIndex = 0;
                isDescriptionloaded = false;
            }
        }
        private void DescrTimer_Tick(object sender, EventArgs e)
        {
            if (!isDescriptionloaded) showing();
            else hiding();
        }

        public void showChars(string chars, Label labal)
        {
            text = chars;
            formatLabel = labal;
            descrTimer.Interval = 60;
            descrTimer.Start();
            formatLabel.Click += (s, e) =>
            {
                formatLabel.Text = text;
                descrTimer.Stop();

                isDescriptionloaded = true;
                formatLabel.Click -= (s_, e_) => { };
            };

        }
        public void hideChars(Label labal)
        {
            descrTimer.Interval = 10;
            descrTimer.Start();
            formatLabel.Click += (e, s) =>
            {
                formatLabel.Text = "";
                descrTimer.Stop();
                isDescriptionloaded = false;
                formatLabel.Click -= (s_, e_) => { };
            };
        }
    }
}

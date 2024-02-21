using System;
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
            descrTimer.Interval = 30;
            newText = "";

        }
        public bool getIsDescriptionLoaded()
        {
            return isDescriptionloaded;
        }
        private  void DescrTimer_Tick(object sender, EventArgs e)
        {
            if (text.Length != newText.Length)
            {
                newText += text[currentIndex];
                currentIndex++;
                formatLabel.Text = newText;
            }
            else { 
                descrTimer.Stop();
                isDescriptionloaded = true;
            }
        }

        public  void showChars(string chars, Label labal)
        {
            text = chars;
            formatLabel = labal;
            descrTimer.Start();
            formatLabel.Click += (s, e) =>
            {
                formatLabel.Text = text;
                descrTimer.Stop();
               
                isDescriptionloaded = true;
                formatLabel.Click -= (s_, e_) => { };
            };
           
        }
    }
}

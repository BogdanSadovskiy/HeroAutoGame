using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Windows.Forms;

namespace HeroAutoGame
{
    public class WeatherForm
    {
        Description description = new Description();
        Control.ControlCollection controls;
        PrivateFontCollection _fontCollection;
        Weather currentWeather;
        List<Weather> weathersAll = new List<Weather>();
        List<PictureBox> weatherList = new List<PictureBox>();
        Label descriptionOfWeatherLabel = new Label();
        WaveStream buttonClickSound;
        WaveOut buttonClickSoundOut;
        WaveStream hoverSound;
        WaveOut hoverSoundOut;
        WaveStream wrongClick;
        WaveOut wrongClickSoundOut;
        int initializeWeatherSizeIcon_X = 150;
        int initializeWeatherSizeIcon_Y = 250;
        Point pictureBoxLocation1;
        Point pictureBoxLocation2;
        Point pictureBoxLocation3;
        Image currentWeatherPicture;
        bool isCurrentWeatherChosen = false;
        bool isWeatherPictureClicked = false;
        bool isRandClicked = false;
        bool isNextClicked = false;
        Form thisForm;
        PictureBox choose = new PictureBox();
        PictureBox random = new PictureBox();
        PictureBox next = new PictureBox();
        Point chooseButtonLocation;
        Point chooseButtonEnterLocation;
        Point randomButtonLocation;
        Point randomButtonEnterLocation;
        Timer isDescriptionFinished = new Timer();
        public bool getIsCurrentWeatherChosen()
        {
            return isCurrentWeatherChosen;
        }
        public Weather getCurrentWeather()
        {
            return this.currentWeather;
        }

        private void initializeWeather()
        {
            weathersAll.Add(new Sunny());
            weathersAll.Add(new Cloudy());
            weathersAll.Add(new DarkNight());
        }

        private void setImageForPictureBoxes()
        {
            string imagePath = @"..\..\Images\Sunny150on250.png";
            weatherList[0].BackgroundImage = new Bitmap(Path.Combine(Application.StartupPath, imagePath));

            imagePath = @"..\..\Images\Cloudy150on250.png";
            weatherList[1].BackgroundImage = new Bitmap(Path.Combine(Application.StartupPath, imagePath));

            imagePath = @"..\..\Images\DarkNight150on250.png";
            weatherList[2].BackgroundImage = new Bitmap(Path.Combine(Application.StartupPath, imagePath));


        }
        private void saveLocations()
        {
            pictureBoxLocation1 = new Point(weatherList[0].Location.X, weatherList[0].Location.Y);
            pictureBoxLocation2 = new Point(weatherList[1].Location.X, weatherList[1].Location.Y);
            pictureBoxLocation3 = new Point(weatherList[2].Location.X, weatherList[2].Location.Y);
        }
        private void initializeButtons()
        {
            choose.BackgroundImage = new Bitmap(global::HeroAutoGame.Properties.Resources.choose);
            choose.BackgroundImageLayout = ImageLayout.Stretch;
            choose.Location = new Point(weatherList[0].Location.X + 140, weatherList[0].Location.Y + 350);
            choose.Size = new Size(choose.BackgroundImage.Width, choose.BackgroundImage.Height);
            choose.Visible = true;
            choose.BackColor = Color.Transparent;
            choose.Click += Choose_Click;
            choose.MouseEnter += Choose_MouseEnter;
            choose.MouseLeave += Choose_MouseLeave;

            random.BackgroundImage = new Bitmap(global::HeroAutoGame.Properties.Resources.randRed);
            random.BackgroundImageLayout = ImageLayout.Stretch;
            random.BackColor = Color.Transparent;
            random.Size = new Size(random.BackgroundImage.Width, random.BackgroundImage.Height);
            random.Location = new Point(weatherList[2].Location.X + weatherList[2].Size.Width - random.Size.Width, choose.Location.Y);
            random.Visible = true;
            random.Click += Random_Click;
            random.MouseEnter += Random_MouseEnter;
            random.MouseLeave += Random_MouseLeave;

            next.BackgroundImage = new Bitmap(global::HeroAutoGame.Properties.Resources.next);
            next.BackgroundImageLayout = ImageLayout.Stretch;
            next.BackColor = Color.Transparent;
            next.Size = new Size(next.BackgroundImage.Width, next.BackgroundImage.Height);
            next.Location = new Point(weatherList[1].Location.X - 20, weatherList[1].Location.Y + 350);
            next.Visible = false;
            next.Click += Next_Click;

            controls.Add(random);
            controls.Add(choose);
            controls.Add(next);
            chooseButtonLocation = new Point(choose.Location.X, choose.Location.Y);
            chooseButtonEnterLocation = new Point(chooseButtonLocation.X, chooseButtonLocation.Y - 1);
            randomButtonLocation = new Point(random.Location.X, random.Location.Y);
            randomButtonEnterLocation = new Point(randomButtonLocation.X, randomButtonLocation.Y - 1);
        }

        private void Next_Click(object sender, EventArgs e)
        {
            isNextClicked = true;
            controls.Clear();
            next.Dispose();
        }

        private void Random_MouseLeave(object sender, EventArgs e)
        {
            random.Location = randomButtonLocation;
            random.Size = new Size(random.Width - 2, random.Height - 2);
        }
        private void Random_MouseEnter(object sender, EventArgs e)
        {
            hoverSound.CurrentTime = new TimeSpan(0L);
            hoverSoundOut.Play();
            random.Size = new Size(random.Width + 2, random.Height + 2);
            random.Location = randomButtonEnterLocation;
        }
        private void Random_Click(object sender, EventArgs e)
        {
            buttonClickSound.CurrentTime = new TimeSpan(0L);
            buttonClickSoundOut.Play();
            randWeather();
        }
        private void Choose_Click(object sender, EventArgs e)
        {
            if (!isWeatherPictureClicked)
            {
                wrongClick.CurrentTime = new TimeSpan(0L);
                wrongClickSoundOut.Play();
                return;
            }
            buttonClickSound.CurrentTime = new TimeSpan(0L);
            buttonClickSoundOut.Play();
            isCurrentWeatherChosen = true;
            showDescriptionOfChosenWeather();
            exitFromThisClass();
        }
        private void Choose_MouseEnter(object sender, EventArgs e)
        {
            hoverSound.CurrentTime = new TimeSpan(0L);
            hoverSoundOut.Play();
            choose.Size = new Size(choose.Size.Width + 2, choose.Size.Height + 2);
            choose.Location = chooseButtonEnterLocation;
        }
        private void Choose_MouseLeave(object sender, EventArgs e)
        {
            choose.Location = chooseButtonLocation;
            choose.Size = new Size(choose.Size.Width - 2, choose.Size.Height - 2);
        }
        private void initializePictureList()
        {
            int x = 330;
            int y = 100;
            for (int i = 0; i < weathersAll.Count; i++)
            {
                weatherList.Add(new PictureBox());
                weatherList[i].Size = new Size(initializeWeatherSizeIcon_X, initializeWeatherSizeIcon_Y);
                weatherList[i].BackgroundImageLayout = ImageLayout.Stretch;
                weatherList[i].Location = new Point(x, y);
                weatherList[i].BackColor = Color.Transparent;
                weatherList[i].BorderStyle = BorderStyle.Fixed3D;
                weatherList[i].MouseEnter += Weather_MouseEnter;
                weatherList[i].MouseLeave += Weather_MouseLeave;
                weatherList[i].MouseHover += Weather_MouseHover;
                weatherList[i].MouseClick += Weather_MouseClick;
                controls.Add(weatherList[i]);
                x = weatherList[i].Location.X + weatherList[i].Size.Width + 20;
            }
            initializeWeatherLabel();
            saveLocations();
            setImageForPictureBoxes();
        }
        private void setCurrenWeatherPicture(PictureBox picture)
        {
            string imagePath;
            if (picture.Equals(this.weatherList[0]))
            {
                imagePath = @"..\..\Images\Sunny.png";
                currentWeather = weathersAll[0];
            }
            else if (picture.Equals(this.weatherList[1]))
            {
                imagePath = @"..\..\Images\Cloudy.png";
                currentWeather = weathersAll[1];
            }
            else
            {
                imagePath = @"..\..\Images\DarkNight.png";
                currentWeather = weathersAll[2];
            }
            currentWeatherPicture = new Bitmap(Path.Combine(Application.StartupPath, imagePath));
            currentWeatherPicture = new Bitmap(currentWeatherPicture, new Size(1188, 679));
            thisForm.BackgroundImage = currentWeatherPicture;

        }
        private void exitFromThisClass()
        {
            foreach (PictureBox p in weatherList)
            {
                p.Visible = false;
                p.Dispose();
                controls.Remove(p);
            }
            choose.Click -= Choose_Click;
            controls.Remove(choose);
            // controls.Remove(descriptionOfWeatherLabel);
            controls.Remove(random);

        }
        private void Weather_MouseClick(object sender, MouseEventArgs e)
        {
            PictureBox picture = sender as PictureBox;
            isWeatherPictureClicked = true;
            choose.Image = new Bitmap(global::HeroAutoGame.Properties.Resources.chooseGreen);


            setCurrenWeatherPicture(picture);
        }

        private void initializeWeatherLabel()
        {
            descriptionOfWeatherLabel.AutoSize = false;
            descriptionOfWeatherLabel.Size = new Size(142, 70);
            descriptionOfWeatherLabel.Font = new Font(_fontCollection.Families[0], 10);
            descriptionOfWeatherLabel.TextAlign = ContentAlignment.TopLeft;
            descriptionOfWeatherLabel.Visible = false;
            descriptionOfWeatherLabel.BackColor = Color.Transparent;
            descriptionOfWeatherLabel.BorderStyle = BorderStyle.Fixed3D;
            descriptionOfWeatherLabel.BringToFront();
            controls.Add(descriptionOfWeatherLabel);

        }
        private void setWeatherLabel(PictureBox picture, Weather weather)
        {
            descriptionOfWeatherLabel.Location = new Point(picture.Location.X + 5, picture.Location.Y + 265);
            descriptionOfWeatherLabel.Text = weather.ToString();
            descriptionOfWeatherLabel.Visible = true;
        }
        private void Weather_MouseHover(object sender, EventArgs e)
        {
            PictureBox picture = sender as PictureBox;
            if (picture.Equals(this.weatherList[0])) setWeatherLabel(picture, weathersAll[0]);
            else if (picture.Equals(this.weatherList[1])) setWeatherLabel(picture, weathersAll[1]);
            else setWeatherLabel(picture, weathersAll[2]);


        }

        private void Weather_MouseHoverSetLocation(PictureBox picture)
        {
            if (picture.Equals(weatherList[0])) picture.Location = pictureBoxLocation1;
            if (picture.Equals(weatherList[1])) picture.Location = pictureBoxLocation2;
            if (picture.Equals(weatherList[2])) picture.Location = pictureBoxLocation3;
        }
        private void Weather_MouseLeave(object sender, EventArgs e)
        {
            descriptionOfWeatherLabel.Visible = false;
            PictureBox picture = sender as PictureBox;
            picture.Size = new Size(initializeWeatherSizeIcon_X, initializeWeatherSizeIcon_Y);
            Weather_MouseHoverSetLocation(picture);
        }

        private void Weather_MouseEnter(object sender, EventArgs e)
        {
            hoverSound.CurrentTime = new TimeSpan(0L);
            hoverSoundOut.Play();
            PictureBox picture = sender as PictureBox;
            picture.Size = new Size(picture.Size.Width + 2, picture.Size.Height + 2);
            picture.Location = new Point(picture.Location.X - 2, picture.Location.Y - 2);
        }


        private void initializeSounds(WaveStream buttonClickSound, WaveOut buttonClickSoundOut, WaveStream hoverSound, WaveOut hoverSoundOut,
            WaveStream wrongClick, WaveOut wrongClickSoundOut)
        {
            this.buttonClickSound = buttonClickSound;
            this.buttonClickSoundOut = buttonClickSoundOut;
            this.hoverSound = hoverSound;
            this.hoverSoundOut = hoverSoundOut;
            this.wrongClick = wrongClick;
            this.wrongClickSoundOut = wrongClickSoundOut;
        }
        public Weather loadWeather(Form thisForm, Control.ControlCollection controls, WaveStream buttonClickSound, WaveOut buttonClickSoundOut,
            WaveStream hoverSound, WaveOut hoverSoundOut, WaveStream wrongClick, WaveOut wrongClickSoundOut, PrivateFontCollection fontCollection)
        {
            this.thisForm = thisForm;
            this.controls = controls;
            this._fontCollection = fontCollection;
            initializeSounds(buttonClickSound, buttonClickSoundOut, hoverSound, hoverSoundOut, wrongClick, wrongClickSoundOut);
            initializeWeather();
            initializePictureList();
            initializeButtons();
            while (!isNextClicked)
            {

                Application.DoEvents();

            }
            return currentWeather;
        }

        private void randWeather()
        {

            Random r = new Random();
            int number = r.Next(1, 4);
            if (number == 1) setCurrenWeatherPicture(weatherList[0]);
            else if (number == 2) setCurrenWeatherPicture(weatherList[1]);
            else setCurrenWeatherPicture(weatherList[2]);
            isRandClicked = true;
            showDescriptionOfChosenWeather();
            exitFromThisClass();
        }
        private string descriptionOfChosenWeather()
        {
            string text = "You ";
            if (isRandClicked) text += "randomly ";
            text += "chosen " + ":\n\n";
            text += currentWeather.ToString();
            return text;
        }
        private void initializeDescriptionTimer()
        {
            isDescriptionFinished.Interval = 200;
            isDescriptionFinished.Tick += IsDescriptionFinished_Tick;
            isDescriptionFinished.Start();
        }

        private void IsDescriptionFinished_Tick(object sender, EventArgs e)
        {
            if (description.getIsDescriptionLoaded())
            {
                next.Visible = true;

                isCurrentWeatherChosen = true;
                isDescriptionFinished.Stop();
            }
        }

        private void showDescriptionOfChosenWeather()
        {

            descriptionOfWeatherLabel.Font = new Font(_fontCollection.Families[0], 20);
            descriptionOfWeatherLabel.Location = new Point(currentWeatherPicture.Width / 4 + 120,
                currentWeatherPicture.Height / 2 - currentWeatherPicture.Height / 4 - 40);
            descriptionOfWeatherLabel.AutoSize = true;
            descriptionOfWeatherLabel.BorderStyle = BorderStyle.None;
            descriptionOfWeatherLabel.Visible = true;


            description.showChars(descriptionOfChosenWeather(), descriptionOfWeatherLabel);
            initializeDescriptionTimer();
        }


    }
}

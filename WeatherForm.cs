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
        int initializeWeatherSizeIcon_X = 150;
        int initializeWeatherSizeIcon_Y = 250;
        Point pictureBoxLocation1;
        Point pictureBoxLocation2;
        Point pictureBoxLocation3;
        bool isWeatherClicked = false;
  
        private void initializeTimers()
        {

        }


        private void initializeWeather()
        {
            weathersAll.Add(new Sunny());
            weathersAll.Add(new Cloudy());
            weathersAll.Add(new DarkNight());
        }

        private void setImageForPictureBoxes()
        {
            string fontPath = @"..\..\Images\Sunny150on250.png";
            weatherList[0].BackgroundImage = new Bitmap(Path.Combine(Application.StartupPath, fontPath));

            fontPath = @"..\..\Images\Cloudy150on250.png";
            weatherList[1].BackgroundImage = new Bitmap(Path.Combine(Application.StartupPath, fontPath));

            fontPath = @"..\..\Images\DarkNight150on250.png";
            weatherList[2].BackgroundImage = new Bitmap(Path.Combine(Application.StartupPath, fontPath));

        }
        private void saveLocations()
        {
            pictureBoxLocation1 = new Point(weatherList[0].Location.X, weatherList[0].Location.Y);
            pictureBoxLocation2 = new Point(weatherList[1].Location.X, weatherList[1].Location.Y);
            pictureBoxLocation3 = new Point(weatherList[2].Location.X, weatherList[2].Location.Y);
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

        private void Weather_MouseClick(object sender, MouseEventArgs e)
        {
            throw new NotImplementedException();
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


        private void initializeSounds(WaveStream buttonClickSound, WaveOut buttonClickSoundOut, WaveStream hoverSound, WaveOut hoverSoundOut)
        {
            this.buttonClickSound = buttonClickSound;
            this.buttonClickSoundOut = buttonClickSoundOut;
            this.hoverSound = hoverSound;
            this.hoverSoundOut = hoverSoundOut;
        }
        public void loadWeather(Control.ControlCollection controls, WaveStream buttonClickSound, WaveOut buttonClickSoundOut,
            WaveStream hoverSound, WaveOut hoverSoundOut, PrivateFontCollection fontCollection)
        {
            this.controls = controls;
            this._fontCollection = fontCollection;
            initializeTimers();
            initializeSounds(buttonClickSound, buttonClickSoundOut, hoverSound, hoverSoundOut);
            initializeWeather();
            initializePictureList();
            randWeather();
        }

        private void randWeather()
        {

            Random r = new Random();
            int number = r.Next(1, 4);
            Weather weather;
            if (number == 1) weather = weathersAll[0];
            else if (number == 2) weather = weathersAll[1];
            else weather = weathersAll[2];

            currentWeather = weather;
        }


    }
}

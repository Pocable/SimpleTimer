using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Timer
{
    public partial class TimerForm : Form
    {

        public int seconds = 0;

        public SoundPlayer player = new SoundPlayer();

        #region State
        public bool mouseDownBox = false;
        public bool mouseDownForm = false;
        public bool alarmSoundEnabled = true;
        public bool isAlarmPlaying = false;
        #endregion

        #region Colors
        public Color pauseColor = Color.FromArgb(128,128,128);
        public Color timerEndColor = Color.Red;
        public Color runningColor = Color.Black;
        #endregion

        public TimerForm()
        {
            InitializeComponent();
            timer1.Enabled = false;
            try
            {
                player.SoundLocation = "alarm.wav";
                player.Load();
            }catch(FileNotFoundException)
            {
                alarmSoundEnabled = false;
            }
            maskedTextBox.ForeColor = pauseColor;
        }

        /// <summary>
        /// Called when the timer ticks. Set for every second.
        /// Counts the timer down. If there are no seconds left on the timer change color and play sound.
        /// </summary>
        private void timer1_Tick(object sender, EventArgs e)
        {
            maskedTextBox.Text = BuildDisplay();

            if (seconds > 0)
            {
                seconds -= 1;
            }
            else
            {

                // Change the text color and play the sound if its not playing.
                maskedTextBox.ForeColor = timerEndColor;
                if (alarmSoundEnabled && !isAlarmPlaying)
                {
                    player.PlayLooping();
                    isAlarmPlaying = true;
                }
            }
        }

        /// <summary>
        /// Build the number display with the proper formatting and numbers.
        /// </summary>
        /// <returns>The string representing the time left in a nice format.</returns>
        private string BuildDisplay()
        {
            string display = "";
            int hours = seconds / 3600;
            int minutes = (seconds - (hours * 3600)) / 60;
            int sec = seconds - (hours * 3600) - (minutes * 60);
            display = $"{hours.ToString().PadLeft(2, '0')}:{minutes.ToString().PadLeft(2, '0')}:{sec.ToString().PadLeft(2, '0')}";
            return display;
        }

        /// <summary>
        /// Converts the display back into seconds.
        /// </summary>
        /// <returns>The number of seconds being displayed.</returns>
        private int ParseDisplay()
        {
            string tim = maskedTextBox.Text.Replace(' ', '0');
            string[] data = tim.Split(':');
            Console.WriteLine(data[2]);
            if (data[2].Length == 1)
            {
                data[2] = data[2] + "0";
            }
            for(int i = 0; i < data.Length; i++)
            {
                data[i] = data[i].TrimStart('0');
                if (string.IsNullOrEmpty(data[i]))
                {
                    data[i] = "0";
                }
            }

            int sec = int.Parse(data[2]);
            sec += int.Parse(data[1]) * 60;
            sec += int.Parse(data[0]) * 3600;
            return sec;
        }

        /// <summary>
        /// Stops the timer from counting and updates the display color.
        /// </summary>
        private void Stop()
        {
            timer1.Stop();
            if (alarmSoundEnabled)
            {
                player.Stop();
                isAlarmPlaying = false;
            }
            maskedTextBox.ForeColor = pauseColor;
        }

        /// <summary>
        /// Starts the timer and updates the display color.
        /// </summary>
        private void Start()
        {
            if (!timer1.Enabled)
            {
                seconds = ParseDisplay();
                timer1.Start();
            }
            maskedTextBox.ForeColor = runningColor;
        }

        /// <summary>
        /// Determines if the key should be handled or not. If so, handle it.
        /// </summary>
        private void timeDisplay_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !int.TryParse(e.KeyChar.ToString(), out int isNum);
        }

        /// <summary>
        /// Whenever a kley is pressed on the form, handle it.
        /// </summary>
        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {

            // If its space, stop/start the timer.
           if (e.KeyChar == Convert.ToChar(Keys.Space))
            {
                if (timer1.Enabled)
                {
                    Stop();
                }
                else
                {
                    Start();
                }
                focusArea.Focus();
            }
        }

        /// <summary>
        /// Focus thetimer area when entered.
        /// </summary>
        private void maskedTextBox_Enter(object sender, EventArgs e)
        {
            if(timer1.Enabled)
            {
                focusArea.Focus();
            }
        }

        /// <summary>
        /// Called when the mouse is down in the focus area.
        /// </summary>
        private void focusArea_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDownBox = true;
        }

        /// <summary>
        /// Called when the mouse is moving in the focus area.
        /// </summary>
        private void focusArea_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDownBox)
            {
                focusArea.Focus();
            }
        }

        /// <summary>
        /// Called when the mouse rises in the focus area.
        /// </summary>
        private void maskedTextBox_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDownBox = false;
        }


        /// <summary>
        /// Called when the mouse is down in the form window.
        /// </summary>
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDownForm = true;
        }

        /// <summary>
        /// Called when the mouse is up in the form window.
        /// </summary>
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDownForm = false;
        }

        /// <summary>
        /// When the mouse moves in the window, snap the mouse to the corner of the window for easy cornering.
        /// </summary>
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDownForm)
            {
                int x = Cursor.Position.X - ((e.X > this.Width / 2) ? this.Width - 1 : 0);
                int y = Cursor.Position.Y - ((e.Y > this.Height / 2) ? this.Height - 1 : 0);
                this.Location = new Point(x, y);
            }
        }

        /// <summary>
        /// When the mouse double clicks, ask the user if they want to close the app and then maybe close it.
        /// </summary>
        private void Form1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure you want to close the timer?", "Timer Close", MessageBoxButtons.YesNo);
            if(dr == DialogResult.Yes)
            {
                Close();
            }
        }
    }
}

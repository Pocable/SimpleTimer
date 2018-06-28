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
    public partial class Form1 : Form
    {

        public int seconds = 0;

        public SoundPlayer player = new SoundPlayer();

        public bool mouseDownBox = false;
        public bool mouseDownForm = false;
        public bool alarmSoundEnabled = true;
        public Color pauseColor = Color.FromArgb(128,128,128);
        public Color timerEndColor = Color.Red;
        public Color runningColor = Color.Black;

        public Form1()
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            maskedTextBox.Text = BuildDisplay();

            if (seconds > 0)
            {
                seconds -= 1;
            }
            else
            {
                maskedTextBox.ForeColor = timerEndColor;
                if (alarmSoundEnabled)
                {
                    player.PlayLooping();
                }
            }
        }

        private String BuildDisplay()
        {
            String display = "";
            int hours = seconds / 3600;
            int minutes = (seconds - (hours * 3600)) / 60;
            int sec = seconds - (hours * 3600) - (minutes * 60);
            display = $"{hours.ToString().PadLeft(2, '0')}:{minutes.ToString().PadLeft(2, '0')}:{sec.ToString().PadLeft(2, '0')}";
            return display;
        }

        private int ParseDisplay()
        {
            String tim = maskedTextBox.Text.Replace(' ', '0');
            String[] data = tim.Split(':');
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

        private void Stop()
        {
            timer1.Stop();
            if (alarmSoundEnabled)
            {
                player.Stop();
            }
            maskedTextBox.ForeColor = pauseColor;
        }

        private void Start()
        {
            if (!timer1.Enabled)
            {
                seconds = ParseDisplay();
                timer1.Start();
            }
            maskedTextBox.ForeColor = runningColor;
        }

        private void timeDisplay_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !int.TryParse(e.KeyChar.ToString(), out int isNum);
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
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

        private void maskedTextBox_Enter(object sender, EventArgs e)
        {
            if(timer1.Enabled)
            {
                focusArea.Focus();
            }
        }

        private void focusArea_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDownBox = true;
        }

        private void focusArea_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDownBox)
            {
                focusArea.Focus();
            }
        }

        private void maskedTextBox_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDownBox = false;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDownForm = true;
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDownForm = false;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDownForm)
            {
                this.Location = Cursor.Position;
            }
        }

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

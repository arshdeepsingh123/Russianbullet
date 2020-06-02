using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;  
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Reflection;
using System.IO;

namespace Russianbullet
{
    public partial class Russian_Bullet : Form
    {
        
        RBclass Bclass = new RBclass();
        public Russian_Bullet()
        {
            InitializeComponent();
        }

        private void LoadBtn_Click(object sender, EventArgs e)
        {
            //below code for loading bullet
            SpinBtn.Enabled = true;
            LoadBtn.Enabled = false;
            Image_Box.Image = Russianbullet.Resource1.loadGif;
            SoundPlayer sp = new SoundPlayer(Russianbullet.Resource1.Chamber);
            sp.Play();

            Bclass.LoadBullet();
        }

        private void SpinBtn_Click(object sender, EventArgs e)
        {
            
            SpinBtn.Enabled = false;
            //code to display image in picture box on form load 
            Assembly myAssembly = Assembly.GetExecutingAssembly();
            Stream myStream = myAssembly.GetManifestResourceStream("Russianbullet.Resources.spin.gif");
            Bitmap bmp = new Bitmap(myStream);

            Image_Box.Image = bmp;  // code for setting the image
            // adding sound from resources
            SoundPlayer sp = new SoundPlayer(Russianbullet.Resource1.spin_gun);
            sp.Play();

            Bclass.SpinChamber();
            FireBtn.Enabled = true;
            ShAwayBtn.Enabled = true;
            
        }
        private void FireBtn_Click(object sender, EventArgs e)
        {

            //below code for picturebox from resources
            Assembly myAssembly = Assembly.GetExecutingAssembly();
            Stream myStream = myAssembly.GetManifestResourceStream("Russianbullet.Resources.shoot.gif");
            Bitmap bmp = new Bitmap(myStream);

            Image_Box.Image = bmp;  // code for setting the image

             SoundPlayer sp = new SoundPlayer(Russianbullet.Resource1.shot_sound);
            sp.Play();

            int chances = Bclass.Fire();
            if (chances == 7)
            {
                //all buttons will be disabled
                FireBtn.Enabled = false;
                ShAwayBtn.Enabled = false;
                SpinBtn.Enabled = false;
                LoadBtn.Enabled = false;
            }

            if (chances == 0)
            {
                //code for message box
                MessageBox.Show("You win"); // after winning all buttons will disable
                FireBtn.Enabled = false;
                ShAwayBtn.Enabled = false;
                SpinBtn.Enabled = false;
                LoadBtn.Enabled = false;

                MessageBox.Show(" Do you want to play again?");
            
            }

        }

        

        private void ShAwayBtn_Click(object sender, EventArgs e)
        {
            ////below code for picturebox from resources
            Image_Box.Image = Russianbullet.Resource1.awaygif;
            SoundPlayer sp = new SoundPlayer(Russianbullet.Resource1.Shooawy);
            sp.Play();

            int chances = Bclass.ShootingAway();
            if (chances == 7)
            {
                //all buttons will be disabled
                FireBtn.Enabled = false;
                ShAwayBtn.Enabled = false;
                SpinBtn.Enabled = false;
                LoadBtn.Enabled = false;
            }
            if (chances == 0)
            {
                //all buttons will be disabled
                FireBtn.Enabled = false;
                ShAwayBtn.Enabled = false;
                SpinBtn.Enabled = false;
                LoadBtn.Enabled = false;
                MessageBox.Show("No chances left, you are dead, do you want to play again?");
                
            }
        }

        
private void btn_PlayAgain_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

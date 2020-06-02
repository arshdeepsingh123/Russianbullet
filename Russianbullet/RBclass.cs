using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Russianbullet
{
   public class RBclass
    {
        //below code for shooting logic
        public int ShootingAwayChances = 2;  //2 chnaces for shooting away
        public int Bullet = 0;
        public int FireRemain = 4;
       
        public void LoadBullet()
        {  
            Bullet = 6;
        }

        public int SpinChamber()

        {
            //spining the chmaber
            Random rand = new Random();
            Bullet = rand.Next(1, 7); 
            return Bullet;
        }

        public int Fire()
        {
            if(Bullet == 1)
            {
                //code for message box
                MessageBox.Show("You are dead , Loose the Game!");
                FireRemain = 7;
            }
            else if(FireRemain > 1)
            {
                //code for message box
                MessageBox.Show("You missed the Bullet ");
                Bullet--;
                FireRemain--;
            }
            else
            {
                Bullet--;
                FireRemain--;
            }

            

            return FireRemain;
        }

        public int ShootingAway()
        {

            if (Bullet == 1)
            {
                //code for message box
                MessageBox.Show("You win the game, Total Score is 100");
                ShootingAwayChances= 7;
            }
            else if (ShootingAwayChances > 1)
            {
                //code for message box
                MessageBox.Show("Loss Chance");
                Bullet--;
                ShootingAwayChances--;
            }
            else
            {
                Bullet--;
                ShootingAwayChances--;
            }
            
            //return the bullet code
            return ShootingAwayChances;

        }
    }
}

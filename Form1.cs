using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EZInput;

namespace CarGame
{
    public partial class Form1 : Form
    {
        
        int speed = 5;
        PictureBox[] enemy;
        PictureBox[] barrel;
        int count = 0;
        int count1 = 50;
        bool check = false;
        int score;
        List<PictureBox> shoot;
        public Form1()
        {
            InitializeComponent();
            StartGame();
        }

        private void StartGame()
        {
            enemy = new PictureBox[4];
            barrel = new PictureBox[4];
            shoot = new List<PictureBox>();

        }
        
        private void pbplayer_Click(object sender, EventArgs e)
        {

        }
        private void movement()
        {
            if (Keyboard.IsKeyPressed(Key.RightArrow))
            {
                if (pbplayer.Left + pbplayer.Width < this.Width)
                {
                    pbplayer.Left = pbplayer.Left + 10;
                }
            }
            if (Keyboard.IsKeyPressed(Key.LeftArrow))
            {
                pbplayer.Left = pbplayer.Left - 10;
            }
            if (Keyboard.IsKeyPressed(Key.UpArrow))
            {
                pbplayer.Top = pbplayer.Top - 10;
            }
            if (Keyboard.IsKeyPressed(Key.DownArrow))
            {
                pbplayer.Top = pbplayer.Top + 10;
            }
            if (Keyboard.IsKeyPressed(Key.Space))
            {
                createfire();
            }
        }
        private void createfire()
        {
            Image img = CarGame.Properties.Resources.bullet;
            PictureBox pbfire = generateshoot(img);
            shoot.Add(pbfire);
            this.Controls.Add(pbfire);
        }
        private void fuelmove()
        {
            for(int i = 0; i < 4; i++)
            {
                if (barrel[i] != null)
                {
                    barrel[i].Top += speed;
                }
            }
            if (barrel[0] != null)
            {
                if (count < 50)
                {
                    barrel[0].Left += 5;
                }
                else if (count < 90)
                {
                    barrel[0].Left -= 5;
                }
                else
                {
                    count = 0;
                }
                count++;
            }
        }

        private void enemymoves()
        {
            for(int i = 0; i <4; i++)
            {
                if (enemy[i] != null)
                {
                    enemy[i].Top += speed;
                }
            }

            if (enemy[0] != null)
            {
                if (count < 40)
                {
                    enemy[0].Left += 5;
                }
                else if (count < 80)
                {
                    enemy[0].Left -= 5;
                }
                else
                {
                    count = 0;
                }
                count++;
            }
        }
        private PictureBox makefuel(Image img, int left, int top)
        {
            PictureBox barel = new PictureBox();

            barel.Image = img;
            barel.Height = img.Height;
            barel.Width = img.Width;
            barel.Left = left;
            barel.Top = top;
            barel.BackColor = Color.Transparent;
            barel.Size = new System.Drawing.Size(50, 78);
            barel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Controls.Add(barel);
            return barel;
        }
        private PictureBox makeEnemyCar(Image img, int left, int top)
        {
            PictureBox enemy1 = new PictureBox();
          
            enemy1.Image = img;
            enemy1.Height = img.Height;
            enemy1.Width = img.Width;
            enemy1.Left = left;
            enemy1.Top = top;
            enemy1.BackColor = Color.Transparent;
            enemy1.Size = new System.Drawing.Size(100, 128);
            enemy1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Controls.Add(enemy1);
            return enemy1;
        }

        private void generateCar()
        {
            if(enemy[1] == null)
            {
                Image img = CarGame.Properties.Resources.Black_viper1;
                enemy[1] = makeEnemyCar(img, 150, -50);
            }

            if(enemy[0] == null)
            {
                Image img = CarGame.Properties.Resources.Police;
                enemy[0] = makeEnemyCar(img, 350, -150);
            }
            if (score == 100)
            {

                if (enemy[2] == null)
                {
                    Image img = CarGame.Properties.Resources.Car_3_01;
                    enemy[2] = makeEnemyCar(img, 380, -256);
                }
            }
            if (enemy[3] == null)
            {
                Image img = CarGame.Properties.Resources.Audi;
                enemy[3] = makeEnemyCar(img, 286, -180);

            }
        }
        private PictureBox generateshoot(Image img)
        {
            PictureBox shoot = new PictureBox();

            shoot.Image = img;
            shoot.Height = img.Height;
            shoot.Width = img.Width;
            shoot.Left = pbplayer.Left - 13;
            shoot.Top = pbplayer.Top+15;
            shoot.BackColor = Color.Transparent;
            shoot.Size = new System.Drawing.Size(127, 121);
            shoot.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;

            return shoot;

        }       
        private void generatefuel()
        {
            if (barrel[1] == null)
            {
                Image img = CarGame.Properties.Resources.fuel;
                barrel[1] = makefuel(img, 170, -60);
            }
            if (barrel[0] == null)
            {
                Image img = CarGame.Properties.Resources.fuel;
                barrel[0] = makefuel(img, 234, -200);
            }
        }
        private void removefuel()
        {
            for (int i = 0; i < 4; i++)
            {
                if (barrel[i] != null)
                {
                    if (barrel[i].Top >= this.Height)
                    {
                        barrel[i] = null;
                    }
                }
            }

        }
       
        private void removeCar()
        {
            for(int i = 0; i < 4; i++)
            {
                if(enemy[i] != null)
                {
                    if(enemy[i].Top >= this.Height)
                    {
                        enemy[i] = null;
                    }
                }
            }
        }
        private void collosions()
        {
            for (int j = 0; j < 4; j++)
            {
                if (enemy[j] != null)
                {
                    if (pbplayer.Bounds.IntersectsWith(enemy[j].Bounds))
                    {
                        
                        carHealth.Value -= 10;
                        check = true;
                        enemy[j].Visible = false;
                        count1 = 50;
                    }
                }
            }

            for(int i = 0; i < shoot.Count; i++)
            {
                for (int x = 0; x < 4; x++)
                {
                    if (enemy[x] != null && shoot.Count > 0)
                    {
                        if (shoot[i].Bounds.IntersectsWith(enemy[x].Bounds))
                        {
                            this.Controls.Remove(enemy[x]);
                            enemy[x] = null;
                            this.Controls.Remove(shoot[i]);
                            shoot.Remove(shoot[i]);
                        }
                    }
                }
            }
        }
        private void calculatescore()
        { 
            for(int j = 0; j < 4; j++)
            {
                if (barrel[j] != null)
                {
                    if (pbplayer.Bounds.IntersectsWith(barrel[j].Bounds))
                    {
                        score++;
                        barrel[j].Hide();

                    }

                }
            }
            lblscore.Text = score.ToString();

        }
        private void gameover()
        {
            this.Hide();
            GameLoop.Enabled = false;
            Form f = new gameover();
            f.ShowDialog();

        }
        int num = 100;
        private void increasespeed()
        {
            if (num == 0)
            {
                speed += 5;
                num = 100;
            }
            num--;
            count1--;
            if (count1 == 0)
            {
                check = false;
            }
        }
        private void detectgameover()
        {
            if (check == false)
            {
                collosions();
            }
            if (carHealth.Value == 0)
            {

                gameover();
            }
        }

        private void MoveFire()
        {
            foreach(PictureBox fire in shoot)
            {
                fire.Top -= 19;
            }
        }

        private void GameLoop_Tick(object sender, EventArgs e)
        {
            movement();
            enemymoves();
            generateCar();
            removeCar();
            generatefuel();
            fuelmove();
            removefuel();
            calculatescore();
            detectgameover();
            increasespeed();
            MoveFire();


        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void Score1_Click(object sender, EventArgs e)
        {

        }

        private void Score_Click(object sender, EventArgs e)
        {
           
        }
    }
}
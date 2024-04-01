using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;


namespace HeroAutoGame
{
    internal class Fight
    {
        Hero leftPlayer;
        Hero rightPlayer;
        Weather weather;
        System.Windows.Forms.Label label;
        Form form;
        public Fight(Hero leftPlayer, Hero rightPlayer, Weather weather, Form form)
        {
            this.form = form;
            this.leftPlayer = leftPlayer;
            this.rightPlayer = rightPlayer;
            this.weather = weather;
            initializeLabel();
            startFight();
        }
        private void initializeLabel()
        {
            label = new System.Windows.Forms.Label();
            label.BackColor = Color.Transparent;
            label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            label.ForeColor = Color.Black ;
            label.AutoSize = false;
            label.Size = new Size(300, 300);
            label.Location = new Point(1188 / 2 - label.Width / 2,
                679 / 2 - label.Size.Height / 2);
            label.SendToBack();
            label.Visible = true;
        }
        public void Player1Attack()
        {
            Func<int, int, int> damageRecievePlayer2 = rightPlayer.getAttacked;
            // Hero_Viewer.mainStats(player1); //Stats in the moment
            // Console.WriteLine(" PLAYER 1 - " + player1.Name + " attacking:");
            int dmg = damageRecievePlayer2(leftPlayer.phisicalAttack(), leftPlayer.magicalAttack()); // damaging Hero 2
            leftPlayer.DamageCounter(dmg); //counting dealt damage
            leftPlayer.other(rightPlayer, dmg);
            //  Hero_Viewer.mainStats(player2);//Stats in the moment

        }
        public void Player2attack()
        {
            Func<int, int, int> damageRecievePlayer1 = leftPlayer.getAttacked;
            // Hero_Viewer.mainStats(player1); //Stats in the moment
            //  Console.WriteLine(" PLAYER 2 - " + player2.Name + " attacking:");
            int dmg = damageRecievePlayer1(rightPlayer.phisicalAttack(), rightPlayer.magicalAttack()); // damaging Hero 1
            rightPlayer.DamageCounter(dmg); //counting dealt damage
            rightPlayer.other(leftPlayer, dmg);
            // Hero_Viewer.mainStats(player2);

        }
        private bool isHeroAlive(Hero cheked, Hero player)
        {
            if (!cheked.isHeroAlive())
            {
                label.Text = player.Name + " WINNER";
                //form.Controls.Clear();
                return false;
            }
            return true;
        }
        private void startFight()
        {
            // round = 1;
            //BeforeFightHeroesStats();
            // timer.Start();
            while (true)
            {
                //FightStore(artefacts_LVL1, artefacts_LVL2);
                Player1Attack();
                if (!isHeroAlive(rightPlayer, leftPlayer)) break;
                Player2attack();
                if (!isHeroAlive(leftPlayer, rightPlayer)) break;
                // round++;
            }
            //timer.Stop();
        }
    }
}

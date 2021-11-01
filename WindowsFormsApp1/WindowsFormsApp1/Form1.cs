using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        AlphaBeta miniMaxAB;
        public Form1()
        {

            InitializeComponent();
            for (int i = 0; i < 9; i++)
                chessBoard.Controls.Add(new PictureBox());
            foreach (PictureBox pb in chessBoard.Controls)
            {
                pb.Height = pb.Width = (chessBoard.Height -20) / 3;
                pb.BorderStyle = BorderStyle.Fixed3D;
                pb.Click += new System.EventHandler(this.chessBoard_Click);
            }
            miniMaxAB = new AlphaBeta(8);

        }
        private void chessBoard_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < chessBoard.Controls.Count; i++)
                if (sender == chessBoard.Controls[i])
                {
                    if (miniMaxAB.chessBoard[i / 3, i % 3] != AlphaBeta.Blank) break;
                    if (!miniMaxAB.endOfGame)
                    {
                        Color slateBlue = Color.FromName("SlateBlue"); //人的颜色
                        Color green = Color.FromName("Green");//电脑的颜色
                        ((PictureBox)sender).BackColor = slateBlue;
                        miniMaxAB.putChess(i, AlphaBeta.Player, miniMaxAB.chessBoard);
                        
                        int result = -1;
                        miniMaxAB.search(ref result, -100, 100, miniMaxAB.depth, AlphaBeta.Computer);
                        if (!miniMaxAB.CheckFull())
                        {
                            if (miniMaxAB.JudgeWinner() == AlphaBeta.Computer)
                            {
                                MessageBox.Show("Computer Win!");
                                miniMaxAB.endOfGame = true;
                                break;
                            }
                            else if (miniMaxAB.JudgeWinner() == AlphaBeta.Player)
                            {
                                MessageBox.Show("Player Win!");
                                miniMaxAB.endOfGame = true;
                                break;
                            }
                            else if (miniMaxAB.JudgeWinner() == AlphaBeta.Blank)
                            {
                                MessageBox.Show("Respect!");
                                miniMaxAB.endOfGame = true;
                                break;

                            }
                            miniMaxAB.putChess(result, AlphaBeta.Computer, miniMaxAB.chessBoard);
                            ((PictureBox)chessBoard.Controls[result]).BackColor = green;
                        }
                        
                    }
                    if (miniMaxAB.JudgeWinner() == AlphaBeta.Computer)
                    {
                        MessageBox.Show("Computer Win!");
                        miniMaxAB.endOfGame = true;
                    }
                    else if (miniMaxAB.JudgeWinner() == AlphaBeta.Player)
                    {
                        MessageBox.Show("Player Win!");
                        miniMaxAB.endOfGame = true;
                    }
                    else if (miniMaxAB.JudgeWinner() == AlphaBeta.Blank)
                    {
                        MessageBox.Show("Respect!");
                        miniMaxAB.endOfGame = true;
                    }
                }
        }

        private void reset_Click(object sender, EventArgs e)
        {
            miniMaxAB = new AlphaBeta(8);
            for (int i = 0; i < chessBoard.Controls.Count; i++) ((PictureBox)chessBoard.Controls[i]).BackColor = SystemColors.Control;
        }

        private void computer_Start_Click(object sender, EventArgs e)
        {
            if (!miniMaxAB.endOfGame)
            {
                Random rnd = new Random();
                int rnd_start = rnd.Next(0, 8);
                Color slateBlue = Color.FromName("SlateBlue"); //人的颜色
                Color green = Color.FromName("Green");//电脑的颜色
                miniMaxAB.putChess(rnd_start, AlphaBeta.Player, miniMaxAB.chessBoard);
                ((PictureBox)chessBoard.Controls[rnd_start]).BackColor = slateBlue;
                Refresh();
                Thread.Sleep(2000);
                while (!miniMaxAB.endOfGame && !miniMaxAB.CheckFull())
                {
                    int result = -1;
                    miniMaxAB.search(ref result, -100, 100, miniMaxAB.depth, AlphaBeta.Computer);
                    if (!miniMaxAB.CheckFull())
                    {
                        if (miniMaxAB.JudgeWinner() == AlphaBeta.Computer)
                        {
                            MessageBox.Show("Computer Win!");
                            Refresh();
                            miniMaxAB.endOfGame = true;
                            break;
                        }
                        else if (miniMaxAB.JudgeWinner() == AlphaBeta.Player)
                        {
                            MessageBox.Show("Player Win!");
                            Refresh();
                            miniMaxAB.endOfGame = true;
                            break;
                        }
                        else if (miniMaxAB.JudgeWinner() == AlphaBeta.Blank)
                        {
                            MessageBox.Show("Respect!");
                            Refresh();
                            miniMaxAB.endOfGame = true;
                            break;

                        }
                        miniMaxAB.putChess(result, AlphaBeta.Computer, miniMaxAB.chessBoard);
                        ((PictureBox)chessBoard.Controls[result]).BackColor = green;
                        Refresh();
                        Thread.Sleep(2000);
                    }
                    result = -1;
                    miniMaxAB.search(ref result, -100, 100, miniMaxAB.depth, AlphaBeta.Player);
                    if (!miniMaxAB.CheckFull())
                    {
                        if (miniMaxAB.JudgeWinner() == AlphaBeta.Computer)
                        {
                            MessageBox.Show("Computer Win!");
                            Refresh();
                            miniMaxAB.endOfGame = true;
                            break;
                        }
                        else if (miniMaxAB.JudgeWinner() == AlphaBeta.Player)
                        {
                            MessageBox.Show("Player Win!");
                            Refresh();
                            miniMaxAB.endOfGame = true;
                            break;
                        }
                        else if (miniMaxAB.JudgeWinner() == AlphaBeta.Blank)
                        {
                            MessageBox.Show("Respect!");
                            Refresh();
                            miniMaxAB.endOfGame = true;
                            break;

                        }
                        miniMaxAB.putChess(result, AlphaBeta.Player, miniMaxAB.chessBoard);
                        ((PictureBox)chessBoard.Controls[result]).BackColor = slateBlue;
                        Refresh();
                        Thread.Sleep(2000);
                    }
                    if (miniMaxAB.JudgeWinner() == AlphaBeta.Computer)
                    {
                        MessageBox.Show("Computer Win!");
                        Refresh();
                        miniMaxAB.endOfGame = true;
                        break;
                    }
                    else if (miniMaxAB.JudgeWinner() == AlphaBeta.Player)
                    {
                        MessageBox.Show("Player Win!");
                        Refresh();
                        miniMaxAB.endOfGame = true;
                        break;
                    }
                    else if (miniMaxAB.JudgeWinner() == AlphaBeta.Blank)
                    {
                        MessageBox.Show("Respect!");
                        Refresh();
                        miniMaxAB.endOfGame = true;
                        break;

                    }
                }

            }
            else MessageBox.Show("请单击重新开始游戏！");
            
        }

        private void computer_First_Click(object sender, EventArgs e)
        {
            if (!miniMaxAB.endOfGame)
            {
                Random rnd = new Random();
                int rnd_start = rnd.Next(0, 8);
                Color slateBlue = Color.FromName("SlateBlue"); //人的颜色
                Color green = Color.FromName("Green");//电脑的颜色
                miniMaxAB.putChess(rnd_start, AlphaBeta.Computer, miniMaxAB.chessBoard);
                ((PictureBox)chessBoard.Controls[rnd_start]).BackColor = green;
            }
            else MessageBox.Show("请单击重新开始游戏！");
        }
    }

    public class AlphaBeta
    {
        public const int Blank = 0;
        public const int Player = 2;
        public const int Computer = 1;
        public int depth;
        public int[,] chessBoard;
        public bool endOfGame;
        public AlphaBeta(int depth)
        {
            chessBoard = new int[3, 3];
            for (int i = 0; i <= 2; i++)
            {
                for (int j = 0; j <= 2; j++)
                {
                    chessBoard[i, j] = 0;
                }
            }
            endOfGame = false;
            this.depth = depth;
        }

        public int JudgeWinner()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int t = 1; t <= 2; t++)
                {
                    if (chessBoard[i, 0] == chessBoard[i, 1] && chessBoard[i, 1] == chessBoard[i, 2] && chessBoard[i, 0] == t) return t;
                    if (chessBoard[0, i] == chessBoard[1, i] && chessBoard[1, i] == chessBoard[2, i] && chessBoard[0, i] == t) return t;
                }
            }//行列判断
            for (int t = 1; t <= 2; t++)
            {
                if (chessBoard[0, 0] == chessBoard[1, 1] && chessBoard[1, 1] == chessBoard[2, 2] && chessBoard[0, 0] == t) return t;
                if (chessBoard[0, 2] == chessBoard[1, 1] && chessBoard[1, 1] == chessBoard[2, 0] && chessBoard[2, 0] == t) return t;
            }//对角线判断

            for (int i = 0; i <= 9; i++)
            {
                if (i == 9) return 0;
                if (chessBoard[i / 3, i % 3] == Blank) break;
            }
            return -1;//说明棋盘内目前没有三子一线
        }

        public bool CheckFull()
        {
            for (int i = 0; i < 9; i++)
            {
                if (chessBoard[i / 3, i % 3] == Blank) return false;
            }
            return true;
        }

        public int Evaluate()
        {
            int[,] tmp = new int[3, 3];//函数内用的搜索棋盘
            for (int i = 0; i <= 8; i++)
            {
                if (i >= 0 && i <= 2) tmp[0, i] = chessBoard[0, i];
                if (i >= 3 && i <= 5) tmp[1, i - 3] = chessBoard[1, i - 3];
                if (i >= 6 && i <= 8) tmp[2, i - 6] = chessBoard[2, i - 6];
            }//棋盘复制

            int max = 0;
            for (int i = 0; i < 9; i++) if (chessBoard[i / 3, i % 3] == Blank) tmp[i / 3, i % 3] = Computer;
            for (int i = 0; i < 3; i++)
            {
                if (tmp[i, 0] == tmp[i, 1] && tmp[i, 1] == tmp[i, 2] && tmp[i, 0] == Computer) max++;
                if (tmp[0, i] == tmp[1, i] && tmp[1, i] == tmp[2, i] && tmp[0, i] == Computer) max++;
            }//行列判断
            if (tmp[0, 0] == tmp[1, 1] && tmp[1, 1] == tmp[2, 2] && tmp[0, 0] == Computer) max++;
            if (tmp[0, 2] == tmp[1, 1] && tmp[1, 1] == tmp[2, 0] && tmp[2, 0] == Computer) max++;
            //对角线判断


            int min = 0;
            for (int i = 0; i < 9; i++) if (chessBoard[i / 3, i % 3] == Blank) tmp[i / 3, i % 3] = Player;
            for (int i = 0; i < 3; i++)
            {
                if (tmp[i, 0] == tmp[i, 1] && tmp[i, 1] == tmp[i, 2] && tmp[i, 0] == Player) min++;
                if (tmp[0, i] == tmp[1, i] && tmp[1, i] == tmp[2, i] && tmp[0, i] == Player) min++;
            }
            //行列判断
            if (tmp[0, 0] == tmp[1, 1] && tmp[1, 1] == tmp[2, 2] && tmp[0, 0] == Player) min++;
            if (tmp[0, 2] == tmp[1, 1] && tmp[1, 1] == tmp[2, 0] && tmp[2, 0] == Player) min++;
            //对角线判断

            return max - min;//说明棋盘内目前没有三子一线
        }
        public int search(ref int result, int Alpha, int Beta, int Depth, int Turn)
        {
            if (JudgeWinner() == Computer)//电脑赢
                return 99;
            if (JudgeWinner() == Player)//玩家赢
                return -99;
            
            int child_Result;
            if ((Depth == 0) || (CheckFull() == true))
                return Evaluate();

            if (Turn == Player) //MIN只改变Beta
                                //值的多少取决于本身、下一层中的Alpha、Beta的最小值
                                //而当Alpha>=Beta时，发生剪枝，所以正常情况下Alpha一定小于Beta，
                                //因此值只会来源于本身以及下一层的Alpha，即通过递归得到的child_Result
            {
                for (int i = 0; i < 9; i++)
                {
                    if (chessBoard[i / 3, i % 3] == Blank)
                    {
                        chessBoard[i / 3, i % 3] = Player;

                        child_Result = search(ref result, Alpha, Beta, Depth - 1, Computer);

                        chessBoard[i / 3, i % 3] = Blank;
                        if (child_Result < Beta)
                        {
                            if (Depth == depth)
                                result = i;//当递归返回到最上面一层的时候，此时的i即为最好的那个位置

                            //result = i;//当递归返回到最上面一层的时候，此时的i即为最好的那个位置
                            Beta = child_Result;
                            if (Alpha >= Beta) return Alpha;
                            //剪枝。因为当剪枝发生时，Alpha>=Beta，此为MIN层，其父亲层需要最大值，而Alpha正为此时的最大值
                        }
                    }

                }
                return Beta;//返回最小值
            }
            else //MAX只改变Alpha（值的多少取决于1.本身、下一层中的2.Alpha、3.Beta的最大值
                 //而当Alpha>=Beta时，发生剪枝，所以正常情况下Alpha一定小于Beta，所以
                 //值只会来源于本身以及下一层的Beta，即child_Result
            {
                for (int i = 0; i < 9; i++)
                {
                    if (chessBoard[i / 3, i % 3] == Blank)
                    {
                        chessBoard[i / 3, i % 3] = Computer;


                        child_Result = search(ref result, Alpha, Beta, Depth - 1, Player);

                        chessBoard[i / 3, i % 3] = Blank;
                        if (child_Result > Alpha)
                        {
                            if (Depth == depth)
                                result = i;//当递归返回到最上面一层的时候，此时的i即为最好的那个位置

                            Alpha = child_Result;//取极大值
                            if (Alpha >= Beta) return Beta;//剪枝
                        }
                    }
                }
                return Alpha;//返回最大值
            }
        }

        public void putChess(int i, int j, int[,] opChessBoard)
        {
            opChessBoard[i / 3, i % 3] = j;
        }
    }

}

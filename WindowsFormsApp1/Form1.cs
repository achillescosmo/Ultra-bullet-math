using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private System.Windows.Forms.Timer timer1;
        private int counter;
        ArrayList list;
        private int answeredQuestion;
        private Question currentQuestion;

        public Form1()
        {
            InitializeComponent();

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            //Tạo sẵn list câu hỏi
            list = new ArrayList();
            list.Add(new OpenendedQuestion("18288%16", "0"));
            list.Add(new OpenendedQuestion("7368/24", "37"));
            list.Add(new OpenendedQuestion("83+97", "180"));
            list.Add(new OpenendedQuestion("6*456", "2736"));
            list.Add(new OpenendedQuestion("768-97", "671"));
            list.Add(new OpenendedQuestion("6538-1923", "4615"));

            list.Add(new OpenendedQuestion("10101010 + 11001100", "0101110110"));
            list.Add(new OpenendedQuestion("12*12", "144"));
            list.Add(new OpenendedQuestion("8397+9716", "18113"));
            list.Add(new OpenendedQuestion("166*456", "75696"));
            list.Add(new OpenendedQuestion("77689-97163", "-19474"));
            list.Add(new OpenendedQuestion("11111100*10101010", "01010011101011000"));

            list.Add(new TrueFalseQuestion("(2^3)^4 = 2^7", "F"));
            list.Add(new TrueFalseQuestion("2^17 = 2^16+1", "F"));
            list.Add(new TrueFalseQuestion("1/((-2)^(-4))=16", "T"));
            list.Add(new TrueFalseQuestion("252 = 11111100 ", "T"));
            list.Add(new TrueFalseQuestion("f(abs(x))=f(sqrt(x^2))", "T"));
            list.Add(new TrueFalseQuestion("f(g(x))=g(f(x))", "F"));

            list.Add(new TrueFalseQuestion("Sin(x)+Cos(x)=1", "F"));
            list.Add(new TrueFalseQuestion("Tan(x)*Cot(x)=1", "T"));
            list.Add(new TrueFalseQuestion("(Sin(x))^6+(Cos(x))^6 = 1 - 3*((Sin(x))^2)(Cos(x))^2", "T"));
            list.Add(new TrueFalseQuestion("pi/2 = 90 độ", "F"));
            list.Add(new TrueFalseQuestion("Cos(x)*Cos(y)=(1/2)*[cos(x-y)+sin(x+y)]", "F"));
            list.Add(new TrueFalseQuestion("(177013)^2 = 31333602169", "T"));


            answeredQuestion = 0;

            //Đếm ngược thời gian, mặc định 2 phút
            counter = 120;
            timer1 = new System.Windows.Forms.Timer();
            random_Question();
            timer1.Tick += new EventHandler(timer1_Tick); //Mỗi lần đến mốc thời gian, gọi hàm timer1_Tick
            timer1.Interval = 1000; // Đặt mốc thời gian 1s
            timer1.Start();
            lblCountDown.Text = counter.ToString();
            //Sau khi bắt đầu, disable nút start và đặt điểm về mặc định
            btnStart.Enabled = false;
            lbPoint.Text = "0";
            lbResult.Text = "";
        }
        private void gameStart()
        {

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            counter--;
            if (counter == 0)
            {
                endOfGame(); //Hết thời gian, gọi hàm endOfGame 
                timer1.Stop();
            }

            lblCountDown.Text = counter.ToString(); //cập nhật thời gian còn lại
        }

        //Lấy ra 1 câu hỏi ngẫu nhiên trong pool
        private void random_Question()
        {
            var random = new Random();
            var listcCount = list.Count;
            if (list.Count == 0)
            {
                endOfGame(); //Hết câu hỏi, gọi hàm endOfGame
                return;
            }
            var randomElementInList = random.Next(0, list.Count);
            currentQuestion = (Question)list[randomElementInList];
            list.Remove(list[randomElementInList]);
            tbQuestion.Text = currentQuestion.Text;
            tbAnswer.Text = "";
            answeredQuestion += 1;
       
        }
        private void tbAnswer_KeyUp(object sender, KeyEventArgs e)
        {


        }
        // Tổng kết điểm
        private void endOfGame()
        {
            btnStart.Enabled = true;
            timer1.Stop();
            lbResult.ForeColor = System.Drawing.Color.BlueViolet;
            lbResult.Text = "Your score is " + lbPoint.Text + "/" + answeredQuestion;
            lbPoint.Text = "0";
            tbAnswer.Text = "";
            tbQuestion.Text = "";
        }

        //Xử lý khi nhấn nút
        private void tbAnswer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13) //phím Enter
            {
                if (tbQuestion.Text == "") return;	//Chưa nhập câu trả lời, kết thúc hàm
                e.Handled = true;
                try
                {
                    if (currentQuestion.CheckAnswer(tbAnswer.Text)) //Câu trả lời đúng
                    {
                        int point = Int32.Parse(lbPoint.Text) + 1;
                        lbPoint.Text = point.ToString();
                        lbResult.ForeColor = System.Drawing.Color.Green;    //Hiện kết quả
                        lbResult.Text = "True";
                    }
                    else    //Câu trả lời sai
                    {
                        lbResult.ForeColor = System.Drawing.Color.Red;      //Hiện kết quả
                        lbResult.Text = "False";
                    }
                    random_Question();
                }
                catch (Exception ex)
                {
                    lbResult.ForeColor = System.Drawing.Color.OrangeRed;
                    lbResult.Text = ex.Message;
                }
            }
        }
    }
}

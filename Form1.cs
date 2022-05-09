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
using System.Diagnostics;

namespace osAssignment1
{
    public partial class Form1 : Form
    {
        class Buffer
        {
            public String[] data;
            public int _in,_out;
        }

        private int bufferSize = 5, equCount = 100;
        Buffer buffer = new Buffer();

        void producer()
        {
            Random rand = new Random();
            for(int i = 0; i < equCount; i++)
            {
                Thread.Sleep(50);
                while ((buffer._in+1)% bufferSize == buffer._out);
                int cnt = rand.Next(3,6) - 1;
                string res = rand.Next(1, 100).ToString();
                for(int j = 0; j < cnt; j++)
                {
                    switch (rand.Next(4))
                    {
                        case 0:
                            res += " + ";
                            break;
                        case 1:
                            res += " - ";
                            break;
                        case 2:
                            res += " * ";
                            break;
                        case 3:
                            res += " / ";
                            break;
                    }
                    res += rand.Next(1,100).ToString();
                }

                bufferList.Items[buffer._in].BackColor = Color.Green;
                bufferList.Items[buffer._in].Text = res;
                buffer.data[buffer._in] = res;
                producerList.Items[i].Text = res;
                producerList.Items[i].BackColor = Color.Green;
                if (i > 3)
                {
                    producerList.Items[i-3].EnsureVisible();
                }
                buffer._in = (buffer._in + 1) % bufferSize;
                
            }
        }

        void consumer()
        {
            for(int i = 0; i < equCount; i++)
            {
                if (buffer._in == buffer._out)
                {
                    bufferList.Items[buffer._in].BackColor = Color.Blue;
                }
                while (buffer._in == buffer._out);
                bufferList.Items[buffer._out].BackColor = Color.Red;
                Thread.Sleep(50);
                string data = buffer.data[buffer._out];
                string[] datas = data.Split(" ");
                int res = 0, cur = Int32.Parse(datas[0]);
                for(int j = 1; j < datas.Length; j += 2)
                {
                    switch (datas[j])
                    {
                        case "+":
                            res += cur;
                            cur = Int32.Parse(datas[j + 1]);
                            break;
                        case "-":
                            res += cur;
                            cur = -Int32.Parse(datas[j + 1]);
                            break;
                        case "*":
                            cur *= Int32.Parse(datas[j + 1]);
                            break;
                        case "/":
                            cur /= Int32.Parse(datas[j + 1]);
                            break;
                    }
                }
                res += cur;
                consumerList.Items[i].Text = data + " = " + res.ToString();
                consumerList.Items[i].BackColor = Color.Green;
                bufferList.Items[buffer._out].BackColor = Color.White;
                if (i > 3)
                {
                    consumerList.Items[i-3].EnsureVisible();
                }
                buffer._out = (buffer._out + 1) % bufferSize;
            }
        }

        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            render();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SettingForm setting = new SettingForm();
            var res = setting.ShowDialog();
            if(res == DialogResult.OK)
            {
                bufferSize = setting.bufferSize;
                equCount = setting.equCount;
                render();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            render();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            buffer.data = new String[bufferSize];
            buffer._in = buffer._out = 0;
            Thread producerT = new Thread(() => producer());
            Thread consumerT = new Thread(() => consumer());
            producerT.Start();
            consumerT.Start();
            producerT.Join();
            consumerT.Join();
            FinishForm finishForm = new FinishForm();
            finishForm.finisMsg.Text = "메모리 크기 = "+ bufferSize.ToString() + "\n총" + equCount.ToString() + "개의 식을 계산하였습니다.";
            finishForm.ShowDialog();
        }

        private void render()
        {
            producerList.Clear();
            bufferList.Clear();
            consumerList.Clear();

            producerList.Columns.Add(new ColumnHeader());
            producerList.Columns[0].Width = producerList.Width - 35;
            producerList.HeaderStyle = ColumnHeaderStyle.None;

            consumerList.Columns.Add(new ColumnHeader());
            consumerList.Columns[0].Width = producerList.Width - 35;
            consumerList.HeaderStyle = ColumnHeaderStyle.None;

            bufferList.Columns.Add(new ColumnHeader());
            bufferList.Columns[0].Width = producerList.Width - 4;
            bufferList.HeaderStyle = ColumnHeaderStyle.None;
            bufferList.SmallImageList = new ImageList();
            bufferList.SmallImageList.ImageSize = new Size(1, (bufferList.Height - 10) / bufferSize);
            

            for (int i = 1; i <= equCount; i++)
            {
                producerList.Items.Add("(" + i.ToString() + ")");
                consumerList.Items.Add("(" + i.ToString() + ")");
            }
            for(int i = 1; i <= bufferSize; i++)
            {
                bufferList.Items.Add("(" + i.ToString() + ")");
                
            }
        }
    }
}

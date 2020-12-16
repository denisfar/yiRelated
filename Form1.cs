using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace yellowRelatedProducts
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();


        }

        private void idInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                
                    add();
            }
        }

        public void render(List<string> ids)
        {
            listBox1.Items.Clear();
            foreach (string id in ids)
                listBox1.Items.Add(id);

        }


        //clear list
        private void button1_Click(object sender, EventArgs e)
        {
            
            Program.clearList();
            render(new List<string>());


        }


        //add item
        private void button2_Click(object sender, EventArgs e)
        {
            add();
        }


        //delete item
        private void button5_Click(object sender, EventArgs e)
        {
            int index = listBox1.SelectedIndex;
            Program.deleteItem(index);
            render(Program.list.getList());
            if(listBox1.Items.Count>0)
                listBox1.SetSelected(index-1, true);
        }

        private void add()
        {
            if (idInput.Text != "" && int.TryParse(idInput.Text, out int i))
            {
                Program.AddToList(idInput.Text);                
                int index = listBox1.Items.Count - 1;
                listBox1.SetSelected(index, true);
            }
            idInput.Text = "";
        }


        //go
        private void button3_Click(object sender, EventArgs e)
        {
            int sleep = 1;
            button3.Text = "(" + sleep.ToString() + ")";
            button3.Enabled = false;
            button3.Refresh();
            for (int i= sleep; i>=0; i--)
            {
                
                System.Threading.Thread.Sleep(1000);
                button3.Text = "(" + i.ToString() + ")";
                button3.Refresh();
            }
            button3.Text = "running";


            int selected = 0;
            foreach(string item in Program.list.getList())
            {
               
                Clipboard.SetText(item);
                SendKeys.Send("^(v)");
                System.Threading.Thread.Sleep(900);

                SendKeys.Send("{ENTER}");
                System.Threading.Thread.Sleep(100);

                SendKeys.Send("^(a)");
                System.Threading.Thread.Sleep(50);

                SendKeys.Send("{DEL}");
                System.Threading.Thread.Sleep(50);

                listBox1.SelectedIndex = selected;
                selected++;
            }





            button3.Text = "Run";
            button3.Enabled = true;
        }
    }
}

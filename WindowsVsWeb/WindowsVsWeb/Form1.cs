﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsVsWeb
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string name;
        private void submitButton_Click(object sender, EventArgs e)
        {
            name = nameTextBox.Text;
            nameTextBox.Clear();
            MessageBox.Show("Submitted Data Successfully");
        }

        private void showButton_Click(object sender, EventArgs e)
        {
            
            outputTextBox.Text = name;
        }
    }
}

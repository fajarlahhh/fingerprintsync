﻿using SharpUpdate;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fingerprint
{
    public partial class FormSplashScreen : Form
    {

        public FormSplashScreen()
        {
            InitializeComponent();
            //this.BackColor = Color.RoyalBlue;
            //this.TransparencyKey = Color.RoyalBlue;
            lblVersi.Text = "v" + ProductVersion;
        }

        private void FormSplashScreen_Load(object sender, EventArgs e)
        {
        }
    }
}

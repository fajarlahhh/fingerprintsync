using System;
using System.Drawing;
using System.Windows.Forms;

namespace Fingerprint.Helper
{
    class TabMain : TabControl
    {
        private Point lastClickPos;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private ContextMenuStrip cms;

        public TabMain()
        {
            cms = getCMS();
        }

        private ContextMenuStrip getCMS()
        {
            ContextMenuStrip _cms = new ContextMenuStrip();
            _cms.Items.Add("Tutup", null, new EventHandler(RemoveTab_Clicked));
            _cms.Items.Add("Tutup Semua", null, new EventHandler(RemoveAll_Clicked));
            return _cms;
        }

        private void RemoveAll_Clicked(object sender, EventArgs e)
        {
            for (int i = 0; i < this.TabCount; i++)
            {
                Rectangle rect = this.GetTabRect(i);
                this.TabPages.Clear();
            }
        }
        private void RemoveTab_Clicked(object sender, EventArgs e)
        {
            for (int i = 0; i < this.TabCount; i++)
            {
                Rectangle rect = this.GetTabRect(i);
                if (rect.Contains(this.PointToClient(lastClickPos)))
                {
                    this.TabPages.RemoveAt(i);
                }
            }
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            if (e.Button == MouseButtons.Right)
            {
                lastClickPos = Cursor.Position;
                cms.Show(Cursor.Position);
            }
        }

        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(200, 100);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(0, 0);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(200, 100);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(0, 0);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(200, 100);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}

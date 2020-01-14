using System;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;

namespace SharpUpdate
{
    /// <summary>
    /// Form to prompt the user to accept the update
    /// </summary>
    internal partial class SharpUpdateAcceptForm : Form
    {
        /// <summary>
        /// The program to update's info
        /// </summary>
        private SharpUpdateLocalAppInfo applicationInfo;

        /// <summary>
        /// The update info from the update.xml
        /// </summary>
        private SharpUpdateXml updateInfo;

        /// <summary>
        /// Creates a new SharpUpdateAcceptForm
        /// </summary>
        /// <param name="applicationInfo"></param>
        /// <param name="updateInfo"></param>
        internal SharpUpdateAcceptForm(SharpUpdateLocalAppInfo applicationInfo, SharpUpdateXml updateInfo, int num_cur_update, int num_total_update)
        {
            InitializeComponent();

            this.applicationInfo = applicationInfo;
            this.updateInfo = updateInfo;

            this.Text = string.Format("{0} - ({1}/{2}) Update Tersedia", this.applicationInfo.ApplicationName, num_cur_update, num_total_update);
            //this.lblUpdateAvail.Text = "An update for \"" + this.applicationInfo.ApplicationID + "\" is available.\r\nWould you like to update?";

            // Assigns the icon if it isn't null
            if (this.applicationInfo.ApplicationIcon != null)
                this.Icon = this.applicationInfo.ApplicationIcon;

            this.lblNewVersion.Text = updateInfo.Tag != JobType.REMOVE ?
                string.Format(updateInfo.Tag == JobType.UPDATE ? "Update: {0}\nVersi Baru: {1}" : "Baru: {0}\nVersi: {1}", Path.GetFileName(this.applicationInfo.ApplicationPath), this.updateInfo.Version.ToString()) :
                string.Format("Remove: {0}", Path.GetFileName(this.applicationInfo.ApplicationPath));
        }

        private void lblLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://dikbud.ntbprov.go.id/absensi/download/Setup_SIM_kendali.zip");
        }

        private void SharpUpdateAcceptForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}

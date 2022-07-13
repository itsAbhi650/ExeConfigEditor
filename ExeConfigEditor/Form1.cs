using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml;

namespace ExeConfigEditor
{
    public partial class Form1 : Form
    {
        Dictionary<string, string> Configurations = new Dictionary<string, string>();
        XmlDocument XDOC = new XmlDocument();
        XmlNodeList ConfigNodeList;
        XmlNode SelectedNode;
        string SelectedSettings;
        //Lost
        public Form1()
        {
            InitializeComponent();
        }

        private void propertyGrid1_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            GetNodeByKey(e.ChangedItem.Label, ConfigNodeList).Attributes[1].Value = e.ChangedItem.Value.ToString();
            string Log =
                       "EDIT NODE" + Environment.NewLine +
                       "=========================" + Environment.NewLine +
                       "*Key: " + e.ChangedItem.Label + Environment.NewLine +
                       "*Old Value: " + e.OldValue.ToString() + Environment.NewLine +
                       "*New Value: " + e.ChangedItem.Value.ToString() + Environment.NewLine +
                       "--------------------------------------------------" + Environment.NewLine;
            TbLog.AppendText(Log);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog OFD = new OpenFileDialog() { Filter = "Config Files (*.exe.Config)|*.exe.Config|All Files (*.*)|*.*" })
            {
                if (OFD.ShowDialog() == DialogResult.OK)
                {
                    textBox1.Text = OFD.FileName;
                    using (var Fstream = new FileInfo(OFD.FileName).OpenRead())
                    {

                        XDOC.Load(Fstream);
                    }
                }
            }
        }

        private XmlNode GetNodeByKey(string key, XmlNodeList NodeList)
        {
            XmlNode node = null;
            foreach (XmlNode _node in NodeList[0])
            {
                if (_node.Attributes[0].Value == key)
                {
                    node = _node;
                }
            }
            return node;
        }

        private void LoadSettings(string Settings)
        {
            if (XDOC != null)
            {
                ConfigNodeList = XDOC.GetElementsByTagName(Settings);
                LoadSettingIntl(ConfigNodeList);
            }
        }

        private void LoadSettingIntl(XmlNodeList NodeList)
        {
            Configurations.Clear();
            if (NodeList.Count > 0)
            {
                foreach (XmlNode node in NodeList[0])
                {
                    Configurations.Add(node.Attributes[0].Value, node.Attributes[1].Value);
                }
                propertyGrid1.SelectedObject = new DictionaryPropertyGridAdapter(Configurations);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XDOC.Save(textBox1.Text);
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog SFD = new SaveFileDialog() { Filter = "Executable Configuration File (*.exe.Config)|*.exe.Config|All Files (*.*)|*.*", AddExtension = true })
            {
                if (SFD.ShowDialog() == DialogResult.OK)
                {
                    XDOC.Save(SFD.FileName);
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog SFD = new SaveFileDialog() { Filter = "Text File (*.txt)|*.txt|All Files (*.*)|*.*" })
            {
                if (SFD.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllLines(SFD.FileName, TbLog.Lines);
                }
            }
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new About().ShowDialog();
        }

        private void propertyGrid1_SelectedGridItemChanged(object sender, SelectedGridItemChangedEventArgs e)
        {
            SelectedNode = GetNodeByKey(e.NewSelection.Label, ConfigNodeList);
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (ConfigNodeList!=null && ConfigNodeList[0].ChildNodes.Count > 0)
            {
                bool isInsert = false;
                using (AddDialog AD = new AddDialog() { Configs = Configurations.Keys.ToArray() })
                {
                    if (AD.ShowDialog() == DialogResult.OK)
                    {
                        XmlNode Node = ConfigNodeList[0].FirstChild.Clone();
                        Node.Attributes[0].Value = AD.Key;
                        Node.Attributes[1].Value = AD.Value;
                        switch (AD.NodeAddMode)
                        {
                            case AddMode.Prepend:
                                ConfigNodeList[0].PrependChild(Node);
                                break;
                            case AddMode.Append:
                                ConfigNodeList[0].AppendChild(Node);
                                break;
                            case AddMode.Insert:
                                isInsert = true;
                                XmlNode RelativeNode = GetNodeByKey(AD.RelativeNodeString, ConfigNodeList);
                                switch (AD.NodeInsertMode)
                                {
                                    case InsertMode.After:
                                        ConfigNodeList[0].InsertAfter(Node, RelativeNode);
                                        break;
                                    case InsertMode.Before:
                                        ConfigNodeList[0].InsertBefore(Node, RelativeNode);
                                        break;
                                }
                                break;
                        }
                        string Log =

                            "ADD NODE" + Environment.NewLine +
                            "=========================" + Environment.NewLine +
                            "*Key: " + AD.Key + Environment.NewLine +
                            "*Value: " + AD.Value + Environment.NewLine +
                            "*Add Mode: " + AD.NodeAddMode.ToString() + Environment.NewLine;
                        if (isInsert)
                        {
                            Log += "*Insert Mode: " + AD.NodeInsertMode.ToString() + Environment.NewLine;
                        }
                        Log += "--------------------------------------------------" + Environment.NewLine;
                        TbLog.AppendText(Log);
                        LoadSettingIntl(ConfigNodeList);
                    }
                }
            }
        }

        private void RbSettings_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rbtn = sender as RadioButton;
            if (rbtn.Checked)
            {
                SelectedSettings = rbtn.Text;
                LoadSettings(SelectedSettings);
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (SelectedNode != null)
            {
                XmlNode DelNode = SelectedNode;
                ConfigNodeList[0].RemoveChild(DelNode);
                LoadSettingIntl(ConfigNodeList);
                string log =
                             "DELETE NODE" + Environment.NewLine +
                             "=========================" + Environment.NewLine +
                             "*Key: " + DelNode.Attributes[0].Value + Environment.NewLine +
                             "*Value: " + DelNode.Attributes[1].Value + Environment.NewLine +
                             "--------------------------------------------------" + Environment.NewLine;
                TbLog.AppendText(log);
            }
        }
    }
}

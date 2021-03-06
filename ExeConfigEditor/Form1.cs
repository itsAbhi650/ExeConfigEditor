using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;

namespace ExeConfigEditor
{
    public partial class Form1 : Form
    {
        string[] args = Environment.GetCommandLineArgs().Skip(1).ToArray();
        Dictionary<string, object> Configurations = new Dictionary<string, object>();
        XmlDocument XDOC = new XmlDocument();
        XmlNodeList ConfigNodeList;
        XmlNode SelectedNode;
        string SelectedSettings;

        public Form1()
        {
            InitializeComponent();
            if (args.Count()>0)
            {
                LoadDocument(args[0]);
            }
        }

        private void propertyGrid1_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            string NewVal;
            string OldVal;
            if (e.ChangedItem.Value is Color ColorObj)
            {
                OldVal = ((Color)e.OldValue).Name;
                NewVal = ColorObj.Name;
            }
            else
            {
                OldVal = e.OldValue.ToString();
                NewVal = e.ChangedItem.Value.ToString();
            }
            GetNodeByKey(e.ChangedItem.Label, ConfigNodeList).Attributes[1].Value = NewVal;
            string Log =
                       "EDIT NODE" + Environment.NewLine +
                       "=========================" + Environment.NewLine +
                       "*Key: " + e.ChangedItem.Label + Environment.NewLine +
                       "*Old Value: " + OldVal + Environment.NewLine +
                       "*New Value: " + NewVal + Environment.NewLine +
                       "--------------------------------------------------" + Environment.NewLine;
            TbLog.AppendText(Log);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog OFD = new OpenFileDialog() { Filter = "Config Files (*.exe.Config)|*.exe.Config|All Files (*.*)|*.*" })
            {
                if (OFD.ShowDialog() == DialogResult.OK)
                {
                    LoadDocument(OFD.FileName);
                }
            }
        }

        private void LoadDocument(string XmlDocFilename)
        {
            textBox1.Text = XmlDocFilename;
            using (var Fstream = new FileInfo(XmlDocFilename).OpenRead())
            {
                XDOC.Load(Fstream);
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
            propertyGrid1.SelectedObject = null;
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
            if (ConfigNodeList != null && ConfigNodeList[0].ChildNodes.Count > 0)
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
                                isInsert = false;
                                ConfigNodeList[0].PrependChild(Node);
                                break;
                            case AddMode.Append:
                                isInsert = false;
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

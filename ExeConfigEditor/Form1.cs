using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace ExeConfigEditor
{
    public partial class Form1 : Form
    {
        XmlDocument XDOC = new XmlDocument();
        public Form1()
        {
            InitializeComponent();
        }

        private void propertyGrid1_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            XDOC.GetElementsByTagName("appSettings")[0].OfType<XmlNode>().First(x => x.Attributes["key"].Value == e.ChangedItem.Label).Attributes["value"].Value = e.ChangedItem.Value.ToString();
            textBox2.Text += string.Format("[ {0} ] {1} => {2}", e.ChangedItem.Label, e.OldValue.ToString(), e.ChangedItem.Value.ToString()) + Environment.NewLine;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog OFD = new OpenFileDialog() { Filter = "Config Files (*.Config)|*.Config|All Files (*.*)|*.*" })
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
            if (XDOC.GetElementsByTagName("appSettings").Count > 0)
            {

                var NodeList = XDOC
                    .GetElementsByTagName("appSettings")[0]
                    .OfType<XmlNode>()
                    .ToDictionary(x => x.Attributes["key"].Value, x => x.Attributes["value"].Value);

                propertyGrid1.SelectedObject = new DictionaryPropertyGridAdapter(NodeList);
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
                    File.WriteAllLines(SFD.FileName, textBox2.Lines);
                }
            }
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new About().ShowDialog();
        }
    }
}

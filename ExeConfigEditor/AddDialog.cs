using System;
using System.Windows.Forms;

namespace ExeConfigEditor
{
    public enum AddMode
    {
        Prepend = 0,
        Append = 1,
        Insert = 2
    }

    public enum InsertMode
    {
        After,
        Before
    }

    public partial class AddDialog : Form
    {
        public string RelativeNodeString { get; private set; }
        public string Value { get; private set; }
        public string Key { get; private set; }
        public System.Xml.XmlNode NewNode;
        public InsertMode NodeInsertMode;
        private string[] ConfigValues;
        public AddMode NodeAddMode;
        public string[] Configs
        {
            get
            {
                return ConfigValues;
            }
            set
            {
                ConfigValues = value;
                CmbBxConfigValues.DataSource = ConfigValues;
            }
        }

        public AddDialog()
        {
            InitializeComponent();
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TbKeyBox.Text) || string.IsNullOrEmpty(TbValueBox.Text))
            {
                MessageBox.Show("Key and Value must not be empty.");
            }
            else
            {
                Key = TbKeyBox.Text;
                Value = TbValueBox.Text;
            }
            DialogResult = DialogResult.OK;
        }

        private void RbAddMode_CheckChanged(object sender, EventArgs e)
        {
            RadioButton rbtn = sender as RadioButton;
            if (rbtn.Checked)
            {
                NodeAddMode = (AddMode)Convert.ToInt32(rbtn.Tag);
                if (NodeAddMode != AddMode.Insert)
                {
                    if (PnlInsertPanel.Visible)
                    {
                        PnlInsertPanel.Visible = false;
                        groupBox1.Height -= PnlInsertPanel.Height;
                        Height -= PnlInsertPanel.Height;
                    }
                }
                else
                {
                    Height += PnlInsertPanel.Height;
                    groupBox1.Height += PnlInsertPanel.Height;
                    PnlInsertPanel.Visible = true;
                }
            }
        }

        private void RbInsertMode_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rbtn = sender as RadioButton;
            if (rbtn.Checked)
            {
                NodeInsertMode = (InsertMode)Convert.ToInt32(rbtn.Tag);
            }
        }

        private void CmbBxConfigValues_SelectedIndexChanged(object sender, EventArgs e)
        {
            RelativeNodeString = CmbBxConfigValues.SelectedItem.ToString();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void AddDialog_Load(object sender, EventArgs e)
        {
            RbAppend.Checked = true;
        }

    }
}

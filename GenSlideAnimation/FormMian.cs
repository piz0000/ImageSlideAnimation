using System;
using System.Windows.Forms;

namespace ImageSlideAnimation
{
    public partial class FormMian : Form
    {
        private ComponentPaging component;


        public FormMian()
        {
            InitializeComponent();
        }

        private void FormPaging_Load(object sender, EventArgs e)
        {
            component = new ComponentPaging();

            tableLayoutPanel_Draw.Controls.Add(component.DrawBox, 0, 0);

            button_Before.Enabled = false;

            button_Next.Enabled = false;

            checkBox_Auto.Enabled = false;

            nm_AutoTime.Enabled = false;
        }

        private void button_SelectFolder_Click(object sender, EventArgs e)
        {
            component.SelectFolder();

            button_Before.Enabled = true;

            button_Next.Enabled = true;

            checkBox_Auto.Enabled = true;

            nm_AutoTime.Enabled = true;
        }

        private void button_Before_Click(object sender, EventArgs e)
        {
            component.BeforePage();
        }

        private void button_Next_Click(object sender, EventArgs e)
        {
            component.NextPage();
        }

        private void checkBox_Auto_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Auto.Checked)
            {
                button_Before.Enabled = false;

                button_Next.Enabled = false;

                component.AutoComplete += Component_AutoComplete;

                component.AutoStart(Convert.ToInt32(nm_AutoTime.Value));
            }
            else
            {
                component.AutoStop();

                button_Before.Enabled = true;

                button_Next.Enabled = true;
            }
        }

        private void Component_AutoComplete(object sender, EventArgs e)
        {
            checkBox_Auto.Invoke((MethodInvoker)delegate
            {
                checkBox_Auto.Checked = false;
            });

            component.AutoComplete -= Component_AutoComplete;
        }
    }
}

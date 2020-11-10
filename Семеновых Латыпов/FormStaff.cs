using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Семеновых_Латыпов
{
    public partial class FormStaff : Form
    {
        public FormStaff()
        {
            InitializeComponent();
            ShowList();
        }
        void ShowList()
        {
            listViewTables.Items.Clear();
            foreach (Tables tables in Program.cafedb.Tables)
            {
                ListViewItem item = new ListViewItem(new string[]
                {
                    tables.Id.ToString(), tables.Date, tables.Tables1, tables.Type
            });

                item.Tag = tables;
                listViewTables.Items.Add(item);

            }
            listViewTables.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

        }
        private void listViewTables_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBoxDate.Text))
            {
                textBoxDate.Text = "-";
            }
            if (String.IsNullOrEmpty(textBoxNumber.Text))
            {
                textBoxNumber.Text = "-";
            }
            Tables tables = new Tables();
            tables.Date = textBoxDate.Text;
            tables.Tables1 = textBoxNumber.Text;
            tables.Type = comboBoxAccept.Text;

            Program.cafedb.Tables.Add(tables);
            Program.cafedb.SaveChanges();
            ShowList();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (listViewTables.SelectedItems.Count == 1)
            {
                Tables tables = listViewTables.SelectedItems[0].Tag as Tables;
                tables.Date = textBoxDate.Text;
                tables.Tables1 = textBoxNumber.Text;
                tables.Type = comboBoxAccept.Text;
                Program.cafedb.SaveChanges();
                ShowList();
            }
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (listViewTables.SelectedItems.Count == 1)
                {
                    Tables tables = listViewTables.SelectedItems[0].Tag as Tables;
                    Program.cafedb.Tables.Remove(tables);
                    Program.cafedb.SaveChanges();
                    ShowList();
                }
                textBoxDate.Text = "";
                textBoxNumber.Text = "";
                comboBoxAccept.Text  = "";
            }
            catch
            {
                MessageBox.Show("Невозможно удалить, эта кнопка используется!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

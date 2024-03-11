using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            SetCBB();
            SetCBBQQ();
            SetCBBSort();
        }
        //cho khoa
        public void SetCBB()
        {
            cbb_Khoa.Items.Add(new CBBItem
            {
                value = 0,
                Text = "All"
            });
            cbb_Khoa.Items.AddRange(SVBUS.Instance.GetListCBB().ToArray());
        }
        // cho que quan
        public void SetCBBQQ()
        {
            cbb_QQ.Items.Add(new CBBItem
            {
                value = 0,
                Text = "All"
            });
            cbb_QQ.Items.AddRange(SVBUS.Instance.GetListCBBQQ().ToArray());
        }
        //cho sort
        public void SetCBBSort()
        {
            cbb_sort.Items.AddRange(SVBUS.Instance.GetListCBBSort().ToArray());
        }
        //show data cho gridview
        private void ShowDGV(string name)
        {
            dataGridView1.DataSource = SVBUS.Instance.GetListSV(name);
        }

    private void btn_Show_Click(object sender, EventArgs e)
        {
            ShowDGV(null);
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            ShowDGV(txtB_search.Text);
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count > 0)
            {
 
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                txtB_MSSV.Text = selectedRow.Cells["MaSV"].Value.ToString();
                txtB_HVT.Text = selectedRow.Cells["TenSV"].Value.ToString();
                dateTimePicker1.Value = (DateTime)selectedRow.Cells["NS"].Value;
                cbb_QQ.Text = selectedRow.Cells["QQ"].Value.ToString();
                txtB_HKTT.Text = selectedRow.Cells["HKTT"].Value.ToString();
                 if(selectedRow.Cells["GT"].Value.ToString()=="True")
                {
                    rbtn_Female.Checked = false;
                    rbtn_Male.Checked = true;

                }else if(selectedRow.Cells["GT"].Value.ToString() == "False")
                {
                    rbtn_Female.Checked = true;
                    rbtn_Male.Checked = false;
                }
                else
                {
                    rbtn_Female.Checked = false;
                    rbtn_Male.Checked = false;
                }
                txtB_GPA.Text = selectedRow.Cells["GPA"].Value.ToString();
                int maKhoaToSelect = (int)selectedRow.Cells["MaKhoa"].Value;


                for (int i = 0; i < cbb_Khoa.Items.Count; i++)
                {
                    CBBItem item = (CBBItem)cbb_Khoa.Items[i];
                    if (item.value == maKhoaToSelect)
                    {
                        cbb_Khoa.SelectedIndex = i;
                        break; 
                    }
                }


            }
            
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            bool? gt = null;
            if (rbtn_Female.Checked == false && rbtn_Male.Checked == true)
            {
                gt = true;
            }else if (rbtn_Female.Checked == true && rbtn_Male.Checked == false)
            {
                gt = false;
            }   else if (rbtn_Female.Checked == false && rbtn_Male.Checked == false)
            {
                gt = null;
            }

            CBBItem selectedCBBItem = (CBBItem)cbb_Khoa.SelectedItem;

            int itemValue = (selectedCBBItem != null) ? selectedCBBItem.value : 0;

            SV s = new SV
            (
                 int.TryParse(txtB_MSSV.Text, out int maSV) ? maSV : 0,
                txtB_HVT.Text,
              (DateTime?)dateTimePicker1?.Value,
                cbb_QQ.Text,
                txtB_HKTT.Text,
                 gt,
                 float.TryParse(txtB_GPA.Text, out float gpa) ? gpa : 0.0f,
              itemValue
            ) ;
         

            if (s != null)
            {
                SVBUS.Instance.ExcuteDB(s);
            }
            ShowDGV(null);
            MessageBox.Show("Update thanh cong");
            ClearComponents();
        }
        public void ClearComponents()
        { 
            txtB_MSSV.Text = string.Empty;
            txtB_HVT.Text = string.Empty;
            txtB_GPA.Text = string.Empty;
            txtB_HKTT.Text = string.Empty;
            dateTimePicker1.Value = DateTime.Now; 
          
            rbtn_Male.Checked = false;
            rbtn_Female.Checked = false;

        }

        private void btn_Del_Click(object sender, EventArgs e)
        {

          if(dataGridView1.SelectedRows.Count > 0)
            {
                List<string> LMSSV = new List<string>();
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                   
                    LMSSV.Add(row.Cells["MaSV"].Value.ToString());
                }
                SVBUS.Instance.DelSV(LMSSV);
               
                ShowDGV(null);
                MessageBox.Show("Xoa thanh cong");
            }
            else
            {
                MessageBox.Show("Chon hang di cu");
            }
            
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            Addform add =   new Addform();
            add.d = new Addform.MyDel(ShowDGV);
            add.Show();
        }

        private void btn_Sort_Click(object sender, EventArgs e)
        {
            List<SV> listSV = new List<SV>();
            if (txtB_search.Text.Length == 0)
            {
                listSV = SVBUS.Instance.GetListSV(null);
            } else
            {
                listSV = SVBUS.Instance.GetListSV(txtB_search.Text);
            }
            switch (cbb_sort.Text)
            {
                case "MaSV":
                    listSV.Sort((x, y) => x.MaSV.CompareTo(y.MaSV));
                    MessageBox.Show("Sap xep thanh cong");
                    break;
                case "TenSV":
                    listSV.Sort((x, y) => string.Compare(x.tenSV, y.tenSV));
                    MessageBox.Show("Sap xep thanh cong");
                    break;
                case "MaKhoa":
                    listSV.Sort((x, y) => x.MaKhoa.CompareTo(y.MaKhoa));
                    MessageBox.Show("Sap xep thanh cong");
                    break;
                case "GPA":
                    listSV.Sort((x, y) => x.GPA.CompareTo(y.GPA));
                    MessageBox.Show("Sap xep thanh cong");
                    break;
                default:
                    MessageBox.Show("Chon thuoc tinh di cu");
                    break;
            }
            dataGridView1.DataSource = listSV;
            dataGridView1.Show();     
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            txtB_MSSV.Enabled = false;
        }
    }
}

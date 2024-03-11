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
    public partial class Addform : Form
    {
     

        public delegate void MyDel(string name);
        public MyDel d {  get; set; }
        public Addform()
        {
            InitializeComponent();
            SetCBB();
            SetCBBQQ();
          
        }
        
        public void SetCBB()
        {
            cbb_Khoa_add.Items.Add(new CBBItem
            {
                value = 0,
                Text = "All"
            });
            cbb_Khoa_add.Items.AddRange(SVBUS.Instance.GetListCBB().ToArray());
        }
        public void SetCBBQQ()
        {
            cbb_QQ_add.Items.Add(new CBBItem
            {
                value = 0,
                Text = "All"
            });
            cbb_QQ_add.Items.AddRange(SVBUS.Instance.GetListCBBQQ().ToArray());
        }

        private void btn_Cal_add_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btn_OK_add_Click(object sender, EventArgs e)
        {
                bool? gt = null;
            if (rbtn_Female_add.Checked == false && rbtn_Male_add.Checked == true)
            {
                gt = true;
            }
            else if (rbtn_Female_add.Checked == true && rbtn_Male_add.Checked == false)
            {
                gt = false;
            }
            else if (rbtn_Female_add.Checked == false && rbtn_Male_add.Checked == false)
            {
                gt = null;
            }
            CBBItem selectedCBBItem = (CBBItem)cbb_Khoa_add.SelectedItem;

            int itemValue = (selectedCBBItem != null) ? selectedCBBItem.value : 0;
            SV s = new SV
            (
                 int.TryParse(txtB_MSSV_add.Text, out int maSV) ? maSV : 0,
                txtB_HVT_add.Text,
              (DateTime?)dateTimePicker1?.Value,
                cbb_QQ_add.Text,
                txtB_HKTT_add.Text,
                 gt,
                 float.TryParse(txtB_GPA_add.Text, out float gpa) ? gpa : 0.0f,
                itemValue
            );
            if (s != null)
            {
                SVBUS.Instance.ExcuteDB(s);
               
            }
           


            MessageBox.Show("Them thanh cong");
            d(null);
            this.Dispose();
        }
    }
}

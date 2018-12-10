using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;

namespace QLPK
{
    public partial class frmPhong : DevExpress.XtraEditors.XtraForm
    {
        qlpk1Entities2 c = new qlpk1Entities2();
        public frmPhong()
        {
            InitializeComponent();
        }

        private void textEdit5_EditValueChanged(object sender, EventArgs e)
        {

        }

        void show()
        {
            
        }

        void load()
        {
            var b = c.Khoas.Select(a=>a.TenKhoa);

            ComboBoxItemCollection item = cbNhom.Properties.Items;
            item.BeginUpdate();
            using (qlpk1Entities2 c = new qlpk1Entities2())
            {
                foreach (var i in b)
                {
                    item.Add(i);
                }
            }
            item.EndUpdate();
        }
        private void frmPhong_Load(object sender, EventArgs e)
        {
            load();

        }

        private void cbNhom_SelectedIndexChanged(object sender, EventArgs e)
        {
            gridPhong.BeginUpdate();
            try
            {
                string ma = cbNhom.Properties.GetDisplayText(cbNhom).ToString();
                var temp = c.Khoas.Where(a => a.TenKhoa==ma).Select(a => a.MaKhoa).FirstOrDefault();
                gridView1.Columns.Clear();
                gridPhong.DataSource = c.usp_ShowPhong(temp);

            }
            finally
            {
                gridPhong.EndUpdate();
            }
        }

    
        private void gridPhong_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

        }

        private void gridPhong_DoubleClick(object sender, EventArgs e)
        {

        }
    }
}
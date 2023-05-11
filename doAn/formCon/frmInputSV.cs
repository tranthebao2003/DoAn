﻿using doAn.List;
using doAn.Object;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace doAn.formCon
{
    public partial class frmInputSV : Form
    {
        public frmInputSV()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
             Close();
        }

        private void btnNhap_Click(object sender, EventArgs e)
        {
            // kiểm tra xem ng dung có nhập đủ thong tin hay ko
            if(txtInPutMaSV.Text == "" || txtInPutHo.Text =="" ||
            txtInPutTen.Text == "" ||
            txtInputSDT.Text == "")
            {
                MessageBox.Show(
               "Không được để trống thông tin",
               "Thông báo",
               MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // gán những thông tin ng dung da nhap vao sv
            SinhVien sv1 = new SinhVien();
            sv1.maSV = txtInPutMaSV.Text;
            sv1.ho = txtInPutHo.Text; 
            sv1.ten = txtInPutTen.Text;
            sv1.soDT = txtInputSDT.Text;
            if(radNu.Checked == true) // nếu ng dùng click vao nữ thì ta cho phai là true
            {
                sv1.phai = true;
            } 
            else if(radNam.Checked == true)
            {
                sv1.phai = false;
            }

            // bản chất thuật toán ko trùng mssv là:
            // nếu nó là node đầu thì gán nó vào dslk lun, còn ko thì ta sẽ so sánh mã sv của node vừa thêm vào (txtInPutMaSV.Text)
            // với all node trong dslk nếu trùng thì return lun còn ko trùng thì thêm nó vào dslk
            if (Program.objectDsSinhVien.head == null)
            {
                Program.objectDsSinhVien.add(sv1);
            }
            else
            {
                DsSinhVien.Node ptr = Program.objectDsSinhVien.head;

                while(ptr != null)
                {
                    if (ptr.sv.maSV == txtInPutMaSV.Text)
                    {
                        MessageBox.Show(
                        "Mã sinh viên bị trùng!",
                        "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    ptr = ptr.next;
                }
                Program.objectDsSinhVien.add(sv1);
            }
            // hiện thi ra dssv
            Program.objectDsSinhVien.display(Program.lvItem);
        }

        private void frmInputSV_Load(object sender, EventArgs e)
        {
            radNu.Checked = true; // mặc định khi chạy form này thì radian button nu se đc check
        }

    }
}

﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace JEMS.MyForm
{
    public partial class frm_CreateBatch : DevExpress.XtraEditors.XtraForm
    {
        private string _csvpath = "";
        private string[] _lFileNames;
        private bool _multi;
        private int soluonghinh;

        public frm_CreateBatch()
        {
            InitializeComponent();
        }

        private void btn_Browser_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txt_PathFolder.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void btn_BrowserImage_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_BatchName.Text))
            {
                MessageBox.Show("Vui lòng điền tên batch", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
           
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "All Types Image|*.bmp;*.jpg;*.jpeg;*.png;*.tif;*.tiff";

            dlg.Multiselect = true;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                _lFileNames = dlg.FileNames;
                txt_ImagePath.Text = Path.GetDirectoryName(dlg.FileName);
            }soluonghinh = 0;
            soluonghinh = dlg.FileNames.Length;
            lb_SoLuongHinh.Text = dlg.FileNames.Length + " files ";
        }

        private void btn_CreateBatch_Click(object sender, EventArgs e)
        {
            Global.db_BPO.UpdateTimeLastRequest(Global.Strtoken);
            backgroundWorker1.RunWorkerAsync();
        }

        private void txt_BatchName_EditValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_BatchName.Text))
            {
                _multi = false;
                txt_PathFolder.Enabled = false;
                btn_Browser.Enabled = false;
            }
            else
            {
                txt_PathFolder.Enabled = true;
                btn_Browser.Enabled = true;
            }
        }

        private void txt_PathFolder_EditValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_PathFolder.Text))
            {
                _multi = true;
                txt_BatchName.Enabled = false;
                txt_ImagePath.Enabled = false;
                btn_BrowserImage.Enabled = false;
            }
            else
            {
                txt_BatchName.Enabled = true;
                txt_ImagePath.Enabled = true;
                btn_BrowserImage.Enabled = true;
            }
        }

        private void frm_CreateBatch_Load(object sender, EventArgs e)
        {
            txt_UserCreate.Text = Global.StrUsername;
            txt_DateCreate.Text = DateTime.Now.ToShortDateString() + "  -  " + DateTime.Now.ToShortTimeString();

            txt_LoaiPhieu.DisplayMember = "Text";
            txt_LoaiPhieu.ValueMember = "Value";

            txt_LoaiPhieu.Items.Add(new { Text = "", Value = "" });
            txt_LoaiPhieu.Items.Add(new { Text = "AEON", Value = "AEON" });
            txt_LoaiPhieu.Items.Add(new { Text = "ASAHI", Value = "ASAHI" });
            txt_LoaiPhieu.Items.Add(new { Text = "EIZEN", Value = "EIZEN" });
            txt_LoaiPhieu.Items.Add(new { Text = "YAMAMOTO", Value = "YAMAMOTO" });
            txt_LoaiPhieu.Items.Add(new { Text = "YASUDA", Value = "YASUDA" });
            txt_LoaiPhieu.SelectedIndex = 0;

            cbb_loaithoigian.DisplayMember = "Text";
            cbb_loaithoigian.ValueMember = "Value";

            cbb_loaithoigian.Items.Add(new { Text = "", Value = "" });
            cbb_loaithoigian.Items.Add(new { Text = "Ngày", Value = "Ngay" });
            cbb_loaithoigian.Items.Add(new { Text = "Giờ", Value = "Gio" });
            cbb_loaithoigian.Items.Add(new { Text = "Phút", Value = "Phut" });
            cbb_loaithoigian.SelectedIndex = 0;
            dateEdit_ngaybatdau.DateTime = DateTime.Now;
            timeEdit_ngaybatdau.Time = DateTime.Now;
            timeEdit_ngayketthuc.Time = DateTime.Now;
            dateEdit_ngayketthuc.DateTime = DateTime.Now;
        }

        public static string[] GetFilesFrom(string searchFolder, string[] filters, bool isRecursive)
        {
            List<string> filesFound = new List<string>();
            var searchOption = isRecursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;
            foreach (var filter in filters)
            {
                filesFound.AddRange(Directory.GetFiles(searchFolder, $"*.{filter}", searchOption));
            }
            return filesFound.ToArray();
        }

        private void UpLoadSingle()
        {
            progressBarControl1.EditValue = 0;
            progressBarControl1.Properties.Step = 1;
            progressBarControl1.Properties.PercentView = true;
            progressBarControl1.Properties.Maximum = _lFileNames.Length;
            progressBarControl1.Properties.Minimum = 0;
            var batch = (from w in Global.db.tbl_Batches.Where(w => w.fBatchName == txt_BatchName.Text)select w.fBatchName).FirstOrDefault();
            if (!string.IsNullOrEmpty(txt_ImagePath.Text))
            {
                
                if (string.IsNullOrEmpty(batch))
                {
                    var fBatch = new tbl_Batch
                    {
                        fBatchName = txt_BatchName.Text,
                        fUserCreate = txt_UserCreate.Text,
                        fDateCreated = DateTime.Now,
                        fPathPicture = txt_ImagePath.Text,
                        fLocation = txt_Location.Text,
                        fSoLuongAnh = soluonghinh.ToString(),
                        fLoaiPhieu = txt_LoaiPhieu.Text
                        
                    };
                    Global.db.tbl_Batches.InsertOnSubmit(fBatch);
                    Global.db.SubmitChanges();


                    DateTime timeStart = new DateTime(dateEdit_ngaybatdau.DateTime.Ticks + timeEdit_ngaybatdau.Time.Ticks);
                    DateTime timeEnd = new DateTime(dateEdit_ngayketthuc.DateTime.Ticks + timeEdit_ngayketthuc.Time.Ticks);
                    int timeNotificationdeadline = 0;
                    if (cbb_loaithoigian.Text == "Ngày")
                    {
                        timeNotificationdeadline = Convert.ToInt32(nud_thoigiandeadline.Value * 24 * 60);
                    }
                    else if (cbb_loaithoigian.Text == "Giờ")
                    {
                        timeNotificationdeadline = Convert.ToInt32(nud_thoigiandeadline.Value * 60);
                    }
                    else if (cbb_loaithoigian.Text == "Phút")
                    {
                        timeNotificationdeadline = Convert.ToInt32(nud_thoigiandeadline.Value);
                    }
                    var fBatchEntry = new tbl_Batch_Entry()
                    {
                        fIDProject = Global.StrIdProject,
                        fBatchName = txt_BatchName.Text,
                        fUserCreate = txt_UserCreate.Text,
                        fDateCreated = DateTime.Now,
                        fPathPicture = txt_ImagePath.Text,
                        fLocation = txt_Location.Text,
                        fSoLuongAnh = soluonghinh.ToString(),
                        fLoaiPhieu = txt_LoaiPhieu.Text,
                        fTimeStart = timeStart,
                        fTimeEnd = timeEnd,
                        fDeadlineNotificationTime = timeNotificationdeadline
                    };
                    Global.db_BPO.tbl_Batch_Entries.InsertOnSubmit(fBatchEntry);
                    Global.db.SubmitChanges();
                }
                else
                {
                    MessageBox.Show("Batch đã tồn tại vui lòng điền tên batch khác!");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn hình ảnh!");
                return;
            }
            string temp = Global.StrPath + "\\" + txt_BatchName.Text;
            if (!Directory.Exists(temp))
            {
                Directory.CreateDirectory(temp);
            }
            else
            {
                MessageBox.Show("Bị trùng tên batch!");
                return;
            }
            foreach (string i in _lFileNames)
            {
                FileInfo fi = new FileInfo(i);
                tbl_Image tempImage = new tbl_Image
                {
                    fbatchname = txt_BatchName.Text,
                    idimage = Path.GetFileName(fi.ToString()),
                    ReadImageDESo = 0,
                    CheckedDESo = 0,
                    Checked_QC = 0,
                    TienDoDESO = "Hình chưa nhập",
                    CheckQC = false
                };
                Global.db.tbl_Images.InsertOnSubmit(tempImage);
                Global.db.SubmitChanges();

                tbl_TienDo tempTblTienDo = new tbl_TienDo
                {
                    IDProject = "JEMS",
                    fBatchName = txt_BatchName.Text,
                    Idimage = Path.GetFileName(fi.ToString()),
                    TienDoDeSo = "Hình chưa nhập",
                    UserCheckDeSo = "",
                    DateCreate = DateTime.Now
                };
                Global.db_BPO.tbl_TienDos.InsertOnSubmit(tempTblTienDo);
                Global.db_BPO.SubmitChanges();

                string des = temp + @"\" + Path.GetFileName(fi.ToString());
                fi.CopyTo(des);
                progressBarControl1.PerformStep();
                progressBarControl1.Update();
            }
            MessageBox.Show("Tạo batch mới thành công!");
            progressBarControl1.EditValue = 0;
            txt_BatchName.Text = "";
            txt_ImagePath.Text = "";
            lb_SoLuongHinh.Text = "";
            txt_LoaiPhieu.SelectedIndex = 0;

        }
        private void UpLoadMulti()
        {
            List<string> lStrBath = new List<string>();
            lStrBath.AddRange(Directory.GetDirectories(txt_PathFolder.Text));
            progressBarControl1.EditValue = 0;
            progressBarControl1.Properties.Step = 1;
            progressBarControl1.Properties.PercentView = true;
            progressBarControl1.Properties.Maximum = lStrBath.Count;
            progressBarControl1.Properties.Minimum = 0;

            foreach (string item in lStrBath)
            {
                var fBatch = new tbl_Batch
                {fBatchName = new DirectoryInfo(item).Name,
                    fUserCreate = txt_UserCreate.Text,
                    fDateCreated = DateTime.Now,
                    fPathPicture = item,
                    fLocation = txt_Location.Text,
                    fSoLuongAnh = Directory.GetFiles(item).Length.ToString()

                };
                Global.db.tbl_Batches.InsertOnSubmit(fBatch);
                Global.db.SubmitChanges();


                DateTime timeStart = new DateTime(dateEdit_ngaybatdau.DateTime.Ticks + timeEdit_ngaybatdau.Time.Ticks);
                DateTime timeEnd = new DateTime(dateEdit_ngayketthuc.DateTime.Ticks + timeEdit_ngayketthuc.Time.Ticks);
                int timeNotificationdeadline = 0;
                if (cbb_loaithoigian.Text == "Ngày")
                {
                    timeNotificationdeadline = Convert.ToInt32(nud_thoigiandeadline.Value * 24 * 60);
                }
                else if (cbb_loaithoigian.Text == "Giờ")
                {
                    timeNotificationdeadline = Convert.ToInt32(nud_thoigiandeadline.Value * 60);
                }
                else if (cbb_loaithoigian.Text == "Phút")
                {
                    timeNotificationdeadline = Convert.ToInt32(nud_thoigiandeadline.Value);
                }
                var fBatchEntry = new tbl_Batch_Entry()
                {
                    fIDProject = Global.StrIdProject,
                    fBatchName = txt_BatchName.Text,
                    fUserCreate = txt_UserCreate.Text,
                    fDateCreated = DateTime.Now,
                    fPathPicture = txt_ImagePath.Text,
                    fLocation = txt_Location.Text,
                    fSoLuongAnh = soluonghinh.ToString(),
                    fLoaiPhieu = txt_LoaiPhieu.Text,
                    fTimeStart = timeStart,
                    fTimeEnd = timeEnd,
                    fDeadlineNotificationTime = timeNotificationdeadline
                };
                Global.db_BPO.tbl_Batch_Entries.InsertOnSubmit(fBatchEntry);
                Global.db.SubmitChanges();


                string searchFolder = txt_PathFolder.Text + "\\" + new DirectoryInfo(item).Name;
                var filters = new String[] { "jpg", "jpeg", "png", "gif", "tiff", "bmp" };
                string[] tmp = GetFilesFrom(searchFolder, filters, false);
                string temp = Global.StrPath + "\\" + new DirectoryInfo(item).Name;
                Directory.CreateDirectory(temp);
                string imageJPG = "";
                foreach (string i in tmp)
                {
                    FileInfo fi = new FileInfo(i);
                    tbl_Image tempImage = new tbl_Image
                    {
                        fbatchname = new DirectoryInfo(item).Name,
                        idimage = Path.GetFileName(fi.ToString()),
                        ReadImageDESo = 0,
                        CheckedDESo = 0,
                        Checked_QC = 0,
                        TienDoDESO = "Hình chưa nhập",
                        CheckQC = false
                    };
                    Global.db.tbl_Images.InsertOnSubmit(tempImage);
                    Global.db.SubmitChanges();

                    tbl_TienDo tempTblTienDo = new tbl_TienDo
                    {
                        IDProject = "JEMS",
                        fBatchName = txt_BatchName.Text,
                        Idimage = Path.GetFileName(fi.ToString()),
                        TienDoDeSo = "Hình chưa nhập",
                        UserCheckDeSo = "",
                        DateCreate = DateTime.Now
                    };
                    Global.db_BPO.tbl_TienDos.InsertOnSubmit(tempTblTienDo);
                    Global.db_BPO.SubmitChanges();

                    string des = temp + @"\" + Path.GetFileName(fi.ToString());
                    fi.CopyTo(des);
                    progressBarControl1.PerformStep();
                    progressBarControl1.Update();
                }
                progressBarControl1.PerformStep();
                progressBarControl1.Update();
            }
            MessageBox.Show("Tạo batch mới thành công!");
            progressBarControl1.EditValue = 0;
            txt_BatchName.Text = "";
            txt_ImagePath.Text = "";
            lb_SoLuongHinh.Text = "";
            txt_LoaiPhieu.SelectedIndex = 0;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            if (string.IsNullOrEmpty(txt_LoaiPhieu.Text))
            {
                MessageBox.Show("Vui lòng chọn loại phiếu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if((nud_songaylam.Value!=0||nud_sogiolam.Value!=0||nud_sophutlam.Value!=0)&&(nud_thoigiandeadline.Value==0))
            {
                if(MessageBox.Show("Bạn chưa chọn thời gian thông báo deadline. Bạn vẫn tiếp tục","Thông báo",MessageBoxButtons.YesNo,MessageBoxIcon.Warning)==DialogResult.No)return;
            }
            if (_multi)
            {
                UpLoadMulti();
            }
            else
            {
                UpLoadSingle();
            }
        }

        private void frm_CreateBatch_FormClosed(object sender, FormClosedEventArgs e)
        {
        }
        private bool closePending;

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (backgroundWorker1.IsBusy)
            {
                closePending = true;
                backgroundWorker1.CancelAsync();
                e.Cancel = true;
                this.Enabled = false;   // or this.Hide()
                return;
            }
            base.OnFormClosing(e);
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (closePending) Close();
            closePending = false;
        }

        private bool flag = false;
        public void HandlingTimeWork()
        {
            try
            {
                if (!flag) return;
                DateTime timeStart = new DateTime(dateEdit_ngaybatdau.DateTime.Ticks + timeEdit_ngaybatdau.Time.Ticks);
                TimeSpan timeAdd = new TimeSpan(Convert.ToInt32(nud_songaylam.Value),Convert.ToInt32(nud_sogiolam.Value), Convert.ToInt32(nud_sophutlam.Value), 0);
                DateTime timeEnd = timeStart.Add(timeAdd);
                dateEdit_ngayketthuc.EditValue = timeEnd;
                timeEdit_ngayketthuc.EditValue = timeEnd;
            }
            catch{}
        }

        public void HandlingTimeWork_1()
        {
            try
            {
                if (flag) return;
                DateTime timeStart = new DateTime(dateEdit_ngaybatdau.DateTime.Ticks + timeEdit_ngaybatdau.Time.Ticks);
                DateTime timeEnd = new DateTime(dateEdit_ngayketthuc.DateTime.Ticks + timeEdit_ngayketthuc.Time.Ticks);
                TimeSpan time = timeEnd.Subtract(timeStart);
                nud_songaylam.Value = time.Days;
                nud_sogiolam.Value = time.Hours;
                nud_sophutlam.Value = time.Minutes;
            }
            catch{}
        }
        private void dateEdit_ngaybatdau_EditValueChanged(object sender, EventArgs e)
        {
            HandlingTimeWork();
        }

        private void timeEdit_ngaybatdau_EditValueChanged(object sender, EventArgs e)
        {
            HandlingTimeWork();
        }

        private void nud_songaylam_ValueChanged(object sender, EventArgs e)
        {
            HandlingTimeWork();
        }

        private void nud_sogiolam_ValueChanged(object sender, EventArgs e)
        {
            HandlingTimeWork();
        }

        private void nud_sophutlam_ValueChanged(object sender, EventArgs e)
        {
            HandlingTimeWork();
        }

        private void dateEdit_ngayketthuc_EditValueChanged(object sender, EventArgs e)
        {
            HandlingTimeWork_1();
        }

        private void timeEdit_ngayketthuc_EditValueChanged(object sender, EventArgs e)
        {
            HandlingTimeWork_1();
        }

        private void nud_thoigiandeadline_ValueChanged(object sender, EventArgs e)
        {
            DateTime timeStart = new DateTime(dateEdit_ngaybatdau.DateTime.Ticks + timeEdit_ngaybatdau.Time.Ticks);
            DateTime timeEnd = new DateTime(dateEdit_ngayketthuc.DateTime.Ticks + timeEdit_ngayketthuc.Time.Ticks);
            TimeSpan time = timeEnd.Subtract(timeStart);
            if (timeStart > timeEnd)
            {
                MessageBox.Show(string.Format("Ngày{0} kết thúc dự án không được trước ngày bắt đầu", ""));
                return;
            }
            if(cbb_loaithoigian.Text=="Ngày")
            {
                float ngay = (float)time.Days  + (float)time.Hours/24+(float)time.Minutes/(60*24);
                if (Convert.ToSingle(nud_thoigiandeadline.Value)>ngay)
                {
                    MessageBox.Show(string.Format("Thời{0} gian thông báo deadline không được lớn hơn thời gian thực hiện dự án\n Thời gian tối đa: " + ngay + " ngày{1}", "", ""));
                    nud_thoigiandeadline.Value = 0;return;
                }
            }
            else if (cbb_loaithoigian.Text == "Giờ")
            {
                float gio = (float)time.Days * 24 + (float)time.Hours+ (float)time.Minutes/60;
                if(Convert.ToSingle(nud_thoigiandeadline.Value)>gio)
                {
                    MessageBox.Show(string.Format("Thời{0} gian thông báo deadline không được lớn hơn thời gian thực hiện dự án\n Thời gian tối đa: " + gio + " giờ{1}", "", ""));
                    nud_thoigiandeadline.Value = 0;
                    return;
                }
            }
            else if (cbb_loaithoigian.Text == "Phút")
            {
                float phut = (float)time.Days * (24*60) + (float)time.Hours*60+ (float)time.Minutes;
                if (Convert.ToSingle(nud_thoigiandeadline.Value) > phut)
                {
                    MessageBox.Show(string.Format("Thời{0} gian thông báo deadline không được lớn hơn thời gian thực hiện dự án\n Thời gian tối đa: " + phut + " phút{1}", "", ""));
                    nud_thoigiandeadline.Value = 0;
                    return;
                }
            }
        }
        private void dateEdit_ngaybatdau_Click(object sender, EventArgs e)
        {
            flag = true;
        }

        private void timeEdit_ngaybatdau_Click(object sender, EventArgs e)
        {
            flag = true;
        }

        private void nud_songaylam_Click(object sender, EventArgs e)
        {
            flag = true;
        }

        private void nud_sogiolam_Click(object sender, EventArgs e)
        {
            flag = true;
        }

        private void nud_sophutlam_Click(object sender, EventArgs e)
        {
            flag = true;
        }

        private void dateEdit_ngayketthuc_Click(object sender, EventArgs e)
        {
            flag = false;
        }

        private void timeEdit_ngayketthuc_Click(object sender, EventArgs e)
        {
            flag = false;
        }

        private void cbb_loaithoigian_SelectedIndexChanged(object sender, EventArgs e)
        {
            nud_thoigiandeadline_ValueChanged(null, null);
        }
    }
}
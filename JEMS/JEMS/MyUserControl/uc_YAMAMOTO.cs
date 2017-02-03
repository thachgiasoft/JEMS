﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace JEMS.MyUserControl
{
    public partial class uc_YAMAMOTO : UserControl
    {
        List<Category> category = new List<Category>();
        public event AllTextChange Changed;
        private bool nonNumberEntered = false;

        public uc_YAMAMOTO()
        {
            InitializeComponent();
        }
        public class Category
        {
            public string Set_Value { get; set; }
        }
        private void SetDataLookUpEdit()
        {
            category.Add(new Category() { Set_Value = "" });
            category.Add(new Category() { Set_Value = "t" });
            category.Add(new Category() { Set_Value = "m3" });
            category.Add(new Category() { Set_Value = "kg" });
            category.Add(new Category() { Set_Value = "リットル" });
            category.Add(new Category() { Set_Value = "個・台" });
        }
        public void ResetData()
        {
            txt_Truong02.Text = "";
            txt_Truong03_1.Text = "";
            txt_Truong03_2.Text = "";

            txt_Truong05.Text = "";
            txt_Truong06.Text = "";
            txt_Truong07.Text = "";
            txt_Truong08.ItemIndex = 0;

            txt_Truong13.Text = "";
            txt_Truong14.Text = "";
            txt_Truong15.Text = "";
            txt_Truong16.ItemIndex = 0;

            txt_Truong21.Text = "";
            txt_Truong22.Text = "";
            txt_Truong23.Text = "";
            txt_Truong24.ItemIndex = 0;

            txt_Truong29.Text = "";
            txt_Truong30.Text = "";
            txt_Truong31.Text = "";
            txt_Truong32.ItemIndex = 0;

            txt_Truong37.Text = "";
            txt_Truong38.Text = "";
            txt_Truong39.Text = "";
            txt_Truong40.ItemIndex = 0;

            txt_Truong45.Text = "";
            txt_Truong46.Text = "";
            txt_Truong47.Text = "";
            txt_Truong48.ItemIndex = 0;

            txt_Truong53.Text = "";
            txt_Truong54.Text = "";
            txt_Truong55.Text = "";
            txt_Truong56.ItemIndex = 0;

            txt_Truong61.Text = "";
            txt_Truong62.Text = "";
            txt_Truong63.Text = "";
            txt_Truong64.ItemIndex = 0;

            txt_Truong69.Text = "";
            txt_Truong70.Text = "";
            txt_Truong71.Text = "";
            txt_Truong72.ItemIndex = 0;

            txt_Truong77.Text = "";
            txt_Truong78.Text = "";
            txt_Truong79.Text = "";
            txt_Truong80.ItemIndex = 0;
            
            txt_Truong85.Text = "";
            txt_Truong0.Text = "";
            txt_Truong86.Text = "";

            txt_Truong02.BackColor = Color.White;
            txt_Truong03_1.BackColor = Color.White;
            txt_Truong03_2.BackColor = Color.White;
            txt_Truong05.BackColor = Color.White;
            txt_Truong06.BackColor = Color.White;
            txt_Truong07.BackColor = Color.White;
            txt_Truong08.BackColor = Color.White;
            txt_Truong13.BackColor = Color.White;
            txt_Truong14.BackColor = Color.White;
            txt_Truong15.BackColor = Color.White;
            txt_Truong16.BackColor = Color.White;
            txt_Truong21.BackColor = Color.White;
            txt_Truong22.BackColor = Color.White;
            txt_Truong23.BackColor = Color.White;
            txt_Truong24.BackColor = Color.White;
            txt_Truong29.BackColor = Color.White;
            txt_Truong30.BackColor = Color.White;
            txt_Truong31.BackColor = Color.White;
            txt_Truong32.BackColor = Color.White;
            txt_Truong37.BackColor = Color.White;
            txt_Truong38.BackColor = Color.White;
            txt_Truong39.BackColor = Color.White;
            txt_Truong40.BackColor = Color.White;
            txt_Truong45.BackColor = Color.White;
            txt_Truong46.BackColor = Color.White;
            txt_Truong47.BackColor = Color.White;
            txt_Truong48.BackColor = Color.White;
            txt_Truong53.BackColor = Color.White;
            txt_Truong54.BackColor = Color.White;
            txt_Truong55.BackColor = Color.White;
            txt_Truong56.BackColor = Color.White;
            txt_Truong61.BackColor = Color.White;
            txt_Truong62.BackColor = Color.White;
            txt_Truong63.BackColor = Color.White;
            txt_Truong64.BackColor = Color.White;
            txt_Truong69.BackColor = Color.White;
            txt_Truong70.BackColor = Color.White;
            txt_Truong71.BackColor = Color.White;
            txt_Truong72.BackColor = Color.White;
            txt_Truong77.BackColor = Color.White;
            txt_Truong78.BackColor = Color.White;
            txt_Truong79.BackColor = Color.White;
            txt_Truong80.BackColor = Color.White;
            txt_Truong85.BackColor = Color.White;
            txt_Truong0.BackColor = Color.White;
            txt_Truong86.BackColor = Color.White;
        }

        public bool IsEmpty()
        {
            if (string.IsNullOrEmpty(txt_Truong02.Text) &&
                string.IsNullOrEmpty(txt_Truong03_1.Text) &&
                string.IsNullOrEmpty(txt_Truong03_2.Text) &&
                string.IsNullOrEmpty(txt_Truong05.Text) &&
                string.IsNullOrEmpty(txt_Truong06.Text) &&
                string.IsNullOrEmpty(txt_Truong07.Text) &&
                string.IsNullOrEmpty(txt_Truong08.Text) &&
                string.IsNullOrEmpty(txt_Truong13.Text) &&
                string.IsNullOrEmpty(txt_Truong14.Text) &&
                string.IsNullOrEmpty(txt_Truong15.Text) &&
                string.IsNullOrEmpty(txt_Truong16.Text) &&
                string.IsNullOrEmpty(txt_Truong21.Text) &&
                string.IsNullOrEmpty(txt_Truong22.Text) &&
                string.IsNullOrEmpty(txt_Truong23.Text) &&
                string.IsNullOrEmpty(txt_Truong24.Text) &&
                string.IsNullOrEmpty(txt_Truong29.Text) &&
                string.IsNullOrEmpty(txt_Truong30.Text) &&
                string.IsNullOrEmpty(txt_Truong31.Text) &&
                string.IsNullOrEmpty(txt_Truong32.Text) &&
                string.IsNullOrEmpty(txt_Truong37.Text) &&
                string.IsNullOrEmpty(txt_Truong38.Text) &&
                string.IsNullOrEmpty(txt_Truong39.Text) &&
                string.IsNullOrEmpty(txt_Truong40.Text) &&
                string.IsNullOrEmpty(txt_Truong45.Text) &&
                string.IsNullOrEmpty(txt_Truong46.Text) &&
                string.IsNullOrEmpty(txt_Truong47.Text) &&
                string.IsNullOrEmpty(txt_Truong48.Text) &&
                string.IsNullOrEmpty(txt_Truong53.Text) &&
                string.IsNullOrEmpty(txt_Truong54.Text) &&
                string.IsNullOrEmpty(txt_Truong55.Text) &&
                string.IsNullOrEmpty(txt_Truong56.Text) &&
                string.IsNullOrEmpty(txt_Truong61.Text) &&
                string.IsNullOrEmpty(txt_Truong62.Text) &&
                string.IsNullOrEmpty(txt_Truong63.Text) &&
                string.IsNullOrEmpty(txt_Truong64.Text) &&
                string.IsNullOrEmpty(txt_Truong69.Text) &&
                string.IsNullOrEmpty(txt_Truong70.Text) &&
                string.IsNullOrEmpty(txt_Truong71.Text) &&
                string.IsNullOrEmpty(txt_Truong72.Text) &&
                string.IsNullOrEmpty(txt_Truong77.Text) &&
                string.IsNullOrEmpty(txt_Truong78.Text) &&
                string.IsNullOrEmpty(txt_Truong79.Text) &&
                string.IsNullOrEmpty(txt_Truong80.Text) &&
                string.IsNullOrEmpty(txt_Truong85.Text) &&
                string.IsNullOrEmpty(txt_Truong0.Text) &&
                string.IsNullOrEmpty(txt_Truong86.Text))
                return true;
            return false;
        }

        private void txt_Truong02_EditValueChanged(object sender, EventArgs e)
        {
            if (txt_Truong02.Text.Length != 6 && txt_Truong02.Text != "" && txt_Truong02.Text != "?")
            {
                txt_Truong02.BackColor = Color.Red;
                txt_Truong02.ForeColor = Color.White;
            }
            else
            {
                txt_Truong02.BackColor = Color.White;
                txt_Truong02.ForeColor = Color.Black;

            }
            if (txt_Truong02.Text.ToString().IndexOf('?') >= 0)
                txt_Truong02.Text = "?";
            if (Changed != null)
                Changed(sender, e);
        }

        private void txt_Truong03_1_EditValueChanged(object sender, EventArgs e)
        {
            if (txt_Truong03_1.Text != "" && txt_Truong03_1.Text != "?")
            {
                if (txt_Truong03_1.Text.Length != 6)
                {
                    txt_Truong03_1.BackColor = Color.Red;
                    txt_Truong03_1.ForeColor = Color.White;
                }
                else
                {
                    txt_Truong03_1.BackColor = Color.White;
                    txt_Truong03_1.ForeColor = Color.Black;
                    txt_Truong03_2.Focus();
                }
            }
            else
            {
                txt_Truong03_1.BackColor = Color.White;
                txt_Truong03_1.ForeColor = Color.Black;
            }
            if (txt_Truong03_1.Text.ToString().IndexOf('?') >= 0)
                txt_Truong03_1.Text = "?";
            if (Changed != null)
                Changed(sender, e);
        }

        private void txt_Truong03_2_EditValueChanged(object sender, EventArgs e)
        {
            if (txt_Truong03_2.Text.Length != 6 && txt_Truong03_1.Text != "" && txt_Truong03_1.Text != "?")
            {
                txt_Truong03_2.BackColor = Color.Red;
                txt_Truong03_2.ForeColor = Color.White;
            }
            else
            {
                txt_Truong03_2.BackColor = Color.White;
                txt_Truong03_2.ForeColor = Color.Black;
            }
            if (txt_Truong03_2.Text.ToString().IndexOf('?') >= 0)
                txt_Truong03_2.Text = "?";
            if (Changed != null)
                Changed(sender, e);
        }
        private void Set_txtLengColumn1(object sender, EventArgs e, TextEdit tb)
        {
            if (tb.Text.Length != 2 && tb.Text != "" && tb.Text != "?")
            {
                tb.BackColor = Color.Red;
                tb.ForeColor = Color.White;
            }
            else
            {
                tb.BackColor = Color.White;
                tb.ForeColor = Color.Black;
            }
            if (tb.Text.ToString().IndexOf('?') >= 0)
                tb.Text = "?";
            if (Changed != null)
                Changed(sender, e);
        }

        private void Set_txtLengColumn2(object sender, EventArgs e,TextEdit tb)
        {
            if (tb.Text.ToString().IndexOf('?') >= 0)
                tb.Text = "?";
            if (Changed != null)
                Changed(sender, e);
        }
        private void Set_txtLengColumn3(object sender, EventArgs e,TextEdit tb)
        {
            if (tb.Text.ToString().IndexOf('?') >= 0)
                tb.Text = "?";
            if (Changed != null)
                Changed(sender, e);
        }
        private void txt_Truong05_EditValueChanged(object sender, EventArgs e)
        {
            Set_txtLengColumn1(sender, e, txt_Truong05);
        }

        private void txt_Truong13_EditValueChanged(object sender, EventArgs e)
        {
            Set_txtLengColumn1(sender, e, txt_Truong13);
        }

        private void txt_Truong21_EditValueChanged(object sender, EventArgs e)
        {
            Set_txtLengColumn1(sender, e, txt_Truong21);
        }

        private void txt_Truong29_EditValueChanged(object sender, EventArgs e)
        {
            Set_txtLengColumn1(sender, e, txt_Truong29);
        }

        private void txt_Truong37_EditValueChanged(object sender, EventArgs e)
        {
            Set_txtLengColumn1(sender, e, txt_Truong37);
        }

        private void txt_Truong45_EditValueChanged(object sender, EventArgs e)
        {
            Set_txtLengColumn1(sender, e, txt_Truong45);
        }

        private void txt_Truong53_EditValueChanged(object sender, EventArgs e)
        {
            Set_txtLengColumn1(sender, e, txt_Truong53);
        }

        private void txt_Truong61_EditValueChanged(object sender, EventArgs e)
        {
            Set_txtLengColumn1(sender, e, txt_Truong61);
        }

        private void txt_Truong69_EditValueChanged(object sender, EventArgs e)
        {
            Set_txtLengColumn1(sender, e, txt_Truong69);
        }

        private void txt_Truong77_EditValueChanged(object sender, EventArgs e)
        {
            Set_txtLengColumn1(sender, e, txt_Truong77);
        }

        private void txt_Truong06_EditValueChanged(object sender, EventArgs e)
        {
            Set_txtLengColumn2(sender, e, txt_Truong06);
        }

        private void txt_Truong14_EditValueChanged(object sender, EventArgs e)
        {
            Set_txtLengColumn2(sender, e, txt_Truong14);
        }

        private void txt_Truong22_EditValueChanged(object sender, EventArgs e)
        {
            Set_txtLengColumn2(sender, e, txt_Truong22);
        }

        private void txt_Truong30_EditValueChanged(object sender, EventArgs e)
        {
            Set_txtLengColumn2(sender, e, txt_Truong30);
        }

        private void txt_Truong38_EditValueChanged(object sender, EventArgs e)
        {
            Set_txtLengColumn2(sender, e, txt_Truong38);
        }

        private void txt_Truong46_EditValueChanged(object sender, EventArgs e)
        {
            Set_txtLengColumn2(sender, e, txt_Truong46);
        }

        private void txt_Truong54_EditValueChanged(object sender, EventArgs e)
        {
            Set_txtLengColumn2(sender, e, txt_Truong54);
        }

        private void txt_Truong62_EditValueChanged(object sender, EventArgs e)
        {
            Set_txtLengColumn2(sender, e, txt_Truong62);
        }

        private void txt_Truong70_EditValueChanged(object sender, EventArgs e)
        {
            Set_txtLengColumn2(sender, e, txt_Truong70);
        }

        private void txt_Truong78_EditValueChanged(object sender, EventArgs e)
        {
            Set_txtLengColumn2(sender, e, txt_Truong78);
        }

        private void txt_Truong07_EditValueChanged(object sender, EventArgs e)
        {
            Set_txtLengColumn3(sender, e, txt_Truong07);
        }

        private void txt_Truong15_EditValueChanged(object sender, EventArgs e)
        {
            Set_txtLengColumn3(sender, e, txt_Truong15);
        }

        private void txt_Truong23_EditValueChanged(object sender, EventArgs e)
        {
            Set_txtLengColumn3(sender, e, txt_Truong23);
        }

        private void txt_Truong31_EditValueChanged(object sender, EventArgs e)
        {
            Set_txtLengColumn3(sender, e, txt_Truong31);
        }

        private void txt_Truong39_EditValueChanged(object sender, EventArgs e)
        {
            Set_txtLengColumn3(sender, e, txt_Truong39);
        }

        private void txt_Truong47_EditValueChanged(object sender, EventArgs e)
        {
            Set_txtLengColumn3(sender, e, txt_Truong47);
        }

        private void txt_Truong55_EditValueChanged(object sender, EventArgs e)
        {
            Set_txtLengColumn3(sender, e, txt_Truong55);
        }

        private void txt_Truong63_EditValueChanged(object sender, EventArgs e)
        {
            Set_txtLengColumn3(sender, e, txt_Truong63);
        }

        private void txt_Truong71_EditValueChanged(object sender, EventArgs e)
        {
            Set_txtLengColumn3(sender, e, txt_Truong71);
        }

        private void txt_Truong79_EditValueChanged(object sender, EventArgs e)
        {
            Set_txtLengColumn3(sender, e, txt_Truong79);
        }
        private void txt_Truong85_EditValueChanged(object sender, EventArgs e)
        {
            if (txt_Truong85.Text.ToString().IndexOf('?') >= 0)
                txt_Truong85.Text = "?";
            if (Changed != null)
                Changed(sender, e);
        }

        private void txt_Truong0_EditValueChanged(object sender, EventArgs e)
        {
            if (txt_Truong0.Text.ToString().IndexOf('?') >= 0)
                txt_Truong0.Text = "?";
            if (txt_Truong0.Text != txt_Truong02.Text && txt_Truong0.Text != "" && txt_Truong0.Text != "?")
            {
                txt_Truong0.BackColor = Color.Red;
                txt_Truong0.ForeColor = Color.White;
                txt_Truong02.BackColor = Color.Red;
                txt_Truong02.ForeColor = Color.White;
            }
            else
            {
                txt_Truong0.BackColor = Color.White;
                txt_Truong0.ForeColor = Color.Black;
                txt_Truong02.BackColor = Color.White;
                txt_Truong02.ForeColor = Color.Black;
            }
            if (Changed != null)
                Changed(sender, e);
        }
        
        private void txt_Truong86_EditValueChanged(object sender, EventArgs e)
        {
            if (txt_Truong86.Text.ToString().IndexOf('?') >= 0)
                txt_Truong86.Text = "?";
            if (Changed != null)
                Changed(sender, e);
        }
        private void txt_Truong86_KeyDown(object sender, KeyEventArgs e)
        {
            nonNumberEntered = false;

            if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
            {
                if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                {
                    nonNumberEntered = true;
                }
            }
        }

        private void txt_Truong86_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (nonNumberEntered == false)
            {
                e.Handled = true;
            }
        }
        private void uc_ASAHI_Load(object sender, EventArgs e)
        {
            SetDataLookUpEdit();
            txt_Truong08.Properties.DataSource = category;
            txt_Truong08.Properties.DisplayMember = "Set_Value";
            txt_Truong08.Properties.ValueMember = "Set_Value";

            txt_Truong16.Properties.DataSource = category;
            txt_Truong16.Properties.DisplayMember = "Set_Value";
            txt_Truong16.Properties.ValueMember = "Set_Value";

            txt_Truong24.Properties.DataSource = category;
            txt_Truong24.Properties.DisplayMember = "Set_Value";
            txt_Truong24.Properties.ValueMember = "Set_Value";

            txt_Truong32.Properties.DataSource = category;
            txt_Truong32.Properties.DisplayMember = "Set_Value";
            txt_Truong32.Properties.ValueMember = "Set_Value";

            txt_Truong40.Properties.DataSource = category;
            txt_Truong40.Properties.DisplayMember = "Set_Value";
            txt_Truong40.Properties.ValueMember = "Set_Value";

            txt_Truong48.Properties.DataSource = category;
            txt_Truong48.Properties.DisplayMember = "Set_Value";
            txt_Truong48.Properties.ValueMember = "Set_Value";

            txt_Truong56.Properties.DataSource = category;
            txt_Truong56.Properties.DisplayMember = "Set_Value";
            txt_Truong56.Properties.ValueMember = "Set_Value";

            txt_Truong64.Properties.DataSource = category;
            txt_Truong64.Properties.DisplayMember = "Set_Value";
            txt_Truong64.Properties.ValueMember = "Set_Value";

            txt_Truong72.Properties.DataSource = category;
            txt_Truong72.Properties.DisplayMember = "Set_Value";
            txt_Truong72.Properties.ValueMember = "Set_Value";

            txt_Truong80.Properties.DataSource = category;
            txt_Truong80.Properties.DisplayMember = "Set_Value";
            txt_Truong80.Properties.ValueMember = "Set_Value";

            txt_Truong02.GotFocus += Txt_Truong02_GotFocus;
            txt_Truong03_1.GotFocus += Txt_Truong02_GotFocus;
            txt_Truong03_2.GotFocus += Txt_Truong02_GotFocus;
            txt_Truong05.GotFocus += Txt_Truong02_GotFocus;
            txt_Truong06.GotFocus += Txt_Truong02_GotFocus;
            txt_Truong07.GotFocus += Txt_Truong02_GotFocus;
            txt_Truong08.GotFocus += Txt_Truong02_GotFocus;
            txt_Truong13.GotFocus += Txt_Truong02_GotFocus;
            txt_Truong14.GotFocus += Txt_Truong02_GotFocus;
            txt_Truong15.GotFocus += Txt_Truong02_GotFocus;
            txt_Truong16.GotFocus += Txt_Truong02_GotFocus;
            txt_Truong21.GotFocus += Txt_Truong02_GotFocus;
            txt_Truong22.GotFocus += Txt_Truong02_GotFocus;
            txt_Truong23.GotFocus += Txt_Truong02_GotFocus;
            txt_Truong24.GotFocus += Txt_Truong02_GotFocus;
            txt_Truong29.GotFocus += Txt_Truong02_GotFocus;
            txt_Truong30.GotFocus += Txt_Truong02_GotFocus;
            txt_Truong31.GotFocus += Txt_Truong02_GotFocus;
            txt_Truong32.GotFocus += Txt_Truong02_GotFocus;
            txt_Truong37.GotFocus += Txt_Truong02_GotFocus;
            txt_Truong38.GotFocus += Txt_Truong02_GotFocus;
            txt_Truong39.GotFocus += Txt_Truong02_GotFocus;
            txt_Truong40.GotFocus += Txt_Truong02_GotFocus;
            txt_Truong45.GotFocus += Txt_Truong02_GotFocus;
            txt_Truong46.GotFocus += Txt_Truong02_GotFocus;
            txt_Truong47.GotFocus += Txt_Truong02_GotFocus;
            txt_Truong48.GotFocus += Txt_Truong02_GotFocus;
            txt_Truong53.GotFocus += Txt_Truong02_GotFocus;
            txt_Truong54.GotFocus += Txt_Truong02_GotFocus;
            txt_Truong55.GotFocus += Txt_Truong02_GotFocus;
            txt_Truong56.GotFocus += Txt_Truong02_GotFocus;
            txt_Truong61.GotFocus += Txt_Truong02_GotFocus;
            txt_Truong62.GotFocus += Txt_Truong02_GotFocus;
            txt_Truong63.GotFocus += Txt_Truong02_GotFocus;
            txt_Truong64.GotFocus += Txt_Truong02_GotFocus;
            txt_Truong69.GotFocus += Txt_Truong02_GotFocus;
            txt_Truong70.GotFocus += Txt_Truong02_GotFocus;
            txt_Truong71.GotFocus += Txt_Truong02_GotFocus;
            txt_Truong72.GotFocus += Txt_Truong02_GotFocus;
            txt_Truong77.GotFocus += Txt_Truong02_GotFocus;
            txt_Truong78.GotFocus += Txt_Truong02_GotFocus;
            txt_Truong79.GotFocus += Txt_Truong02_GotFocus;
            txt_Truong80.GotFocus += Txt_Truong02_GotFocus;
            txt_Truong85.GotFocus += Txt_Truong02_GotFocus;
            txt_Truong0.GotFocus += Txt_Truong02_GotFocus;
            txt_Truong86.GotFocus += Txt_Truong02_GotFocus;
        }

        private void Txt_Truong02_GotFocus(object sender, EventArgs e)
        {
            ((TextEdit)sender).SelectAll();
        }
        public void SaveData_ASAHI(string idImage)
        {
            string txtTruong03 = txt_Truong03_1.Text + txt_Truong03_2.Text;
            //Save Data
            //Global.db_BCL.Insert_Loai4_new(idImage, Global.StrBatch, Global.StrUsername, "Loai4",
        }
    }
}
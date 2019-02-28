﻿using C1.Win.C1FlexGrid;
using C1.Win.C1Input;
using C1.Win.C1SuperTooltip;
using C1.Win.C1Themes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using modernpos_pos.control;
using modernpos_pos.object1;
using modernpos_pos.Properties;

namespace modernpos_pos.gui
{
    public partial class FrmCFoodsCatSub : Form
    {
        mPOSControl mposC;
        FoodsCatSub fcb;

        Font fEdit, fEditB;

        Color bg, fc;
        Font ff, ffB;
        int colID = 1, colCode = 2, colName = 3, colRemark = 4, colE = 5, colS = 6, coledit = 7, colCnt = 7;

        C1FlexGrid grfFcb;

        //C1TextBox txtPassword = new C1.Win.C1Input.C1TextBox();
        Boolean flagEdit = false;
        C1SuperTooltip stt;
        C1SuperErrorProvider sep;

        String userIdVoid = "";
        public FrmCFoodsCatSub(mPOSControl x)
        {
            InitializeComponent();
            mposC = x;
            initConfig();
        }

        private void initConfig()
        {
            fcb = new FoodsCatSub();
            fEdit = new Font(mposC.iniC.grdViewFontName, mposC.grdViewFontSize, FontStyle.Regular);
            fEditB = new Font(mposC.iniC.grdViewFontName, mposC.grdViewFontSize, FontStyle.Bold);

            //C1ThemeController.ApplicationTheme = mposC.iniC.themeApplication;
            theme1.Theme = mposC.iniC.themeApplication;
            theme1.SetTheme(sB, "BeigeOne");
            foreach (Control c in panel3.Controls)
            {
                theme1.SetTheme(c, mposC.iniC.themeApplication);
            }

            bg = txtFcbCode.BackColor;
            fc = txtFcbCode.ForeColor;
            ff = txtFcbCode.Font;
            txtPasswordVoid.KeyUp += TxtPasswordVoid_KeyUp;
            mposC.mposDB.foocDB.setCboFoodsCat(cboFoodsCat);

            initGrfFoodsCatSub();
            setGrfFoodsCatSub();
            setControlEnable(false);
            setFocusColor();
            sB1.Text = "";
            btnVoid.Hide();
            txtPasswordVoid.Hide();
            stt = new C1SuperTooltip();
            sep = new C1SuperErrorProvider();
            //stt.BackgroundGradient = C1.Win.C1SuperTooltip.BackgroundGradient.Gold;
        }
        
        private void initGrfFoodsCatSub()
        {
            grfFcb = new C1FlexGrid();
            grfFcb.Font = fEdit;
            grfFcb.Dock = System.Windows.Forms.DockStyle.Fill;
            grfFcb.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfPosi);

            grfFcb.AfterRowColChange += new C1.Win.C1FlexGrid.RangeEventHandler(this.grfPosi_AfterRowColChange);
            grfFcb.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfPosi_CellButtonClick);
            grfFcb.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfPosi_CellChanged);

            panel2.Controls.Add(this.grfFcb);

            C1Theme theme = C1ThemeController.GetThemeByName("Office2013Red", false);
            C1ThemeController.ApplyThemeToObject(grfFcb, theme);
        }
        private void setGrfFoodsCatSub()
        {
            //grfDept.Rows.Count = 7;

            grfFcb.DataSource = mposC.mposDB.fcbDB.selectAll();
            grfFcb.Cols.Count = colCnt;
            CellStyle cs = grfFcb.Styles.Add("btn");
            cs.DataType = typeof(Button);
            //cs.ComboList = "|Tom|Dick|Harry";
            cs.ForeColor = Color.Navy;
            cs.Font = new Font(Font, FontStyle.Bold);
            cs = grfFcb.Styles.Add("date");
            cs.DataType = typeof(DateTime);
            cs.Format = "dd-MMM-yy";
            cs.ForeColor = Color.DarkGoldenrod;

            grfFcb.Cols[colE].Style = grfFcb.Styles["btn"];
            grfFcb.Cols[colS].Style = grfFcb.Styles["date"];

            grfFcb.Cols[colID].Width = 60;

            grfFcb.Cols[colCode].Width = 80;
            grfFcb.Cols[colName].Width = 300;

            grfFcb.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfFcb.Cols[colCode].Caption = "รหัส";
            grfFcb.Cols[colName].Caption = "ชื่อกลุ่มย่อย";
            grfFcb.Cols[colRemark].Caption = "หมายเหตุ";

            //grfDept.Cols[coledit].Visible = false;
            CellRange rg = grfFcb.GetCellRange(2, colE);
            for (int i = 1; i < grfFcb.Rows.Count; i++)
            {
                grfFcb[i, 0] = i;
                if (i % 2 == 0)
                    grfFcb.Rows[i].StyleNew.BackColor = ColorTranslator.FromHtml(mposC.iniC.grfRowColor);
            }
            grfFcb.Cols[colID].Visible = false;
            grfFcb.Cols[colE].Visible = false;
            grfFcb.Cols[colS].Visible = false;
        }
        private void textBox_Enter(object sender, EventArgs e)
        {
            C1TextBox a = (C1TextBox)sender;
            a.BackColor = mposC.cTxtFocus;
            a.Font = new Font(ff, FontStyle.Bold);
        }
        private void setFocusColor()
        {
            this.txtFcbCode.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtFcbCode.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtFcbNameT.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtFcbNameT.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtRemark.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtRemark.Enter += new System.EventHandler(this.textBox_Enter);
        }
        private void textBox_Leave(object sender, EventArgs e)
        {
            C1TextBox a = (C1TextBox)sender;
            a.BackColor = bg;
            a.ForeColor = fc;
            a.Font = new Font(ff, FontStyle.Regular);
        }
        private void setControl(String posiId)
        {
            fcb = mposC.mposDB.fcbDB.selectByPk1(posiId);
            txtID.Value = fcb.foods_cat_sub_id;
            txtFcbCode.Value = fcb.foods_cat_sub_code;
            txtFcbNameT.Value = fcb.foods_cat_sub_name;
            txtRemark.Value = fcb.remark;
            mposC.setC1Combo(cboFoodsCat, fcb.foods_cat_id);
            //if (fcb.status_togo.Equals("1"))
            //{
            //    chkStatusTakeOut.Checked = true;
            //}
            //else
            //{
            //    chkStatusTakeOut.Checked = false;
            //}
            //mposC.setC1Combo(cboPosi, stf.posi_id);
            //if (area.status_embryologist.Equals("1"))
            //{
            //    chkEmbryologist.Checked = true;
            //}
            //else
            //{
            //    chkEmbryologist.Checked = false;
            //}
        }
        private void setControlEnable(Boolean flag)
        {
            //txtID.Enabled = flag;
            cboFoodsCat.Enabled = flag;
            txtFcbCode.Enabled = flag;
            txtFcbNameT.Enabled = flag;
            txtRemark.Enabled = flag;
            chkVoid.Enabled = flag;
            btnEdit.Image = !flag ? Resources.lock24 : Resources.open24;
        }

        

        private void setFoodsCatSub()
        {
            fcb.foods_cat_sub_id = txtID.Text;
            fcb.foods_cat_sub_code = txtFcbCode.Text;
            fcb.foods_cat_sub_name = txtFcbNameT.Text;
            fcb.foods_cat_id = cboFoodsCat.SelectedItem == null ? "" : ((ComboBoxItem)cboFoodsCat.SelectedItem).Value;
            fcb.remark = txtRemark.Text;
            //fcb.status_togo = chkStatusTakeOut.Checked == true ? "1" : "0";
            //area.status_embryologist = chkEmbryologist.Checked == true ? "1" : "0";
        }
        private void grfPosi_AfterRowColChange(object sender, C1.Win.C1FlexGrid.RangeEventArgs e)
        {
            if (e.NewRange.r1 < 0) return;
            if (e.NewRange.Data == null) return;

            String deptId = "";
            deptId = grfFcb[e.NewRange.r1, colID] != null ? grfFcb[e.NewRange.r1, colID].ToString() : "";
            setControl(deptId);
            setControlEnable(false);
            //setControlAddr(addrId);
            //setControlAddrEnable(false);
        }
        private void grfPosi_CellButtonClick(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {

        }
        private void grfPosi_CellChanged(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            //if (e.Row == 0) return;
            //CellStyle cs = grfDept.Styles.Add("text");
            //cs.BackColor = Color.DimGray;
            //sB1.Text = grfDept[e.Row, e.Col].ToString();
            ////grfDept[e.Row, coledit] = "1";
            //grfDept.Rows[e.Row].Style = cs;
            //if((e.Row+1) == ((RowCollection)grfDept.Rows).Count)
            //{
            //    ((RowCollection)grfDept.Rows).Count = ((RowCollection)grfDept.Rows).Count + 1;
            //}
        }
        private void TxtPasswordVoid_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            if (e.KeyCode == Keys.Enter)
            {
                userIdVoid = mposC.mposDB.stfDB.selectByPasswordAdmin(txtPasswordVoid.Text.Trim());
                if (userIdVoid.Length>0)
                {
                    txtPasswordVoid.Hide();
                    btnVoid.Show();
                    //stt.Show("<p><b>ต้องการยกเลิก</b></p> <br> รหัสผ่านถูกต้อง", btnVoid);
                }
                else
                {
                    sep.SetError(txtPasswordVoid, "333");
                }
            }
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            txtID.Value = "";
            txtFcbCode.Value = "";
            txtFcbNameT.Value = "";
            txtRemark.Value = "";
            chkVoid.Checked = false;
            btnVoid.Hide();
            flagEdit = true;
            setControlEnable(true);
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            flagEdit = true;
            setControlEnable(flagEdit);
        }
        private void btnVoid_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("ต้องการ ยกเลิกช้อมูล ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                mposC.mposDB.posiDB.VoidPosition(txtID.Text, userIdVoid);
                setGrfFoodsCatSub();
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("ต้องการ บันทึกช้อมูล ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                setFoodsCatSub();
                String re = mposC.mposDB.fcbDB.insertFoodsCatSub(fcb, mposC.user.staff_id);
                int chk = 0;
                if (int.TryParse(re, out chk))
                {
                    btnSave.Image = Resources.accept_database24;
                }
                else
                {
                    btnSave.Image = Resources.accept_database24;
                }
                setGrfFoodsCatSub();
                //setGrdView();
                //this.Dispose();
            }
        }
        private void chkVoid_Click(object sender, EventArgs e)
        {
            if (btnVoid.Visible)
            {
                btnVoid.Hide();
            }
            else
            {
                txtPasswordVoid.Show();
                txtPasswordVoid.Focus();
                //stt.Show("<p><b>ต้องการยกเลิก</b></p> <br> กรุณาป้อนรหัสผ่าน", txtPasswordVoid);
            }
        }
        private void FrmArea_Load(object sender, EventArgs e)
        {

        }
    }
}

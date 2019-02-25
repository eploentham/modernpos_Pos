﻿using C1.Win.C1Input;
using modernpos_pos.objdb;
using modernpos_pos.object1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace modernpos_pos.objdb
{
    public class FPrefixDB
    {
        FPrefix fpf;
        ConnectDB conn;
        public List<FPrefix> lFpf;

        public FPrefixDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            lFpf = new List<FPrefix>();
            fpf = new FPrefix();
            fpf.active = "active";
            fpf.f_prefix_id = "f_prefix_id";
            fpf.f_sex_id = "f_sex_id";            
            fpf.prefix_description = "prefix_description";
            fpf.active = "active";

            fpf.pkField = "f_prefix_id";
            fpf.table = "f_prefix";
        }
        public void getlFPrefix()
        {
            //lDept = new List<Position>();
            lFpf.Clear();
            DataTable dt = new DataTable();
            dt = selectAll();
            foreach (DataRow row in dt.Rows)
            {
                FPrefix itm1 = new FPrefix();
                itm1.f_prefix_id = row[fpf.f_prefix_id].ToString();
                itm1.prefix_description = row[fpf.prefix_description].ToString();

                lFpf.Add(itm1);
            }
        }
        public String getList(String id)
        {
            String re = "";
            if (lFpf.Count <= 0)
            {
                getlFPrefix();
            }
            foreach (FPrefix sex in lFpf)
            {
                if (sex.f_prefix_id.Equals(id))
                {
                    re = sex.prefix_description;
                    break;
                }
            }
            return re;
        }
        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select dept.*  " +
                "From " + fpf.table + " dept " +
                " " +
                "Where dept." + fpf.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByPk(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select dept.* " +
                "From " + fpf.table + " dept " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where dept." + fpf.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public FPrefix selectByPk1(String copId)
        {
            FPrefix cop1 = new FPrefix();
            DataTable dt = new DataTable();
            String sql = "select fpf.* " +
                "From " + fpf.table + " fpf " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where fpf." + fpf.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setPrefix(dt);
            return cop1;
        }
        private FPrefix setPrefix(DataTable dt)
        {
            FPrefix dept1 = new FPrefix();
            if (dt.Rows.Count > 0)
            {
                dept1.f_prefix_id = dt.Rows[0][fpf.f_prefix_id].ToString();
                dept1.prefix_description = dt.Rows[0][fpf.prefix_description].ToString();                
            }

            return dept1;
        }
        public DataTable selectC1()
        {
            DataTable dt = new DataTable();
            String sql = "select fpf." + fpf.pkField + ",fpf." + fpf.prefix_description + " " +
                "From " + fpf.table + " fpf " +
                " " +
                "Where fpf." + fpf.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public C1ComboBox setCboPrefix(C1ComboBox c, String selected)
        {
            ComboBoxItem item = new ComboBoxItem();
            //DataTable dt = selectC1();
            //String aaa = "";
            if (lFpf.Count <= 0) getlFPrefix();
            ComboBoxItem item1 = new ComboBoxItem();
            item1.Text = "";
            item1.Value = "";
            c.Items.Clear();
            c.Items.Add(item1);
            //for (int i = 0; i < dt.Rows.Count; i++)
            int i = 0;
            foreach (FPrefix row in lFpf)
            {
                item = new ComboBoxItem();
                item.Value = row.f_prefix_id;
                item.Text = row.prefix_description;
                c.Items.Add(item);
                if (item.Value.Equals(selected))
                {
                    //c.SelectedItem = item.Value;
                    c.SelectedText = item.Text;
                    c.SelectedIndex = i + 1;
                }
                i++;
            }
            return c;
        }
        public ComboBox setCboPrefix(ComboBox c)
        {
            ComboBoxItem item = new ComboBoxItem();
            DataTable dt = selectC1();
            //String aaa = "";
            ComboBoxItem item1 = new ComboBoxItem();
            item1.Text = "";
            item1.Value = "000";
            c.Items.Clear();
            c.Items.Add(item1);
            //for (int i = 0; i < dt.Rows.Count; i++)
            foreach (DataRow row in dt.Rows)
            {
                item = new ComboBoxItem();
                item.Text = row[fpf.prefix_description].ToString();
                item.Value = row[fpf.f_prefix_id].ToString();

                c.Items.Add(item);
            }
            return c;
        }
    }
}

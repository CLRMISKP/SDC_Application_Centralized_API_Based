using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.Collections;
using System.Configuration;

namespace SDC_Application.Classess
{
    class datagrid_controls
    {
        static int m = 0;
        static decimal TotalVoucharCost = 0;
        public void Grid_Settings(DataGridView gv)
        {
            gv.DefaultCellStyle.Font = new Font("Alvi Nastaleeq", 14, GraphicsUnit.Point);
            gv.RowHeadersDefaultCellStyle.Font = new Font(gv.Font, FontStyle.Regular);
            gv.ColumnHeadersDefaultCellStyle.Font = new Font("Alvi Nastaleeq", 14, GraphicsUnit.Point);
            gv.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gv.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            gv.DefaultCellStyle.ForeColor = Color.Black;
            gv.ColumnHeadersHeight = 33;
        }
        public void gridControls(DataGridView gv)
        {
            try
            {
                gv.ReadOnly = true;
                gv.MultiSelect = false;
                gv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                gv.DefaultCellStyle.SelectionForeColor = Color.Black;
                gv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                gv.RowHeadersVisible = false;
                            

                gv.ColumnHeadersDefaultCellStyle.Font = new Font("Alvi Nastaleeq", 14F, GraphicsUnit.Point);
                //gv.RowsDefaultCellStyle.Font = new Font(gv.Font, FontStyle.Regular);

                gv.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                gv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                gv.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
                gv.DefaultCellStyle.ForeColor = Color.Black;
                gv.ColumnHeadersHeight = 33;
                for (int k = 0; k <= gv.Columns.Count - 1; k++)
                {
                    gv.Columns[k].SortMode = DataGridViewColumnSortMode.NotSortable;
                }

                int colCount = gv.RowCount;
                for (int i = 0; i < colCount; i++)
                {

                    gv.Rows[i].DefaultCellStyle.Font = new System.Drawing.Font("Alvi Nastaleeq", 14F, FontStyle.Regular);

                }
                for (int i = 0; i <= colCount - 1; i++)
                {
                    DataGridViewRow row = gv.Rows[i];
                    row.Height = 35;
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message);
            }
        }

        public void colorrbackgrid(DataGridView gv) /////change color of Datagridview
        {
           int m = 0;
            for (int k = 0; k <= gv.Rows.Count - 1; k++)
            {
                if (m == 0)
                {
                    gv.AlternatingRowsDefaultCellStyle.BackColor= Color.White;
                    m = 1;
                }
                else
                {
                    gv.DefaultCellStyle.BackColor= Color.LightGray;
                    m = 0;
                }

            }
           
        }

        public void SumDataGridColumn(DataGridView gvdelete, TextBox tt,string Columnname)
        {
            
            int rows = gvdelete.Rows.Count;
            //MessageBox.Show(""+rows);
            if (gvdelete.Rows.Count > 0)
            {
                for (int i = 0; i < gvdelete.Rows.Count; i++)
                {
                    TotalVoucharCost = TotalVoucharCost + Convert.ToDecimal(gvdelete.Rows[i].Cells[Columnname].Value);
                    tt.Text =TotalVoucharCost.ToString();
                 
                                  }
                
                TotalVoucharCost = 0;
            }
            
        }

        
    }
}

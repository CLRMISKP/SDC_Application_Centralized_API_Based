using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.Collections;
using SDC_Application.BL;
namespace SDC_Application.Classess
{
    class AutoComplete
    {
        BL.frmToken obj = new BL.frmToken();
        DataTable cmbdt = new DataTable();
        /// <summary>
        /// Fill textbox auto by keypress needs three parameters query,fild name to bound and textbox
        /// </summary>
        #region  Autocomplete
        AutoCompleteStringCollection data = new AutoCompleteStringCollection();
        ArrayList listarry = new ArrayList();
        public  AutoCompleteStringCollection value(string query, string fieldname,TextBox tt)
        {
            DataTable  cmbdt1 = obj.filldatatable_from_storedProcedure(query);

            foreach (DataRow dr in cmbdt1.Rows)
            {

            
                listarry.Add(dr[fieldname].ToString());
            }

            for (int i = 0; i < listarry.Count; i++)
            {
                data.Add(listarry[i].ToString());
            }
            tt.AutoCompleteSource = AutoCompleteSource.CustomSource;
         //   tt.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            return tt.AutoCompleteCustomSource = data;
        }

       
        #endregion

/// <summary>
        /// Fill the combobox , pass three paramters query,comboxname ,DisplayMemberm ValueMember
        /// </summary>
        #region
        public void FillCombo(string query, ComboBox cmb, string DisplayMember, string ValueMember)
        {
     
           DataTable cmbdt2 = obj.filldatatable_from_storedProcedure(query);
            if (cmbdt2 != null)
            {
                try
                {
                    cmb.DataSource = cmbdt2;
                    DataRow list = cmbdt2.NewRow();
                    list[ValueMember] = "0";
                    list[DisplayMember] = "--انتخاب کریں--";
                    cmbdt2.Rows.InsertAt(list, 0);
                    cmb.DataSource = cmbdt2;
                    cmb.DisplayMember = DisplayMember;
                    cmb.ValueMember = ValueMember;
                    cmb.SelectedValue = 0;
                }
                catch (Exception ex)
                {
                    ///
                }
             
            }
           
           
        }

        #endregion
    }
}

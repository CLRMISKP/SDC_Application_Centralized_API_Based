using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Collections;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SDC_Application.AL
{
    public partial class UserRolDefination : Form

    {
        BL.Users objuser = new BL.Users();
        public string Roleid { get; set; }
        ArrayList array = new ArrayList();
        public UserRolDefination()
        {
            InitializeComponent();
        }

        private void btnNewRole_Click(object sender, EventArgs e)
        {
            this.txtRolid.Text = "-1";
            this.txtRole.Text = "";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string teshilid = SDC_Application.Classess.UsersManagments._Tehsilid.ToString();
            string rolid = this.txtRolid.Text.ToString();
            string rolename = this.txtRole.Text.ToString();
            string lastid = objuser.SaveRole(rolid, teshilid, rolename,chkAllAccess.Checked.ToString());
            if (lastid != string.Empty)
            {
                this.txtRolid.Text = lastid;
                getRoleName();
                getAllobjectsroles();
            }
            

        }
        public void getRoleName()
        {
            DataTable dt = new DataTable();
            dt = objuser.getRoleName(SDC_Application.Classess.UsersManagments._Tehsilid.ToString());
            grdRoleName.DataSource = dt;
            grdRoleName.Columns["RoleId"].Visible = false;

        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            bool isExists = false;
           
            for (int i = 0; i <= this.grdObjectNames.Rows.Count - 1; i++)
            {
                int b = Convert.ToInt32(grdObjectNames.Rows[i].Cells["chkSelect"].Value);
                if (b == 1)
                {


                  
                    string ObjectId = grdObjectNames.Rows[i].Cells["ObjectId"].Value.ToString();

                    try
                    {
                        if (this.grdRoleonObject.Rows.Count > 0)
                        {
                            foreach (DataGridViewRow row in grdRoleonObject.Rows)
                            {
                                // MessageBox.Show(row.Cells["IntiqalDocId"].Value + "--" + grdObjectNames.Rows[i].Cells["IntiqalDocId"].Value);
                                if (row.Cells["ObjectId"].Value.ToString() == grdObjectNames.Rows[i].Cells["ObjectId"].Value.ToString())
                                {
                                    isExists = true;
                                    grdObjectNames.CurrentCell = null;
                                    grdObjectNames.Rows[i].Visible = false;
                                    break;
                                }
                            }

                        }

                        if (!isExists)
                        {
                            string roledetailid = "-1";
                            //string roleid=grdRoleName.CurrentRow.Cells["RoleId"].Value.ToString();
                            string objectid = grdObjectNames.Rows[i].Cells["ObjectId"].Value.ToString();
                            string s = objuser.SaveObjectDetails(roledetailid,Roleid,objectid);
                            grdObjectNames.CurrentCell = null;
                            grdObjectNames.Rows[i].Visible = false;
                            invsiable();
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }

            }

            for (int k = 0; k <= grdObjectNames.Rows.Count - 1; k++)
            {
                grdObjectNames.Rows[k].Cells["chkselect"].Value = 0;
            }
          CallRequireDocuments();
          this.chkAllObject.Checked = false;
        }
        public void CallRequireDocuments()
        {
            this.grdRoleonObject.Rows.Clear();
            try
            {
                DataTable dt_GetfromDocRequired = new DataTable();
                dt_GetfromDocRequired = objuser.getRoleObjectdetails(Roleid);
                if (dt_GetfromDocRequired != null)
                {


                    for (int rowss = 0; rowss <= dt_GetfromDocRequired.Rows.Count - 1; rowss++)
                    {
                        grdRoleonObject.Rows.Add();
                    }
                    int count = 0;
                    foreach (DataRow row in dt_GetfromDocRequired.Rows)
                    {

                        this.grdRoleonObject.Rows[count].Cells["RoleDetailId"].Value = row["RoleDetailId"];
                        this.grdRoleonObject.Rows[count].Cells["ObjectId"].Value = row["ObjectId"];
                        this.grdRoleonObject.Rows[count].Cells["ObjectDisplayName"].Value = row["ObjectDisplayName"];
                        this.grdRoleonObject.Rows[count].Cells["ObjectActualName"].Value = row["ObjectActualName"];
                        this.grdRoleonObject.Rows[count].Cells["RoleDetailStatus"].Value = row["RoleDetailStatus"];

                        count++;

                    }
                }
                this.grdRoleonObject.Columns["ObjectId"].Visible = false;
                this.grdRoleonObject.Columns["RoleDetailId"].Visible = false;
                grdRoleonObject.Columns["ObjectId"].Visible = false;
                grdRoleonObject.Columns["ObjectActualName"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void invsiable()
        {

            if (grdRoleonObject.Rows.Count > 0)
            {
                for (int i = 0; i <this.grdRoleonObject.Rows.Count; i++)
                {

                    for (int ii = 0; ii <this.grdObjectNames.Rows.Count; ii++)
                    {
                        if (grdRoleonObject.Rows[i].Cells["ObjectId"].Value.ToString() == grdObjectNames.Rows[ii].Cells["ObjectId"].Value.ToString())
                        {
                            grdObjectNames.Rows[ii].Selected = true;
                            grdObjectNames.CurrentCell = null;
                            grdObjectNames.Rows[ii].Visible = false;
                            //{

                            //    gdrDucoments.Rows[ii].Visible = true;
                            //}
                            //else
                            //{
                            //    gdrDucoments.Rows[ii].Visible = false;
                            //}
                        }
                    }

                }
            }
        }
        private void btnRemove_Click(object sender, EventArgs e)
        {
            DataGridView g = sender as DataGridView;


            if (this.grdRoleonObject.Rows.Count > 0)

            {
                for (int i = 0; i < grdRoleonObject.Rows.Count; i++)
                {
                    int rowvalue = Convert.ToInt32(grdRoleonObject.Rows[i].Cells["chkselectlist"].Value);

                    if (rowvalue == 1)
                    {
                        string roledeleteid = grdRoleonObject.Rows[i].Cells["RoleDetailId"].Value.ToString();

                         DataTable dt = new DataTable();
                         dt = objuser.DeleteRoleDetail(roledeleteid);
                         if (dt != null)
                         {
                             array.Add(grdRoleonObject.Rows[i].Cells["ObjectId"].Value.ToString());
                         }
                        
                    }
                }
                for (int i = 0; i < this.grdObjectNames.Rows.Count; i++)
                {
                    foreach(string objects in array)
                    {
                        if (grdObjectNames.Rows[i].Cells["ObjectId"].Value.ToString() == objects)
                        {
                            

                                grdObjectNames.Rows[i].Visible = true;
                                break;                          
                           
                        }
                    }
                }
            }
            //{

            //    try
            //    {
            //        for (int i = 0; i < grdRoleonObject.Rows.Count; i++)
            //        {
                       
                          
            //                int rowvalue = Convert.ToInt32(grdRoleonObject.Rows[i].Cells["chkselectlist"].Value);
                            
            //                if (rowvalue == 1)
            //                {

            //                    string roledeleteid = grdRoleonObject.Rows[i].Cells["RoleDetailId"].Value.ToString();
                                
            //                    DataTable dt = new DataTable();
            //                    dt = objuser.DeleteRoleDetail(roledeleteid);
            //                    if (dt.Rows.Count > 0)
            //                    {

            //                        for (int ii = 0; ii < this.grdObjectNames.Rows.Count; ii++)
            //                        {
                                        
                                        
                                           
            //                                if (grdRoleonObject.Rows[i].Cells["ObjectId"].Value.ToString() == grdRoleonObject.Rows[ii].Cells["ObjectId"].Value.ToString())
            //                                {
            //                                    if (grdObjectNames.Rows[ii].Visible == false)
            //                                    {

            //                                        grdObjectNames.Rows[ii].Visible = true;
            //                                        break;
            //                                    }
            //                                    else
            //                                    {
            //                                    }
            //                                }
                                    


            //                    }
            //                }
            //            }
            //        }
                  
            //      

            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.Message);
            //    }
            //}

            CallRequireDocuments();
            this.chkAllDetails.Checked = false;

        }

        private void UserRolDefination_Load(object sender, EventArgs e)
        {
            String showFormName = System.Configuration.ConfigurationSettings.AppSettings["showFormName"];
            if (showFormName != null && showFormName.ToUpper() == "TRUE") this.Text = this.Name + "|" + this.Text;

            getRoleName();
            getAllobjectsroles();
            invsiable();
            ObjectsandDetails("0");
           
        }
        public void getAllobjectsroles()
        {
            DataTable dt = new DataTable();
            dt = objuser.getAllobjectsroles();
            grdObjectNames.DataSource = dt;
            grdObjectNames.Columns["ObjectActualName"].Visible = false;
            grdObjectNames.Columns["ObjectId"].Visible = false;
           // grdObjectNames.Columns["RoleId"].Visible = false;
        }

        private void grdRoleName_DoubleClick(object sender, EventArgs e)
        {
            Roleid = grdRoleName.CurrentRow.Cells["RoleId"].Value.ToString();
            ObjectsandDetails(Roleid);
           // ObjectsandDetails();  
        }
        public void ObjectsandDetails(string Roled)
        {
            DataTable dt = new DataTable();
            getAllobjectsroles();
            Roleid = Roled;//grdRoleName.CurrentRow.Cells["RoleId"].Value.ToString();
            CallRequireDocuments();
            invsiable();
            chkAllObject.Checked = false;
            chkAllDetails.Checked = false;
        }
        private void grdRoleName_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Roleid = grdRoleName.CurrentRow.Cells["RoleId"].Value.ToString();
            ObjectsandDetails(Roleid);
        }

        private void grdRoleonObject_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView g = sender as DataGridView;

            if (e.RowIndex != -1)
            {

                if (e.ColumnIndex == this.grdRoleonObject.CurrentRow.Cells["chkselectlist"].ColumnIndex)
                {
                    if (Convert.ToInt32(this.grdRoleonObject.CurrentRow.Cells["chkselectlist"].Value) == 1)
                    {
                        this.grdRoleonObject.CurrentRow.Cells["chkselectlist"].Value = 0;
                    }
                    else
                    {
                        this.grdRoleonObject.CurrentRow.Cells["chkselectlist"].Value = 1;
                    }
                }
            }
        }

        private void grdObjectNames_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView g = sender as DataGridView;

            if (e.RowIndex != -1)
            {

                if (e.ColumnIndex == this.grdObjectNames.CurrentRow.Cells["chkselect"].ColumnIndex)
                {
                    if (Convert.ToInt32(this.grdObjectNames.CurrentRow.Cells["chkselect"].Value) == 1)
                    {
                        this.grdObjectNames.CurrentRow.Cells["chkselect"].Value = 0;
                    }
                    else
                    {
                        this.grdObjectNames.CurrentRow.Cells["chkselect"].Value = 1;
                    }
                }
            }
        }

        private void chkAllObject_Click(object sender, EventArgs e)
        {
            if (this.grdObjectNames.Rows.Count > 0)
            {
                if (this.chkAllObject.Checked)
                {
                    foreach (DataGridViewRow row in grdObjectNames.Rows)
                    {

                        row.Cells["chkselect"].Value = 1;

                    }
                }
                else
                {
                    foreach (DataGridViewRow row in grdObjectNames.Rows)
                    {

                        row.Cells["chkselect"].Value = 0;

                    }
                }
            }
            //chkAllObject.Checked = false;
        }

        private void chkAllDetails_Click(object sender, EventArgs e)
        {
            if (this.grdRoleonObject.Rows.Count > 0)
            {
                if (this.chkAllDetails.Checked)
                {
                    foreach (DataGridViewRow row in grdRoleonObject.Rows)
                    {

                        row.Cells["chkselectlist"].Value = 1;

                    }
                }
                else
                {
                    foreach (DataGridViewRow row in grdRoleonObject.Rows)
                    {

                        row.Cells["chkselectlist"].Value = 0;

                    }
                }
            }
            //chkAllDetails.Checked = false;
        }
    }
}

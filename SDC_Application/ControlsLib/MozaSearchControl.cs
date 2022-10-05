using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LandInfo.Common;
using SDC_Application.LanguageManager;
namespace LandInfo.ControlsLib
{
    public partial class MozaSearchControl : UserControl
    {
        List<AreaNode> lstNodes = new List<AreaNode>();
        List<AreaNode> lstTemp;
        LanguageConverter Lang = new LanguageConverter();
        public MozaSearchControl()
        {
            InitializeComponent();
        }


        #region Properties
       
        public Int64 MozaId { get; set; }
        public string MozaName { get; set; }
        public List<MozaData> AreaData { get; set; }
        #endregion
        
        public void FillAvailableLocationTree()
        {
            LoadAvailableDataInList();
            tvwAreas.Nodes.Clear();
            TreeNode tNode = new TreeNode();
            tNode = tvwAreas.Nodes.Add(lstNodes[0].ID.ToString() , lstNodes[0].AreaName);
            tNode.Tag = lstNodes[0].ID.ToString();
            lstTemp = lstNodes.Where(p => p.ParentNodeID == lstNodes[0].ID).ToList();
            AddDataAvailableLocationsToTreeView(lstTemp , tNode , 0);
            //tvwGeoAreas.ExpandAll();

        }
        /// <summary>
        /// Load Data into List
        /// </summary>
        private void LoadAvailableDataInList()
        {
            //lstNodes = new List<AreaNode>();
            // System.Data.DataSet Ds = new System.Data.DataSet();
            // Ds = this.dsGeoLocations();
            foreach ( var data in this.AreaData)
            {
                
                Int64 iID = Convert.ToInt64(data.AreaCode.ToString());
                string sDesc = data.AreaName.ToString();
                Int64 sParent = Convert.ToInt64(data.ParentCode.ToString());
                string sareaType = data.AreaType.ToString();
                lstNodes.Add(new AreaNode() { ID = iID , AreaName = sDesc , ParentNodeID = sParent , AreaType = sareaType });
                //lstNodes.Add(new NodeClass() { ID = 0, Name = "Data", ParentNodeID = -1 });
            }


        }

        /// <summary>
        /// Add Data To TreeView
        /// </summary>
        /// <param name="iEnumerable"></param>
        /// <param name="t"></param>
        /// <param name="level"></param>
        private void AddDataAvailableLocationsToTreeView(List<AreaNode> iEnumerable , TreeNode t , int level)
        {
            foreach ( AreaNode c in iEnumerable )
            {

                TreeNode treenode;
                
                treenode = t.Nodes.Add(c.ID.ToString() , c.AreaName);
                tvwAreas.Update();
                lstTemp = lstNodes.Where(p => p.ParentNodeID == c.ID).ToList();
                AddDataAvailableLocationsToTreeView(lstTemp , treenode , level + 1);
            }
        }

        private void txtMozaName_DoubleClick(object sender , EventArgs e)
        {
            if ( this.Height == 320 )
            {
                this.Height = 53;
            }
            else
            {
                this.Height = 320;
            }
        }

        private void txtMozaName_KeyPress(object sender , KeyPressEventArgs e)
        {
            if ( e.KeyChar == Convert.ToChar(( Keys.Back )) )
            {

            }
            else
            {
                e.KeyChar = Lang.UrduChar(Convert.ToChar(e.KeyChar));
            }
        }

        private void tvwAreas_NodeMouseDoubleClick(object sender , TreeNodeMouseClickEventArgs e)
        {
            TreeView t = sender as TreeView;
            if ( t.SelectedNode.Level == 7 )
            {
                this.MozaId = Convert.ToInt64(t.SelectedNode.Name.ToString());
                this.txtMozaName.Text = t.SelectedNode.Text;
                this.Height = 53;
                this.txtMozaName.Focus();
            }
        }

    }
}

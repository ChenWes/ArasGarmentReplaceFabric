using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Aras.IOM;

namespace ArasGarmentReplaceFabric
{
    public partial class FrmMain : Form
    {
        private HttpServerConnection mc_conn = null;
        private Innovator mc_innovator = null;

        //process type
        private replaceType mc_replaceType;
        public enum replaceType
        {
            None = 0,
            Fabirc = 1,
            PLU = 2
        }

        public FrmMain()
        {
            InitializeComponent();

            SettingConnectionButton(false);
        }

        private void GetConnection(string l_serverurl, string l_db, string l_username, string l_password)
        {
            mc_conn = IomFactory.CreateHttpServerConnection(l_serverurl.Trim(), l_db.Trim(), l_username.Trim(), Innovator.ScalcMD5(l_password.Trim()));
        }

        private void GetInnovator()
        {
            mc_innovator = IomFactory.CreateInnovator(mc_conn);
        }

        private void ShowError(string errormessage)
        {
            MessageBox.Show(errormessage);
        }

        private void SettingProcess(int maxValue, int CurrentValue)
        {
            decimal getvalue = CurrentValue * 100 / maxValue;
            pro_CheckItem.Value = (int)getvalue;
            pro_CheckItem.Refresh();
        }

        private void SettingConnectionButton(bool bln_ConnectionFlag)
        {
            btn_ConnectionAras.Enabled = !bln_ConnectionFlag;
            btn_disconnection.Enabled = bln_ConnectionFlag;

            txt_serverurl.Enabled = !bln_ConnectionFlag;
            txt_DB.Enabled = !bln_ConnectionFlag;
            txt_username.Enabled = !bln_ConnectionFlag;
            txt_password.Enabled = !bln_ConnectionFlag;

            btn_Start.Enabled = bln_ConnectionFlag;
            btn_StartReplace.Enabled = bln_ConnectionFlag;

            txt_SearchAML.Enabled = bln_ConnectionFlag;
            txt_ReplacePLUAML.Enabled = bln_ConnectionFlag;
            txt_ReplaceFabricAML.Enabled = bln_ConnectionFlag;
            txt_DataList.Enabled = bln_ConnectionFlag;

            if (!bln_ConnectionFlag)
            {
                tre_Item.Nodes.Clear();
            }
        }

        private void SettingCheckItemButton(bool bln_CheckItemFlag)
        {
            btn_Start.Enabled = !bln_CheckItemFlag;

            btn_StartReplace.Enabled = bln_CheckItemFlag;
            tre_Item.Enabled = bln_CheckItemFlag;
        }

        //------------------------------------------------------------------------------------------------------

        private void btn_ConnectionAras_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txt_serverurl.Text.Trim()))
                {
                    throw new Exception("Server Url Is Null Or Empty !");
                }

                if (string.IsNullOrEmpty(txt_DB.Text.Trim()))
                {
                    throw new Exception("DB Name Is Null Or Empty !");
                }

                if (string.IsNullOrEmpty(txt_username.Text.Trim()))
                {
                    throw new Exception("User Name Is Null Or Empty !");
                }

                if (string.IsNullOrEmpty(txt_password.Text.Trim()))
                {
                    throw new Exception("Password Is Null Or Empty !");
                }

                GetConnection(txt_serverurl.Text, txt_DB.Text, txt_username.Text, txt_password.Text);
                GetInnovator();

                Item login_result = mc_conn.Login();
                if (login_result.isError()) throw new Exception("Login failed, please check connection infomation.");

                SettingConnectionButton(true);
            }
            catch (Exception ex)
            {
                ShowError("Connection Aras Error:" + ex.Message);
            }
        }

        private void btn_disconnection_Click(object sender, EventArgs e)
        {
            mc_conn = null;
            mc_innovator = null;
            SettingConnectionButton(false);
            SettingCheckItemButton(false);
        }

        //------------------------------------------------------------------------------------------------------

        private void btn_Start_Click(object sender, EventArgs e)
        {
            try
            {
                if (mc_innovator == null)
                {
                    throw new Exception("Please Connection To Aras First.");
                }

                if (string.IsNullOrEmpty(txt_SearchAML.Text.Trim()))
                {
                    throw new Exception("Please Enter Search AML .");
                }

                if (string.IsNullOrEmpty(txt_DataList.Text.Trim()))
                {
                    txt_DataList.Focus();
                    throw new Exception("Please Enter Check Data .");
                }

                mc_replaceType = replaceType.None;

                TreeNode l_rootNode = new TreeNode("Garment Style", 0, 0);

                string[] l_getDataRow = txt_DataList.Text.Trim().Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

                int l_columnIdx = 0;
                for (int rowIDX = 0; rowIDX < l_getDataRow.Length; rowIDX++)
                {
                    #region process parameter
                    string[] l_getDataColumn = l_getDataRow[rowIDX].Split(new char[] { '\t' });
                    if (l_getDataColumn != null && l_getDataColumn.Length != 0)
                    {
                        l_columnIdx = l_getDataColumn.Length;
                    }

                    //type logic
                    if (mc_replaceType == replaceType.None)
                    {
                        if (l_columnIdx == 4)
                        {
                            mc_replaceType = replaceType.Fabirc;
                        }
                        else if (l_columnIdx == 3)
                        {
                            mc_replaceType = replaceType.PLU;
                        }
                        else
                        {
                            throw new Exception("No Support Type");
                        }
                    }

                    string l_AML = "";
                    string l_tempAML = txt_SearchAML.Text.Trim();
                    for (int columnIDX = 0; columnIDX < l_columnIdx; columnIDX++)
                    {
                        l_tempAML = l_tempAML.Replace("$" + (columnIDX + 1), l_getDataColumn[columnIDX]);
                    }

                    l_AML = "<AML>" + l_tempAML + "</AML>";

                    #endregion

                    #region get item and check
                    Item l_GetItem = mc_innovator.applyAML(l_AML);

                    if (l_GetItem.isError())
                    {
                        throw new Exception("AML Run Have Error[" + l_GetItem.getErrorCode() + "]" + l_GetItem.getErrorDetail());
                    }

                    if (l_GetItem.getItemCount() == 0)
                    {
                        throw new Exception("AML Return Item Zero Error[" + l_GetItem.getErrorCode() + "]" + l_GetItem.getErrorDetail());
                    }

                    #endregion

                    SettingProcess(l_getDataRow.Length, rowIDX + 1);

                    //clear node
                    tre_Item.Nodes.Clear();


                    #region process garment style
                    for (int garmentIDX = 0; garmentIDX < l_GetItem.getItemCount(); garmentIDX++)
                    {
                        Item l_garmentStyle_Item = l_GetItem.getItemByIndex(garmentIDX);

                        TreeNode l_garmentStyle_Item_Node = new TreeNode(l_garmentStyle_Item.getProperty("item_number", "-"), 0, 0);
                        l_garmentStyle_Item_Node.Tag = l_garmentStyle_Item.getProperty("item_number", "-");

                        #region process Garment Style Option

                        Item l_GarmentStyleContainsOption_Item = l_GetItem.getRelationships("Garment Style Contains Option");
                        for (int garOptIDX = 0; garOptIDX < l_GarmentStyleContainsOption_Item.getItemCount(); garOptIDX++)
                        {
                            Item l_GarmentStyleOption_Item = l_GarmentStyleContainsOption_Item.getItemByIndex(garOptIDX).getRelatedItem();

                            TreeNode l_GarmentStyleOption_Item_Node = new TreeNode(l_GarmentStyleOption_Item.getProperty("option_no", "option_no") + "<-->" + l_GarmentStyleOption_Item.getProperty("cn_body_pattern", "cn_body_pattern") + "<-->" + l_GarmentStyleOption_Item.getProperty("cn_plu", "cn_plu"), 0, 0);
                            l_GarmentStyleOption_Item_Node.Tag = l_GarmentStyleOption_Item.getProperty("id", "");
                            l_GarmentStyleOption_Item_Node.ToolTipText = l_getDataColumn[2];

                            #region process Garment BOM

                            Item l_GarmentStyleOptionBOM = l_GarmentStyleOption_Item.getRelationships("Garment Style Option BOM");
                            for (int garOptBomIDX = 0; garOptBomIDX < l_GarmentStyleOptionBOM.getItemCount(); garOptBomIDX++)
                            {
                                Item l_GarmentBOM_Item = l_GarmentStyleOptionBOM.getItemByIndex(garOptIDX).getRelatedItem();

                                TreeNode l_GarmentBOM_Item_Node = new TreeNode(l_GarmentBOM_Item.getProperty("cn_bom_type", "cn_bom_type"), 0, 0);

                                #region process Garment BOM Part

                                Item l_GarmentBOMPart_Item = l_GarmentBOM_Item.getRelationships("Garment BOM Part");
                                for (int partIDX = 0; partIDX < l_GarmentBOMPart_Item.getItemCount(); partIDX++)
                                {
                                    Item l_part_Item = l_GarmentBOMPart_Item.getItemByIndex(garOptIDX).getRelatedItem();

                                    TreeNode l_part_Node = new TreeNode(l_part_Item.getProperty("item_number", "item_number"), 0, 0);
                                    l_part_Node.Tag = l_GarmentBOMPart_Item.getItemByIndex(garOptIDX).getProperty("id", "");
                                    l_part_Node.ToolTipText = l_getDataColumn[2];

                                    l_GarmentBOM_Item_Node.Nodes.Add(l_part_Node);
                                }

                                #endregion

                                l_GarmentStyleOption_Item_Node.Nodes.Add(l_GarmentBOM_Item_Node);
                            }

                            #endregion

                            l_garmentStyle_Item_Node.Nodes.Add(l_GarmentStyleOption_Item_Node);
                        }

                        #endregion


                        l_rootNode.Nodes.Add(l_garmentStyle_Item_Node);
                    }
                    #endregion

                    tre_Item.Nodes.Add(l_rootNode);
                }
            }
            catch (Exception ex)
            {
                ShowError("check data error:" + ex.Message);
            }
        }

        private void btn_StartReplace_Click(object sender, EventArgs e)
        {
            try
            {
                if (mc_innovator == null)
                {
                    throw new Exception("Please Connection To Aras First.");
                }

                if (string.IsNullOrEmpty(txt_SearchAML.Text.Trim()))
                {
                    throw new Exception("Please Enter Search AML .");
                }

                if (string.IsNullOrEmpty(txt_ReplacePLUAML.Text.Trim()))
                {
                    throw new Exception("Please Enter Replace AML .");
                }

                if (string.IsNullOrEmpty(txt_ReplaceFabricAML.Text.Trim()))
                {
                    throw new Exception("Please Enter Replace AML .");
                }

                if (mc_replaceType == replaceType.None)
                {
                    throw new Exception("No Support Type .");
                }

                DialogResult result = MessageBox.Show("Replace Main Body Fabric / PLU Just Change Latest Version Generation, Do You Know That ?", "System Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {

                    if (tre_Item.Nodes != null && tre_Item.Nodes.Count > 0)
                    {
                        tre_Item.Nodes[0].Expand();
                    }

                    foreach (TreeNode styleNode in tre_Item.Nodes[0].Nodes)
                    {
                        styleNode.Expand();

                        foreach (TreeNode optNode in styleNode.Nodes)
                        {
                            optNode.Expand();

                            if (mc_replaceType == replaceType.PLU)
                            {
                                #region replace PLU

                                if (!string.IsNullOrEmpty(optNode.Tag.ToString()) && !string.IsNullOrEmpty(optNode.ToolTipText.ToString()))
                                {
                                    string AML = "<AML>" + txt_ReplacePLUAML.Text.Trim() + "</AML>";

                                    AML = AML.Replace("$1", optNode.Tag.ToString());
                                    AML = AML.Replace("$2", optNode.ToolTipText.ToString());

                                    Item l_checkItem = mc_innovator.applyAML(AML);

                                    if (l_checkItem.isError())
                                    {
                                        throw new Exception("AML Run Have Error[" + l_checkItem.getErrorCode() + "]" + l_checkItem.getErrorDetail());
                                    }

                                    if (l_checkItem.getItemCount() == 0)
                                    {
                                        throw new Exception("AML Return Item Zero Error[" + l_checkItem.getErrorCode() + "]" + l_checkItem.getErrorDetail());
                                    }

                                    optNode.Text = optNode.Text + "-->" + optNode.ToolTipText;
                                    optNode.ImageIndex = 3;
                                    optNode.SelectedImageIndex = 3;
                                }

                                #endregion
                            }
                            else if (mc_replaceType == replaceType.Fabirc)
                            {
                                #region replace Fabric
                                foreach (TreeNode fabNode in optNode.Nodes)
                                {
                                    fabNode.Expand();

                                    foreach (TreeNode partNode in fabNode.Nodes)
                                    {
                                        partNode.Expand();

                                        if (!string.IsNullOrEmpty(partNode.Tag.ToString()) && !string.IsNullOrEmpty(partNode.ToolTipText.ToString()))
                                        {
                                            string AML = "<AML>" + txt_ReplaceFabricAML.Text.Trim() + "</AML>";

                                            AML = AML.Replace("$1", partNode.Tag.ToString());
                                            AML = AML.Replace("$2", partNode.ToolTipText.ToString());

                                            Item l_checkItem = mc_innovator.applyAML(AML);

                                            if (l_checkItem.isError())
                                            {
                                                throw new Exception("AML Run Have Error[" + l_checkItem.getErrorCode() + "]" + l_checkItem.getErrorDetail());
                                            }

                                            if (l_checkItem.getItemCount() == 0)
                                            {
                                                throw new Exception("AML Return Item Zero Error[" + l_checkItem.getErrorCode() + "]" + l_checkItem.getErrorDetail());
                                            }

                                            partNode.Text = partNode.Text + "-->" + partNode.ToolTipText;
                                            partNode.ImageIndex = 3;
                                            partNode.SelectedImageIndex = 3;

                                            fabNode.ImageIndex = 3;
                                            fabNode.SelectedImageIndex = 3;

                                            optNode.ImageIndex = 3;
                                            optNode.SelectedImageIndex = 3;

                                            styleNode.ImageIndex = 3;
                                            styleNode.SelectedImageIndex = 3;
                                        }
                                    }
                                }

                                #endregion
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ShowError("replace data error:" + ex.Message);
            }
        }

        private void btn_disconnection_Click_1(object sender, EventArgs e)
        {
            mc_conn.Logout();
            mc_conn = null;
            mc_innovator = null;
            SettingConnectionButton(false);
        }
    }
}

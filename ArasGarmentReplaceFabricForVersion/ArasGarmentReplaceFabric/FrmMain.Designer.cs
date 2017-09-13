namespace ArasGarmentReplaceFabric
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lab_password = new System.Windows.Forms.Label();
            this.lab_DB = new System.Windows.Forms.Label();
            this.lab_username = new System.Windows.Forms.Label();
            this.lab_serverurl = new System.Windows.Forms.Label();
            this.btn_disconnection = new System.Windows.Forms.Button();
            this.btn_ConnectionAras = new System.Windows.Forms.Button();
            this.txt_username = new System.Windows.Forms.TextBox();
            this.txt_password = new System.Windows.Forms.TextBox();
            this.txt_DB = new System.Windows.Forms.TextBox();
            this.txt_serverurl = new System.Windows.Forms.TextBox();
            this.tre_Item = new System.Windows.Forms.TreeView();
            this.imageLiarbry = new System.Windows.Forms.ImageList(this.components);
            this.txt_SearchAML = new System.Windows.Forms.TextBox();
            this.txt_DataList = new System.Windows.Forms.TextBox();
            this.btn_StartReplace = new System.Windows.Forms.Button();
            this.btn_Start = new System.Windows.Forms.Button();
            this.pro_CheckItem = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_ReplaceFabricAML = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lab_password);
            this.panel1.Controls.Add(this.lab_DB);
            this.panel1.Controls.Add(this.lab_username);
            this.panel1.Controls.Add(this.lab_serverurl);
            this.panel1.Controls.Add(this.btn_disconnection);
            this.panel1.Controls.Add(this.btn_ConnectionAras);
            this.panel1.Controls.Add(this.txt_username);
            this.panel1.Controls.Add(this.txt_password);
            this.panel1.Controls.Add(this.txt_DB);
            this.panel1.Controls.Add(this.txt_serverurl);
            this.panel1.Location = new System.Drawing.Point(11, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(824, 74);
            this.panel1.TabIndex = 2;
            // 
            // lab_password
            // 
            this.lab_password.AutoSize = true;
            this.lab_password.Location = new System.Drawing.Point(364, 44);
            this.lab_password.Name = "lab_password";
            this.lab_password.Size = new System.Drawing.Size(53, 12);
            this.lab_password.TabIndex = 2;
            this.lab_password.Text = "PassWord";
            // 
            // lab_DB
            // 
            this.lab_DB.AutoSize = true;
            this.lab_DB.Location = new System.Drawing.Point(364, 17);
            this.lab_DB.Name = "lab_DB";
            this.lab_DB.Size = new System.Drawing.Size(41, 12);
            this.lab_DB.TabIndex = 2;
            this.lab_DB.Text = "DBName";
            // 
            // lab_username
            // 
            this.lab_username.AutoSize = true;
            this.lab_username.Location = new System.Drawing.Point(17, 44);
            this.lab_username.Name = "lab_username";
            this.lab_username.Size = new System.Drawing.Size(53, 12);
            this.lab_username.TabIndex = 2;
            this.lab_username.Text = "UserName";
            // 
            // lab_serverurl
            // 
            this.lab_serverurl.AutoSize = true;
            this.lab_serverurl.Location = new System.Drawing.Point(17, 17);
            this.lab_serverurl.Name = "lab_serverurl";
            this.lab_serverurl.Size = new System.Drawing.Size(59, 12);
            this.lab_serverurl.TabIndex = 2;
            this.lab_serverurl.Text = "ServerUrl";
            // 
            // btn_disconnection
            // 
            this.btn_disconnection.Location = new System.Drawing.Point(715, 39);
            this.btn_disconnection.Name = "btn_disconnection";
            this.btn_disconnection.Size = new System.Drawing.Size(87, 23);
            this.btn_disconnection.TabIndex = 1;
            this.btn_disconnection.Text = "Disconnection";
            this.btn_disconnection.UseVisualStyleBackColor = true;
            this.btn_disconnection.Click += new System.EventHandler(this.btn_disconnection_Click_1);
            // 
            // btn_ConnectionAras
            // 
            this.btn_ConnectionAras.Location = new System.Drawing.Point(715, 12);
            this.btn_ConnectionAras.Name = "btn_ConnectionAras";
            this.btn_ConnectionAras.Size = new System.Drawing.Size(87, 23);
            this.btn_ConnectionAras.TabIndex = 1;
            this.btn_ConnectionAras.Text = "Connection";
            this.btn_ConnectionAras.UseVisualStyleBackColor = true;
            this.btn_ConnectionAras.Click += new System.EventHandler(this.btn_ConnectionAras_Click);
            // 
            // txt_username
            // 
            this.txt_username.Location = new System.Drawing.Point(82, 41);
            this.txt_username.Name = "txt_username";
            this.txt_username.Size = new System.Drawing.Size(254, 21);
            this.txt_username.TabIndex = 0;
            this.txt_username.Text = "admin";
            // 
            // txt_password
            // 
            this.txt_password.Location = new System.Drawing.Point(423, 41);
            this.txt_password.Name = "txt_password";
            this.txt_password.PasswordChar = '*';
            this.txt_password.Size = new System.Drawing.Size(254, 21);
            this.txt_password.TabIndex = 0;
            this.txt_password.Text = "innovator";
            // 
            // txt_DB
            // 
            this.txt_DB.Location = new System.Drawing.Point(423, 14);
            this.txt_DB.Name = "txt_DB";
            this.txt_DB.Size = new System.Drawing.Size(254, 21);
            this.txt_DB.TabIndex = 0;
            this.txt_DB.Text = "Esquel_PLM_SIT";
            // 
            // txt_serverurl
            // 
            this.txt_serverurl.Location = new System.Drawing.Point(82, 14);
            this.txt_serverurl.Name = "txt_serverurl";
            this.txt_serverurl.Size = new System.Drawing.Size(254, 21);
            this.txt_serverurl.TabIndex = 0;
            this.txt_serverurl.Text = "http://10.20.2.30/InnovatorServer/";
            // 
            // tre_Item
            // 
            this.tre_Item.ImageIndex = 0;
            this.tre_Item.ImageList = this.imageLiarbry;
            this.tre_Item.Location = new System.Drawing.Point(11, 273);
            this.tre_Item.Name = "tre_Item";
            this.tre_Item.SelectedImageIndex = 0;
            this.tre_Item.Size = new System.Drawing.Size(402, 398);
            this.tre_Item.TabIndex = 8;
            // 
            // imageLiarbry
            // 
            this.imageLiarbry.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageLiarbry.ImageStream")));
            this.imageLiarbry.TransparentColor = System.Drawing.Color.Transparent;
            this.imageLiarbry.Images.SetKeyName(0, "wait.png");
            this.imageLiarbry.Images.SetKeyName(1, "start.png");
            this.imageLiarbry.Images.SetKeyName(2, "stop.png");
            this.imageLiarbry.Images.SetKeyName(3, "complete.png");
            // 
            // txt_SearchAML
            // 
            this.txt_SearchAML.Location = new System.Drawing.Point(11, 135);
            this.txt_SearchAML.Multiline = true;
            this.txt_SearchAML.Name = "txt_SearchAML";
            this.txt_SearchAML.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_SearchAML.Size = new System.Drawing.Size(401, 132);
            this.txt_SearchAML.TabIndex = 9;
            this.txt_SearchAML.Text = resources.GetString("txt_SearchAML.Text");
            // 
            // txt_DataList
            // 
            this.txt_DataList.Location = new System.Drawing.Point(423, 273);
            this.txt_DataList.Multiline = true;
            this.txt_DataList.Name = "txt_DataList";
            this.txt_DataList.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_DataList.Size = new System.Drawing.Size(409, 398);
            this.txt_DataList.TabIndex = 10;
            // 
            // btn_StartReplace
            // 
            this.btn_StartReplace.Location = new System.Drawing.Point(550, 227);
            this.btn_StartReplace.Name = "btn_StartReplace";
            this.btn_StartReplace.Size = new System.Drawing.Size(121, 40);
            this.btn_StartReplace.TabIndex = 11;
            this.btn_StartReplace.Text = "Start Replace";
            this.btn_StartReplace.UseVisualStyleBackColor = true;
            this.btn_StartReplace.Click += new System.EventHandler(this.btn_StartReplace_Click);
            // 
            // btn_Start
            // 
            this.btn_Start.Location = new System.Drawing.Point(423, 227);
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.Size = new System.Drawing.Size(121, 40);
            this.btn_Start.TabIndex = 12;
            this.btn_Start.Text = "Start Check";
            this.btn_Start.UseVisualStyleBackColor = true;
            this.btn_Start.Click += new System.EventHandler(this.btn_Start_Click);
            // 
            // pro_CheckItem
            // 
            this.pro_CheckItem.Location = new System.Drawing.Point(11, 92);
            this.pro_CheckItem.Name = "pro_CheckItem";
            this.pro_CheckItem.Size = new System.Drawing.Size(824, 17);
            this.pro_CheckItem.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 15;
            this.label1.Text = "search AML";
            // 
            // txt_ReplaceFabricAML
            // 
            this.txt_ReplaceFabricAML.Location = new System.Drawing.Point(423, 189);
            this.txt_ReplaceFabricAML.Multiline = true;
            this.txt_ReplaceFabricAML.Name = "txt_ReplaceFabricAML";
            this.txt_ReplaceFabricAML.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_ReplaceFabricAML.Size = new System.Drawing.Size(412, 32);
            this.txt_ReplaceFabricAML.TabIndex = 14;
            this.txt_ReplaceFabricAML.Text = "<Item type=\"Garment BOM Part\" where=\"id=\'$1\'\" action=\"edit\">\t\t\r\n\t<related_id>\r\n\t\t" +
    "<Item type=\"Part\" action=\"get\" select=\"id\">\r\n\t\t\t<item_number>$2</item_number>\r\n\t" +
    "\t</Item>\r\n\t</related_id>\r\n</Item>";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(421, 174);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 12);
            this.label3.TabIndex = 16;
            this.label3.Text = "replace Fabric AML";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(841, 681);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_ReplaceFabricAML);
            this.Controls.Add(this.pro_CheckItem);
            this.Controls.Add(this.btn_StartReplace);
            this.Controls.Add(this.btn_Start);
            this.Controls.Add(this.txt_DataList);
            this.Controls.Add(this.txt_SearchAML);
            this.Controls.Add(this.tre_Item);
            this.Controls.Add(this.panel1);
            this.Name = "FrmMain";
            this.Text = "Aras Garment Style Replace Fabric For Version Generation";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lab_password;
        private System.Windows.Forms.Label lab_DB;
        private System.Windows.Forms.Label lab_username;
        private System.Windows.Forms.Label lab_serverurl;
        private System.Windows.Forms.Button btn_disconnection;
        private System.Windows.Forms.Button btn_ConnectionAras;
        private System.Windows.Forms.TextBox txt_username;
        private System.Windows.Forms.TextBox txt_password;
        private System.Windows.Forms.TextBox txt_DB;
        private System.Windows.Forms.TextBox txt_serverurl;
        private System.Windows.Forms.TreeView tre_Item;
        private System.Windows.Forms.TextBox txt_SearchAML;
        private System.Windows.Forms.TextBox txt_DataList;
        private System.Windows.Forms.Button btn_StartReplace;
        private System.Windows.Forms.Button btn_Start;
        private System.Windows.Forms.ProgressBar pro_CheckItem;
        private System.Windows.Forms.ImageList imageLiarbry;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_ReplaceFabricAML;
        private System.Windows.Forms.Label label3;
    }
}


namespace Datacom.GetTrackedMessage
{
    partial class GetTrackedMessage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GetTrackedMessage));
            this.btnGetMessage = new System.Windows.Forms.Button();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.txtGuid = new System.Windows.Forms.TextBox();
            this.lblGuid = new System.Windows.Forms.Label();
            this.cboGetType = new System.Windows.Forms.ComboBox();
            this.lblTrackingDBServer = new System.Windows.Forms.Label();
            this.txtTrackingDBServer = new System.Windows.Forms.TextBox();
            this.lblTrackingDBName = new System.Windows.Forms.Label();
            this.txtTrackingDBName = new System.Windows.Forms.TextBox();
            this.lblExtractionType = new System.Windows.Forms.Label();
            this.logoBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.logoBox)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGetMessage
            // 
            this.btnGetMessage.Location = new System.Drawing.Point(791, 93);
            this.btnGetMessage.Name = "btnGetMessage";
            this.btnGetMessage.Size = new System.Drawing.Size(95, 23);
            this.btnGetMessage.TabIndex = 4;
            this.btnGetMessage.Text = "Get Message";
            this.btnGetMessage.UseVisualStyleBackColor = true;
            this.btnGetMessage.Click += new System.EventHandler(this.btnGetMessage_Click);
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(41, 130);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMessage.Size = new System.Drawing.Size(845, 684);
            this.txtMessage.TabIndex = 5;
            // 
            // txtGuid
            // 
            this.txtGuid.Location = new System.Drawing.Point(245, 40);
            this.txtGuid.Name = "txtGuid";
            this.txtGuid.Size = new System.Drawing.Size(293, 20);
            this.txtGuid.TabIndex = 0;
            // 
            // lblGuid
            // 
            this.lblGuid.AutoSize = true;
            this.lblGuid.Location = new System.Drawing.Point(168, 43);
            this.lblGuid.Name = "lblGuid";
            this.lblGuid.Size = new System.Drawing.Size(76, 13);
            this.lblGuid.TabIndex = 3;
            this.lblGuid.Text = "Message guid:";
            // 
            // cboGetType
            // 
            this.cboGetType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGetType.FormattingEnabled = true;
            this.cboGetType.Items.AddRange(new object[] {
            "Use Operations DLL",
            "Use SQL",
            "Use WMI"});
            this.cboGetType.Location = new System.Drawing.Point(647, 40);
            this.cboGetType.Name = "cboGetType";
            this.cboGetType.Size = new System.Drawing.Size(239, 21);
            this.cboGetType.TabIndex = 1;
            // 
            // lblTrackingDBServer
            // 
            this.lblTrackingDBServer.AutoSize = true;
            this.lblTrackingDBServer.Location = new System.Drawing.Point(142, 68);
            this.lblTrackingDBServer.Name = "lblTrackingDBServer";
            this.lblTrackingDBServer.Size = new System.Drawing.Size(102, 13);
            this.lblTrackingDBServer.TabIndex = 8;
            this.lblTrackingDBServer.Text = "Tracking DB server:";
            // 
            // txtTrackingDBServer
            // 
            this.txtTrackingDBServer.Location = new System.Drawing.Point(245, 66);
            this.txtTrackingDBServer.Name = "txtTrackingDBServer";
            this.txtTrackingDBServer.Size = new System.Drawing.Size(293, 20);
            this.txtTrackingDBServer.TabIndex = 2;
            this.txtTrackingDBServer.Text = ".";
            // 
            // lblTrackingDBName
            // 
            this.lblTrackingDBName.AutoSize = true;
            this.lblTrackingDBName.Location = new System.Drawing.Point(544, 69);
            this.lblTrackingDBName.Name = "lblTrackingDBName";
            this.lblTrackingDBName.Size = new System.Drawing.Size(99, 13);
            this.lblTrackingDBName.TabIndex = 10;
            this.lblTrackingDBName.Text = "Tracking DB name:";
            // 
            // txtTrackingDBName
            // 
            this.txtTrackingDBName.Location = new System.Drawing.Point(647, 67);
            this.txtTrackingDBName.Name = "txtTrackingDBName";
            this.txtTrackingDBName.Size = new System.Drawing.Size(239, 20);
            this.txtTrackingDBName.TabIndex = 3;
            this.txtTrackingDBName.Text = "BizTalkDTADb";
            // 
            // lblExtractionType
            // 
            this.lblExtractionType.AutoSize = true;
            this.lblExtractionType.Location = new System.Drawing.Point(559, 43);
            this.lblExtractionType.Name = "lblExtractionType";
            this.lblExtractionType.Size = new System.Drawing.Size(84, 13);
            this.lblExtractionType.TabIndex = 11;
            this.lblExtractionType.Text = "Extraction Type:";
            // 
            // logoBox
            // 
            this.logoBox.Image = global::Datacom.GetTrackedMessage.Properties.Resources.SSO1;
            this.logoBox.Location = new System.Drawing.Point(12, 21);
            this.logoBox.Name = "logoBox";
            this.logoBox.Size = new System.Drawing.Size(126, 78);
            this.logoBox.TabIndex = 12;
            this.logoBox.TabStop = false;
            // 
            // GetTrackedMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(921, 826);
            this.Controls.Add(this.logoBox);
            this.Controls.Add(this.lblExtractionType);
            this.Controls.Add(this.lblTrackingDBName);
            this.Controls.Add(this.txtTrackingDBName);
            this.Controls.Add(this.lblTrackingDBServer);
            this.Controls.Add(this.txtTrackingDBServer);
            this.Controls.Add(this.cboGetType);
            this.Controls.Add(this.lblGuid);
            this.Controls.Add(this.txtGuid);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.btnGetMessage);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GetTrackedMessage";
            this.Text = "Get BizTalk Tracked Message";
            ((System.ComponentModel.ISupportInitialize)(this.logoBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGetMessage;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.TextBox txtGuid;
        private System.Windows.Forms.Label lblGuid;
        private System.Windows.Forms.ComboBox cboGetType;
        private System.Windows.Forms.Label lblTrackingDBServer;
        private System.Windows.Forms.TextBox txtTrackingDBServer;
        private System.Windows.Forms.Label lblTrackingDBName;
        private System.Windows.Forms.TextBox txtTrackingDBName;
        private System.Windows.Forms.Label lblExtractionType;
        private System.Windows.Forms.PictureBox logoBox;
    }
}


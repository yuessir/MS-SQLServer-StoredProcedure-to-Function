namespace SP2FUN
{
    partial class mainFrmSP2Fun
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.cboSPList = new System.Windows.Forms.ComboBox();
            this.txtSP = new System.Windows.Forms.TextBox();
            this.txtFun = new System.Windows.Forms.TextBox();
            this.btnConvertSP2Fun = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cboSPList
            // 
            this.cboSPList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSPList.FormattingEnabled = true;
            this.cboSPList.Location = new System.Drawing.Point(12, 12);
            this.cboSPList.Name = "cboSPList";
            this.cboSPList.Size = new System.Drawing.Size(197, 20);
            this.cboSPList.TabIndex = 0;
            this.cboSPList.SelectedIndexChanged += new System.EventHandler(this.cboSPList_SelectedIndexChanged);
            // 
            // txtSP
            // 
            this.txtSP.Location = new System.Drawing.Point(12, 38);
            this.txtSP.Multiline = true;
            this.txtSP.Name = "txtSP";
            this.txtSP.ReadOnly = true;
            this.txtSP.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtSP.Size = new System.Drawing.Size(570, 461);
            this.txtSP.TabIndex = 1;
            this.txtSP.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFun_KeyDown);
            // 
            // txtFun
            // 
            this.txtFun.Location = new System.Drawing.Point(588, 38);
            this.txtFun.Multiline = true;
            this.txtFun.Name = "txtFun";
            this.txtFun.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtFun.Size = new System.Drawing.Size(570, 461);
            this.txtFun.TabIndex = 2;
            this.txtFun.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFun_KeyDown);
            // 
            // btnConvertSP2Fun
            // 
            this.btnConvertSP2Fun.Location = new System.Drawing.Point(215, 9);
            this.btnConvertSP2Fun.Name = "btnConvertSP2Fun";
            this.btnConvertSP2Fun.Size = new System.Drawing.Size(75, 23);
            this.btnConvertSP2Fun.TabIndex = 3;
            this.btnConvertSP2Fun.Text = "Convet";
            this.btnConvertSP2Fun.UseVisualStyleBackColor = true;
            this.btnConvertSP2Fun.Click += new System.EventHandler(this.btnConvertSP2Fun_Click);
            // 
            // mainFrmSP2Fun
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1166, 523);
            this.Controls.Add(this.btnConvertSP2Fun);
            this.Controls.Add(this.txtFun);
            this.Controls.Add(this.txtSP);
            this.Controls.Add(this.cboSPList);
            this.Name = "mainFrmSP2Fun";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SP2Fun By KevinYu";
            this.Load += new System.EventHandler(this.mainFrmSP2Fun_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboSPList;
        private System.Windows.Forms.TextBox txtSP;
        private System.Windows.Forms.TextBox txtFun;
        private System.Windows.Forms.Button btnConvertSP2Fun;
    }
}


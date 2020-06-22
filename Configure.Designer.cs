namespace Import
{
    partial class Configure
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
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblRssUrl = new System.Windows.Forms.Label();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.lblQuery = new System.Windows.Forms.Label();
            this.txtQuery = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lblLocation = new System.Windows.Forms.Label();
            this.cmbLocation = new System.Windows.Forms.ComboBox();
            this.cmbRadius = new System.Windows.Forms.ComboBox();
            this.lblRadius = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(422, 314);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(528, 314);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // lblRssUrl
            // 
            this.lblRssUrl.AutoSize = true;
            this.lblRssUrl.Location = new System.Drawing.Point(11, 20);
            this.lblRssUrl.Name = "lblRssUrl";
            this.lblRssUrl.Size = new System.Drawing.Size(54, 13);
            this.lblRssUrl.TabIndex = 2;
            this.lblRssUrl.Text = "RSS URL";
            // 
            // txtUrl
            // 
            this.txtUrl.Location = new System.Drawing.Point(78, 17);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.ReadOnly = true;
            this.txtUrl.Size = new System.Drawing.Size(525, 20);
            this.txtUrl.TabIndex = 3;
            // 
            // lblQuery
            // 
            this.lblQuery.AutoSize = true;
            this.lblQuery.Location = new System.Drawing.Point(11, 85);
            this.lblQuery.Name = "lblQuery";
            this.lblQuery.Size = new System.Drawing.Size(35, 13);
            this.lblQuery.TabIndex = 4;
            this.lblQuery.Text = "Query";
            // 
            // txtQuery
            // 
            this.txtQuery.Location = new System.Drawing.Point(78, 82);
            this.txtQuery.Name = "txtQuery";
            this.txtQuery.Size = new System.Drawing.Size(257, 20);
            this.txtQuery.TabIndex = 5;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(78, 43);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(541, 20);
            this.textBox1.TabIndex = 6;
            this.textBox1.Text = "http://www.indeed.ca/rss?q=store+clerk&l=Oakville%2C+ON&radius=100&sort=date";
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Location = new System.Drawing.Point(12, 111);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(48, 13);
            this.lblLocation.TabIndex = 7;
            this.lblLocation.Text = "Location";
            // 
            // cmbLocation
            // 
            this.cmbLocation.FormattingEnabled = true;
            this.cmbLocation.Location = new System.Drawing.Point(78, 108);
            this.cmbLocation.Name = "cmbLocation";
            this.cmbLocation.Size = new System.Drawing.Size(257, 21);
            this.cmbLocation.TabIndex = 8;
            // 
            // cmbRadius
            // 
            this.cmbRadius.FormattingEnabled = true;
            this.cmbRadius.Location = new System.Drawing.Point(78, 135);
            this.cmbRadius.Name = "cmbRadius";
            this.cmbRadius.Size = new System.Drawing.Size(102, 21);
            this.cmbRadius.TabIndex = 9;
            // 
            // lblRadius
            // 
            this.lblRadius.AutoSize = true;
            this.lblRadius.Location = new System.Drawing.Point(12, 138);
            this.lblRadius.Name = "lblRadius";
            this.lblRadius.Size = new System.Drawing.Size(40, 13);
            this.lblRadius.TabIndex = 10;
            this.lblRadius.Text = "Radius";
            // 
            // Configure
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(627, 367);
            this.Controls.Add(this.lblRadius);
            this.Controls.Add(this.cmbRadius);
            this.Controls.Add(this.cmbLocation);
            this.Controls.Add(this.lblLocation);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.txtQuery);
            this.Controls.Add(this.lblQuery);
            this.Controls.Add(this.txtUrl);
            this.Controls.Add(this.lblRssUrl);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Name = "Configure";
            this.Text = "Configure";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblRssUrl;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.Label lblQuery;
        private System.Windows.Forms.TextBox txtQuery;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.ComboBox cmbLocation;
        private System.Windows.Forms.ComboBox cmbRadius;
        private System.Windows.Forms.Label lblRadius;
    }
}
namespace Video_Club
{
    partial class DialogoError
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DialogoError));
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.icon = new System.Windows.Forms.PictureBox();
            this.icon_delay = new System.Windows.Forms.Timer(this.components);
            this.lbDialog = new System.Windows.Forms.Label();
            this.btnOk = new Bunifu.Framework.UI.BunifuThinButton2();
            this.label_delay = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.icon)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = this;
            this.bunifuDragControl1.Vertical = true;
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 30;
            this.bunifuElipse1.TargetControl = this;
            // 
            // icon
            // 
            this.icon.BackColor = System.Drawing.SystemColors.Control;
            this.icon.Enabled = false;
            this.icon.Image = ((System.Drawing.Image)(resources.GetObject("icon.Image")));
            this.icon.Location = new System.Drawing.Point(112, 13);
            this.icon.Name = "icon";
            this.icon.Size = new System.Drawing.Size(211, 170);
            this.icon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.icon.TabIndex = 3;
            this.icon.TabStop = false;
            // 
            // icon_delay
            // 
            this.icon_delay.Enabled = true;
            this.icon_delay.Interval = 1500;
            this.icon_delay.Tick += new System.EventHandler(this.icon_delay_Tick);
            // 
            // lbDialog
            // 
            this.lbDialog.AutoSize = true;
            this.lbDialog.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDialog.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbDialog.Location = new System.Drawing.Point(95, 186);
            this.lbDialog.Name = "lbDialog";
            this.lbDialog.Size = new System.Drawing.Size(246, 25);
            this.lbDialog.TabIndex = 5;
            this.lbDialog.Text = "Error al Cargar los datos";
            this.lbDialog.Visible = false;
            // 
            // btnOk
            // 
            this.btnOk.ActiveBorderThickness = 1;
            this.btnOk.ActiveCornerRadius = 20;
            this.btnOk.ActiveFillColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnOk.ActiveForecolor = System.Drawing.Color.White;
            this.btnOk.ActiveLineColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnOk.BackColor = System.Drawing.Color.White;
            this.btnOk.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnOk.BackgroundImage")));
            this.btnOk.ButtonText = "OK";
            this.btnOk.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOk.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOk.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnOk.IdleBorderThickness = 1;
            this.btnOk.IdleCornerRadius = 20;
            this.btnOk.IdleFillColor = System.Drawing.Color.White;
            this.btnOk.IdleForecolor = System.Drawing.SystemColors.ActiveCaption;
            this.btnOk.IdleLineColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnOk.Location = new System.Drawing.Point(144, 216);
            this.btnOk.Margin = new System.Windows.Forms.Padding(5);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(140, 54);
            this.btnOk.TabIndex = 4;
            this.btnOk.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnOk.Visible = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // label_delay
            // 
            this.label_delay.Enabled = true;
            this.label_delay.Interval = 500;
            this.label_delay.Tick += new System.EventHandler(this.label_delay_Tick);
            // 
            // DialogoError
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(425, 283);
            this.Controls.Add(this.icon);
            this.Controls.Add(this.lbDialog);
            this.Controls.Add(this.btnOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DialogoError";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DialogoError";
            ((System.ComponentModel.ISupportInitialize)(this.icon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.PictureBox icon;
        private System.Windows.Forms.Label lbDialog;
        private Bunifu.Framework.UI.BunifuThinButton2 btnOk;
        private System.Windows.Forms.Timer icon_delay;
        private System.Windows.Forms.Timer label_delay;
    }
}
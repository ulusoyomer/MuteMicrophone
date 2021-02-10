
namespace MuteMicrophone
{
    partial class Mainform
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
            this.btn_Record = new System.Windows.Forms.Button();
            this.btn_RecordStop = new System.Windows.Forms.Button();
            this.btn_MuteUnmuteMic = new System.Windows.Forms.Button();
            this.tb_Keys = new System.Windows.Forms.TextBox();
            this.rdb_Press = new System.Windows.Forms.RadioButton();
            this.rdb_OnOff = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.lb_Status = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.pB_MicStatusImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pB_MicStatusImage)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Record
            // 
            this.btn_Record.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(114)))), ((int)(((byte)(44)))));
            this.btn_Record.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Record.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(114)))), ((int)(((byte)(44)))));
            this.btn_Record.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Record.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_Record.Location = new System.Drawing.Point(12, 191);
            this.btn_Record.Name = "btn_Record";
            this.btn_Record.Size = new System.Drawing.Size(54, 23);
            this.btn_Record.TabIndex = 1;
            this.btn_Record.Text = "Record";
            this.btn_Record.UseVisualStyleBackColor = false;
            this.btn_Record.Click += new System.EventHandler(this.btn_Record_Click);
            // 
            // btn_RecordStop
            // 
            this.btn_RecordStop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(114)))), ((int)(((byte)(44)))));
            this.btn_RecordStop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_RecordStop.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(114)))), ((int)(((byte)(44)))));
            this.btn_RecordStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_RecordStop.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_RecordStop.Location = new System.Drawing.Point(72, 191);
            this.btn_RecordStop.Name = "btn_RecordStop";
            this.btn_RecordStop.Size = new System.Drawing.Size(84, 23);
            this.btn_RecordStop.TabIndex = 2;
            this.btn_RecordStop.Text = "Record Stop";
            this.btn_RecordStop.UseVisualStyleBackColor = false;
            this.btn_RecordStop.Click += new System.EventHandler(this.btn_RecordStop_Click);
            // 
            // btn_MuteUnmuteMic
            // 
            this.btn_MuteUnmuteMic.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(114)))), ((int)(((byte)(44)))));
            this.btn_MuteUnmuteMic.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_MuteUnmuteMic.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(114)))), ((int)(((byte)(44)))));
            this.btn_MuteUnmuteMic.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_MuteUnmuteMic.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_MuteUnmuteMic.Location = new System.Drawing.Point(162, 191);
            this.btn_MuteUnmuteMic.Name = "btn_MuteUnmuteMic";
            this.btn_MuteUnmuteMic.Size = new System.Drawing.Size(54, 23);
            this.btn_MuteUnmuteMic.TabIndex = 3;
            this.btn_MuteUnmuteMic.Text = "Unmute";
            this.btn_MuteUnmuteMic.UseVisualStyleBackColor = false;
            this.btn_MuteUnmuteMic.Click += new System.EventHandler(this.btn_MuteUnmuteMic_Click);
            // 
            // tb_Keys
            // 
            this.tb_Keys.Enabled = false;
            this.tb_Keys.Location = new System.Drawing.Point(13, 246);
            this.tb_Keys.Name = "tb_Keys";
            this.tb_Keys.Size = new System.Drawing.Size(203, 20);
            this.tb_Keys.TabIndex = 4;
            // 
            // rdb_Press
            // 
            this.rdb_Press.AutoSize = true;
            this.rdb_Press.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.rdb_Press.Location = new System.Drawing.Point(12, 293);
            this.rdb_Press.Name = "rdb_Press";
            this.rdb_Press.Size = new System.Drawing.Size(51, 17);
            this.rdb_Press.TabIndex = 5;
            this.rdb_Press.Text = "Press";
            this.rdb_Press.UseVisualStyleBackColor = true;
            this.rdb_Press.CheckedChanged += new System.EventHandler(this.rdb_Press_CheckedChanged);
            // 
            // rdb_OnOff
            // 
            this.rdb_OnOff.AutoSize = true;
            this.rdb_OnOff.Checked = true;
            this.rdb_OnOff.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.rdb_OnOff.Location = new System.Drawing.Point(69, 293);
            this.rdb_OnOff.Name = "rdb_OnOff";
            this.rdb_OnOff.Size = new System.Drawing.Size(58, 17);
            this.rdb_OnOff.TabIndex = 6;
            this.rdb_OnOff.TabStop = true;
            this.rdb_OnOff.Text = "On/Off";
            this.rdb_OnOff.UseVisualStyleBackColor = true;
            this.rdb_OnOff.CheckedChanged += new System.EventHandler(this.rdb_OnOff_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(8, 269);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 21);
            this.label1.TabIndex = 7;
            this.label1.Text = "Mute Mode";
            // 
            // lb_Status
            // 
            this.lb_Status.AutoSize = true;
            this.lb_Status.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lb_Status.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lb_Status.Location = new System.Drawing.Point(12, 217);
            this.lb_Status.Name = "lb_Status";
            this.lb_Status.Size = new System.Drawing.Size(38, 21);
            this.lb_Status.TabIndex = 8;
            this.lb_Status.Text = "----";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(114)))), ((int)(((byte)(44)))));
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(114)))), ((int)(((byte)(44)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button1.Location = new System.Drawing.Point(133, 272);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(84, 40);
            this.button1.TabIndex = 9;
            this.button1.Text = "Off";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // pB_MicStatusImage
            // 
            this.pB_MicStatusImage.Image = global::MuteMicrophone.Properties.Resources.microphone_80px;
            this.pB_MicStatusImage.ImageLocation = "";
            this.pB_MicStatusImage.Location = new System.Drawing.Point(72, 57);
            this.pB_MicStatusImage.Name = "pB_MicStatusImage";
            this.pB_MicStatusImage.Size = new System.Drawing.Size(84, 90);
            this.pB_MicStatusImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pB_MicStatusImage.TabIndex = 0;
            this.pB_MicStatusImage.TabStop = false;
            // 
            // Mainform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(228, 322);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lb_Status);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rdb_OnOff);
            this.Controls.Add(this.rdb_Press);
            this.Controls.Add(this.tb_Keys);
            this.Controls.Add(this.btn_MuteUnmuteMic);
            this.Controls.Add(this.btn_RecordStop);
            this.Controls.Add(this.btn_Record);
            this.Controls.Add(this.pB_MicStatusImage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Mainform";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MuteMicrophone";
            this.Load += new System.EventHandler(this.Mainform_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.pB_MicStatusImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pB_MicStatusImage;
        private System.Windows.Forms.Button btn_Record;
        private System.Windows.Forms.Button btn_RecordStop;
        private System.Windows.Forms.Button btn_MuteUnmuteMic;
        private System.Windows.Forms.TextBox tb_Keys;
        private System.Windows.Forms.RadioButton rdb_Press;
        private System.Windows.Forms.RadioButton rdb_OnOff;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lb_Status;
        private System.Windows.Forms.Button button1;
    }
}


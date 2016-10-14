namespace BackupreportTool
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.dtpicker1 = new System.Windows.Forms.DateTimePicker();
            this.dtpicker2 = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnsubmit = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpicker3 = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.dtpicker4 = new System.Windows.Forms.DateTimePicker();
            this.txtDB = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.btnsaveConfig = new System.Windows.Forms.Button();
            this.chkMonth = new System.Windows.Forms.CheckBox();
            this.checkbox_AutoUpdate = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(384, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            this.label1.Visible = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 341);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(382, 105);
            this.dataGridView1.TabIndex = 1;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(12, 124);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(632, 210);
            this.dataGridView2.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label2.Location = new System.Drawing.Point(14, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 29);
            this.label2.TabIndex = 3;
            this.label2.Text = "label2";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(220, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 13);
            this.label4.TabIndex = 5;
            // 
            // dtpicker1
            // 
            this.dtpicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpicker1.Location = new System.Drawing.Point(52, 13);
            this.dtpicker1.Name = "dtpicker1";
            this.dtpicker1.Size = new System.Drawing.Size(104, 20);
            this.dtpicker1.TabIndex = 6;
            // 
            // dtpicker2
            // 
            this.dtpicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpicker2.Location = new System.Drawing.Point(190, 13);
            this.dtpicker2.Name = "dtpicker2";
            this.dtpicker2.Size = new System.Drawing.Size(107, 20);
            this.dtpicker2.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "From";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(164, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(20, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "To";
            // 
            // btnsubmit
            // 
            this.btnsubmit.Location = new System.Drawing.Point(303, 12);
            this.btnsubmit.Name = "btnsubmit";
            this.btnsubmit.Size = new System.Drawing.Size(75, 23);
            this.btnsubmit.TabIndex = 10;
            this.btnsubmit.Text = "Submit";
            this.btnsubmit.UseVisualStyleBackColor = true;
            this.btnsubmit.Click += new System.EventHandler(this.btnsubmit_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(190, 44);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(0, 13);
            this.label7.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Period Start";
            // 
            // dtpicker3
            // 
            this.dtpicker3.Enabled = false;
            this.dtpicker3.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpicker3.Location = new System.Drawing.Point(84, 38);
            this.dtpicker3.Name = "dtpicker3";
            this.dtpicker3.Size = new System.Drawing.Size(107, 20);
            this.dtpicker3.TabIndex = 16;
            this.dtpicker3.Value = new System.DateTime(2016, 6, 10, 6, 0, 0, 0);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(197, 43);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Period End";
            // 
            // dtpicker4
            // 
            this.dtpicker4.Enabled = false;
            this.dtpicker4.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpicker4.Location = new System.Drawing.Point(262, 39);
            this.dtpicker4.Name = "dtpicker4";
            this.dtpicker4.Size = new System.Drawing.Size(107, 20);
            this.dtpicker4.TabIndex = 17;
            this.dtpicker4.Value = new System.DateTime(2016, 6, 10, 6, 0, 2, 0);
            // 
            // txtDB
            // 
            this.txtDB.Location = new System.Drawing.Point(104, 64);
            this.txtDB.Name = "txtDB";
            this.txtDB.Size = new System.Drawing.Size(140, 20);
            this.txtDB.TabIndex = 18;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 67);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(82, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "DataBaseName";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(251, 67);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 13);
            this.label10.TabIndex = 20;
            this.label10.Text = "FolderName";
            // 
            // txtFile
            // 
            this.txtFile.Location = new System.Drawing.Point(321, 65);
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(117, 20);
            this.txtFile.TabIndex = 21;
            // 
            // btnsaveConfig
            // 
            this.btnsaveConfig.Location = new System.Drawing.Point(444, 64);
            this.btnsaveConfig.Name = "btnsaveConfig";
            this.btnsaveConfig.Size = new System.Drawing.Size(75, 23);
            this.btnsaveConfig.TabIndex = 0;
            this.btnsaveConfig.Text = "Save";
            this.btnsaveConfig.Click += new System.EventHandler(this.btnsaveConfig_Click);
            // 
            // chkMonth
            // 
            this.chkMonth.AutoSize = true;
            this.chkMonth.Checked = true;
            this.chkMonth.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMonth.Location = new System.Drawing.Point(387, 38);
            this.chkMonth.Name = "chkMonth";
            this.chkMonth.Size = new System.Drawing.Size(97, 17);
            this.chkMonth.TabIndex = 22;
            this.chkMonth.Text = "Export 1 month";
            this.chkMonth.UseVisualStyleBackColor = true;
            this.chkMonth.CheckedChanged += new System.EventHandler(this.chkMonth_CheckedChanged);
            // 
            // checkbox_AutoUpdate
            // 
            this.checkbox_AutoUpdate.AutoSize = true;
            this.checkbox_AutoUpdate.Location = new System.Drawing.Point(491, 38);
            this.checkbox_AutoUpdate.Name = "checkbox_AutoUpdate";
            this.checkbox_AutoUpdate.Size = new System.Drawing.Size(83, 17);
            this.checkbox_AutoUpdate.TabIndex = 23;
            this.checkbox_AutoUpdate.Text = "AutoUpdate";
            this.checkbox_AutoUpdate.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 120);
            this.Controls.Add(this.checkbox_AutoUpdate);
            this.Controls.Add(this.chkMonth);
            this.Controls.Add(this.btnsaveConfig);
            this.Controls.Add(this.txtFile);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtDB);
            this.Controls.Add(this.dtpicker4);
            this.Controls.Add(this.dtpicker3);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnsubmit);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dtpicker2);
            this.Controls.Add(this.dtpicker1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "BackupDatabaseTool";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpicker1;
        private System.Windows.Forms.DateTimePicker dtpicker2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnsubmit;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpicker3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtpicker4;
        private System.Windows.Forms.TextBox txtDB;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.Button btnsaveConfig;
        private System.Windows.Forms.CheckBox chkMonth;
        private System.Windows.Forms.CheckBox checkbox_AutoUpdate;

    }
}


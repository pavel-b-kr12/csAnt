namespace csAnt_FastDrawToBitmap
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.label_dt_walk = new System.Windows.Forms.Label();
            this.btn_speed_sub = new System.Windows.Forms.Button();
            this.checkBox_show_imageColorized = new System.Windows.Forms.CheckBox();
            this.checkBox_bDrawColorizationToField = new System.Windows.Forms.CheckBox();
            this.label_step_ii = new System.Windows.Forms.Label();
            this.btn_speed = new System.Windows.Forms.Button();
            this.checkBox_mirrorWall = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_fillClearField = new System.Windows.Forms.Button();
            this.comboBox_colorizeType = new System.Windows.Forms.ListBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.label_slider_H_mod = new System.Windows.Forms.Label();
            this.slider_colorizeRange = new System.Windows.Forms.TrackBar();
            this.listBox_ColorizeSkipBGType = new System.Windows.Forms.ListBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.slider_colorizeRange)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(998, 1005);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.label_dt_walk);
            this.splitContainer1.Panel1.Controls.Add(this.btn_speed_sub);
            this.splitContainer1.Panel1.Controls.Add(this.checkBox_bDrawColorizationToField);
            this.splitContainer1.Panel1.Controls.Add(this.label_step_ii);
            this.splitContainer1.Panel1.Controls.Add(this.btn_speed);
            this.splitContainer1.Panel1.Controls.Add(this.checkBox_mirrorWall);
            this.splitContainer1.Panel1.Controls.Add(this.button1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pictureBox1);
            this.splitContainer1.Size = new System.Drawing.Size(998, 1041);
            this.splitContainer1.SplitterDistance = 32;
            this.splitContainer1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(38, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "walk | draw";
            // 
            // label_dt_walk
            // 
            this.label_dt_walk.AutoSize = true;
            this.label_dt_walk.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_dt_walk.Location = new System.Drawing.Point(12, 10);
            this.label_dt_walk.Name = "label_dt_walk";
            this.label_dt_walk.Size = new System.Drawing.Size(26, 16);
            this.label_dt_walk.TabIndex = 9;
            this.label_dt_walk.Text = "ms";
            // 
            // btn_speed_sub
            // 
            this.btn_speed_sub.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_speed_sub.Location = new System.Drawing.Point(306, 6);
            this.btn_speed_sub.Name = "btn_speed_sub";
            this.btn_speed_sub.Size = new System.Drawing.Size(62, 23);
            this.btn_speed_sub.TabIndex = 8;
            this.btn_speed_sub.Text = "speed -";
            this.btn_speed_sub.UseVisualStyleBackColor = true;
            this.btn_speed_sub.Click += new System.EventHandler(this.btn_speed_sub_Click);
            // 
            // checkBox_show_imageColorized
            // 
            this.checkBox_show_imageColorized.AutoSize = true;
            this.checkBox_show_imageColorized.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBox_show_imageColorized.Location = new System.Drawing.Point(16, 6);
            this.checkBox_show_imageColorized.Name = "checkBox_show_imageColorized";
            this.checkBox_show_imageColorized.Size = new System.Drawing.Size(421, 24);
            this.checkBox_show_imageColorized.TabIndex = 7;
            this.checkBox_show_imageColorized.Text = "show colorized image (press CTRL) with settings:";
            this.checkBox_show_imageColorized.UseVisualStyleBackColor = true;
            this.checkBox_show_imageColorized.CheckedChanged += new System.EventHandler(this.checkBox_show_imageColorized_CheckedChanged);
            // 
            // checkBox_bDrawColorizationToField
            // 
            this.checkBox_bDrawColorizationToField.AutoSize = true;
            this.checkBox_bDrawColorizationToField.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBox_bDrawColorizationToField.Location = new System.Drawing.Point(455, 8);
            this.checkBox_bDrawColorizationToField.Name = "checkBox_bDrawColorizationToField";
            this.checkBox_bDrawColorizationToField.Size = new System.Drawing.Size(183, 20);
            this.checkBox_bDrawColorizationToField.TabIndex = 5;
            this.checkBox_bDrawColorizationToField.Text = "bDrawColorizationToField";
            this.checkBox_bDrawColorizationToField.UseVisualStyleBackColor = true;
            this.checkBox_bDrawColorizationToField.CheckedChanged += new System.EventHandler(this.checkBox_bDrawColorizationToField_CheckedChanged);
            this.checkBox_bDrawColorizationToField.CheckStateChanged += new System.EventHandler(this.checkBox_bDrawHist_CheckStateChanged);
            // 
            // label_step_ii
            // 
            this.label_step_ii.AutoSize = true;
            this.label_step_ii.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_step_ii.Location = new System.Drawing.Point(644, 8);
            this.label_step_ii.Name = "label_step_ii";
            this.label_step_ii.Size = new System.Drawing.Size(34, 16);
            this.label_step_ii.TabIndex = 4;
            this.label_step_ii.Text = "step";
            // 
            // btn_speed
            // 
            this.btn_speed.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_speed.Location = new System.Drawing.Point(374, 6);
            this.btn_speed.Name = "btn_speed";
            this.btn_speed.Size = new System.Drawing.Size(75, 23);
            this.btn_speed.TabIndex = 3;
            this.btn_speed.Text = "speed +";
            this.btn_speed.UseVisualStyleBackColor = true;
            this.btn_speed.Click += new System.EventHandler(this.btn_speed_Click);
            // 
            // checkBox_mirrorWall
            // 
            this.checkBox_mirrorWall.AutoSize = true;
            this.checkBox_mirrorWall.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBox_mirrorWall.Location = new System.Drawing.Point(222, 9);
            this.checkBox_mirrorWall.Name = "checkBox_mirrorWall";
            this.checkBox_mirrorWall.Size = new System.Drawing.Size(87, 20);
            this.checkBox_mirrorWall.TabIndex = 2;
            this.checkBox_mirrorWall.Text = "mirror wall";
            this.checkBox_mirrorWall.UseVisualStyleBackColor = true;
            this.checkBox_mirrorWall.CheckStateChanged += new System.EventHandler(this.checkBox_mirrorWall_CheckStateChanged);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(117, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_fillClearField
            // 
            this.btn_fillClearField.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_fillClearField.Location = new System.Drawing.Point(16, 145);
            this.btn_fillClearField.Name = "btn_fillClearField";
            this.btn_fillClearField.Size = new System.Drawing.Size(75, 23);
            this.btn_fillClearField.TabIndex = 1;
            this.btn_fillClearField.Text = "clear field";
            this.btn_fillClearField.UseVisualStyleBackColor = true;
            this.btn_fillClearField.Click += new System.EventHandler(this.btn_fillField_clear_Click);
            // 
            // comboBox_colorizeType
            // 
            this.comboBox_colorizeType.CausesValidation = false;
            this.comboBox_colorizeType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBox_colorizeType.FormattingEnabled = true;
            this.comboBox_colorizeType.ItemHeight = 16;
            this.comboBox_colorizeType.Location = new System.Drawing.Point(3, 174);
            this.comboBox_colorizeType.Name = "comboBox_colorizeType";
            this.comboBox_colorizeType.Size = new System.Drawing.Size(201, 100);
            this.comboBox_colorizeType.TabIndex = 6;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.label_slider_H_mod);
            this.splitContainer2.Panel2.Controls.Add(this.slider_colorizeRange);
            this.splitContainer2.Panel2.Controls.Add(this.listBox_ColorizeSkipBGType);
            this.splitContainer2.Panel2.Controls.Add(this.checkBox_show_imageColorized);
            this.splitContainer2.Panel2.Controls.Add(this.comboBox_colorizeType);
            this.splitContainer2.Panel2.Controls.Add(this.btn_fillClearField);
            this.splitContainer2.Panel2.Controls.Add(this.pictureBox2);
            this.splitContainer2.Size = new System.Drawing.Size(1564, 1041);
            this.splitContainer2.SplitterDistance = 998;
            this.splitContainer2.TabIndex = 7;
            // 
            // label_slider_H_mod
            // 
            this.label_slider_H_mod.AutoSize = true;
            this.label_slider_H_mod.BackColor = System.Drawing.Color.Transparent;
            this.label_slider_H_mod.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_slider_H_mod.Location = new System.Drawing.Point(302, 186);
            this.label_slider_H_mod.Name = "label_slider_H_mod";
            this.label_slider_H_mod.Size = new System.Drawing.Size(140, 16);
            this.label_slider_H_mod.TabIndex = 10;
            this.label_slider_H_mod.Text = "H_mod colorize range";
            // 
            // slider_colorizeRange
            // 
            this.slider_colorizeRange.Location = new System.Drawing.Point(210, 174);
            this.slider_colorizeRange.Maximum = 100;
            this.slider_colorizeRange.Minimum = 1;
            this.slider_colorizeRange.Name = "slider_colorizeRange";
            this.slider_colorizeRange.Size = new System.Drawing.Size(323, 45);
            this.slider_colorizeRange.TabIndex = 9;
            this.slider_colorizeRange.TickStyle = System.Windows.Forms.TickStyle.None;
            this.slider_colorizeRange.Value = 20;
            this.slider_colorizeRange.Scroll += new System.EventHandler(this.slider_colorizeRange_Scroll);
            // 
            // listBox_ColorizeSkipBGType
            // 
            this.listBox_ColorizeSkipBGType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listBox_ColorizeSkipBGType.FormattingEnabled = true;
            this.listBox_ColorizeSkipBGType.ItemHeight = 16;
            this.listBox_ColorizeSkipBGType.Location = new System.Drawing.Point(4, 322);
            this.listBox_ColorizeSkipBGType.Name = "listBox_ColorizeSkipBGType";
            this.listBox_ColorizeSkipBGType.Size = new System.Drawing.Size(191, 84);
            this.listBox_ColorizeSkipBGType.TabIndex = 7;
            this.listBox_ColorizeSkipBGType.SelectedIndexChanged += new System.EventHandler(this.listBox_ColorizeSkipBGType_SelectedIndexChanged);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(7, 36);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(552, 1002);
            this.pictureBox2.TabIndex = 8;
            this.pictureBox2.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1564, 1041);
            this.Controls.Add(this.splitContainer2);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.slider_colorizeRange)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_fillClearField;
        private System.Windows.Forms.CheckBox checkBox_mirrorWall;
        private System.Windows.Forms.Button btn_speed;
        private System.Windows.Forms.Label label_step_ii;
        private System.Windows.Forms.CheckBox checkBox_bDrawColorizationToField;
        private System.Windows.Forms.ListBox comboBox_colorizeType;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ListBox listBox_ColorizeSkipBGType;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.CheckBox checkBox_show_imageColorized;
        private System.Windows.Forms.TrackBar slider_colorizeRange;
        private System.Windows.Forms.Label label_slider_H_mod;
        private System.Windows.Forms.Button btn_speed_sub;
        private System.Windows.Forms.Label label_dt_walk;
        private System.Windows.Forms.Label label1;
    }
}


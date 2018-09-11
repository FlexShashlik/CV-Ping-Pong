namespace WindowsForms
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.trackBarhMin = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxhMin = new System.Windows.Forms.TextBox();
            this.textBoxhMax = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.trackBarhMax = new System.Windows.Forms.TrackBar();
            this.trackBarsMin = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxsMin = new System.Windows.Forms.TextBox();
            this.trackBarsMax = new System.Windows.Forms.TrackBar();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxsMax = new System.Windows.Forms.TextBox();
            this.trackBarvMin = new System.Windows.Forms.TrackBar();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxvMin = new System.Windows.Forms.TextBox();
            this.trackBarvMax = new System.Windows.Forms.TrackBar();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxvMax = new System.Windows.Forms.TextBox();
            this.timerBall = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarhMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarhMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarsMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarsMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarvMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarvMax)).BeginInit();
            this.SuspendLayout();
            // 
            // trackBarhMin
            // 
            this.trackBarhMin.Location = new System.Drawing.Point(59, 25);
            this.trackBarhMin.Maximum = 255;
            this.trackBarhMin.Name = "trackBarhMin";
            this.trackBarhMin.Size = new System.Drawing.Size(532, 45);
            this.trackBarhMin.TabIndex = 0;
            this.trackBarhMin.Scroll += new System.EventHandler(this.trackBarhMin_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "hMin";
            // 
            // textBoxhMin
            // 
            this.textBoxhMin.Location = new System.Drawing.Point(13, 42);
            this.textBoxhMin.Name = "textBoxhMin";
            this.textBoxhMin.Size = new System.Drawing.Size(40, 20);
            this.textBoxhMin.TabIndex = 2;
            this.textBoxhMin.Text = "0";
            // 
            // textBoxhMax
            // 
            this.textBoxhMax.Location = new System.Drawing.Point(13, 93);
            this.textBoxhMax.Name = "textBoxhMax";
            this.textBoxhMax.Size = new System.Drawing.Size(40, 20);
            this.textBoxhMax.TabIndex = 5;
            this.textBoxhMax.Text = "255";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "hMax";
            // 
            // trackBarhMax
            // 
            this.trackBarhMax.Location = new System.Drawing.Point(59, 76);
            this.trackBarhMax.Maximum = 255;
            this.trackBarhMax.Name = "trackBarhMax";
            this.trackBarhMax.Size = new System.Drawing.Size(532, 45);
            this.trackBarhMax.TabIndex = 3;
            this.trackBarhMax.Value = 255;
            this.trackBarhMax.Scroll += new System.EventHandler(this.trackBarhMax_Scroll);
            // 
            // trackBarsMin
            // 
            this.trackBarsMin.Location = new System.Drawing.Point(59, 166);
            this.trackBarsMin.Maximum = 255;
            this.trackBarsMin.Name = "trackBarsMin";
            this.trackBarsMin.Size = new System.Drawing.Size(532, 45);
            this.trackBarsMin.TabIndex = 0;
            this.trackBarsMin.Scroll += new System.EventHandler(this.trackBarsMin_Scroll);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 166);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "sMin";
            // 
            // textBoxsMin
            // 
            this.textBoxsMin.Location = new System.Drawing.Point(13, 183);
            this.textBoxsMin.Name = "textBoxsMin";
            this.textBoxsMin.Size = new System.Drawing.Size(40, 20);
            this.textBoxsMin.TabIndex = 2;
            this.textBoxsMin.Text = "0";
            // 
            // trackBarsMax
            // 
            this.trackBarsMax.Location = new System.Drawing.Point(59, 217);
            this.trackBarsMax.Maximum = 255;
            this.trackBarsMax.Name = "trackBarsMax";
            this.trackBarsMax.Size = new System.Drawing.Size(532, 45);
            this.trackBarsMax.TabIndex = 3;
            this.trackBarsMax.Value = 255;
            this.trackBarsMax.Scroll += new System.EventHandler(this.trackBarsMax_Scroll);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 217);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "sMax";
            // 
            // textBoxsMax
            // 
            this.textBoxsMax.Location = new System.Drawing.Point(13, 234);
            this.textBoxsMax.Name = "textBoxsMax";
            this.textBoxsMax.Size = new System.Drawing.Size(40, 20);
            this.textBoxsMax.TabIndex = 5;
            this.textBoxsMax.Text = "255";
            // 
            // trackBarvMin
            // 
            this.trackBarvMin.Location = new System.Drawing.Point(59, 331);
            this.trackBarvMin.Maximum = 255;
            this.trackBarvMin.Name = "trackBarvMin";
            this.trackBarvMin.Size = new System.Drawing.Size(532, 45);
            this.trackBarvMin.TabIndex = 0;
            this.trackBarvMin.Scroll += new System.EventHandler(this.trackBarvMin_Scroll);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 331);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "vMin";
            // 
            // textBoxvMin
            // 
            this.textBoxvMin.Location = new System.Drawing.Point(13, 348);
            this.textBoxvMin.Name = "textBoxvMin";
            this.textBoxvMin.Size = new System.Drawing.Size(40, 20);
            this.textBoxvMin.TabIndex = 2;
            this.textBoxvMin.Text = "0";
            // 
            // trackBarvMax
            // 
            this.trackBarvMax.Location = new System.Drawing.Point(59, 382);
            this.trackBarvMax.Maximum = 255;
            this.trackBarvMax.Name = "trackBarvMax";
            this.trackBarvMax.Size = new System.Drawing.Size(532, 45);
            this.trackBarvMax.TabIndex = 3;
            this.trackBarvMax.Value = 255;
            this.trackBarvMax.Scroll += new System.EventHandler(this.trackBarvMax_Scroll);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 382);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "vMax";
            // 
            // textBoxvMax
            // 
            this.textBoxvMax.Location = new System.Drawing.Point(13, 399);
            this.textBoxvMax.Name = "textBoxvMax";
            this.textBoxvMax.Size = new System.Drawing.Size(40, 20);
            this.textBoxvMax.TabIndex = 5;
            this.textBoxvMax.Text = "255";
            // 
            // timerBall
            // 
            this.timerBall.Enabled = true;
            this.timerBall.Interval = 50;
            this.timerBall.Tick += new System.EventHandler(this.timerBall_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 439);
            this.Controls.Add(this.textBoxvMax);
            this.Controls.Add(this.textBoxsMax);
            this.Controls.Add(this.textBoxhMax);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.trackBarvMax);
            this.Controls.Add(this.textBoxvMin);
            this.Controls.Add(this.trackBarsMax);
            this.Controls.Add(this.textBoxsMin);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.trackBarhMax);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.trackBarvMin);
            this.Controls.Add(this.textBoxhMin);
            this.Controls.Add(this.trackBarsMin);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.trackBarhMin);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarhMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarhMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarsMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarsMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarvMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarvMax)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar trackBarhMin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxhMin;
        private System.Windows.Forms.TextBox textBoxhMax;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar trackBarhMax;
        private System.Windows.Forms.TrackBar trackBarsMin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxsMin;
        private System.Windows.Forms.TrackBar trackBarsMax;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxsMax;
        private System.Windows.Forms.TrackBar trackBarvMin;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxvMin;
        private System.Windows.Forms.TrackBar trackBarvMax;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxvMax;
        private System.Windows.Forms.Timer timerBall;
    }
}


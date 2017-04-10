namespace QLearning
{
    partial class frmQLearning
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQLearning));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnNextStep = new System.Windows.Forms.Button();
            this.lblLearningRate = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtLearningRate = new System.Windows.Forms.TextBox();
            this.txtDiscountFactor = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(907, 632);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.Location = new System.Drawing.Point(817, 661);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(102, 44);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStop.Location = new System.Drawing.Point(709, 661);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(102, 44);
            this.btnStop.TabIndex = 3;
            this.btnStop.Text = "stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnNextStep
            // 
            this.btnNextStep.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNextStep.Location = new System.Drawing.Point(601, 661);
            this.btnNextStep.Name = "btnNextStep";
            this.btnNextStep.Size = new System.Drawing.Size(102, 44);
            this.btnNextStep.TabIndex = 4;
            this.btnNextStep.Text = "next step";
            this.btnNextStep.UseVisualStyleBackColor = true;
            this.btnNextStep.Click += new System.EventHandler(this.btnNextStep_Click);
            // 
            // lblLearningRate
            // 
            this.lblLearningRate.AutoSize = true;
            this.lblLearningRate.Location = new System.Drawing.Point(13, 661);
            this.lblLearningRate.Name = "lblLearningRate";
            this.lblLearningRate.Size = new System.Drawing.Size(105, 13);
            this.lblLearningRate.TabIndex = 5;
            this.lblLearningRate.Text = "Learning rate (Alpha)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 692);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(190, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Future reward discount factor (Gamma)";
            // 
            // txtLearningRate
            // 
            this.txtLearningRate.Location = new System.Drawing.Point(124, 658);
            this.txtLearningRate.Name = "txtLearningRate";
            this.txtLearningRate.Size = new System.Drawing.Size(179, 20);
            this.txtLearningRate.TabIndex = 7;
            this.txtLearningRate.Text = "0,8";
            // 
            // txtDiscountFactor
            // 
            this.txtDiscountFactor.Location = new System.Drawing.Point(209, 689);
            this.txtDiscountFactor.Name = "txtDiscountFactor";
            this.txtDiscountFactor.Size = new System.Drawing.Size(94, 20);
            this.txtDiscountFactor.TabIndex = 8;
            this.txtDiscountFactor.Text = "0,5";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(345, 661);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Has converged";
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(431, 658);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(20, 20);
            this.pictureBox.TabIndex = 10;
            this.pictureBox.TabStop = false;
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "Red");
            this.imageList.Images.SetKeyName(1, "Green");
            // 
            // frmQLearning
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 717);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDiscountFactor);
            this.Controls.Add(this.txtLearningRate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblLearningRate);
            this.Controls.Add(this.btnNextStep);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.panel1);
            this.Name = "frmQLearning";
            this.Text = "QLearning";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnNextStep;
        private System.Windows.Forms.Label lblLearningRate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLearningRate;
        private System.Windows.Forms.TextBox txtDiscountFactor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.ImageList imageList;
    }
}


namespace Visual
{
    partial class Form1
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
            this.plotView1 = new OxyPlot.WindowsForms.PlotView();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.textBoxXMin = new System.Windows.Forms.TextBox();
            this.textBoxXMax = new System.Windows.Forms.TextBox();
            this.labelXMin = new System.Windows.Forms.Label();
            this.labelXMax = new System.Windows.Forms.Label();
            this.labelLagrange = new System.Windows.Forms.Label();
            this.checkBoxDerivative = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // plotView1
            // 
            this.plotView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.plotView1.Location = new System.Drawing.Point(13, 9);
            this.plotView1.Name = "plotView1";
            this.plotView1.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.plotView1.Size = new System.Drawing.Size(524, 429);
            this.plotView1.TabIndex = 0;
            this.plotView1.Text = "plotView1";
            this.plotView1.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.plotView1.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.plotView1.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(713, 296);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Draw";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(543, 29);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(245, 258);
            this.dataGridView1.TabIndex = 2;
            // 
            // textBoxXMin
            // 
            this.textBoxXMin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxXMin.Location = new System.Drawing.Point(581, 298);
            this.textBoxXMin.Name = "textBoxXMin";
            this.textBoxXMin.Size = new System.Drawing.Size(100, 20);
            this.textBoxXMin.TabIndex = 3;
            this.textBoxXMin.Text = "-100";
            this.textBoxXMin.TextChanged += new System.EventHandler(this.textBoxXMin_TextChanged);
            this.textBoxXMin.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxXMin_Validating);
            // 
            // textBoxXMax
            // 
            this.textBoxXMax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxXMax.Location = new System.Drawing.Point(581, 324);
            this.textBoxXMax.Name = "textBoxXMax";
            this.textBoxXMax.Size = new System.Drawing.Size(100, 20);
            this.textBoxXMax.TabIndex = 4;
            this.textBoxXMax.Text = "100";
            this.textBoxXMax.TextChanged += new System.EventHandler(this.textBoxXMax_TextChanged);
            this.textBoxXMax.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxXMax_Validating);
            // 
            // labelXMin
            // 
            this.labelXMin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelXMin.AutoSize = true;
            this.labelXMin.Location = new System.Drawing.Point(540, 301);
            this.labelXMin.Name = "labelXMin";
            this.labelXMin.Size = new System.Drawing.Size(31, 13);
            this.labelXMin.TabIndex = 5;
            this.labelXMin.Text = "XMin";
            // 
            // labelXMax
            // 
            this.labelXMax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelXMax.AutoSize = true;
            this.labelXMax.Location = new System.Drawing.Point(540, 327);
            this.labelXMax.Name = "labelXMax";
            this.labelXMax.Size = new System.Drawing.Size(34, 13);
            this.labelXMax.TabIndex = 6;
            this.labelXMax.Text = "XMax";
            // 
            // labelLagrange
            // 
            this.labelLagrange.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelLagrange.AutoSize = true;
            this.labelLagrange.Location = new System.Drawing.Point(544, 10);
            this.labelLagrange.Name = "labelLagrange";
            this.labelLagrange.Size = new System.Drawing.Size(82, 13);
            this.labelLagrange.TabIndex = 7;
            this.labelLagrange.Text = "Lagrange-Table";
            // 
            // checkBoxDerivative
            // 
            this.checkBoxDerivative.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxDerivative.AutoSize = true;
            this.checkBoxDerivative.Location = new System.Drawing.Point(543, 350);
            this.checkBoxDerivative.Name = "checkBoxDerivative";
            this.checkBoxDerivative.Size = new System.Drawing.Size(104, 17);
            this.checkBoxDerivative.TabIndex = 9;
            this.checkBoxDerivative.Text = "Show Derivative";
            this.checkBoxDerivative.UseVisualStyleBackColor = true;
            this.checkBoxDerivative.CheckedChanged += new System.EventHandler(this.checkBoxDerivative_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.checkBoxDerivative);
            this.Controls.Add(this.labelLagrange);
            this.Controls.Add(this.labelXMax);
            this.Controls.Add(this.labelXMin);
            this.Controls.Add(this.textBoxXMax);
            this.Controls.Add(this.textBoxXMin);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.plotView1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OxyPlot.WindowsForms.PlotView plotView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox textBoxXMin;
        private System.Windows.Forms.TextBox textBoxXMax;
        private System.Windows.Forms.Label labelXMin;
        private System.Windows.Forms.Label labelXMax;
        private System.Windows.Forms.Label labelLagrange;
        private System.Windows.Forms.CheckBox checkBoxDerivative;
    }
}


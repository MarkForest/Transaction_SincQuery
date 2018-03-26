namespace WindowsFormsApplication1
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnFill = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnTransaction = new System.Windows.Forms.Button();
            this.btAsinc = new System.Windows.Forms.Button();
            this.btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 108);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(671, 309);
            this.dataGridView1.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 13);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(671, 20);
            this.textBox1.TabIndex = 1;
            // 
            // btnFill
            // 
            this.btnFill.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btnFill.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnFill.Location = new System.Drawing.Point(13, 39);
            this.btnFill.Name = "btnFill";
            this.btnFill.Size = new System.Drawing.Size(109, 63);
            this.btnFill.TabIndex = 2;
            this.btnFill.Text = "Fill";
            this.btnFill.UseVisualStyleBackColor = false;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(560, 39);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(123, 63);
            this.btnUpdate.TabIndex = 3;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            // 
            // btnTransaction
            // 
            this.btnTransaction.Location = new System.Drawing.Point(356, 39);
            this.btnTransaction.Name = "btnTransaction";
            this.btnTransaction.Size = new System.Drawing.Size(96, 63);
            this.btnTransaction.TabIndex = 4;
            this.btnTransaction.Text = "Transaction";
            this.btnTransaction.UseVisualStyleBackColor = true;
            this.btnTransaction.Click += new System.EventHandler(this.btnTransaction_Click);
            // 
            // btAsinc
            // 
            this.btAsinc.Location = new System.Drawing.Point(458, 39);
            this.btAsinc.Name = "btAsinc";
            this.btAsinc.Size = new System.Drawing.Size(96, 63);
            this.btAsinc.TabIndex = 5;
            this.btAsinc.Text = "Asinc Query";
            this.btAsinc.UseVisualStyleBackColor = true;
            this.btAsinc.Click += new System.EventHandler(this.btAsinc_Click);
            // 
            // btn
            // 
            this.btn.Location = new System.Drawing.Point(129, 40);
            this.btn.Name = "btn";
            this.btn.Size = new System.Drawing.Size(221, 62);
            this.btn.TabIndex = 6;
            this.btn.Text = "AwaitHandle";
            this.btn.UseVisualStyleBackColor = true;
            this.btn.Click += new System.EventHandler(this.btn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(695, 429);
            this.Controls.Add(this.btn);
            this.Controls.Add(this.btAsinc);
            this.Controls.Add(this.btnTransaction);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnFill);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnFill;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnTransaction;
        private System.Windows.Forms.Button btAsinc;
        private System.Windows.Forms.Button btn;
    }
}


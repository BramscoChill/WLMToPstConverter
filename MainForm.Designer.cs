namespace WLMToPst
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tbInputFolder = new System.Windows.Forms.TextBox();
            this.pbMainProgress = new System.Windows.Forms.ProgressBar();
            this.btSelectInputFolder = new System.Windows.Forms.Button();
            this.btSelectOutputFile = new System.Windows.Forms.Button();
            this.tbOutputFile = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.bnConvert = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbInputFolder
            // 
            this.tbInputFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbInputFolder.Location = new System.Drawing.Point(12, 110);
            this.tbInputFolder.Name = "tbInputFolder";
            this.tbInputFolder.Size = new System.Drawing.Size(437, 22);
            this.tbInputFolder.TabIndex = 0;
            this.tbInputFolder.TextChanged += new System.EventHandler(this.tbInputFolder_TextChanged);
            // 
            // pbMainProgress
            // 
            this.pbMainProgress.Location = new System.Drawing.Point(12, 28);
            this.pbMainProgress.Name = "pbMainProgress";
            this.pbMainProgress.Size = new System.Drawing.Size(437, 23);
            this.pbMainProgress.TabIndex = 1;
            // 
            // btSelectInputFolder
            // 
            this.btSelectInputFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSelectInputFolder.Location = new System.Drawing.Point(455, 110);
            this.btSelectInputFolder.Name = "btSelectInputFolder";
            this.btSelectInputFolder.Size = new System.Drawing.Size(102, 22);
            this.btSelectInputFolder.TabIndex = 2;
            this.btSelectInputFolder.Text = "Select folder";
            this.btSelectInputFolder.UseVisualStyleBackColor = true;
            this.btSelectInputFolder.Click += new System.EventHandler(this.btSelectInputFolder_Click);
            // 
            // btSelectOutputFile
            // 
            this.btSelectOutputFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSelectOutputFile.Location = new System.Drawing.Point(455, 158);
            this.btSelectOutputFile.Name = "btSelectOutputFile";
            this.btSelectOutputFile.Size = new System.Drawing.Size(102, 22);
            this.btSelectOutputFile.TabIndex = 4;
            this.btSelectOutputFile.Text = "Select file";
            this.btSelectOutputFile.UseVisualStyleBackColor = true;
            this.btSelectOutputFile.Click += new System.EventHandler(this.btSelectOutputFile_Click);
            // 
            // tbOutputFile
            // 
            this.tbOutputFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbOutputFile.Location = new System.Drawing.Point(12, 158);
            this.tbOutputFile.Name = "tbOutputFile";
            this.tbOutputFile.Size = new System.Drawing.Size(437, 22);
            this.tbOutputFile.TabIndex = 3;
            this.tbOutputFile.TextChanged += new System.EventHandler(this.tbOutputFile_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(206, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Windows live mail root mail folder";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 142);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Output *.pst file";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(162, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Progress (not working yet)";
            // 
            // bnConvert
            // 
            this.bnConvert.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bnConvert.Location = new System.Drawing.Point(15, 189);
            this.bnConvert.Name = "bnConvert";
            this.bnConvert.Size = new System.Drawing.Size(542, 22);
            this.bnConvert.TabIndex = 8;
            this.bnConvert.Text = "Convert";
            this.bnConvert.UseVisualStyleBackColor = true;
            this.bnConvert.Click += new System.EventHandler(this.bnConvert_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 223);
            this.Controls.Add(this.bnConvert);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btSelectOutputFile);
            this.Controls.Add(this.tbOutputFile);
            this.Controls.Add(this.btSelectInputFolder);
            this.Controls.Add(this.pbMainProgress);
            this.Controls.Add(this.tbInputFolder);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "Windows Live Mail to PST v1.0.1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbInputFolder;
        private System.Windows.Forms.ProgressBar pbMainProgress;
        private System.Windows.Forms.Button btSelectInputFolder;
        private System.Windows.Forms.Button btSelectOutputFile;
        private System.Windows.Forms.TextBox tbOutputFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button bnConvert;
    }
}


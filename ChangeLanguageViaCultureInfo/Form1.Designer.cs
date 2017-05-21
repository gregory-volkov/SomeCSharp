namespace ChangeLang
{
    partial class perInfoForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(perInfoForm));
            this.fstNameLabel = new System.Windows.Forms.Label();
            this.lastNameLabel = new System.Windows.Forms.Label();
            this.ukIco = new System.Windows.Forms.PictureBox();
            this.russiaIco = new System.Windows.Forms.PictureBox();
            this.ageLabel = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.flag = new System.Windows.Forms.PictureBox();
            this.title = new System.Windows.Forms.Label();
            this.registerButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ukIco)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.russiaIco)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.flag)).BeginInit();
            this.SuspendLayout();
            // 
            // fstNameLabel
            // 
            resources.ApplyResources(this.fstNameLabel, "fstNameLabel");
            this.fstNameLabel.BackColor = System.Drawing.Color.Transparent;
            this.fstNameLabel.ForeColor = System.Drawing.Color.White;
            this.fstNameLabel.Name = "fstNameLabel";
            // 
            // lastNameLabel
            // 
            resources.ApplyResources(this.lastNameLabel, "lastNameLabel");
            this.lastNameLabel.BackColor = System.Drawing.Color.Transparent;
            this.lastNameLabel.ForeColor = System.Drawing.Color.White;
            this.lastNameLabel.Name = "lastNameLabel";
            // 
            // ukIco
            // 
            this.ukIco.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.ukIco, "ukIco");
            this.ukIco.Name = "ukIco";
            this.ukIco.TabStop = false;
            this.ukIco.Click += new System.EventHandler(this.ukIco_Click);
            // 
            // russiaIco
            // 
            this.russiaIco.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.russiaIco, "russiaIco");
            this.russiaIco.Name = "russiaIco";
            this.russiaIco.TabStop = false;
            this.russiaIco.Click += new System.EventHandler(this.russiaIco_Click);
            // 
            // ageLabel
            // 
            resources.ApplyResources(this.ageLabel, "ageLabel");
            this.ageLabel.BackColor = System.Drawing.Color.Transparent;
            this.ageLabel.ForeColor = System.Drawing.Color.White;
            this.ageLabel.Name = "ageLabel";
            // 
            // textBox1
            // 
            resources.ApplyResources(this.textBox1, "textBox1");
            this.textBox1.Name = "textBox1";
            // 
            // textBox2
            // 
            resources.ApplyResources(this.textBox2, "textBox2");
            this.textBox2.Name = "textBox2";
            // 
            // textBox3
            // 
            resources.ApplyResources(this.textBox3, "textBox3");
            this.textBox3.Name = "textBox3";
            // 
            // flag
            // 
            resources.ApplyResources(this.flag, "flag");
            this.flag.Name = "flag";
            this.flag.TabStop = false;
            // 
            // title
            // 
            resources.ApplyResources(this.title, "title");
            this.title.BackColor = System.Drawing.Color.Transparent;
            this.title.ForeColor = System.Drawing.Color.White;
            this.title.Name = "title";
            // 
            // registerButton
            // 
            resources.ApplyResources(this.registerButton, "registerButton");
            this.registerButton.Name = "registerButton";
            this.registerButton.UseVisualStyleBackColor = true;
            // 
            // perInfoForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.registerButton);
            this.Controls.Add(this.title);
            this.Controls.Add(this.flag);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.ageLabel);
            this.Controls.Add(this.russiaIco);
            this.Controls.Add(this.ukIco);
            this.Controls.Add(this.lastNameLabel);
            this.Controls.Add(this.fstNameLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "perInfoForm";
            this.Load += new System.EventHandler(this.perInfoForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ukIco)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.russiaIco)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.flag)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label fstNameLabel;
        private System.Windows.Forms.Label lastNameLabel;
        private System.Windows.Forms.PictureBox ukIco;
        private System.Windows.Forms.PictureBox russiaIco;
        private System.Windows.Forms.Label ageLabel;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.PictureBox flag;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Button registerButton;
    }
}


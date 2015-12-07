namespace ReadInSoutions
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
            this.button1 = new System.Windows.Forms.Button();
            this.uxJson = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.uxLabel = new System.Windows.Forms.Label();
            this.uxAssnId = new System.Windows.Forms.TextBox();
            this.uxMode = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.uxStud = new System.Windows.Forms.TextBox();
            this.uxGrade = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(498, 317);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(240, 64);
            this.button1.TabIndex = 0;
            this.button1.Text = "Submit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // uxJson
            // 
            this.uxJson.Location = new System.Drawing.Point(43, 29);
            this.uxJson.Multiline = true;
            this.uxJson.Name = "uxJson";
            this.uxJson.Size = new System.Drawing.Size(695, 282);
            this.uxJson.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "JSON:";
            // 
            // uxLabel
            // 
            this.uxLabel.AutoSize = true;
            this.uxLabel.Location = new System.Drawing.Point(44, 317);
            this.uxLabel.Name = "uxLabel";
            this.uxLabel.Size = new System.Drawing.Size(92, 17);
            this.uxLabel.TabIndex = 5;
            this.uxLabel.Text = "AssignmentId";
            // 
            // uxAssnId
            // 
            this.uxAssnId.Location = new System.Drawing.Point(142, 317);
            this.uxAssnId.Name = "uxAssnId";
            this.uxAssnId.Size = new System.Drawing.Size(66, 22);
            this.uxAssnId.TabIndex = 6;
            // 
            // uxMode
            // 
            this.uxMode.FormattingEnabled = true;
            this.uxMode.Items.AddRange(new object[] {
            "Submission",
            "Solution"});
            this.uxMode.Location = new System.Drawing.Point(344, 318);
            this.uxMode.Name = "uxMode";
            this.uxMode.Size = new System.Drawing.Size(138, 24);
            this.uxMode.TabIndex = 7;
            this.uxMode.SelectedIndexChanged += new System.EventHandler(this.uxMode_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(292, 318);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "Mode";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 347);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "StudentId";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(44, 372);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 17);
            this.label4.TabIndex = 10;
            this.label4.Text = "Grade %";
            // 
            // uxStud
            // 
            this.uxStud.Location = new System.Drawing.Point(142, 344);
            this.uxStud.Name = "uxStud";
            this.uxStud.Size = new System.Drawing.Size(66, 22);
            this.uxStud.TabIndex = 11;
            // 
            // uxGrade
            // 
            this.uxGrade.Location = new System.Drawing.Point(142, 372);
            this.uxGrade.Name = "uxGrade";
            this.uxGrade.Size = new System.Drawing.Size(66, 22);
            this.uxGrade.TabIndex = 12;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 407);
            this.Controls.Add(this.uxGrade);
            this.Controls.Add(this.uxStud);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.uxMode);
            this.Controls.Add(this.uxAssnId);
            this.Controls.Add(this.uxLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.uxJson);
            this.Controls.Add(this.button1);
            this.Name = "MainForm";
            this.Text = "Submission Simulator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox uxJson;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label uxLabel;
        private System.Windows.Forms.TextBox uxAssnId;
        private System.Windows.Forms.ComboBox uxMode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox uxStud;
        private System.Windows.Forms.TextBox uxGrade;
    }
}
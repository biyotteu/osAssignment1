
namespace osAssignment1
{
    partial class SettingForm
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
            this.buffSizeEdit = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.equCountEdit = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buffSizeEdit
            // 
            this.buffSizeEdit.Location = new System.Drawing.Point(146, 21);
            this.buffSizeEdit.Name = "buffSizeEdit";
            this.buffSizeEdit.Size = new System.Drawing.Size(100, 23);
            this.buffSizeEdit.TabIndex = 0;
            this.buffSizeEdit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.buffSizeEdit_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Bounded Buffer Size : ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Equation 발생 횟수 : ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // equCountEdit
            // 
            this.equCountEdit.Location = new System.Drawing.Point(146, 60);
            this.equCountEdit.Name = "equCountEdit";
            this.equCountEdit.Size = new System.Drawing.Size(100, 23);
            this.equCountEdit.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(173, 101);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "확인";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // SettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(260, 136);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.equCountEdit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buffSizeEdit);
            this.Name = "SettingForm";
            this.Text = "SettingForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox equCountEdit;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox buffSizeEdit;
    }
}
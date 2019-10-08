namespace VKParanoid_2._0__test_
{
    partial class Autho
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
            this.access_token = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.receiving_token = new System.Windows.Forms.Button();
            this.authorization = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // access_token
            // 
            this.access_token.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.access_token.Location = new System.Drawing.Point(156, 31);
            this.access_token.Name = "access_token";
            this.access_token.Size = new System.Drawing.Size(971, 22);
            this.access_token.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Вставьте токен:";
            // 
            // receiving_token
            // 
            this.receiving_token.Location = new System.Drawing.Point(438, 59);
            this.receiving_token.Name = "receiving_token";
            this.receiving_token.Size = new System.Drawing.Size(138, 32);
            this.receiving_token.TabIndex = 2;
            this.receiving_token.Text = "Получить токен";
            this.receiving_token.UseVisualStyleBackColor = true;
            this.receiving_token.Click += new System.EventHandler(this.receiving_token_Click);
            // 
            // authorization
            // 
            this.authorization.Location = new System.Drawing.Point(582, 59);
            this.authorization.Name = "authorization";
            this.authorization.Size = new System.Drawing.Size(138, 32);
            this.authorization.TabIndex = 3;
            this.authorization.Text = "Войти";
            this.authorization.UseVisualStyleBackColor = true;
            this.authorization.Click += new System.EventHandler(this.authorization_Click);
            // 
            // Autho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1160, 113);
            this.Controls.Add(this.authorization);
            this.Controls.Add(this.receiving_token);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.access_token);
            this.Name = "Autho";
            this.Text = "VKParanoid 2.0 ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox access_token;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button receiving_token;
        private System.Windows.Forms.Button authorization;
    }
}


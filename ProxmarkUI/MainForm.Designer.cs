namespace ProxmarkUI
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
            this.buttonGetMACReader = new System.Windows.Forms.Button();
            this.textBoxResult = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxCSN = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxKey = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxCC = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxNR = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxDataForCRC = new System.Windows.Forms.TextBox();
            this.buttonGetCRC = new System.Windows.Forms.Button();
            this.buttonEncryptBlock = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxDataForEncrypt = new System.Windows.Forms.TextBox();
            this.buttonDecryptBlock = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxDivKey = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textBoxDataForMAC = new System.Windows.Forms.TextBox();
            this.buttonGetMAC = new System.Windows.Forms.Button();
            this.buttonGetMACTag = new System.Windows.Forms.Button();
            this.checkBoxOptimizeMAC = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonClearResultList = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonGetMACReader
            // 
            this.buttonGetMACReader.Location = new System.Drawing.Point(512, 29);
            this.buttonGetMACReader.Margin = new System.Windows.Forms.Padding(2);
            this.buttonGetMACReader.Name = "buttonGetMACReader";
            this.buttonGetMACReader.Size = new System.Drawing.Size(83, 23);
            this.buttonGetMACReader.TabIndex = 0;
            this.buttonGetMACReader.Text = "Get MAC Rdr";
            this.buttonGetMACReader.UseVisualStyleBackColor = true;
            this.buttonGetMACReader.Click += new System.EventHandler(this.buttonGetMACReader_Click);
            // 
            // textBoxResult
            // 
            this.textBoxResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxResult.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxResult.Location = new System.Drawing.Point(4, 289);
            this.textBoxResult.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxResult.Multiline = true;
            this.textBoxResult.Name = "textBoxResult";
            this.textBoxResult.Size = new System.Drawing.Size(614, 146);
            this.textBoxResult.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1, 274);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Result:";
            // 
            // textBoxCSN
            // 
            this.textBoxCSN.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxCSN.Location = new System.Drawing.Point(258, 31);
            this.textBoxCSN.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxCSN.MaxLength = 64;
            this.textBoxCSN.Name = "textBoxCSN";
            this.textBoxCSN.Size = new System.Drawing.Size(236, 22);
            this.textBoxCSN.TabIndex = 3;
            this.textBoxCSN.Text = "42721A00FBFF12E0";
            this.textBoxCSN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxHexNums_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(258, 16);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "CSN";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 16);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "KEY";
            // 
            // textBoxKey
            // 
            this.textBoxKey.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxKey.Location = new System.Drawing.Point(10, 31);
            this.textBoxKey.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxKey.MaxLength = 64;
            this.textBoxKey.Name = "textBoxKey";
            this.textBoxKey.Size = new System.Drawing.Size(236, 22);
            this.textBoxKey.TabIndex = 5;
            this.textBoxKey.Text = "FDCB5A52EA8F3090";
            this.textBoxKey.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxHexNums_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 55);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "CC";
            // 
            // textBoxCC
            // 
            this.textBoxCC.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxCC.Location = new System.Drawing.Point(9, 70);
            this.textBoxCC.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxCC.MaxLength = 64;
            this.textBoxCC.Name = "textBoxCC";
            this.textBoxCC.Size = new System.Drawing.Size(236, 22);
            this.textBoxCC.TabIndex = 7;
            this.textBoxCC.Text = "FFFFFFFF7FFFFFFF";
            this.textBoxCC.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxHexNums_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(258, 55);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(23, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "NR";
            // 
            // textBoxNR
            // 
            this.textBoxNR.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxNR.Location = new System.Drawing.Point(258, 70);
            this.textBoxNR.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxNR.MaxLength = 32;
            this.textBoxNR.Name = "textBoxNR";
            this.textBoxNR.Size = new System.Drawing.Size(236, 22);
            this.textBoxNR.TabIndex = 9;
            this.textBoxNR.Text = "00000000";
            this.textBoxNR.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxHexNums_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 55);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Data for CRC";
            // 
            // textBoxDataForCRC
            // 
            this.textBoxDataForCRC.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxDataForCRC.Location = new System.Drawing.Point(8, 71);
            this.textBoxDataForCRC.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxDataForCRC.MaxLength = 64;
            this.textBoxDataForCRC.Name = "textBoxDataForCRC";
            this.textBoxDataForCRC.Size = new System.Drawing.Size(486, 22);
            this.textBoxDataForCRC.TabIndex = 11;
            this.textBoxDataForCRC.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxHexNums_KeyPress);
            // 
            // buttonGetCRC
            // 
            this.buttonGetCRC.Location = new System.Drawing.Point(512, 69);
            this.buttonGetCRC.Name = "buttonGetCRC";
            this.buttonGetCRC.Size = new System.Drawing.Size(83, 23);
            this.buttonGetCRC.TabIndex = 13;
            this.buttonGetCRC.Text = "Get CRC";
            this.buttonGetCRC.UseVisualStyleBackColor = true;
            this.buttonGetCRC.Click += new System.EventHandler(this.buttonGetCRC_Click);
            // 
            // buttonEncryptBlock
            // 
            this.buttonEncryptBlock.Location = new System.Drawing.Point(411, 108);
            this.buttonEncryptBlock.Name = "buttonEncryptBlock";
            this.buttonEncryptBlock.Size = new System.Drawing.Size(83, 23);
            this.buttonEncryptBlock.TabIndex = 16;
            this.buttonEncryptBlock.Text = "Encrypt";
            this.buttonEncryptBlock.UseVisualStyleBackColor = true;
            this.buttonEncryptBlock.Click += new System.EventHandler(this.buttonEncryptBlock_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 95);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(123, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Data for encrypt/decrypt";
            // 
            // textBoxDataForEncrypt
            // 
            this.textBoxDataForEncrypt.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxDataForEncrypt.Location = new System.Drawing.Point(9, 110);
            this.textBoxDataForEncrypt.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxDataForEncrypt.MaxLength = 64;
            this.textBoxDataForEncrypt.Name = "textBoxDataForEncrypt";
            this.textBoxDataForEncrypt.Size = new System.Drawing.Size(387, 22);
            this.textBoxDataForEncrypt.TabIndex = 14;
            this.textBoxDataForEncrypt.Text = "629353EFEA7B05B8";
            this.textBoxDataForEncrypt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxHexNums_KeyPress);
            // 
            // buttonDecryptBlock
            // 
            this.buttonDecryptBlock.Location = new System.Drawing.Point(512, 108);
            this.buttonDecryptBlock.Name = "buttonDecryptBlock";
            this.buttonDecryptBlock.Size = new System.Drawing.Size(83, 23);
            this.buttonDecryptBlock.TabIndex = 17;
            this.buttonDecryptBlock.Text = "Decrypt";
            this.buttonDecryptBlock.UseVisualStyleBackColor = true;
            this.buttonDecryptBlock.Click += new System.EventHandler(this.buttonDecryptBlock_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(5, 16);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(71, 13);
            this.label10.TabIndex = 22;
            this.label10.Text = "Diversify KEY";
            // 
            // textBoxDivKey
            // 
            this.textBoxDivKey.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxDivKey.Location = new System.Drawing.Point(10, 31);
            this.textBoxDivKey.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxDivKey.MaxLength = 64;
            this.textBoxDivKey.Name = "textBoxDivKey";
            this.textBoxDivKey.Size = new System.Drawing.Size(235, 22);
            this.textBoxDivKey.TabIndex = 21;
            this.textBoxDivKey.Text = "77D463D2B32AD756";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(258, 16);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(71, 13);
            this.label11.TabIndex = 20;
            this.label11.Text = "Data for MAC";
            // 
            // textBoxDataForMAC
            // 
            this.textBoxDataForMAC.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxDataForMAC.Location = new System.Drawing.Point(258, 32);
            this.textBoxDataForMAC.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxDataForMAC.MaxLength = 64;
            this.textBoxDataForMAC.Name = "textBoxDataForMAC";
            this.textBoxDataForMAC.Size = new System.Drawing.Size(236, 22);
            this.textBoxDataForMAC.TabIndex = 19;
            this.textBoxDataForMAC.Text = "0000000000000000";
            // 
            // buttonGetMAC
            // 
            this.buttonGetMAC.Location = new System.Drawing.Point(512, 29);
            this.buttonGetMAC.Margin = new System.Windows.Forms.Padding(2);
            this.buttonGetMAC.Name = "buttonGetMAC";
            this.buttonGetMAC.Size = new System.Drawing.Size(83, 23);
            this.buttonGetMAC.TabIndex = 18;
            this.buttonGetMAC.Text = "Get MAC";
            this.buttonGetMAC.UseVisualStyleBackColor = true;
            this.buttonGetMAC.Click += new System.EventHandler(this.buttonGetMAC_Click);
            // 
            // buttonGetMACTag
            // 
            this.buttonGetMACTag.Location = new System.Drawing.Point(512, 68);
            this.buttonGetMACTag.Margin = new System.Windows.Forms.Padding(2);
            this.buttonGetMACTag.Name = "buttonGetMACTag";
            this.buttonGetMACTag.Size = new System.Drawing.Size(83, 23);
            this.buttonGetMACTag.TabIndex = 24;
            this.buttonGetMACTag.Text = "Get MAC Tag";
            this.buttonGetMACTag.UseVisualStyleBackColor = true;
            this.buttonGetMACTag.Click += new System.EventHandler(this.buttonGetMACTag_Click);
            // 
            // checkBoxOptimizeMAC
            // 
            this.checkBoxOptimizeMAC.AutoSize = true;
            this.checkBoxOptimizeMAC.Enabled = false;
            this.checkBoxOptimizeMAC.Location = new System.Drawing.Point(531, 8);
            this.checkBoxOptimizeMAC.Margin = new System.Windows.Forms.Padding(2);
            this.checkBoxOptimizeMAC.Name = "checkBoxOptimizeMAC";
            this.checkBoxOptimizeMAC.Size = new System.Drawing.Size(64, 17);
            this.checkBoxOptimizeMAC.TabIndex = 23;
            this.checkBoxOptimizeMAC.Text = "optimize";
            this.checkBoxOptimizeMAC.UseVisualStyleBackColor = true;
            this.checkBoxOptimizeMAC.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.buttonGetMACTag);
            this.groupBox1.Controls.Add(this.textBoxCSN);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBoxKey);
            this.groupBox1.Controls.Add(this.textBoxCC);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textBoxNR);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.buttonGetMACReader);
            this.groupBox1.Location = new System.Drawing.Point(4, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(604, 100);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Authentication";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.textBoxDivKey);
            this.groupBox2.Controls.Add(this.buttonDecryptBlock);
            this.groupBox2.Controls.Add(this.checkBoxOptimizeMAC);
            this.groupBox2.Controls.Add(this.buttonEncryptBlock);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.textBoxDataForEncrypt);
            this.groupBox2.Controls.Add(this.buttonGetMAC);
            this.groupBox2.Controls.Add(this.textBoxDataForMAC);
            this.groupBox2.Controls.Add(this.buttonGetCRC);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.textBoxDataForCRC);
            this.groupBox2.Location = new System.Drawing.Point(4, 109);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(604, 145);
            this.groupBox2.TabIndex = 26;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Calculation";
            // 
            // buttonClearResultList
            // 
            this.buttonClearResultList.Location = new System.Drawing.Point(516, 264);
            this.buttonClearResultList.Name = "buttonClearResultList";
            this.buttonClearResultList.Size = new System.Drawing.Size(83, 23);
            this.buttonClearResultList.TabIndex = 27;
            this.buttonClearResultList.Text = "Clear";
            this.buttonClearResultList.UseVisualStyleBackColor = true;
            this.buttonClearResultList.Click += new System.EventHandler(this.buttonClearResultList_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 442);
            this.Controls.Add(this.buttonClearResultList);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxResult);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainForm";
            this.Text = "Proxmark";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonGetMACReader;
        private System.Windows.Forms.TextBox textBoxResult;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxCSN;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxKey;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxCC;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxNR;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxDataForCRC;
        private System.Windows.Forms.Button buttonGetCRC;
        private System.Windows.Forms.Button buttonEncryptBlock;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxDataForEncrypt;
        private System.Windows.Forms.Button buttonDecryptBlock;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBoxDivKey;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBoxDataForMAC;
        private System.Windows.Forms.Button buttonGetMAC;
        private System.Windows.Forms.Button buttonGetMACTag;
        private System.Windows.Forms.CheckBox checkBoxOptimizeMAC;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonClearResultList;
    }
}


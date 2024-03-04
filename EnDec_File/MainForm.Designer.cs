namespace EnDec_File
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
            this.Panel_MainBtn = new System.Windows.Forms.Panel();
            this.LLbl_Version = new System.Windows.Forms.LinkLabel();
            this.Btn_AuthorInfo = new System.Windows.Forms.Button();
            this.CB_EncryptMethod = new System.Windows.Forms.ComboBox();
            this.Panel_СaesarMainBtn = new System.Windows.Forms.Panel();
            this.Btn_CaesarEncryptFile = new System.Windows.Forms.Button();
            this.Btn_CaesarDecryptFile = new System.Windows.Forms.Button();
            this.Btn_CaesarText = new System.Windows.Forms.Button();
            this.Panel_CaesarFileEncrypt = new System.Windows.Forms.Panel();
            this.Panel_CaesarSaveFileEnc = new System.Windows.Forms.Panel();
            this.Lbl_4 = new System.Windows.Forms.Label();
            this.TB_CaesarKeyEncrypt = new System.Windows.Forms.TextBox();
            this.TB_CaesarPathSaveFileEncrypt = new System.Windows.Forms.TextBox();
            this.Lbl_3 = new System.Windows.Forms.Label();
            this.Btn_SaveEncFile = new System.Windows.Forms.Button();
            this.Btn_CaesarCloseSaveFileEnc = new System.Windows.Forms.Button();
            this.Lbl_2 = new System.Windows.Forms.Label();
            this.Btn_CaesarOpenFileEnc = new System.Windows.Forms.Button();
            this.Lbl_0 = new System.Windows.Forms.Label();
            this.Lbl_1 = new System.Windows.Forms.Label();
            this.Panel_CaesarFileDecrypt = new System.Windows.Forms.Panel();
            this.Panel_CaesarSaveFileDec = new System.Windows.Forms.Panel();
            this.CheckBox_CaesarEnumerateAllCipher = new System.Windows.Forms.CheckBox();
            this.Lbl_9 = new System.Windows.Forms.Label();
            this.TB_CaesarKeyDecrypt = new System.Windows.Forms.TextBox();
            this.TB_CaesarPathSaveFileDecrypt = new System.Windows.Forms.TextBox();
            this.Lbl_8 = new System.Windows.Forms.Label();
            this.Btn_SaveDecFile = new System.Windows.Forms.Button();
            this.Btn_CaesarCloseSaveFileDec = new System.Windows.Forms.Button();
            this.Lbl_7 = new System.Windows.Forms.Label();
            this.Btn_CaesarOpenFileDec = new System.Windows.Forms.Button();
            this.Lbl_5 = new System.Windows.Forms.Label();
            this.Lbl_6 = new System.Windows.Forms.Label();
            this.Panel_MainBtn.SuspendLayout();
            this.Panel_СaesarMainBtn.SuspendLayout();
            this.Panel_CaesarFileEncrypt.SuspendLayout();
            this.Panel_CaesarSaveFileEnc.SuspendLayout();
            this.Panel_CaesarFileDecrypt.SuspendLayout();
            this.Panel_CaesarSaveFileDec.SuspendLayout();
            this.SuspendLayout();
            // 
            // Panel_MainBtn
            // 
            this.Panel_MainBtn.AutoSize = true;
            this.Panel_MainBtn.BackColor = System.Drawing.Color.LightSteelBlue;
            this.Panel_MainBtn.Controls.Add(this.LLbl_Version);
            this.Panel_MainBtn.Controls.Add(this.Btn_AuthorInfo);
            this.Panel_MainBtn.Controls.Add(this.CB_EncryptMethod);
            this.Panel_MainBtn.Controls.Add(this.Panel_СaesarMainBtn);
            this.Panel_MainBtn.Location = new System.Drawing.Point(0, 0);
            this.Panel_MainBtn.Margin = new System.Windows.Forms.Padding(2);
            this.Panel_MainBtn.Name = "Panel_MainBtn";
            this.Panel_MainBtn.Size = new System.Drawing.Size(170, 375);
            this.Panel_MainBtn.TabIndex = 1;
            // 
            // LLbl_Version
            // 
            this.LLbl_Version.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LLbl_Version.AutoSize = true;
            this.LLbl_Version.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LLbl_Version.Location = new System.Drawing.Point(2, 356);
            this.LLbl_Version.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LLbl_Version.Name = "LLbl_Version";
            this.LLbl_Version.Size = new System.Drawing.Size(164, 15);
            this.LLbl_Version.TabIndex = 20;
            this.LLbl_Version.TabStop = true;
            this.LLbl_Version.Text = "Version 1.0 (About the program)";
            this.LLbl_Version.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LLbl_Version_LinkClicked);
            // 
            // Btn_AuthorInfo
            // 
            this.Btn_AuthorInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Btn_AuthorInfo.BackColor = System.Drawing.SystemColors.Window;
            this.Btn_AuthorInfo.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Btn_AuthorInfo.Location = new System.Drawing.Point(4, 320);
            this.Btn_AuthorInfo.Margin = new System.Windows.Forms.Padding(2);
            this.Btn_AuthorInfo.Name = "Btn_AuthorInfo";
            this.Btn_AuthorInfo.Size = new System.Drawing.Size(161, 31);
            this.Btn_AuthorInfo.TabIndex = 4;
            this.Btn_AuthorInfo.Text = "AUTHOR INFO";
            this.Btn_AuthorInfo.UseVisualStyleBackColor = false;
            this.Btn_AuthorInfo.Click += new System.EventHandler(this.Btn_AuthorInfo_Click);
            // 
            // CB_EncryptMethod
            // 
            this.CB_EncryptMethod.BackColor = System.Drawing.Color.Red;
            this.CB_EncryptMethod.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.CB_EncryptMethod.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CB_EncryptMethod.FormattingEnabled = true;
            this.CB_EncryptMethod.Items.AddRange(new object[] {
            "Cesar cipher",
            "Trithemius cipher",
            "Gamma cipher",
            "DES cipher",
            "TripleDes cipher",
            "AES cipher"});
            this.CB_EncryptMethod.Location = new System.Drawing.Point(5, 10);
            this.CB_EncryptMethod.Margin = new System.Windows.Forms.Padding(2);
            this.CB_EncryptMethod.Name = "CB_EncryptMethod";
            this.CB_EncryptMethod.Size = new System.Drawing.Size(162, 20);
            this.CB_EncryptMethod.TabIndex = 2;
            this.CB_EncryptMethod.Text = "Cesar cipher";
            // 
            // Panel_СaesarMainBtn
            // 
            this.Panel_СaesarMainBtn.AutoScroll = true;
            this.Panel_СaesarMainBtn.BackColor = System.Drawing.Color.LightSteelBlue;
            this.Panel_СaesarMainBtn.Controls.Add(this.Btn_CaesarEncryptFile);
            this.Panel_СaesarMainBtn.Controls.Add(this.Btn_CaesarDecryptFile);
            this.Panel_СaesarMainBtn.Controls.Add(this.Btn_CaesarText);
            this.Panel_СaesarMainBtn.Location = new System.Drawing.Point(3, 39);
            this.Panel_СaesarMainBtn.Margin = new System.Windows.Forms.Padding(2);
            this.Panel_СaesarMainBtn.Name = "Panel_СaesarMainBtn";
            this.Panel_СaesarMainBtn.Size = new System.Drawing.Size(162, 268);
            this.Panel_СaesarMainBtn.TabIndex = 22;
            // 
            // Btn_CaesarEncryptFile
            // 
            this.Btn_CaesarEncryptFile.BackColor = System.Drawing.SystemColors.Window;
            this.Btn_CaesarEncryptFile.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Btn_CaesarEncryptFile.Location = new System.Drawing.Point(1, 1);
            this.Btn_CaesarEncryptFile.Margin = new System.Windows.Forms.Padding(2);
            this.Btn_CaesarEncryptFile.Name = "Btn_CaesarEncryptFile";
            this.Btn_CaesarEncryptFile.Size = new System.Drawing.Size(161, 31);
            this.Btn_CaesarEncryptFile.TabIndex = 0;
            this.Btn_CaesarEncryptFile.Text = "ENCRYPT FILE";
            this.Btn_CaesarEncryptFile.UseVisualStyleBackColor = false;
            this.Btn_CaesarEncryptFile.Click += new System.EventHandler(this.Btn_CaesarEncryptFile_Click);
            // 
            // Btn_CaesarDecryptFile
            // 
            this.Btn_CaesarDecryptFile.BackColor = System.Drawing.SystemColors.Window;
            this.Btn_CaesarDecryptFile.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Btn_CaesarDecryptFile.Location = new System.Drawing.Point(1, 33);
            this.Btn_CaesarDecryptFile.Margin = new System.Windows.Forms.Padding(2);
            this.Btn_CaesarDecryptFile.Name = "Btn_CaesarDecryptFile";
            this.Btn_CaesarDecryptFile.Size = new System.Drawing.Size(161, 31);
            this.Btn_CaesarDecryptFile.TabIndex = 3;
            this.Btn_CaesarDecryptFile.Text = "DECRYPT FILE";
            this.Btn_CaesarDecryptFile.UseVisualStyleBackColor = false;
            this.Btn_CaesarDecryptFile.Click += new System.EventHandler(this.Btn_CaesarDecryptFile_Click);
            // 
            // Btn_CaesarText
            // 
            this.Btn_CaesarText.BackColor = System.Drawing.Color.Red;
            this.Btn_CaesarText.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Btn_CaesarText.Location = new System.Drawing.Point(1, 65);
            this.Btn_CaesarText.Margin = new System.Windows.Forms.Padding(2);
            this.Btn_CaesarText.Name = "Btn_CaesarText";
            this.Btn_CaesarText.Size = new System.Drawing.Size(161, 31);
            this.Btn_CaesarText.TabIndex = 5;
            this.Btn_CaesarText.Text = "TEXT ENCRYPTION";
            this.Btn_CaesarText.UseVisualStyleBackColor = false;
            // 
            // Panel_CaesarFileEncrypt
            // 
            this.Panel_CaesarFileEncrypt.AllowDrop = true;
            this.Panel_CaesarFileEncrypt.AutoSize = true;
            this.Panel_CaesarFileEncrypt.BackColor = System.Drawing.Color.LightSteelBlue;
            this.Panel_CaesarFileEncrypt.Controls.Add(this.Panel_CaesarSaveFileEnc);
            this.Panel_CaesarFileEncrypt.Controls.Add(this.Btn_CaesarOpenFileEnc);
            this.Panel_CaesarFileEncrypt.Controls.Add(this.Lbl_0);
            this.Panel_CaesarFileEncrypt.Controls.Add(this.Lbl_1);
            this.Panel_CaesarFileEncrypt.Location = new System.Drawing.Point(176, 0);
            this.Panel_CaesarFileEncrypt.Margin = new System.Windows.Forms.Padding(2);
            this.Panel_CaesarFileEncrypt.Name = "Panel_CaesarFileEncrypt";
            this.Panel_CaesarFileEncrypt.Size = new System.Drawing.Size(565, 375);
            this.Panel_CaesarFileEncrypt.TabIndex = 2;
            this.Panel_CaesarFileEncrypt.DragDrop += new System.Windows.Forms.DragEventHandler(this.Panel_CaesarFileEncrypt_DragDrop);
            this.Panel_CaesarFileEncrypt.DragEnter += new System.Windows.Forms.DragEventHandler(this.Panel_CaesarFileEncrypt_DragEnter);
            // 
            // Panel_CaesarSaveFileEnc
            // 
            this.Panel_CaesarSaveFileEnc.AllowDrop = true;
            this.Panel_CaesarSaveFileEnc.AutoSize = true;
            this.Panel_CaesarSaveFileEnc.BackColor = System.Drawing.Color.Lavender;
            this.Panel_CaesarSaveFileEnc.Controls.Add(this.Lbl_4);
            this.Panel_CaesarSaveFileEnc.Controls.Add(this.TB_CaesarKeyEncrypt);
            this.Panel_CaesarSaveFileEnc.Controls.Add(this.TB_CaesarPathSaveFileEncrypt);
            this.Panel_CaesarSaveFileEnc.Controls.Add(this.Lbl_3);
            this.Panel_CaesarSaveFileEnc.Controls.Add(this.Btn_SaveEncFile);
            this.Panel_CaesarSaveFileEnc.Controls.Add(this.Btn_CaesarCloseSaveFileEnc);
            this.Panel_CaesarSaveFileEnc.Controls.Add(this.Lbl_2);
            this.Panel_CaesarSaveFileEnc.Enabled = false;
            this.Panel_CaesarSaveFileEnc.Location = new System.Drawing.Point(176, 88);
            this.Panel_CaesarSaveFileEnc.Margin = new System.Windows.Forms.Padding(2);
            this.Panel_CaesarSaveFileEnc.Name = "Panel_CaesarSaveFileEnc";
            this.Panel_CaesarSaveFileEnc.Size = new System.Drawing.Size(216, 140);
            this.Panel_CaesarSaveFileEnc.TabIndex = 24;
            this.Panel_CaesarSaveFileEnc.Visible = false;
            // 
            // Lbl_4
            // 
            this.Lbl_4.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Lbl_4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Lbl_4.Location = new System.Drawing.Point(4, 81);
            this.Lbl_4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Lbl_4.Name = "Lbl_4";
            this.Lbl_4.Size = new System.Drawing.Size(44, 18);
            this.Lbl_4.TabIndex = 73;
            this.Lbl_4.Text = "Path:";
            this.Lbl_4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TB_CaesarKeyEncrypt
            // 
            this.TB_CaesarKeyEncrypt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TB_CaesarKeyEncrypt.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TB_CaesarKeyEncrypt.Location = new System.Drawing.Point(50, 52);
            this.TB_CaesarKeyEncrypt.Margin = new System.Windows.Forms.Padding(2);
            this.TB_CaesarKeyEncrypt.Name = "TB_CaesarKeyEncrypt";
            this.TB_CaesarKeyEncrypt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TB_CaesarKeyEncrypt.Size = new System.Drawing.Size(160, 20);
            this.TB_CaesarKeyEncrypt.TabIndex = 72;
            // 
            // TB_CaesarPathSaveFileEncrypt
            // 
            this.TB_CaesarPathSaveFileEncrypt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TB_CaesarPathSaveFileEncrypt.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TB_CaesarPathSaveFileEncrypt.Location = new System.Drawing.Point(50, 80);
            this.TB_CaesarPathSaveFileEncrypt.Margin = new System.Windows.Forms.Padding(2);
            this.TB_CaesarPathSaveFileEncrypt.Name = "TB_CaesarPathSaveFileEncrypt";
            this.TB_CaesarPathSaveFileEncrypt.ReadOnly = true;
            this.TB_CaesarPathSaveFileEncrypt.Size = new System.Drawing.Size(160, 20);
            this.TB_CaesarPathSaveFileEncrypt.TabIndex = 69;
            // 
            // Lbl_3
            // 
            this.Lbl_3.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Lbl_3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Lbl_3.Location = new System.Drawing.Point(4, 51);
            this.Lbl_3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Lbl_3.Name = "Lbl_3";
            this.Lbl_3.Size = new System.Drawing.Size(44, 18);
            this.Lbl_3.TabIndex = 65;
            this.Lbl_3.Text = "Key:";
            this.Lbl_3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Btn_SaveEncFile
            // 
            this.Btn_SaveEncFile.BackColor = System.Drawing.SystemColors.Window;
            this.Btn_SaveEncFile.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Btn_SaveEncFile.Location = new System.Drawing.Point(7, 110);
            this.Btn_SaveEncFile.Margin = new System.Windows.Forms.Padding(2);
            this.Btn_SaveEncFile.Name = "Btn_SaveEncFile";
            this.Btn_SaveEncFile.Size = new System.Drawing.Size(202, 20);
            this.Btn_SaveEncFile.TabIndex = 22;
            this.Btn_SaveEncFile.Text = "SAVE ENCRYPT FILE";
            this.Btn_SaveEncFile.UseVisualStyleBackColor = false;
            this.Btn_SaveEncFile.Click += new System.EventHandler(this.Btn_SaveEncFile_Click);
            // 
            // Btn_CaesarCloseSaveFileEnc
            // 
            this.Btn_CaesarCloseSaveFileEnc.BackColor = System.Drawing.SystemColors.Window;
            this.Btn_CaesarCloseSaveFileEnc.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Btn_CaesarCloseSaveFileEnc.Location = new System.Drawing.Point(192, 2);
            this.Btn_CaesarCloseSaveFileEnc.Margin = new System.Windows.Forms.Padding(2);
            this.Btn_CaesarCloseSaveFileEnc.Name = "Btn_CaesarCloseSaveFileEnc";
            this.Btn_CaesarCloseSaveFileEnc.Size = new System.Drawing.Size(22, 20);
            this.Btn_CaesarCloseSaveFileEnc.TabIndex = 21;
            this.Btn_CaesarCloseSaveFileEnc.Text = "X";
            this.Btn_CaesarCloseSaveFileEnc.UseVisualStyleBackColor = false;
            this.Btn_CaesarCloseSaveFileEnc.Click += new System.EventHandler(this.Btn_CaesarCloseSaveFileEnc_Click);
            // 
            // Lbl_2
            // 
            this.Lbl_2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Lbl_2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Lbl_2.Location = new System.Drawing.Point(2, 4);
            this.Lbl_2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Lbl_2.Name = "Lbl_2";
            this.Lbl_2.Size = new System.Drawing.Size(210, 42);
            this.Lbl_2.TabIndex = 66;
            this.Lbl_2.Text = "CAESAR CIPHER\r\nSAVE ENCRYPT FILE";
            this.Lbl_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Btn_CaesarOpenFileEnc
            // 
            this.Btn_CaesarOpenFileEnc.BackColor = System.Drawing.SystemColors.Window;
            this.Btn_CaesarOpenFileEnc.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Btn_CaesarOpenFileEnc.Location = new System.Drawing.Point(200, 288);
            this.Btn_CaesarOpenFileEnc.Margin = new System.Windows.Forms.Padding(2);
            this.Btn_CaesarOpenFileEnc.Name = "Btn_CaesarOpenFileEnc";
            this.Btn_CaesarOpenFileEnc.Size = new System.Drawing.Size(161, 31);
            this.Btn_CaesarOpenFileEnc.TabIndex = 23;
            this.Btn_CaesarOpenFileEnc.Text = "Open the file in Explorer...";
            this.Btn_CaesarOpenFileEnc.UseVisualStyleBackColor = false;
            this.Btn_CaesarOpenFileEnc.Click += new System.EventHandler(this.Btn_CaesarOpenFileEnc_Click);
            // 
            // Lbl_0
            // 
            this.Lbl_0.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Lbl_0.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Lbl_0.Location = new System.Drawing.Point(92, 96);
            this.Lbl_0.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Lbl_0.Name = "Lbl_0";
            this.Lbl_0.Size = new System.Drawing.Size(387, 69);
            this.Lbl_0.TabIndex = 1;
            this.Lbl_0.Text = "CAESAR CIPHER";
            this.Lbl_0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Lbl_1
            // 
            this.Lbl_1.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Lbl_1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Lbl_1.Location = new System.Drawing.Point(92, 160);
            this.Lbl_1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Lbl_1.Name = "Lbl_1";
            this.Lbl_1.Size = new System.Drawing.Size(387, 69);
            this.Lbl_1.TabIndex = 0;
            this.Lbl_1.Text = "Drag a file of any format into this window to encrypt it";
            this.Lbl_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Panel_CaesarFileDecrypt
            // 
            this.Panel_CaesarFileDecrypt.AllowDrop = true;
            this.Panel_CaesarFileDecrypt.AutoSize = true;
            this.Panel_CaesarFileDecrypt.BackColor = System.Drawing.Color.LightSteelBlue;
            this.Panel_CaesarFileDecrypt.Controls.Add(this.Panel_CaesarSaveFileDec);
            this.Panel_CaesarFileDecrypt.Controls.Add(this.Btn_CaesarOpenFileDec);
            this.Panel_CaesarFileDecrypt.Controls.Add(this.Lbl_5);
            this.Panel_CaesarFileDecrypt.Controls.Add(this.Lbl_6);
            this.Panel_CaesarFileDecrypt.Enabled = false;
            this.Panel_CaesarFileDecrypt.Location = new System.Drawing.Point(176, 0);
            this.Panel_CaesarFileDecrypt.Margin = new System.Windows.Forms.Padding(2);
            this.Panel_CaesarFileDecrypt.Name = "Panel_CaesarFileDecrypt";
            this.Panel_CaesarFileDecrypt.Size = new System.Drawing.Size(565, 375);
            this.Panel_CaesarFileDecrypt.TabIndex = 3;
            this.Panel_CaesarFileDecrypt.Visible = false;
            this.Panel_CaesarFileDecrypt.DragDrop += new System.Windows.Forms.DragEventHandler(this.Panel_CaesarFileDecrypt_DragDrop);
            this.Panel_CaesarFileDecrypt.DragEnter += new System.Windows.Forms.DragEventHandler(this.Panel_CaesarFileDecrypt_DragEnter);
            // 
            // Panel_CaesarSaveFileDec
            // 
            this.Panel_CaesarSaveFileDec.AllowDrop = true;
            this.Panel_CaesarSaveFileDec.AutoSize = true;
            this.Panel_CaesarSaveFileDec.BackColor = System.Drawing.Color.Lavender;
            this.Panel_CaesarSaveFileDec.Controls.Add(this.CheckBox_CaesarEnumerateAllCipher);
            this.Panel_CaesarSaveFileDec.Controls.Add(this.Lbl_9);
            this.Panel_CaesarSaveFileDec.Controls.Add(this.TB_CaesarKeyDecrypt);
            this.Panel_CaesarSaveFileDec.Controls.Add(this.TB_CaesarPathSaveFileDecrypt);
            this.Panel_CaesarSaveFileDec.Controls.Add(this.Lbl_8);
            this.Panel_CaesarSaveFileDec.Controls.Add(this.Btn_SaveDecFile);
            this.Panel_CaesarSaveFileDec.Controls.Add(this.Btn_CaesarCloseSaveFileDec);
            this.Panel_CaesarSaveFileDec.Controls.Add(this.Lbl_7);
            this.Panel_CaesarSaveFileDec.Enabled = false;
            this.Panel_CaesarSaveFileDec.Location = new System.Drawing.Point(176, 88);
            this.Panel_CaesarSaveFileDec.Margin = new System.Windows.Forms.Padding(2);
            this.Panel_CaesarSaveFileDec.Name = "Panel_CaesarSaveFileDec";
            this.Panel_CaesarSaveFileDec.Size = new System.Drawing.Size(216, 152);
            this.Panel_CaesarSaveFileDec.TabIndex = 25;
            this.Panel_CaesarSaveFileDec.Visible = false;
            // 
            // CheckBox_CaesarEnumerateAllCipher
            // 
            this.CheckBox_CaesarEnumerateAllCipher.AutoSize = true;
            this.CheckBox_CaesarEnumerateAllCipher.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CheckBox_CaesarEnumerateAllCipher.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.CheckBox_CaesarEnumerateAllCipher.Location = new System.Drawing.Point(8, 75);
            this.CheckBox_CaesarEnumerateAllCipher.Name = "CheckBox_CaesarEnumerateAllCipher";
            this.CheckBox_CaesarEnumerateAllCipher.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.CheckBox_CaesarEnumerateAllCipher.Size = new System.Drawing.Size(202, 18);
            this.CheckBox_CaesarEnumerateAllCipher.TabIndex = 74;
            this.CheckBox_CaesarEnumerateAllCipher.Text = "Enumerate all variants of ciphergrams";
            this.CheckBox_CaesarEnumerateAllCipher.UseVisualStyleBackColor = true;
            this.CheckBox_CaesarEnumerateAllCipher.CheckedChanged += new System.EventHandler(this.CheckBox_CaesarEnumerateAllCipher_CheckedChanged);
            // 
            // Lbl_9
            // 
            this.Lbl_9.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Lbl_9.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Lbl_9.Location = new System.Drawing.Point(4, 98);
            this.Lbl_9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Lbl_9.Name = "Lbl_9";
            this.Lbl_9.Size = new System.Drawing.Size(44, 18);
            this.Lbl_9.TabIndex = 73;
            this.Lbl_9.Text = "Path:";
            this.Lbl_9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TB_CaesarKeyDecrypt
            // 
            this.TB_CaesarKeyDecrypt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TB_CaesarKeyDecrypt.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TB_CaesarKeyDecrypt.Location = new System.Drawing.Point(50, 52);
            this.TB_CaesarKeyDecrypt.Margin = new System.Windows.Forms.Padding(2);
            this.TB_CaesarKeyDecrypt.Name = "TB_CaesarKeyDecrypt";
            this.TB_CaesarKeyDecrypt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TB_CaesarKeyDecrypt.Size = new System.Drawing.Size(160, 20);
            this.TB_CaesarKeyDecrypt.TabIndex = 72;
            // 
            // TB_CaesarPathSaveFileDecrypt
            // 
            this.TB_CaesarPathSaveFileDecrypt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TB_CaesarPathSaveFileDecrypt.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TB_CaesarPathSaveFileDecrypt.Location = new System.Drawing.Point(50, 97);
            this.TB_CaesarPathSaveFileDecrypt.Margin = new System.Windows.Forms.Padding(2);
            this.TB_CaesarPathSaveFileDecrypt.Name = "TB_CaesarPathSaveFileDecrypt";
            this.TB_CaesarPathSaveFileDecrypt.ReadOnly = true;
            this.TB_CaesarPathSaveFileDecrypt.Size = new System.Drawing.Size(160, 20);
            this.TB_CaesarPathSaveFileDecrypt.TabIndex = 69;
            // 
            // Lbl_8
            // 
            this.Lbl_8.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Lbl_8.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Lbl_8.Location = new System.Drawing.Point(4, 51);
            this.Lbl_8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Lbl_8.Name = "Lbl_8";
            this.Lbl_8.Size = new System.Drawing.Size(44, 18);
            this.Lbl_8.TabIndex = 65;
            this.Lbl_8.Text = "Key:";
            this.Lbl_8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Btn_SaveDecFile
            // 
            this.Btn_SaveDecFile.BackColor = System.Drawing.SystemColors.Window;
            this.Btn_SaveDecFile.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Btn_SaveDecFile.Location = new System.Drawing.Point(7, 123);
            this.Btn_SaveDecFile.Margin = new System.Windows.Forms.Padding(2);
            this.Btn_SaveDecFile.Name = "Btn_SaveDecFile";
            this.Btn_SaveDecFile.Size = new System.Drawing.Size(202, 20);
            this.Btn_SaveDecFile.TabIndex = 22;
            this.Btn_SaveDecFile.Text = "SAVE DECRYPT FILE";
            this.Btn_SaveDecFile.UseVisualStyleBackColor = false;
            this.Btn_SaveDecFile.Click += new System.EventHandler(this.Btn_SaveDecFile_Click);
            // 
            // Btn_CaesarCloseSaveFileDec
            // 
            this.Btn_CaesarCloseSaveFileDec.BackColor = System.Drawing.SystemColors.Window;
            this.Btn_CaesarCloseSaveFileDec.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Btn_CaesarCloseSaveFileDec.Location = new System.Drawing.Point(192, 2);
            this.Btn_CaesarCloseSaveFileDec.Margin = new System.Windows.Forms.Padding(2);
            this.Btn_CaesarCloseSaveFileDec.Name = "Btn_CaesarCloseSaveFileDec";
            this.Btn_CaesarCloseSaveFileDec.Size = new System.Drawing.Size(22, 20);
            this.Btn_CaesarCloseSaveFileDec.TabIndex = 21;
            this.Btn_CaesarCloseSaveFileDec.Text = "X";
            this.Btn_CaesarCloseSaveFileDec.UseVisualStyleBackColor = false;
            this.Btn_CaesarCloseSaveFileDec.Click += new System.EventHandler(this.Btn_CaesarCloseSaveFileDec_Click);
            // 
            // Lbl_7
            // 
            this.Lbl_7.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Lbl_7.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Lbl_7.Location = new System.Drawing.Point(2, 4);
            this.Lbl_7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Lbl_7.Name = "Lbl_7";
            this.Lbl_7.Size = new System.Drawing.Size(210, 42);
            this.Lbl_7.TabIndex = 66;
            this.Lbl_7.Text = "CAESAR CIPHER\r\nSAVE DECRYPT FILE";
            this.Lbl_7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Btn_CaesarOpenFileDec
            // 
            this.Btn_CaesarOpenFileDec.BackColor = System.Drawing.SystemColors.Window;
            this.Btn_CaesarOpenFileDec.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Btn_CaesarOpenFileDec.Location = new System.Drawing.Point(200, 288);
            this.Btn_CaesarOpenFileDec.Margin = new System.Windows.Forms.Padding(2);
            this.Btn_CaesarOpenFileDec.Name = "Btn_CaesarOpenFileDec";
            this.Btn_CaesarOpenFileDec.Size = new System.Drawing.Size(161, 31);
            this.Btn_CaesarOpenFileDec.TabIndex = 22;
            this.Btn_CaesarOpenFileDec.Text = "Open the file in Explorer...";
            this.Btn_CaesarOpenFileDec.UseVisualStyleBackColor = false;
            this.Btn_CaesarOpenFileDec.Click += new System.EventHandler(this.Btn_CaesarOpenFileDec_Click);
            // 
            // Lbl_5
            // 
            this.Lbl_5.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Lbl_5.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Lbl_5.Location = new System.Drawing.Point(92, 96);
            this.Lbl_5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Lbl_5.Name = "Lbl_5";
            this.Lbl_5.Size = new System.Drawing.Size(387, 69);
            this.Lbl_5.TabIndex = 1;
            this.Lbl_5.Text = "CAESAR CIPHER";
            this.Lbl_5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Lbl_6
            // 
            this.Lbl_6.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Lbl_6.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Lbl_6.Location = new System.Drawing.Point(92, 160);
            this.Lbl_6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Lbl_6.Name = "Lbl_6";
            this.Lbl_6.Size = new System.Drawing.Size(387, 69);
            this.Lbl_6.TabIndex = 0;
            this.Lbl_6.Text = "Drag the encrypted file into this window to decrypt it.";
            this.Lbl_6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(738, 374);
            this.Controls.Add(this.Panel_MainBtn);
            this.Controls.Add(this.Panel_CaesarFileDecrypt);
            this.Controls.Add(this.Panel_CaesarFileEncrypt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(754, 413);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EnDec File";
            this.Panel_MainBtn.ResumeLayout(false);
            this.Panel_MainBtn.PerformLayout();
            this.Panel_СaesarMainBtn.ResumeLayout(false);
            this.Panel_CaesarFileEncrypt.ResumeLayout(false);
            this.Panel_CaesarFileEncrypt.PerformLayout();
            this.Panel_CaesarSaveFileEnc.ResumeLayout(false);
            this.Panel_CaesarSaveFileEnc.PerformLayout();
            this.Panel_CaesarFileDecrypt.ResumeLayout(false);
            this.Panel_CaesarFileDecrypt.PerformLayout();
            this.Panel_CaesarSaveFileDec.ResumeLayout(false);
            this.Panel_CaesarSaveFileDec.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel Panel_MainBtn;
        private System.Windows.Forms.LinkLabel LLbl_Version;
        private System.Windows.Forms.Button Btn_AuthorInfo;
        private System.Windows.Forms.ComboBox CB_EncryptMethod;
        private System.Windows.Forms.Panel Panel_СaesarMainBtn;
        private System.Windows.Forms.Button Btn_CaesarEncryptFile;
        private System.Windows.Forms.Button Btn_CaesarDecryptFile;
        private System.Windows.Forms.Button Btn_CaesarText;
        private System.Windows.Forms.Panel Panel_CaesarFileEncrypt;
        private System.Windows.Forms.Panel Panel_CaesarSaveFileEnc;
        private System.Windows.Forms.Label Lbl_4;
        private System.Windows.Forms.TextBox TB_CaesarKeyEncrypt;
        private System.Windows.Forms.TextBox TB_CaesarPathSaveFileEncrypt;
        private System.Windows.Forms.Label Lbl_3;
        private System.Windows.Forms.Button Btn_SaveEncFile;
        private System.Windows.Forms.Button Btn_CaesarCloseSaveFileEnc;
        private System.Windows.Forms.Label Lbl_2;
        private System.Windows.Forms.Button Btn_CaesarOpenFileEnc;
        private System.Windows.Forms.Label Lbl_0;
        private System.Windows.Forms.Label Lbl_1;
        private System.Windows.Forms.Panel Panel_CaesarFileDecrypt;
        private System.Windows.Forms.Panel Panel_CaesarSaveFileDec;
        private System.Windows.Forms.CheckBox CheckBox_CaesarEnumerateAllCipher;
        private System.Windows.Forms.Label Lbl_9;
        private System.Windows.Forms.TextBox TB_CaesarKeyDecrypt;
        private System.Windows.Forms.TextBox TB_CaesarPathSaveFileDecrypt;
        private System.Windows.Forms.Label Lbl_8;
        private System.Windows.Forms.Button Btn_SaveDecFile;
        private System.Windows.Forms.Button Btn_CaesarCloseSaveFileDec;
        private System.Windows.Forms.Label Lbl_7;
        private System.Windows.Forms.Button Btn_CaesarOpenFileDec;
        private System.Windows.Forms.Label Lbl_5;
        private System.Windows.Forms.Label Lbl_6;
    }
}
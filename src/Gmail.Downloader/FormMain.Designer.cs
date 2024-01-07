using System.Drawing;
using System.Windows.Forms;

namespace Gmail.Downloader
{
    partial class FormMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnLogin = new Button();
            txtUserInfo = new TextBox();
            chkLabels = new CheckedListBox();
            grpLabels = new GroupBox();
            btnGetMessages = new Button();
            btnGetAttachments = new Button();
            chkMessages = new CheckedListBox();
            grpMessages = new GroupBox();
            tableLayoutPanel4 = new TableLayoutPanel();
            panel1 = new Panel();
            btnCheckAllMessages = new Button();
            btnUncheckAllMessages = new Button();
            progressBar = new ProgressBar();
            txtStatus = new TextBox();
            txtFilterQuery = new TextBox();
            grpFilterQuery = new GroupBox();
            btnGetLabels = new Button();
            dateTimePickerFrom = new DateTimePicker();
            dateTimePickerTo = new DateTimePicker();
            grpFrom = new GroupBox();
            grpTo = new GroupBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            grpLogin = new GroupBox();
            tableLayoutPanel2 = new TableLayoutPanel();
            splitContainer1 = new SplitContainer();
            tableLayoutPanel3 = new TableLayoutPanel();
            panel2 = new Panel();
            panel3 = new Panel();
            tableLayoutPanel5 = new TableLayoutPanel();
            grpLabels.SuspendLayout();
            grpMessages.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            panel1.SuspendLayout();
            grpFilterQuery.SuspendLayout();
            grpFrom.SuspendLayout();
            grpTo.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            grpLogin.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            tableLayoutPanel5.SuspendLayout();
            SuspendLayout();
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(3, 3);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(94, 50);
            btnLogin.TabIndex = 9;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // txtUserInfo
            // 
            txtUserInfo.Dock = DockStyle.Fill;
            txtUserInfo.Location = new Point(103, 3);
            txtUserInfo.Multiline = true;
            txtUserInfo.Name = "txtUserInfo";
            txtUserInfo.ReadOnly = true;
            txtUserInfo.Size = new Size(766, 66);
            txtUserInfo.TabIndex = 10;
            // 
            // chkLabels
            // 
            chkLabels.CheckOnClick = true;
            chkLabels.Dock = DockStyle.Fill;
            chkLabels.FormattingEnabled = true;
            chkLabels.Location = new Point(3, 19);
            chkLabels.Name = "chkLabels";
            chkLabels.Size = new Size(286, 533);
            chkLabels.TabIndex = 11;
            // 
            // grpLabels
            // 
            grpLabels.Controls.Add(chkLabels);
            grpLabels.Dock = DockStyle.Fill;
            grpLabels.Location = new Point(0, 0);
            grpLabels.Name = "grpLabels";
            grpLabels.Size = new Size(292, 555);
            grpLabels.TabIndex = 12;
            grpLabels.TabStop = false;
            grpLabels.Text = "Labels";
            // 
            // btnGetMessages
            // 
            btnGetMessages.Location = new Point(134, 3);
            btnGetMessages.Name = "btnGetMessages";
            btnGetMessages.Size = new Size(119, 33);
            btnGetMessages.TabIndex = 13;
            btnGetMessages.Text = "Get Messages";
            btnGetMessages.UseVisualStyleBackColor = true;
            btnGetMessages.Click += btnGetMessages_Click;
            // 
            // btnGetAttachments
            // 
            btnGetAttachments.Location = new Point(258, 3);
            btnGetAttachments.Name = "btnGetAttachments";
            btnGetAttachments.Size = new Size(119, 33);
            btnGetAttachments.TabIndex = 14;
            btnGetAttachments.Text = "Get Attachments";
            btnGetAttachments.UseVisualStyleBackColor = true;
            btnGetAttachments.Click += btnGetAttachments_Click;
            // 
            // chkMessages
            // 
            chkMessages.CheckOnClick = true;
            chkMessages.Dock = DockStyle.Fill;
            chkMessages.FormattingEnabled = true;
            chkMessages.Location = new Point(93, 3);
            chkMessages.Name = "chkMessages";
            chkMessages.Size = new Size(474, 356);
            chkMessages.TabIndex = 15;
            // 
            // grpMessages
            // 
            grpMessages.Controls.Add(tableLayoutPanel4);
            grpMessages.Dock = DockStyle.Fill;
            grpMessages.Location = new Point(3, 168);
            grpMessages.Name = "grpMessages";
            grpMessages.Size = new Size(576, 384);
            grpMessages.TabIndex = 16;
            grpMessages.TabStop = false;
            grpMessages.Text = "Messages";
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.ColumnCount = 2;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 90F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel4.Controls.Add(chkMessages, 1, 0);
            tableLayoutPanel4.Controls.Add(panel1, 0, 0);
            tableLayoutPanel4.Dock = DockStyle.Fill;
            tableLayoutPanel4.Location = new Point(3, 19);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 1;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel4.Size = new Size(570, 362);
            tableLayoutPanel4.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnCheckAllMessages);
            panel1.Controls.Add(btnUncheckAllMessages);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(84, 356);
            panel1.TabIndex = 16;
            // 
            // btnCheckAllMessages
            // 
            btnCheckAllMessages.Location = new Point(3, 3);
            btnCheckAllMessages.Name = "btnCheckAllMessages";
            btnCheckAllMessages.Size = new Size(71, 42);
            btnCheckAllMessages.TabIndex = 26;
            btnCheckAllMessages.Text = "Check All";
            btnCheckAllMessages.UseVisualStyleBackColor = true;
            btnCheckAllMessages.Click += btnCheckAllMessages_Click;
            // 
            // btnUncheckAllMessages
            // 
            btnUncheckAllMessages.Location = new Point(3, 63);
            btnUncheckAllMessages.Name = "btnUncheckAllMessages";
            btnUncheckAllMessages.Size = new Size(71, 42);
            btnUncheckAllMessages.TabIndex = 27;
            btnUncheckAllMessages.Text = "Uncheck All";
            btnUncheckAllMessages.UseVisualStyleBackColor = true;
            btnUncheckAllMessages.Click += btnUncheckAllMessages_Click;
            // 
            // progressBar
            // 
            progressBar.Dock = DockStyle.Fill;
            progressBar.Location = new Point(3, 3);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(872, 48);
            progressBar.TabIndex = 17;
            // 
            // txtStatus
            // 
            txtStatus.Dock = DockStyle.Fill;
            txtStatus.Location = new Point(3, 57);
            txtStatus.Name = "txtStatus";
            txtStatus.ReadOnly = true;
            txtStatus.Size = new Size(872, 23);
            txtStatus.TabIndex = 18;
            // 
            // txtFilterQuery
            // 
            txtFilterQuery.Dock = DockStyle.Fill;
            txtFilterQuery.Location = new Point(3, 19);
            txtFilterQuery.Name = "txtFilterQuery";
            txtFilterQuery.Size = new Size(570, 23);
            txtFilterQuery.TabIndex = 19;
            // 
            // grpFilterQuery
            // 
            grpFilterQuery.Controls.Add(txtFilterQuery);
            grpFilterQuery.Dock = DockStyle.Fill;
            grpFilterQuery.Location = new Point(3, 3);
            grpFilterQuery.Name = "grpFilterQuery";
            grpFilterQuery.Size = new Size(576, 49);
            grpFilterQuery.TabIndex = 20;
            grpFilterQuery.TabStop = false;
            grpFilterQuery.Text = "Filter Query";
            // 
            // btnGetLabels
            // 
            btnGetLabels.Location = new Point(9, 3);
            btnGetLabels.Name = "btnGetLabels";
            btnGetLabels.Size = new Size(119, 33);
            btnGetLabels.TabIndex = 21;
            btnGetLabels.Text = "Get Labels";
            btnGetLabels.UseVisualStyleBackColor = true;
            btnGetLabels.Click += btnGetLabels_Click;
            // 
            // dateTimePickerFrom
            // 
            dateTimePickerFrom.Dock = DockStyle.Fill;
            dateTimePickerFrom.Format = DateTimePickerFormat.Short;
            dateTimePickerFrom.Location = new Point(3, 19);
            dateTimePickerFrom.Name = "dateTimePickerFrom";
            dateTimePickerFrom.Size = new Size(105, 23);
            dateTimePickerFrom.TabIndex = 22;
            // 
            // dateTimePickerTo
            // 
            dateTimePickerTo.Dock = DockStyle.Fill;
            dateTimePickerTo.Format = DateTimePickerFormat.Short;
            dateTimePickerTo.Location = new Point(3, 19);
            dateTimePickerTo.Name = "dateTimePickerTo";
            dateTimePickerTo.Size = new Size(105, 23);
            dateTimePickerTo.TabIndex = 23;
            // 
            // grpFrom
            // 
            grpFrom.Controls.Add(dateTimePickerFrom);
            grpFrom.Location = new Point(3, 3);
            grpFrom.Name = "grpFrom";
            grpFrom.Size = new Size(111, 50);
            grpFrom.TabIndex = 24;
            grpFrom.TabStop = false;
            grpFrom.Text = "From";
            // 
            // grpTo
            // 
            grpTo.Controls.Add(dateTimePickerTo);
            grpTo.Location = new Point(134, 3);
            grpTo.Name = "grpTo";
            grpTo.Size = new Size(111, 50);
            grpTo.TabIndex = 25;
            grpTo.TabStop = false;
            grpTo.Text = "To";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Controls.Add(grpLogin, 0, 0);
            tableLayoutPanel1.Controls.Add(splitContainer1, 0, 1);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel5, 0, 2);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
            tableLayoutPanel1.Size = new Size(884, 761);
            tableLayoutPanel1.TabIndex = 28;
            // 
            // grpLogin
            // 
            grpLogin.Controls.Add(tableLayoutPanel2);
            grpLogin.Dock = DockStyle.Fill;
            grpLogin.Location = new Point(3, 3);
            grpLogin.Name = "grpLogin";
            grpLogin.Size = new Size(878, 94);
            grpLogin.TabIndex = 0;
            grpLogin.TabStop = false;
            grpLogin.Text = "Login";
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Controls.Add(btnLogin, 0, 0);
            tableLayoutPanel2.Controls.Add(txtUserInfo, 1, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 19);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(872, 72);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(3, 103);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(grpLabels);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(tableLayoutPanel3);
            splitContainer1.Size = new Size(878, 555);
            splitContainer1.SplitterDistance = 292;
            splitContainer1.TabIndex = 1;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 1;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Controls.Add(grpMessages, 0, 3);
            tableLayoutPanel3.Controls.Add(grpFilterQuery, 0, 0);
            tableLayoutPanel3.Controls.Add(panel2, 0, 1);
            tableLayoutPanel3.Controls.Add(panel3, 0, 2);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(0, 0);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 4;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 55F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Size = new Size(582, 555);
            tableLayoutPanel3.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Controls.Add(grpFrom);
            panel2.Controls.Add(grpTo);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(3, 58);
            panel2.Name = "panel2";
            panel2.Size = new Size(576, 54);
            panel2.TabIndex = 21;
            // 
            // panel3
            // 
            panel3.Controls.Add(btnGetLabels);
            panel3.Controls.Add(btnGetMessages);
            panel3.Controls.Add(btnGetAttachments);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(3, 118);
            panel3.Name = "panel3";
            panel3.Size = new Size(576, 44);
            panel3.TabIndex = 22;
            // 
            // tableLayoutPanel5
            // 
            tableLayoutPanel5.ColumnCount = 1;
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel5.Controls.Add(progressBar, 0, 0);
            tableLayoutPanel5.Controls.Add(txtStatus, 0, 1);
            tableLayoutPanel5.Dock = DockStyle.Fill;
            tableLayoutPanel5.Location = new Point(3, 664);
            tableLayoutPanel5.Name = "tableLayoutPanel5";
            tableLayoutPanel5.RowCount = 2;
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel5.Size = new Size(878, 94);
            tableLayoutPanel5.TabIndex = 2;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(884, 761);
            Controls.Add(tableLayoutPanel1);
            Name = "FormMain";
            Text = "GmailDownloader";
            grpLabels.ResumeLayout(false);
            grpMessages.ResumeLayout(false);
            tableLayoutPanel4.ResumeLayout(false);
            panel1.ResumeLayout(false);
            grpFilterQuery.ResumeLayout(false);
            grpFilterQuery.PerformLayout();
            grpFrom.ResumeLayout(false);
            grpTo.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            grpLogin.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            tableLayoutPanel5.ResumeLayout(false);
            tableLayoutPanel5.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Button btnLogin;
        private TextBox txtUserInfo;
        private CheckedListBox chkLabels;
        private GroupBox grpLabels;
        private Button btnGetMessages;
        private Button btnGetAttachments;
        private CheckedListBox chkMessages;
        private GroupBox grpMessages;
        private ProgressBar progressBar;
        private TextBox txtStatus;
        private TextBox txtFilterQuery;
        private GroupBox grpFilterQuery;
        private Button btnGetLabels;
        private DateTimePicker dateTimePickerFrom;
        private DateTimePicker dateTimePickerTo;
        private GroupBox grpFrom;
        private GroupBox grpTo;
        private Button btnCheckAllMessages;
        private Button btnUncheckAllMessages;
        private TableLayoutPanel tableLayoutPanel4;
        private Panel panel1;
        private TableLayoutPanel tableLayoutPanel1;
        private GroupBox grpLogin;
        private TableLayoutPanel tableLayoutPanel2;
        private SplitContainer splitContainer1;
        private TableLayoutPanel tableLayoutPanel3;
        private TableLayoutPanel tableLayoutPanel5;
        private Panel panel2;
        private Panel panel3;
    }
}

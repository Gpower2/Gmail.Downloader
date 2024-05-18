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
            tlpMessagesContent = new TableLayoutPanel();
            pnlMessageActions = new Panel();
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
            tlpMain = new TableLayoutPanel();
            grpLogin = new GroupBox();
            tlpLogin = new TableLayoutPanel();
            spltMain = new SplitContainer();
            tlpMessagesMain = new TableLayoutPanel();
            pnlFilters = new Panel();
            pnlActions = new Panel();
            tlpStatus = new TableLayoutPanel();
            grpLabels.SuspendLayout();
            grpMessages.SuspendLayout();
            tlpMessagesContent.SuspendLayout();
            pnlMessageActions.SuspendLayout();
            grpFilterQuery.SuspendLayout();
            grpFrom.SuspendLayout();
            grpTo.SuspendLayout();
            tlpMain.SuspendLayout();
            grpLogin.SuspendLayout();
            tlpLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)spltMain).BeginInit();
            spltMain.Panel1.SuspendLayout();
            spltMain.Panel2.SuspendLayout();
            spltMain.SuspendLayout();
            tlpMessagesMain.SuspendLayout();
            pnlFilters.SuspendLayout();
            pnlActions.SuspendLayout();
            tlpStatus.SuspendLayout();
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
            grpMessages.Controls.Add(tlpMessagesContent);
            grpMessages.Dock = DockStyle.Fill;
            grpMessages.Location = new Point(3, 168);
            grpMessages.Name = "grpMessages";
            grpMessages.Size = new Size(576, 384);
            grpMessages.TabIndex = 16;
            grpMessages.TabStop = false;
            grpMessages.Text = "Messages";
            // 
            // tlpMessagesContent
            // 
            tlpMessagesContent.ColumnCount = 2;
            tlpMessagesContent.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 90F));
            tlpMessagesContent.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpMessagesContent.Controls.Add(chkMessages, 1, 0);
            tlpMessagesContent.Controls.Add(pnlMessageActions, 0, 0);
            tlpMessagesContent.Dock = DockStyle.Fill;
            tlpMessagesContent.Location = new Point(3, 19);
            tlpMessagesContent.Name = "tlpMessagesContent";
            tlpMessagesContent.RowCount = 1;
            tlpMessagesContent.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpMessagesContent.Size = new Size(570, 362);
            tlpMessagesContent.TabIndex = 0;
            // 
            // pnlMessageActions
            // 
            pnlMessageActions.Controls.Add(btnCheckAllMessages);
            pnlMessageActions.Controls.Add(btnUncheckAllMessages);
            pnlMessageActions.Dock = DockStyle.Fill;
            pnlMessageActions.Location = new Point(3, 3);
            pnlMessageActions.Name = "pnlMessageActions";
            pnlMessageActions.Size = new Size(84, 356);
            pnlMessageActions.TabIndex = 16;
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
            // tlpMain
            // 
            tlpMain.ColumnCount = 1;
            tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tlpMain.Controls.Add(grpLogin, 0, 0);
            tlpMain.Controls.Add(spltMain, 0, 1);
            tlpMain.Controls.Add(tlpStatus, 0, 2);
            tlpMain.Dock = DockStyle.Fill;
            tlpMain.Location = new Point(0, 0);
            tlpMain.Name = "tlpMain";
            tlpMain.RowCount = 3;
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
            tlpMain.Size = new Size(884, 761);
            tlpMain.TabIndex = 28;
            // 
            // grpLogin
            // 
            grpLogin.Controls.Add(tlpLogin);
            grpLogin.Dock = DockStyle.Fill;
            grpLogin.Location = new Point(3, 3);
            grpLogin.Name = "grpLogin";
            grpLogin.Size = new Size(878, 94);
            grpLogin.TabIndex = 0;
            grpLogin.TabStop = false;
            grpLogin.Text = "Login";
            // 
            // tlpLogin
            // 
            tlpLogin.ColumnCount = 2;
            tlpLogin.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
            tlpLogin.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpLogin.Controls.Add(btnLogin, 0, 0);
            tlpLogin.Controls.Add(txtUserInfo, 1, 0);
            tlpLogin.Dock = DockStyle.Fill;
            tlpLogin.Location = new Point(3, 19);
            tlpLogin.Name = "tlpLogin";
            tlpLogin.RowCount = 1;
            tlpLogin.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpLogin.Size = new Size(872, 72);
            tlpLogin.TabIndex = 0;
            // 
            // spltMain
            // 
            spltMain.Dock = DockStyle.Fill;
            spltMain.Location = new Point(3, 103);
            spltMain.Name = "spltMain";
            // 
            // spltMain.Panel1
            // 
            spltMain.Panel1.Controls.Add(grpLabels);
            // 
            // spltMain.Panel2
            // 
            spltMain.Panel2.Controls.Add(tlpMessagesMain);
            spltMain.Size = new Size(878, 555);
            spltMain.SplitterDistance = 292;
            spltMain.TabIndex = 1;
            // 
            // tlpMessagesMain
            // 
            tlpMessagesMain.ColumnCount = 1;
            tlpMessagesMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpMessagesMain.Controls.Add(grpMessages, 0, 3);
            tlpMessagesMain.Controls.Add(grpFilterQuery, 0, 0);
            tlpMessagesMain.Controls.Add(pnlFilters, 0, 1);
            tlpMessagesMain.Controls.Add(pnlActions, 0, 2);
            tlpMessagesMain.Dock = DockStyle.Fill;
            tlpMessagesMain.Location = new Point(0, 0);
            tlpMessagesMain.Name = "tlpMessagesMain";
            tlpMessagesMain.RowCount = 4;
            tlpMessagesMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 55F));
            tlpMessagesMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            tlpMessagesMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tlpMessagesMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpMessagesMain.Size = new Size(582, 555);
            tlpMessagesMain.TabIndex = 0;
            // 
            // pnlFilters
            // 
            pnlFilters.Controls.Add(grpFrom);
            pnlFilters.Controls.Add(grpTo);
            pnlFilters.Dock = DockStyle.Fill;
            pnlFilters.Location = new Point(3, 58);
            pnlFilters.Name = "pnlFilters";
            pnlFilters.Size = new Size(576, 54);
            pnlFilters.TabIndex = 21;
            // 
            // pnlActions
            // 
            pnlActions.Controls.Add(btnGetLabels);
            pnlActions.Controls.Add(btnGetMessages);
            pnlActions.Controls.Add(btnGetAttachments);
            pnlActions.Dock = DockStyle.Fill;
            pnlActions.Location = new Point(3, 118);
            pnlActions.Name = "pnlActions";
            pnlActions.Size = new Size(576, 44);
            pnlActions.TabIndex = 22;
            // 
            // tlpStatus
            // 
            tlpStatus.ColumnCount = 1;
            tlpStatus.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpStatus.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tlpStatus.Controls.Add(progressBar, 0, 0);
            tlpStatus.Controls.Add(txtStatus, 0, 1);
            tlpStatus.Dock = DockStyle.Fill;
            tlpStatus.Location = new Point(3, 664);
            tlpStatus.Name = "tlpStatus";
            tlpStatus.RowCount = 2;
            tlpStatus.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpStatus.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tlpStatus.Size = new Size(878, 94);
            tlpStatus.TabIndex = 2;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(884, 761);
            Controls.Add(tlpMain);
            Name = "FormMain";
            Text = "GmailDownloader";
            grpLabels.ResumeLayout(false);
            grpMessages.ResumeLayout(false);
            tlpMessagesContent.ResumeLayout(false);
            pnlMessageActions.ResumeLayout(false);
            grpFilterQuery.ResumeLayout(false);
            grpFilterQuery.PerformLayout();
            grpFrom.ResumeLayout(false);
            grpTo.ResumeLayout(false);
            tlpMain.ResumeLayout(false);
            grpLogin.ResumeLayout(false);
            tlpLogin.ResumeLayout(false);
            tlpLogin.PerformLayout();
            spltMain.Panel1.ResumeLayout(false);
            spltMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)spltMain).EndInit();
            spltMain.ResumeLayout(false);
            tlpMessagesMain.ResumeLayout(false);
            pnlFilters.ResumeLayout(false);
            pnlActions.ResumeLayout(false);
            tlpStatus.ResumeLayout(false);
            tlpStatus.PerformLayout();
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
        private TableLayoutPanel tlpMessagesContent;
        private Panel pnlMessageActions;
        private TableLayoutPanel tlpMain;
        private GroupBox grpLogin;
        private TableLayoutPanel tlpLogin;
        private SplitContainer spltMain;
        private TableLayoutPanel tlpMessagesMain;
        private TableLayoutPanel tlpStatus;
        private Panel pnlFilters;
        private Panel pnlActions;
    }
}

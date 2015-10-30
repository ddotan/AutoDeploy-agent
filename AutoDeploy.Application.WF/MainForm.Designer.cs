namespace AutoDeploy.Application.WF
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
            this.components = new System.ComponentModel.Container();
            this.richTextBoxLog = new System.Windows.Forms.RichTextBox();
            this.buttonStop = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonStartAll = new System.Windows.Forms.Button();
            this.buttonStopAll = new System.Windows.Forms.Button();
            this.buttonRemoteConfig = new System.Windows.Forms.Button();
            this.buttonDeploy = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridViewAgents = new System.Windows.Forms.DataGridView();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.versionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serviceRunningDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.autoDeployAgentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.buttonDeployAll = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAgents)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.autoDeployAgentBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // richTextBoxLog
            // 
            this.richTextBoxLog.Location = new System.Drawing.Point(-1, 367);
            this.richTextBoxLog.Name = "richTextBoxLog";
            this.richTextBoxLog.Size = new System.Drawing.Size(345, 204);
            this.richTextBoxLog.TabIndex = 0;
            this.richTextBoxLog.Text = "";
            // 
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(12, 203);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(75, 23);
            this.buttonStop.TabIndex = 2;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.Location = new System.Drawing.Point(30, 156);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 31);
            this.label1.TabIndex = 3;
            this.label1.Text = "Services";
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(95, 203);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.TabIndex = 4;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonStartAll
            // 
            this.buttonStartAll.Location = new System.Drawing.Point(95, 243);
            this.buttonStartAll.Name = "buttonStartAll";
            this.buttonStartAll.Size = new System.Drawing.Size(75, 23);
            this.buttonStartAll.TabIndex = 5;
            this.buttonStartAll.Text = "Start All";
            this.buttonStartAll.UseVisualStyleBackColor = true;
            this.buttonStartAll.Click += new System.EventHandler(this.buttonStartAll_Click);
            // 
            // buttonStopAll
            // 
            this.buttonStopAll.Location = new System.Drawing.Point(14, 243);
            this.buttonStopAll.Name = "buttonStopAll";
            this.buttonStopAll.Size = new System.Drawing.Size(75, 23);
            this.buttonStopAll.TabIndex = 6;
            this.buttonStopAll.Text = "Stop All";
            this.buttonStopAll.UseVisualStyleBackColor = true;
            this.buttonStopAll.Click += new System.EventHandler(this.buttonStopAll_Click);
            // 
            // buttonRemoteConfig
            // 
            this.buttonRemoteConfig.Location = new System.Drawing.Point(197, 243);
            this.buttonRemoteConfig.Name = "buttonRemoteConfig";
            this.buttonRemoteConfig.Size = new System.Drawing.Size(124, 23);
            this.buttonRemoteConfig.TabIndex = 10;
            this.buttonRemoteConfig.Text = "Remote Configuration";
            this.buttonRemoteConfig.UseVisualStyleBackColor = true;
            this.buttonRemoteConfig.Click += new System.EventHandler(this.buttonRemoteConfig_Click);
            // 
            // buttonDeploy
            // 
            this.buttonDeploy.Location = new System.Drawing.Point(188, 203);
            this.buttonDeploy.Name = "buttonDeploy";
            this.buttonDeploy.Size = new System.Drawing.Size(75, 23);
            this.buttonDeploy.TabIndex = 9;
            this.buttonDeploy.Text = "Deploy";
            this.buttonDeploy.UseVisualStyleBackColor = true;
            this.buttonDeploy.Click += new System.EventHandler(this.buttonDeploy_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label2.Location = new System.Drawing.Point(173, 156);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(159, 31);
            this.label2.TabIndex = 8;
            this.label2.Text = "Deployment";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label3.Location = new System.Drawing.Point(100, 327);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(155, 37);
            this.label3.TabIndex = 11;
            this.label3.Text = "Reporting";
            // 
            // dataGridViewAgents
            // 
            this.dataGridViewAgents.AllowUserToAddRows = false;
            this.dataGridViewAgents.AllowUserToDeleteRows = false;
            this.dataGridViewAgents.AutoGenerateColumns = false;
            this.dataGridViewAgents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAgents.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn,
            this.versionDataGridViewTextBoxColumn,
            this.serviceRunningDataGridViewCheckBoxColumn});
            this.dataGridViewAgents.DataSource = this.autoDeployAgentBindingSource;
            this.dataGridViewAgents.Location = new System.Drawing.Point(-1, 0);
            this.dataGridViewAgents.Name = "dataGridViewAgents";
            this.dataGridViewAgents.ReadOnly = true;
            this.dataGridViewAgents.Size = new System.Drawing.Size(345, 150);
            this.dataGridViewAgents.TabIndex = 12;
            this.dataGridViewAgents.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewAgents_CellMouseClick);
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // versionDataGridViewTextBoxColumn
            // 
            this.versionDataGridViewTextBoxColumn.DataPropertyName = "Version";
            this.versionDataGridViewTextBoxColumn.HeaderText = "Version";
            this.versionDataGridViewTextBoxColumn.Name = "versionDataGridViewTextBoxColumn";
            this.versionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // serviceRunningDataGridViewCheckBoxColumn
            // 
            this.serviceRunningDataGridViewCheckBoxColumn.DataPropertyName = "ServiceRunning";
            this.serviceRunningDataGridViewCheckBoxColumn.HeaderText = "ServiceRunning";
            this.serviceRunningDataGridViewCheckBoxColumn.Name = "serviceRunningDataGridViewCheckBoxColumn";
            this.serviceRunningDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // autoDeployAgentBindingSource
            // 
            this.autoDeployAgentBindingSource.DataSource = typeof(AutoDeploy.Application.Objects.AutoDeployAgent);
            // 
            // buttonDeployAll
            // 
            this.buttonDeployAll.Location = new System.Drawing.Point(269, 203);
            this.buttonDeployAll.Name = "buttonDeployAll";
            this.buttonDeployAll.Size = new System.Drawing.Size(75, 23);
            this.buttonDeployAll.TabIndex = 13;
            this.buttonDeployAll.Text = "Deploy All";
            this.buttonDeployAll.UseVisualStyleBackColor = true;
            this.buttonDeployAll.Click += new System.EventHandler(this.buttonDeployAll_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 573);
            this.Controls.Add(this.buttonDeployAll);
            this.Controls.Add(this.dataGridViewAgents);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonRemoteConfig);
            this.Controls.Add(this.buttonDeploy);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonStopAll);
            this.Controls.Add(this.buttonStartAll);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.richTextBoxLog);
            this.Name = "MainForm";
            this.Text = "AutoDeploy.Dashboard";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAgents)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.autoDeployAgentBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBoxLog;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonStartAll;
        private System.Windows.Forms.Button buttonStopAll;
        private System.Windows.Forms.Button buttonRemoteConfig;
        private System.Windows.Forms.Button buttonDeploy;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridViewAgents;
        private System.Windows.Forms.BindingSource autoDeployAgentBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn versionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn serviceRunningDataGridViewCheckBoxColumn;
        private System.Windows.Forms.Button buttonDeployAll;
    }
}


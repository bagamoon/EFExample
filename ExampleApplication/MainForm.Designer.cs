namespace ExampleApplicationCSharp
{
    partial class MainForm
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.FlowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnSelect = new System.Windows.Forms.Button();
            this.btnEagerLoadingAPI = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnFunction = new System.Windows.Forms.Button();
            this.btnSP = new System.Windows.Forms.Button();
            this.btnAutoMapper = new System.Windows.Forms.Button();
            this.btnLog = new System.Windows.Forms.Button();
            this.btnLogHelper = new System.Windows.Forms.Button();
            this.btnMsgBox = new System.Windows.Forms.Button();
            this.btnDemo = new System.Windows.Forms.Button();
            this.btnCompare = new System.Windows.Forms.Button();
            this.SplitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnEagerLoading = new System.Windows.Forms.Button();
            this.btnEntry = new System.Windows.Forms.Button();
            this.btnGeneric = new System.Windows.Forms.Button();
            this.btnAnonymousType = new System.Windows.Forms.Button();
            this.btnDelegate = new System.Windows.Forms.Button();
            this.btnAnonymous = new System.Windows.Forms.Button();
            this.btnAction = new System.Windows.Forms.Button();
            this.btnFunc = new System.Windows.Forms.Button();
            this.btnExpression = new System.Windows.Forms.Button();
            this.DataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnBulkInsert = new System.Windows.Forms.Button();
            this.FlowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer1)).BeginInit();
            this.SplitContainer1.Panel1.SuspendLayout();
            this.SplitContainer1.Panel2.SuspendLayout();
            this.SplitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(184, 3);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 25);
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Text = "update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // FlowLayoutPanel1
            // 
            this.FlowLayoutPanel1.Controls.Add(this.btnSelect);
            this.FlowLayoutPanel1.Controls.Add(this.btnEagerLoadingAPI);
            this.FlowLayoutPanel1.Controls.Add(this.btnUpdate);
            this.FlowLayoutPanel1.Controls.Add(this.btnDelete);
            this.FlowLayoutPanel1.Controls.Add(this.btnCreate);
            this.FlowLayoutPanel1.Controls.Add(this.btnFunction);
            this.FlowLayoutPanel1.Controls.Add(this.btnSP);
            this.FlowLayoutPanel1.Controls.Add(this.btnAutoMapper);
            this.FlowLayoutPanel1.Controls.Add(this.btnLog);
            this.FlowLayoutPanel1.Controls.Add(this.btnLogHelper);
            this.FlowLayoutPanel1.Controls.Add(this.btnMsgBox);
            this.FlowLayoutPanel1.Controls.Add(this.btnBulkInsert);
            this.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FlowLayoutPanel1.Location = new System.Drawing.Point(3, 77);
            this.FlowLayoutPanel1.Name = "FlowLayoutPanel1";
            this.FlowLayoutPanel1.Size = new System.Drawing.Size(735, 68);
            this.FlowLayoutPanel1.TabIndex = 0;
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(3, 3);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(75, 25);
            this.btnSelect.TabIndex = 0;
            this.btnSelect.Text = "select";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnEagerLoadingAPI
            // 
            this.btnEagerLoadingAPI.Location = new System.Drawing.Point(84, 3);
            this.btnEagerLoadingAPI.Name = "btnEagerLoadingAPI";
            this.btnEagerLoadingAPI.Size = new System.Drawing.Size(94, 25);
            this.btnEagerLoadingAPI.TabIndex = 7;
            this.btnEagerLoadingAPI.Text = "Eager Loading";
            this.btnEagerLoadingAPI.UseVisualStyleBackColor = true;
            this.btnEagerLoadingAPI.Click += new System.EventHandler(this.btnEagerLoadingAPI_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(265, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 25);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(346, 3);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(75, 25);
            this.btnCreate.TabIndex = 3;
            this.btnCreate.Text = "create";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnFunction
            // 
            this.btnFunction.Location = new System.Drawing.Point(427, 3);
            this.btnFunction.Name = "btnFunction";
            this.btnFunction.Size = new System.Drawing.Size(75, 25);
            this.btnFunction.TabIndex = 4;
            this.btnFunction.Text = "DB function";
            this.btnFunction.UseVisualStyleBackColor = true;
            this.btnFunction.Click += new System.EventHandler(this.btnFunction_Click);
            // 
            // btnSP
            // 
            this.btnSP.Location = new System.Drawing.Point(508, 3);
            this.btnSP.Name = "btnSP";
            this.btnSP.Size = new System.Drawing.Size(98, 25);
            this.btnSP.TabIndex = 5;
            this.btnSP.Text = "Store Procedure";
            this.btnSP.UseVisualStyleBackColor = true;
            this.btnSP.Click += new System.EventHandler(this.btnSP_Click);
            // 
            // btnAutoMapper
            // 
            this.btnAutoMapper.Location = new System.Drawing.Point(612, 3);
            this.btnAutoMapper.Name = "btnAutoMapper";
            this.btnAutoMapper.Size = new System.Drawing.Size(75, 25);
            this.btnAutoMapper.TabIndex = 8;
            this.btnAutoMapper.Text = "AutoMapper";
            this.btnAutoMapper.UseVisualStyleBackColor = true;
            this.btnAutoMapper.Click += new System.EventHandler(this.btnAutoMapper_Click);
            // 
            // btnLog
            // 
            this.btnLog.Location = new System.Drawing.Point(3, 34);
            this.btnLog.Name = "btnLog";
            this.btnLog.Size = new System.Drawing.Size(91, 25);
            this.btnLog.TabIndex = 9;
            this.btnLog.Text = "寫入大量log";
            this.btnLog.UseVisualStyleBackColor = true;
            this.btnLog.Click += new System.EventHandler(this.btnLog_Click);
            // 
            // btnLogHelper
            // 
            this.btnLogHelper.Location = new System.Drawing.Point(100, 34);
            this.btnLogHelper.Name = "btnLogHelper";
            this.btnLogHelper.Size = new System.Drawing.Size(75, 25);
            this.btnLogHelper.TabIndex = 10;
            this.btnLogHelper.Text = "LogHelper";
            this.btnLogHelper.UseVisualStyleBackColor = true;
            this.btnLogHelper.Click += new System.EventHandler(this.btnLogHelper_Click);
            // 
            // btnMsgBox
            // 
            this.btnMsgBox.Location = new System.Drawing.Point(181, 34);
            this.btnMsgBox.Name = "btnMsgBox";
            this.btnMsgBox.Size = new System.Drawing.Size(97, 25);
            this.btnMsgBox.TabIndex = 11;
            this.btnMsgBox.Text = "跳出訊息視窗";
            this.btnMsgBox.UseVisualStyleBackColor = true;
            this.btnMsgBox.Click += new System.EventHandler(this.btnMsgBox_Click);
            // 
            // btnDemo
            // 
            this.btnDemo.Location = new System.Drawing.Point(3, 3);
            this.btnDemo.Name = "btnDemo";
            this.btnDemo.Size = new System.Drawing.Size(75, 25);
            this.btnDemo.TabIndex = 8;
            this.btnDemo.Text = "EF demo";
            this.btnDemo.UseVisualStyleBackColor = true;
            this.btnDemo.Click += new System.EventHandler(this.btnDemo_Click);
            // 
            // btnCompare
            // 
            this.btnCompare.Location = new System.Drawing.Point(365, 3);
            this.btnCompare.Name = "btnCompare";
            this.btnCompare.Size = new System.Drawing.Size(155, 25);
            this.btnCompare.TabIndex = 6;
            this.btnCompare.Text = "IEnumerable vs IQueryable";
            this.btnCompare.UseVisualStyleBackColor = true;
            this.btnCompare.Click += new System.EventHandler(this.btnCompare_Click);
            // 
            // SplitContainer1
            // 
            this.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer1.Location = new System.Drawing.Point(0, 0);
            this.SplitContainer1.Name = "SplitContainer1";
            this.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // SplitContainer1.Panel1
            // 
            this.SplitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // SplitContainer1.Panel2
            // 
            this.SplitContainer1.Panel2.Controls.Add(this.DataGridView1);
            this.SplitContainer1.Size = new System.Drawing.Size(741, 538);
            this.SplitContainer1.SplitterDistance = 148;
            this.SplitContainer1.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.FlowLayoutPanel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.36496F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 49.63504F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(741, 148);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.btnDemo);
            this.flowLayoutPanel2.Controls.Add(this.btnEagerLoading);
            this.flowLayoutPanel2.Controls.Add(this.btnEntry);
            this.flowLayoutPanel2.Controls.Add(this.btnGeneric);
            this.flowLayoutPanel2.Controls.Add(this.btnCompare);
            this.flowLayoutPanel2.Controls.Add(this.btnAnonymousType);
            this.flowLayoutPanel2.Controls.Add(this.btnDelegate);
            this.flowLayoutPanel2.Controls.Add(this.btnAnonymous);
            this.flowLayoutPanel2.Controls.Add(this.btnAction);
            this.flowLayoutPanel2.Controls.Add(this.btnFunc);
            this.flowLayoutPanel2.Controls.Add(this.btnExpression);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(735, 68);
            this.flowLayoutPanel2.TabIndex = 1;
            // 
            // btnEagerLoading
            // 
            this.btnEagerLoading.Location = new System.Drawing.Point(84, 3);
            this.btnEagerLoading.Name = "btnEagerLoading";
            this.btnEagerLoading.Size = new System.Drawing.Size(94, 25);
            this.btnEagerLoading.TabIndex = 17;
            this.btnEagerLoading.Text = "Eager Loading";
            this.btnEagerLoading.UseVisualStyleBackColor = true;
            this.btnEagerLoading.Click += new System.EventHandler(this.btnEagerLoading_Click);
            // 
            // btnEntry
            // 
            this.btnEntry.Location = new System.Drawing.Point(184, 3);
            this.btnEntry.Name = "btnEntry";
            this.btnEntry.Size = new System.Drawing.Size(94, 25);
            this.btnEntry.TabIndex = 10;
            this.btnEntry.Text = "DbEntityEntry";
            this.btnEntry.UseVisualStyleBackColor = true;
            this.btnEntry.Click += new System.EventHandler(this.btnEntry_Click);
            // 
            // btnGeneric
            // 
            this.btnGeneric.Location = new System.Drawing.Point(284, 3);
            this.btnGeneric.Name = "btnGeneric";
            this.btnGeneric.Size = new System.Drawing.Size(75, 25);
            this.btnGeneric.TabIndex = 9;
            this.btnGeneric.Text = "泛型";
            this.btnGeneric.UseVisualStyleBackColor = true;
            this.btnGeneric.Click += new System.EventHandler(this.btnGeneric_Click);
            // 
            // btnAnonymousType
            // 
            this.btnAnonymousType.Location = new System.Drawing.Point(526, 3);
            this.btnAnonymousType.Name = "btnAnonymousType";
            this.btnAnonymousType.Size = new System.Drawing.Size(75, 25);
            this.btnAnonymousType.TabIndex = 15;
            this.btnAnonymousType.Text = "匿名型別";
            this.btnAnonymousType.UseVisualStyleBackColor = true;
            this.btnAnonymousType.Click += new System.EventHandler(this.btnAnonymousType_Click);
            // 
            // btnDelegate
            // 
            this.btnDelegate.Location = new System.Drawing.Point(607, 3);
            this.btnDelegate.Name = "btnDelegate";
            this.btnDelegate.Size = new System.Drawing.Size(75, 25);
            this.btnDelegate.TabIndex = 11;
            this.btnDelegate.Text = "delegate";
            this.btnDelegate.UseVisualStyleBackColor = true;
            this.btnDelegate.Click += new System.EventHandler(this.btnDelegate_Click);
            // 
            // btnAnonymous
            // 
            this.btnAnonymous.Location = new System.Drawing.Point(3, 34);
            this.btnAnonymous.Name = "btnAnonymous";
            this.btnAnonymous.Size = new System.Drawing.Size(75, 25);
            this.btnAnonymous.TabIndex = 12;
            this.btnAnonymous.Text = "匿名方法";
            this.btnAnonymous.UseVisualStyleBackColor = true;
            this.btnAnonymous.Click += new System.EventHandler(this.btnAnonymous_Click);
            // 
            // btnAction
            // 
            this.btnAction.Location = new System.Drawing.Point(84, 34);
            this.btnAction.Name = "btnAction";
            this.btnAction.Size = new System.Drawing.Size(75, 25);
            this.btnAction.TabIndex = 13;
            this.btnAction.Text = "Action";
            this.btnAction.UseVisualStyleBackColor = true;
            this.btnAction.Click += new System.EventHandler(this.btnAction_Click);
            // 
            // btnFunc
            // 
            this.btnFunc.Location = new System.Drawing.Point(165, 34);
            this.btnFunc.Name = "btnFunc";
            this.btnFunc.Size = new System.Drawing.Size(75, 25);
            this.btnFunc.TabIndex = 14;
            this.btnFunc.Text = "Func";
            this.btnFunc.UseVisualStyleBackColor = true;
            this.btnFunc.Click += new System.EventHandler(this.btnFunc_Click);
            // 
            // btnExpression
            // 
            this.btnExpression.Location = new System.Drawing.Point(246, 34);
            this.btnExpression.Name = "btnExpression";
            this.btnExpression.Size = new System.Drawing.Size(75, 25);
            this.btnExpression.TabIndex = 16;
            this.btnExpression.Text = "Expression";
            this.btnExpression.UseVisualStyleBackColor = true;
            this.btnExpression.Click += new System.EventHandler(this.btnExpression_Click);
            // 
            // DataGridView1
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataGridView1.DefaultCellStyle = dataGridViewCellStyle5;
            this.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataGridView1.Location = new System.Drawing.Point(0, 0);
            this.DataGridView1.Name = "DataGridView1";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.DataGridView1.Size = new System.Drawing.Size(741, 386);
            this.DataGridView1.TabIndex = 0;
            // 
            // btnBulkInsert
            // 
            this.btnBulkInsert.Location = new System.Drawing.Point(284, 34);
            this.btnBulkInsert.Name = "btnBulkInsert";
            this.btnBulkInsert.Size = new System.Drawing.Size(75, 23);
            this.btnBulkInsert.TabIndex = 12;
            this.btnBulkInsert.Text = "Bulk Insert";
            this.btnBulkInsert.UseVisualStyleBackColor = true;
            this.btnBulkInsert.Click += new System.EventHandler(this.btnBulkInsert_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(741, 538);
            this.Controls.Add(this.SplitContainer1);
            this.Name = "MainForm";
            this.Text = "CRUDForm";
            this.Load += new System.EventHandler(this.CRUDForm_Load);
            this.FlowLayoutPanel1.ResumeLayout(false);
            this.SplitContainer1.Panel1.ResumeLayout(false);
            this.SplitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer1)).EndInit();
            this.SplitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Button btnUpdate;
        internal System.Windows.Forms.FlowLayoutPanel FlowLayoutPanel1;
        internal System.Windows.Forms.Button btnSelect;
        internal System.Windows.Forms.Button btnDelete;
        internal System.Windows.Forms.Button btnCreate;
        internal System.Windows.Forms.Button btnFunction;
        internal System.Windows.Forms.Button btnSP;
        internal System.Windows.Forms.Button btnCompare;
        internal System.Windows.Forms.SplitContainer SplitContainer1;
        internal System.Windows.Forms.DataGridView DataGridView1;
        private System.Windows.Forms.Button btnEagerLoadingAPI;
        private System.Windows.Forms.Button btnDemo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button btnGeneric;
        private System.Windows.Forms.Button btnEntry;
        private System.Windows.Forms.Button btnDelegate;
        private System.Windows.Forms.Button btnAnonymous;
        private System.Windows.Forms.Button btnAction;
        private System.Windows.Forms.Button btnFunc;
        private System.Windows.Forms.Button btnAnonymousType;
        private System.Windows.Forms.Button btnExpression;
        private System.Windows.Forms.Button btnAutoMapper;
        private System.Windows.Forms.Button btnEagerLoading;
        private System.Windows.Forms.Button btnLog;
        private System.Windows.Forms.Button btnLogHelper;
        private System.Windows.Forms.Button btnMsgBox;
        private System.Windows.Forms.Button btnBulkInsert;
    }
}


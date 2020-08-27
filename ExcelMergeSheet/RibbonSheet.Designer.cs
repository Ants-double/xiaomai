namespace ExcelMergeSheet
{
    partial class RibbonSheet : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public RibbonSheet()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tab1 = this.Factory.CreateRibbonTab();
            this.sheetGroup = this.Factory.CreateRibbonGroup();
            this.buttonMergeSheet = this.Factory.CreateRibbonButton();
            this.tab1.SuspendLayout();
            this.sheetGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab1
            // 
            this.tab1.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tab1.Groups.Add(this.sheetGroup);
            this.tab1.Label = "TabAddIns";
            this.tab1.Name = "tab1";
            // 
            // sheetGroup
            // 
            this.sheetGroup.Items.Add(this.buttonMergeSheet);
            this.sheetGroup.Label = "表操作";
            this.sheetGroup.Name = "sheetGroup";
            // 
            // buttonMergeSheet
            // 
            this.buttonMergeSheet.Label = "合并sheet";
            this.buttonMergeSheet.Name = "buttonMergeSheet";
            this.buttonMergeSheet.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.buttonMergeSheet_Click);
            // 
            // RibbonSheet
            // 
            this.Name = "RibbonSheet";
            this.RibbonType = "Microsoft.Excel.Workbook";
            this.Tabs.Add(this.tab1);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.RibbonSheet_Load);
            this.tab1.ResumeLayout(false);
            this.tab1.PerformLayout();
            this.sheetGroup.ResumeLayout(false);
            this.sheetGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tab1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup sheetGroup;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton buttonMergeSheet;
    }

    partial class ThisRibbonCollection
    {
        internal RibbonSheet RibbonSheet
        {
            get { return this.GetRibbon<RibbonSheet>(); }
        }
    }
}

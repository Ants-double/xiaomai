namespace LandAddIn
{
    partial class RibbonColor : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public RibbonColor()
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
            this.tabColor = this.Factory.CreateRibbonTab();
            this.groupRow = this.Factory.CreateRibbonGroup();
            this.rangeColor = this.Factory.CreateRibbonButton();
            this.rangeRemoveColor = this.Factory.CreateRibbonButton();
            this.tab1.SuspendLayout();
            this.tabColor.SuspendLayout();
            this.groupRow.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab1
            // 
            this.tab1.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tab1.Label = "TabAddIns";
            this.tab1.Name = "tab1";
            this.tab1.Visible = false;
            // 
            // tabColor
            // 
            this.tabColor.Groups.Add(this.groupRow);
            this.tabColor.Label = "颜色相关";
            this.tabColor.Name = "tabColor";
            // 
            // groupRow
            // 
            this.groupRow.Items.Add(this.rangeColor);
            this.groupRow.Items.Add(this.rangeRemoveColor);
            this.groupRow.Label = "区域操作";
            this.groupRow.Name = "groupRow";
            // 
            // rangeColor
            // 
            this.rangeColor.Label = "区域加色";
            this.rangeColor.Name = "rangeColor";
            this.rangeColor.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.RangeColor_Click);
            // 
            // rangeRemoveColor
            // 
            this.rangeRemoveColor.Label = "区域去色";
            this.rangeRemoveColor.Name = "rangeRemoveColor";
            this.rangeRemoveColor.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.RangeRemoveColor_Click);
            // 
            // RibbonColor
            // 
            this.Name = "RibbonColor";
            this.RibbonType = "Microsoft.Excel.Workbook";
            this.Tabs.Add(this.tab1);
            this.Tabs.Add(this.tabColor);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.RibbonColor_Load);
            this.tab1.ResumeLayout(false);
            this.tab1.PerformLayout();
            this.tabColor.ResumeLayout(false);
            this.tabColor.PerformLayout();
            this.groupRow.ResumeLayout(false);
            this.groupRow.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tab1;
        internal Microsoft.Office.Tools.Ribbon.RibbonTab tabColor;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup groupRow;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton rangeColor;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton rangeRemoveColor;
    }

    partial class ThisRibbonCollection
    {
        internal RibbonColor RibbonColor
        {
            get { return this.GetRibbon<RibbonColor>(); }
        }
    }
}

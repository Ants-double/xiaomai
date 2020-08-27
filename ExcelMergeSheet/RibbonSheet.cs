using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;
using Excel = Microsoft.Office.Interop.Excel;

namespace ExcelMergeSheet
{
    public partial class RibbonSheet
    {
        private void RibbonSheet_Load(object sender, RibbonUIEventArgs e)
        {

        }

        private void buttonMergeSheet_Click(object sender, RibbonControlEventArgs e)
        {
            var app = Globals.ThisAddIn.Application;
            // 关闭相关警告
            if (app.DisplayAlerts == true)
            {
                app.DisplayAlerts = false;
            }
            var execlBook = app.ActiveWorkbook;
            Excel.Workbook book = app.ActiveWorkbook;
           

        }
    }
}

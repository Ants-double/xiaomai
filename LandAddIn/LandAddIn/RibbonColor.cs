using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Interop.Excel;
using Microsoft.Office.Tools.Ribbon;
using Excel = Microsoft.Office.Interop.Excel;
namespace LandAddIn
{
    public partial class RibbonColor
    {
        private void RibbonColor_Load(object sender, RibbonUIEventArgs e)
        {

        }        

        private void RangeRemoveColor_Click(object sender, RibbonControlEventArgs e)
        {
            var app = Globals.ThisAddIn.Application;
            // 关闭相关警告
            if (app.DisplayAlerts == true)
            {
                app.DisplayAlerts = false;
            }
            Excel.Workbook book = app.ActiveWorkbook;
            Excel.Worksheet sheet = book.ActiveSheet;
            var rowCount = sheet.UsedRange.Rows.Count;
            var colCount = sheet.UsedRange.Columns.Count;
            var rowLength = sheet.UsedRange.Row + rowCount;
            var colLength = sheet.UsedRange.Column + colCount;
           
            for (int i = sheet.UsedRange.Row; i < rowLength; i++)
            {
                for (int j = sheet.UsedRange.Column; j < colLength; j++)
                {
                    Range numRan = sheet.Cells[i, j];
                    numRan.Cells.Interior.Color = ((Range)sheet.Cells[rowLength + 5, colLength + 5]).Cells.Interior.Color; 
                }
            }
        }

        private void RangeColor_Click(object sender, RibbonControlEventArgs e)
        {
            var app = Globals.ThisAddIn.Application;
            // 关闭相关警告
            if (app.DisplayAlerts == true)
            {
                app.DisplayAlerts = false;
            }
            Excel.Workbook book = app.ActiveWorkbook;
            Excel.Worksheet sheet = book.ActiveSheet;
            var rowCount = sheet.UsedRange.Rows.Count;
            var colCount = sheet.UsedRange.Columns.Count;
            var rowLength = sheet.UsedRange.Row + rowCount;
            var colLength = sheet.UsedRange.Column + colCount;
            Random rd = new Random();
            for (int i = sheet.UsedRange.Row; i < rowLength; i++)
            {
                for (int j = sheet.UsedRange.Column; j < colLength; j++)
                {
                    Range numRan = sheet.Cells[i, j];
                    numRan.Cells.Interior.Color = System.Drawing.Color.FromArgb(rd.Next(0, 255), rd.Next(0, 158), rd.Next(120, 255)).ToArgb();
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Excel = Microsoft.Office.Interop.Excel;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Tools.Excel;
using Microsoft.Office.Interop.Excel;

namespace cliesx
{
    public partial class ThisAddIn
    {
        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            this.Application.WorkbookBeforeSave += new Microsoft.Office.Interop.Excel.AppEvents_WorkbookBeforeSaveEventHandler(Application_WorkbookBeforeSave);
            
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
        }

        private void Application_WorkbookBeforeSave(Microsoft.Office.Interop.Excel.Workbook wb, bool SaveAsUI, ref bool Cancel)
        {
            Excel.Worksheet activeWorksheet = ((Excel.Worksheet)Application.ActiveSheet);
            Excel.Range firstRow = activeWorksheet.get_Range("A1");
            firstRow.EntireRow.Insert(Excel.XlInsertShiftDirection.xlShiftDown);
            Excel.Range newFirstRow = activeWorksheet.get_Range("A1");
            newFirstRow.Value2 = "This text was added by using code.";
        }

        public static void ChangeFontColor(System.Drawing.Color colorCode)
        {
            Excel.Range selectedRange = Globals.ThisAddIn.Application.Selection;
            if(selectedRange != null && selectedRange.Count > 0) {
                //selectedRange.Font.Color = Excel.XlRgbColor.rgbRed;
                selectedRange.Font.Color = colorCode;
            }
        }

        public static void ChangeFileAccess(XlFileAccess xl)
        {
            try
            {
                Excel.Workbook activeWorkbook = Globals.ThisAddIn.Application.ActiveWorkbook;
                activeWorkbook.ChangeFileAccess(xl);

            }catch(Exception ex)
            {

            }

            return;
        }

        public static void GroupColumn(bool groupMode)
        {
            Excel.Range selectedRange = Globals.ThisAddIn.Application.Selection;
            if (groupMode) selectedRange.Group();
            else selectedRange.Ungroup();
        }

        public static void GroupRow(bool groupMode)
        {
            Excel.Range selectedRange = Globals.ThisAddIn.Application.Selection;

            int startRowIndex = selectedRange.Row;
            int endRowIndex = selectedRange.Row + selectedRange.Rows.Count - 1;

            Excel.Range groupRange = Globals.ThisAddIn.Application.ActiveSheet.Rows[startRowIndex + ":" + endRowIndex];

            if(groupMode) groupRange.Group();
            else groupRange.Ungroup();


        }

        public static string GetFullName()
        {
            string fullName = Globals.ThisAddIn.Application.ActiveWorkbook.FullName;
            return fullName;
        }

        public static string GetSheetName()
        {
            string sheetName = Globals.ThisAddIn.Application.ActiveWorkbook.ActiveSheet.Name;
            return sheetName;
        }

        public static void AddSheet(string sheetName = "")
        {
            Excel.Workbook activeWorkbook = Globals.ThisAddIn.Application.ActiveWorkbook;
            Excel.Worksheet newSheet = activeWorkbook.Worksheets.Add();
            if(sheetName != "")
                newSheet.Name = sheetName;
        }

        public static void DeleteSheet()
        {
            Globals.ThisAddIn.Application.ActiveWorkbook.ActiveSheet.Delete();

        }

        public static void CopySheet()
        {
            Excel.Worksheet activeWorkSheet = Globals.ThisAddIn.Application.ActiveWorkbook.ActiveSheet;
            activeWorkSheet.Copy(After: activeWorkSheet);
        }

        public static void CellHorizontalAlignment(Microsoft.Office.Interop.Excel.XlHAlign hAlign)
        {
            Excel.Range selectedRange = Globals.ThisAddIn.Application.Selection;
            selectedRange.HorizontalAlignment = hAlign;
        }

        public static void CellVerticalAlignment(Microsoft.Office.Interop.Excel.XlVAlign vAlign)
        {
            Range activeCell = Globals.ThisAddIn.Application.ActiveCell;
            Excel.Range selectedRange = Globals.ThisAddIn.Application.Selection;
            selectedRange.VerticalAlignment = vAlign;
        }

        public static void MergeActiveCell()
        {
            Excel.Range selectedRange = Globals.ThisAddIn.Application.Selection;
            selectedRange.Merge();
        }

        public static void UnMergeActiveCell()
        {
            Excel.Range selectedRange = Globals.ThisAddIn.Application.Selection;
            selectedRange.UnMerge();
        }

        public static void DisplayGridLines(bool displayFlag)
        {
            Globals.ThisAddIn.Application.ActiveWindow.DisplayGridlines = displayFlag;
        }

        public static void DisplayFomulasBar(bool displayFlag)
        {
            Globals.ThisAddIn.Application.DisplayFormulaBar = displayFlag;
        }

        public static void DisplayClipboard(bool displayFlag)
        {
            Globals.ThisAddIn.Application.DisplayClipboardWindow = displayFlag;
        }

        public static void DisplayFullScreen(bool displayFlag)
        {
            Globals.ThisAddIn.Application.DisplayFullScreen = displayFlag;
        }

        public static void ShowDialog(Microsoft.Office.Interop.Excel.XlBuiltInDialog dialogCode)
        {
            Globals.ThisAddIn.Application.Dialogs[dialogCode].Show(
                Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

        }



        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }
        
        #endregion
    }
}

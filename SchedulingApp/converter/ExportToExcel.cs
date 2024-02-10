using Microsoft.Office.Interop.Excel;
using DataTable = System.Data.DataTable;
using Application = Microsoft.Office.Interop.Excel.Application;

namespace SchedulingApp.converter;

public class ExportToExcel
{
    public static void ToExcelFile(DataTable values)
    {
        Application excel = new();
        Workbook wb = excel.Workbooks.Add();
        Worksheet ws = (Worksheet)wb.ActiveSheet;
        ws.Columns.AutoFit();
        ws.Columns.EntireColumn.ColumnWidth = 25;
        // Header row
        for (int Idx = 0; Idx < values.Columns.Count; Idx++)
        {
            ws.Range["A1"].Offset[0, Idx].Value = values.Columns[Idx].ColumnName;
        }
        // Data Rows
        for (int Idx = 0; Idx < values.Rows.Count; Idx++)
        {
            ws.Range["A2"].Offset[Idx].Resize[1, values.Columns.Count].Value = values.Rows[Idx].ItemArray;
        }
        excel.Visible = true;
        wb.Activate();
    }
}

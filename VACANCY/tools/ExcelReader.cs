/**==========================================================================
 * System: TS Vacancy
 * Module: Administration Website
 * Author: Lucas Porcelli, Edward Centeno
 * Company: @r-Tech SRL Costa Rica
 * Date: Sep, 2018
 *==========================================================================*/

using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace PG.LST.PSC.TSVacancy.Tools
{
    /// <summary>
    /// Class to read an Excel file using OpenXML.
    /// </summary>
    static class ExcelReader
    {
        /// <summary>
        /// Method to read an Excel file into a Datatable.
        /// </summary>
        /// <param name="path">Excel File path</param>
        /// <returns>Datatable with Excel content</returns>
        public static DataTable ReadFile(string path)
        {
            DataTable dt = new DataTable();

            using (SpreadsheetDocument spreadSheetDocument = SpreadsheetDocument.Open(path, false))
            {
                WorkbookPart workbookPart = spreadSheetDocument.WorkbookPart;
                IEnumerable<Sheet> sheets = spreadSheetDocument.WorkbookPart.Workbook.GetFirstChild<Sheets>().Elements<Sheet>();
                string relationshipId = sheets.First().Id.Value;
                WorksheetPart worksheetPart = (WorksheetPart)spreadSheetDocument.WorkbookPart.GetPartById(relationshipId);
                Worksheet workSheet = worksheetPart.Worksheet;
                SheetData sheetData = workSheet.GetFirstChild<SheetData>();
                IEnumerable<Row> rows = sheetData.Descendants<Row>();

                //En el 1 estan los campos de cabecera. Los blancos no los lee el openxml
                foreach (Cell cell in rows.ElementAt(0))
                {
                    string colName = GetCellValue(spreadSheetDocument, cell);
                    dt.Columns.Add(colName);
                }

                foreach (Row row in rows)
                {
                    DataRow tempRow = dt.NewRow();
                    int columnIndex = 0;
                    foreach (Cell cell in row.Descendants<Cell>())
                    {
                        int cellColumnIndex = (int)GetColumnIndexFromName(GetColumnName(cell.CellReference));
                        cellColumnIndex--;

                        //Verifico si la celda corresponde al indice, sino es celda en blanco.
                        if (columnIndex < cellColumnIndex)
                        {
                            do
                            {
                                tempRow[columnIndex] = "";
                                columnIndex++;
                            }
                            while (columnIndex < cellColumnIndex);
                        }

                        tempRow[columnIndex] = GetCellValue(spreadSheetDocument, cell);

                        columnIndex++;
                    }
                    dt.Rows.Add(tempRow);
                }
            }
            dt.Rows.RemoveAt(0); //Elimino los campos de la cabecera

            return dt;
        }


        public static string GetCellValue(SpreadsheetDocument document, Cell cell)
        {
            SharedStringTablePart stringTablePart = document.WorkbookPart.SharedStringTablePart;

            if (cell.CellValue == null)
            {
                return "";
            }

            string value = cell.CellValue.InnerXml;
            if (cell.DataType != null && cell.DataType.Value == CellValues.SharedString)
            {
                return stringTablePart.SharedStringTable.ChildElements[Int32.Parse(value)].InnerText;
            }
            else
            {
                return value;
            }
        }

        private static string GetColumnName(string cellReference)
        {
            // Create a regular expression to match the column name portion of the cell name.
            Regex regex = new Regex("[A-Za-z]+");
            Match match = regex.Match(cellReference);
            return match.Value;
        }

        private static int? GetColumnIndexFromName(string columnName)
        {
            //return columnIndex;
            string name = columnName;
            int number = 0;
            int pow = 1;
            for (int i = name.Length - 1; i >= 0; i--)
            {
                number += (name[i] - 'A' + 1) * pow;
                pow *= 26;
            }
            return number;
        }

    }
}

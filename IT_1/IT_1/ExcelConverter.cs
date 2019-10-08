using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace IT_1
{
    class ExcelConverter
    {
        public static void SaveGroup(Group group, string path)
        {
            var newFile = new FileInfo(path);
            using (ExcelPackage xlPackage = new ExcelPackage(newFile))
            {

                ExcelWorksheet worksheet = xlPackage.Workbook.Worksheets.Add("Group");

                for (int i = 0; i < group.header.Length; i++)
                {
                    worksheet.Cells[1, i + 1].Value = group.header[i];
                    worksheet.Column(i+1).Width = 20;
                }
                worksheet.Cells[1, group.header.Length + 1].Value = "Average mark";
                worksheet.Column(group.header.Length + 1).Width = 20;
                
                for (int i = 0, row = 2; i < group.students.Count; i++, row++)
                {
                    worksheet.Cells[row, 1].Value = group.students[i].name;
                    worksheet.Cells[row, 2].Value = group.students[i].surname;
                    worksheet.Cells[row, 3].Value = group.students[i].patronymic;
                    int col = 4;
                    for (int j = 0; j < group.students[i].subjects.Count; j++, col++)
                    {
                        worksheet.Cells[row, col].Value = group.students[i].subjects[j].mark;
                    }
                    worksheet.Cells[row, col].Value = group.students[i].averageMark;
                }

                int lastRow = group.students.Count + 2;


                worksheet.Cells[lastRow, 3].Value = "Average by group:";

                for (int i = 0; i < group.averageMarks.Count - 1; i++)
                {
                    worksheet.Cells[lastRow, i + 4].Value = group.averageMarks[group.header[i + 3]];
                }


                worksheet.Cells[lastRow, group.averageMarks.Count + 3].Value = group.averageMarks["Average"];



                try
                {
                    if (File.Exists(path))
                    {
                        File.Delete(path);
                    }
                    xlPackage.Save();
                }
                catch
                {
                    ExceptionProcessing.LogEx(new Exception("Invalid file format or path."));
                }
            }
        }
    }
}

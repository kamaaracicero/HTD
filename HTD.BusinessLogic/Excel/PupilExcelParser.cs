using HTD.DataEntities;
using OfficeOpenXml;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HTD.BusinessLogic.Excel
{
    internal class PupilExcelParser : IExcelParser<Pupil>
    {
        public void Parse(IEnumerable<Pupil> data, string path)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            var package = new ExcelPackage();

            var sheet = package.Workbook.Worksheets.Add("Ученики");
            sheet.Cells[1, 1].Value = "ID";
            sheet.Cells[1, 2].Value = "Ф.И.О.";
            sheet.Cells[1, 3].Value = "Ф.И.О. представителя";
            sheet.Cells[1, 4].Value = "Телефон представителя";

            var row = 2;
            foreach (var pupil in data.Where(p => !p.IsExpelled))
            {
                sheet.Cells[row, 1].Value = pupil.Id;
                sheet.Cells[row, 2].Value = pupil.Name;
                sheet.Cells[row, 3].Value = pupil.ParentName;
                sheet.Cells[row, 4].Value = pupil.ContactPhone;

                row++;
            }
            sheet.Cells[1, 1, row, 4].AutoFitColumns();

            File.WriteAllBytes(path, package.GetAsByteArray());
        }
    }
}

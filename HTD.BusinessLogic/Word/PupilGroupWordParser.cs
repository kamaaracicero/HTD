using HTD.BusinessLogic.Word.Data;
using HTD.DataEntities;
using System;
using Xceed.Document.NET;
using Xceed.Words.NET;

namespace HTD.BusinessLogic.Word
{
    internal class PupilGroupWordParser : IWordParser<PupilGroupWordData>
    {
        public void ParseWordDoc(PupilGroupWordData data, string path)
        {
            using (DocX doc = DocX.Create(path))
            {
                Paragraph par = doc.InsertParagraph();
                Formatting formatting = SetUpFormatting();

                par.Append(data.GroupName + ", " + data.GroupYear + " Год",
                    formatting);

                doc.InsertParagraph().Append("", formatting);

                var list = doc.AddList(listType: ListItemType.Numbered,
                    startNumber: 1,
                    formatting: formatting);

                foreach (var pupil in data.Pupils)
                {
                    doc.AddListItem(list,
                        GetListItemText(pupil),
                        level: 0,
                        formatting: formatting);
                }

                doc.InsertList(list);

                doc.Save();
            }
        }

        private Formatting SetUpFormatting() =>
            new Formatting
            {
                FontFamily = new Font("Times New Roman"),
                Size = 14
            };

        private string GetListItemText(Pupil pupil)
            => string.Format("{0}, ГУО \"{1}\", {2} Класс",
                pupil.Name, pupil.GUO, pupil.Class);
    }
}

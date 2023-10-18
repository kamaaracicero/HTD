using HTD.DataEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HTD.BusinessLogic.Word.Data;
using HTD.BusinessLogic.Word;

namespace HTD.TestConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Pupil> list = new List<Pupil>
            {
                new Pupil()
                {
                    Name = "Веровкин Андрей Александрович",
                    GUO = "Гимназия №3",
                    Class = 11,
                },
                new Pupil()
                {
                    Name = "Колосовский Денис Юрьевич",
                    GUO = "СШ №23",
                    Class = 11,
                },
                new Pupil()
                {
                    Name = "Веровкина Галина Михайловна",
                    GUO = "СШ №15",
                    Class = 11,
                }
            };
            PupilGroupWordData data = new PupilGroupWordData();
            data.Pupils = list;
            data.GroupName = "Python 1 Группа";
            data.GroupYear = "1";
            IWordParser<PupilGroupWordData> parser = new PupilGroupWordParser();
            parser.ParseWordDoc(data, "C:\\Users\\verov\\Documents\\test.docx");

            Console.WriteLine("Good");
            Console.ReadLine();
        }
    }
}

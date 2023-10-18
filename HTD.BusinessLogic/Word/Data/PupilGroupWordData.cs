using HTD.DataEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTD.BusinessLogic.Word.Data
{
    public class PupilGroupWordData
    {
        public IEnumerable<Pupil> Pupils { get; set; }

        public string GroupName { get; set; }

        public string GroupYear { get; set; }
    }
}

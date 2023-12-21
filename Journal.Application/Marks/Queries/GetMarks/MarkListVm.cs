using Journal.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Journal.Application.Marks.Queries.GetMarks
{
    public class MarkListVm
    {
        public IList<MarkDto> Marks { get; set; }
    }
}

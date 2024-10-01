using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zavtarasdaemsya
{
    public class Task
    {
        public int Id {  get; set; }
        public string Title { get; set; } = null!;

        public int? RazdelId { get; set; } = null;
        public Razdel Razdel { get; set; } = null;
    }
}

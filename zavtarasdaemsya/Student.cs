using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zavtarasdaemsya
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;

        public int? TaskId { get; set; } = null;
        public Task Task { get; set; } = null;
    }
}

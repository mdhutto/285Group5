using System;
using System.Collections.Generic;

namespace RisingPhoenix.Models
{
    public partial class Forms
    {
        public int FormId { get; set; }
        public int FormType { get; set; }
        public DateTime FormDate { get; set; }

        public Face2Faces Face2Faces { get; set; }
        public Htmoneys Htmoneys { get; set; }
    }
}

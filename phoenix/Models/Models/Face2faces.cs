using System;
using System.Collections.Generic;

namespace DataAccessLibrary.Models
{
    public partial class Face2faces
    {
        public int FormId { get; set; }
        public string Location { get; set; }
        public int MetId1 { get; set; }
        public int MetId2 { get; set; }
        public int? MetId3 { get; set; }
        public int? MetId4 { get; set; }

        public Forms Form { get; set; }
        public Members MetId1Navigation { get; set; }
        public Members MetId2Navigation { get; set; }
        public Members MetId3Navigation { get; set; }
        public Members MetId4Navigation { get; set; }
    }
}

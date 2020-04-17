using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcaneTracker
{
    class Arcane
    {
        public string Name { get; set; }
        public int Rank { get; set; }
        public int MaxRank { get; set; }
        public int SurplusArcanes { get; set; }
        public bool isMaxRank { get; set; }
        public int MaxArcanesRequired { get { return 21; }}
        public int ArcanesRequiredToReachMaxRank { get; set; }
        public int Rank0OwnedArcanes { get; set; }

    }
}

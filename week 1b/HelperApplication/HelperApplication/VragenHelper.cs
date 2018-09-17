using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperApplication
{
    public class VragenHelper
    {
        public virtual List<Tuple<int, string, string>> VragenSet { get; set; }

        public VragenHelper()
        {
            VragenSet = new List<Tuple<int, string, string>>();
            VragenSet.Add(new Tuple<int, string, string>(13, "Waarom is de klasse niet vindbaar?", "De klasse is niet 'public'."));
        }
    }
}

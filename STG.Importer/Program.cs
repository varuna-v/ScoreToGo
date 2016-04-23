using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STG.Importer
{
    class Program
    {
        public static void Main(string[] args)
        {
            var importer = new TeamsImporter();
            importer.Import();
        }
    }
}

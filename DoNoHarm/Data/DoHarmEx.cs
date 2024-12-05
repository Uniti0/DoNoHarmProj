using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DoNoHarm.Data
{
    partial class DoNoHarmDB
    {
        public static DoNoHarmDB _context;

        public static DoNoHarmDB GetContext()
        {
            if (_context == null)
            {
                _context = new DoNoHarmDB();
            }
            return _context;
        }
    }
}

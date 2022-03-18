using APMService.DataFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APMService.ServiceFolder
{
    public class DataService : APMServiceEntities12
    {
        private static APMServiceEntities12 context;


        public DataService() : base()
        {

        }


        public static APMServiceEntities12 GetContext()
        {
            if (context == null)
                context = new APMServiceEntities12();
            return context;
        }
    }
}


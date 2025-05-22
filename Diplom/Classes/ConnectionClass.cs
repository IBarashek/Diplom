using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.Classes
{
    class ConnectionClass
    {
        public static KazanSightEntities4 entities = new KazanSightEntities4();
        public static User currentUser;
        public static Administrator administrator;
    }
}

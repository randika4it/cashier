using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cashier
{
    interface InterfaceActivities
    {

        bool login(String username,String password);
        void order();
        void billCal();
        bool loginAdmin(String username,String password);
        bool addNewItem(String itemCode, String itemName, String size, String price, String availability);
        String getNextItemCode();

        void updateItem();
        void deleteItem();

    }
}

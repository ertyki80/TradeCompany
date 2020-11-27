using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingCompany.DataAccess.Context;
using TradingCompany.DataAccess.Models;
using TradingCompanyDataTransfer;

namespace TradingCompany.BusinessLogic.Extensions
{
    public class Extensions
    {
        
        public  string ToString(UserDTO user)
        {
            string str;
            str = string.Format("{0}.{1} {2} {3} {4}", user.Id, user.Login, user.FirstName, user.LastName, user.TimeOfCreating);
            return str;
            
        }
        public string ToString(ProductDTO product)
        {
            string str="";
            str = string.Format("{0}.{1} {2} {3}", product.Name, product.CountInStock, product.Description,product.TimeOfAdd);
            return str;

        }
        public string ToString(CategoryDTO category)
        {
            string str;
            str = string.Format("{0}. {1}", category.Id, category.Name);
            return str;

        }
        public string ToString(LogsDTO logs)
        {
            string str;
            str = string.Format("{0}. {1}", logs.Id, logs.Name);
            return str;

        }
        public string ToString(RoleDTO role)
        {
            string str;
            str = string.Format("{0}. {1}", role.Id, role.Name);
            return str;

        }
        public string ToString(TransactionDTO transaction)
        {
            string str;
            str = string.Format("{0}. {1} {2} {3} {4} ", transaction.Id, transaction.Product,transaction.User,transaction.Status,transaction.Time);
            return str;

        }
        public string ToString(StatusDTO status)
        {
            string str;
            str = string.Format("{0}. {1} ", status.Id, status.Name);
            return str;

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingCompany.DataAccess.Context;
using TradingCompany.DataAccess.Models;

namespace TradingCompany.BusinessLogic.Extensions
{
    public class Extensions
    {
        
        public  string ToString(User user)
        {
            string str;
            str = string.Format("{0}.{1} {2} {3} {4}", user.Id, user.Login, user.FirstName, user.LastName, user.TimeOfCreating);
            return str;
            
        }
        public string ToString(Product product)
        {
            string str="";
            str = string.Format("{0}.{1} {2} {3}", product.Name, product.CountInStock, product.Description,product.TimeOfAdd);
            return str;

        }
        public string ToString(Category category)
        {
            string str;
            str = string.Format("{0}. {1}", category.Id, category.Name);
            return str;

        }
        public string ToString(Logs logs)
        {
            string str;
            str = string.Format("{0}. {1}", logs.Id, logs.Name);
            return str;

        }
        public string ToString(Role role)
        {
            string str;
            str = string.Format("{0}. {1}", role.Id, role.Name);
            return str;

        }
        public string ToString(Transaction transaction)
        {
            string str;
            str = string.Format("{0}. {1} {2} {3} {4} {5}", transaction.Id, transaction.Product.Name,transaction.Product.Price,transaction.User.FirstName,transaction.Status.Name,transaction.Time);
            return str;

        }
        public string ToString(Status status)
        {
            string str;
            str = string.Format("{0}. {1} ", status.Id, status.Name);
            return str;

        }
    }
}

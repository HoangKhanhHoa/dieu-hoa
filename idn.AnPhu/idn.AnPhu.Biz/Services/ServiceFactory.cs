using idn.AnPhu.Biz.Persistance.SqlServer;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idn.AnPhu.Biz.Services
{
    public class ServiceFactory
    {
        static Hashtable services = new Hashtable();

        static ServiceFactory()
        {
            #region["Auth"]
            services.Add(typeof(Sys_UserManager), new Sys_UserManager(new Sys_UserProvider()));
            services.Add(typeof(Sys_GroupManager), new Sys_GroupManager(new Sys_GroupProvider()));
            services.Add(typeof(LocationManager), new LocationManager(new LocationProvider()));
            services.Add(typeof(LocationDiscountManager), new LocationDiscountManager(new LocationDiscountProvider()));
            services.Add(typeof(ManufacterManager), new ManufacterManager(new ManufacterProvider()));
            services.Add(typeof(CustomerManager), new CustomerManager(new CustomerProvider()));
            services.Add(typeof(OrderManager), new OrderManager(new OrderProvider()));
            services.Add(typeof(ProductOrderManager), new ProductOrderManager(new ProductOrderProvider()));
            #endregion
        }

        public static T GetService<T>()
        {
            foreach (var service in services.Values)
            {
                if (service is T)
                {
                    return (T)service;
                }
            }
            return default(T);
        }

        public static Sys_UserManager Sys_UserManager
        {
            get
            {
                return (Sys_UserManager)services[typeof(Sys_UserManager)];
            }
            set
            {
                services[typeof(Sys_UserManager)] = value;
            }
        }
        public static Sys_GroupManager Sys_GroupManager
        {
            get
            {
                return (Sys_GroupManager)services[typeof(Sys_GroupManager)];
            }
            set
            {
                services[typeof(Sys_GroupManager)] = value;
            }
        }
        public static LocationManager LocationManager
        {
            get
            {
                return (LocationManager)services[typeof(LocationManager)];
            }
            set
            {
                services[typeof(LocationManager)] = value;
            }
        }
        public static LocationDiscountManager LocationDiscountManager
        {
            get
            {
                return (LocationDiscountManager)services[typeof(LocationDiscountManager)];
            }
            set
            {
                services[typeof(LocationDiscountManager)] = value;
            }
        }
        public static ManufacterManager ManufacterManager
        {
            get
            {
                return (ManufacterManager)services[typeof(ManufacterManager)];
            }
            set
            {
                services[typeof(ManufacterManager)] = value;
            }
        }
        public static CustomerManager CustomerManager
        {
            get
            {
                return (CustomerManager)services[typeof(CustomerManager)];
            }
            set
            {
                services[typeof(CustomerManager)] = value;
            }
        }
        public static OrderManager OrderManager
        {
            get
            {
                return (OrderManager)services[typeof(OrderManager)];
            }
            set
            {
                services[typeof(OrderManager)] = value;
            }
        }
        public static ProductOrderManager ProductOrderManager
        {
            get
            {
                return (ProductOrderManager)services[typeof(ProductOrderManager)];
            }
            set
            {
                services[typeof(ProductOrderManager)] = value;
            }
        }
    }
}

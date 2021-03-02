//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using ToolChest_Data;
//using ToolChest_Models;

//namespace ToolChest_Service
//{
//    public class CustomerService
//    {
//        private readonly Guid _userId;

//        public CustomerService(Guid userId)
//        {
//            _userId = userId;
//        }

//        public bool CreateCustomer(CustomerCreate model)
//        {
//            var entity =
//                new Customer()
//                {
//                    CustomerId = _userId,
//                    CreatedUtc = DateTimeOffset.Now
//                };

//            using (var ctx = new ApplicationDbContext())
//            {
//                ctx.Customers.Add(entity);
//                return ctx.SaveChanges() == 1;
//            }
//        }

//        public IEnumerable<CustomerListItem> GetCustomers()
//        {
//            using (var ctx = new ApplicationDbContext())
//            {
//                var query =
//                    ctx
//                        .Customers
//                        .Where(e => e.CustomerId == _userId)
//                        .Select(
//                            e=>
//                                new CustomerListItem
//                                {
//                                    CustomerId =e.Id,
//                                    CreatedUtc =e.CreatedUtc,
//                                }
//                        );

//                return query.ToArray();
//            }
//        }
//    }
//}

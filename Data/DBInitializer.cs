using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using  BangazonAPI.Models;
using System.Threading.Tasks;

namespace BangazonAPI.Data //Worked on by Joey, July 27, 28, 31
{
    public static class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BangazonContext(serviceProvider.GetRequiredService<DbContextOptions<BangazonContext>>()))
            {
                if(context.Customer.Any())
                {
                    return; //db is already seeded
                }
                var customer = new Customer[]
                {
                    new Customer {
                        FirstName = "Gucci",
                        LastName = "Mane"
                    }, 
                    new Customer{
                        FirstName = "Riff",
                        LastName= "Raff"
                    },
                    new Customer{
                        FirstName = "Wacka Flocka",
                        LastName = "Flame"
                    }
                };
                foreach (Customer i in customer)
                {
                    context.Customer.Add(i);
                }
                context.SaveChanges();


                var productsType =  new ProductType[]
                {
                    new ProductType{
                        ProductTypeName = "Sports",
                    },
                    new ProductType{
                        ProductTypeName = "Toys",
                    }  
                };
                foreach(ProductType i in productsType)
                {
                    context.ProductType.Add(i);
                }  
                context.SaveChanges();
        

                var products = new Product[]
                {
                    new Product{
                        ProductTypeId = productsType.Single(s => s.ProductTypeName =="Sports").ProductTypeId,
                        Price = 50.00, 
                        Title = "Baseball Glove", 
                        Description = "This glove will help you catch baseballs.",
                        CustomerId = 1   
                    },
                    new Product{
                        ProductTypeId = productsType.Single(s => s.ProductTypeName =="Sports").ProductTypeId,
                        Price = 30.00, 
                        Title = "Basketball", 
                        Description = "Learn to dunk!",
                        CustomerId = 1    
                    },
                    new Product{
                        ProductTypeId = productsType.Single(s => s.ProductTypeName =="Toys").ProductTypeId,
                        Price = 10.00, 
                        Title = "Teddy Bear", 
                        Description = "Get it for the kids.",
                        CustomerId = 1   
                    },
                    new Product{
                        ProductTypeId = productsType.Single(s => s.ProductTypeName =="Toys").ProductTypeId,
                        Price = 5.00, 
                        Title = "Coloring Book", 
                        Description = "Stay in the lines. Or don't. Its up to you.",
                        CustomerId = 1 
                    }
                };  
                foreach(Product i in products)
                {
                    context.Product.Add(i);
                }
                context.SaveChanges();
        

                var paymentTypes = new PaymentType[]
                {
                    new PaymentType{
                        CustomerId = customer.Single(s => s.FirstName == "Gucci").CustomerId, 
                        AccountNumber = 2, 
                        PaymentTypeName = "Cash",
                    },
                    new PaymentType{
                        CustomerId = customer.Single(s => s.FirstName == "Riff").CustomerId,
                        AccountNumber = 3, 
                        PaymentTypeName = "Visa",
                    }, 
                    new PaymentType{
                        CustomerId = customer.Single(s => s.FirstName == "Wacka Flocka").CustomerId, 
                        AccountNumber = 4,
                        PaymentTypeName = "Mastercard", 
                    }
                }; 
                foreach(PaymentType i in paymentTypes)
                {
                    context.PaymentType.Add(i);
                }
                context.SaveChanges();


                var orders = new Order[]
                {
                    new Order{
                        CustomerId = customer.Single(s => s.FirstName == "Wacka Flocka").CustomerId,
                        // PaymentTypeId = paymentTypes.Single(s => s.PaymentTypeName == "Cash").PaymentTypeId, 
                    },
                    new Order{
                        CustomerId = customer.Single(s => s.FirstName == "Riff").CustomerId,
                        // PaymentTypeId = paymentTypes.Single(s => s.PaymentTypeName == "Visa").PaymentTypeId, 
                    },
                    new Order{
                        CustomerId = customer.Single(s => s.FirstName == "Gucci").CustomerId,
                        // PaymentTypeId = paymentTypes.Single(s => s.PaymentTypeName == "Mastercard").PaymentTypeId, 
                    }
                };
                foreach(Order i in orders)
                {
                    context.Order.Add(i);
                }
                context.SaveChanges();


                var departments = new Department[]
                {
                    new Department{
                        DeptName = "Sporting Goods",
                        ExpenseBudget = 1500
                    },
                    new Department{
                        DeptName = "Toy Department",
                        ExpenseBudget = 1250
                    }
                }; 
                foreach(Department i in departments)
                {
                    context.Department.Add(i);
                }
                context.SaveChanges();


                var employees = new Employee[]
                {
                    new Employee{
                        EmployeeName = "A$AP Ferg", 
                        EmployeePhone = "212-555-1212",
                        DepartmentId = departments.Single(s => s.DeptName == "Sporting Goods").DepartmentId,
                        IsSupervisor = false,
                    },
                    new Employee{
                        EmployeeName = "A$AP Rocky", 
                        EmployeePhone = "212-555-1213",
                        DepartmentId = departments.Single(s => s.DeptName == "Sporting Goods").DepartmentId,
                        IsSupervisor = true,
                    },
                    new Employee{
                        EmployeeName = "A$AP Nast",
                        EmployeePhone = "212-555-1214",
                        DepartmentId = departments.Single(s => s.DeptName == "Toy Department").DepartmentId,
                        IsSupervisor = false,
                    }
                }; 
                foreach(Employee i in employees)
                {
                    context.Employee.Add(i);
                }
                context.SaveChanges();

                var computers = new Computer[]
                {
                    new Computer{
                        ModelNumber = 123
                    },
                    new Computer{
                        ModelNumber = 456
                    },
                    new Computer{
                        ModelNumber = 789
                    }
                }; 
                foreach(Computer i in computers)
                {
                    context.Computer.Add(i);
                }
                context.SaveChanges();

                var employeeComputers = new EmployeeComputer[]
                {
                    new EmployeeComputer{
                        ComputerId = computers.Single(s => s.ModelNumber == 123).ComputerId,
                        EmployeeId = employees.Single(s => s.EmployeeName == "A$AP Nast").EmployeeId
                    },
                        new EmployeeComputer{
                        ComputerId = computers.Single(s => s.ModelNumber == 456).ComputerId,
                        EmployeeId = employees.Single(s => s.EmployeeName == "A$AP Ferg").EmployeeId
                    },
                        new EmployeeComputer{
                        ComputerId = computers.Single(s => s.ModelNumber == 123).ComputerId,
                        EmployeeId = employees.Single(s => s.EmployeeName == "A$AP Rocky").EmployeeId
                    }
                }; 
                foreach(EmployeeComputer i in employeeComputers)
                {
                    context.EmployeeComputer.Add(i);
                }
                context.SaveChanges();

                var training = new Training[]
                {
                    new Training{
                        StartDate = new DateTime(2017, 08, 01),
                        EndDate = new DateTime(2017, 08, 07),
                        Name = "Computer Training",
                        MaxAttendees = 25
                    },
                    new Training{
                        StartDate = new DateTime(2017, 09, 01),
                        EndDate = new DateTime(2017, 09, 07),
                        Name = "Up Selling", 
                        MaxAttendees = 40
                    },
                    new Training{
                        StartDate = new DateTime(2017, 09, 10),
                        EndDate = new DateTime(2017, 09, 12),
                        Name = "Sensitivity Traning",
                        MaxAttendees = 6
                    }
                };
                foreach(Training i in training)
                {
                    context.Training.Add(i);
                }
                context.SaveChanges();

                var employeeTrainings = new EmployeeTraining[]
                {
                    new EmployeeTraining{
                        TrainingId = training.Single(s => s.Name ==  "Computer Training").TrainingId,
                        EmployeeId = employees.Single(s => s.EmployeeName == "A$AP Nast").EmployeeId
                    },
                        new EmployeeTraining{
                        TrainingId = training.Single(s => s.Name ==  "Up Selling").TrainingId,
                        EmployeeId = employees.Single(s => s.EmployeeName == "A$AP Ferg").EmployeeId
                    },
                        new EmployeeTraining{
                        TrainingId = training.Single(s => s.Name == "Sensitivity Traning").TrainingId,
                        EmployeeId = employees.Single(s => s.EmployeeName == "A$AP Rocky").EmployeeId
                    }
                }; 
                foreach(EmployeeTraining i in employeeTrainings)
                {
                    context.EmployeeTraining.Add(i);
                }
                context.SaveChanges();
            }
        }
    }
}
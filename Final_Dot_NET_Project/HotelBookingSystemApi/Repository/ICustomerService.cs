using HotelBookingSystem.Models;

namespace HotelBookingSystem.Repository
{
    public interface ICustomerService
    {
        public List<Customer> GetCustomers ();
        public Customer GetCustomer (int id);
        public Customer AddCustomer(Customer customer)  ;

        public Customer UpdateCustomer(Customer customer,int id) ; 

        public void DeleteCustomer(int id); 
    }
}

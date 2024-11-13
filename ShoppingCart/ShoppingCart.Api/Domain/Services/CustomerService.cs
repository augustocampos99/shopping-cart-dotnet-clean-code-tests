using ShoppingCart.Api.Domain.Entities;
using ShoppingCart.Api.Domain.Interfaces.Repositories;
using ShoppingCart.Api.Domain.Interfaces.Services;
using ShoppingCart.Api.Dtos;

namespace ShoppingCart.Api.Domain.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<BaseResult<List<Customer>>> GetAllLimit(int limit, int skip)
        {
            try
            {
                var result = await _customerRepository.GetAllLimit(limit, skip);
                return new BaseResult<List<Customer>> { Success = true, Result = result.ToList(), Message = "" };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<BaseResult<Customer>> GetByGuid(Guid guid)
        {
            try
            {
                var result = await _customerRepository.GetByGuid(guid);
                if (result == null)
                {
                    return new BaseResult<Customer> { Success = false, Result = null, Message = "Not found" };
                }

                return new BaseResult<Customer> { Success = true, Result = result, Message = "" };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<BaseResult<Customer>> Create(Customer customer)
        {
            try
            {
                customer.Guid = Guid.NewGuid();
                customer.CreatedAt = DateTime.Now;
                customer.UpdatedAt = DateTime.Now;

                var result = await _customerRepository.Create(customer);
                return new BaseResult<Customer> { Success = true, Result = result, Message = "" };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<BaseResult<Customer>> Update(Customer customer)
        {
            try
            {
                var customerResult = await _customerRepository.GetByGuid(customer.Guid);

                if (customerResult == null)
                {
                    return new BaseResult<Customer> { Success = false, Result = null, Message = "Not found" };
                }

                customerResult.Name = customer.Name;
                customerResult.Email = customer.Email;
                customerResult.Phone = customer.Phone;
                customerResult.UpdatedAt = DateTime.Now;

                var result = await _customerRepository.Update(customerResult);

                return new BaseResult<Customer> { Success = true, Result = result, Message = "" };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<BaseResult<int>> Delete(Guid guid)
        {
            try
            {
                var customer = await _customerRepository.GetByGuid(guid);
                if(customer == null)
                {
                    return new BaseResult<int> { Success = false, Result = 0, Message = "Not found" };
                }

                var result = await _customerRepository.Delete(customer);
                return new BaseResult<int> { Success = true, Result = result, Message = "" };
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}

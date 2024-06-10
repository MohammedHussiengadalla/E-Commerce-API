using E_Commerce_API.Model;
using E_Commerce_API.Services.Interfaces;

namespace E_Commerce_API.Services.Implementation
{
    public class OrderService
    {
        private readonly IGenericRepository<Order> _orderRepository;

        public OrderService(IGenericRepository<Order> orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<IEnumerable<Order>> GetAllOrdersForUserAsync(int userId)
        {
            return (await _orderRepository.GetAllAsync()).Where(o => o.UserId == userId).ToList();
        }

        public async Task<Order> GetOrderByIdAsync(int id)
        {
            return await _orderRepository.GetByIdAsync(id);
        }

        public async Task AddOrderAsync(Order order)
        {
            await _orderRepository.AddAsync(order);
            await _orderRepository.SaveChangesAsync();
        }

        public async Task UpdateOrderAsync(Order order)
        {
            _orderRepository.Update(order);
            await _orderRepository.SaveChangesAsync();
        }

        public async Task DeleteOrderAsync(int id)
        {
            var order = await _orderRepository.GetByIdAsync(id);
            _orderRepository.Delete(order);
            await _orderRepository.SaveChangesAsync();
        }
    }

}

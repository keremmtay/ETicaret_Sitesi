using ETicaret.BusinessLayer.Abstract;
using ETicaret.WebUI.Identity;
using ETicaret.WebUI.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ETicaret.WebUI.Controllers
{
    [Authorize(Roles ="Customer")]
    public class OrderController : Controller
    {
        private UserManager<User> _userManager;
        private IOrderService _orderService;

        public OrderController(UserManager<User> userManager, IOrderService orderService)
        {
            _userManager = userManager;
            _orderService = orderService;
        }

        public IActionResult List()
        {
            var userId = _userManager.GetUserId(User);

            var orders = _orderService.GetOrders(userId);

            return View(orders);
        }
    }
}

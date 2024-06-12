using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using PR49_Galkin.Context;
using PR49_Galkin.Model;

namespace PR49_Galkin.Controllers
{
    [Route("api/OrderControllers")]
    [ApiExplorerSettings(GroupName = "v4")]
    public class OrderControllers : Controller
    {
        /// <summary>
        /// Отправить заказ
        /// </summary>
        /// <param name="Address">Введенный адрес</param>
        /// <param name="Date">Введенная дата</param>
        /// <param name="DishId">Введенное блюдо</param>
        /// <param name="Count">Введенное количество</param>
        /// <param name="Token">Токен пользователя</param>
        /// <returns>Метод для отправки заказа</returns>
        /// <response code="200">Заказ принят</response>
        /// <response code="400">Проблемы при запросе</response>
        /// <response code="401">Неавторизованный пользователь</response>
        [Route("AddOrders")]
        [HttpPost]
        [ProducesResponseType(typeof(User), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public ActionResult AddOrders([FromForm] string Address, [FromForm] DateTime Date, [FromForm] int DishId, [FromForm] int Count, [FromForm] string Token)
        {
            if (Address == null || Date == null || DishId == null ||
                Count == null || Token == null)
                return StatusCode(400);
            try
            {
                var order = new OrderContext();
                var findToken = new UserContext();
                if (order.Order.FirstOrDefault(x => x.Address == Address && x.Date == Date && x.DishId == DishId && x.Count == Count) != null) return StatusCode(400);
                if (findToken.Users.FirstOrDefault(x => x.Token == Token == null) == null) return StatusCode(400, "Токен не существует.");
                else
                {
                    Model.Oders order2 = new Oders()
                    {
                        Address = Address,
                        Date = Date,
                        DishId = DishId,
                        Count = Count
                    };
                    order.Order.Add(order2);
                    order.SaveChanges();
                    return Json(order);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Получение истории заказов
        /// </summary>
        /// <remarks>Данный метод получает историю заказов, находящийся в базе данных</remarks>
        /// <response code="200">Список успешно получен</response>
        /// <response code="400">Проблемы при запросе</response>
        /// <response code="401">Неавторизованный доступ</response>
        [Route("History")]
        [HttpGet]
        [ProducesResponseType(typeof(List<Oders>), 200)]
        [ProducesResponseType(400)]
        public ActionResult Hist()
        {
            try
            {
                IEnumerable<Oders> order = new OrderContext().Order;
                return Json(order);
            }
            catch
            {
                return StatusCode(400);
            }
        }
    }
}

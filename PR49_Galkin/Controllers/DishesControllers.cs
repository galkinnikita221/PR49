using Microsoft.AspNetCore.Mvc;
using PR49_Galkin.Context;
using PR49_Galkin.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PR49_Galkin.Controllers
{
    [Route("api/DishesControllers")]
    [ApiExplorerSettings(GroupName = "v3")]
    public class DishesControllers : Controller
    {
        /// <summary>
        /// Получение списка блюд
        /// </summary>
        /// <param name="Version">Версия блюда</param>
        /// <remarks>Данный метод получает список блюд, находящийся в базе данных</remarks>
        /// <response code="200">Список успешно получен</response>
        /// <response code="400">Проблемы при запросе</response>
        [Route("List")]
        [HttpGet]
        [ProducesResponseType(typeof(List<Dishes>), 200)]
        [ProducesResponseType(400)]
        public ActionResult List([FromQuery] int Version)
        {
            try
            {
                IEnumerable<Dishes> dishes = new DishesContext().Dishes.Where(x => x.Version == Version);
                return Json(dishes);
            }
            catch { return StatusCode(400); }
        }
    }
}

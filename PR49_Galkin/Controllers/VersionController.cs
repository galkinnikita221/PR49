using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PR49_Galkin.Context;
using PR49_Galkin.Model;

namespace PR49_Galkin.Controllers
{
    [Route("api/VersionController")]
    [ApiExplorerSettings(GroupName = "v2")]
    public class VersionController : Controller
    {
        /// <summary>
        /// Получение списка версий
        /// </summary>
        /// <remarks>Метод получает список версий из базы данных</remarks>
        /// <response code="200">Список успешно получен</response>
        /// <response code="400">Проблемы при запросе</response>
        [Route("List")]
        [HttpGet]
        [ProducesResponseType(typeof(List<Model.Versiyas>), 200)]
        [ProducesResponseType(400)]
        public ActionResult List()
        {
            try
            {
                IEnumerable<Model.Versiyas> versiyas = new VersionContext().Versiyas;
                return Json(versiyas);
            }
            catch
            {
                return StatusCode(400);
            }
        }
    }
}

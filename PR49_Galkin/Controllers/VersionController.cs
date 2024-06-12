using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using PR49_Galkin.Model;
using System.Collections.Generic;

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
        [ProducesResponseType(typeof(List<Versiya>) 200)]
        [ProducesResponseType(400)]
        public ActionResult List()
        {
            try
            {
                IEnumerable<Versiya> versiyas = new VersionContext().Versions;
                return Json(versiyas);
            }
            catch
            {
                return StatusCode(400);
            }
        }
    }
}

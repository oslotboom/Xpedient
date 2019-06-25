using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Xpedient.Controllers
{
    [Route("api/[controller]")]
    public class DataController : Controller
    {
        private readonly ClassLibrary.IDataProvider _dataProvider;

        public DataController(ClassLibrary.IDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }

        [HttpPost("[action]")]
        public IActionResult GetList(
            [FromBody] ClassLibrary.ListParameters listParameters

        )
        {
            object listObject = _dataProvider.GetList(listParameters);

            return Ok(listObject);
        }

    }
}

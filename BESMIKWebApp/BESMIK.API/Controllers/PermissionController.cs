using BESMIK.BLL.Managers.Concrete;
using BESMIK.Entities.Concrete;
using BESMIK.ViewModel.Permission;
using BESMIK.ViewModel.Spending;
using Microsoft.AspNetCore.Mvc;

namespace BESMIK.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PermissionController : Controller
    {
        private readonly PermissionManager _permissionManagerService;

        public PermissionController(PermissionManager permissionManagerService)
        {
            _permissionManagerService = permissionManagerService;
        }

        [HttpGet("PermissionList")]
        public ActionResult<IEnumerable<PermissionViewModel>> GetList()
        { 
            var permissions = _permissionManagerService.GetAll();
            return Ok(permissions);
        }
        [HttpPost("PermissionAdd")]
        public IActionResult Post([FromBody] PermissionViewModel model) 
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _permissionManagerService.Add(model);
            return Ok(model);
        }

    }
}

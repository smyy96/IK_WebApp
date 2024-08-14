using BESMIK.Entities.Concrete;
using BESMIK.ViewModel.Permission;
using Microsoft.AspNetCore.Mvc;

namespace BESMIK.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PermissionController : Controller
    {
        private readonly PermissionManager _permissionManagerService;
        private readonly Permission _permission;

        public PermissionController(PermissionManager permissionManagerService, Permission permission)
        {
            _permissionManagerService = permissionManagerService;
            _permission = permission;
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
            if (ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _permissionManagerService.Add(model);
            return Ok();
        }
    }
}

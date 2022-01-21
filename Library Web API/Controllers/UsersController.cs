using Library_BL.Model;
using Library_BL.Interfaces;
using Library_DAL.Interfaces;
using Library_Web_API.Requests;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace Library_Web_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserService _userService;
        private readonly IMapper _autoMapper;

        public UsersController(
            ILogger<UsersController> logger,
            IUnitOfWork unitOfWork,
            IUserService userService,
            IMapper autoMapper)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _userService = userService;
            _autoMapper = autoMapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var users =  await _userService.GetAll();
            return Ok(users);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var item = await _userService.Get(id);

            if (item == null)
                return NotFound();

            return Ok(item);
        }

       [HttpPost]
        public async Task<IActionResult> CreateUser(UserRequest user)
        {
            if (ModelState.IsValid && user != null)
            {

                await _userService.Create(_autoMapper.Map<UserModel>(user));

                return CreatedAtAction("Get", new { user.Id }, user);
            }

            return new JsonResult("Something went wrong") { StatusCode = 500 };
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute]int id, UserRequest user)
        {
            if (id != user.Id)
                return BadRequest();

            await _userService.Update(_autoMapper.Map<UserModel>(user));

            // Following up the REST standart on update we need to return NoContent
            return NoContent();
        }
       
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
             await _userService.Delete(id);

            return NoContent();
        }
        [HttpGet]
        [Route("~/[controller]/mostOverdue")]
        public async Task<IActionResult> GetTopOverdueUsers()
        {
            var history = await _unitOfWork.Users.GetMostOverdueUsers();
            return Ok(history);
        }
    }
}
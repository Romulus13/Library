using AutoMapper;
using Library_DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Library_Web_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookRentsController : ControllerBase
    {
        private readonly ILogger<BookRentsController> _logger;
        private readonly IUnitOfWork _unitOfWork;
 
        private readonly IMapper _autoMapper;

        public BookRentsController(
          ILogger<BookRentsController> logger,
          IUnitOfWork unitOfWork,
          IMapper autoMapper)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _autoMapper = autoMapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetBookRentHistory(int? bookId )
        {
            var history = await _unitOfWork.BookRents.GetHistory(bookId);
            return Ok(history);
        }

    }
}

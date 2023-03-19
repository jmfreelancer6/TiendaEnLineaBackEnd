using API.Dtos;
using API.ParameterIN;
using AutoMapper;
using Domain.Core.Contracts;
using Domain.Core.Entity;
using Domain.Core.Pagination;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ProductosController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(_mapper.Map<IEnumerable<ProductoDto>>(await _unitOfWork.ProductoRepository.GetAllAsync()));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("/GetPagination")]
        public async Task<IActionResult> GetPagination(int currentPage, int pageSize)
        {
            try
            {
                var totalRecord = await _unitOfWork.ProductoRepository.GetObjectTotalRecords();
                var Data = await _unitOfWork.ProductoRepository.GetObjectByPagination(currentPage, pageSize);
                return Ok( new PaginationModel(currentPage, pageSize, totalRecord, _mapper.Map<IEnumerable<ProductoDto>>(Data)));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("/SearchByString")]
        public async Task<IActionResult> SearchByString(string search, int currentPage, int pageSize)
        {
            try
            {
                var totalRecord = await _unitOfWork.ProductoRepository.GetObjectTotalRecordsBySearch(a => a.NombreProducto.Contains(search));
                var Data = await _unitOfWork.ProductoRepository.GetObjectByPaginationBySearch(a => a.NombreProducto.Contains(search), currentPage, pageSize);
                return Ok(new PaginationModel(currentPage, pageSize, totalRecord, _mapper.Map<IEnumerable<ProductoDto>>(Data)));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // GET api/<ClienteController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                return Ok(_mapper.Map<ProductoDto>(await _unitOfWork.ProductoRepository.GetByIdAsync(id)));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // POST api/<ClienteController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProductoIN value)
        {
            try
            {
                await _unitOfWork.ProductoRepository.SaveAsync(_mapper.Map<Tbl_Productos>(value));
                return Ok(new { Message = "Se ha guardado correctamente." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            finally
            {
                await _unitOfWork.ProductoRepository.SaveChangesAsync();
            }
        }

        // PUT api/<ClienteController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ProductoIN value)
        {
            try
            {
                _unitOfWork.ProductoRepository.Edit(_mapper.Map<Tbl_Productos>(value));
                return Ok(new { Message = "Se ha modificado correctamente." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            finally
            {
                await _unitOfWork.ProductoRepository.SaveChangesAsync();
            }
        }

        // DELETE api/<ClienteController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                _unitOfWork.ProductoRepository.Remove(await _unitOfWork.ProductoRepository.GetByIdAsync(id));
                return Ok(new { Message = "Se ha eliminado correctamente." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            finally
            {
                await _unitOfWork.ProductoRepository.SaveChangesAsync();
            }
        }
    }
}

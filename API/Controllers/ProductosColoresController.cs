using API.Dtos;
using API.ParameterIN;
using AutoMapper;
using Domain.Core.Contracts;
using Domain.Core.Entity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosColoresController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ProductosColoresController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // GET: api/<ClienteController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(_mapper.Map<IEnumerable<ProductoColoresDto>>(await _unitOfWork.ProductoColoresRepository.GetAllAsync()));
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
                return Ok(_mapper.Map<ProductoDto>(await _unitOfWork.ProductoColoresRepository.GetByIdAsync(id)));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // POST api/<ClienteController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProductosColoresIn value)
        {
            try
            {
                var data = await _unitOfWork.ProductoColoresByExpressioinRepository.GetOneViewByFuncAsync(a => a.IDProducto == value.IDProducto && a.IDColor == value.IDColor);
                if (data != null)
                {
                    return BadRequest(new { message = "Este color ya esta registrado."});
                }
                await _unitOfWork.ProductoColoresRepository.SaveAsync(_mapper.Map<Tbl_Productos_Colores>(value));
                return Ok(new { Message = "Se ha guardado correctamente." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            finally
            {
                await _unitOfWork.ProductoColoresRepository.SaveChangesAsync();
            }
        }

        // PUT api/<ClienteController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ProductosColoresIn value)
        {
            try
            {
                _unitOfWork.ProductoColoresRepository.Edit(_mapper.Map<Tbl_Productos_Colores>(value));
                return Ok(new { Message = "Se ha modificado correctamente." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            finally
            {
                await _unitOfWork.ProductoColoresRepository.SaveChangesAsync();
            }
        }

        // DELETE api/<ClienteController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                _unitOfWork.ProductoColoresRepository.Remove(await _unitOfWork.ProductoColoresRepository.GetByIdAsync(id));
                return Ok(new { Message = "Se ha eliminado correctamente." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            finally
            {
                await _unitOfWork.ProductoColoresRepository.SaveChangesAsync();
            }
        }
    }
}

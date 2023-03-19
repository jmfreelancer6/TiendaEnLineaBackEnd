using API.Dtos;
using AutoMapper;
using Domain.Core.Contracts;
using Domain.Core.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColoresController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ColoresController(IMapper mapper, IUnitOfWork unitOfWork)
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
                return Ok(_mapper.Map<IEnumerable<ColoresDto>>(await _unitOfWork.ColoresRepository.GetAllAsync()));
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
                return Ok(_mapper.Map<ColoresDto>(await _unitOfWork.ColoresRepository.GetByIdAsync(id)));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // POST api/<ClienteController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ColoresDto value)
        {
            try
            {
                await _unitOfWork.ColoresRepository.SaveAsync(_mapper.Map<Tbl_Colores>(value));
                return Ok(new { Message = "Se ha guardado correctamente." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            finally
            {
                await _unitOfWork.ColoresRepository.SaveChangesAsync();
            }
        }

        // PUT api/<ClienteController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ColoresDto value)
        {
            try
            {
                _unitOfWork.ColoresRepository.Edit(_mapper.Map<Tbl_Colores>(value));
                return Ok(new { Message = "Se ha modificado correctamente." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            finally
            {
                await _unitOfWork.ColoresRepository.SaveChangesAsync();
            }
        }

        // DELETE api/<ClienteController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                _unitOfWork.ColoresRepository.Remove(await _unitOfWork.ColoresRepository.GetByIdAsync(id));
                return Ok(new { Message = "Se ha eliminado correctamente." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            finally
            {
                await _unitOfWork.ColoresRepository.SaveChangesAsync();
            }
        }
    }
}

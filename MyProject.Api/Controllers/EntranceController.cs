using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyProject.DataAccess.Abstract;
using MyProject.TokenDTOs.DTOs.EntranceDTOs;
using MyProject.Entity.Entities;

namespace MyProject.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EntranceController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly IEntranceRepository _entranceRepository;

        public EntranceController(IEntranceRepository entranceRepository, IMapper mapper)
        {
            _entranceRepository = entranceRepository;
            _mapper = mapper;
        }



        [HttpGet]
        public async Task<ActionResult<ListEntranceDTO>> GetEntrance()
        {
            try
            {

                var result = await _entranceRepository.GetAllAsync();
                var value = _mapper.Map<IList<ListEntranceDTO>>(result);
                return Ok(value);
            }

            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                 "Error retrieving data from the database");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EntranceDetailsDTO>> GetByIdEntranceAsync(Guid id)
        {
            try
            {
                var result = await _entranceRepository.GetByIdAsync(id);
                if (result is null)
                {
                    return NotFound();
                }
                var entranceDto = _mapper.Map<EntranceDetailsDTO>(result);
                return Ok(entranceDto);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }

        }

        [HttpPost]
        public async Task<IActionResult> AddEntrance([FromBody] CreateEntranceDTO createEntranceDTO)
        {
            try
            {
                if (createEntranceDTO is null)
                {
                    return BadRequest();

                }

                var entrance = _mapper.Map<Entrance>(createEntranceDTO);

                await _entranceRepository.AddAsync(entrance);
                return Ok();
                //CreatedAtAction(nameof(GetEntrance), new { id = new Guid() }, entrance);


            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
               "Error creating new employee record");
            }



        }

        [HttpPut("{id}")]
        public async Task<ActionResult> EditEntrance(Guid id, [FromBody] UpdateEntranceDTO updateEntranceDTO)
        {

            var result = await _entranceRepository.GetByIdAsync(updateEntranceDTO.Id);
            if (result != null && id == updateEntranceDTO.Id)
            {
                var updateDto = _mapper.Map<Entrance>(updateEntranceDTO);
                _entranceRepository.Update(updateDto);

                return Ok();
                //CreatedAtRoute(nameof(GetEntrance), new { Id = id }, updateDto);
            }

            return NoContent();
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEntranceAsync(Guid id)
        {
            if (await _entranceRepository.GetByIdAsync(id) != null)
            {
                _entranceRepository.Delete(id);
                return NoContent();
            }

            return NotFound();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Yeryok.API.Data;

namespace Yeryok.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SliderController : ControllerBase          
    {
        private readonly DataContext context;
        private readonly IMapper mapper;

        public SliderController(DataContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet("GetSliders")]
        public async Task<IActionResult> GetSliders()
        {
            var slider = await context.Sliders.ToListAsync();
            return Ok(slider);
        }
    }
}
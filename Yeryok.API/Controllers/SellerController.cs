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
    public class SellerController : ControllerBase
    {
        private readonly DataContext context;
        private readonly IMapper mapper;
        public SellerController(DataContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet("GetSellers")]
        public async Task<IActionResult> GetSellers()
        {
            var sellers = await context.Sellers.ToListAsync();
            return Ok(sellers);
        }
    }
}
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using YadBeYadServerBL.Models;

namespace YadBeYadServer.Controllers
{
    [Route("YadBeYadAPI")]//achi
    [ApiController]
    public class YadBeYadController : ControllerBase
    {
        #region Add connection to the db context using dependency injection
        AhiyaDBContext context;
        public YadBeYadController(AhiyaDBContext context)
        {
            this.context = context;
        }
        #endregion
        [Route("Test")]
        [HttpGet]
        public string Test()
        {
            return "Get bet";
        }
    }
 
}

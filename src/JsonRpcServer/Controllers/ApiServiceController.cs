﻿using Bee.Api.AspNetCore;
using Microsoft.AspNetCore.Mvc;

namespace ApiService.Controllers
{
    /// <summary>
    /// API 服務控制器。
    /// </summary>
    [ApiController]
    [Route("api")]
    [Produces("application/json")]
    public class ApiServiceController : TApiServiceController
    {
    }

}

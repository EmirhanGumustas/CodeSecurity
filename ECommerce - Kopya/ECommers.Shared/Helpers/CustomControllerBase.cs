using ECommers.Shared.ResponseDTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ECommers.Shared.Helpers
{
    public class CustomControllerBase : ControllerBase
    {
        public static IActionResult CreateResponse<T>(ResponseDTO<T> responseDTO)// dönen değer response oldugu için.
                                                                                 // controllerda gelen bilgiler response olarka geldiği için   
        {
            return new ObjectResult(responseDTO)
            {
                StatusCode = responseDTO.StatusCode,
                
            };
        }
       
    }
}

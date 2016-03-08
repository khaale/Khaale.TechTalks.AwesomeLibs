﻿using System.Collections.Generic;
using System.Web.Http;

namespace Khaale.TechTalks.AwesomeLibs.BusinessService.Api.Controllers
{
    public class ItemsController : ApiController
    {
        public IEnumerable<string> Get()
        {
            return new List<string>
            {
                "Item 1"
            };
        }

        public string Get(int id)
        {
            return "Item 1";
        }
    }
}
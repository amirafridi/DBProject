﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DBProject.Models
{
    public class Producer
    {
        int ProducerID { get; set; } // Producer ID. Autogenerated. PK
        string FirstName { get; set; } // Producer's First Name
        string LastName { get; set; } // Producer's Last Name

    }
}
﻿using MusClient.ServiceMusReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusClient
{
    public class MyServiceClient : MusServiceClient
    {
        public MyServiceClient(string ipaddress) : base()
        {
            this.Endpoint.Address = new System.ServiceModel.EndpointAddress($"http://{ipaddress}:8000/MusService/MusService");
        }
    }
}

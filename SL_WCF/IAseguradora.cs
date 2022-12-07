﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL_WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IAseguradora" in both code and config file together.
    [ServiceContract]
    public interface IAseguradora
    {
        [OperationContract]
        SL_WCF.Result Add(ML.Aseguradora aseguradora);

        [OperationContract]
        SL_WCF.Result GetAll();

        [OperationContract]
        SL_WCF.Result GetById();

        [OperationContract]
        SL_WCF.Result Update();

    }
}

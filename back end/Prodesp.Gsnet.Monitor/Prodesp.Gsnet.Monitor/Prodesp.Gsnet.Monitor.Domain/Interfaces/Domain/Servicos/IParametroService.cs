﻿using Prodesp.Gsnet.Monitor.Domain.Entidades;
using Prodesp.Gsnet.Monitor.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prodesp.Gsnet.Monitor.Domain.Interfaces.Domain.Servicos
{
    public interface IParametroService : IService<Parametro>
    {
        List<DadosViewDetalheConsumo> retDadosViewDetalheConsumo();
        
    }
}

﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NicolasAlvarez.Models
{
    public class Venta
    {
        public int Id { get; set; }
        public string Comentarios { get; set; }
        public int Idusuario { get; set; }

        public Venta()
        {
            Id = 0;
            Comentarios = string.Empty;
            Idusuario = 0;
        }
    }
}

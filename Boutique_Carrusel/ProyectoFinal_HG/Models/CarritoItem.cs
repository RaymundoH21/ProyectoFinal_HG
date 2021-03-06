﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoFinal_HG.Models
{
    public class CarritoItem
    {
        private Ropa _producto;
        private int _cantidad;

        public CarritoItem()
        {

        }
        public CarritoItem(Ropa producto, int cantidad, string user)
        {
            this.Producto = producto;
            this.Cantidad = cantidad;
            this.Usuario = user;
        }

        public Ropa Producto { get => _producto; set => _producto = value; }
        public int Cantidad { get => _cantidad; set => _cantidad = value; }
        public string Usuario { get; set; }
    }
}
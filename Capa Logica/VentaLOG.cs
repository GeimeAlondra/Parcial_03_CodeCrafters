﻿using CapaDatos;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Logica
{
    public class VentaLOG
    {
        VentaDAL _VentaDAL;
        public List<Venta> FiltroCodigo(int codigo)
        {
            _VentaDAL = new VentaDAL();
            
            return _VentaDAL.FiltroCodigo(codigo);
        }
        public List<Venta> FiltroNombres(string nombre)
        {
            _VentaDAL = new VentaDAL();

            return _VentaDAL.FiltroNombres(nombre);
        }


        


        public int GuardarVenta(Venta venta)
        {
            _VentaDAL = new VentaDAL();
            return _VentaDAL.Guardar(venta);
        }
        //Metodo que devuelve las ventas realizadas
        public List<Venta> ObtenerVentas()
        {
            _VentaDAL = new VentaDAL();

            return _VentaDAL.ObtenerVentas();
        }
    }

   





}

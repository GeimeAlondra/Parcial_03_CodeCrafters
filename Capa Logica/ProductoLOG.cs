﻿using CapaDatos;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Logica
{
    public class ProductoLOG
    {
        ProductoDAL _ProductoDAL;

        public int GuardarProducto(Producto producto, int id = 0, bool esActualizacion = false)
        {
            _ProductoDAL = new ProductoDAL();

            return _ProductoDAL.Guardar(producto, id, esActualizacion);
        }
        
        public Producto ObtenerProductoPorId(int codigo)
        {
            _ProductoDAL = new ProductoDAL();

            return _ProductoDAL.LeerPorId(codigo);
        }
        

        public List<Producto> ObtenerProductos(bool inactivos = false)
        {
            _ProductoDAL = new ProductoDAL();

            return _ProductoDAL.Leer(inactivos);
        }

        public List<Producto> ObtenerProductosConExistencias(bool inactivos = false)
        {
            _ProductoDAL = new ProductoDAL();

            return _ProductoDAL.ObtenerProductosConExistencias(inactivos);
        }

        //obtner lo del combobox
        public List<Categoria> ObtenerCategoria()
        {
            _ProductoDAL = new ProductoDAL();

            return _ProductoDAL.ObtenerCategorias();
        }

        public List<Marca> ObtenerMarca()
        {
            _ProductoDAL = new ProductoDAL();

            return _ProductoDAL.ObtenerMarcas();
        }

        public List<Proveedor> ObtenerProveedor()
        {
            _ProductoDAL = new ProductoDAL();

            return _ProductoDAL.ObtenerProveedores();
        }

        public int ActualizarProducto(Producto producto, int id, bool esActualizacion)
        {
            _ProductoDAL = new ProductoDAL();

            return _ProductoDAL.Guardar(producto, id, esActualizacion);
        }

        public int EliminarProducto(int id)
        {
            _ProductoDAL = new ProductoDAL();

            return _ProductoDAL.Eliminar(id);

        }

        public List<Producto> FiltroCategoria(int categoriaValue,bool inactivos = false)
        {
            _ProductoDAL = new ProductoDAL();

            return _ProductoDAL.FiltroCategorias(categoriaValue,inactivos);
        }

        public List<Producto> FiltroMarca(int categoriaValue, bool inactivos = false)
        {
            _ProductoDAL = new ProductoDAL();

            return _ProductoDAL.FiltroMarca(categoriaValue, inactivos);
        }

        public List<Producto> FiltroProveedor(int categoriaValue, bool inactivos = false)
        {
            _ProductoDAL = new ProductoDAL();

            return _ProductoDAL.FiltroProveedor(categoriaValue, inactivos);
        }

         public List<Producto> FiltroNombre(string nombre, bool inactivos = false)
        {
            _ProductoDAL = new ProductoDAL();

            return _ProductoDAL.FiltroNombre(nombre, inactivos);
        }

        public int DescontarStock(int productoId, int cantidad)
        {
            _ProductoDAL = new ProductoDAL();
            return _ProductoDAL.DescontarProductos(productoId, cantidad);
        }
       
    }
}

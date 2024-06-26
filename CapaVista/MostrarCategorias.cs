﻿using Capa_Logica;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaVista
{
    public partial class MostrarCategorias : Form
    {
        CategoriaLOG _CategoriaLOG;
        int _id = 0;
        public MostrarCategorias()
        {
            InitializeComponent();
            categoriaBindingSources.MoveLast();
            categoriaBindingSources.AddNew();
            CargarCategoriaEnDataGridView();
        }

        private void btnGuardarCategoria_Click(object sender, EventArgs e)
        {
            GuardarCategoria();
        }



        private void GuardarCategoria()
        {
            _CategoriaLOG = new CategoriaLOG();
            try
            {

                if (!ValidarCampos())
                {
                    return; // Si los campos no son válidos, salir del método
                }


                int resultado;
                //debemo indicar si es una actualizacion o es un nuevo producto
                if (_id > 0)
                {
                    categoriaBindingSources.EndEdit();
                    Categoria categoria;
                    categoria = (Categoria)categoriaBindingSources.Current;
                    resultado = _CategoriaLOG.ActualizarCategoria(categoria, _id,true);
                    if (resultado > 0)
                    {
                        txtNombre.Clear();
                        MessageBox.Show("Categoria actualizada con exito", "Tienda | Registro Categoria",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnActualizarCategoria.Visible = false;
                        btnGuardarCategoria.Visible = true;
                        CargarCategoriaEnDataGridView();
                        
                    }
                    else
                    {
                        MessageBox.Show("No se logro actualizar la Categoria", "Tienda | Registro Categoria",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }


                }
                else
                {
                    categoriaBindingSources.EndEdit();

                    Categoria categoria;
                    categoria = (Categoria)categoriaBindingSources.Current;

                    resultado = _CategoriaLOG.GuardarCategoria(categoria);

                    if (resultado > 0)
                    {
                        txtNombre.Clear();
                        MessageBox.Show("Categoria agregada con exito", "Tienda | Registro Categoria",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarCategoriaEnDataGridView();
                    }
                    else
                    {
                        MessageBox.Show("No se logro guardar la Categoria", "Tienda | Registro Categoria",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrio un Error: {ex}", "Tienda | Registro Categoria",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }
        private void CargarCategoriaEnDataGridView()
        {
            _CategoriaLOG = new CategoriaLOG();           
            dvgCategorias.DataSource = _CategoriaLOG.ObtenerCategorias();          
        }

        private bool ValidarCampos()
        {

            bool camposValidos = true;
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                MessageBox.Show("Se requiere el nombre de la Categoria \n !Este campo es obligatorio!", "Tienda | Registro Categoria",
                       MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //txtNombreProveedor.Focus();
                plinea.BackColor = Color.LightCoral;
                camposValidos = false;
            }
            return camposValidos;

        }

        private void dvgCategorias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dvgCategorias.Columns[e.ColumnIndex].Name == "Editar")
            {
                //Esta linea de abajo creo que no esta haciendo nada pero me da miedo borrarla XD
                _id= Convert.ToInt32(dvgCategorias.CurrentRow.Cells["CategoriaId"].Value.ToString());
                //
                
                CargarDatos(_id);
                btnGuardarCategoria.Visible = false;
                btnActualizarCategoria.Visible = true;

            }

            if (dvgCategorias.Columns[e.ColumnIndex].Name == "Eliminar")
            {
                _id = Convert.ToInt32(dvgCategorias.CurrentRow.Cells["CategoriaId"].Value.ToString());
                EliminarCategoria(_id);
            }
        }


        private void CargarDatos(int id)
        {
            _CategoriaLOG = new CategoriaLOG();

            categoriaBindingSources.DataSource = _CategoriaLOG.ObtenerPorId(id);

        }

        private void EliminarCategoria(int id)
        {
            _CategoriaLOG = new CategoriaLOG();
            int resultado = _CategoriaLOG.EliminarCategoria(id);
            if (resultado > 0)
            {
                MessageBox.Show("Categoria eliminada con exito", "Tienda | Registro Categoria",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarCategoriaEnDataGridView();
            }
            else
            {
                MessageBox.Show("No se logro eliminar la Categoria", "Tienda | Registro Categoria",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            GuardarCategoria();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtNombre_Enter(object sender, EventArgs e)
        {
            plinea.BackColor = SystemColors.Window;
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

    }
}

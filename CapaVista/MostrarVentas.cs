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
    public partial class MostrarVentas : Form
    {
        VentaLOG _VentaLOG;
        int _id = 0;

        public MostrarVentas()
        {
            InitializeComponent();
            CargarDatagridView();
        }

        public void CargarDatagridView()
        {
            _VentaLOG = new VentaLOG();
            dgvVentas.DataSource = _VentaLOG.ObtenerVentas();
        }

        private void dgvVentas_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (dgvVentas.Columns[e.ColumnIndex].Name == "Cliente") // Reemplaza "Categoria" por el nombre real de la columna de la categoría
                {
                    var cliente = dgvVentas.Rows[e.RowIndex].Cells[e.ColumnIndex].Value as Cliente; // Reemplaza "Categoria" por el nombre de la clase de la categoría
                    if (cliente != null)
                    {
                        e.Value = cliente.ClienteNombre +" "+cliente.ClienteApellido;
                    }
                }
                else if (dgvVentas.Columns[e.ColumnIndex].Name == "EmpleadoNombre") // Reemplaza "Marca" por el nombre real de la columna de la marca
                {
                    var empleado = dgvVentas.Rows[e.RowIndex].Cells[e.ColumnIndex].Value as Empleado; // Reemplaza "Marca" por el nombre de la clase de la marca
                    if (empleado != null)
                    {
                        e.Value = empleado.EmpleadoNombre+" "+empleado.EmpleadoApellido;
                    }
                }
               
            }
        }

        private void dgvVentas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvVentas.Columns[e.ColumnIndex].Name.Equals("Informacion"))
            {
                int id = Convert.ToInt32(dgvVentas.CurrentRow.Cells["VentaId"].Value.ToString());
                

                Reportes.ReporteVentas objeReporte = new Reportes.ReporteVentas(id);
                objeReporte.ShowDialog();

            }
        }

       

        private void AbrirFormulario2()
        {
            RegistroVenta objRegistrarVenta = new RegistroVenta(_id);
            objRegistrarVenta.LlenarDataGridViewRequested += (sender, args) =>
            {
                LlenarDataGridView();
            };
            objRegistrarVenta.ShowDialog();
        }

        private void LlenarDataGridView()
        {
            CargarDatagridView();
        }

        private void btnAgregarVenta_Click(object sender, EventArgs e)
        {
            _id = 0;
            AbrirFormulario2();
            CargarDatagridView();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }



        }

        private void FiltroCodigo()
        {
            if (!string.IsNullOrEmpty(txtCodigo.Text))
            {
                int codigo;
                if (int.TryParse(txtCodigo.Text, out codigo))
                {
                    dgvVentas.DataSource = _VentaLOG.FiltroCodigo(codigo);
                }
                else
                {
                    MessageBox.Show("Digite un código válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


        }


        private void FiltroNombre()
        {
            string nombre = txtNombre.Text;
            dgvVentas.DataSource = _VentaLOG.FiltroNombres(nombre);


        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            FiltroCodigo();
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            FiltroNombre();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }       
}

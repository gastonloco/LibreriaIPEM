﻿
using Entidades;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDato;
namespace Video_Club
{
    public partial class Devolucion : Form
    {
        int posicion = 0;
        public Devolucion()
        {
            InitializeComponent();
            CargarTablaPrestamo();
        }

        void CargarTablaPrestamo()
        {
            Class1 conexion = new Class1();
            MySqlConnection con = new MySqlConnection(conexion.Cadena);
            con.Open();
            string sql = "select idPrestamo as ID,idUsuario as ID_Usu,NombreUsuario as Nombre,ApellidoUsuario as Apellido,idLibro as ID_Lib,titulo as Titulo,fechaSalida as Salida,fechaEntrega as Entrega, mora as Mora_$,stock as Stock from prestamo INNER JOIN usuario On prestamo.idUsuario = usuario.id_usuario INNER JOIN libros On prestamo.idLibro = libros.idLibros where condicion=0;";
            MySqlDataAdapter da = new MySqlDataAdapter(sql, conexion.Cadena);
            DataTable dt = new DataTable();
            con.Close();
            da.Fill(dt);
            dgDevolucion.DataSource = dt;
            dgDevolucion.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        private void btnDeBuscar_Click(object sender, EventArgs e)
        {
            Class1 conexion = new Class1();
            MySqlConnection con = new MySqlConnection(conexion.Cadena);
            con.Open();
            string sql = "select idPrestamo as ID,idUsuario as ID_Usu,NombreUsuario as Nombre,ApellidoUsuario as Apellido,idLibro as ID_Lib,titulo as Titulo,fechaSalida as Salida,fechaEntrega as Entrega, mora as Mora_$,stock as Stock from prestamo INNER JOIN usuario On prestamo.idUsuario = usuario.id_usuario INNER JOIN libros On prestamo.idLibro = libros.idLibros where prestamo.idPrestamo ='" + txtDevolver.Text + "' || usuario.NombreUsuario LIKE '%" + txtDevolver.Text + "%' || usuario.ApellidoUsuario LIKE '%" + txtDevolver.Text + "%' || libros.titulo LIKE '%" + txtDevolver.Text + "%';";
            MySqlDataAdapter da = new MySqlDataAdapter(sql, conexion.Cadena);
            DataTable dt = new DataTable();
            con.Close();
            da.Fill(dt);
            dgDevolucion.DataSource = dt;
            dgDevolucion.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        private void btn_registrar_Click(object sender, EventArgs e)
        {
            PrestamoClass prestamoObj = new PrestamoClass();
            prestamoObj.FechaDevolucion = dtFechaDevolucion.Text;
            DateTime fEntrega= Convert.ToDateTime(prestamoObj.FechaEntrega);
            DateTime fDevolucion = Convert.ToDateTime(prestamoObj.FechaDevolucion);
            TimeSpan tspan = fDevolucion - fEntrega;
            double difDias = tspan.Days;  // mostramos la diferencias de dias
            if(difDias > 0) {
                difDias = difDias * 10;
                Class1 conexion = new Class1();
                string sql = "update libros set stock='" + prestamoObj.Stock + "', id_estado=1  where idLibros='" + prestamoObj.IdLibro + "';";
                MySqlConnection con = new MySqlConnection(conexion.Cadena);
                con.Open();
                MySqlCommand comando = new MySqlCommand(sql, con);
                comando.ExecuteNonQuery();
                con.Close();

                string sql2 = "update prestamo set mora='" + difDias + "',fechaDevolucion='" + prestamoObj.FechaDevolucion + "', condicion=1  where idPrestamo='" + prestamoObj.IdPrestamo + "';";
                MySqlConnection con2 = new MySqlConnection(conexion.Cadena);
                con2.Open();
                MySqlCommand comando2 = new MySqlCommand(sql2, con2);
                comando2.ExecuteNonQuery();
                //MessageBox.Show("Los dias "+ difDias);
                con2.Close();
                

                string sql3 = "update usuario set estadoUsuario=1  where id_usuario='" + prestamoObj.IdUsuario + "';";
                MySqlConnection con3 = new MySqlConnection(conexion.Cadena);
                con3.Open();
                MySqlCommand comando3 = new MySqlCommand(sql3, con3);
                comando3.ExecuteNonQuery();
                //MessageBox.Show("Los dias " + difDias);
                con3.Close();

                Dialogo FormDialog = new Dialogo();
                FormDialog.ShowDialog();
            } 
            else {

                //prestamoObj.Condicion = Convert.ToBoolean(0);
                Class1 conexion = new Class1();
                string sql = "update libros set stock='" + prestamoObj.Stock + "', id_estado=1  where idLibros='" + prestamoObj.IdLibro + "';";
            MySqlConnection con = new MySqlConnection(conexion.Cadena);
            con.Open();
            MySqlCommand comando = new MySqlCommand(sql, con);
            comando.ExecuteNonQuery();
            con.Close();

            string sql2 = "update prestamo set mora='" + difDias + "',fechaDevolucion='" + prestamoObj.FechaDevolucion + "', condicion=1  where idPrestamo='" + prestamoObj.IdPrestamo + "';";
            MySqlConnection con2 = new MySqlConnection(conexion.Cadena);
            con2.Open();
            MySqlCommand comando2 = new MySqlCommand(sql2, con2);
            comando2.ExecuteNonQuery();
                MessageBox.Show("Los dias " + difDias);
                con2.Close();
            Dialogo FormDialog = new Dialogo();
            FormDialog.ShowDialog();
            }
            CargarTablaPrestamo();
        }

        private void dgDevolucion_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            PrestamoClass prestamoObj = new PrestamoClass();
            posicion = dgDevolucion.CurrentRow.Index;
            prestamoObj.IdPrestamo = int.Parse(dgDevolucion[0, posicion].Value.ToString());
            prestamoObj.IdUsuario = int.Parse(dgDevolucion[1, posicion].Value.ToString());
            prestamoObj.IdLibro = int.Parse(dgDevolucion[4, posicion].Value.ToString());
            prestamoObj.FechaEntrega = dgDevolucion[7, posicion].Value.ToString();
            prestamoObj.Stock = int.Parse(dgDevolucion[9, posicion].Value.ToString()) + 1;
          
        }

        private void btnDeRefrescar_Click(object sender, EventArgs e)
        {
            CargarTablaPrestamo();
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            Dialogo FormDialog = new Dialogo();
            FormDialog.ShowDialog();
        }
    }
}

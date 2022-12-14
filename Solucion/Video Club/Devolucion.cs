
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

namespace Video_Club
{
    public partial class Devolucion : Form
    {
        int posicion = 0;
        public Devolucion()
        {
            InitializeComponent();
            CargarTablaPrestamo();
            dgDevolucion.Columns[1].Visible= false;
            dgDevolucion.Columns[4].Visible = false;
        }

        void CargarTablaPrestamo()
        {
            //Conexion conexion = new Conexion();

            string cadena = "Server=localhost;Database=libreria_bd;Uid=root;Pwd=13231414";
            MySqlConnection con = new MySqlConnection(cadena);
            con.Open();
            string sql = "select idPrestamo as COD,idUsuario as ID_Usu,NombreUsuario as Nombre,ApellidoUsuario as Apellido,idLibro as ID_Lib,titulo as Titulo,fechaSalida as Salida,fechaEntrega as Entrega, mora as Mora_$,stock as Stock from prestamo INNER JOIN usuario On prestamo.idUsuario = usuario.id_usuario INNER JOIN libros On prestamo.idLibro = libros.idLibros where condicion=0;";
            MySqlDataAdapter da = new MySqlDataAdapter(sql, cadena);
            DataTable dt = new DataTable();
            con.Close();
            da.Fill(dt);
            dgDevolucion.DataSource = dt;
            dgDevolucion.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        private void btnDeBuscar_Click(object sender, EventArgs e)
        {

            if (txtDevolver.Text != "")
            { 
            string cadena = "Server=localhost;Database=libreria_bd;Uid=root;Pwd=13231414";
            MySqlConnection con = new MySqlConnection(cadena);
            con.Open();
            string sql = "select idPrestamo as COD,idUsuario as ID_Usu,NombreUsuario as Nombre,ApellidoUsuario as Apellido,idLibro as ID_Lib,titulo as Titulo,fechaSalida as Salida,fechaEntrega as Entrega, mora as Mora_$,stock as Stock from prestamo INNER JOIN usuario On prestamo.idUsuario = usuario.id_usuario INNER JOIN libros On prestamo.idLibro = libros.idLibros where prestamo.condicion=0 AND prestamo.idPrestamo ='" + txtDevolver.Text + "' || prestamo.condicion=0 AND usuario.NombreUsuario LIKE '%" + txtDevolver.Text + "%' || prestamo.condicion=0 AND usuario.ApellidoUsuario LIKE '%" + txtDevolver.Text + "%' || prestamo.condicion=0 AND libros.titulo LIKE '%" + txtDevolver.Text + "%';";
            MySqlDataAdapter da = new MySqlDataAdapter(sql, cadena);
            DataTable dt = new DataTable();
            con.Close();
            da.Fill(dt);
            dgDevolucion.DataSource = dt;
            dgDevolucion.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
        }
        private void btn_registrar_Click(object sender, EventArgs e)
        {
            PrestamoClass prestamoObj = new PrestamoClass();
            prestamoObj.FechaDevolucion = dtFechaDevolucion.Value;

            //MessageBox.Show("resultado " + (prestamoObj.FechaDevolucion).ToString("yyyy,MM,dd"));

            DateTime fEntrega= Convert.ToDateTime(prestamoObj.FechaEntrega);
            DateTime fDevolucion = Convert.ToDateTime(prestamoObj.FechaDevolucion);
            TimeSpan tspan = fDevolucion - fEntrega;
            double difDias = tspan.Days;  // mostramos la diferencias de dias
            if(difDias > 0) {
                difDias = difDias * 10;
                //Conexion conexion = new Conexion();

                string cadena = "Server=localhost;Database=libreria_bd;Uid=root;Pwd=13231414";
                string sql = "update libros set stock='" + prestamoObj.Stock + "', id_estado=1  where idLibros='" + prestamoObj.IdLibro + "';";
                MySqlConnection con = new MySqlConnection(cadena);
                con.Open();
                MySqlCommand comando = new MySqlCommand(sql, con);
                comando.ExecuteNonQuery();
                con.Close();

                string sql2 = "update prestamo set mora='" + difDias + "',fechaDevolucion='" + (prestamoObj.FechaDevolucion).ToString("yyyy,MM,dd") + "', condicion=1  where idPrestamo='" + prestamoObj.IdPrestamo + "';";
                MySqlConnection con2 = new MySqlConnection(cadena);
                con2.Open();
                MySqlCommand comando2 = new MySqlCommand(sql2, con2);
                comando2.ExecuteNonQuery();
                //MessageBox.Show("Los dias "+ difDias);
                con2.Close();
                

                string sql3 = "update usuario set estadoUsuario=1  where id_usuario='" + prestamoObj.IdUsuario + "';";
                MySqlConnection con3 = new MySqlConnection(cadena);
                con3.Open();
                MySqlCommand comando3 = new MySqlCommand(sql3, con3);
                comando3.ExecuteNonQuery();
                //MessageBox.Show("Los dias " + difDias);
                con3.Close();

                Dialogo FormDialog = new Dialogo();
                FormDialog.ShowDialog();
            } 
            else {

                string cadena = "Server=localhost;Database=libreria_bd;Uid=root;Pwd=13231414";
                string sql = "update libros set stock='" + prestamoObj.Stock + "', id_estado=1  where idLibros='" + prestamoObj.IdLibro + "';";
            MySqlConnection con = new MySqlConnection(cadena);
            con.Open();
            MySqlCommand comando = new MySqlCommand(sql, con);
            comando.ExecuteNonQuery();
            con.Close();

            string sql2 = "update prestamo set mora='" + difDias + "',fechaDevolucion='" + (prestamoObj.FechaDevolucion).ToString("yyyy,MM,dd") + "', condicion=1  where idPrestamo='" + prestamoObj.IdPrestamo + "';";
            MySqlConnection con2 = new MySqlConnection(cadena);
            con2.Open();
            MySqlCommand comando2 = new MySqlCommand(sql2, con2);
            comando2.ExecuteNonQuery();
               // MessageBox.Show("Los dias " + difDias);
                con2.Close();
            Dialogo FormDialog = new Dialogo();
            FormDialog.ShowDialog();
            }
            CargarTablaPrestamo();
        }

        private void dgDevolucion_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            PrestamoClass prestamoObj = new PrestamoClass();
            UsuarioClass usuarioObj = new UsuarioClass();
            LibroClass libroObj = new LibroClass();
            posicion = dgDevolucion.CurrentRow.Index;
            prestamoObj.IdPrestamo = int.Parse(dgDevolucion[0, posicion].Value.ToString());
            prestamoObj.IdUsuario = int.Parse(dgDevolucion[1, posicion].Value.ToString());
            usuarioObj.Nombre1 = dgDevolucion[2, posicion].Value.ToString();
            usuarioObj.Apellido1 = dgDevolucion[3, posicion].Value.ToString();
            prestamoObj.IdLibro = int.Parse(dgDevolucion[4, posicion].Value.ToString());
            libroObj.Titulo = dgDevolucion[5, posicion].Value.ToString();
            prestamoObj.FechaEntrega = DateTime.Parse(dgDevolucion[7, posicion].Value.ToString());
            prestamoObj.Stock = int.Parse(dgDevolucion[9, posicion].Value.ToString()) + 1;

            textNombre.Text = usuarioObj.Nombre1;
            textApellido.Text = usuarioObj.Apellido1;
            textDni.Text = libroObj.Titulo;

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

        private void pnl_opciones_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

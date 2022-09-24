using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using MySql.Data.MySqlClient;
using System.Threading;


namespace Ferreteria1975
{

    public partial class Ferreteria1975 : Form
    {
        string moneda, usuario, contraseña;
        int x;
        decimal ganancia;
        int idCompra;
        int idUsuario;
        int stockTemporal;
        bool maximized;
        decimal precioTemporal;
        bool insertar, modificar;
        bool mouseDown;
        string editar = "";
        private Point lastLocation;

        bool login, admin, abriendo;
        string genero;
        static string conexion = "SERVER=127.0.0.1;PORT=3306;DATABASE=dbferreteria1975;UID=root;PASSWORDS=;";
        MySqlConnection cn = new MySqlConnection(conexion);
        public Ferreteria1975()
        {
            InitializeComponent();
        }

        private void Ferreteria1975_Load(object sender, EventArgs e)
        {
            tabControl1.TabPages[0].BackColor = Color.Black;
            llenarCmbBusquedaCompra();

            panel13.Visible = false;
            

            txtUsuario.Select();
            llenarDg1();
            llenarDg2();
            ajustarDg2();

            abriendo = true;


        }

        ////////////////////////////      IMPRESIÓN DE LOS DATAGRIDS

        private void llenarDg1()
        {
            dataGridView1.Rows.Clear();

            string query = "SELECT * FROM preciosystock";
            MySqlConnection databaseConnection = new MySqlConnection(conexion);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;
            databaseConnection.Open();
            reader = commandDatabase.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    if (cmbBusquedaCompra.Text.Contains (reader.GetString(1)))
                    {
                        string[] row = { reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), Convert.ToString(reader.GetDecimal(2) * 1.4m) };
                        var listViewItem = new ListViewItem(row);
                        for (x = 0; x < 10000; x++)
                        {
                            if (Convert.ToInt32(reader.GetString(0)) == x)
                            {
                                dataGridView1.Rows.Add(row);
                            }

                            ganancia = reader.GetDecimal(2) * 1.4m;


                        }
                    }
                    else if (cmbBusquedaCompra.Text == "")
                    {
                        string[] row = { reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), Convert.ToString(reader.GetDecimal(2) * 1.4m) };
                        var listViewItem = new ListViewItem(row);
                        for (x = 0; x < 10000; x++)
                        {
                            if (Convert.ToInt32(reader.GetString(0)) == x)
                            {
                                dataGridView1.Rows.Add(row);
                            }

                            ganancia = reader.GetDecimal(2) * 1.4m;


                        }
                    }
                        

                                        
                    //ganancia =(Convert.ToDecimal(reader.GetDecimal) * 1.4);
                   
                }
            }
        }

        private void llenarDg2()
        {
            dataGridView2.Rows.Clear();

            string query = "SELECT * FROM preciosystock";
            MySqlConnection databaseConnection = new MySqlConnection(conexion);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;
            databaseConnection.Open();
            reader = commandDatabase.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    //textBox1.Text = reader.GetString(2);
                    string[] row = { reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), Convert.ToString(reader.GetDecimal(2) * 1.4m) };
                    var listViewItem = new ListViewItem(row);
                    for (x = 0; x < 10000; x++)
                    {
                        if (Convert.ToInt32(reader.GetString(0)) == x)
                        {
                            dataGridView2.Rows.Add(row);
                        }
                    }
                }
            }
            dataGridView2.ClearSelection();
            //double total ganancia
            //dataGridView1.cell
        }

        private void ajustarDg2()
        {
            DataGridViewColumn idCol = dataGridView2.Columns[0];
            idCol.Width = 40;

            DataGridViewColumn descripcionCol = dataGridView2.Columns[1];
            descripcionCol.Width = 300;

            DataGridViewColumn micostoCol = dataGridView2.Columns[2];
            micostoCol.Width = 100;

            DataGridViewColumn monedaCol = dataGridView2.Columns[3];
            monedaCol.Width = 32;

            DataGridViewColumn stockCol = dataGridView2.Columns[4];
            stockCol.Width = 86;

            DataGridViewColumn preciocongananciaCol = dataGridView2.Columns[5];
            stockCol.Width = 86;
        }

        ////////////////////////////       COMANDOS SQL

        private void ingresarUsuario()
        {
            string query = "SELECT * FROM usuarios";
            MySqlConnection databaseConnection = new MySqlConnection(conexion);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;
            databaseConnection.Open();
            reader = commandDatabase.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    for (x = 0; x < 10000; x++)
                    {
                        if (Convert.ToInt32(reader.GetString(0)) == x)
                        {
                            if (txtUsuario.Text.ToString() == reader.GetString(1))
                            {
                                if (txtContraseña.Text.ToString() == reader.GetString(2))
                                {
                                    groupBox6.Visible = true;
                                    panel3.Visible = false;
                                    panel12 .Visible = false;
                                    panel13.Visible = false;

                                    label18.Text = "Usuario: " + reader.GetString(1);
                                    usuario = reader.GetString(1);
                                    lblBienvenido.Text = "Bienvenido, " + reader.GetString(4) + "!";
                                    lblNombre.Text = reader.GetString(4);
                                    lblApellido.Text = reader.GetString(5);
                                    contraseña = reader.GetString(2);
                                    lblUsuario.Text = reader.GetString(1);
                                    label18.Text = reader.GetString(4);
                                    lblContraseña.Text = reader.GetString(2);
                                    txtDni.Text = reader.GetString(7);
                                    txtSexo.Text = reader.GetString(6);
                                    idUsuario = reader.GetInt32(0);

                                    groupBox6.Visible = false;
                                    panel13.Visible = true;

                                    login = true;

                                    if (reader.GetString(3) == "si")
                                    {
                                        admin = true;
                                    }

                                    usuario = txtUsuario.Text;
                                    contraseña = txtContraseña.Text;

                                    txtContraseña.Clear();
                                    txtUsuario.Clear();

                                }

                            }



                        }
                    }
                }
            }

            databaseConnection.Close();
        }

        private void usuariosInsert()
        {

            string query = "INSERT INTO `usuarios`(`usuario`, `contraseña`, `nombre`, `apellido`, `sexo`, `dni`) VALUES ('" + textBox3.Text + "','" + textBox4.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + genero + "','" + maskedTextBox1.Text + "')";
            MySqlConnection databaseConnection = new MySqlConnection(conexion);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;
            databaseConnection.Open();
            reader = commandDatabase.ExecuteReader();
        }

        private void preciosystockInsert()
        {
            string query = "INSERT INTO `preciosystock`(`DESCRIPCION`, `MICOSTO`, `$`, `STOCK`) VALUES ('" + txtDescripcion.Text + "','" + txtMiCosto.Text + "','" + moneda + "','" + Convert.ToInt32(txtStock.Text) + "')";
            MySqlConnection databaseConnection = new MySqlConnection(conexion);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;
            databaseConnection.Open();
            reader = commandDatabase.ExecuteReader();
        }

        private void preciosystockDelete()
        {
            string query = "DELETE FROM `preciosystock` WHERE id=" + Convert.ToInt32(cmbEliminar.Text);
            MySqlConnection databaseConnection = new MySqlConnection(conexion);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;
            databaseConnection.Open();
            reader = commandDatabase.ExecuteReader();
        }

        private void preciosystockUpdate()
        {

            string query = "UPDATE `preciosystock` SET `DESCRIPCION`= '" + txtDescripcion.Text + "',`MICOSTO`= '" + txtStock.Text + "',`$`= '" + moneda + "',`STOCK`= '" + Convert.ToInt32(txtStock.Text) + "' WHERE id =" + Convert.ToInt32(cmbModificar.Text);
            MySqlConnection databaseConnection = new MySqlConnection(conexion);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;
            databaseConnection.Open();
            reader = commandDatabase.ExecuteReader();


        }


        private void usuariosUpdateNombre()
        {
            string query = "UPDATE `usuarios` SET `nombre`= '" + textBox1.Text + "' WHERE id =" + idUsuario;
            MySqlConnection databaseConnection = new MySqlConnection(conexion);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;
            databaseConnection.Open();
            reader = commandDatabase.ExecuteReader();
        }

        private void usuariosUpdateApellido()
        {
            string query = "UPDATE `usuarios` SET `apellido`= '" + textBox1.Text + "' WHERE id =" + idUsuario;
            MySqlConnection databaseConnection = new MySqlConnection(conexion);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;
            databaseConnection.Open();
            reader = commandDatabase.ExecuteReader();
        }

        private void usuariosUpdateUsuario()
        {
            string query = "UPDATE `usuarios` SET `usuario`= '" + textBox8.Text + "' WHERE id =" + idUsuario;
            MySqlConnection databaseConnection = new MySqlConnection(conexion);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;
            databaseConnection.Open();
            reader = commandDatabase.ExecuteReader();
        }

        private void usuariosUpdateContraseña()
        {
            string query = "UPDATE `usuarios` SET `contraseña`= '" + textBox8.Text + "' WHERE id =" + idUsuario;
            MySqlConnection databaseConnection = new MySqlConnection(conexion);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;
            databaseConnection.Open();
            reader = commandDatabase.ExecuteReader();
        }

        private void usuariosUpdateGenero()
        {
            string query = "UPDATE `usuarios` SET `sexo`= '" + genero + "' WHERE id =" + idUsuario;
            MySqlConnection databaseConnection = new MySqlConnection(conexion);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;
            databaseConnection.Open();
            reader = commandDatabase.ExecuteReader();
        }

        private void usuariosUpdateDocumento()
        {
            string query = "UPDATE `usuarios` SET `dni`= '" + textBox2.Text + "' WHERE id =" + idUsuario;
            MySqlConnection databaseConnection = new MySqlConnection(conexion);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;
            databaseConnection.Open();
            reader = commandDatabase.ExecuteReader();
        }


        ////////////////////////////       COMANDOS DE ADMINISTRACIÓN


        private void btnInsertar_Click_1(object sender, EventArgs e)
        {
            insertar = true; modificar = false;

            btnInsertar.Visible = false; btnVolver.Visible = true;
            btnModificar.Visible = false; cmbEliminar.Visible = false;
            btnEliminar.Visible = false; cmbModificar.Visible = false;

            txtDescripcion.Visible = true; lblDescripcion.Visible = true;
            txtMiCosto.Visible = true; lblMiCosto.Visible = true;
            txtStock.Visible = true; lblStock.Visible = true;
            lblId.Visible = false; lblId2.Visible = false;
            btnGuardar.Visible = true; RbtnARS.Visible = true; RbtonUSD.Visible = true;
        }

        private void btnModificar_Click_1(object sender, EventArgs e)
        {
            if (cmbModificar.Text == "")
            {
                MessageBox.Show("Tenes que ingresar la id primero");
            }
            else
            {
                insertar = false; modificar = true;

                btnInsertar.Visible = false; btnVolver.Visible = true;
                btnModificar.Visible = false; cmbEliminar.Visible = false;
                btnEliminar.Visible = false; cmbModificar.Visible = false;

                txtDescripcion.Visible = true; lblDescripcion.Visible = true;
                txtMiCosto.Visible = true; lblMiCosto.Visible = true;
                txtStock.Visible = true; lblStock.Visible = true;
                lblId.Visible = false; lblId2.Visible = false;
                btnGuardar.Visible = true; RbtnARS.Visible = true; RbtonUSD.Visible = true;
            }
        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show("Esta seguro que desea eliminar este objeto?", "Confirmación de eliminación", buttons);
            if (result == DialogResult.Yes)
            {
                if (cmbModificar.Text == "")
                {
                    MessageBox.Show("Tenes que ingresar la id primero");
                }
                else
                {
                    preciosystockDelete();
                    llenarDg2();
                }
            }
        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            if (insertar == true)
            {
                dataGridView2.Rows.Clear();
                preciosystockInsert();
            }
            else if (modificar)
            {
                dataGridView2.Rows.Clear();
                preciosystockUpdate();

            }

            llenarDg1();
            llenarDg2();
        }

        private void btnVolver_Click_1(object sender, EventArgs e)
        {
            btnInsertar.Visible = true; btnVolver.Visible = false;
            btnModificar.Visible = true; cmbModificar.Visible = true;
            btnEliminar.Visible = true; cmbEliminar.Visible = true;

            txtDescripcion.Visible = false; lblDescripcion.Visible = false;
            txtMiCosto.Visible = false; lblMiCosto.Visible = false;
            txtStock.Visible = false; lblStock.Visible = false;
            lblId.Visible = true; lblId2.Visible = true;
            btnGuardar.Visible = false; RbtnARS.Visible = false; RbtonUSD.Visible = false;
        }

        ///////////////////////////        ELECCION DE MONEDA

        private void RbtnARS_CheckedChanged_1(object sender, EventArgs e)
        {
            moneda = "ARS";
        }

        private void RbtonUSD_CheckedChanged_1(object sender, EventArgs e)
        {
            moneda = "USD";
        }

        ///////////////////////////        EXCEPCIONES NUMERALES

        private void txtMiCosto_KeyPress_2(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;

            }


        }

        private void cmbModificar_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;

            }
        }

        private void cmbEliminar_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;

            }
        }

        //////////////////////////         ANIMACIONES

        private void label9_MouseMove_1(object sender, MouseEventArgs e)
        {
            label9.Font = new Font(label9.Font, FontStyle.Underline);
        }

        private void label9_MouseLeave_1(object sender, EventArgs e)
        {
            label9.Font = new Font(label9.Font, FontStyle.Regular);
        }

        private void label9_Click_1(object sender, EventArgs e)
        {
            panel12.Visible = false;
            panel3.Visible = true;
        }

        private void label5_MouseMove_1(object sender, MouseEventArgs e)
        {
            label5.Font = new Font(label5.Font, FontStyle.Underline);
        }

        private void label5_MouseLeave_1(object sender, EventArgs e)
        {
            label5.Font = new Font(label5.Font, FontStyle.Regular);
        }

        private void label5_Click_1(object sender, EventArgs e)
        {
            panel12.Visible = true;
        }

        //////////////////////////          INGRESO

        private void txtContraseña_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                ingresarUsuario();
            }
        }

        private void btnIngresar_Click_1(object sender, EventArgs e)
        {

            ingresarUsuario();

        }

    
      

        private void button1_Click_1(object sender, EventArgs e)
        {
            registrar();

        }

        

        private void label21_MouseMove_1(object sender, MouseEventArgs e)
        {
            label21.Font = new Font(label9.Font, FontStyle.Underline);
        }

        private void label21_MouseLeave_1(object sender, EventArgs e)
        {
            label9.Font = new Font(label9.Font, FontStyle.Regular);
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView2.ClearSelection();
        }

        private void dataGridView1_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            idCompra = Convert.ToInt32(dataGridView1.Rows[Convert.ToInt32(e.RowIndex)].Cells[Convert.ToInt32(0)].Value);

            string query = "SELECT * FROM preciosystock";
            MySqlConnection databaseConnection = new MySqlConnection(conexion);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;
            databaseConnection.Open();
            reader = commandDatabase.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    for (x = 0; x < 10000; x++)
                    {
                        if (Convert.ToInt32(reader.GetString(0)) == idCompra)
                        {
                            stockTemporal = Convert.ToInt32(reader.GetString(4));
                            precioTemporal = Convert.ToDecimal(dataGridView1.Rows[Convert.ToInt32(e.RowIndex)].Cells[Convert.ToInt32(5)].Value);

                        }
                    }
                }

            }

            groupBox8.Visible = true;
            databaseConnection.Close();

            //MessageBox.Show(""+ idCompra);
        }

        private void textBox3_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                registrar();
            }
        }

        private void txtUsuario_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                ingresarUsuario();
            }
        }

        private void textBox4_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                registrar();
            }
        }

        private void textBox5_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                registrar();
            }
        }

        private void textBox6_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                registrar();
            }
        }

        private void textBox7_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                registrar();
            }
        }

        private void maskedTextBox1_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                registrar();
            }
        }
        
        private void btnComprar_Click_1(object sender, EventArgs e)
        {


            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show("Esta seguro que desea comprar este objeto?", "Confirmación de compra", buttons);
            if (result == DialogResult.Yes)
            {
                if (stockTemporal > Convert.ToInt32(cantidadUpdown.Value))
                {
                    string query = "UPDATE `preciosystock` SET `STOCK`= '" + Convert.ToInt32(stockTemporal - cantidadUpdown.Value) + "' WHERE id =" + idCompra;
                    MySqlConnection databaseConnection = new MySqlConnection(conexion);
                    MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
                    commandDatabase.CommandTimeout = 60;
                    MySqlDataReader reader;
                    databaseConnection.Open();
                    reader = commandDatabase.ExecuteReader();

                    llenarDg1();
                    llenarDg2();

                    stockTemporal = 0;
                    idCompra = 0;
                    precioTemporal = 0;

                    groupBox8.Visible = false;

                    MessageBox.Show("Compra realizada con éxito!");
                }
                else if (stockTemporal < Convert.ToInt32(cantidadUpdown.Value))
                {
                    MessageBox.Show("No hay stock suficiente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
            
        }

        private void cantidadUpdown_ValueChanged_1(object sender, EventArgs e)
        {
            decimal precioAMostrar = 0;

            precioAMostrar = (precioTemporal + (precioTemporal * (gananciaUpDown.Value / 100))) * cantidadUpdown.Value;
            subtotal.Text = "Subtotal: $" + Convert.ToString(precioAMostrar);
        }

        private void gananciaUpDown_ValueChanged_1(object sender, EventArgs e)
        {
            decimal precioAMostrar = 0;

            precioAMostrar = (precioTemporal + (precioTemporal * (gananciaUpDown.Value / 100))) * cantidadUpdown.Value;
            subtotal.Text = "Subtotal: $" + Convert.ToString(precioAMostrar);

        }

        private void gananciaUpDown_KeyUp_1(object sender, KeyEventArgs e)
        {
            decimal precioAMostrar = 0;

            precioAMostrar = (precioTemporal + (precioTemporal * (gananciaUpDown.Value / 100))) * cantidadUpdown.Value;
            subtotal.Text = "Subtotal: $" + Convert.ToString(precioAMostrar);
        }

        private void cantidadUpdown_KeyUp_1(object sender, KeyEventArgs e)
        {
            decimal precioAMostrar = 0;

            precioAMostrar = (precioTemporal + (precioTemporal * (gananciaUpDown.Value / 100))) * cantidadUpdown.Value;
            subtotal.Text = "Subtotal: $" + Convert.ToString(precioAMostrar);
        }

        private void textBox6_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);

        }

        private void tabControl1_Click_1(object sender, EventArgs e)
        {
            cmbBusquedaCompra.Text = "";
            llenarDg1();
        }

        private void cmbBusquedaCompra_TextChanged_1(object sender, EventArgs e)
        {
            llenarDg1();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView2.ClearSelection();
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void Ferreteria1975_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void Ferreteria1975_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {
            groupBox8.Visible = false;
        }

        private void label7_MouseMove(object sender, MouseEventArgs e)
        {
            label7.Font = new Font(label9.Font, FontStyle.Underline);
        }

        private void label7_MouseLeave(object sender, EventArgs e)
        {
            label7.Font = new Font(label9.Font, FontStyle.Regular);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            if(maximized == false)
            {
                this.WindowState = FormWindowState.Maximized;
                maximized = true;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                maximized = false;
            }
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            lblIngresoDatosUsuarios.Text = "Ingrese nombre:";
            editar = "nombre";
            groupBox1.Visible = true;
            textBox1.Visible = true;
            textBox2.Visible = false;
            textBox8.Visible = false;
            radioButton3.Visible = false;
            radioButton4.Visible = false;

        }

        private void label29_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox8.Text = "";
        }

        private void label29_MouseMove(object sender, MouseEventArgs e)
        {
            label29.Font = new Font(label9.Font, FontStyle.Underline);
        }

        private void label29_MouseLeave(object sender, EventArgs e)
        {
            label29.Font = new Font(label9.Font, FontStyle.Regular);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            switch(editar) 
                {
              
        case "nombre":
              usuariosUpdateNombre();
                    lblNombre.Text = textBox1.Text;
                break;
  
        case "apellido":
                    usuariosUpdateApellido();
                    lblApellido.Text = textBox1.Text;
                    break;

        case "usuario":
                    usuariosUpdateUsuario();
                    lblUsuario.Text = textBox8.Text;
                    break;
        case "contraseña":
                    usuariosUpdateContraseña();
                    lblContraseña.Text = textBox8.Text;
                    break;
        case "genero":
                    usuariosUpdateGenero();
                    txtSexo.Text = genero;
                    break;
        case "dni":
                    usuariosUpdateDocumento();
                    txtDni.Text = textBox1.Text;
                    break;

                default:
                    MessageBox.Show("Ha ocurrido un error");
                break;
            }

            groupBox1.Visible = false;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox8.Text = "";

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;

            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            genero = "Hombre";
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            genero = "Mujer";
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            lblIngresoDatosUsuarios.Text = "Ingrese apellido:";
            editar = "apellido";
            groupBox1.Visible = true;
            textBox1.Visible = true;
            textBox2.Visible = false;
            textBox8.Visible = false;
            radioButton3.Visible = false;
            radioButton4.Visible = false;
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            lblIngresoDatosUsuarios.Text = "Ingrese usuario:";
            editar = "usuario";
            groupBox1.Visible = true;
            textBox8.Visible = true;
            textBox2.Visible = false;
            textBox1.Visible = false;
            radioButton3.Visible = false;
            radioButton4.Visible = false;
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            lblIngresoDatosUsuarios.Text = "Ingrese contraseña:";
            editar = "contraseña";
            groupBox1.Visible = true;
            textBox8.Visible = true;
            radioButton3.Visible = false;
            radioButton4.Visible = false;
            textBox2.Visible = false;
            textBox1.Visible = false;
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            lblIngresoDatosUsuarios.Text = "Ingrese genero:";
            editar = "genero";
            groupBox1.Visible = true;
            radioButton3.Visible = true;
            radioButton4.Visible = true;
            textBox8.Visible = false;
            textBox2.Visible = false;
            textBox1.Visible = false;

        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            lblIngresoDatosUsuarios.Text = "Ingrese dni:";
            editar = "dni";
            groupBox1.Visible = true;
            textBox2.Visible = true;
            textBox8.Visible = false;
            textBox1.Visible = false;
            radioButton3.Visible = false;
            radioButton4.Visible = false;
        }

        private void label11_Click(object sender, EventArgs e)
        {
            panel12.Visible = true;
            panel3.Visible = false;
            panel13.Visible = false;
        }

        private void label11_MouseMove(object sender, MouseEventArgs e)
        {
            label11.Font = new Font(label9.Font, FontStyle.Underline);
        }

        private void label11_MouseLeave(object sender, EventArgs e)
        {
            label11.Font = new Font(label9.Font, FontStyle.Regular);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            genero = "Hombre";
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            genero = "Mujer";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            registrar();
        }

        private void lblCerrarSesion_Click(object sender, EventArgs e)
        {
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show("Esta seguro que desea cerrar sesión?", "Cierre de sesión", buttons);
            if (result == DialogResult.Yes)
            {
                genero = "";
                idUsuario = 0;

                admin = false;
                login = false;

                groupBox6.Visible = false;
                panel12.Visible = true;
                panel13.Visible = false;
            }
           
        }

        private void lblCerrarSesion_MouseMove(object sender, MouseEventArgs e)
        {
            lblCerrarSesion.Font = new Font(lblCerrarSesion.Font, FontStyle.Underline);
        }

        private void lblCerrarSesion_MouseLeave(object sender, EventArgs e)
        {
            lblCerrarSesion.Font = new Font(lblCerrarSesion.Font, FontStyle.Regular);
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void cmbBusquedaCompra_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            llenarDg1();
        }

        private void Ferreteria1975_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void dataGridView2_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (Convert.ToInt32(e.ColumnIndex) == 1)
            {
                string query = "UPDATE `preciosystock` SET `DESCRIPCION`= '" + dataGridView2.Rows[Convert.ToInt32(e.RowIndex)].Cells[Convert.ToInt32(e.ColumnIndex)].Value + "' WHERE id =" + dataGridView2.Rows[Convert.ToInt32(e.RowIndex)].Cells[Convert.ToInt32(0)].Value;
                MySqlConnection databaseConnection = new MySqlConnection(conexion);
                MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
                commandDatabase.CommandTimeout = 60;
                MySqlDataReader reader;
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
            }
            else if (Convert.ToInt32(e.ColumnIndex) == 2)
            {
                string query = "UPDATE `preciosystock` SET `MICOSTO`= '" + (dataGridView2.Rows[Convert.ToInt32(e.RowIndex)].Cells[Convert.ToInt32(e.ColumnIndex)].Value) + "' WHERE id =" + dataGridView2.Rows[Convert.ToInt32(e.RowIndex)].Cells[Convert.ToInt32(0)].Value;
                MySqlConnection databaseConnection = new MySqlConnection(conexion);
                MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
                commandDatabase.CommandTimeout = 60;
                MySqlDataReader reader;
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
            }
            else if (Convert.ToInt32(e.ColumnIndex) == 3)
            {
                string query = "UPDATE `preciosystock` SET `$`= '" + (dataGridView2.Rows[Convert.ToInt32(e.RowIndex)].Cells[Convert.ToInt32(e.ColumnIndex)].Value) + "' WHERE id =" + dataGridView2.Rows[Convert.ToInt32(e.RowIndex)].Cells[Convert.ToInt32(0)].Value;
                MySqlConnection databaseConnection = new MySqlConnection(conexion);
                MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
                commandDatabase.CommandTimeout = 60;
                MySqlDataReader reader;
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
            }

            else if (Convert.ToInt32(e.ColumnIndex) == 4)
            {
                string query = "UPDATE `preciosystock` SET `STOCK`= '" + (dataGridView2.Rows[Convert.ToInt32(e.RowIndex)].Cells[Convert.ToInt32(e.ColumnIndex)].Value) + "' WHERE id =" + dataGridView2.Rows[Convert.ToInt32(e.RowIndex)].Cells[Convert.ToInt32(0)].Value;
                MySqlConnection databaseConnection = new MySqlConnection(conexion);
                MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
                commandDatabase.CommandTimeout = 60;
                MySqlDataReader reader;
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
            }


            this.BeginInvoke(new MethodInvoker(() =>
            {
                dataGridView1.Rows.Clear();
                dataGridView2.Rows.Clear();
                llenarDg1();
                llenarDg2();

            }
                ));
        }

        private void registrar()
        {
            if ((textBox3.Text != "") && (textBox4.Text != "") && (textBox5.Text != "") && (textBox6.Text != "") && (textBox7.Text != "") && (maskedTextBox1.Text != "") && (genero.ToString() != ""))
            {

                if (textBox4.Text == textBox5.Text)
                {
                    usuariosInsert();

                    //groupBox1.Visible = false;
                    panel12.Visible = false;
                    panel13.Visible = true;
                    groupBox6.Visible = false;


                    lblBienvenido.Text = "Bienvenido: " + textBox6.Text;
                    lblNombre.Text = "Usuario: " + textBox3.Text;
                    label18.Text = "Usuario: " + textBox3.Text;
                    lblUsuario.Text = "Nombre: " + textBox6.Text;
                    lblContraseña.Text = "Apellido: " + textBox7.Text;
                    txtSexo.Text = "Genero: " + genero;
                    txtDni.Text = "DNI: " + maskedTextBox1.Text;


                }
                else
                {
                    MessageBox.Show("Las contraseñas deben coincidir", "Revise los datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("No debe haber ningún campo en blanco", "Revise los datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void llenarCmbBusquedaCompra()
        {

            MySqlDataAdapter sda = new MySqlDataAdapter("SELECT `DESCRIPCION` FROM `preciosystock` WHERE 1", conexion);

            DataTable dt = new DataTable();
            sda.Fill(dt);
            

            cmbBusquedaCompra.DataSource = dt;
            //cmbBusquedaCompra.ValueMember = "ID";
            cmbBusquedaCompra.DisplayMember = "DESCRIPCION";
            cmbBusquedaCompra.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbBusquedaCompra.AutoCompleteSource = AutoCompleteSource.ListItems;

        }
    }
}

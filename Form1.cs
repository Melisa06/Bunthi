//Librerias utilizadas 
using System;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Drawing;
using System.Linq;

namespace Bunthi
{
    public partial class Form1 : Form
    {
        //Este es un list privado para que siempre tenga los valores sea cual sea la acción que se realice
        //O al menos en esta clase
        private List<Datos> datosDeTxt = new List<Datos>();
        //Variable para dar acceso al form 
        private delegate void DelegadoAcceso(string accion);
        //Variables para la lectura de datos
        private string strBufferIn;
        private string strBufferOut;

        //Esta es para tomar la fecha, hora al momento de conectarse al puerto
        private DateTime fecha = DateTime.Now;
        //Es el contador que vamos a usar por mientras
        //private int aumentoTiempo = 0;
        //Es el contador que vamos a usar por mientras
        private TimeSpan aumentoTiempo = new TimeSpan(0, 1, 0);
        //Variable para abrir ventana de busqueda de archivos 
        FolderBrowserDialog fbd = new FolderBrowserDialog();
        private string ruta;
        public Form1()
        {
            InitializeComponent();
        }

        //gets & sets 
        public class Datos
        {

            public string Temp { get; set; }
            public string Lum { get; set; }
            public string Fecha { get; set; }
            public string Hora { get; set; }
        }
        /// <summary>
        /// Esta función es para validar si entra o no en el rango de tiempo
        /// </summary>
        /// <param name="aumento">es el aumento en minutos que se tendra que sumar a la hora anterior</param>
        public bool MandarDatos(TimeSpan aumento)
        {

            //Se usa para validar el minuto actual 
            System.Diagnostics.Debug.WriteLine("Minuto anterior: " + fecha.ToString("mm") + "  Minuto actual: " + DateTime.Now.ToString("mm"));

            if ((fecha + aumentoTiempo).ToString("mm") == DateTime.Now.ToString("mm"))
            {
                fecha = fecha + aumentoTiempo;
                //MessageBox.Show("aqui voy");
                return true;
            }

            else
                return false;

        }

        //---------------------------Metodo para leer dato e insertar en un .txt-------------

        public void LeerDatos(Datos datoRecibido)
        {
            ruta = txtBrowse.Text;
            //Primero se agrega el dato a la lista
            datosDeTxt.Add(datoRecibido);

            //Luego la lista se cambia a el sentido contrario, esto para que el ultimo dato ingresado salga al inicio del txt
            datosDeTxt.Reverse();

            //Iniciamos el StreamWriter que es el motor para crear el archivo, se especifica la ruta donde se almacenara
            // System.IO.StreamWriter stre = new System.IO.StreamWriter(Server.MapPath("C:/Datos/datos.txt") + "datos.txt", true); 
            StreamWriter sw = new StreamWriter(ruta);

            //Creamos el encabezado
            sw.WriteLine("+-------------+-------------+------------+-------------+");
            sw.WriteLine("|TEMPERATURA  | LUMINOSIDAD |    FECHA   |    HORA     |");
            sw.WriteLine("+-------------+-------------+------------+-------------+");

            //Creamos un foreach para recorrer la lista inversa y separar los datos del mismo
            foreach (var dato in datosDeTxt)
            {
                string espaciado = "";
                //Cada valor separado se agrega a una linea en el archivo

                for (int i = 0; i < 13 - (dato.Temp.Length + 1); i++)
                    espaciado = espaciado + " ";

                sw.WriteLine("|" + espaciado + dato.Temp + " |" + espaciado + dato.Lum + "," + "|" + dato.Fecha + "," + "|" + dato.Hora + "|");
            }
            sw.WriteLine("+-------------+-------------+-------------+-------------+");

            //Cerramos el motor para que se guarden los cambios en el archivo
            sw.Close();

            //Volvemos a invertir la lista para que el siguiente dato sigua la linea de la lista correctamente
            datosDeTxt.Reverse();

        }//cierra metodo leer dato 

        //metodo para dar acceso al form
        private void AccesoForm(string accion)
        {
            //--------------------- tener  acceso a los datos que se ingresan desde el puerto serial

            //El numero 10 es provisional

            if (MandarDatos(new TimeSpan(0, 1, 0)))
            {
                try
                {
                    strBufferIn = accion;
                    //Aqui es donde se hara la separación de datos

                    System.Diagnostics.Debug.WriteLine(accion);

                    string  temp, lum;
                    //Se hace un array el cual se separa por la coma para eso funciona la herramienta split 
                    //(Puede ser cualquier parametro desde una palabra hasta caracteres especiales en un orden especifico)
                    string[] subStrings = accion.Split(',');
                    temp = subStrings[0];
                    lum = subStrings[1];



                    txtDatoRecibido.Text = accion;
                    spPuertoSerial.DiscardInBuffer();

                    Datos datosNuevos = new Datos();
                    datosNuevos.Temp = temp;
                    datosNuevos.Lum = lum;
                    datosNuevos.Fecha = DateTime.Now.ToShortDateString();
                    datosNuevos.Hora = DateTime.Now.ToLongTimeString();

                    LeerDatos(datosNuevos);
                    //Este metodo ingresa datos al gridView y lo agrega, no se puede poner un objeto, se tiene que poner separado por comas
                    //Asi separamos el objeto actual en los elementos separados
                    dataGridView1.Rows.Add(datosNuevos.Temp, datosNuevos.Lum, datosNuevos.Fecha, datosNuevos.Hora);
                    //spPuertoSerial.DiscardOutBuffer();

                    //System.Diagnostics.Debug.WriteLine("1");

                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message.ToString());
                }
            }
        }

        //Metodo para estar guardando los datos 
        private void AccesoInterrupcion(string accion)
        {
            try
            {
                DelegadoAcceso var_DA;
                var_DA = new DelegadoAcceso(AccesoForm);


                object[] arg = { accion };

                base.Invoke(var_DA, arg);
            }

            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("No toma el valor o supera el buffer asignado");
            }

        }


        private void Form1_Load(object sender, EventArgs e)
        {
            strBufferIn = "";
            strBufferOut = "";
            btnConectar.Enabled = false;
        }

        private void btnBuscar_Puertos_Click(object sender, EventArgs e)
        {
            // en un arreglo se guardarn los datos disponobles 
            string[] PuertosDisponibles = SerialPort.GetPortNames();
            cmbPuertos.Items.Clear();

            foreach (string puerto in PuertosDisponibles)
            {
                // en el combo box puertos 
                // se guardaran los puertos disponibles 
                cmbPuertos.Items.Add(puerto);

            }
            //si el cmbPuertos es mayor que 0 se mostrará  el siguiente mensaje 
            if (cmbPuertos.Items.Count > 0)
            {
                cmbPuertos.SelectedIndex = 0;
                //-------------------------------Mensaje para seleccionar el puerto 
                // Esto nos indica que el metodo para encontrar los seriales esta funcionando 
                MessageBox.Show("Seleccionar el puerto");

                btnConectar.Enabled = true;
                //------------------------------------------------------------------------------
            }
            //si no se encuentra ningun puerto pasara al siguiente else 
            else
            {
                MessageBox.Show("Ningun puerto seleccionado");
                cmbPuertos.Items.Clear();
                cmbPuertos.Text = "                       ";
                strBufferIn = "";
                strBufferOut = "";
                btnConectar.Enabled = false;
            }
        }
        //-------
        /*
    *En el botón conectar le pasaremos los 
    * parametros que necesita para recibir los datos 
    * 
    */
        private void btnConectar_Click(object sender, EventArgs e)
        {
            // La función y el metodo para conectra con el serial
            try
            {
                if (btnConectar.Text == "CONECTAR")
                {
                    System.Diagnostics.Debug.WriteLine("1");

                    //datos para poder conectar con el serial 
                    spPuertoSerial.BaudRate = 9600;
                    spPuertoSerial.DataBits = 8;
                    spPuertoSerial.Parity = Parity.None;
                    spPuertoSerial.StopBits = StopBits.One;
                    spPuertoSerial.Encoding = Encoding.ASCII;
                    //spPuertoSerial.Handshake = Handshake.None;// para que sirve?
                    // No lo se eso lo puse del video 
                    //este es otro emulador 

                    spPuertoSerial.PortName = cmbPuertos.Text;

                    try
                    {
                        //Línea de código para abrir el puerto serial 
                        spPuertoSerial.Open();
                        spPuertoSerial.DiscardOutBuffer();

                        strBufferIn = "";
                        strBufferOut = "1";
                        /*
                         * Cuando se conecte al serial 
                         * este mandara un dato de 
                         * para concer que si esta concetado 
                         * 
                         */
                        spPuertoSerial.DiscardInBuffer();
                        spPuertoSerial.DiscardOutBuffer();
                        AccesoInterrupcion(spPuertoSerial.ReadExisting());
                        strBufferIn = "";
                        strBufferOut = "";
                        btnConectar.Text = "DESCONECTAR";

                        //Lo que se hace es tomar toda la fecha, dia/mes/año hh:mm:ss por cualquier cosa que quieras hacer despues
                        //Luego lo que hago es separar esa fecha en solo los minutos para comenzar a hacer el contador 
                        fecha = DateTime.Now;
                        // aumentoTiempo = Int32.Parse(fecha.ToString("mm"));
                    }
                    catch (Exception EXC)
                    {
                        MessageBox.Show(EXC.Message.ToString());
                    }
                }
                //EL else if es para cambiar el botn de conectar por las palabras "desconectar"
                else if (btnConectar.Text == "DESCONECTAR")
                {
                    spPuertoSerial.Close();
                    btnConectar.Text = "CONECTAR";
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message.ToString());
            }
        }
        //--------------

        private void spPuertoSerial_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                Thread.Sleep(9000);
                string dato = spPuertoSerial.ReadExisting();
                AccesoInterrupcion(dato);
                System.Diagnostics.Debug.WriteLine(strBufferIn);
            }

            catch (Exception ec)
            {
                MessageBox.Show(ec.Message.ToString());
            }
        }
        //--------------
        private void tTime_Tick(object sender, EventArgs e)
        {
            try
            {
                lblTiempo.Text = DateTime.Now.ToLongTimeString();

                tTime.Start();
                if ((fecha + aumentoTiempo).ToString("mm") == DateTime.Now.ToString("mm"))
                {
                    //spPuertoSerial.DiscardInBuffer();
                    //spPuertoSerial.DiscardOutBuffer();
                    spPuertoSerial.Write("1");
                    Thread.Sleep(9000);
                    System.Diagnostics.Debug.WriteLine(strBufferOut);
                    spPuertoSerial.DiscardOutBuffer();

                }

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Truena por el minuto" + ex);
            }
        }
        //--------------

      

        private void btnArchivos_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
        }

        private void saveFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
             txtBrowse.Text = saveFileDialog1.FileName;
        
        }

      
        //--------------



    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TallerAutos.BusinessLayer;
using TallerAutos.DataAccessLayer;
using TallerAutos.Entities;

namespace TallerAutos.GUILayer
{
    public partial class frmDetallesOT : Form
    {
        private Empleado empleadoSesion = new Empleado();
        //Por defecto esta en insert mode.
        private FormMode formMode = FormMode.insert;
        private EmpleadoService empleadoS;
        private List<Repuesto> listaRepuestos;
        private List<int> listaCantidades;
        private decimal montoTrabajo;
        private DetalleOT trabajoEdicion;
        //No se utilizan por el momento.
        //private MarcaService Smarca;
        //private ModeloService Smodelo;
        public frmDetallesOT()
        {
            InitializeComponent();
            InitializeDataGridView();
            empleadoS = new EmpleadoService();
            montoTrabajo = 0;
            //No se utilizan por el momento
            //Smarca = new MarcaService();
            //Smodelo = new ModeloService();
        }

        public enum FormMode
        {
            insert,
            update,
            detail
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void SeleccionarTrabajo(DetalleOT trabajo)
        {
            this.trabajoEdicion = trabajo;
        }

        private void CargarDgvRepuestos()
        {   
            dgvRepuestos.RowCount = 0;
            montoTrabajo = 0;
            for (int i = 0; i < listaRepuestos.Count(); i++)
            {
                dgvRepuestos.Rows.Insert(i, listaRepuestos[i].Nombre, listaRepuestos[i].Fabricante, listaCantidades[i], listaRepuestos[i].PrecioUnitario * listaCantidades[i]);
                montoTrabajo += listaRepuestos[i].PrecioUnitario * listaCantidades[i];
            }
        }

        private void InitializeDataGridView()
        {

           
            dgvRepuestos.ColumnCount = 4;
            dgvRepuestos.ColumnHeadersVisible = true;

            dgvRepuestos.AutoGenerateColumns = false;

            //Cargado
            dgvRepuestos.Columns[0].Name = "Nombre";
            dgvRepuestos.Columns[0].DataPropertyName = "nombre";
            

            dgvRepuestos.Columns[1].Name = "Fabricante";
            dgvRepuestos.Columns[1].DataPropertyName = "fabricante";

            dgvRepuestos.Columns[2].Name = "Cantidad";
            dgvRepuestos.Columns[2].DataPropertyName = "cantidad";

            dgvRepuestos.Columns[3].Name = "Precio";
            dgvRepuestos.Columns[3].DataPropertyName = "precio";

            DataGridViewImageColumn columnaimg = new DataGridViewImageColumn();
            columnaimg.Name = "Eliminar";
            columnaimg.HeaderText = "Eliminar";

            var ruta = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location).Replace(@"\bin\Debug", @"\Resources\borrar.png");
            Console.WriteLine(ruta);
            columnaimg.Image = Image.FromFile(ruta);

            dgvRepuestos.Columns.Add(columnaimg);

            dgvRepuestos.AllowUserToAddRows = false;
            dgvRepuestos.ReadOnly = true;
            dgvRepuestos.MultiSelect = false;
            this.dgvRepuestos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //No permito cambiar el tamaño de las celdas para que la seleccion quede mas limpia.
            this.dgvRepuestos.AllowUserToResizeRows = false;
   

        }

        private void FrmDetallesOT_Load(object sender, EventArgs e)
        {
            LlenarCombo(this.cboEmpleado, empleadoS.ConsultarEmpleados("AND 1=1"), "Nombre", "Legajo");
            this.lblError.Visible = false;
            
            switch (formMode)
            {
                //Modo crear Orden de Trabajo
                case FormMode.insert:
                    {
                        listaRepuestos = new List<Repuesto>();
                        listaCantidades = new List<int>();
                        cboEmpleado.Enabled = false;
                        cboEmpleado.SelectedValue = empleadoSesion.Legajo;
                        break;
                    }

                case FormMode.update:
                    {
                        
                        this.listaRepuestos = (List <Repuesto>) trabajoEdicion.Repuesto;
                        this.listaCantidades = (List <int>) trabajoEdicion.Cantidades;
                        this.txtDescripcion.Text = trabajoEdicion.Descripcion;
                        this.cboEmpleado.SelectedValue = trabajoEdicion.Empleado.Legajo;
                        //Calculando el monto de la mano de obra
                        decimal montoTotal = Convert.ToInt32(trabajoEdicion.Monto);
                        for (int i = 0; i< trabajoEdicion.Repuesto.Count; i++ )
                        {
                            decimal montoRepuesto = trabajoEdicion.Repuesto[i].PrecioUnitario * trabajoEdicion.Cantidades[i];
                            montoTotal -= montoRepuesto;
                        }

                        this.txtMonto.Text = Convert.ToString(montoTotal);
                        this.CargarDgvRepuestos();
                        this.cboEmpleado.Enabled = false;
                        break;
                    }

                case FormMode.detail:
                    {
                        //Prueba, luego agrupar en un método
                        this.listaRepuestos = (List<Repuesto>)trabajoEdicion.Repuesto;
                        this.listaCantidades = (List<int>)trabajoEdicion.Cantidades;
                        this.txtDescripcion.Text = trabajoEdicion.Descripcion;
                        this.cboEmpleado.SelectedValue = trabajoEdicion.Empleado.Legajo;
                        //Calculando el monto de la mano de obra
                        decimal montoTotal = Convert.ToInt32(trabajoEdicion.Monto);
                        for (int i = 0; i < trabajoEdicion.Repuesto.Count; i++)
                        {
                            decimal montoRepuesto = trabajoEdicion.Repuesto[i].PrecioUnitario * trabajoEdicion.Cantidades[i];
                            montoTotal -= montoRepuesto;
                        }

                        this.txtMonto.Text = Convert.ToString(montoTotal);
                        this.CargarDgvRepuestos();
                        this.cboEmpleado.Enabled = false;
                        this.txtMonto.Enabled = false;
                        this.btnAgregar.Visible = false;
                        this.txtDescripcion.Enabled = false;
                        this.txtMonto.Enabled = false;
                        dgvRepuestos.AllowUserToDeleteRows = false;
                        dgvRepuestos.ReadOnly = true;
                        break;
                    }

                 
            }
        }

        public void SeleccionarDOT(FormMode modo,  Empleado empleadoSesion)
        {
            formMode = modo;
            if(formMode == FormMode.insert) this.empleadoSesion = empleadoSesion;
        }

        private void LlenarCombo(ComboBox combo, Object fuente, string display, String value)
        {
            combo.DataSource = fuente;
            combo.DisplayMember = display;
            combo.ValueMember = value;
            combo.SelectedIndex = -1;
        }


        public void CargarRepuesto(Repuesto rep, int cantidad)
        {
            listaRepuestos.Add(rep);
            listaCantidades.Add(cantidad);
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            frmConsultaRepuestos fCR = new frmConsultaRepuestos(false);
            AddOwnedForm(fCR);
            fCR.FormClosing += frmRepuestos_FormClosing;
            fCR.Show();
            this.Hide();
        }

        private void frmRepuestos_FormClosing(object sender, EventArgs e)
        {
            this.Show();
            CargarDgvRepuestos();
        }

        private void TxtMonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar)) //Al pulsar un número
            {
                e.Handled = false; //Se acepta
            }
            else if (Char.IsControl(e.KeyChar)) //Teclas especial como borrar
            {
                e.Handled = false; //Se acepta
            }
            else //Para todas las demas teclas
            {
                e.Handled = true; //No se acepta
            }
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            //Si el formMode esta en detail, unicamente cerramos el form.
            if (formMode == FormMode.detail) this.Close();

            if(cboEmpleado.SelectedIndex > -1 && txtDescripcion.Text.Length > 0 && txtDescripcion.Text.Length <= 90 && txtMonto.Text.Length > 0 && Convert.ToDecimal(txtMonto.Text) > 0)
            {
                DetalleOT oDOT = new DetalleOT();
                oDOT.Empleado = new Empleado();
                oDOT.Descripcion = txtDescripcion.Text;
                oDOT.Empleado = (Empleado) cboEmpleado.SelectedItem;
                oDOT.Monto = montoTrabajo + Convert.ToDecimal(txtMonto.Text);
                oDOT.Repuesto = listaRepuestos;
                oDOT.Cantidades = listaCantidades;
                
                //Mandar info para transacción.
                frmCrearOrden frmPadre = this.Owner as frmCrearOrden;
                
                if (formMode == FormMode.update) frmPadre.EliminarTrabajo(trabajoEdicion);
                
                frmPadre.CargarTrabajo(oDOT);
                this.Close();
            }
            else
            {
                lblError.Text = "Error: Descripción incorrecta o monto incorrecto.";
                lblError.Visible = true;
                timerError.Start();
            }
        }

        private void TimerError_Tick(object sender, EventArgs e)
        {
            lblError.Visible = false;
        }

        private void DgvTrabajos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (formMode == FormMode.detail) ; //No hago nada
            else
            {
                if (e.ColumnIndex == 4) // Si es la columna que tiene el boton eliminar.
                {
                    if (dgvRepuestos.Rows.Count > 0) //Si existe al menos una fila.
                    {
                        int index = dgvRepuestos.CurrentRow.Index;

                        decimal montoRepuestoEliminado = Convert.ToDecimal(dgvRepuestos.CurrentRow.Cells[3].Value) * listaCantidades[index];
                        montoTrabajo -= montoRepuestoEliminado;
                        dgvRepuestos.Rows.RemoveAt(index); //Elimino de la grilla.
                        listaRepuestos.RemoveAt(index); //Elimino de la lista de repuestos.
                        listaCantidades.RemoveAt(index); //Eliminmo de la lista de cantidades.
                    }
                }
            }
        }

        public List<Repuesto> getListaRepuestos()
        {
            return listaRepuestos;
        }

        public List<int> getCantidadRepuestos()
        {
            return listaCantidades;
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
 
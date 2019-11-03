using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using TallerAutos.BusinessLayer;
using TallerAutos.DataAccessLayer;
using TallerAutos.Entities;

namespace TallerAutos.GUILayer
{
    public partial class frmConsultaOrden : Form
    {
        BaseDeDatos oBD = new BaseDeDatos();
        private Empleado empleadoSesion;
        OrdenTrabajoService ot;
        public frmConsultaOrden(Empleado emp)
        {
            InitializeComponent();
            InitializeDataGridView();
            this.empleadoSesion = emp;
            ot = new OrdenTrabajoService();
        }

        private void BtnQuery_Click(object sender, EventArgs e)
        {
            
            String sqlCondiciones = "";
            Dictionary<string, object> parametros = new Dictionary<string, object>();

            DateTime fechaDesde;
            DateTime fechaHasta;

            if (DateTime.TryParse(dtpDesde.Text, out fechaDesde) &&
                DateTime.TryParse(dtpHasta.Text, out fechaHasta))
            {
                sqlCondiciones += " AND (O.fechaAlta>='" + fechaDesde.ToString("dd/MM/yyyy") + "' AND O.fechaAlta<='" + fechaHasta.ToString("dd/MM/yyyy") + "')";
                //parametros.Add("fechaDesde", dtpDesde.Value);
                //parametros.Add("fechaHasta", dtpHasta.Value);
            }

            if (!string.IsNullOrEmpty(cboEstados.Text))
            {
                var idEstado = cboEstados.SelectedValue.ToString();
                sqlCondiciones += " AND (O.codEstado=" + idEstado + ")";
                //parametros.Add("idEstado", idEstado);
            }

            if (!string.IsNullOrEmpty(txtIdOrden.Text))
            {
                var nCod = txtIdOrden.Text;
                sqlCondiciones += " AND (O.codOrden = " + nCod + ")";
                //parametros.Add("nCod", nCod);
            }

            if (!string.IsNullOrEmpty(txtPatente.Text))
            {
                var patente = txtPatente.Text;
                sqlCondiciones += " AND (O.patente = '" + patente + "')";
                //parametros.Add("patente", patente);
            }

            if (!string.IsNullOrEmpty(txtDNI.Text))
            {
                var dniCliente = txtDNI.Text;
                sqlCondiciones += " AND (O.dniCliente = " + dniCliente + ")";
                //parametros.Add("dniCliente", dni);
            }

            IList<OrdenTrabajo> listaOT = ot.ConsultarOT(sqlCondiciones);
            dgvOrdenes.DataSource = listaOT;

            if (dgvOrdenes.Rows.Count == 0)
            {
                MessageBox.Show("No se encontraron órdenes para los filtros ingresados", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void InitializeDataGridView()
        {
            //Cantidad columnas y las hago visibles.
            dgvOrdenes.ColumnCount = 6;
            dgvOrdenes.ColumnHeadersVisible = true;

            // Configurp la AutoGenerateColumns en false para que no se autogeneren las columnas
            dgvOrdenes.AutoGenerateColumns = false;
                        
            // Definimos el nombre de la columnas y el DataPropertyName que se asocia a DataSource
            dgvOrdenes.Columns[0].Name = "Codigo";
            dgvOrdenes.Columns[0].DataPropertyName = "codOrden";

            dgvOrdenes.Columns[1].Name = "Estado";
            dgvOrdenes.Columns[1].DataPropertyName = "Estado";

            dgvOrdenes.Columns[2].Name = "Patente";
            dgvOrdenes.Columns[2].DataPropertyName = "Vehiculo";

            dgvOrdenes.Columns[3].Name = "DNI";
            dgvOrdenes.Columns[3].DataPropertyName = "Cliente";

            dgvOrdenes.Columns[4].Name = "Descripcion";
            dgvOrdenes.Columns[4].DataPropertyName = "descripcionFalla";

            dgvOrdenes.Columns[5].Name = "Monto Total";
            dgvOrdenes.Columns[5].DataPropertyName = "montoTotal";

            // Cambia el tamaño de la altura de los encabezados de columna.
            dgvOrdenes.AutoResizeColumnHeadersHeight();

            // Cambia el tamaño de todas las alturas de fila para ajustar el contenido de todas las celdas que no sean de encabezado.
            dgvOrdenes.AutoResizeRows(
                DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders);

            this.dgvOrdenes.MultiSelect = false;
            this.dgvOrdenes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrdenes.AllowUserToAddRows = false;
        }   

        private void CargarComboEstados()
        {
            DataTable tabla = new DataTable();
            tabla = oBD.ConsultarTabla("Estados");
            this.cboEstados.DataSource = oBD.ConsultarTabla("Estados");
            this.cboEstados.DisplayMember = tabla.Columns[1].ColumnName;
            this.cboEstados.ValueMember = tabla.Columns[0].ColumnName;
            this.cboEstados.SelectedIndex = -1;
        }

        private void Form1_Load(object sender, EventArgs e)
        {           
            CargarComboEstados();
            btnDetalle.Enabled = false;
            btnEditar.Enabled = false;
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {   
            this.Close();
        }


        private void BtnDetalle_Click(object sender, EventArgs e)
        {
            if (dgvOrdenes.SelectedRows != null)
            {
                OrdenTrabajo otEdicion = (OrdenTrabajo)dgvOrdenes.CurrentRow.DataBoundItem;
                frmCrearOrden frmCrearOrden = new frmCrearOrden(empleadoSesion);
                AddOwnedForm(frmCrearOrden);
                frmCrearOrden.FormClosing += frmCrearOrden_FormClosing;
                frmCrearOrden.SeleccionarOT(frmCrearOrden.FormMode.details, otEdicion);
                frmCrearOrden.Show();
                this.Hide();
            }
        }

        private void DgvOrdenes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Activo el boton de ver detalle y el de editar.
            btnDetalle.Enabled = true;
            btnEditar.Enabled = true;
        }

        private void PictureCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            OrdenTrabajo otEdicion = (OrdenTrabajo) dgvOrdenes.CurrentRow.DataBoundItem;
            frmCrearOrden frmCrearOrden = new frmCrearOrden(empleadoSesion);
            AddOwnedForm(frmCrearOrden);
            frmCrearOrden.FormClosing += frmCrearOrden_FormClosing;
            frmCrearOrden.SeleccionarOT(frmCrearOrden.FormMode.update, otEdicion);
            frmCrearOrden.Show();
            this.Hide();
        }

        private void frmCrearOrden_FormClosing(object sender, FormClosingEventArgs e)
        {
            IList<OrdenTrabajo> listaOT = ot.ConsultarOT("");
            dgvOrdenes.DataSource = listaOT;
            this.Show();
        }

        private void TxtIdOrden_KeyPress(object sender, KeyPressEventArgs e)
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
    }
    
}

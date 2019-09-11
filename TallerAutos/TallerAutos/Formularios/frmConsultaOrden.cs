using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TallerAutos.Clases;
namespace TallerAutos.Formularios
{
    public partial class frmConsultaOrden : Form
    {
        BaseDeDatos oBD = new BaseDeDatos();
        public frmConsultaOrden()
        {
            InitializeComponent();
            InitializeDataGridView();
            
        }

        private void BtnQuery_Click(object sender, EventArgs e)
        {
            OrdenTrabajo ot = new OrdenTrabajo();
            string strSql = "SELECT O.codOrden, E.nombre, O.patente, O.dniCliente, FP.nombre, O.fechaAlta, O.fechaCierre, O.descripcionFalla, O.fechaPago, O.montoTotal " +
                            "FROM Ordenes O JOIN Estados E ON (O.codEstado = E.codEstado) " +
                            "               FULL JOIN FormasPago FP ON (O.formaPago = FP.codFormaPago) " +
                            "WHERE 1=1 ";

            Dictionary<string, object> parametros = new Dictionary<string, object>();

            DateTime fechaDesde = dtpDesde.Value;
            DateTime fechaHasta = dtpHasta.Value;


            strSql += " AND (O.fechaAlta>=@fechaDesde AND O.fechaAlta<=@fechaHasta) ";
            parametros.Add("fechaDesde", dtpDesde.Value);
            parametros.Add("fechaHasta", dtpHasta.Value);



            if (!string.IsNullOrEmpty(cboEstados.Text))
            {
                var idEstado = cboEstados.SelectedValue.ToString();
                strSql += "AND (O.codEstado=@idEstado) ";
                parametros.Add("idEstado", idEstado);
            }

            if (!string.IsNullOrEmpty(txtIdOrden.Text))
            {
                var nCod = txtIdOrden.Text;
                strSql += "AND (O.codOrden = @nCod) ";
                parametros.Add("nCod", nCod);
            }

            if (!string.IsNullOrEmpty(txtPatente.Text))
            {
                var patente = txtPatente.Text;
                strSql += "AND (O.patente = @patente) ";
                parametros.Add("patente", patente);
            }

            if (!string.IsNullOrEmpty(txtDNI.Text))
            {
                var dni = txtDNI.Text;
                strSql += "AND (O.dniCliente = @dniCliente) ";
                parametros.Add("dniCliente", dni);
            }
            strSql += " ORDER BY O.fechaAlta DESC";
            dgvOrdenes.DataSource = ot.consultarOT(strSql, parametros);
            if (dgvOrdenes.Rows.Count == 0)
            {
                MessageBox.Show("No se encontraron órdenes para los filtros ingresados", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void InitializeDataGridView()
        {
            //Propiedades del dgvOrdenes


            //Cantidad columnas y las hago visibles.
            dgvOrdenes.ColumnCount = 10;
            dgvOrdenes.ColumnHeadersVisible = true;

            // Configurp la AutoGenerateColumns en false para que no se autogeneren las columnas
            dgvOrdenes.AutoGenerateColumns = false;

            // Cambia el estilo de la cabecera de la grilla.
            DataGridViewCellStyle columnHeaderStyle = new DataGridViewCellStyle();

            columnHeaderStyle.BackColor = Color.Beige;
            columnHeaderStyle.Font = new Font("Verdana", 8, FontStyle.Bold);
            dgvOrdenes.ColumnHeadersDefaultCellStyle = columnHeaderStyle;


            // Definimos el nombre de la columnas y el DataPropertyName que se asocia a DataSource
            dgvOrdenes.Columns[0].Name = "Codigo";
            dgvOrdenes.Columns[0].DataPropertyName = "codOrden";

            dgvOrdenes.Columns[1].Name = "Estado";
            dgvOrdenes.Columns[1].DataPropertyName = "nombre";

            dgvOrdenes.Columns[2].Name = "Patente";
            dgvOrdenes.Columns[2].DataPropertyName = "patente";

            dgvOrdenes.Columns[3].Name = "DNI";
            dgvOrdenes.Columns[3].DataPropertyName = "dniCliente";

            dgvOrdenes.Columns[4].Name = "Forma Pago";
            dgvOrdenes.Columns[4].DataPropertyName = "nombre1";

            dgvOrdenes.Columns[5].Name = "Fecha Alta";
            dgvOrdenes.Columns[5].DataPropertyName = "fechaAlta";

            dgvOrdenes.Columns[6].Name = "Fecha Cierre";
            dgvOrdenes.Columns[6].DataPropertyName = "fechaCierre";

            dgvOrdenes.Columns[7].Name = "Descripcion";
            dgvOrdenes.Columns[7].DataPropertyName = "descripcionFalla";

            dgvOrdenes.Columns[8].Name = "Fecha Pago";
            dgvOrdenes.Columns[8].DataPropertyName = "fechaPago";

            dgvOrdenes.Columns[9].Name = "Monto Total";
            dgvOrdenes.Columns[9].DataPropertyName = "montoTotal";

            // Cambia el tamaño de la altura de los encabezados de columna.
            dgvOrdenes.AutoResizeColumnHeadersHeight();

            // Cambia el tamaño de todas las alturas de fila para ajustar el contenido de todas las celdas que no sean de encabezado.
            dgvOrdenes.AutoResizeRows(
                DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders);

            this.dgvOrdenes.MultiSelect = false;
            this.dgvOrdenes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrdenes.AllowUserToAddRows = false;
        }   
        
            
 

        private void cargarComboEstados()
        {
            DataTable tabla = new DataTable();
            tabla = oBD.consultarTabla("Estados");
            this.cboEstados.DataSource = oBD.consultarTabla("Estados");
            this.cboEstados.DisplayMember = tabla.Columns[1].ColumnName;
            this.cboEstados.ValueMember = tabla.Columns[0].ColumnName;
            this.cboEstados.SelectedIndex = -1;
        }

        private void Form1_Load(object sender, EventArgs e)
        {           
            cargarComboEstados();
            btnDetalle.Enabled = false;
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {   
            this.Close();
        }

        private void DgvOrdenes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }



        private void BtnDetalle_Click(object sender, EventArgs e)
        {
            if(dgvOrdenes.SelectedRows != null)
            {

                string idOrden = dgvOrdenes.Rows[dgvOrdenes.CurrentRow.Index].Cells["Codigo"].Value.ToString();
                
                frmDetalleCOrdenes fDCO = new frmDetalleCOrdenes(idOrden);
                fDCO.ShowDialog();
            }
        }

        private void DgvOrdenes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Activo el boton de ver detalle
            btnDetalle.Enabled = true;
        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
    
}

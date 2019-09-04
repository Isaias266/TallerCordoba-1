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
        }

        private void LblFechDesde_Click(object sender, EventArgs e)
        {

        }

        private void LblPrior_Click(object sender, EventArgs e)
        {

        }

        private void BtnQuery_Click(object sender, EventArgs e)
        {
            string strSql = "SELECT TOP 20 * FROM Ordenes WHERE 1=1 ";

            Dictionary<string, object> parametros = new Dictionary<string, object>();

            DateTime fechaDesde = dtpDesde.Value;
            DateTime fechaHasta = dtpHasta.Value;
            
            {
                strSql += " AND (fechaAlta>=@fechaDesde AND fechaAlta<=@fechaHasta) ";
                parametros.Add("fechaDesde", dtpDesde.Value);
                parametros.Add("fechaHasta", dtpHasta.Value);
            }


            if (!string.IsNullOrEmpty(cboEstados.Text))
            {
                var idEstado = cboEstados.SelectedValue.ToString();
                strSql += "AND (codEstado=@idEstado) ";
                parametros.Add("idEstado", idEstado);
            }

            if (!string.IsNullOrEmpty(txtIdOrden.Text))
            {                   
                var nCod = txtIdOrden.Text;
                strSql += "AND (codOrden = @nCod) ";
                parametros.Add("nCod", nCod);
            }

            if (!string.IsNullOrEmpty(txtPatente.Text))
            {
             
                var patente = txtPatente.Text;
                strSql += "AND (patente = @patente) ";
                parametros.Add("patente", patente);
            }

            if (!string.IsNullOrEmpty(txtDNI.Text))
            {

                var dni = txtPatente.Text;
                strSql += "AND (dniCliente = @dniCliente) ";
                parametros.Add("dniCliente", dni);
            }


            strSql += " ORDER BY fechaAlta DESC";
            dgvOrdenes.DataSource = oBD.ConsultaSQLConParametros(strSql, parametros);
            if (dgvOrdenes.Rows.Count == 0)
            {
                MessageBox.Show("No se encontraron órdenes para los filtros ingresados", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

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
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {   
            this.Close();
        }
    }
    
}

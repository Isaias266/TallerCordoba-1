using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TallerAutos.BusinessLayer;
using TallerAutos.Entities;

namespace TallerAutos.GUILayer
{
    public partial class frmConsultaRepuestos : Form
    {
        private MarcaService marca;
        private RepuestoService oRepuestoService;
        private bool consultaNormal;

        public frmConsultaRepuestos(bool x)
        {
            InitializeComponent();
            InitializeDataGridView();
            marca = new MarcaService();
            oRepuestoService = new RepuestoService();
            consultaNormal = x;
        }

        private void InitializeDataGridView()
        {
            dataGridRepuestos.ColumnCount = 8;
            dataGridRepuestos.ColumnHeadersVisible = true;
            dataGridRepuestos.AutoGenerateColumns = false;

            dataGridRepuestos.Columns[0].Name = "Código";
            dataGridRepuestos.Columns[0].DataPropertyName = "codRepuesto";

            dataGridRepuestos.Columns[1].Name = "Nombre";
            dataGridRepuestos.Columns[1].DataPropertyName = "nombre";

            dataGridRepuestos.Columns[2].Name = "Marca";
            dataGridRepuestos.Columns[2].DataPropertyName = "Marca";

            dataGridRepuestos.Columns[3].Name = "Modelo";
            dataGridRepuestos.Columns[3].DataPropertyName = "Modelo";

            dataGridRepuestos.Columns[4].Name = "Descripción";
            dataGridRepuestos.Columns[4].DataPropertyName = "descripcion";

            dataGridRepuestos.Columns[5].Name = "Precio";
            dataGridRepuestos.Columns[5].DataPropertyName = "precioUnitario";

            dataGridRepuestos.Columns[6].Name = "Stock";
            dataGridRepuestos.Columns[6].DataPropertyName = "stock";

            dataGridRepuestos.Columns[7].Name = "Fabricante";
            dataGridRepuestos.Columns[7].DataPropertyName = "fabricante";

            dataGridRepuestos.ReadOnly = true;
            this.dataGridRepuestos.MultiSelect = false;
            this.dataGridRepuestos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridRepuestos.AllowUserToAddRows = false;
        }

        private void PictureCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnConsultar_Click(object sender, EventArgs e)
        {
            string strCondiciones = "";

            if (!chkTodos.Checked)
            {
                txtCodRepuesto.Enabled = true;
                txtNombre.Enabled = true;
                cboMarca.Enabled = true;

                bool codOk = false;
                bool nomOk = false;
                bool marcaOk = false;

                if (!String.IsNullOrEmpty(txtCodRepuesto.Text))
                {
                    // Chequea que el input codigo contenga solo numeros
                    if (!int.TryParse(txtCodRepuesto.Text, out int codigo))
                    {
                        MessageBox.Show("El código debe contener solo números.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    codOk = true;
                    strCondiciones += "AND R.codRepuesto =" + txtCodRepuesto.Text + " ";
                }

                if (!String.IsNullOrEmpty(txtNombre.Text))
                {
                    nomOk = true;
                    strCondiciones += "AND R.nombre LIKE '%" + txtNombre.Text + "%' ";
                }

                if (!String.IsNullOrEmpty(cboMarca.Text))
                {
                    marcaOk = true;
                    strCondiciones += "AND R.codMarca=" + cboMarca.SelectedValue.ToString() + " ";
                }

                if (nomOk || codOk || marcaOk)
                {
                    IList<Repuesto> listaR = oRepuestoService.ConsultarRepuestos(strCondiciones);
                    if (listaR.Count > 0)
                        this.dataGridRepuestos.DataSource = listaR;
                    else
                        MessageBox.Show("No se encontró ningún repuesto.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se ingresó ningún criterio de búsqueda", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                this.CargarGrilla();
                this.btnAgregar.Enabled = true;
                this.txtCantidad.Enabled = true;
            }
        }

        private void CargarGrilla()
        {
            IList<Repuesto> listaRepuesto = oRepuestoService.ConsultarRepuestos("");
            if (listaRepuesto.Count >= 1)
                this.dataGridRepuestos.DataSource = listaRepuesto;
            else MessageBox.Show("No se encontraron repuestos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void FrmABMCRepuestos_Load(object sender, EventArgs e)
        {
            if (!consultaNormal)
            {
                this.btnAgregar.Visible = true;
                this.btnAgregar.Enabled = false;
                this.txtCantidad.Visible = true;
                this.txtCantidad.Enabled = false;
                this.txtCantidad.Value = 1;
                this.lblCantidad.Visible = true;
                
            }
            else
            {
                this.btnAgregar.Visible = false;
                this.txtCantidad.Visible = false;
                this.lblCantidad.Visible = false;
            }
            // Cargar ComboBox de Marcas
            cboMarca.DataSource = marca.RecuperarMarcas();
            cboMarca.DisplayMember = "nombre";
            cboMarca.ValueMember = "codMarca";
            cboMarca.SelectedIndex = -1;
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            frmABMRepuestos ABMRep = new frmABMRepuestos();
            ABMRep.ShowDialog();
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            Repuesto selected = (Repuesto)dataGridRepuestos.CurrentRow.DataBoundItem;

            frmABMRepuestos ABMRep = new frmABMRepuestos();
            ABMRep.SeleccionarRepuesto(frmABMRepuestos.FormMode.update, selected);
            ABMRep.ShowDialog();
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            Repuesto selected = (Repuesto)this.dataGridRepuestos.CurrentRow.DataBoundItem;

            if (MessageBox.Show("Seguro que desea eiminar el repuesto seleccionado?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                oRepuestoService.EliminarRepuesto(selected);

                if (chkTodos.Checked)
                {
                    this.CargarGrilla();
                }
                MessageBox.Show("Cliente eliminado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }



        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            Repuesto repAgregar = (Repuesto)dataGridRepuestos.CurrentRow.DataBoundItem;
            if (txtCantidad.Value <= repAgregar.Stock && txtCantidad.Value > 0)
            {
                frmDetallesOT frmPadre = this.Owner as frmDetallesOT;
                frmPadre.CargarRepuesto(repAgregar, Convert.ToInt32(txtCantidad.Value));
                MessageBox.Show("El repuesto se ha añadido con exito\nCantidad: " + txtCantidad.Value, "Repuesto añadido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtCantidad.Value = 1;
            }
            else
            {
                MessageBox.Show("Cantidad incorrecta, no hay suficiente stock\nStock actual: " + repAgregar.Stock, "Stock insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtCantidad.Value = 1;
            }
        }

        /*private void TxtCantidad_KeyPress(object sender, KeyPressEventArgs e)
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
        } No es necesario aparentemente */

        private void DataGridRepuestos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

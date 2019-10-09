using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TallerAutos.BusinessLayer;
using TallerAutos.Entities;

namespace TallerAutos.GUILayer
{
    public partial class frmABMRepuestos : Form
    {
        private FormMode formMode = FormMode.insert;
        private Repuesto repuestoSeleccionado;
        private RepuestoService oRepuestoService;
        private MarcaService oMarcaService;
        private ModeloService oModeloService;

        public frmABMRepuestos()
        {
            InitializeComponent();
            repuestoSeleccionado = new Repuesto();
            oMarcaService = new MarcaService();
            oModeloService = new ModeloService();
            oRepuestoService = new RepuestoService();
        }

        private void PictureCerrar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        internal void SeleccionarRepuesto(FormMode modo, Repuesto repuestoSel)
        {
            formMode = modo;
            repuestoSeleccionado = repuestoSel;
        }

        private void LlenarCombo(ComboBox combo, Object fuente, string display, String value)
        {
            combo.DataSource = fuente;
            combo.DisplayMember = display;
            combo.ValueMember = value;
            combo.SelectedIndex = -1;
        }

        public enum FormMode
        {
            insert,
            update
        }

        private void FrmABMRepuestos_Load(object sender, EventArgs e)
        {
            LlenarCombo(cboMarca, oMarcaService.RecuperarMarcas(), "nombre", "codMarca");
            LlenarCombo(cboModelo, oModeloService.RecuperarModelos(), "nombre", "codModelo");

            switch (formMode)
            {
                case FormMode.insert:
                    {
                        this.Text = "Cargar repuesto";
                        Habilitar(true);
                        break;
                    }

                case FormMode.update:
                    {
                        this.Text = "Editar repuesto";
                        this.MostrarDatos(repuestoSeleccionado);
                        Habilitar(true);
                        break;
                    }
            }
        }

        private void MostrarDatos(Repuesto r)
        {
            this.txtCodRepuesto.Text = r.CodRepuesto.ToString();
            this.txtNombre.Text = r.Nombre;
            this.cboMarca.SelectedValue = r.Marca.CodMarca;
            this.cboModelo.SelectedValue = r.Modelo.CodModelo;
            this.txtFabricante.Text = r.Fabricante;
            this.nudStock.Value = r.Stock;
            this.txtDescripcion.Text = r.Descripcion;
            this.txtPrecio.Text = r.PrecioUnitario.ToString();
        }

        private void Habilitar(bool x)
        {
            if(!x)
            {
                this.txtCodRepuesto.Enabled = false;
                this.txtNombre.Enabled = false;
                this.cboMarca.Enabled = false;
                this.cboModelo.Enabled = false;
                this.txtFabricante.Enabled = false;
                this.nudStock.Enabled = false;
                this.txtDescripcion.Enabled = false;
                this.txtPrecio.Enabled = false;
            }
            else
            {
                this.txtCodRepuesto.Enabled = false;
                this.txtNombre.Enabled = true;
                this.cboMarca.Enabled = true;
                this.cboModelo.Enabled = true;
                this.txtFabricante.Enabled = true;
                this.nudStock.Enabled = true;
                this.txtDescripcion.Enabled = true;
                this.txtPrecio.Enabled = true;
            }
        }

        private void BtnAceptarInfo_Click(object sender, EventArgs e)
        {
            switch (formMode)
            {
                case FormMode.insert:
                    {
                        if (ValidarCamposObl())
                        {
                            if (ValidarDatosIngresados() != "")
                                return;

                            Repuesto oRepuesto = new Repuesto();
                            LlenarDatosRepuesto(oRepuesto);

                            oRepuestoService.CargarRepuesto(oRepuesto);

                            MessageBox.Show("Repuesto cargado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            this.repuestoSeleccionado = oRepuesto;
                        }
                        else
                        {
                            MessageBox.Show("No se han completado uno o más campos obligatorios.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        break;
                    }
                case FormMode.update:
                    {
                        if (ValidarCamposObl())
                        {
                            if (ValidarDatosIngresados() != "")
                                return;
                            LlenarDatosRepuesto(repuestoSeleccionado);

                            oRepuestoService.ActualizarRepuesto(repuestoSeleccionado);

                            MessageBox.Show("Repuesto actualizado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Dispose();

                        }
                        else
                            MessageBox.Show("No se han completado uno o más campos obligatorios.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        break;
                    }
            }
        }

        private void LlenarDatosRepuesto(Repuesto r)
        {
            r.Marca = new Marca();
            r.Modelo = new Modelo();
            r.Nombre = this.txtNombre.Text;
            r.Fabricante = this.txtFabricante.Text;
            r.Stock = Convert.ToInt32(this.nudStock.Value);
            r.Descripcion = this.txtDescripcion.Text;
            r.Marca.CodMarca = Convert.ToInt32(this.cboMarca.SelectedValue);
            r.Modelo.CodModelo = Convert.ToInt32(this.cboModelo.SelectedValue);
            r.PrecioUnitario = Convert.ToDecimal(this.txtPrecio.Text);
        }

        private bool ValidarCamposObl()
        {
            if(String.IsNullOrEmpty(this.txtNombre.Text) || cboMarca.SelectedIndex == -1 || cboModelo.SelectedIndex == -1 || 
                String.IsNullOrEmpty(nudStock.Value.ToString()) || String.IsNullOrEmpty(this.txtPrecio.Text))
            {
                return false;
            }
            return true;
        }

        private string ValidarDatosIngresados()
        {
            if (!int.TryParse(this.txtPrecio.Text.Replace(",",""), out int codigo))
            {
                MessageBox.Show("El precio debe contener solo números.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return "-";
            }
            return "";
        }
    }
}

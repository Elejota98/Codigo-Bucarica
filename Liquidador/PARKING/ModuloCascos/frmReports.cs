using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModuloCascos
{
    public partial class frmReports : Form
    {
        public frmReports()
        {
            InitializeComponent();
        }

        private void frmReports_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
            

        }

        private void button1_Click(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
            string FF = dtpInicial.Value.ToShortDateString();
            string DD = dtpFinal.Value.ToShortDateString();
            string[] Fecha = FF.Split('/');
            string[] FIN = DD.Split('/');

            string INICIO = Fecha[2] + "-" + Fecha[1] + "-" + Fecha[0] + " " + tbHoraIni.Text;
            string FINAL = FIN[2] + "-" + FIN[1] + "-" + FIN[0] + " " + tbHoraFin.Text;
            
            // TODO: esta línea de código carga datos en la tabla 'DataSetFacturas.DataTable1' Puede moverla o quitarla según sea necesario.
            this.DataTable1TableAdapter.Fill(this.DataSetFacturas.DataTable1, Convert.ToDateTime(INICIO), Convert.ToDateTime(FINAL));
            // TODO: esta línea de código carga datos en la tabla 'DataSetFacturas.T_Movimientos' Puede moverla o quitarla según sea necesario.
            this.reportViewer1.RefreshReport();
        }
    }
}

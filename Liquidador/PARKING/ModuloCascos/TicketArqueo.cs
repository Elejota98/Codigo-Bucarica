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
    public partial class TicketArqueo : Form
    {
        long _ID = 0;

        public TicketArqueo(long IDT)
        {
            _ID = IDT;
            InitializeComponent();
        }

        private void TicketArqueo_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'DataSetFacturas.T_Arqueos' Puede moverla o quitarla según sea necesario.
            this.T_ArqueosTableAdapter.Fill(this.DataSetFacturas.T_Arqueos,_ID);

            this.reportViewer1.RefreshReport();
        }
    }
}

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
    public partial class TicketEntrada : Form
    {
        long _ID = 0;

        public TicketEntrada(long idt)
        {
            _ID = idt;
            InitializeComponent();
        }

        private void TicketEntrada_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'DataSetFacturas.T_Movimientos' Puede moverla o quitarla según sea necesario.
            this.T_MovimientosTableAdapter.Fill(this.DataSetFacturas.T_Movimientos, _ID);

            this.reportViewer1.RefreshReport();
        }
    }
}

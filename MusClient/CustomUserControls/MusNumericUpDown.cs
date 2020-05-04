using MusClient.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusClient.CustomUserControls
{
    public class MusNumericUpDown : NumericUpDown, IMusChangePoints
    {
        public int UserPointsChanged { get; set; }
        public DateTime ChangePointsDate { get; set; } = DateTime.MaxValue;
        public int MusValor
        {
            get { return (int)this.Value; }
            set
            {
                this.Value = value;
                this.Tag = value;
            }
        }
        public bool MusEnabled
        {
            get { return this.Enabled; }
            set { this.Enabled = value; }
        }

    }
}

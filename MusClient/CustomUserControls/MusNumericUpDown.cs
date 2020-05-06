using MusClient.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusClient.CustomUserControls
{
    public class MusNumericUpDown : NumericUpDown, IMusChangePoints
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public int UserPointsChanged { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public DateTime ChangePointsDate { get; set; } = DateTime.MaxValue;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public int MusValor
        {
            get { return (int)this.Value; }
            set
            {
                this.Value = value;
                this.Tag = value;
            }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public bool MusEnabled
        {
            get { return this.Enabled; }
            set { this.Enabled = value; }
        }

    }
}

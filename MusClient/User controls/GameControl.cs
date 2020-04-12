using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MusClient.Interface;

namespace MusClient.User_controls
{
    public partial class GameControl : UserControl
    {
        IGeneralData generalData;
        public GameControl(IGeneralData generalData)
        {
            InitializeComponent();
            this.generalData = generalData;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Conway_s_Game_of_Life
{
    public partial class SetIntervalWindow : Form
    {
        public int timeInterval
        {
            get
            {
                return (int)intervalInput.Value;
            }
        }
        public SetIntervalWindow(int interval)
        {
            InitializeComponent();
            intervalInput.Value = interval;
        }
    }
}

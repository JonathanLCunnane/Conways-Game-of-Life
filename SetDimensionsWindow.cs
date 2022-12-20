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
    public partial class SetDimensionsWindow : Form
    {
        public int x
        {
            get
            {
                return (int)xInput.Value;
            }
        }
        public int y
        {
            get
            {
                return (int)yInput.Value;
            }
        }
        public SetDimensionsWindow(int startingX, int startingY)
        {
            InitializeComponent();
            xInput.Value = startingX;
            yInput.Value = startingY;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pentapox
{
    public partial class PalettePicture : PictureBox
    {
        public PalettePicture()
        {
            InitializeComponent();
        }
        public PalettePicture(FiveBitColor color)
        {
            InitializeComponent();
            this.SetColor(color);
        }
        public PalettePicture(FiveBitColor color, Size imageSize)
        {
            InitializeComponent();
            this.Size = imageSize;
            this.SetColor(color);
        }
        public PalettePicture(Color color, Size imageSize)
        {
            InitializeComponent();
            this.Size = imageSize;
            this.SetColor(color);
        }

        public void SetColor(FiveBitColor color)
        {
            Color = color;
            this.Image = Color.ToImage(this.Size);
        }
        public void SetColor(Color color)
        {
            FiveBitColor convert = new FiveBitColor(color);
            Color = convert;
            this.Image = Color.ToImage(this.Size);
        }
        public FiveBitColor Get5bitColor()
        {
            return Color;
        }
        private FiveBitColor Color { set; get; }
    }
}

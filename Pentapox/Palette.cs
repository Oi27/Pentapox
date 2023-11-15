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
    public partial class Palette : Panel
    {
        //Palette is a collection of 16 PalettePictures
        private Color DefaultPalette = Color.Black;
        private Size PaletteSquareSize = new Size(15, 20);
        public PalettePicture ColorPreview { set; get; }
        public Palette()
        {
            //new palette with no args autofills all the colors to a default
            InitializeComponent();
            for(byte i = 0; i < 16; i++)
            {
                FiveBitColor gradientColor = new FiveBitColor(i,i,i);
                PalettePicture addThis = new PalettePicture(gradientColor, PaletteSquareSize)
                {
                    Location = new Point(i * PaletteSquareSize.Width, 0),
                };
                addThis.Click += PaletteColor_Click;
                this.Controls.Add(addThis);
            }
            this.Size = new Size(PaletteSquareSize.Width * 16, PaletteSquareSize.Height);
            this.ColorPreview = null;
        }
        private void PaletteColor_Click(object sender, EventArgs e)
        {
            if(ColorPreview == null) { return; }
            PalettePicture clicked = (PalettePicture)sender;
            ColorPreview.SetColor(clicked.Get5bitColor());
        }
    }
}

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
        private Size PaletteSquareSize = new Size(15, 20);
        public PalettePicture ColorPreview { set; get; }
        public Palette()
        {
            //new palette with no args autofills all the colors to a default gradient
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
            PentaPox mainWindow = (PentaPox)this.FindForm();
            this.ColorPreview = null;
        }
        public Palette(Palette copyThis)
        {
            for (int i = 0; i < copyThis.Controls.Count; i++)
            {
                PalettePicture original = (PalettePicture)copyThis.Controls[i];
                PalettePicture newEntry = new PalettePicture(original);
                newEntry.Click += PaletteColor_Click;
                this.Controls.Add(newEntry);
            }
            this.Size = copyThis.Size;
            this.ColorPreview = copyThis.ColorPreview;
        }
        private void PaletteColor_Click(object sender, EventArgs e)
        {
            //Uses FindForm to get the main window no matter where it is
            if(ColorPreview == null) { return; }
            PalettePicture clicked = (PalettePicture)sender;
            ColorPreview.SetColor(clicked.Get5bitColor());
            PentaPox mainWindow = (PentaPox)clicked.FindForm();
            mainWindow.ActiveColor = clicked;

            FiveBitColor colorClicked = clicked.Get5bitColor();
            mainWindow.RedScrollBar.Value = colorClicked.Red;
            mainWindow.GreenScrollBar.Value = colorClicked.Green;
            mainWindow.BlueScrollBar.Value = colorClicked.Blue;
            mainWindow.ColorBar_Scroll(null, null);
        }
    }
}

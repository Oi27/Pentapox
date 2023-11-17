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
        //Line number is initalized to -1 & set to a real number by caller, if necessary.
        private Size PaletteSquareSize = new Size(15, 20);
        public PalettePicture ColorPreview { set; get; }
        public bool FxPreview { set; get; }
        public int LineNumber { set; get; }
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
                    Tag = new PalettePictureTags(i),
                };
                addThis.Click += PaletteColor_Click;
                this.Controls.Add(addThis);
            }
            this.Size = new Size(PaletteSquareSize.Width * 16, PaletteSquareSize.Height);
            PentaPox mainWindow = (PentaPox)this.FindForm();
            this.LineNumber = -1;
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
            //doesn't update the palette index viewer unless the palette was explicitly given a line number.
            //(^feels pretty safe.)
            PentaPox mainWindow = (PentaPox)this.FindForm();
            PalettePicture clicked = (PalettePicture)sender;
            Palette clickedPalette = (Palette)clicked.Parent;
            if(ColorPreview == null) { return; }
            ColorPreview.SetColor(clicked.Get5bitColor());
            mainWindow.ActiveColor = clicked;

            FiveBitColor colorClicked = clicked.Get5bitColor();
            mainWindow.RedScrollBar.Value = colorClicked.Red;
            mainWindow.GreenScrollBar.Value = colorClicked.Green;
            mainWindow.BlueScrollBar.Value = colorClicked.Blue;
            mainWindow.ColorBar_Scroll(null, null);

            int paletteLine = clickedPalette.LineNumber;
            mainWindow.UpdateFxPreviewLine(paletteLine);
            mainWindow.ActivePaletteLine = paletteLine;

            PalettePictureTags palTag = (PalettePictureTags)clicked.Tag;
            if (paletteLine < 0 || palTag == null) { return; }
            int relativePaletteIndex = palTag.RelativeIndex;
            int realPaletteIndex = (paletteLine * 16) + relativePaletteIndex;
            mainWindow.ActivePaletteIndexBox.Text = realPaletteIndex.ToString("X4");
        }
    }
}

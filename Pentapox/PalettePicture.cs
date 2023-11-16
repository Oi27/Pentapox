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

        public PalettePicture(PalettePicture copyThis)
        {
            //copies location exclusively for when copied for copying palettes... might need more copy methods
            SetColor(new FiveBitColor(copyThis.Color));
            this.Size = copyThis.Size;
            this.Location = copyThis.Location;
            this.Tag = new PalettePictureTags((PalettePictureTags)copyThis.Tag);
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
    public class PalettePictureTags
    {
        //relative index 
        public PalettePictureTags(int i)
        {
            RelativeIndex = i;
            AestheticOnly = false;
        }

        public PalettePictureTags(PalettePictureTags copyThis)
        {
            if(copyThis == null) { return; }
            RelativeIndex = copyThis.RelativeIndex;
            AestheticOnly = copyThis.AestheticOnly;
        }
        public int RelativeIndex { set; get; }
        public bool AestheticOnly { set; get; }
    }
}

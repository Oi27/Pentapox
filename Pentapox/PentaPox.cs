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
    public partial class PentaPox : Form
    {
        //Global Constants
        Size PalettesExtended = new Size(480, 210);
        Size PalettesHidden = new Size(210, 210);
        Size PaletteImageSize = new Size(20, 20);

        public PentaPox()
        {
            InitializeComponent();
            UpdateColorCodeBoxes();
            this.Size = PalettesExtended;
        }

        private FiveBitColor ColorFromScrollBars()
        {
            byte R = (byte)RedScrollBar.Value;
            byte G = (byte)GreenScrollBar.Value;
            byte B = (byte)BlueScrollBar.Value;
            return new FiveBitColor(R, G, B);
        }

        private void ColorBar_Scroll(object sender, EventArgs e)
        {
            TrackBar A = (TrackBar)sender;
            UpdateColorCodeBoxes();
            UpdateColorValueBoxes();
        }

        private void UpdateColorValueBoxes()
        {
            foreach (Control item in ColorValueSliders.Controls)
            {
                TrackBar slider = (TrackBar)item;
                foreach (Control box in ColorValueBoxes.Controls)
                {
                    //locate the control with the matching tag and propagate values
                    if(box.Tag == slider.Tag)
                    {
                        box.Text = slider.Value.ToString("X2");
                        break;
                    }
                }
            }
        }

        private void UpdateColorValueSlidersFromColorValueBoxes()
        {
            foreach (Control item in ColorValueBoxes.Controls)
            {
                TextBox box = (TextBox)item;
                foreach (Control item2 in ColorValueSliders.Controls)
                {
                    //locate the control with the matching tag and propagate values
                    TrackBar slider = (TrackBar)item2;
                    if (box.Tag == slider.Tag)
                    {
                        slider.Value = int.Parse(box.Text, System.Globalization.NumberStyles.HexNumber);
                        break;
                    }
                }
            }
        }

        private void UpdateColorCodeBoxes()
        {
            FiveBitColor color = ColorFromScrollBars();
            FiveBPP.Text = color.ToFiveBGR().ToString("X4");
            TwentyFourBPP.Text =
                color.To24BPP().R.ToString("X2") +
                color.To24BPP().G.ToString("X2") +
                color.To24BPP().B.ToString("X2");
            UpdatePreview(color);
        }

        private void UpdateColorValueSliders(FiveBitColor color)
        {
            RedScrollBar.Value = color.Red;
            GreenScrollBar.Value = color.Green;
            BlueScrollBar.Value = color.Blue;
            UpdateColorValueBoxes();
        }

        private void ColorValueBox_Leave(object sender, EventArgs e)
        {
            UpdateColorValueSlidersFromColorValueBoxes();
            UpdateColorCodeBoxes();
        }

        private void FiveBPP_Leave(object sender, EventArgs e)
        {
            FiveBitColor color = new FiveBitColor(short.Parse(FiveBPP.Text, System.Globalization.NumberStyles.HexNumber));
            UpdateColorValueSliders(color);
            UpdateColorCodeBoxes();
        }

        private void TwentyFourBPP_Leave(object sender, EventArgs e)
        {
            Color newColor = Color.FromArgb(int.Parse(TwentyFourBPP.Text, System.Globalization.NumberStyles.HexNumber));
            FiveBitColor color = new FiveBitColor(newColor);
            UpdateColorValueSliders(color);
            UpdateColorCodeBoxes();
        }

        private void UpdatePreview(FiveBitColor color)
        {
            ColorPreview.Image = color.ToImage(PaletteImageSize);
            ColorPreview.Size = PaletteImageSize;
        }

        private void ShowPalettes_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem A = (ToolStripMenuItem)sender;
            if (A.Checked)
            {
                this.Size = PalettesExtended;
            }
            else
            {
                this.Size = PalettesHidden;
            }
        }
    }

    public class FiveBitColor
    {
        public FiveBitColor(byte R, byte G, byte B)
        {
            //byte data type to construct from 5BPP data 00-1F
            //if any numbers invalid black out all of them
            bool colorsValid = (R > 32) && (G > 32) && (B > 32);
            if (!colorsValid) 
            {
                Red = 0;
                Green = 0;
                Blue = 0;
            }
            Red = R;
            Green = G;
            Blue = B;
        }
        public FiveBitColor(Color RGB)
        {
            //24bit color
            Red = RGB.R / 8;
            Green = RGB.G / 8;
            Blue = RGB.B / 8;
        }
        public FiveBitColor(short RGB)
        {
            //0bbb bbgg gggr rrrr 
            Red = RGB & 0x001F;
            Green = (RGB & 0x03E0) >> 5;
            Blue = (RGB & 0x7C00) >> 10;
        }
        public int ToFiveBGR()
        {
            return Red | (Green << 5) | (Blue << 10);
        }
        public Color To24BPP()
        {
            return Color.FromArgb(Red * 8, Green * 8, Blue * 8);
        }
        public Bitmap ToImage(Size ImageSize)
        {
            int width = ImageSize.Width;
            int height = ImageSize.Height;
            Bitmap image = new Bitmap(width, height);
            Color thisColor = this.To24BPP();
            for(int x = 0; x < image.Width; x++)
            {
                for(int y = 0; y < image.Height; y++)
                {
                    image.SetPixel(x, y, thisColor);
                }
            }
            return image;
        }
        public int Red { set; get; }
        public int Green { set; get; }
        public int Blue { set; get; }
    }
}

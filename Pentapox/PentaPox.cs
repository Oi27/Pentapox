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
        //The size of the PalettePictures is a property of the Palette object.
        public PalettePicture ActiveColor { set; get; }
        public Palette AnimatedPalette { set; get; }
        public int ActivePaletteLine { set; get; }
        public PentaPox()
        {
            InitializeComponent();
            this.ActiveColor = null;
            for(int i = 0; i < 16; i++)
            {
                Palette newPalette = new Palette(16)
                {
                    ColorPreview = this.ColorPreview,
                    LineNumber = i,
                };
                newPalette.Location = new Point(0, i * newPalette.Size.Height);
                PalettePanel.Controls.Add(newPalette);
            }
            PalettePanel_SizeChanged(PalettePanel, null);
            UpdateFxPreviewLine(0);
            UpdateColorCodeBoxes();

            PaletteFxLine news = new PaletteFxLine(3) 
            { 
                Location = new Point(300, 100),                
            };
            news.Pal.ColorPreview = this.ColorPreview;

            this.Controls.Add(news);
            news.BringToFront();
        }

        public void UpdateFxPreviewLine(int paletteLine)
        {
            //adds "someNew" in front of AnimatedPalette before deleting & replacing the object in the AnimatedPalette property.
            //makes the transition smoother than removing the property first :D
            const string paletteName = "AnimatedFxPreview";
            if(paletteLine == -1) { return; }
            Palette someNew = new Palette((Palette)PalettePanel.Controls[paletteLine])
            {
                Location = AnimPaletteLabel.Location,
                Name = paletteName,
                ColorPreview = null,
            };
            this.Controls.Add(someNew);
            someNew.BringToFront();

            bool fxLinePresent = this.Controls.Contains(AnimatedPalette);
            if (fxLinePresent)
            {
                this.Controls.Remove(AnimatedPalette);
            }

            AnimatedPalette = someNew;
        }

        private FiveBitColor ColorFromScrollBars()
        {
            byte R = (byte)RedScrollBar.Value;
            byte G = (byte)GreenScrollBar.Value;
            byte B = (byte)BlueScrollBar.Value;
            return new FiveBitColor(R, G, B);
        }

        public void ColorBar_Scroll(object sender, EventArgs e)
        {
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
            UpdateActiveColor(color);
            StepFxPreviewColor(color);
        }

        private void StepFxPreviewColor(FiveBitColor color)
        {
            if(ActiveColor == null) { return; }
            PalettePictureTags A = (PalettePictureTags)ActiveColor.Tag;
            int read = A.RelativeIndex;
            PalettePicture toUpdate = (PalettePicture)AnimatedPalette.Controls[read];
            toUpdate.SetColor(color);
        }

        private void UpdateActiveColor(FiveBitColor color)
        {
            if (ActiveColor == null) { return; }
            ActiveColor.SetColor(color);
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
            ColorPreview.SetColor(color);
        }

        private void ShowPalettes_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem A = (ToolStripMenuItem)sender;
            if (A.Checked)
            {
                //this.Size = PalettesExtended;
            }
            else
            {
                //this.Size = PalettesHidden;
            }
        }

        private void PentaPox_SizeChanged(object sender, EventArgs e)
        {
            this.Text = this.Size.ToString();
        }

        private void PalettePanel_SizeChanged(object sender, EventArgs e)
        {
            //if the size of the control is smaller than the size of the contents, vertically, then:
            //turn on autoscroll
            //increase size of control to account for scrollbar appearance
            //(why is the scrollbar 21 pixels wide??)
            Panel panel = (Panel)sender;
            int scrollBarSize = 21;
            Size scrollsOn = new Size(panel.Controls[0].Width + scrollBarSize, panel.Height);
            Size scrollsOff = new Size(panel.Controls[0].Width, panel.Height);
            int sizeContents = panel.Controls[0].Height * panel.Controls.Count;
            if(panel.Height < sizeContents)
            {
                //enable scrolls & change size
                panel.AutoScroll = true;
                panel.Size = scrollsOn;
            }
            else
            {
                panel.AutoScroll = false;
                panel.Size = scrollsOff;
            }
        }
    }

    public class FiveBitColor
    {
        public FiveBitColor(FiveBitColor copyThis)
        {
            Red = copyThis.Red;
            Blue = copyThis.Blue;
            Green = copyThis.Green;
        }
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

    public class PaletteFxInstruction
    {
        //goto [paletteFxLine]
        //delete
        //maybe more? 
    }
    public class PaletteFxData
    {
        //contains frame delay, list of FiveBitColors, and optional flow instruction
        //in theory each line could contain a different number of colors, so it should be supported.
    }
    public class PaletteFX
    {
        //contains starting offset and list of PaletteFxLines
    }
}

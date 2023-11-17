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
    public partial class PaletteFxLine : Panel
    {
        //contains 3 controls: a palette of user determined number count, a number picker that determines that count, and a number picker for the frame delay.
        public NumericUpDown ColorCount { set; get; }
        public NumericUpDown FrameDelay { set; get; }
        public Palette Pal { set; get; }

        Point frameDelayLocation = new Point(0, 0);        
        const int defaultFrameDelay = 4;
        public PaletteFxLine(int paletteLength)
        {
            InitializeComponent();
            NumericUpDown frameDelay = new NumericUpDown()
            {
                Name = "FrameDelay",
                Location = frameDelayLocation,
                Hexadecimal = true,
                Value = defaultFrameDelay,
                Maximum = 0x7FFF,
                Minimum = 1,
                Increment = 1,
                Size = new Size(60, 20),
            };
            NumericUpDown colorCount = new NumericUpDown()
            {
                Name = "ColorCount",
                Location = new Point(frameDelay.Location.X + frameDelay.Size.Width + 40, 0),
                Hexadecimal = true,
                Value = paletteLength,
                Maximum = 0x10,
                Minimum = 1,
                Increment = 1,
                Size = new Size(40, 20),
            };
            Palette pal = new Palette(paletteLength)
            {
                Name = "Palette",
                //ColorPreview = mainWindow.ColorPreview,
                Location = new Point(frameDelay.Location.X + 20, frameDelay.Location.Y + frameDelay.Size.Height + 5),
            };
            this.Controls.Add(colorCount);
            this.Controls.Add(frameDelay);
            this.Controls.Add(pal);
            ColorCount = colorCount;
            FrameDelay = frameDelay;
            Pal = pal;
        }
    }
}

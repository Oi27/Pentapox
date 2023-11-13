
namespace Pentapox
{
    partial class PentaPox
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ColorPreview = new System.Windows.Forms.PictureBox();
            this.RedValue = new System.Windows.Forms.TextBox();
            this.GreenValue = new System.Windows.Forms.TextBox();
            this.BlueValue = new System.Windows.Forms.TextBox();
            this.PentaMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadpalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutPenta = new System.Windows.Forms.ToolStripMenuItem();
            this.PentaVersion = new System.Windows.Forms.ToolStripMenuItem();
            this.FiveBPP = new System.Windows.Forms.TextBox();
            this.TwentyFourBPP = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.RedScrollBar = new System.Windows.Forms.TrackBar();
            this.GreenScrollBar = new System.Windows.Forms.TrackBar();
            this.BlueScrollBar = new System.Windows.Forms.TrackBar();
            this.ColorValueSliders = new System.Windows.Forms.Panel();
            this.ColorValueBoxes = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.ColorPreview)).BeginInit();
            this.PentaMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RedScrollBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GreenScrollBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlueScrollBar)).BeginInit();
            this.ColorValueSliders.SuspendLayout();
            this.ColorValueBoxes.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(15, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "R";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "G";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "B";
            // 
            // ColorPreview
            // 
            this.ColorPreview.Location = new System.Drawing.Point(169, 50);
            this.ColorPreview.Name = "ColorPreview";
            this.ColorPreview.Size = new System.Drawing.Size(35, 58);
            this.ColorPreview.TabIndex = 6;
            this.ColorPreview.TabStop = false;
            // 
            // RedValue
            // 
            this.RedValue.Location = new System.Drawing.Point(3, 3);
            this.RedValue.MaxLength = 2;
            this.RedValue.Name = "RedValue";
            this.RedValue.Size = new System.Drawing.Size(34, 20);
            this.RedValue.TabIndex = 7;
            this.RedValue.Tag = "R";
            this.RedValue.Text = "00";
            this.RedValue.Leave += new System.EventHandler(this.ColorValueBox_Leave);
            // 
            // GreenValue
            // 
            this.GreenValue.Location = new System.Drawing.Point(3, 29);
            this.GreenValue.MaxLength = 2;
            this.GreenValue.Name = "GreenValue";
            this.GreenValue.Size = new System.Drawing.Size(34, 20);
            this.GreenValue.TabIndex = 8;
            this.GreenValue.Tag = "G";
            this.GreenValue.Text = "00";
            this.GreenValue.Leave += new System.EventHandler(this.ColorValueBox_Leave);
            // 
            // BlueValue
            // 
            this.BlueValue.Location = new System.Drawing.Point(3, 55);
            this.BlueValue.MaxLength = 2;
            this.BlueValue.Name = "BlueValue";
            this.BlueValue.Size = new System.Drawing.Size(34, 20);
            this.BlueValue.TabIndex = 9;
            this.BlueValue.Tag = "B";
            this.BlueValue.Text = "00";
            this.BlueValue.Leave += new System.EventHandler(this.ColorValueBox_Leave);
            // 
            // PentaMenuStrip
            // 
            this.PentaMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.aboutPenta});
            this.PentaMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.PentaMenuStrip.Name = "PentaMenuStrip";
            this.PentaMenuStrip.Size = new System.Drawing.Size(228, 24);
            this.PentaMenuStrip.TabIndex = 10;
            this.PentaMenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadpalToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // loadpalToolStripMenuItem
            // 
            this.loadpalToolStripMenuItem.Enabled = false;
            this.loadpalToolStripMenuItem.Name = "loadpalToolStripMenuItem";
            this.loadpalToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.loadpalToolStripMenuItem.Text = "Load .pal";
            // 
            // aboutPenta
            // 
            this.aboutPenta.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PentaVersion});
            this.aboutPenta.Name = "aboutPenta";
            this.aboutPenta.Size = new System.Drawing.Size(52, 20);
            this.aboutPenta.Text = "About";
            // 
            // PentaVersion
            // 
            this.PentaVersion.Enabled = false;
            this.PentaVersion.Name = "PentaVersion";
            this.PentaVersion.Size = new System.Drawing.Size(180, 22);
            this.PentaVersion.Text = "PentaPox v.0.0.1";
            // 
            // FiveBPP
            // 
            this.FiveBPP.Location = new System.Drawing.Point(29, 130);
            this.FiveBPP.MaxLength = 4;
            this.FiveBPP.Name = "FiveBPP";
            this.FiveBPP.Size = new System.Drawing.Size(47, 20);
            this.FiveBPP.TabIndex = 11;
            this.FiveBPP.Text = "0000";
            this.FiveBPP.Leave += new System.EventHandler(this.FiveBPP_Leave);
            // 
            // TwentyFourBPP
            // 
            this.TwentyFourBPP.Location = new System.Drawing.Point(101, 130);
            this.TwentyFourBPP.MaxLength = 6;
            this.TwentyFourBPP.Name = "TwentyFourBPP";
            this.TwentyFourBPP.Size = new System.Drawing.Size(57, 20);
            this.TwentyFourBPP.TabIndex = 12;
            this.TwentyFourBPP.Text = "000000";
            this.TwentyFourBPP.Leave += new System.EventHandler(this.TwentyFourBPP_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "5-Bit BGR";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(98, 114);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "24-Bit RGB";
            // 
            // RedScrollBar
            // 
            this.RedScrollBar.Location = new System.Drawing.Point(3, 4);
            this.RedScrollBar.Maximum = 31;
            this.RedScrollBar.Name = "RedScrollBar";
            this.RedScrollBar.Size = new System.Drawing.Size(76, 45);
            this.RedScrollBar.TabIndex = 15;
            this.RedScrollBar.TabStop = false;
            this.RedScrollBar.Tag = "R";
            this.RedScrollBar.TickFrequency = 0;
            this.RedScrollBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.RedScrollBar.Scroll += new System.EventHandler(this.ColorBar_Scroll);
            // 
            // GreenScrollBar
            // 
            this.GreenScrollBar.Location = new System.Drawing.Point(3, 21);
            this.GreenScrollBar.Maximum = 31;
            this.GreenScrollBar.Name = "GreenScrollBar";
            this.GreenScrollBar.Size = new System.Drawing.Size(76, 45);
            this.GreenScrollBar.TabIndex = 16;
            this.GreenScrollBar.TabStop = false;
            this.GreenScrollBar.Tag = "G";
            this.GreenScrollBar.TickFrequency = 0;
            this.GreenScrollBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.GreenScrollBar.Scroll += new System.EventHandler(this.ColorBar_Scroll);
            // 
            // BlueScrollBar
            // 
            this.BlueScrollBar.Location = new System.Drawing.Point(3, 37);
            this.BlueScrollBar.Maximum = 31;
            this.BlueScrollBar.Name = "BlueScrollBar";
            this.BlueScrollBar.Size = new System.Drawing.Size(76, 45);
            this.BlueScrollBar.TabIndex = 17;
            this.BlueScrollBar.TabStop = false;
            this.BlueScrollBar.Tag = "B";
            this.BlueScrollBar.TickFrequency = 0;
            this.BlueScrollBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.BlueScrollBar.Scroll += new System.EventHandler(this.ColorBar_Scroll);
            // 
            // ColorValueSliders
            // 
            this.ColorValueSliders.Controls.Add(this.BlueScrollBar);
            this.ColorValueSliders.Controls.Add(this.GreenScrollBar);
            this.ColorValueSliders.Controls.Add(this.RedScrollBar);
            this.ColorValueSliders.Location = new System.Drawing.Point(40, 46);
            this.ColorValueSliders.Name = "ColorValueSliders";
            this.ColorValueSliders.Size = new System.Drawing.Size(80, 61);
            this.ColorValueSliders.TabIndex = 18;
            // 
            // ColorValueBoxes
            // 
            this.ColorValueBoxes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ColorValueBoxes.Controls.Add(this.RedValue);
            this.ColorValueBoxes.Controls.Add(this.GreenValue);
            this.ColorValueBoxes.Controls.Add(this.BlueValue);
            this.ColorValueBoxes.Location = new System.Drawing.Point(122, 39);
            this.ColorValueBoxes.Name = "ColorValueBoxes";
            this.ColorValueBoxes.Size = new System.Drawing.Size(41, 85);
            this.ColorValueBoxes.TabIndex = 19;
            // 
            // PentaPox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(228, 193);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ColorValueBoxes);
            this.Controls.Add(this.ColorValueSliders);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TwentyFourBPP);
            this.Controls.Add(this.FiveBPP);
            this.Controls.Add(this.ColorPreview);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PentaMenuStrip);
            this.MainMenuStrip = this.PentaMenuStrip;
            this.Name = "PentaPox";
            this.Text = "PentaPox";
            ((System.ComponentModel.ISupportInitialize)(this.ColorPreview)).EndInit();
            this.PentaMenuStrip.ResumeLayout(false);
            this.PentaMenuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RedScrollBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GreenScrollBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlueScrollBar)).EndInit();
            this.ColorValueSliders.ResumeLayout(false);
            this.ColorValueSliders.PerformLayout();
            this.ColorValueBoxes.ResumeLayout(false);
            this.ColorValueBoxes.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox ColorPreview;
        private System.Windows.Forms.TextBox RedValue;
        private System.Windows.Forms.TextBox GreenValue;
        private System.Windows.Forms.TextBox BlueValue;
        private System.Windows.Forms.MenuStrip PentaMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutPenta;
        private System.Windows.Forms.TextBox FiveBPP;
        private System.Windows.Forms.TextBox TwentyFourBPP;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TrackBar RedScrollBar;
        private System.Windows.Forms.TrackBar GreenScrollBar;
        private System.Windows.Forms.TrackBar BlueScrollBar;
        private System.Windows.Forms.Panel ColorValueSliders;
        private System.Windows.Forms.FlowLayoutPanel ColorValueBoxes;
        private System.Windows.Forms.ToolStripMenuItem loadpalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PentaVersion;
    }
}


using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ViperBytes.Windows.Forms
{
    /// <summary>
    /// An isometrix box filled with colored water
    /// You can change the height in %.
    /// 
    /// (c) Copyright Vincent Wochnik 2007
    /// </summary>
    class WaterBox : Control
    {
        #region private fields
        /// <summary>
        /// Specifyes the border color
        /// </summary>
        private Color borderColor = Color.DimGray;

        /// <summary>
        /// Specifyes border width
        /// </summary>
        private float borderWidth = 1;

        /// <summary>
        /// Specifyes light fill color
        /// </summary>
        private Color lightFillColor = Color.FromArgb(224, 90, 150, 200);

        /// <summary>
        /// Specifyes dark fill color
        /// </summary>
        private Color darkFillColor = Color.FromArgb(224, 50, 110, 160);

        /// <summary>
        /// Specifyes light background color
        /// </summary>
        private Color lightBackColor = Color.FromArgb(127, 193, 236, 250);

        /// <summary>
        /// Specifyes dark background color
        /// </summary>
        private Color darkBackColor = Color.FromArgb(127, 153, 196, 210);

        /// <summary>
        /// Specifyes, wheather a top is drawn
        /// </summary>
        private bool drawTop = false;

        /// <summary>
        /// Specifyes scala separators
        /// </summary>
        private int separators = 5;

        /// <summary>
        /// The width of separator from 0 to 100 percent
        /// </summary>
        private int separatorWidth = 15;

        /// <summary>
        /// Specifyes the value
        /// </summary>
        private int value = 0;
        #endregion

        #region properties
        /// <summary>
        /// Border color
        /// </summary>
        [Browsable(true)]
        [Category("Appearance")]
        [Description("The color of the box's border")]
        [DefaultValue(typeof(Color), "DimGray")]
        public Color BorderColor
        {
            get
            {
                return this.borderColor;
            }
            set
            {
                if (this.borderColor != value)
                {
                    this.borderColor = value;
                    Invalidate();
                    OnBorderColorChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Border width
        /// </summary>
        [Browsable(true)]
        [Category("Appearance")]
        [Description("Thickness of box's border")]
        [DefaultValue(1)]
        public float BorderWidth
        {
            get
            {
                return this.borderWidth;
            }
            set
            {
                if (this.borderWidth != value)
                {
                    this.borderWidth = value;
                    Invalidate();
                    OnBorderWidthChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Light fill color
        /// </summary>
        [Browsable(true)]
        [Category("Appearance")]
        [Description("The light fill color of water")]
        public Color LightFillColor
        {
            get
            {
                return this.lightFillColor;
            }
            set
            {
                if (this.lightFillColor != value)
                {
                    this.lightFillColor = value;
                    Invalidate();
                    OnLightFillColorChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Dark fill color
        /// </summary>
        [Browsable(true)]
        [Category("Appearance")]
        [Description("The dark fill color of water")]
        public Color DarkFillColor
        {
            get
            {
                return this.darkFillColor;
            }
            set
            {
                if (this.darkFillColor != value)
                {
                    this.darkFillColor = value;
                    Invalidate();
                    OnDarkFillColorChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Light background color
        /// </summary>
        [Browsable(true)]
        [Category("Appearance")]
        [Description("The light fill color of the box's wall")]
        public Color LightBackColor
        {
            get
            {
                return this.lightBackColor;
            }
            set
            {
                if (this.lightBackColor != value)
                {
                    this.lightBackColor = value;
                    Invalidate();
                    OnLightBackColorChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Dark background color
        /// </summary>
        [Browsable(true)]
        [Category("Appearance")]
        [Description("The dark fill color of the box*s wall")]
        public Color DarkBackColor
        {
            get
            {
                return this.darkBackColor;
            }
            set
            {
                if (this.darkBackColor != value)
                {
                    this.darkBackColor = value;
                    Invalidate();
                    OnDarkBackColorChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Draw top
        /// </summary>
        [Browsable(true)]
        [Category("Behavior")]
        [DefaultValue(false)]
        [Description("Specifyes, wheather a top is drawn")]
        public bool DrawTop
        {
            get
            {
                return this.drawTop;
            }
            set
            {
                if (this.drawTop != value)
                {
                    this.drawTop = value;
                    Invalidate();
                    OnDrawTopChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Separators
        /// </summary>
        [Browsable(true)]
        [Category("Behavior")]
        [DefaultValue(5)]
        [Description("The number of separators")]
        public int Separators
        {
            get
            {
                return this.separators;
            }
            set
            {
                if (this.separators != value)
                {
                    this.separators = value;
                    Invalidate();
                    OnSeparatorsChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Specifyes separator width
        /// </summary>
        [Browsable(true)]
        [Category("Behavior")]
        [DefaultValue(15)]
        [Description("The percentual width of separators")]
        public int SeparatorWidth
        {
            get
            {
                return this.separatorWidth;
            }
            set
            {
                if (this.separatorWidth != value)
                {
                    this.separatorWidth = value;
                    Invalidate();
                    OnSeparatorWidthChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// The drawn value
        /// </summary>
        [Browsable(true)]
        [Category("Behavior")]
        [DefaultValue(0)]
        [Description("A percentual value")]
        public int Value
        {
            get
            {
                return this.value;
            }
            set
            {
                if (this.value != value)
                {
                    this.value = value;
                    Invalidate();
                    OnValueChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// mix between light and dark fill colors
        /// </summary>
        [Browsable(false)]
        [Category("Appearance")]
        [Description("The average between light and dark fill color")]
        public Color MainFillColor
        {
            get
            {
                return Color.FromArgb(
                    (int)((double)(LightFillColor.A + DarkFillColor.A) / 2.0),
                    (int)((double)(LightFillColor.R + DarkFillColor.R) / 2.0),
                    (int)((double)(LightFillColor.G + DarkFillColor.G) / 2.0),
                    (int)((double)(LightFillColor.B + DarkFillColor.B) / 2.0));
            }
        }

        /// <summary>
        /// mix between light and dark background colors
        /// </summary>
        [Browsable(false)]
        [Category("Appearance")]
        [Description("The average between light and dark background color")]
        public Color MainBackColor
        {
            get
            {
                return Color.FromArgb(
                    (int)((double)(LightBackColor.A + DarkBackColor.A) / 2.0),
                    (int)((double)(LightBackColor.R + DarkBackColor.R) / 2.0),
                    (int)((double)(LightBackColor.G + DarkBackColor.G) / 2.0),
                    (int)((double)(LightBackColor.B + DarkBackColor.B) / 2.0));
            }
        }
        #endregion

        #region public events
        /// <summary>
        /// Fired when border color changed
        /// </summary>
        public event EventHandler BorderColorChanged;

        /// <summary>
        /// Fired when border width changed
        /// </summary>
        public event EventHandler BorderWidthChanged;

        /// <summary>
        /// Fired when light fill color changed
        /// </summary>
        public event EventHandler LightFillColorChanged;

        /// <summary>
        /// Fired when dark fill color changed
        /// </summary>
        public event EventHandler DarkFillColorChanged;

        /// <summary>
        /// Fired when light background color changed
        /// </summary>
        public event EventHandler LightBackColorChanged;

        /// <summary>
        /// Fired when dark background color changed
        /// </summary>
        public event EventHandler DarkBackColorChanged;

        /// <summary>
        /// Fired when draw top boolean changed
        /// </summary>
        public event EventHandler DrawTopChanged;

        /// <summary>
        /// Fired when number of separators changed
        /// </summary>
        public event EventHandler SeparatorsChanged;

        /// <summary>
        /// Fired when width of separator changed
        /// </summary>
        public event EventHandler SeparatorWidthChanged;

        /// <summary>
        /// Fired when value changed
        /// </summary>
        public event EventHandler ValueChanged;
        #endregion

        #region constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public WaterBox()
        {
            DoubleBuffered = true;
            Size = new Size(100, 140);
        }
        #endregion

        #region public methods
        /// <summary>
        /// Resets light fill color
        /// </summary>
        public void ResetLightFillColor()
        {
            LightFillColor = Color.FromArgb(224, 90, 150, 200);
        }

        /// <summary>
        /// Serialize light fill color
        /// </summary>
        /// <returns>Wheather a serialization is needed</returns>
        public bool ShouldSerializeLightFillColor()
        {
            return LightFillColor != Color.FromArgb(224, 90, 150, 200);
        }

        /// <summary>
        /// Resets dark fill color
        /// </summary>
        public void ResetDarkFillColor()
        {
            DarkFillColor = Color.FromArgb(224, 50, 110, 160);
        }

        /// <summary>
        /// Serialize dark fill color
        /// </summary>
        /// <returns>Wheather a serialization is needed</returns>
        public bool ShouldSerializeDarkFillColor()
        {
            return DarkFillColor != Color.FromArgb(224, 50, 110, 160);
        }

        /// <summary>
        /// Resets light background color
        /// </summary>
        public void ResetLightBackColor()
        {
            LightBackColor = Color.FromArgb(127, 193, 236, 250);
        }

        /// <summary>
        /// Serialize light background color
        /// </summary>
        /// <returns>Wheather a serialization is needed</returns>
        public bool ShouldSerializeLightBackColor()
        {
            return LightBackColor != Color.FromArgb(127, 193, 236, 250);
        }

        /// <summary>
        /// Resets dark background color
        /// </summary>
        public void ResetDarkBackColor()
        {
            DarkBackColor = Color.FromArgb(127, 153, 196, 210);
        }

        /// <summary>
        /// Serialize dark background color
        /// </summary>
        /// <returns>Wheather a serialization is needed</returns>
        public bool ShouldSerializeDarkBackColor()
        {
            return DarkBackColor != Color.FromArgb(127, 153, 196, 210);
        }
        #endregion

        #region protected methods
        /// <summary>
        /// Fired when border color changed
        /// </summary>
        /// <param name="e">Event arguments</param>
        protected void OnBorderColorChanged(EventArgs e)
        {
            if (BorderColorChanged != null)
                BorderColorChanged(this, e);
        }

        /// <summary>
        /// Fired when border width changed
        /// </summary>
        /// <param name="e">Event arguments</param>
        protected void OnBorderWidthChanged(EventArgs e)
        {
            if (BorderWidthChanged != null)
                BorderWidthChanged(this, e);
        }

        /// <summary>
        /// Fired when light fill color changed
        /// </summary>
        /// <param name="e">Event arguments</param>
        protected void OnLightFillColorChanged(EventArgs e)
        {
            if (LightFillColorChanged != null)
                LightFillColorChanged(this, e);
        }

        /// <summary>
        /// Fired when dark fill color changed
        /// </summary>
        /// <param name="e">Event arguments</param>
        protected void OnDarkFillColorChanged(EventArgs e)
        {
            if (DarkFillColorChanged != null)
                DarkFillColorChanged(this, e);
        }

        /// <summary>
        /// Fired when light background color changed
        /// </summary>
        /// <param name="e">Event arguments</param>
        protected void OnLightBackColorChanged(EventArgs e)
        {
            if (LightBackColorChanged != null)
                LightBackColorChanged(this, e);
        }

        /// <summary>
        /// Fired when dark background color changed
        /// </summary>
        /// <param name="e">Event arguments</param>
        protected void OnDarkBackColorChanged(EventArgs e)
        {
            if (DarkBackColorChanged != null)
                DarkBackColorChanged(this, e);
        }

        /// <summary>
        /// Fired when draw top boolean changed
        /// </summary>
        /// <param name="e">Event arguments</param>
        protected void OnDrawTopChanged(EventArgs e)
        {
            if (DrawTopChanged != null)
                DrawTopChanged(this, e);
        }

        /// <summary>
        /// Fired when number of separators changed
        /// </summary>
        /// <param name="e">Event arguments</param>
        protected void OnSeparatorsChanged(EventArgs e)
        {
            if (SeparatorsChanged != null)
                SeparatorsChanged(this, e);
        }

        /// <summary>
        /// Fired when percentual separator width changed
        /// </summary>
        /// <param name="e">Event arguments</param>
        protected void OnSeparatorWidthChanged(EventArgs e)
        {
            if (SeparatorWidthChanged != null)
                SeparatorWidthChanged(this, e);
        }

        /// <summary>
        /// Fired when value changed
        /// </summary>
        /// <param name="e">Event arguments</param>
        protected void OnValueChanged(EventArgs e)
        {
            if (ValueChanged != null)
                ValueChanged(this, e);
        }

        /// <summary>
        /// Fired on re-paint
        /// </summary>
        /// <param name="e">Event arguments</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;

            // all containing rectangle
            RectangleF rect = new RectangleF(BorderWidth / 2F, BorderWidth / 2F, Width - BorderWidth - 1, Height - BorderWidth - 1);

            // isometric size of the box
            SizeF size = new SizeF(rect.Width, rect.Width / 2F);

            #region draw bottom rectangle
            {
                // the isometric area containing the rhombus
                RectangleF area = new RectangleF(
                    rect.X, rect.Y + rect.Height - size.Height,
                    size.Width, size.Height);

                // the path containing figure of rhombus
                GraphicsPath path = new GraphicsPath();
                path.AddLine(
                    area.X, area.Y + area.Height / 2F,
                    area.X + area.Width / 2F, area.Y);
                path.AddLine(
                    area.X + area.Width, area.Y + area.Height / 2F,
                    area.X + area.Width / 2F, area.Y + area.Height);
                path.CloseFigure();

                // draw path
                g.FillPath(new SolidBrush(MainBackColor), path);
                g.DrawPath(new Pen(BorderColor, BorderWidth), path);
            }
            #endregion
            #region draw bottom wall
            {
                // the isometric background box wall
                // the area is hall, then rect
                GraphicsPath path = new GraphicsPath();
                path.AddLine(
                    rect.X, rect.Y + size.Height / 2F,
                    rect.X + rect.Width / 2F, rect.Y);
                path.AddLine(
                    rect.X + rect.Width / 2F, rect.Y,
                    rect.X + rect.Width, rect.Y + size.Height / 2F);
                path.AddLine(
                    rect.X + rect.Width, rect.Y + rect.Height - size.Height / 2F,
                    rect.X + rect.Width / 2F, rect.Y + rect.Height - size.Height);
                path.AddLine(
                    rect.X + rect.Width / 2F, rect.Y + rect.Height - size.Height,
                    rect.X, rect.Y + rect.Height - size.Height / 2F);
                path.CloseFigure();

                // draw path, with light and dark background color
                g.SetClip(new RectangleF(rect.X, rect.Y, rect.Width / 2F, rect.Height));
                g.FillPath(new SolidBrush(LightBackColor), path);
                g.SetClip(new RectangleF(rect.X + rect.Width / 2F, rect.Y, rect.Width / 2F, rect.Height));
                g.FillPath(new SolidBrush(DarkBackColor), path);
                g.ResetClip();
                g.DrawPath(new Pen(BorderColor, BorderWidth), path);
            }
            #endregion
            #region draw back line
            // draws background wall's edge line
            g.DrawLine(new Pen(BorderColor, BorderWidth),
                rect.X + rect.Width / 2F, rect.Y,
                rect.X + rect.Width / 2F, rect.Y + rect.Height - size.Height);
            #endregion
            #region draw scala
            // draws scala each 100 / separators percentual step
            if (Separators > 0)
            {
                int step = (int)(100.0 / (double)Separators);

                for (int s = step; s < 100; s += step)
                {
                    // the area
                    RectangleF area = new RectangleF(
                        rect.X, rect.Y + rect.Height - size.Height - (rect.Height - size.Height) * (s / 100F),
                        size.Width, size.Height);

                    // draw only the top edge
                    g.DrawLine(
                        new Pen(BorderColor, BorderWidth),
                        area.X + area.Width / 2F - area.Width / 2F * SeparatorWidth / 100F, area.Y + area.Height / 2F * SeparatorWidth / 100F,
                        area.X + area.Width / 2F, area.Y);
                    g.DrawLine(
                        new Pen(BorderColor, BorderWidth),
                        area.X + area.Width / 2F + area.Width / 2F * SeparatorWidth / 100F, area.Y + area.Height / 2F * SeparatorWidth / 100F,
                        area.X + area.Width / 2F, area.Y);
                }
            }
            #endregion
            #region draw top wall
            // draws the front water's wall
            if (Value > 0)
            {
                // the area
                RectangleF area = new RectangleF(
                    rect.X, rect.Y + rect.Height - size.Height - (rect.Height - size.Height) * (Value / 100F),
                    rect.Width, size.Height + (rect.Height - size.Height) * (Value / 100F));

                // the isometric figure
                GraphicsPath path = new GraphicsPath();
                path.AddLine(
                    area.X, area.Y + size.Height / 2F,
                    area.X + area.Width / 2F, area.Y + size.Height);
                path.AddLine(
                    area.X + area.Width / 2F, area.Y + size.Height,
                    area.X + area.Width, area.Y + size.Height / 2F);
                path.AddLine(
                    area.X + area.Width, area.Y + area.Height - size.Height / 2F,
                    area.X + area.Width / 2F, area.Y + area.Height);
                path.AddLine(
                    area.X + area.Width / 2F, area.Y + area.Height,
                    area.X, area.Y + area.Height - size.Height / 2F);
                path.CloseFigure();

                // draw figure with light and dark water color
                g.SetClip(new RectangleF(rect.X, rect.Y, rect.Width / 2F, rect.Height));
                g.FillPath(new SolidBrush(DarkFillColor), path);
                g.SetClip(new RectangleF(rect.X + rect.Width / 2F, rect.Y, rect.Width / 2F, rect.Height));
                g.FillPath(new SolidBrush(LightFillColor), path);
                g.ResetClip();
                g.DrawPath(new Pen(BorderColor, BorderWidth), path);
            }
            #endregion
            #region draw fill rectangle
            // draws water's top
            if (Value > 0)
            {
                // water's height area
                RectangleF area = new RectangleF(
                    rect.X, rect.Y + rect.Height - size.Height - (rect.Height - size.Height) * (Value / 100F),
                    size.Width, size.Height);

                // isometric figure
                GraphicsPath path = new GraphicsPath();
                path.AddLine(
                    area.X, area.Y + area.Height / 2F,
                    area.X + area.Width / 2F, area.Y);
                path.AddLine(
                    area.X + area.Width, area.Y + area.Height / 2F,
                    area.X + area.Width / 2F, area.Y + area.Height);
                path.CloseFigure();

                // draw figure
                g.FillPath(new SolidBrush(MainFillColor), path);
                g.DrawPath(new Pen(BorderColor, BorderWidth), path);
            }
            #endregion
            #region draw top rectangle
            if (DrawTop)
            {
                // area
                RectangleF area = new RectangleF(
                    rect.X, rect.Y,
                    size.Width, size.Height);

                // isometric figure
                GraphicsPath path = new GraphicsPath();
                path.AddLine(
                    area.X, area.Y + area.Height / 2F,
                    area.X + area.Width / 2F, area.Y);
                path.AddLine(
                    area.X + area.Width, area.Y + area.Height / 2F,
                    area.X + area.Width / 2F, area.Y + area.Height);
                path.CloseFigure();

                // draw figure
                g.FillPath(new SolidBrush(MainBackColor), path);
                g.DrawPath(new Pen(BorderColor, BorderWidth), path);
            }
            #endregion

            base.OnPaint(e);
        }

        /// <summary>
        /// Fired when size changed
        /// </summary>
        /// <param name="e">Event arguments</param>
        protected override void OnSizeChanged(EventArgs e)
        {
            if (Height < (int)Math.Ceiling(Width / 2F))
                Height = (int)Math.Ceiling(Width / 2F);

            base.OnSizeChanged(e);
        }
        #endregion
    }
}

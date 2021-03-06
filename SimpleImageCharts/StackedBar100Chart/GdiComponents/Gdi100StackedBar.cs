﻿using GdiSharp.Components;
using GdiSharp.Models;
using System;
using System.Drawing;
using System.Linq;

namespace SimpleImageCharts.StackedBar100Chart.GdiComponents
{
    public class Gdi100StackedBar : GdiRectangle
    {
        private const string TextFormat = "{0:#.##}%";

        public float[] Values { get; set; }

        public Color[] Colors { get; set; }

        public override void BeforeRendering(Graphics graphics)
        {
            base.BeforeRendering(graphics);
            if (Values.Length != Colors.Length)
            {
                throw new ArgumentException("Values and Colors must have the same number of items.");
            }

            var size = this.Size;
            var pixelUnit = size.Width / 100;
            var sum = this.Values.Sum();
            var x = 0f;
            var font = SlimFont.Default;
            font.Size = 10;
            for (int i = 0; i < Values.Length; i++)
            {
                var percent = Values[i] / sum * 100;
                var width = percent * pixelUnit;
                var section = new GdiRectangle
                {
                    BackgroundColor = Colors[i],
                    Margin = new PointF(x, 0),
                    Size = new SizeF(width, size.Height)
                };
                var text = new GdiText
                {
                    Content = string.Format(TextFormat, percent),
                    HorizontalAlignment = GdiSharp.Enum.GdiHorizontalAlign.Center,
                    VerticalAlignment = GdiSharp.Enum.GdiVerticalAlign.Middle,
                    Font = font,
                    TextColor = Color.Black
                };
                section.AddChild(text);

                this.AddChild(section);

                x += width;
            }
        }
    }
}
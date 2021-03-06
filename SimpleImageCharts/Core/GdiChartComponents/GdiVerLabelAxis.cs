﻿using GdiSharp.Components;
using GdiSharp.Models;
using System.Drawing;

namespace SimpleImageCharts.Core.GdiChartComponents
{
    public class GdiVerLabelAxis : GdiRectangle
    {
        public string[] Labels { get; set; }

        public float LabelHeight { get; set; }

        public float LabelOffsetX { get; set; }

        public float LabelOffetY { get; set; }

        public SlimFont Font { get; set; }

        public override void Render(Graphics graphics)
        {
            base.Render(graphics);
            var position = GetAbsolutePosition(graphics);
            var y = position.Y + LabelHeight / 2 + LabelOffetY;
            var x = position.X + LabelOffsetX;
            using (StringFormat stringFormat = new StringFormat())
            using (var font = Font.ToFatFont())
            {
                stringFormat.LineAlignment = StringAlignment.Center;
                stringFormat.Alignment = StringAlignment.Far;

                foreach (var item in Labels)
                {
                    graphics.DrawString(item, font, Brushes.Gray, x, y, stringFormat);
                    y += LabelHeight;
                }
            }
        }
    }
}
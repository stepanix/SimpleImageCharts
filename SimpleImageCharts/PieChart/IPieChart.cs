﻿using System;
using System.Drawing;
using SimpleImageCharts.Core;
using SimpleImageCharts.Enum;

namespace SimpleImageCharts.PieChart
{
    public interface IPieChart : IImageChart
    {
        Action<Graphics> AfterDraw { get; set; }
        Color BorderColor { get; set; }
        byte BorderWidth { get; set; }
        PieEntry[] Entries { get; set; }
        Font Font { get; set; }
        int Height { get; set; }
        bool IsDonut { get; set; }
        string LabelFormat { get; set; }
        PositionAlignment PieAligment { get; set; }
        Color TextColor { get; set; }
        int Width { get; set; }
    }
}
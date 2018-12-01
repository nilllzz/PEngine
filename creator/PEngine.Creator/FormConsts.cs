using System.Drawing;

namespace PEngine.Creator
{
    internal static class FormConsts
    {
        internal static readonly Color Color_MainGray = Color.FromArgb(238, 238, 242);
        internal static readonly Color Color_LightGray = Color.FromArgb(245, 245, 245);
        internal static readonly Color Color_Highlight = Color.FromArgb(0, 122, 204);

        internal static readonly FontFamily Font_Family = new FontFamily("Segoe UI");
        internal static readonly Font Font_H1 = new Font(
            Font_Family,
            24,
            FontStyle.Regular);
        internal static readonly Font Font_H2 = new Font(
            Font_Family,
            18,
            FontStyle.Regular);
        internal static readonly Font Font_H3 = new Font(
            Font_Family,
            16,
            FontStyle.Regular);
        internal static readonly Font Font_H4 = new Font(
            Font_Family,
            14,
            FontStyle.Regular);
        internal static readonly Font Font_H5 = new Font(
            Font_Family,
            12,
            FontStyle.Regular);
        internal static readonly Font Font_H6 = new Font(
            Font_Family,
            10,
            FontStyle.Regular);
    }
}

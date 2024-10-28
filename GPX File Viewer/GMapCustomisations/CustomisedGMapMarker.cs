using GMap.NET;
using GMap.NET.WindowsForms;
using System;
using System.Drawing;
using System.Runtime.Serialization;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

/*
namespace GPX_File_Viewer.GMapCustomisations
{
    [Serializable]
    public class CustomisedGMapMarker : GMapMarker
    {
        private readonly int _size = 10; // Marker size

        protected CustomisedGMapMarker(SerializationInfo info, StreamingContext context) : base(info, context)
        { 
        }
        public CustomisedGMapMarker(PointLatLng pos) : base(pos)
        {
            // Initialize any other properties or data you need
        }

        public override void OnRender(Graphics g)
        {
            // Customize the marker appearance
            var rect = new Rectangle(LocalPosition.X - _size / 2, LocalPosition.Y - _size / 2, _size, _size);
            var transparentColor = Color.FromArgb(100, Color.Red); // Set the desired transparency (100 = semi-transparent)

            using (var brush = new SolidBrush(transparentColor))
            {
                g.FillEllipse(brush, rect); // Draw a transparent ellipse (you can use any shape)
            }
        }
    }
}
*/

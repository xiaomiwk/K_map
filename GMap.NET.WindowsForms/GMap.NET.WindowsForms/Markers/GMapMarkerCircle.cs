using System;
using System.Drawing;
using System.Runtime.Serialization;
using GMap.NET;
using GMap.NET.WindowsForms;

namespace GMap.NET.WindowsForms.Markers
{

    [Serializable]
    public class GMapMarkerCircle : GMapMarker, ISerializable
    {
        /// <summary>
        /// In Meters
        /// </summary>
        public int Radius;

        /// <summary>
        /// specifies how the outline is painted
        /// </summary>
        [NonSerialized]
        public Pen Stroke = new Pen(Color.FromArgb(155, Color.MidnightBlue));

        /// <summary>
        /// background color
        /// </summary>
        [NonSerialized]
        public Brush Fill = new SolidBrush(Color.FromArgb(155, Color.AliceBlue));

        /// <summary>
        /// is filled
        /// </summary>
        public bool IsFilled = true;

        public GMapMarkerCircle(PointLatLng p, Color 边框色, Color 填充色, int 边框宽度 = 1)
            : base(p)
        {
            Radius = 100; // 100m
            IsHitTestVisible = false;
            Stroke = new Pen(边框色) { Width = 边框宽度 };
            Fill = new SolidBrush(填充色);
        }

        public GMapMarkerCircle(PointLatLng p, Pen __边框画笔, Brush __填充笔刷, bool __允许交互, int 边框宽度 = 1)
            : base(p)
        {
            Radius = 100; // 100m
            IsHitTestVisible = __允许交互;
            Stroke = __边框画笔;
            Fill = __填充笔刷;
        }

        public override void OnRender(Graphics g)
        {
            int R = (int)((Radius) / Overlay.Control.MapProvider.Projection.GetGroundResolution((int)Overlay.Control.Zoom, Position.Lat)) * 2;

            if (IsFilled)
            {
                g.FillEllipse(Fill, new System.Drawing.Rectangle(LocalPosition.X - R / 2, LocalPosition.Y - R / 2, R, R));
            }
            g.DrawEllipse(Stroke, new System.Drawing.Rectangle(LocalPosition.X - R / 2, LocalPosition.Y - R / 2, R, R));
        }

        public override void Dispose()
        {
            if (Stroke != null)
            {
                Stroke.Dispose();
                Stroke = null;
            }

            if (Fill != null)
            {
                Fill.Dispose();
                Fill = null;
            }

            base.Dispose();
        }

        #region ISerializable Members

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);

            // TODO: Radius, IsFilled
        }

        protected GMapMarkerCircle(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            // TODO: Radius, IsFilled
        }

        #endregion

    }
}

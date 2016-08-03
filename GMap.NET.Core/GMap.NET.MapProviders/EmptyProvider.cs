using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GMap.NET.MapProviders;
using GMap.NET.Projections;

namespace GMap.NET.MapProviders
{
    /// <summary>
    /// represents empty provider
    /// </summary>
    public class EmptyProvider : GMapProvider
    {
        public static readonly EmptyProvider Instance;

        EmptyProvider()
        {
            MaxZoom = null;
        }

        static EmptyProvider()
        {
            Instance = new EmptyProvider();
        }

        #region GMapProvider Members

        public override Guid Id
        {
            get
            {
                return Guid.Empty;
            }
        }

        readonly string name = "None";
        public override string Name
        {
            get
            {
                return name;
            }
        }

        readonly MercatorProjection projection = MercatorProjection.Instance;
        public override PureProjection Projection
        {
            get
            {
                return projection;
            }
        }
        GMapProvider[] overlays;

        public override GMapProvider[] Overlays
        {
            get
            {
                if (overlays == null)
                {
                    overlays = new GMapProvider[] { this };
                }
                return overlays;
            }
        }

        public override PureImage GetTileImage(GPoint pos, int zoom)
        {
            return null;
        }

        #endregion
    }
}

using System.IO;
using System;
using System.Collections.Generic;

namespace GMap.NET.publics
{
    /// <summary>
    /// struct for raw tile
    /// </summary>
    public struct RawTile
    {
        public int Type;
        public GPoint Pos;
        public int Zoom;

        public RawTile(int Type, GPoint Pos, int Zoom)
        {
            this.Type = Type;
            this.Pos = Pos;
            this.Zoom = Zoom;
        }

        public override string ToString()
        {
            return Type + " at zoom " + Zoom + ", pos: " + Pos;
        }
    }

    public class RawTileComparer : IEqualityComparer<RawTile>
    {
        public bool Equals(RawTile x, RawTile y)
        {
            return x.Type == y.Type && x.Zoom == y.Zoom && x.Pos == y.Pos;
        }

        public int GetHashCode(RawTile obj)
        {
            return obj.Type ^ obj.Zoom ^ obj.Pos.GetHashCode();
        }
    }
}


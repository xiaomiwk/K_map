using System.IO;
using System;

namespace GMap.NET
{

    /// <summary>
    /// pure abstraction for image cache
    /// </summary>
    public interface PureImageCache
    {
        /// <summary>
        /// gets image from db
        /// </summary>
        /// <param name="type"></param>
        /// <param name="pos"></param>
        /// <param name="zoom"></param>
        /// <returns></returns>
        PureImage GetImageFromCache(int type, GPoint pos, int zoom);

    }
}

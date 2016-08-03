
namespace GMap.NET
{
   using System;

   /// <summary>
   /// types of great maps, legacy, not used anymore,
   /// left for old ids                                          
   /// </summary>
   public enum MapType
   {
      None = 0, // displays no map

      [Obsolete("check http://greatmaps.codeplex.com/discussions/252531", false)]
      GoogleMap = 1,
      [Obsolete("check http://greatmaps.codeplex.com/discussions/252531", false)]
      GoogleSatellite = 4,
      [Obsolete("check http://greatmaps.codeplex.com/discussions/252531", false)]
      GoogleLabels = 8,
      [Obsolete("check http://greatmaps.codeplex.com/discussions/252531", false)]
      GoogleTerrain = 16,
      [Obsolete("check http://greatmaps.codeplex.com/discussions/252531", false)]
      GoogleHybrid = 20,

      [Obsolete("check http://greatmaps.codeplex.com/discussions/252531", false)]
      GoogleMapChina = 22,
      [Obsolete("check http://greatmaps.codeplex.com/discussions/252531", false)]
      GoogleSatelliteChina = 24,
      [Obsolete("check http://greatmaps.codeplex.com/discussions/252531", false)]
      GoogleLabelsChina = 26,
      [Obsolete("check http://greatmaps.codeplex.com/discussions/252531", false)]
      GoogleTerrainChina = 28,
      [Obsolete("check http://greatmaps.codeplex.com/discussions/252531", false)]
      GoogleHybridChina = 29,

      OpenStreetMap = 32, //
      OpenStreetOsm = 33, //
      OpenStreetMapSurfer = 34, //
      OpenStreetMapSurferTerrain = 35, //
      OpenSeaMapLabels = 36, //
      OpenSeaMapHybrid = 37, //
      OpenCycleMap = 38,  //

      BingMap = 444,
      BingMap_New = 455,
      BingSatellite = 555,
      BingHybrid = 666,

   }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Reflection;

namespace GMap.NET.publics
{

    /// <summary>
    /// etc functions...
    /// </summary>
    public class Stuff
    {
        public static string EnumToString(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());
            DescriptionAttribute[] attributes =
                   (DescriptionAttribute[])fi.GetCustomAttributes(
                  typeof(DescriptionAttribute), false);

            return (attributes.Length > 0) ? attributes[0].Description : value.ToString();
        }

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll", EntryPoint = "SetCursorPos")]
        [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.Bool)]
        public static extern bool SetCursorPos(int X, int Y);

        public static readonly Random random = new System.Random();

        public static void Shuffle<T>(List<T> deck)
        {
            int N = deck.Count;

            for (int i = 0; i < N; ++i)
            {
                int r = i + (int)(random.Next(N - i));
                T t = deck[r];
                deck[r] = deck[i];
                deck[i] = t;
            }
        }

        public static MemoryStream CopyStream(Stream inputStream, bool SeekOriginBegin)
        {
            const int readSize = 32 * 1024;
            byte[] buffer = new byte[readSize];
            MemoryStream ms = new MemoryStream();
            {
                int count = 0;
                while ((count = inputStream.Read(buffer, 0, readSize)) > 0)
                {
                    ms.Write(buffer, 0, count);
                }
            }
            buffer = null;
            if (SeekOriginBegin)
            {
                inputStream.Seek(0, SeekOrigin.Begin);
            }
            ms.Seek(0, SeekOrigin.Begin);
            return ms;
        }

        public static bool IsRunningOnVistaOrLater()
        {
            OperatingSystem os = Environment.OSVersion;

            if (os.Platform == PlatformID.Win32NT)
            {
                Version vs = os.Version;

                if (vs.Major >= 6 && vs.Minor >= 0)
                {
                    return true;
                }
            }

            return false;
        }

        public static bool IsRunningOnWin7orLater()
        {
            OperatingSystem os = Environment.OSVersion;

            if (os.Platform == PlatformID.Win32NT)
            {
                Version vs = os.Version;

                if (vs.Major >= 6 && vs.Minor > 0)
                {
                    return true;
                }
            }

            return false;
        }

        public static void RemoveInvalidPathSymbols(ref string url)
        {
            char[] ilg = Path.GetInvalidFileNameChars();
            foreach (char c in ilg)
            {
                url = url.Replace(c, '_');
            }
        }
    }

}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace TibiaMarkerMerge
{

    internal static class Tools
    {
        public static List<MapMarker> DecodeMapMarkers(string fileName)
        {

            List<MapMarker> mapMarkers = new List<MapMarker>();

            using (FileStream fileStream = File.Open(fileName, FileMode.Open))
            {

                BinaryReader reader = new BinaryReader(fileStream);
                bool firstIteration = true;

                while (reader.BaseStream.Position < reader.BaseStream.Length)
                {

                    // the first byte is 0x0A
                    if (firstIteration)
                    {
                        reader.ReadByte();
                        firstIteration = false;
                    }

                    // The second byte indicates the size of this marker’s data block (i.e. all the following bytes).
                    reader.ReadByte();

                    // The following byte is another 0x0A separator, indicating the start of the coordinate data block.
                    reader.ReadByte();

                    // The next byte indicates the size of this marker’s coordinate data block.
                    // byte coordinateSize = reader.ReadByte();

                    // For simplicity, we only support the coordinate sizes used on the official servers. For those, `coordinateSize` is always 0x0A.
                    reader.ReadByte();

                    // The 0x08 byte marks the start of the `x` coordinate data.
                    reader.ReadByte();

                    // The next 1, 2, or 3 bytes represent the `x` coordinate.
                    byte x1 = reader.ReadByte();
                    byte x2 = reader.ReadByte();
                    byte x3 = reader.ReadByte();

                    int posX = (x1 + 0x80 * x2 + 0x4000 * x3 - 0x4080);

                    // The 0x10 byte marks the end of the `x` coordinate data.
                    reader.ReadByte();

                    // The next 1, 2, or 3 bytes represent the `y` coordinate.
                    byte y1 = reader.ReadByte();
                    byte y2 = reader.ReadByte();
                    byte y3 = reader.ReadByte();

                    int posY = (y1 + 0x80 * y2 + 0x4000 * y3 - 0x4080);

                    // The 0x18 byte marks the end of the `x` coordinate data.
                    reader.ReadByte();

                    // The next byte is the floor ID.
                    byte z = reader.ReadByte();

                    // The following byte is 0x10.
                    reader.ReadByte();

                    // The next byte represents the image ID of the marker icon.
                    byte imageId = reader.ReadByte();

                    // The next byte is 0x1A.
                    reader.ReadByte();

                    // The next byte indicates the size of the string that follows.
                    byte descriptionLength = reader.ReadByte();

                    // The following bytes represent the marker description as a UTF-8–encoded string.
                    byte[] descriptionArray = reader.ReadBytes(descriptionLength);
                    string description = Encoding.ASCII.GetString(descriptionArray, 0, descriptionLength);

                    mapMarkers.Add(new MapMarker() {
                        PosX = posX,
                        PosY = posY,
                        PosZ = z,
                        MarkerIcon = imageId,
                        Description = description
                    });

                    byte lastByte = 0;
                    while (lastByte != 0x0A && reader.BaseStream.Position < reader.BaseStream.Length)
                    {
                        lastByte = reader.ReadByte();
                    }

                }

                // File.WriteAllText("minimapmarkers.json", JsonSerializer.Serialize(mapMarkers));

            }

            return mapMarkers;

        }

        public static bool SaveMapMarkers(List<MapMarker> mapMarkers, string fileName)
        {

            using (FileStream fileStream = File.Open(fileName, FileMode.Truncate))
            {

                BinaryWriter writer = new BinaryWriter(fileStream);

                foreach(MapMarker marker in mapMarkers) {

                    int x3 = marker.PosX >> 14;
                    int x1 = 0x80 + marker.PosX % 0x80;
                    int x2 = (marker.PosX - 0x4000 * x3 - x1 + 0x4080) >> 7;

                    int y3 = marker.PosY >> 14;
                    int y1 = 0x80 + marker.PosY % 0x80;
                    int y2 = (marker.PosY - 0x4000 * y3 - y1 + 0x4080) >> 7;

                    byte[] description = Encoding.ASCII.GetBytes(marker.Description);

                    // the first byte is 0x0A
                    writer.Write((byte) 0x0A);

                    // The second byte indicates the size of this marker’s data block (i.e. all the following bytes).
                    writer.Write((byte) (description.Length + 18));

                    // The following byte is another 0x0A separator, indicating the start of the coordinate data block.
                    writer.Write((byte) 0x0A);

                    // The next byte indicates the size of this marker’s coordinate data block.
                    // byte coordinateSize = reader.ReadByte();

                    // For simplicity, we only support the coordinate sizes used on the official servers. For those, `coordinateSize` is always 0x0A.
                    writer.Write((byte) 0x0A);

                    // The 0x08 byte marks the start of the `x` coordinate data.
                    writer.Write((byte) 0x08);

                    // The next 1, 2, or 3 bytes represent the `x` coordinate.
                    writer.Write((byte) x1);
                    writer.Write((byte) x2);
                    writer.Write((byte) x3);

                    // The 0x10 byte marks the end of the `x` coordinate data.
                    writer.Write((byte) 0x10);

                    // The next 1, 2, or 3 bytes represent the `y` coordinate.
                    writer.Write((byte) y1);
                    writer.Write((byte) y2);
                    writer.Write((byte) y3);

                    // The 0x18 byte marks the end of the `x` coordinate data.
                    writer.Write((byte) 0x18);

                    // The next byte is the floor ID.
                    writer.Write((byte) marker.PosZ);

                    // The following byte is 0x10.
                    writer.Write((byte) 0x10);

                    // The next byte represents the image ID of the marker icon.
                    writer.Write((byte) marker.MarkerIcon);

                    // The next byte is 0x1A.
                    writer.Write((byte) 0x1A);

                    // The next byte indicates the size of the string that follows.
                    writer.Write((byte) description.Length);

                    // The following bytes represent the marker description as a UTF-8–encoded string.
                    foreach(byte descriptionByte in description) {
                        writer.Write((byte) descriptionByte);
                    }

                    writer.Write((byte) 0x20);
                    writer.Write((byte) 0x00);

                }

                return true;

            }
 
        }

        public static string GetSizeString(long length)
        {

            long B = 0, KB = 1024, MB = KB * 1024, GB = MB * 1024, TB = GB * 1024;
            double size = length;
            string suffix = nameof(B);

            if (length >= TB)
            {
                size = Math.Round((double)length / TB, 2);
                suffix = nameof(TB);
            }
            else if (length >= GB)
            {
                size = Math.Round((double)length / GB, 2);
                suffix = nameof(GB);
            }
            else if (length >= MB)
            {
                size = Math.Round((double)length / MB, 2);
                suffix = nameof(MB);
            }
            else if (length >= KB)
            {
                size = Math.Round((double)length / KB, 2);
                suffix = nameof(KB);
            }

            return String.Format("{0} {1}", size, suffix);

        }

    }

}

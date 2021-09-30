using System;
using System.IO;

namespace _04.CopyBinaryFile
{
    class Program
    {
        static void Main(string[] args)
        {
            using FileStream reader = new FileStream("../../../copyMe.png", FileMode.Open);
            using FileStream writer = new FileStream("copyMeCopy.png", FileMode.Create);
            byte[] buffer = new byte[4];
            while (reader.CanRead)
            {
                var byteRead = reader.Read(buffer, 0, buffer.Length);
                if (byteRead == 0)
                {
                    break;
                }

                writer.Write(buffer, 0, buffer.Length);
            }
        }
    }
}

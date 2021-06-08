using System;
using System.IO;

namespace _04.CopyBinaryFile
{
    class Program
    {
        static void Main(string[] args)
        {
            using (Stream myStream = File.Open("../../../Files/copyMe.png", FileMode.Open))
            {
                using (Stream copyStream = File.Open("../../../newCopy.png", FileMode.Create))
                {
                    BinaryReader binaryReader = new BinaryReader(myStream);
                    BinaryWriter content = new BinaryWriter(copyStream);

                    while (true)
                    {
                        byte[] buffer = new byte[4096];
                        int size = binaryReader.Read(buffer, 0, buffer.Length);
                        if (size <= 0)
                        {
                            break;
                        }
                        content.Write(buffer, 0, size);
                        if (size < buffer.Length)
                        {
                            break;
                        }
                    }
                }
            }
        }
    }
}

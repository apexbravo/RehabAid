using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace RehabAid.Web.Models
{
    public static class HtmlHelperExtensions
    {
        public static byte[] ToBytes(this Stream instream)
        {
            if (instream is MemoryStream)
                return ((MemoryStream)instream).ToArray();
            using (var memoryStream = new MemoryStream())

            {
                instream.CopyTo(memoryStream);
                return memoryStream.ToArray();
            }
        }

    }
}

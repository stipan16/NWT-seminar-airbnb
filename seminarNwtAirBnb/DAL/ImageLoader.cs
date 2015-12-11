using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;

namespace seminarNwtAirBnb.DAL
{
    public static class ImageLoader
    {
        public static byte[] slika = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + @"\Resources\kuca1.jpg").toByteArray();
        public static byte[] toByteArray(this Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.ToArray();
        }

        public static Image toImage(this byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }
    }
}
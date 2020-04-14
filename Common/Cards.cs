using MusCommon.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MusCommon
{
    public static class Cards
    {
        static Size cardSize = new Size(208, 319);
        static Bitmap MainImage
        {
            get
            {
                if (mainImage == null)
                {
                    Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("MusCommon.Res.BarajaEspañolaCompleta.png");
                    mainImage = new Bitmap(stream);
                }
                return mainImage;
            }
        }
        static Bitmap mainImage;

        public static Image GetCard(MusCard card)
        {
            Image retVal = null;
            int x = 0, y = 0;
            int numCard = (int)card;

            x = numCard > 9 ? numCard % 10 : numCard;
            x = x * cardSize.Width;

            y = numCard > 9 ? numCard / 10 : 0;
            y = y * cardSize.Height;

            retVal = MainImage.Clone(new Rectangle(x, y, cardSize.Width, cardSize.Height), MainImage.PixelFormat);
            return retVal;
        }
    }
}

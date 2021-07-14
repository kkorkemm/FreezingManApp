using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace FreezingManApp.Base
{
    public partial class Camp
    {
        public string IsRed => Status.IsRed ? "#FE5F55" : "White";

        public ImageSource CampImage
        {
            get
            {
                ImageSourceConverter converter = new ImageSourceConverter();

                try
                {
                    BitmapImage bitimage = new BitmapImage();
                    bitimage.BeginInit();
                    bitimage.UriSource = new Uri(MainImagePath, UriKind.Relative);
                    bitimage.EndInit();
                    

                    return bitimage;
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Spaetzel.UtilityLibrary;
using System.Web.Caching;
using System.Net;
using System.Web;

namespace Spaetzel.SizedImagesDA
{
    public class SizedImages
    {

       

        public static string GetSizedImageUrl(Uri ImageUrl, int Width, int Height)
        {
            if (!ImageUrl.IsNullOrEmpty())
            {
                if (!ImageUrl.ToString().Contains("gravatar.com") || !ImageUrl.ToString().Contains("castroller.com"))
                {
                    return String.Format("{0}/{2}/{3}/{1}", Config.SizedBaseUrl, ImageUrl.ToString().Replace("http://", "").Replace("//", "DSLASH"), Width, Height);
                }
                else
                {
                    var min = Math.Min(Width, Height);




                    ImageUrl = new Uri(ImageUrl.ToString().Replace("IMAGESIZE", min.ToString()));

                    int defaultLocation = ImageUrl.ToString().IndexOf("d=");
                    string defaultUrl = ImageUrl.ToString().Substring(defaultLocation + 2);

                    return ImageUrl.ToString().Replace(defaultUrl, HttpUtility.UrlEncode(defaultUrl));

                    //      string noDefault = ImageUrl.ToString().Substring(0, ImageUrl.ToString().IndexOf("&d="));

                    //   return String.Format("{0}&d={1}", noDefault, HttpUtility.UrlEncode(defaultUrl));

                }
            }
            else
            {
                return "";
            }

        }

     


       
    }
}

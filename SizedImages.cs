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
    public class SizedImages : AccessorBase
    {

       

        public static string GetSizedImageUrl(string ImageUrl, int Width, int Height)
        {

            if (!ImageUrl.Contains("gravatar.com") || !ImageUrl.Contains("castroller.com") )
            {
                return String.Format("{0}/default.ashx?url={1}&width={2}&height={3}", Config.SizedBaseUrl, HttpUtility.UrlEncode(ImageUrl), Width, Height);
            }
            else
            {
                var min = Math.Min(Width, Height);

                
               

                ImageUrl = ImageUrl.Replace("IMAGESIZE", min.ToString());

                int defaultLocation = ImageUrl.IndexOf("d=");
                string defaultUrl = ImageUrl.Substring(defaultLocation + 2);

                return ImageUrl.Replace(defaultUrl, HttpUtility.UrlEncode(defaultUrl));
            }

        }

     


       
    }
}

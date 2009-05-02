using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Spaetzel.SizedImagesDA
{
    public static class Config
    {
        private static string _sizedBaseUrl;

        internal static string SizedBaseUrl
        {
            get
            {
                return _sizedBaseUrl;
            }
        }

        public static void SetConfigurations(string sizedBaseUrl)
        {
            _sizedBaseUrl = sizedBaseUrl;
        }

    }
}

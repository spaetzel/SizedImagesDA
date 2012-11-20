using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Web.UI.WebControls;
using Spaetzel.UtilityLibrary;
using System.Web.UI;
using Spaetzel.SizedImagesDA;

namespace Spaetzel.SizedImagesDA
{
    public class SizedImageControl : WebControl
    {
        private System.Web.UI.WebControls.Image _image;
        private string _navigateUrl = "";
        private Uri _imageUrl;
        private int _width =0 ;
        private int _height = 0;
   


        public string Alt
        {
            get { return _image.AlternateText; }
            set { 
                _image.AlternateText = value;
                _image.Attributes["title"] = value;
            }
        }
        public string NavigateUrl
        {
            get { return _navigateUrl; }
            set { _navigateUrl = value; }
        }

        public Uri ImageUrl
        {
            get { return _imageUrl; }
            set { _imageUrl = value; }
        }

        public ImageAlign ImageAlign
        {
            get { return _image.ImageAlign; }
            set { _image.ImageAlign = value; }
        }

        /// <summary>
        /// The width of the image in pixels
        /// </summary>
        public new int Width
        {
            get {
            
                    return _width;
                
                }
            set
            {

                _width = value;
           //     _actualWidth = value;
            }
        }

        /// <summary>
        /// The height of the image in pixels
        /// </summary>
        public new int Height
        {
            get
            {
              
                    return _height;
             
            }
            set
            {
                _height = value;
          //      _actualHeight = value;
            }
        }


        public SizedImageControl()
        {
            _image = new System.Web.UI.WebControls.Image();
        }

        public string SizedImageUrl
        {
            get
            {
                EnsureChildControls();
                return _image.ImageUrl;
            }
        }



        protected override void CreateChildControls()
        {
            base.CreateChildControls();

            _image.ImageUrl = GetSizedImageUrl();

            
            /*
            base.Width = _image.Width = Unit.Pixel(ActualWidth);
            base.Height = _image.Height = Unit.Pixel(ActualHeight);
            */

         /*   if (Reflect)
            {
                _image.CssClass += "reflect rheight66";
                base.Height = Unit.Pixel( ActualHeight + (int)Math.Ceiling(this.Height * 1.66) );
            }
            */

            if (this.NavigateUrl != "")
            {
                HyperLink link = new HyperLink();
                link.NavigateUrl = NavigateUrl;
                link.Controls.Add(_image);

                this.Controls.Add(link);
            }
            else
            {
                this.Controls.Add(_image);
            }
        }

     

        private string GetSizedImageUrl()
        {
            return SizedImages.GetSizedImageUrl(ImageUrl, Width, Height);

           
        }


    }
}

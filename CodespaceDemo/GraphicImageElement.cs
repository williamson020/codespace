using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Threading.Tasks;

namespace CodespaceDemo
{
    public class GraphicImageElement : DynamicElement
    {

        public GraphicImageElement() { }

        public Uri Graphic { get; set; }

        public Point Size
        {
            set { _width = (int)value.X;  _height = (int)value.Y; }
        }

        private Image _image;

        public GraphicImageElement(string key, Codespace parent)
             : base(key, parent)
        {
            
        }

         public override void Layout()
         {

             if (null == _image)
                 _image  = LoadImage();

             if (_image != null)
             {
                 _parent.TheCanvas.Children.Add(_image);


                 _image.SetValue(Canvas.LeftProperty, _layoutpos.X);
                 _image.SetValue(Canvas.TopProperty, _layoutpos.Y);
                 
             }

             base.Layout();
                          
         }

         public override Point Position()
         {
             if (_image == null)
                 return base.Position();

             return new Point((int)_image.GetValue(Canvas.LeftProperty), (int)_image.GetValue(Canvas.TopProperty));
         }

         private Image LoadImage()
         {
             Image i = new Image();
             BitmapImage src = new BitmapImage();
             i.Width = Width();
             i.Height = Height();
             src.BeginInit();
             src.UriSource = Graphic;
             src.CacheOption = BitmapCacheOption.OnLoad;
             src.EndInit();
             i.Source = src;
             i.StretchDirection = StretchDirection.Both;
             i.IsEnabled = true;
             return i;
         }


    }
}

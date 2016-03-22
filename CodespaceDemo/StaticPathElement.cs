using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Reflection;
using System.Diagnostics;
using System.Threading.Tasks;

namespace CodespaceDemo
{
    //todo: create an interface IPathElement
    public class StaticPathElement : StaticElement /*IPathElement*/
    {

        private Path _path;
        
        
        public StaticPathElement(string key, Codespace parent):base(key, parent)
        {

        }
        

        public void AddFigure(PathFigure pf)
        {
            AddFigure(0,0,pf);
        }

        public void AddFigure(int x, int y, PathFigure pf)
        {
            if (null == pf)
                throw new ArgumentNullException();

           

            if (_path != null)
            {
                var pg = _path.Data as PathGeometry;

                

                pg.Figures.Add(PathHelper.Offset(pf, x, y));
            }
        }

        public void Init(Brush strokeBrush, int strokethickness, string imageSrc)
        {

            _path = new Path();
            _path.Stroke = strokeBrush;
            _path.StrokeThickness = strokethickness;

            var pg  = new PathGeometry();
            pg.Figures = new PathFigureCollection(); // add to this collection one or more PathFigure
            _path.Data = pg;


            if (!String.IsNullOrEmpty(imageSrc))
            {
                ImageBrush ib = new ImageBrush();
                //todo: change all asset paths to relative
                ib.ImageSource = new BitmapImage(new Uri(imageSrc, UriKind.Absolute));
                ib.TileMode = TileMode.None;
                ib.Stretch = Stretch.UniformToFill;
                _path.Fill = ib;
                ib.Opacity = 0.5;
            }

        }

        public override void Layout()
        {
                        
            if (_path!= null)
            {
                _parent.TheCanvas.Children.Add(_path);
                _path.SetValue(Canvas.LeftProperty, _layoutpos.X);
                _path.SetValue(Canvas.TopProperty, _layoutpos.Y);

            }

            base.Layout();

        }
        

    }
}

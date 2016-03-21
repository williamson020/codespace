using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Text;
using System.Threading.Tasks;

namespace CodespaceDemo
{
    public static class PathHelper
    {
       

        public static Path PathFromGrid(int unitsX, int unitsY, Point gridSize)
        {
            if (unitsX == 0 || unitsY == 0)
                return null;

            if (gridSize.X==0 || gridSize.Y==0)
                return null;
            
            PathFigure pf = new PathFigure();
            pf.StartPoint = new Point(0, 0);

            LineSegment ls1 = new LineSegment();
            ls1.Point = new Point(unitsX * gridSize.X, 0);
            LineSegment ls2 = new LineSegment();
            ls2.Point = new Point(unitsX * gridSize.X, unitsY*gridSize.Y);
            LineSegment ls3 = new LineSegment();
            ls2.Point = new Point(0, unitsY * gridSize.Y);
            LineSegment ls4 = new LineSegment();
            ls2.Point = new Point(0,0);
            

            PathSegmentCollection myPathSegmentCollection = new PathSegmentCollection();
            myPathSegmentCollection.Add(ls1);
            myPathSegmentCollection.Add(ls2);
            myPathSegmentCollection.Add(ls3);
            myPathSegmentCollection.Add(ls4);

            pf.Segments = myPathSegmentCollection;

            PathFigureCollection pfc = new PathFigureCollection();
            pfc.Add(pf);

            PathGeometry myPathGeometry = new PathGeometry();
            myPathGeometry.Figures = pfc;

            Path p = new Path();
            p.Stroke = Brushes.Black;
            p.StrokeThickness = 1;
            p.Data = myPathGeometry;

            return p;


        }



        /// <summary>
        /// Generate a path from actors current position to the extent of the Codespace in given direction
        /// </summary>
        /// <param name="ord"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static PathGeometry OrdinalPath(Codespace.Ordinal ord, DynamicElement el)
        {            

            PathFigure pFigure = new PathFigure();

            pFigure.StartPoint = el.MidPoint;

            Point endpoint = el.MidPoint;

            switch (ord)
            {
                case Codespace.Ordinal.Right:
                    endpoint.Offset(el.Parent.Right,0);
                    break;
                case Codespace.Ordinal.Left:
                    endpoint.Offset(el.Parent.Left, 0);
                    break;
                case Codespace.Ordinal.Up:
                    endpoint.Offset(0, el.Parent.Top);
                    break;
                case Codespace.Ordinal.Down:
                    endpoint.Offset(0, el.Parent.Bottom);
                    break;
            }

            
            pFigure.Segments.Add(new LineSegment(endpoint,true));
            
            
            PathGeometry animationPath = new PathGeometry();
            animationPath.Figures.Add(pFigure);
            // Freeze the PathGeometry for performance benefits.
            animationPath.Freeze();
            return animationPath;
        }

        internal static LineGeometry NewLine(int x1, int y1, int x2, int y2)
        {
            var lg = new LineGeometry();
            lg.StartPoint = new Point(x1,y1);
            lg.EndPoint = new Point(x2,y2);
            return lg;

        }
        internal static Codespace.Ordinal InvertDirection(Codespace.Ordinal direction)
        {
            switch (direction)
            { 
                case Codespace.Ordinal.Left:
                    return Codespace.Ordinal.Right;

                case Codespace.Ordinal.Right:
                    return Codespace.Ordinal.Left;

                case Codespace.Ordinal.Up:
                    return Codespace.Ordinal.Down;

                case Codespace.Ordinal.Down:
                    return Codespace.Ordinal.Up;

            }

            throw new Exception();
        }
    }
}

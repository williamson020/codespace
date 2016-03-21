using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace CodespaceDemo
{
    public static class PathHelper
    {

        [DebuggerStepThrough]
        public static LineSegment MakeSegment(int x, int y)
        {
            LineSegment ls = new LineSegment();
            ls.Point = new Point(x, y);
            return ls;

        }

        [DebuggerStepThrough]
        public static LineSegment MakeSegment(Point p)
        {
            LineSegment ls = new LineSegment();
            ls.Point = new Point((int)p.X, (int)p.Y);
            return ls;

        }


        /// <summary>
        /// Create a regular closed path of 4 lines from X by Y  grid units
        /// </summary>
        /// <param name="unitsX"></param>
        /// <param name="unitsY"></param>
        /// <param name="gridSize"></param>
        /// <returns></returns>
        public static PathFigure PathFigureFromGrid(int unitsX, int unitsY, Point gridSize)
        {
            if (unitsX == 0 || unitsY == 0)
                return null;

            if (gridSize.X==0 || gridSize.Y==0)
                return null;
            
            PathSegmentCollection myPathSegmentCollection = new PathSegmentCollection();
            myPathSegmentCollection.Add(MakeSegment(unitsX * (int)gridSize.X, 0));
            myPathSegmentCollection.Add(MakeSegment(unitsX * (int)gridSize.X, unitsY * (int)gridSize.Y));
            myPathSegmentCollection.Add(MakeSegment(0, unitsY * (int)gridSize.Y));
            myPathSegmentCollection.Add(MakeSegment(0,0));


            PathFigure pf = new PathFigure();
            pf.StartPoint = new Point(0, 0);
            pf.Segments = myPathSegmentCollection;

            return pf;

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

        internal static Point Offset(Point p, int x, int y)
        {
            Point copy = new Point(p.X,p.Y);

            copy.Offset((int)x, (int)y);

            return copy;

        }

        internal static PathFigure Offset(PathFigure pf, int x, int y)
        {
            PathSegmentCollection coll = new PathSegmentCollection();
            foreach (LineSegment seg in pf.Segments)
            {
                Point j = Offset(seg.Point,x, y);
                coll.Add(MakeSegment(j));
            }

            PathFigure pfnew = new PathFigure();
            pfnew.StartPoint = Offset(pf.StartPoint, x, y);
            pfnew.Segments = coll;

            return pfnew;
        }
    }
}

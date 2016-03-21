using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;



namespace CodespaceDemo
{
    public abstract class Codespace : CodespaceElement
    {
        public enum Ordinal { Right, Left, Up, Down };
        public enum Mode{ DesignTime, Runtime };

        #region Data Members
        private Dictionary<string, CodespaceElement> _elements = new Dictionary<string, CodespaceElement>();

        private Ordinal? _magnetism = null;

        private Canvas _canvas;

        private MainWindow _wnd;

        private Program _program = new Program();

        private VirtualMachine _vm;

        protected  Point _gridSize = new Point(40, 40);

        protected Mode _mode = Mode.DesignTime;

        #endregion

        #region Ctor
        public Codespace(string name, MainWindow wnd, int width, int height): base(name,null)
        {
            _wnd = wnd;
            _parent = this;

            _canvas = new Canvas();
            _canvas.Width = width;
            _canvas.Height = height;
            CodespaceBorder.Child = _canvas;
            
            Initialise();

        }

        protected void CreateGrid()
        {
            if ((_gridSize.X > 0) && (+_gridSize.Y > 0))
            {
                DrawingBrush brush = new DrawingBrush();
                brush.TileMode = TileMode.Tile;
                brush.Stretch = Stretch.None;
                brush.Viewport = new Rect(new Point(0, 0), _gridSize);
                brush.ViewportUnits = BrushMappingMode.Absolute;


                var gg = new GeometryGroup();
                gg.Children = new GeometryCollection();
                gg.Children.Add(PathHelper.NewLine(0, 0, 0, (int)_gridSize.X));
                gg.Children.Add(PathHelper.NewLine(0, 0, (int)_gridSize.X, 0));


                var gd = new GeometryDrawing();
                gd.Geometry = gg;
                gd.Pen = new Pen(new SolidColorBrush(Color.FromRgb(211, 211, 211)), 0.2);
                gd.Brush = new SolidColorBrush(Color.FromRgb(211, 211, 211));
                brush.Drawing = gd;
                _canvas.Background = brush;
            }
            
        }
        #endregion


        private void ClearCanvas()
        {
            TheCanvas.Children.Clear();
        }

        public Canvas TheCanvas
        {
            get { return _canvas; }
        }

        
        #region Properties

        public virtual void  SetMode(Mode m)
        {
            _mode = m;

            ShowGrid((m == Mode.DesignTime) || _gridVisible);
        }

        private void ShowGrid(bool p)
        {
            //throw new NotImplementedException();
        }

        public override int Width()
        {
            return (int)CanvasExtents.X;
        }
        public override int Height()
        {
            return (int)CanvasExtents.Y;
        }

        internal int GridWidth
        {
            get { return (int)_gridSize.X; }
        }

        internal int GridHeight
        {
            get { return (int)_gridSize.Y; }
        }

        public Program TheProgram
        {
            get { return _program;  }
        }



        private Border CodespaceBorder
        {
            get
            {
                Grid x = _wnd.Content as Grid;
                Viewbox vb = x.Children[0] as Viewbox;
                return vb.Child as Border;
            }
        }

        /// <summary>
        /// Note - this code is very fragile ... dependent entirely on XAML layout
        /// </summary>
        public Point CanvasExtents
        {
            get
            {
                return new Point(TheCanvas.Width, TheCanvas.Height);
            }
        }

        #endregion


        #region Virtuals

        protected virtual void Initialise()
        {

        }

        #endregion


        /*
         * TODO: LinkCodespace
        public void LinkCodespace(Codespace cs)
        {
            throw new NotImplementedException();
        }
         */



        protected void AddElement(VisualElement el, int x, int y)
        {
            AddElement(el, new Point(x,y));
        }

        protected void AddElement(VisualElement el, Point layoutPos)
        {
            if (el != null)
            {
                CodespaceElement temp;
                if (_elements.TryGetValue(el.Key, out temp))
                    throw new ArgumentException("Element with this key already in collection:" + el.Key);

                el.LayoutPos = layoutPos;
                _elements.Add(el.Key, el);

            }
        }

        /// <summary>
        /// 
        /// </summary>
        public override void Layout()
        {
            foreach (var e in _elements)
                e.Value.Layout();
        }


        public void RuntimeReset(bool doLayout = true)
        {
            TheCanvas.Children.Clear();

            if (doLayout)
                    Layout();
        }

        public bool HasMagneticBorder
        {
            get { return _magnetism.HasValue; }
        }

        public Ordinal? Magnetism { get; set; }

    
        public double Right 
        {
            get { return _wnd.Left + _wnd.Width; }
        }


        
        public double Left 
        { 
            get { return _wnd.Left; } 
        }

        public double Top { get { return _wnd.Top; } }

        public double Bottom 
        { 
            get { return _wnd.Top + _wnd.Height; } 
        }


        internal PathGeometry GenerateMagneticPath(VisualElement el)
        {

            if (!this.HasMagneticBorder)
                return null;

            DynamicElement de = el as DynamicElement;
            if (null != de)
            {
                Codespace.Ordinal direction = _magnetism.Value;

                if (de.MagneticState ==  DynamicElement.Magnestism.Antimagnetic)
                    direction = PathHelper.InvertDirection(direction);

                return PathHelper.OrdinalPath(direction, de);
            }

            return null;
        }



        internal void InitRuntime()
        {


            _vm = new VirtualMachine(this);
            _vm.Execute();
        }

        public bool _gridVisible { get; set; }
    }
}

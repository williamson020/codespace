using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;
using System.Diagnostics;

namespace CodespaceDemo
{
    /// <summary>
    /// TODO: MOVE TO SEPARATE LIB
    /// </summary>
    public class Robots1 : Codespace
    {

        public readonly string ROBOT_TYPENAME = "ROBOT1";

        public Robots1(string name, MainWindow wnd, int width, int height)
            : base (name,wnd, width,height)
        {
        }

        /// <summary>
        /// On first load - dynamically constuct all CodeSpace elements
        /// </summary>
        protected override void Initialise()
        {
            try
            {

                CreateTypes();

                //not magnetic
                CreateGrid(60,60);
                CreateStatics();
                CreateActors();
                CreateProgram();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message); // dont forget to add assets to git
            }
          
        }

        private void CreateTypes()
        {
            RegisterType(ROBOT_TYPENAME);

            GetType(ROBOT_TYPENAME).AddMethod("MOVE", MovePublic, new  EnumArgumentType<Codespace.Ordinal>("Direction"), new IntArgumentType("UNITS"));


        }

        private void CreateProgram()
        {

            var benny = FindElement("ROBOT1");
            TheProgram.Push(benny);
            TheProgram.Push(Ordinal.Down.ToString());
            TheProgram.Push(2);
            TheProgram.Invoke(benny.FindMethod("MOVE"));
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        private void MovePublic(CodespaceElement receiver, object[] args)
        {
            //todo - THE WORK OF MOVEPUBLIC
            Debug.WriteLine(receiver.Key);
            Debug.WriteLine(args[0].ToString());
            Debug.WriteLine(args[1].ToString());
        }
        
        private void Move(Ordinal dir, int units)
        {
            //call some generic method in base class 

        }

        private void CreateStatics()
        {
            //Create a line geometry 3x1 grid units

            
            StaticPathElement se1 = CodespaceElementFactory.StaticPathHelper("STATIC1", this, Brushes.Pink, 2, @"C:\tmp\Assets\Backgrounds\CircuitBoard_Pink.png");

            
            se1.AddFigure(0,0,PathHelper.PathFigureFromGrid(5, 3, _gridSize));

            se1.AddFigure(GridUnits(6, Ordinal.Right), GridUnits(0, Ordinal.Down), PathHelper.PathFigureFromGrid(3, 2, _gridSize));
            se1.AddFigure(GridUnits(6, Ordinal.Right), GridUnits(3, Ordinal.Down), PathHelper.PathFigureFromGrid(3, 2, _gridSize));
            se1.AddFigure(GridUnits(6, Ordinal.Right), GridUnits(8, Ordinal.Down),PathHelper.PathFigureFromGrid(3, 2, _gridSize));
            se1.AddFigure(GridUnits(6, Ordinal.Right), GridUnits(6, Ordinal.Down), PathHelper.PathFigureFromGrid(3, 2, _gridSize));

            se1.AddFigure(GridUnits(2, Ordinal.Right), GridUnits(4, Ordinal.Down), PathHelper.PathFigureFromGrid(1, 8, _gridSize));
            
            AddElement(se1, GridUnits(1, Ordinal.Right), GridUnits(0, Ordinal.Down));
            

        }

        private void CreateActors()
        {
            //GraphicImageElement a = (GraphicImageElement)CodespaceElementFactory.Create("BEACH-BALL-001", typeof(GraphicImageElement), this);
            //GraphicImageElement b = (GraphicImageElement)CodespaceElementFactory.Create("BEACH-BALL-002", typeof(GraphicImageElement), this);
            //a.Graphic = new Uri("file:///C:/tmp/beach_ball.png", UriKind.Absolute);
            //a.Size = new Point(20, 20);
            //a.MagneticState = DynamicElement.Magnestism.Magnetic;

            //b.Graphic = new Uri("file:///C:/tmp/beach_ball.png", UriKind.Absolute);
            //b.Size = new Point(20, 20);
            //b.MagneticState = DynamicElement.Magnestism.Magnetic;


            //AddElement(a, GridUnits(2, Ordinal.Right), GridUnits(2, Ordinal.Down));
            //AddElement(b, GridUnits(3, Ordinal.Right), GridUnits(3, Ordinal.Down));   


            GraphicImageElement robot = (GraphicImageElement)CodespaceElementFactory.Create("ROBOT1", typeof(GraphicImageElement), this, GetType(ROBOT_TYPENAME));
            //robot.Graphic = new Uri("file:///C:/tmp/robot_square.png", UriKind.Absolute);
            robot.Graphic = new Uri("file:///C:/tmp/robot.png", UriKind.Absolute);
            robot.Size = _gridSize;
            robot.MagneticState = DynamicElement.Magnestism.None;
            AddElement(robot, GridUnits(0, Ordinal.Right), GridUnits(0, Ordinal.Down));


        }

        
    }
}

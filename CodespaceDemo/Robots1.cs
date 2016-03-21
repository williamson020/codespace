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

        public Robots1(string name, MainWindow wnd, int width, int height): base (name,wnd, width,height)
        {
            
        }

        /// <summary>
        /// On first load - dynamically constuct all CodeSpace elements
        /// </summary>
        protected override void Initialise()
        {

            try
            {

                _gridSize = new System.Windows.Point(40, 40);

                //not magnetic

                CreateGrid();
                CreateStatics();

                CreateActors();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
          
        }

      
        private void CreateStatics()
        {
            //Create a line geometry 3x1 grid units

            //Path static1 = 
            
            StaticPathElement se1 = CodespaceElementFactory.StaticHelper(_gridSize);
            se1.

        }

        private void CreateActors()
        {
            GraphicImageElement a = (GraphicImageElement)CodespaceElementFactory.Create("BEACH-BALL-001", typeof(GraphicImageElement), this);
            GraphicImageElement b = (GraphicImageElement)CodespaceElementFactory.Create("BEACH-BALL-002", typeof(GraphicImageElement), this);

            a.Graphic = new Uri("file:///C:/tmp/beach_ball.png", UriKind.Absolute);
            a.Size = new Point(20, 20);
            a.MagneticState = DynamicElement.Magnestism.Magnetic;

            b.Graphic = new Uri("file:///C:/tmp/beach_ball.png", UriKind.Absolute);
            b.Size = new Point(20, 20);
            b.MagneticState = DynamicElement.Magnestism.Magnetic;


            AddElement(a, 100, 100);
            AddElement(b, 80, 80);   
        }

        
    }
}

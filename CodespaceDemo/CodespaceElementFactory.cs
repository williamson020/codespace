using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Reflection;
using System.Diagnostics;
using System.Threading.Tasks;

namespace CodespaceDemo
{
    public static class CodespaceElementFactory
    {


        internal static VisualElement Create(string key, Type type, Codespace codespace)
        {

            try
            {
                // Simple method calling default ctor
                // create an object of the type
                //ICodespaceElement obj = (ICodespaceElement)Activator.CreateInstance(type);


                /*Another way is to use reflection: */

                // Get public constructors
                //var ctors = type.GetConstructors(BindingFlags.Public);

                var ctr = type.GetConstructor(BindingFlags.Instance | BindingFlags.Public, null, new Type[] { typeof(String), typeof(Codespace) }, null);

                if (ctr!=null)
                    return (VisualElement)ctr.Invoke(new object[] { key, codespace });


            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex.Message);

            }

            return null;




        }

        internal static StaticPathElement StaticHelper(Point gridsize)
        {

            var sp = new StaticPathElement();

            /*
            <Path  Stroke ="Black" StrokeThickness="2" Data="M100,50 L140,60 L150,100 L125,120 L90,110 L80,80 z M15,40 L70,15 L80,30 L65,70 L80,115 L10,80 z M160,40 L170,50 L180,90 L180,120 L140,150 L130,130 L160,100 z" >
                    <Path.Fill>
                        <ImageBrush ImageSource="C:\tmp\Assets\Backgrounds\CircuitBoard_Pink.png" TileMode="None" Stretch="UniformToFill" />
                    </Path.Fill>

                </Path>
            */


            return sp;
        }
    }
}

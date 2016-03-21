using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CodespaceDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Codespace _codespace1;

        public MainWindow()
        {
            InitializeComponent();

            this.Loaded += new RoutedEventHandler(Window_Loaded);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Create new Codespace

            _codespace1 = new Robots1("ROBOTS-1", this, 1000, 800);
            
            _codespace1.SetMode(Codespace.Mode.DesignTime);

            _codespace1.Layout();
                                    
            //Runtime invoked fromUI
            

        }

    }
}

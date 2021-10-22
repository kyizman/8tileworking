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

namespace _8tile
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        UtilityCommands utilcommands = new UtilityCommands();
        List<int[][]> goodpath;
        public MainWindow()
        {
            InitializeComponent();

            

          


        }


        public List<int[,] > x(int[,] y)
        {
         



            return null;
        }

        private void BestBut_Click(object sender, RoutedEventArgs e)
        {
            UtilityCommands commands = new UtilityCommands();

            //{ { 1, 2, 3 }, { 8, 0, 4 }, { 7, 6, 5 } };
            int[,] holder = { {int.Parse(_0_0.Text), int.Parse(_1_0.Text), int.Parse(_2_0.Text) }, {int.Parse(_0_1.Text), int.Parse(_1_1.Text), int.Parse(_2_1.Text) },
                { int.Parse(_0_2.Text),int.Parse(_1_2.Text),int.Parse(_2_2.Text)} };

            int[,] x = commands.BestFirst(holder).Last();


            _0_0.Text = x[0, 0].ToString();
            _1_0.Text = x[0, 1].ToString();
            _2_0.Text = x[0, 2].ToString();
            _0_1.Text = x[1, 0].ToString();
            _1_1.Text = x[1, 1].ToString();
            _2_1.Text = x[1, 2].ToString();
            _0_2.Text = x[2, 0].ToString();
            _1_2.Text = x[2, 1].ToString();
            _2_2.Text = x[2, 2].ToString();




        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int[,] holder = { {int.Parse(_0_0.Text), int.Parse(_1_0.Text), int.Parse(_2_0.Text) }, {int.Parse(_0_1.Text), int.Parse(_1_1.Text), int.Parse(_2_1.Text) },
                { int.Parse(_0_2.Text),int.Parse(_1_2.Text),int.Parse(_2_2.Text)} };

            uniform uniform = new uniform();
            Node start = new Node(holder);
           List< Node> y = uniform.uniformsearch(start);
        
            int[,] x= y.First().data;

            _0_0.Text = x[0, 0].ToString();
            _1_0.Text = x[0, 1].ToString();
            _2_0.Text = x[0, 2].ToString();
            _0_1.Text = x[1, 0].ToString();
            _1_1.Text = x[1, 1].ToString();
            _2_1.Text = x[1, 2].ToString();
            _0_2.Text = x[2, 0].ToString();
            _1_2.Text = x[2, 1].ToString();
            _2_2.Text = x[2, 2].ToString();

        }

        private void _0_0_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Astar_Click(object sender, RoutedEventArgs e)
        {
            {
                int[,] holder = { {int.Parse(_0_0.Text), int.Parse(_1_0.Text), int.Parse(_2_0.Text) }, {int.Parse(_0_1.Text), int.Parse(_1_1.Text), int.Parse(_2_1.Text) },
                { int.Parse(_0_2.Text),int.Parse(_1_2.Text),int.Parse(_2_2.Text)} };

                astar uniform = new astar();
                Node start = new Node(holder);


                start.sethuristic(start.BadPostion(holder));

                start.setf();
                List<Node> y = uniform.astarsearch(start);

                int[,] x = y.First().data;

                _0_0.Text = x[0, 0].ToString();
                _1_0.Text = x[0, 1].ToString();
                _2_0.Text = x[0, 2].ToString();
                _0_1.Text = x[1, 0].ToString();
                _1_1.Text = x[1, 1].ToString();
                _2_1.Text = x[1, 2].ToString();
                _0_2.Text = x[2, 0].ToString();
                _1_2.Text = x[2, 1].ToString();
                _2_2.Text = x[2, 2].ToString();

            }
        }
    }
}

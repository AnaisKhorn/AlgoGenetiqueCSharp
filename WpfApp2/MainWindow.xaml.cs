using System;
using SQLite;
using SQLitePCL;
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
using WpfApp2.Classes;

namespace WpfApp2
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        List<Ville> items = new List<Ville>();
        public MainWindow()
        {
            InitializeComponent();
        }
        private void testClic(object sender, MouseEventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            Rectangle rect = new Rectangle { Width = 5, Height = 5, Fill = Brushes.Black };
            TextBlock villInfo = new TextBlock();
            villInfo.Text = "Ville " + (items.Count + 1);
            testCanvas.Children.Add(villInfo);
            testCanvas.Children.Add(rect);


            var test = me.GetPosition(testCanvas);
            Ville newVille = new Ville((items.Count + 1), "Ville" + (items.Count + 1), test.X, test.Y);
            Canvas.SetLeft(rect, test.X);
            Canvas.SetTop(rect, test.Y);
            Canvas.SetLeft(villInfo, test.X);
            Canvas.SetTop(villInfo, test.Y - 15);
            items.Add(newVille);

            listVilles.Items.Add(newVille);

            var db = Database.GetDatabase();
            db.saveVille(newVille);
        }

        private void launchAlgorithm(object sender, RoutedEventArgs e)
        {

            int limit = 1;

            int cheminsNumber = Int32.Parse(nbChemins.Text);

            List<Chemin> Chemins = Chemin.setFirstGen(cheminsNumber, items);


            do
            {
                List<Chemin> elites = Chemin.Elite(Chemins, cheminsNumber / 5);
                List<Chemin> testo = Chemin.crossover(cheminsNumber, Chemins, items);
                List<Chemin> muty = Chemin.mutation(cheminsNumber, Chemins);
                List<Chemin> newGen = Chemin.setNewGen(testo, muty, elites, cheminsNumber);
                limit++;
            }
            while (limit < Int32.Parse(nbGenerations.Text));
        }
        /*
       private void saveVilles(object sender, RoutedEventArgs e)
       {
           Ville ville = new Ville()
           {
               Nom = NomTextBox.Text,
               X = XTextBox.Text,
               Y = YTextBox.Text

           };

           Database.GetDatabase().saveVille(ville);



           Close();

       }
       */
    }
}

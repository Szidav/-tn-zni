using Console_feladat;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace Wpf_Vizsga_f4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Dolgozo> dolgozok = new List<Dolgozo>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void buttonMegnyit_Click(object sender, RoutedEventArgs e)
        {
            Megnyitas();

            //Másik mód ha nem teszem külön metódusba!!!
            
            /*OpenFileDialog dialog = new OpenFileDialog();

            if (dialog.ShowDialog() == true)
            {
                try
                {
                    var sorok = File.ReadAllLines(dialog.FileName, Encoding.Default);

                    for (int i = 1; i < sorok.Length; i++)
                    {
                        dolgozok.Add(new Dolgozo(sorok[i]));
                    }
                    datagridDolgozok.ItemsSource = dolgozok;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }*/
        }

        //Metódusos a megoldás, a kód duplikálás elkerülése véget.
        //Előfordulhat rendezés.
        private void Megnyitas()
        {
            OpenFileDialog dialog = new OpenFileDialog();

            if (dialog.ShowDialog() == true)
            {
                try
                {
                    var sorok = File.ReadAllLines(dialog.FileName, Encoding.Default);

                    for (int i = 1; i < sorok.Length; i++)
                    {
                        dolgozok.Add(new Dolgozo(sorok[i]));
                    }
                    datagridDolgozok.ItemsSource = dolgozok;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }


        private void menuitemMegnyitás_Click(object sender, RoutedEventArgs e)
        {
            Megnyitas();
            Adatok adatok = new Adatok(dolgozok);

            //Megjelenéshez kell a ShowDialog()
            adatok.ShowDialog();
        }
    }
}

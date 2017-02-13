using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
using System.Windows.Threading;

namespace TercerReloj
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DispatcherTimerSetup();
            alarma.activate = false;
            textAlarm.Visibility = Visibility.Hidden;


            btGuardar.Visibility = Visibility.Hidden;
            Alarma.Visibility = Visibility.Hidden;
            InfoAct.Text = desac;
            labelItalia.Visibility = Visibility.Hidden;
            labelJapon.Visibility = Visibility.Hidden;
            labelTurquia.Visibility = Visibility.Hidden;

        }
        Alarma alarma = new Alarma();
        DispatcherTimer dispatcherTimer;
        DateTimeOffset startTime;
        DateTimeOffset lastTime;
        DateTimeOffset stopTime;
        string alarm;
        string aux;
        string acti = "activada";
        string desac = "descativada";

        public void DispatcherTimerSetup()
        {
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);



            //IsEnabled defaults to false
            startTime = DateTimeOffset.Now;
            lastTime = startTime;

            dispatcherTimer.Start();
        }

        void dispatcherTimer_Tick(object sender, object e)
        {
            
            textTime.Visibility = Visibility.Visible;
            textTime.Text = DateTime.Now.ToShortTimeString();
            

            if (alarm != null)
            {
                if (alarm.Equals(textTime.Text))
                {
                    MessageBox.Show("Notificación de Alarma");
                    alarm = null;
                }
            }
            aux = textTime.Text;
            //Time since last tick should be very very close to Interval
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("David Casas Gimenez");

            
            

        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            alarm = textAlarm.Text;

            alarma.alarma = textAlarm.Text;

            System.IO.File.WriteAllText(@"C:\Users\46406163y\Documents\Visual Studio 2015\Projects\TercerReloj\hora.txt", alarm);

        }

        private void ItActivar_Click(object sender, RoutedEventArgs e)
        {
            textAlarm.Visibility = Visibility.Visible;
            btGuardar.Visibility = Visibility.Visible;
            Alarma.Visibility = Visibility.Visible;

            InfoAct.Text = acti;

            alarma.activate = true;

        }

        private void ItDesactivar_Click(object sender, RoutedEventArgs e)
        {
            textAlarm.Visibility = Visibility.Hidden;
            btGuardar.Visibility = Visibility.Hidden;
            Alarma.Visibility = Visibility.Hidden;

            InfoAct.Text = desac;

            alarma.activate = false;
        }

        private void Informacion_Click(object sender, RoutedEventArgs e)
        {
            if (alarm == null)
            {
                string resultat = System.IO.File.ReadAllText(@"C:\Users\46406163y\Documents\Visual Studio 2015\Projects\TercerReloj\hora.txt");
                InfoAlarma.Text = resultat;

            }
            else
            {
                InfoAlarma.Text = alarma.alarma;
            }
            
        }

        private void turquia_Click(object sender, RoutedEventArgs e)
        {
            double horas = 3.0;
            textTimeAlter.Text = DateTime.Now.AddHours(horas).ToShortTimeString();
            labelTurquia.Visibility = Visibility.Visible;
            labelItalia.Visibility = Visibility.Hidden;
            labelJapon.Visibility = Visibility.Hidden;
        }

        private void italia_Click(object sender, RoutedEventArgs e)
        {
            double horas = 1.0;
            textTimeAlter.Text = DateTime.Now.AddHours(horas).ToShortTimeString();
            labelItalia.Visibility = Visibility.Visible;
            labelJapon.Visibility = Visibility.Hidden;
            labelTurquia.Visibility = Visibility.Hidden;

        }

        private void japon_Click(object sender, RoutedEventArgs e)
        {
            double horas = 9.0;
            textTimeAlter.Text = DateTime.Now.AddHours(horas).ToShortTimeString();
            labelJapon.Visibility = Visibility.Visible;
            labelTurquia.Visibility = Visibility.Hidden;
            labelItalia.Visibility = Visibility.Hidden;

        }

        private void textAlarm_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }


    [Serializable()]
    public class Alarma : System.ComponentModel.INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string alarma { get; set; }
        public Boolean activate { get; set; }

        public Alarma(string alarma, Boolean activate)
        {

            this.alarma = alarma;
            this.activate = activate;
        }
        public Alarma()
        {
        }
    }

}








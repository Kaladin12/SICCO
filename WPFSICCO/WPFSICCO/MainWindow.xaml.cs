﻿using System;
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
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System.Data;
using System.Xaml;
using XamlGeneratedNamespace;
using System.Net;
using System.Net.Http;
using Microsoft.Win32;
using System.Collections.Specialized;
using System.IO;

namespace WPFSICCO
{
    
    public partial class MainWindow : Window
    {
        
        UTF8Encoding utf = new UTF8Encoding();
        int clasificador = -1;
        public MainWindow()
        {
            InitializeComponent();
            
           
        }
        WebClient Reg_DB = new WebClient();
        
        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
  
        }

        private void Ingresar_Click (object sender, RoutedEventArgs e)
        {
            PaginaRegistrarse registro = new PaginaRegistrarse();
            registro.Show();
            this.Close();
            
        }

        private void OlvContr_Click  (object sender, RoutedEventArgs e)
        {
            
        }

        private void Buttonn_Click_1(object sender, RoutedEventArgs e)
        {
            Basededatos();
        }

        private void txt_Contrasena_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (clasificador == 1)
            {
                EyeOff.Kind = MaterialDesignThemes.Wpf.PackIconKind.Eye;
                clasificador = -1;
                txt_Contraseña.Visibility = System.Windows.Visibility.Collapsed;
                txt_Contrasena.Visibility = System.Windows.Visibility.Visible;             
                txt_Contrasena.Focus();
            }
            else if (clasificador == -1)
            {
               EyeOff.Kind = MaterialDesignThemes.Wpf.PackIconKind.EyeOff;
                clasificador = 1;
                txt_Contraseña.Visibility = System.Windows.Visibility.Visible;
                txt_Contrasena.Visibility = System.Windows.Visibility.Collapsed;
                txt_Contraseña.Focus();
            }
        }
        void Basededatos()
        {
            string pss = txt_Contraseña.Password;
            ASCIIEncoding encoding = new ASCIIEncoding();
            string postdata = "NU=" + txt_NombreUsuario.Text + "&pss=" + pss;
            byte[] data = encoding.GetBytes(postdata);
      
            WebRequest request = WebRequest.Create("http://sicconviene.com/ABRIR_CONEX.php");
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;

            Stream stream = request.GetRequestStream();
            stream.Write(data, 0, data.Length);
            stream.Close();

            WebResponse response = request.GetResponse();
            stream = response.GetResponseStream();
            StreamReader leer = new StreamReader(stream);
            string lectura_php = leer.ReadToEnd();
            leer.Close();
            stream.Close();
            if (lectura_php.Contains("registros_generados"))
            {
                int inicio, fin;
                inicio = lectura_php.IndexOf("o");
                fin = lectura_php.IndexOf("Q")-6;
                Clase_php.No_Control_Usuario = lectura_php.Substring(inicio+1, fin-1); ;
                msgText.Text = "Ingresado correctamente";
                
            }
            Hecho.IsOpen = true;
 
        }

        private void BotonAceptar_Click(object sender, RoutedEventArgs e)
        {
            if (msgText.Text == "Ingresado correctamente")
            {
                PantallaInicio PantallaInicio_Form = new PantallaInicio();
                PantallaInicio_Form.Show();
                this.Close();
            }
        }
    }
}

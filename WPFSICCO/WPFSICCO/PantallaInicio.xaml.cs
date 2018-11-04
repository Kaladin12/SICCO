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
using System.Windows.Shapes;

namespace WPFSICCO
{
    public partial class PantallaInicio : Window
    {
      
        public PantallaInicio()
        {
            InitializeComponent(); 
        }

        private void AbrirMenu_Click(object sender, RoutedEventArgs e)
        {
            AbrirMenu.Visibility = Visibility.Collapsed;
            CerrarMenu.Visibility = Visibility.Visible ;
            BtnInfo.Visibility = Visibility.Visible;
        }

        private void CerrarMenu_Click(object sender, RoutedEventArgs e)
        {
            AbrirMenu.Visibility = Visibility.Visible;
            CerrarMenu.Visibility = Visibility.Collapsed;
            BtnInfo.Visibility = Visibility.Collapsed;
        }

        
        ///////// Menu ////////////
        private void BtnPerfil_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void BtnAgregarArticulo_Selected(object sender, RoutedEventArgs e)
        {
            UserResgistro_Articulos reg = new UserResgistro_Articulos();
            pnlFormas.Children.Add(reg);
            
            
        }

        private void BtnMisCompras_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void BtnMisArticulos_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void BtnServicios_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void BtnInfo_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Buscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                string nombre="", precio="",descripcion="";
                Resultado_busqueda result = new Resultado_busqueda(Buscar.Text, nombre, precio, descripcion);
                result.Show();
            }
        }
    }
}

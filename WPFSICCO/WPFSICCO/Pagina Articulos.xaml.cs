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
    /// <summary>
    /// Lógica de interacción para Pagina_Articulos.xaml
    /// </summary>
    public partial class Pagina_Articulos : Window
    {
        
        public Pagina_Articulos(string id)
        {
            InitializeComponent();
            IDArticulo.Text = "#" + id;
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
             
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}

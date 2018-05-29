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
using Gymly.Models;

namespace Gymly.UserControls
{
    /// <summary>
    /// Interação lógica para UserControlCadastroAvaliacaoFisicaProximaEtapa2_Antropometria.xam
    /// </summary>
    public partial class UserControlCadastroAvaliacaoFisicaProximaEtapa2_Antropometria : UserControl
    {
        private MainWindow mainWindow;
        private AvaliacaoFisica avaliacaoFisica;
        private string txtBoxTextoMedidaMM = "mm";
        public UserControlCadastroAvaliacaoFisicaProximaEtapa2_Antropometria(MainWindow mainWindow, AvaliacaoFisica avaliacaoFisica)
        {
            this.mainWindow = mainWindow;
            this.avaliacaoFisica = avaliacaoFisica;
            InitializeComponent();
            EditorTxtBox.AdicionaTextoInicialTxtBox(txtBoxDobraCutaneaAbdominal, txtBoxTextoMedidaMM);
            EditorTxtBox.AdicionaTextoInicialTxtBox(txtBoxDobraCutaneaAxilarMedia, txtBoxTextoMedidaMM);
            EditorTxtBox.AdicionaTextoInicialTxtBox(txtBoxDobraCutaneaBiceps, txtBoxTextoMedidaMM);
            EditorTxtBox.AdicionaTextoInicialTxtBox(txtBoxDobraCutaneaCoxa, txtBoxTextoMedidaMM);
            EditorTxtBox.AdicionaTextoInicialTxtBox(txtBoxDobraCutaneaPerna, txtBoxTextoMedidaMM);
            EditorTxtBox.AdicionaTextoInicialTxtBox(txtBoxDobraCutaneaSubescapular, txtBoxTextoMedidaMM);
            EditorTxtBox.AdicionaTextoInicialTxtBox(txtBoxDobraCutaneaSuprailiaca, txtBoxTextoMedidaMM);
            EditorTxtBox.AdicionaTextoInicialTxtBox(txtBoxDobraCutaneaTorax, txtBoxTextoMedidaMM);
            EditorTxtBox.AdicionaTextoInicialTxtBox(txtBoxDobraCutaneaTriceps, txtBoxTextoMedidaMM);

        }

        private void BtnProximaEtapa_Click(object sender, RoutedEventArgs e)
        {
            avaliacaoFisica.DobraCutaneaAbdominal = float.Parse(txtBoxDobraCutaneaAbdominal.Text);
            avaliacaoFisica.DobraCutaneaAxilarMedia = float.Parse(txtBoxDobraCutaneaAxilarMedia.Text);
            avaliacaoFisica.DobraCutaneaBiceps = float.Parse(txtBoxDobraCutaneaBiceps.Text);
            avaliacaoFisica.DobraCutaneaCoxa = float.Parse(txtBoxDobraCutaneaCoxa.Text);
            avaliacaoFisica.DobraCutaneaPerna = float.Parse(txtBoxDobraCutaneaPerna.Text);
            avaliacaoFisica.DobraCutaneaSubescapular = float.Parse(txtBoxDobraCutaneaSubescapular.Text);
            avaliacaoFisica.DobraCutaneaSuprailiaca = float.Parse(txtBoxDobraCutaneaSuprailiaca.Text);
            avaliacaoFisica.DobraCutaneaTorax = float.Parse(txtBoxDobraCutaneaTorax.Text);
            avaliacaoFisica.DobraCutaneaTriceps = float.Parse(txtBoxDobraCutaneaTriceps.Text);

            mainWindow.MudarUserControl("cadastroAvaliacaoFisicaProximaEtapa3", avaliacaoFisica);
        }

        private void TxtBoxDobraCutaneaSubescapular_GotFocus(object sender, RoutedEventArgs e)
        {
            EditorTxtBox.GotFocus(txtBoxDobraCutaneaSubescapular);
        }

        private void TxtBoxDobraCutaneaSubescapular_LostFocus(object sender, RoutedEventArgs e)
        {
            EditorTxtBox.LostFocus(txtBoxDobraCutaneaSubescapular, txtBoxTextoMedidaMM);
        }

        private void TxtBoxDobraCutaneaTriceps_LostFocus(object sender, RoutedEventArgs e)
        {
            EditorTxtBox.LostFocus(txtBoxDobraCutaneaTriceps, txtBoxTextoMedidaMM);
        }

        private void TxtBoxDobraCutaneaTriceps_GotFocus(object sender, RoutedEventArgs e)
        {
            EditorTxtBox.GotFocus(txtBoxDobraCutaneaTriceps);
        }

        private void TxtBoxDobraCutaneaBiceps_GotFocus(object sender, RoutedEventArgs e)
        {
            EditorTxtBox.GotFocus(txtBoxDobraCutaneaBiceps);
        }

        private void TxtBoxDobraCutaneaBiceps_LostFocus(object sender, RoutedEventArgs e)
        {
            EditorTxtBox.LostFocus(txtBoxDobraCutaneaBiceps, txtBoxTextoMedidaMM);
        }

        private void TxtBoxDobraCutaneaTorax_LostFocus(object sender, RoutedEventArgs e)
        {
            EditorTxtBox.LostFocus(txtBoxDobraCutaneaTorax, txtBoxTextoMedidaMM);
        }

        private void TxtBoxDobraCutaneaTorax_GotFocus(object sender, RoutedEventArgs e)
        {
            EditorTxtBox.GotFocus(txtBoxDobraCutaneaTorax);
        }

        private void TxtBoxDobraCutaneaAxilarMedia_GotFocus(object sender, RoutedEventArgs e)
        {
            EditorTxtBox.GotFocus(txtBoxDobraCutaneaAxilarMedia);
        }

        private void TxtBoxDobraCutaneaAxilarMedia_LostFocus(object sender, RoutedEventArgs e)
        {
            EditorTxtBox.LostFocus(txtBoxDobraCutaneaAxilarMedia, txtBoxTextoMedidaMM);
        }

        private void TxtBoxDobraCutaneaSuprailiaca_LostFocus(object sender, RoutedEventArgs e)
        {
            EditorTxtBox.LostFocus(txtBoxDobraCutaneaSuprailiaca, txtBoxTextoMedidaMM);
        }

        private void TxtBoxDobraCutaneaSuprailiaca_GotFocus(object sender, RoutedEventArgs e)
        {
            EditorTxtBox.GotFocus(txtBoxDobraCutaneaSuprailiaca);
        }

        private void TxtBoxDobraCutaneaAbdominal_GotFocus(object sender, RoutedEventArgs e)
        {
            EditorTxtBox.GotFocus(txtBoxDobraCutaneaAbdominal);
        }

        private void TxtBoxDobraCutaneaAbdominal_LostFocus(object sender, RoutedEventArgs e)
        {
            EditorTxtBox.LostFocus(txtBoxDobraCutaneaAbdominal, txtBoxTextoMedidaMM);
        }

        private void TxtBoxDobraCutaneaCoxa_LostFocus(object sender, RoutedEventArgs e)
        {
            EditorTxtBox.LostFocus(txtBoxDobraCutaneaCoxa, txtBoxTextoMedidaMM);
        }

        private void TxtBoxDobraCutaneaCoxa_GotFocus(object sender, RoutedEventArgs e)
        {
            EditorTxtBox.GotFocus(txtBoxDobraCutaneaCoxa);
        }

        private void TxtBoxDobraCutaneaPerna_GotFocus(object sender, RoutedEventArgs e)
        {
            EditorTxtBox.GotFocus(txtBoxDobraCutaneaPerna);
        }

        private void TxtBoxDobraCutaneaPerna_LostFocus(object sender, RoutedEventArgs e)
        {
            EditorTxtBox.LostFocus(txtBoxDobraCutaneaPerna, txtBoxTextoMedidaMM);
        }
    }
}
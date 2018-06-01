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
using Gymly.BD;
using Xceed.Wpf.Toolkit;
using Xceed.Wpf.AvalonDock;
using Xceed.Wpf.DataGrid;
using System.IO;
using System.Windows.Forms;
using System.Globalization;

namespace Gymly.UserControls
{
    /// <summary>
    /// Interaction logic for UserControlCadastroAluno.xaml
    /// </summary>
    public partial class UserControlCadastroAluno : System.Windows.Controls.UserControl
    {
        int caracteresCont = 0;
        private MainWindow mainWindow;
        private string caminhoFotoDeRosto;
        private string caminhoSalvarFotoDeRosto;

        public UserControlCadastroAluno(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
            InitializeComponent();
            PreencheComboBoxs("dia");
            PreencheComboBoxs("mes");
            PreencheComboBoxs("ano");
        }

        // private void buttonAtivarCalendario_Click(object sender, RoutedEventArgs e)
        //{
        // calendarDataNasc.Visibility = Visibility.Visible;
        //buttonAtivarCalendario.Visibility = Visibility.Collapsed;
        // }

        private void BtnCadastrarAluno_Click(object sender, RoutedEventArgs e)
        {                   
            if (camposValidos())
            {
                Aluno aluno = new Aluno
                {
                    Nome = txtBoxNome.Text,
                    Cpf = txtBoxCpf.Text,
                    Email = txtBoxEmail.Text,
                    Telefone = txtBoxTelefone.Text
                };
                if (rdMasculino.IsChecked == true)
                {
                    aluno.Sexo = 'M';
                }
                else if (rdFeminino.IsChecked == true)
                {
                    aluno.Sexo = 'F';
                }
                string cpf = aluno.Cpf;
                cpf = cpf.Replace(".", "").Replace("-", "");
                if(ComboBoxNivel.SelectedValue != null)
                aluno.Nivel = ComboBoxNivel.SelectedValue.ToString();
                if (caminhoFotoDeRosto != null && !caminhoFotoDeRosto.Equals(""))
                {
                    GerenciadorDeArquivos.AlocaPasta(cpf);
                    GerenciadorDeArquivos.AlocaPasta(cpf, "Cadastro");
                    caminhoSalvarFotoDeRosto = "Fotos\\" + cpf + "\\" + "Cadastro\\rosto" + GerenciadorDeArquivos.GetExtensao(caminhoFotoDeRosto);
                    GerenciadorDeArquivos.MoveCopiaDeArquivo(caminhoFotoDeRosto, caminhoSalvarFotoDeRosto);
                    aluno.CaminhoFotoDoRosto = GerenciadorDeArquivos.GetCaminho("rosto");
                }
                else
                {
                    aluno.CaminhoFotoDoRosto = String.Empty;
                }

                CultureInfo culture = new CultureInfo("pt-BR");

                aluno.DataNasc = DateTime.Parse((comboBoxDia.SelectedValue + "/" + comboBoxMes.SelectedValue + "/" + comboBoxAno.SelectedValue));
                try
                {
                    BDAluno.InsereAluno(aluno);
                    Anamnese anamnese = new Anamnese();
                    anamnese.CpfAluno = aluno.Cpf;
                    mainWindow.MudarUserControl("cadastroAnamnese", anamnese);
                }
                 catch(Exception ex)
                 {
                      if (ex is System.Data.SQLite.SQLiteException && ex.Message.Equals("constraint failed\r\nUNIQUE constraint failed: ALUNOS.CPF"))
                     {
                        System.Windows.MessageBox.Show("Este cpf ja foi utilizado!");
                     } else
                    {
                        System.Windows.MessageBox.Show("Falha ao salvar aluno no banco de dados");
                    }
                 }
            }
        }
        private void BtnAddFotoDeRosto_Click(object sender, RoutedEventArgs e)
        {
            caminhoFotoDeRosto = GerenciadorDeArquivos.ProcuraImagem();

            if (caminhoFotoDeRosto != null && !caminhoFotoDeRosto.Equals(""))
            {
                ImageFotoDeRosto.Source = GerenciadorDeArquivos.AdicionaImagem(caminhoFotoDeRosto);
                btnAddFotoDeRosto.Background = Brushes.Transparent;
                btnAddFotoDeRosto.BorderBrush = null;
            }
        }
        public void PreencheComboBoxs(string nomeComboBox)
        {
            switch (nomeComboBox)
            {
                case "dia":
                    AdicionaItemNoCmB(1, 31, comboBoxDia);
                    break;
                case "mes":
                    AdicionaItemNoCmB(1, 12, comboBoxMes);
                    break;
                case "ano":
                    AdicionaItemNoCmB(1900, DateTime.Now.Year, comboBoxAno);
                    break;
            }
        }
        public void AdicionaItemNoCmB(int inicio, int fim, System.Windows.Controls.ComboBox comboBox)
        {
       
            List<string> lista = new List<string>();

            for (int i = inicio; i <= fim; i++)
            {
                lista.Add(i.ToString());
            }
            comboBox.ItemsSource = lista;
        }

        private void TxtBoxCpf_TextChanged(object sender, TextChangedEventArgs e)
        {
            int txtSize = txtBoxCpf.Text.Length;
            String temp = txtBoxCpf.Text;
            
            if(txtSize == 0)
            {
                caracteresCont = 0;
            }

            if( !(caracteresCont == txtSize-2) && txtSize == 12 && !temp.Substring(11, 1).Equals("-"))
            {
                caracteresCont = txtSize;
                txtBoxCpf.Text = temp.Substring(0, 11) + "-" + temp.Substring(11, txtSize - 11);
                txtBoxCpf.Select(txtSize + 1, 0);
            }
            if (!(caracteresCont == txtSize-2) && txtSize ==8 && !temp.Substring(7,1).Equals("."))
            {
                caracteresCont = txtSize;
                txtBoxCpf.Text = temp.Substring(0, 7) + "." + temp.Substring(7,txtSize-7);
                txtBoxCpf.Select(txtSize + 1, 0);
            }
            else if (!(caracteresCont == txtSize-2) && txtSize == 4 && !temp.Substring(3, 1).Equals("."))
            {
                caracteresCont = txtSize;
                txtBoxCpf.Text = temp.Substring(0, 3) + "." + temp.Substring(3, txtSize-3);
                txtBoxCpf.Select(txtSize+1,0);
            }
            else 
            {
                caracteresCont = txtSize;
            }
        }

        private void txtBoxCpf_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if(txtBoxCpf.Text.Length == 14)
            {
                e.Handled = true;
                return;
            }

            int valor = (int) e.Key;
            if ((valor >= 34 && valor <= 43) || (valor >= 74 && valor <= 83))
            {
                hintCPF.Visibility = Visibility.Hidden;
                e.Handled = false;
            }
            else
                e.Handled = true;
        }

        private void txtBoxTelefone_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            int valor = (int)e.Key;
            if ((valor >= 34 && valor <= 43) || (valor >= 74 && valor <= 83))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void txtBoxNome_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            hintNome.Visibility = Visibility.Hidden;
        }

        private void comboBoxDia_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(comboBoxAno.SelectedValue != null && comboBoxMes.SelectedValue != null)
            hintDataNasc.Visibility = Visibility.Hidden;
        }

        private void comboBoxMes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBoxAno.SelectedValue != null && comboBoxDia.SelectedValue != null)
                hintDataNasc.Visibility = Visibility.Hidden;
        }

        private void comboBoxAno_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBoxDia.SelectedValue != null && comboBoxMes.SelectedValue != null)
                hintDataNasc.Visibility = Visibility.Hidden;
        }

        private bool camposValidos()
        {
            bool todosCamposValidos = true;
            if (txtBoxCpf.Text.Equals(""))
            {
                hintCPF.Text = "Informe o CPF";
                hintCPF.Visibility = Visibility.Visible;
                todosCamposValidos = false;
            }
            if (txtBoxNome.Text.Equals(""))
            {
                hintNome.Text = "Informe o nome";
                hintNome.Visibility = Visibility.Visible;
                todosCamposValidos = false;
            }
            if (comboBoxDia.SelectedValue == null || comboBoxMes.SelectedValue == null || comboBoxAno.SelectedValue == null)
            {
                hintDataNasc.Text = "Informe a data de nascimento";
                hintDataNasc.Visibility = Visibility.Visible;
                todosCamposValidos = false;
            }
            /*if (!validaCpf(txtBoxCpf.ToString()){
                    todosCamposValidos = false;
            }*/
            if (!validaEmail(txtBoxEmail.Text.ToString()))
            {
                txtBoxEmail.Text = "";
                todosCamposValidos = false;
                hintEmail.Text = "Formato de email invalido!";
                hintEmail.Visibility = Visibility.Visible;
            } else
                hintEmail.Visibility = Visibility.Hidden;
            return todosCamposValidos;
        }
        private bool validaEmail(String email)
        {
            if (!email.Equals(""))
            {
                System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"@");
                return regex.IsMatch(email);
            }
            else
                return true;
        }

        private void txtBoxEmail_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            hintEmail.Visibility = Visibility.Hidden;
        }
    }
}

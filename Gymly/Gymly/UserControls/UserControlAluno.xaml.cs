﻿using Gymly.BD;
using Gymly.Models;
using System;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Gymly.UserControls
{

    public partial class UserControlAluno : UserControl, INotifyPropertyChanged
    {
        private const string nomeTabela = "Aluno";
        private string txtBoxTextoConsultaAluno = "Consultar Alunos";
        private MainWindow mainWindow;

        public UserControlAluno(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
            InitializeComponent();
            DataContext = this;
            EditorTxtBox.AdicionaTextoInicialTxtBox(txtBoxConsultaAluno, txtBoxTextoConsultaAluno);
            PreencheDataGridAluno();
        }
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotificarPropriedadeAlterada(string propriedade)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propriedade));
        }

        private void TxtBoxConsultaAluno_GotFocus(object sender, RoutedEventArgs e)
        {
            EditorTxtBox.GotFocus(txtBoxConsultaAluno);
        }

        private void TxtBoxConsultaAluno_LostFocus(object sender, RoutedEventArgs e)
        {
            
            EditorTxtBox.LostFocus(txtBoxConsultaAluno, txtBoxTextoConsultaAluno);
        }

        private void BtnCadastraAluno_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.MudarUserControl("cadastroAluno");
        }

        private void PreencheDataGridAluno(string nome)
        {
            SQLiteConexao conexao = new SQLiteConexao();
            SQLiteConnection conn = conexao.GetConexao();
            string query = "SELECT cpf, nome, email, STRFTIME('%d/%m/%Y',datanasc) AS 'Data de Nascimento' FROM Alunos WHERE nome like '%" + txtBoxConsultaAluno.Text + "%';";
            SQLiteCommand command = new SQLiteCommand(query, conn);

            DataTable dt = new DataTable("Alunos");

            SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);

            DataSet ds = new DataSet();
            adapter.Fill(dt);
            dataGridAluno.ItemsSource = dt.DefaultView;
            conn.Close();
        }

        private void PreencheDataGridAluno()
        {
            SQLiteConexao conexao = new SQLiteConexao();
            SQLiteConnection conn = conexao.GetConexao();
            string query = "SELECT cpf, nome, email, STRFTIME('%d/%m/%Y',datanasc) AS 'Data de Nascimento' FROM Alunos;";
            SQLiteCommand command = new SQLiteCommand(query, conn);
            DataTable dt = new DataTable("Alunos");
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
            DataSet ds = new DataSet();
            adapter.Fill(dt);
            dataGridAluno.ItemsSource = dt.DefaultView;
            conn.Close();
        }

        private void TxtBoxConsultaAluno_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!(txtBoxConsultaAluno.Text == String.Empty) && !(txtBoxConsultaAluno.Text == txtBoxTextoConsultaAluno))
            {
                PreencheDataGridAluno(txtBoxConsultaAluno.Text);
            } else
            {
                PreencheDataGridAluno();
            }
        }

        private void DataGridAluno_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataRowView dataRow = (DataRowView) dataGridAluno.SelectedItem;
            try
            {
                string cpf = dataRow.Row.ItemArray[0].ToString();
                mainWindow.MudarUserControl("detalhesAluno", cpf);
            }
            catch
            {

            }
        }

        private void DataGridAluno_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //DataRowView dataRow = (DataRowView)dataGridAluno.SelectedItem;
            //string cpf = dataRow.Row.ItemArray[0].ToString();
        }
    }
}
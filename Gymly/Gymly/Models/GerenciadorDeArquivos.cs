﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Imaging;

namespace Gymly.Models
{
    class GerenciadorDeArquivos
    {

        public static void AlocaDiretorioPrincipal()
        {
            if (!File.Exists("Fotos"))
            {
                Directory.CreateDirectory("Fotos");

            }
        }
        public static void AlocaPasta(string cpfAluno)
        {
            if (!File.Exists("Fotos\\" + cpfAluno))
            {
                Directory.CreateDirectory("Fotos\\" + cpfAluno);

            }
        }
        public static void AlocaPasta(string cpfAluno, string nomeDaPastaNova)
        {
            if (!File.Exists("Fotos\\" + cpfAluno + "\\" + nomeDaPastaNova))
            {
                Directory.CreateDirectory("Fotos\\" + cpfAluno + "\\" + nomeDaPastaNova);
            }
        }
        public static void MoveCopiaDeArquivo(string caminhoOrigem, string caminhoDestino)
        {
            File.Copy(caminhoOrigem, caminhoDestino);
        }
        public static string ProcuraImagem()
        {
            string nomeFoto=null;
            OpenFileDialog dlg = new OpenFileDialog
            {
                InitialDirectory = "c:\\",
                Filter = "Image files (*.jpg)|*.jpg|All Files (*.*)|*.*",
                RestoreDirectory = true,
                Multiselect = false
            };
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                nomeFoto = dlg.FileName;
              
            }
            return nomeFoto;
        }
        public static string GetExtensao(string caminho) {

            return Path.GetExtension(caminho);
        }
        public static string GetCaminho(string nome)
        {
            return Path.GetFileName(nome);
        }
        public static BitmapImage AdicionaImagem(string caminho) {
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(caminho);
            bitmap.EndInit();
            return bitmap;
        }
    }
}

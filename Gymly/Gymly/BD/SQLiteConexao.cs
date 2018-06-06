﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;

namespace Gymly.BD
{
    class SQLiteConexao
    {

        private static string nomeBanco = "gymly.db";
        private static string conexao = "Data Source="+nomeBanco;
        private SQLiteConnection conn;


        public SQLiteConexao()
        {
            CriaTabelas();
        }

        public SQLiteConnection GetConexao()
        {
            conn = new SQLiteConnection(conexao);
            conn.Open();
            return conn;
        }

        private void CriaTabelas()
        {
            if (!File.Exists(nomeBanco))
            {
                SQLiteConnection.CreateFile(nomeBanco);
                conn = new SQLiteConnection(conexao);
                conn.Open();
                StringBuilder sql = new StringBuilder();

                sql.AppendLine("PRAGMA foreign_keys = ON;");
                SQLiteCommand cmd = new SQLiteCommand(sql.ToString(), conn);
                cmd.ExecuteNonQuery();
                sql.Clear();
                sql.AppendLine("CREATE TABLE IF NOT EXISTS ALUNOS ([CPF] VARCHAR(16) PRIMARY KEY,");
                sql.AppendLine("[NOME] VARCHAR(50),");
                sql.AppendLine("[DATANASC] DATE,");
                sql.AppendLine("[EMAIL] VARCHAR(50),");
                sql.AppendLine("[TELEFONE] VARCHAR(15),");
                sql.AppendLine("[SEXO] VARCHAR(10),");
                sql.AppendLine("[NIVEL] VARCHAR(50),"); 
                sql.AppendLine("[FOTO_DE_ROSTO] VARCHAR(256));");
                cmd = new SQLiteCommand(sql.ToString(), conn);
                cmd.ExecuteNonQuery();
                sql.Clear();



                sql.AppendLine("CREATE TABLE IF NOT EXISTS ANAMNESES ([CPF_ALUNO] VARCHAR(16) PRIMARY KEY,");
                sql.AppendLine("[HISTORICO_PROBLEMA_CARDIACO] INT,");
                sql.AppendLine("[HISTORICO_DORES_PEITO] INT,");
                sql.AppendLine("[HISTORICO_DESMAIOS_OU_VERTIGEM] INT,");
                sql.AppendLine("[HISTORICO_PRESSAO_ALTA] INT,");
                sql.AppendLine("[HISTORICO_PROBLEMA_OSSEO] INT,");
                sql.AppendLine("[IDOSO_NAO_ACOSTUMADO] INT,");
                sql.AppendLine("[DOENCA_CARDIACA_CORONARIANA] INT,");
                sql.AppendLine("[DOENCA_CARDIACA_REUMATICA] INT,");
                sql.AppendLine("[DOENCA_CARDIACA_CONGENITA] INT,");
                sql.AppendLine("[BATIMENTOS_CARDIACOS_IRREGULARES] INT,");
                sql.AppendLine("[PROBLEMA_VALVULAS_CARDIACAS] INT,");
                sql.AppendLine("[MURMURIOS_CARDIACOS] INT,");
                sql.AppendLine("[ATAQUE_CARDIACO] INT,");
                sql.AppendLine("[DERRAME_CEREBRAL] INT,");
                sql.AppendLine("[EPILEPSIA] INT,");
                sql.AppendLine("[DIABETES] INT,");
                sql.AppendLine("[HIPERTENSAO] INT,");
                sql.AppendLine("[CANCER] INT,");
                sql.AppendLine("[DOR_COSTAS] INT,");
                sql.AppendLine("[DOR_ARTICULACAO] INT,");
                sql.AppendLine("[DOR_PULMONAR] INT,");
                sql.AppendLine("[GESTANTE] INT,");
                sql.AppendLine("[FUMANTE] INT,");
                sql.AppendLine("[BEBIDA_ALCOOLICA] INT,");
                sql.AppendLine("[PERDER_PESO] INT,");
                sql.AppendLine("[MELHORAR_FLEXIBILIDADE] INT,");
                sql.AppendLine("[DIMINUIR_VICIOS] INT,");
                sql.AppendLine("[REDUZIR_DORES] INT,");
                sql.AppendLine("[MELHORAR_NUTRICAO] INT,");
                sql.AppendLine("[MELHORAR_APTIDAO] INT,");
                sql.AppendLine("[MELHORAR_MUSCULAR] INT,");
                sql.AppendLine("[REDUZIR_ESTRESSE] INT,");
                sql.AppendLine("[SENTIR_MELHOR] INT,");
                sql.AppendLine("[HIPERTROFIA] INT,");
                sql.AppendLine("[OBSERVACAO] VARCHAR(256),");
                sql.AppendLine("FOREIGN KEY(CPF_ALUNO) REFERENCES ALUNO(CPF));");
                cmd = new SQLiteCommand(sql.ToString(), conn);
                cmd.ExecuteNonQuery();
                sql.Clear();

                sql.AppendLine("CREATE TABLE IF NOT EXISTS AVALIACAOFISICA ([ID] INTEGER PRIMARY KEY AUTOINCREMENT,");
                sql.AppendLine("[CPF_ALUNO] VARCHAR(16),");
                sql.AppendLine("[DATA] DATE,");
                sql.AppendLine("[CAMINHOIMAGEMFRONTAL]  VARCHAR(256),");
                sql.AppendLine("[OBSERVACAOIMAGEMFRONTAL]  VARCHAR(256),");
                sql.AppendLine("[CAMINHOIMAGEMLATERAL]  VARCHAR(256),");
                sql.AppendLine("[OBSERVACAOIMAGEMLATERAL]  VARCHAR(256),");
                sql.AppendLine("[CAMINHOIMAGEMCOSTAS]  VARCHAR(256),");
                sql.AppendLine("[OBSERVACAOIMAGEMCOSTAS] VARCHAR(256),");
                sql.AppendLine("[PERIMETROOMBRO] FLOAT,");
                sql.AppendLine("[PERIMETROTORAX] FLOAT,");
                sql.AppendLine("[PERIMETROBRACODIREITO] FLOAT,");
                sql.AppendLine("[PERIMETROBRACOESQUERDO] FLOAT,");
                sql.AppendLine("[PERIMETROCINTURA] FLOAT,");
                sql.AppendLine("[PERIMETROABDOMINAL] FLOAT,");
                sql.AppendLine("[PERIMETROQUADRIL] FLOAT,");
                sql.AppendLine("[PERIMETROCOXAPROXIMALDIREITA] FLOAT,");
                sql.AppendLine("[PERIMETROCOXAPROXIMALESQUERDA] FLOAT,");
                sql.AppendLine("[PERIMETROCOXAMEDIALDIREITA] FLOAT,");
                sql.AppendLine("[PERIMETROCOXAMEDIALESQUERDA] FLOAT,");
                sql.AppendLine("[PERIMETROCOXADISTALDIREITA] FLOAT,");
                sql.AppendLine("[PERIMETROCOXADISTALESQUERDA] FLOAT,");
                sql.AppendLine("[PERIMETROPERNADIREITA] FLOAT,");
                sql.AppendLine("[PERIMETROPERNAESQUERDA] FLOAT,");
                sql.AppendLine("[ENVERGADURA] FLOAT,");
                sql.AppendLine("[ALTURA] FLOAT,");
                sql.AppendLine("[MASSA] FLOAT,");
                sql.AppendLine("[PRESSAOARTERIALSISTOLICA] FLOAT,");
                sql.AppendLine("[PRESSAOARTERIALDIASTOLICA] FLOAT,");
                sql.AppendLine("[FREQUENCIACARDIACA] FLOAT,");
                sql.AppendLine("[TEMPOABDOMINAL] FLOAT,");
                sql.AppendLine("[TEMPOFLEXAO] FLOAT,");
                sql.AppendLine("FOREIGN KEY(CPF_ALUNO) REFERENCES ALUNOS(CPF));");
                cmd = new SQLiteCommand(sql.ToString(), conn);
                cmd.ExecuteNonQuery();
                sql.Clear();

                sql.AppendLine("CREATE TABLE IF NOT EXISTS AF_ANTROPOMETRICA ([ID] INTEGER PRIMARY KEY AUTOINCREMENT,");
                sql.AppendLine("[CPF_ALUNO] VARCHAR(16),");
                sql.AppendLine("[DOBRACUTANEASUBESCAPULAR] FLOAT,");
                sql.AppendLine("[DOBRACUTANEATRICEPS] FLOAT,");
                sql.AppendLine("[DOBRACUTANEABICEPS] FLOAT,");
                sql.AppendLine("[DOBRACUTANEATORAX] FLOAT,");
                sql.AppendLine("[DOBRACUTANEAAXILARMEDIA] FLOAT,");
                sql.AppendLine("[DOBRACUTANEASUPRAILIACA] FLOAT,");
                sql.AppendLine("[DOBRACUTANEAABDOMINAL] FLOAT,");
                sql.AppendLine("[DOBRACUTANEACOXA] FLOAT,");
                sql.AppendLine("[DOBRACUTANEAPERNA] FLOAT,");
                sql.AppendLine("FOREIGN KEY(CPF_ALUNO) REFERENCES ALUNOS(CPF));");

                cmd = new SQLiteCommand(sql.ToString(), conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gymly.Models;
using System.Data.SQLite;
namespace Gymly.BD
{
    class BDAvaliacaoFisica
    {
        public static void InsereAvaliacaoFisica(AvaliacaoFisica avaliacaoFisica)
        {
            SQLiteConexao conexao = new SQLiteConexao();
            SQLiteConnection conn = conexao.GetConexao();

            string sql = "INSERT INTO AvaliacaoFisica(id,cpf_aluno,data,tipo,perimetroOmbro,perimetroTorax,perimetroBracoE,perimetroBracoD,perimetroAntebracoE,perimetroAntebracoD" +
                ",perimetroCintura,perimetroAbdominal,perimetroQuadril,perimetroCoxaProximalE,perimetroCoxaProximalD,perimetroCoxaMedialE,perimetroCoxaMedialD,perimetroCoxaDistalE, perimetroCoxaDistalD," +
                "perimetroPernaE, perimetroPernaD,dobraCutaneaSubescapular,dobraCutaneaTriceps,dobraCutaneaBiceps,dobraCutaneaTorax,dobraCutaneaAxilarMedia," +
                "dobraCutaneaSuprailiaca,dobraCutaneaAbdominal,dobraCutaneaCoxa,dobraCutaneaPerna,altura,massa,envergadura,tempoFlexao,tempoAbdominal,flexibilidade,pressaoArterialSistolica,pressaoArterialDiastolica,frequenciaCardiaca)" +
                "VALUES(@id,@cpf_aluno,@data,@tipo,@perimetroOmbro,@perimetroTorax,@perimetroBracoE,@perimetroBracoD,@perimetroAntebracoE,@perimetroAntebracoD,@perimetroCintura" +
                ",@perimetroAbdominal,@perimetroQuadril,@perimetroCoxaProximalE,@perimetroCoxaProximalD,@perimetroCoxaMedialE,@perimetroCoxaMedialD,@perimetroCoxaDistalE, @perimetroCoxaDistalD,@perimetroPernaE, @perimetroPernaD," +
                "@dobraCutaneaSubescapular,@dobraCutaneaTriceps,@dobraCutaneaBiceps,@dobraCutaneaTorax,@dobraCutaneaAxilarMedia," +
                "@dobraCutaneaSuprailiaca,@dobraCutaneaAbdominal,@dobraCutaneaCoxa,@dobraCutaneaPerna,@altura,@massa,@envergadura,@tempoFlexao,@tempoAbdominal,@flexibilidade,@pressaoArterialSistolica,@pressaoArterialDiastolica,@frequenciaCardiaca);";



            SQLiteCommand cmd = new SQLiteCommand(sql, conn);
            cmd.Parameters.AddWithValue("@cpf_aluno", avaliacaoFisica.CpfAluno);
            String data = avaliacaoFisica.Data.ToString("dd/MM/yyyy HH:mm:ss");
            if (!data.Equals("01/01/0001 00:00:00"))
                cmd.Parameters.AddWithValue("@data", avaliacaoFisica.Data);
            else
             cmd.Parameters.AddWithValue("@id", avaliacaoFisica.Id);
            cmd.Parameters.AddWithValue("@data", DateTime.Now);
            cmd.Parameters.AddWithValue("@tipo", avaliacaoFisica.TipoDeAvaliacao);
            cmd.Parameters.AddWithValue("@perimetroOmbro", avaliacaoFisica.PerimetroOmbro);
            cmd.Parameters.AddWithValue("@perimetroTorax", avaliacaoFisica.PerimetroTorax);
            cmd.Parameters.AddWithValue("@perimetroBracoE", avaliacaoFisica.PerimetroBracoEsquerdo);
            cmd.Parameters.AddWithValue("@perimetroBracoD", avaliacaoFisica.PerimetroBracoDireito);
            cmd.Parameters.AddWithValue("@perimetroAntebracoE", avaliacaoFisica.PerimetroAntebracoEsquerdo);
            cmd.Parameters.AddWithValue("@perimetroAntebracoD", avaliacaoFisica.PerimetroAntebracoDireito);
            cmd.Parameters.AddWithValue("@perimetroCintura", avaliacaoFisica.PerimetroCintura);
            cmd.Parameters.AddWithValue("@perimetroAbdominal", avaliacaoFisica.PerimetroAbdominal);
            cmd.Parameters.AddWithValue("@perimetroQuadril", avaliacaoFisica.PerimetroQuadril);
            cmd.Parameters.AddWithValue("@perimetroCoxaProximalE", avaliacaoFisica.PerimetroCoxaProximalEsquerda);
            cmd.Parameters.AddWithValue("@perimetroCoxaProximalD", avaliacaoFisica.PerimetroCoxaProximalDireita);
            cmd.Parameters.AddWithValue("@perimetroCoxaMedialE", avaliacaoFisica.PerimetroCoxaMedialEsquerda);
            cmd.Parameters.AddWithValue("@perimetroCoxaMedialD", avaliacaoFisica.PerimetroCoxaMedialDireita);
            cmd.Parameters.AddWithValue("@perimetroCoxaDistalE", avaliacaoFisica.PerimetroCoxaDistalEsquerda);
            cmd.Parameters.AddWithValue("@perimetroCoxaDistalD", avaliacaoFisica.PerimetroCoxaDistalDireita);
            cmd.Parameters.AddWithValue("@perimetroPernaE", avaliacaoFisica.PerimetroPernaEsquerda);
            cmd.Parameters.AddWithValue("@perimetroPernaD", avaliacaoFisica.PerimetroPernaDireita);
            cmd.Parameters.AddWithValue("@dobraCutaneaSubescapular", avaliacaoFisica.DobraCutaneaSubescapular);
            cmd.Parameters.AddWithValue("@dobraCutaneaTriceps", avaliacaoFisica.DobraCutaneaTriceps);
            cmd.Parameters.AddWithValue("@dobraCutaneaBiceps", avaliacaoFisica.DobraCutaneaBiceps);
            cmd.Parameters.AddWithValue("@dobraCutaneaTorax", avaliacaoFisica.DobraCutaneaTorax);
            cmd.Parameters.AddWithValue("@dobraCutaneaAxilarMedia", avaliacaoFisica.DobraCutaneaAxilarMedia);
            cmd.Parameters.AddWithValue("@dobraCutaneaSuprailiaca", avaliacaoFisica.DobraCutaneaSuprailiaca);
            cmd.Parameters.AddWithValue("@dobraCutaneaAbdominal", avaliacaoFisica.DobraCutaneaAbdominal);
            cmd.Parameters.AddWithValue("@dobraCutaneaCoxa", avaliacaoFisica.DobraCutaneaCoxa);
            cmd.Parameters.AddWithValue("@dobraCutaneaPerna", avaliacaoFisica.DobraCutaneaPerna);
            cmd.Parameters.AddWithValue("@altura", avaliacaoFisica.Altura);
            cmd.Parameters.AddWithValue("@massa", avaliacaoFisica.Massa);
            cmd.Parameters.AddWithValue("@envergadura", avaliacaoFisica.Envergadura);
            cmd.Parameters.AddWithValue("@distanciaCooper", avaliacaoFisica.DistanciaCooper);
            cmd.Parameters.AddWithValue("@tempoFlexao", avaliacaoFisica.TempoFlexao);
            cmd.Parameters.AddWithValue("@tempoAbdominal", avaliacaoFisica.TempoAbdominal);
            cmd.Parameters.AddWithValue("@flexibilidade", avaliacaoFisica.Flexibilidade);
            cmd.Parameters.AddWithValue("@pressaoArterialSistolica", avaliacaoFisica.PressaoArterialSistolica);
            cmd.Parameters.AddWithValue("@pressaoArterialDiastolica", avaliacaoFisica.PressaoArterialDiastolica);
            cmd.Parameters.AddWithValue("@frequenciaCardiaca", avaliacaoFisica.FrequenciaCardiaca);





            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static List<string> SelecionaIdAvaliacoesFisicasDoAluno(string cpf)
        {
            List<string> idAvFisicas = new List<string>();
            SQLiteConexao conexao = new SQLiteConexao();
            SQLiteConnection conn = conexao.GetConexao();

            string sql = "SELECT id FROM AvaliacaoFisica WHERE cpf_aluno LIKE '"+cpf+"';";
            SQLiteCommand cmd = new SQLiteCommand(sql, conn);
            SQLiteDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                idAvFisicas.Add(reader.GetString(0));
            }
            reader.Close();
            return idAvFisicas;
        }
        internal static void AtualizaAvaliacaoFisica(AvaliacaoFisica avaliacaoFisica)
        {
            SQLiteConexao conexao = new SQLiteConexao();
            SQLiteConnection conn = conexao.GetConexao();

            string sql = "UPDATE AvaliacaoFisica SET " +
                         "data = @data," +
                         "tipo = @tipo," +
                         "perimetroOmbro = @perimetroOmbro," +
                         "perimetroTorax = @perimetroTorax, " +
                         "perimetroBracoE = @perimetroBracoE, " +
                         "perimetroBracoD = @perimetroBracoD," +
                         "perimetroAntebracoE = @perimetroAntebracoE," +
                         "perimetroAntebracoD = @perimetroAntebracoD," +
                         "perimetroCintura = @perimetroCintura," +
                         "perimetroAbdominal = @perimetroAbdominal," +
                         "perimetroQuadril = @perimetroQuadril," +
                         "perimetroCoxaProximalE = @perimetroCoxaProximalE," +
                         "perimetroCoxaProximalD = @perimetroCoxaProximalD," +
                         "perimetroCoxaMedialE= @perimetroCoxaMedialE," +
                         "perimetroCoxaMedialD = @perimetroCoxaMedialD," +
                         "perimetroCoxaDistalE =@perimetroCoxaDistalE," +
                         "perimetroCoxaDistalD = @perimetroCoxaDistalD" +
                         ",perimetroPernaE = @perimetroPernaE," +
                         "perimetroPernaD = @perimetroPernaD," +
                         "dobraCutaneaSubescapular = @dobraCutaneaSubescapular," +
                         "dobraCutaneaTriceps = @dobraCutaneaTriceps,"
                         + 
                         
                         "dobraCutaneaBiceps = @dobraCutaneaBiceps," +
                         "dobraCutaneaTorax = @dobraCutaneaTorax," +
                         "dobraCutaneaAxilarMedia= @dobraCutaneaAxilarMedia ," +
                         "dobraCutaneaSuprailiaca = @dobraCutaneaSuprailiaca," +
                         "dobraCutaneaAbdominal = @dobraCutaneaAbdominal," +
                         "dobraCutaneaCoxa = @dobraCutaneaCoxa," +
                          "dobraCutaneaAbdominal = @dobraCutaneaAbdominal,"+
                           "distanciaCooper = @distanciaCooper,"+
                         "tempoFlexao = @tempoFlexao," +
                       "quantidadeFlexao = @qtdadeFlexao," +
                      "tempoAbdominal = @tempoAbdominal," +
                       "quantidadeAbdominal = @qtdadeAbdominais," +
                      "flexibilidade = @flexibilidade," +
                       "frequenciaCardiaca = @frequenciaCardiaca," +
                         "pressaoArterialSistolica = @pressaoArterialSistolica," +
                        "pressaoArterialDiastolica = @pressaoArterialDiastolica," +
                         "altura = @altura," +
                         "massa = @massa, " +
                         "envergadura = @envergadura " +    
                         "where id = @id;";




            SQLiteCommand cmd = new SQLiteCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id", avaliacaoFisica.Id);
            cmd.Parameters.AddWithValue("@data", DateTime.Now.ToShortDateString());
            cmd.Parameters.AddWithValue("@tipo", avaliacaoFisica.TipoDeAvaliacao);
            cmd.Parameters.AddWithValue("@perimetroOmbro", avaliacaoFisica.PerimetroOmbro);
            cmd.Parameters.AddWithValue("@perimetroTorax", avaliacaoFisica.PerimetroTorax);
            cmd.Parameters.AddWithValue("@perimetroBracoE", avaliacaoFisica.PerimetroBracoEsquerdo);
            cmd.Parameters.AddWithValue("@perimetroBracoD", avaliacaoFisica.PerimetroBracoDireito);
            cmd.Parameters.AddWithValue("@perimetroAntebracoE", avaliacaoFisica.PerimetroAntebracoEsquerdo);
            cmd.Parameters.AddWithValue("@perimetroAntebracoD", avaliacaoFisica.PerimetroAntebracoDireito);
            cmd.Parameters.AddWithValue("@perimetroCintura", avaliacaoFisica.PerimetroCintura);
            cmd.Parameters.AddWithValue("@perimetroAbdominal", avaliacaoFisica.PerimetroAbdominal);
            cmd.Parameters.AddWithValue("@perimetroQuadril", avaliacaoFisica.PerimetroQuadril);
            cmd.Parameters.AddWithValue("@perimetroCoxaProximalE", avaliacaoFisica.PerimetroCoxaProximalEsquerda);
            cmd.Parameters.AddWithValue("@perimetroCoxaProximalD", avaliacaoFisica.PerimetroCoxaProximalDireita);
            cmd.Parameters.AddWithValue("@perimetroCoxaMedialE", avaliacaoFisica.PerimetroCoxaMedialEsquerda);
            cmd.Parameters.AddWithValue("@perimetroCoxaMedialD", avaliacaoFisica.PerimetroCoxaMedialDireita);
            cmd.Parameters.AddWithValue("@perimetroCoxaDistalE", avaliacaoFisica.PerimetroCoxaDistalEsquerda);
            cmd.Parameters.AddWithValue("@perimetroCoxaDistalD", avaliacaoFisica.PerimetroCoxaDistalDireita);
            cmd.Parameters.AddWithValue("@perimetroPernaE", avaliacaoFisica.PerimetroPernaEsquerda);
            cmd.Parameters.AddWithValue("@perimetroPernaD", avaliacaoFisica.PerimetroPernaDireita);
            cmd.Parameters.AddWithValue("@dobraCutaneaSubescapular", avaliacaoFisica.DobraCutaneaSubescapular);
            cmd.Parameters.AddWithValue("@dobraCutaneaTriceps", avaliacaoFisica.DobraCutaneaTriceps);
            cmd.Parameters.AddWithValue("@dobraCutaneaBiceps", avaliacaoFisica.DobraCutaneaBiceps);
            cmd.Parameters.AddWithValue("@dobraCutaneaTorax", avaliacaoFisica.DobraCutaneaTorax);
            cmd.Parameters.AddWithValue("@dobraCutaneaAxilarMedia", avaliacaoFisica.DobraCutaneaAxilarMedia);
            cmd.Parameters.AddWithValue("@dobraCutaneaSuprailiaca", avaliacaoFisica.DobraCutaneaSuprailiaca);
            cmd.Parameters.AddWithValue("@dobraCutaneaAbdominal", avaliacaoFisica.DobraCutaneaAbdominal);
            cmd.Parameters.AddWithValue("@dobraCutaneaCoxa", avaliacaoFisica.DobraCutaneaCoxa);
            cmd.Parameters.AddWithValue("@dobraCutaneaPerna", avaliacaoFisica.DobraCutaneaPerna);
            cmd.Parameters.AddWithValue("@altura", avaliacaoFisica.Altura);
            cmd.Parameters.AddWithValue("@massa", avaliacaoFisica.Massa);
            cmd.Parameters.AddWithValue("@pressaoArterialSistolica", avaliacaoFisica.PressaoArterialSistolica);
            cmd.Parameters.AddWithValue("@pressaoArterialDiastolica", avaliacaoFisica.PressaoArterialDiastolica);
            cmd.Parameters.AddWithValue("@frequenciaCardiaca", avaliacaoFisica.FrequenciaCardiaca);
            cmd.Parameters.AddWithValue("@flexibilidade", avaliacaoFisica.Flexibilidade);
            cmd.Parameters.AddWithValue("@qtdadeAbdominais", avaliacaoFisica.QtdadeAbdominais);
            cmd.Parameters.AddWithValue("@tempoAbdominal", avaliacaoFisica.TempoAbdominal);
            cmd.Parameters.AddWithValue("@qtdadeFlexao", avaliacaoFisica.QtdadeFlexao);
            cmd.Parameters.AddWithValue("@tempoFlexao", avaliacaoFisica.TempoFlexao);
            cmd.Parameters.AddWithValue("@distanciaCooper", avaliacaoFisica.DistanciaCooper);
            cmd.Parameters.AddWithValue("@envergadura", avaliacaoFisica.Envergadura);

            cmd.ExecuteNonQuery();
            conn.Close();
        }


        public static AvaliacaoFisica SelecionaAvaliacaoFisicaPeloId(int id)
        {
            SQLiteConexao conexao = new SQLiteConexao();
            SQLiteConnection conn = conexao.GetConexao();

            string sql = "SELECT * FROM AvaliacaoFisica where id = '" + id + "';";
            SQLiteCommand cmd = new SQLiteCommand(sql, conn);
            //cmd.Parameters.AddWithValue("cpf_aluno", cpf);
            SQLiteDataReader reader = cmd.ExecuteReader();
            reader.Read();

            AvaliacaoFisica avaliacaoFisica = new AvaliacaoFisica();
            try
            {
                avaliacaoFisica.Id = Convert.ToInt32(reader["ID"]);
                avaliacaoFisica.CpfAluno = reader["CPF_ALUNO"] .ToString();
                avaliacaoFisica.Data = Convert.ToDateTime(reader["DATA"]);
                avaliacaoFisica.TipoDeAvaliacao = reader["TIPO"].ToString();
                avaliacaoFisica.PerimetroOmbro = (float) Convert.ToDouble(reader["PERIMETROOMBRO"]);
                avaliacaoFisica.PerimetroTorax = (float)Convert.ToDouble(reader["PERIMETROTORAX"]);
                avaliacaoFisica.PerimetroBracoEsquerdo = (float)Convert.ToDouble(reader["PERIMETROBRACOE"]);
                avaliacaoFisica.PerimetroBracoDireito = (float)Convert.ToDouble(reader["PERIMETROBRACOD"]);
                avaliacaoFisica.PerimetroAntebracoEsquerdo = (float)Convert.ToDouble(reader["perimetroAntebracoE"]);
                avaliacaoFisica.PerimetroAntebracoDireito = (float)Convert.ToDouble(reader["perimetroAntebracoD"]);
                avaliacaoFisica.PerimetroCintura = (float)Convert.ToDouble(reader["PERIMETROCINTURA"]);
                avaliacaoFisica.PerimetroAbdominal = (float)Convert.ToDouble(reader["PERIMETROABDOMINAL"]);
                avaliacaoFisica.PerimetroQuadril = (float)Convert.ToDouble(reader["PERIMETROQUADRIL"]);
                avaliacaoFisica.PerimetroCoxaProximalEsquerda = (float)Convert.ToDouble(reader["PERIMETROCOXAPROXIMALE"]);
                avaliacaoFisica.PerimetroCoxaProximalDireita = (float)Convert.ToDouble(reader["PERIMETROCOXAPROXIMALD"]);
                avaliacaoFisica.PerimetroCoxaMedialEsquerda = (float)Convert.ToDouble(reader["PERIMETROCOXAMEDIALE"]);
                avaliacaoFisica.PerimetroCoxaMedialDireita = (float)Convert.ToDouble(reader["PERIMETROCOXAMEDIALD"]);
                avaliacaoFisica.PerimetroCoxaDistalEsquerda = (float)Convert.ToDouble(reader["perimetroCoxaDistalE"]);
                avaliacaoFisica.PerimetroCoxaDistalDireita = (float)Convert.ToDouble(reader["perimetroCoxaDistalD"]);
                avaliacaoFisica.PerimetroPernaEsquerda = (float)Convert.ToDouble(reader["PERIMETROPERNAE"]);
                avaliacaoFisica.PerimetroPernaDireita = (float)Convert.ToDouble(reader["PERIMETROPERNAD"]);
                avaliacaoFisica.DobraCutaneaSubescapular = (float)Convert.ToDouble(reader["DOBRACUTANEASUBESCAPULAR"]);
                avaliacaoFisica.DobraCutaneaTriceps = (float)Convert.ToDouble(reader["DOBRACUTANEATRICEPS"]);
                avaliacaoFisica.DobraCutaneaBiceps = (float)Convert.ToDouble(reader["DOBRACUTANEABICEPS"]);
                avaliacaoFisica.DobraCutaneaTorax = (float)Convert.ToDouble(reader["DOBRACUTANEATORAX"]);
                avaliacaoFisica.DobraCutaneaAxilarMedia = (float)Convert.ToDouble(reader["DOBRACUTANEAAXILARMEDIA"]);
                avaliacaoFisica.DobraCutaneaSuprailiaca = (float)Convert.ToDouble(reader["DOBRACUTANEASUPRAILIACA"]);
                avaliacaoFisica.DobraCutaneaAbdominal = (float)Convert.ToDouble(reader["DOBRACUTANEAABDOMINAL"]);
                avaliacaoFisica.DobraCutaneaCoxa = (float)Convert.ToDouble(reader["DOBRACUTANEACOXA"]);
                avaliacaoFisica.DobraCutaneaPerna = (float)Convert.ToDouble(reader["DOBRACUTANEAPERNA"]);
                avaliacaoFisica.Altura = (float)Convert.ToDouble(reader["ALTURA"]);
                avaliacaoFisica.Massa = (float)Convert.ToDouble(reader["MASSA"]);
                avaliacaoFisica.PressaoArterialSistolica = (float)Convert.ToDouble(reader["PRESSAOARTERIALSISTOLICA"]);
                avaliacaoFisica.PressaoArterialDiastolica = (float)Convert.ToDouble(reader["PRESSAOARTERIALDIASTOLICA"]);
                avaliacaoFisica.FrequenciaCardiaca = (float)Convert.ToDouble(reader["FREQUENCIACARDIACA"]);
                avaliacaoFisica.TempoAbdominal = (float)Convert.ToDouble(reader["TEMPOABDOMINAL"]);
                avaliacaoFisica.TempoFlexao = (float)Convert.ToDouble(reader["TEMPOFLEXAO"]);
                avaliacaoFisica.Flexibilidade = reader["FLEXIBILIDADE"].ToString();
                avaliacaoFisica.QtdadeAbdominais = Convert.ToInt32(reader["QUANTIDADEABDOMINAL"]);
                avaliacaoFisica.QtdadeFlexao = Convert.ToInt32(reader["QUANTIDADEFLEXAO"]);
                avaliacaoFisica.DistanciaCooper = (float)Convert.ToDouble(reader["DISTANCIACOOPER"]);
                avaliacaoFisica.Envergadura = (float)Convert.ToDouble(reader["ENVERGADURA"]);




            }
            catch
            {

            }
            finally
            {
                reader.Close();
                conn.Close();
            }

            return avaliacaoFisica;
        }
    }
    /*
    public static Aluno SelecionaAvaliacaoFisicaPorId(int id, string tipo)
    {
        SQLiteConexao conexao = new SQLiteConexao();
        SQLiteConnection conn = conexao.GetConexao();

        string sql = (tipo=="Antropometrica")? "SELECT af.*, a.* FROM AvaliacaoFisica af JOIN AF_Antropometrica a ON af.id = a.id_af WHERE af.id = "+id : "SELECT af.*, b.* FROM AvaliacaoFisica af JOIN AF_Bioimpedancia b ON af.id = b.id_af WHERE af.id = " + id;

        SQLiteCommand cmd = new SQLiteCommand(sql, conn);
        SQLiteDataReader reader = cmd.ExecuteReader();
        reader.Read();

        AvaliacaoFisica avaliacaoFisica = new AvaliacaoFisica();
        try
        {
            avaliacaoFisica.Data = reader["DATA"].ToString();
            avaliacaoFisica.CaminhoImagemFrontal = reader["CAMINHOIMAGEMFRONTAL"].ToString();
            avaliacaoFisica.ObservacaoImagemFrontal = reader["OBSERVACAOIMAGEMFRONTAL"].ToString();
            avaliacaoFisica.CaminhoImagemFrontal = reader["CAMINHOIMAGEMLATERAL"].ToString();
            avaliacaoFisica.CaminhoImagemFrontal = reader["OBSERVACAOIMAGEMLATERAL"].ToString();
            avaliacaoFisica.CaminhoImagemFrontal = reader["CAMINHOIMAGEMCOSTAS"].ToString();
            avaliacaoFisica.CaminhoImagemFrontal = reader["OBSERVACAOIMAGEMCOSTAS"].ToString();
            avaliacaoFisica.CaminhoImagemFrontal = reader["PERIMETROOMBRO"].ToString();
            avaliacaoFisica.CaminhoImagemFrontal = reader["PERIMETROTORAX"].ToString();
            avaliacaoFisica.CaminhoImagemFrontal = reader["PERIMETROBRACODIREITO"].ToString();
            avaliacaoFisica.CaminhoImagemFrontal = reader["PERIMETROBRACOESQUERDO"].ToString();
            avaliacaoFisica.CaminhoImagemFrontal = reader["PERIMETROCINTURA"].ToString();
            avaliacaoFisica.CaminhoImagemFrontal = reader["PERIMETROABDOMINAL"].ToString();
            avaliacaoFisica.CaminhoImagemFrontal = reader["PERIMETROQUADRIL"].ToString();
            avaliacaoFisica.CaminhoImagemFrontal = reader["PERIMETROCOXAPROXIMALDIREITA"].ToString();
            avaliacaoFisica.CaminhoImagemFrontal = reader["PERIMETROCOXAPROXIMALESQUERDA"].ToString();
            avaliacaoFisica.CaminhoImagemFrontal = reader["PERIMETROCOXAMEDIALDIREITA"].ToString();
            avaliacaoFisica.CaminhoImagemFrontal = reader["PERIMETROCOXAMEDIALESQUERDA"].ToString();
            avaliacaoFisica.CaminhoImagemFrontal = reader["PERIMETROCOXADISTALESQUERDA"].ToString();
            avaliacaoFisica.CaminhoImagemFrontal = reader["PERIMETROPERNADIREITA"].ToString();
            avaliacaoFisica.CaminhoImagemFrontal = reader["PERIMETROPERNAESQUERDA"].ToString();
            avaliacaoFisica.CaminhoImagemFrontal = reader["ENVERGADURA"].ToString();
            avaliacaoFisica.CaminhoImagemFrontal = reader["ALTURA"].ToString();
            avaliacaoFisica.CaminhoImagemFrontal = reader["MASSA"].ToString();
            avaliacaoFisica.CaminhoImagemFrontal = reader["PRESSAOARTERIALSISTOLICA"].ToString();
            avaliacaoFisica.CaminhoImagemFrontal = reader["PRESSAOARTERIALDIASTOLICA"].ToString();
            avaliacaoFisica.CaminhoImagemFrontal = reader["FREQUENCIACARDIACA"].ToString();
            avaliacaoFisica.CaminhoImagemFrontal = reader["TEMPOABDOMINAL"].ToString();
            avaliacaoFisica.CaminhoImagemFrontal = reader["TEMPOFLEXAO"].ToString();
        }
        catch
        {

        }
        reader.Close();
        conn.Close();
        return aluno;
    }
    */

}
    

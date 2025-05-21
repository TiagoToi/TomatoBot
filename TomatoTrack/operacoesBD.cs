using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows;
using System.IO;
using System.Data;
using System.Runtime.InteropServices.WindowsRuntime;
using TomatoTrack.Models;

namespace TomatoTrack
{
    class operacoesBD
    {
        public static List<LoteModel> getLotes(int IdUser)
        {
            SQLiteConnection conn = Conectar();
            SQLiteCommand cmd = new SQLiteCommand("SELECT * FROM Lotes where IdUser = @idUser ORDER BY IdLote DESC", conn);
            cmd.Parameters.AddWithValue("@idUser", IdUser);

            try
            {
                List<LoteModel> lotes = new List<LoteModel>();
                SQLiteDataReader leitor = cmd.ExecuteReader();
                while (leitor.Read())
                {
                    LoteModel lote = new LoteModel()
                    {
                        Id = Convert.ToInt32(leitor["IdLote"]),
                        TotalTomates = Convert.ToInt32(leitor["NumeroTomates"]),
                        TomatesMaduros = Convert.ToInt32(leitor["QuantidadeMaduros"]),
                        mediaScoreMaduros = Convert.ToDouble(leitor["MediaScoreMaduros"]),
                        desvioPadraoMaduros = Convert.ToDouble(leitor["DesvioPadraoMaduros"]),
                        mediaScoreVerdes = Convert.ToDouble(leitor["MediaScoreVerdes"]),
                        desvioPadraoVerdes = Convert.ToDouble(leitor["DesvioPadraoVerdes"]),
                        NumeroImagens = Convert.ToInt32(leitor["QuantidadeImagens"])
                    };
                    lote.setDateTime(leitor.GetString(leitor.GetOrdinal("DiaHora")));
                    lotes.Add(lote);
                }
                return lotes;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao visualizar imagens." + ex.Message, "Erro!");
                return null;
            }
            finally
            {
                conn.Close();
            }
        }
            
        public static List<byte[]> getImagens(int idLote)
        {
            SQLiteConnection conn = Conectar();
            SQLiteCommand cmd = new SQLiteCommand("SELECT Imagem FROM Imagens where IdLote = @idLote", conn);
            cmd.Parameters.AddWithValue("@idLote", idLote);

            try
            {
                List<byte[]> imagens = new List<byte[]>();
                SQLiteDataReader leitor = cmd.ExecuteReader();
                while (leitor.Read())
                {
                    imagens.Add((byte[])leitor["Imagem"]);
                }
                return imagens;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao visualizar imagens." +  ex.Message, "Erro!");
                return null;
            }
            finally
            {
                conn.Close();
            }
        }

        public static bool SalvarLote(int IdUser, String dataHora, int numTomates, int qntMaduros, double mediaScoreMaduros, double desvioPadraoMaduros, double mediaScoreVerdes, double desvioPadraoVerdes, List<byte[]> imagens)
        {
            SQLiteConnection conn = Conectar();
            SQLiteCommand cmd = new SQLiteCommand("INSERT INTO Lotes (DiaHora, NumeroTomates, QuantidadeMaduros, MediaScoreMaduros, DesvioPadraoMaduros, MediaScoreVerdes, DesvioPadraoVerdes, QuantidadeImagens, IdUser) " +
                "VALUES (@dataHora, @numTomates, @qntMaduros, @MediaScoreMaduros, @DesvioPadraoMaduros, @MediaScoreVerdes, @DesvioPadraoVerdes, @qntImagens, @idUser)", conn);
            cmd.Parameters.AddWithValue("@dataHora", dataHora);
            cmd.Parameters.AddWithValue("@numTomates", numTomates);
            cmd.Parameters.AddWithValue("@qntMaduros", qntMaduros);
            cmd.Parameters.AddWithValue("@MediaScoreMaduros", mediaScoreMaduros);
            cmd.Parameters.AddWithValue("@DesvioPadraoMaduros", desvioPadraoMaduros);
            cmd.Parameters.AddWithValue("@MediaScoreVerdes", mediaScoreVerdes);
            cmd.Parameters.AddWithValue("@DesvioPadraoVerdes", desvioPadraoVerdes);
            cmd.Parameters.AddWithValue("@qntImagens", imagens.Count());
            cmd.Parameters.AddWithValue("@idUser", IdUser);

            try
            {
                cmd.ExecuteNonQuery();

                long idLote = conn.LastInsertRowId;

                foreach (byte[] imagem in imagens)
                {
                    SQLiteCommand cmdImagem = new SQLiteCommand("INSERT INTO Imagens (IdLote, Imagem) VALUES (@idlote, @imagem)", conn);
                    cmdImagem.Parameters.AddWithValue("@idlote", idLote);
                    cmdImagem.Parameters.AddWithValue("@imagem", imagem);

                    cmdImagem.ExecuteNonQuery();
                }
                MessageBox.Show("Lote salvo.", "Sucesso!", MessageBoxButton.OK, MessageBoxImage.Information);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar lote: " + ex.Message);
                return false;
            }
            finally
            {
                conn.Close();                
            }
        }

        public static List<String> VerificaLogin(string email, string senha)
        {
            SQLiteConnection conn = Conectar();
            SQLiteCommand cmd = new SQLiteCommand("SELECT * FROM Users WHERE Email = @email AND Senha = @senha", conn);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@senha", senha);
            try
            {
                List<String> list = new List<String>();
                SQLiteDataReader leitor = cmd.ExecuteReader();
                while (leitor.Read())
                {
                    list.Add(leitor.GetInt64(0).ToString());
                    list.Add(leitor.GetString(1));
                }
                return list;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao verificar login: " + ex.Message);
                return null;
            }
            finally
            {
                conn.Close();
            }
        }

        public static bool criarUser(string nome, string senha, string email    )
        {
            SQLiteConnection conn = Conectar();
            SQLiteCommand cmd = new SQLiteCommand("INSERT INTO Users (Nome, Senha, Email) VALUES (@nome, @senha, @email)", conn);
            cmd.Parameters.AddWithValue("@nome", nome);
            cmd.Parameters.AddWithValue("@senha", senha);
            cmd.Parameters.AddWithValue("@email", email);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Usuário criado!", "Sucesso!", MessageBoxButton.OK, MessageBoxImage.Information);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao criar usuário: " + ex.Message);
                return false;
            }
            finally
            {
                conn.Close();
            }
        }

        public static SQLiteConnection Conectar()
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string caminho = Path.GetFullPath(Path.Combine(baseDir, @"..\..\..\Banco De Dados\TomatoTrack.db"));
            string caminhoBanco = $"Data Source={caminho};Version=3";


            SQLiteConnection conn = new SQLiteConnection(caminhoBanco);
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao conectar ao banco de dados: " + ex.Message);
            }
            return conn;
        }  
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using TomatoTrack.Models;

namespace TomatoTrack
{
    /// <summary>
    /// Interação lógica para LotesPage.xam
    /// </summary>
    public partial class LotesPage : UserControl
    {
        public LotesPage(int IdUser, String nomeUser)
        {
            InitializeComponent();

            List<LoteModel> lotes = operacoesBD.getLotes(IdUser);

            if (lotes == null || lotes.Count() == 0)
            {
                MessageBox.Show($"O usuário {nomeUser} não possui lotes salvos.");
                return;
            }

            foreach (var lote in lotes)
            {
                LoteItem item = new LoteItem(lote);
                LotesList.Items.Add(item);
            }
        }
    }

}

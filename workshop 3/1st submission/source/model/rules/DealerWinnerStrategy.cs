using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    class DealerWinnerStrategy: IWinnerStrategy
    {
        private const int g_maxScore = 21;
        public bool Winner(model.Player a_dealer, model.Player a_player)
        {
            if (a_dealer.CalcScore() > g_maxScore)
            {
                return false;
            }

            else if (a_player.CalcScore() > g_maxScore)
            {
                return true;
            }

            else
            {
                return a_dealer.CalcScore() > a_player.CalcScore();
            }
        }
    }
}

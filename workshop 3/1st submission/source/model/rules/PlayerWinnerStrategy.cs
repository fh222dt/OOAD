using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    //return true if dealer is winner
    class PlayerWinnerStrategy: IWinnerStrategy
    {
        private const int g_maxScore = 21;
        public bool Winner(model.Player a_dealer, Player a_player)
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
                return a_player.CalcScore() < a_dealer.CalcScore();
            }
        }
    }
}

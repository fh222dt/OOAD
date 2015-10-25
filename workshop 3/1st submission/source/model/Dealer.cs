﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model
{
    class Dealer : Player
    {
        private Deck m_deck = null;
        private const int g_maxScore = 21;

        private rules.INewGameStrategy m_newGameRule;
        private rules.IHitStrategy m_hitRule;
        private rules.IWinnerStrategy m_winnerRule;


        public Dealer(rules.RulesFactory a_rulesFactory)
        {
            m_newGameRule = a_rulesFactory.GetNewGameRule();
            m_hitRule = a_rulesFactory.GetHitRule();
            m_winnerRule = a_rulesFactory.GetWinnerRule();
        }

        public bool NewGame(Player a_player)
        {
            if (m_deck == null || IsGameOver())
            {
                m_deck = new Deck();
                ClearHand();
                a_player.ClearHand();
                return m_newGameRule.NewGame(m_deck, this, a_player);   
            }
            return false;
        }

        public bool Hit(Player a_player)
        {
            if (m_deck != null && a_player.CalcScore() < g_maxScore && !IsGameOver())
            {
                Deal(a_player);

                return true;
            }
            return false;
        }

        public bool Stand()
        {
            if (m_deck != null)
            {
                ShowHand();
                
                foreach (Card c in GetHand())
                {
                    c.Show(true);
                }

                while (m_hitRule.DoHit(this))
                {                    
                    Deal(this);

                }

                return true;
            }

            return false;
        }

        public bool IsDealerWinner(Player a_player)
        {       
            return m_winnerRule.Winner(this, a_player);     //returns if dealer is winner
        }

        public bool IsGameOver()
        {
            if (m_deck != null && /*CalcScore() >= g_hitLimit*/ m_hitRule.DoHit(this) != true)
            {
                return true;
            }
            return false;
        }

        public void Deal(Player a_player, bool show = true)
        {
            Card c;
            c = m_deck.GetCard();
            c.Show(show);
            a_player.DealCard(c);
        }
    }
}
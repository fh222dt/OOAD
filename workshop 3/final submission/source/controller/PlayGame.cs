﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.controller
{
    class PlayGame: model.ICardObserver
    {
        private model.Game m_game;
        private view.IView m_view;

        public PlayGame(model.Game a_game, view.IView a_view)
        {
            m_game = a_game;
            m_view = a_view;
            m_game.RegisterObserver(this);
        }

        public bool Play()
        {
            Display();

            if (m_game.IsGameOver())
            {
                m_view.DisplayGameOver(m_game.IsDealerWinner());
            }


            view.MenuChoice input = m_view.GetInput();

            if (input == view.MenuChoice.Play)
            {
                m_game.NewGame();
            }

            if (input == view.MenuChoice.Hit)
            {
                m_game.Hit();
            }

            if (input == view.MenuChoice.Stand)
            {
                m_game.Stand();
            }

            if (input == view.MenuChoice.Quit)
            {
                return false;
            }

            return true;
        }

        private void Display()
        {
            m_view.DisplayWelcomeMessage();

            m_view.DisplayDealerHand(m_game.GetDealerHand(), m_game.GetDealerScore());
            m_view.DisplayPlayerHand(m_game.GetPlayerHand(), m_game.GetPlayerScore());
        }

        public void cardInHand()
        {
            Display();
            System.Threading.Thread.Sleep(1500);
            

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    class Soft17HitStrategy: IHitStrategy
    {
        private const int g_hitLimit = 17;

        public bool DoHit(model.Player a_dealer)
        {
            if(a_dealer.CalcScore() == g_hitLimit)
            {
                IEnumerable<Card> aces = a_dealer.GetHand().Where(c => c.GetValue() == Card.Value.Ace);                //get all aces from hand
                IEnumerable<Card> handWithoutAces = a_dealer.GetHand().Where(c => c.GetValue() != Card.Value.Ace);     //get all other cards from hand
                
                int score = a_dealer.CalcCardsScore(handWithoutAces);          //calc score of hand without aces

                return aces.Count() > 0 && score == 6;                        //return if there is aces and score of other cards is 6
            }

            else
            {
                return a_dealer.CalcScore() < g_hitLimit;
            }

            
        }
    }
}

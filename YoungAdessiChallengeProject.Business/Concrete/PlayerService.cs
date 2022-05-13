using System;
using System.Collections.Generic;
using System.Linq;
using YoungAdessiChallengeProject.Business.Abstract;

namespace YoungAdessiChallengeProject.Business.Concrete
{
    public class PlayerService : IPlayerService
    {
        public int GetWinnerPlayer(int count)
        {
            var players = PreparePlayers(count);
            
            var tourCount = 1;
            var playerToEliminate =(int) Math.Pow(2, tourCount);
            var lastPlayer = players.LastOrDefault();
          
            while (players.Count != 2)
            {
                players.Remove(playerToEliminate);
                playerToEliminate += (int) Math.Pow(2, tourCount);

                var checkForNextTour = playerToEliminate > count;
                if (checkForNextTour)
                {
                    (playerToEliminate,tourCount,lastPlayer) = SetForNextTour(lastPlayer,tourCount,players);
                }
            }

            return players.FirstOrDefault();
        }
        
        private List<int> PreparePlayers(int count)
        {
            var player = new List<int>();
            for (var i = 1; i <= count; i++)
            {
                player.Add(i);
            }

            return player;
        }

        private (int playerToEliminate, int tourCount, int lastPlayer) SetForNextTour(int lastPlayer,int tourCount, List<int> players)
        {
            return (players.Any(x => x == lastPlayer) ? players[0] : players[1], ++tourCount, players.LastOrDefault());
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labyrinth
{

	// smilih se nad vas kolegi, ne sym puskal obfuskatora, shtoto se zamislih, che i vie moze da imate
    class LabTest
    {
        const int TOP_RESULTS_CAPACITY = 5;
        static void Main()
        {
            //ScoreBoard ladder = new ScoreBoard();
            
            ScoreBoard ladder = new ScoreBoard(TOP_RESULTS_CAPACITY);
            Random rand = new Random();
            while (1 == 1)
            {


                Game game = new Game(rand, ladder);
            }
        }
    }
}

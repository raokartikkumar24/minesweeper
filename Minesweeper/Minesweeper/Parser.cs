using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{

    class Parser
    {
        private readonly string m_CSInput;
        private int m_nRows;
        private int m_nColumns;

        public MainGame game;

        public Parser(string input)
        {
           
            m_CSInput = input;
            m_nColumns = m_nRows = 0;
        }

        public Parser()
        {
            m_nColumns = m_nRows = 0;
        }

        public void ParseInput(string input)
        {
            int l = input.Length;

            string[] col = input.Split(',');

            m_nRows = col.Length + 2;
            
            m_nColumns = col[0].Length + 2;

            game = new MainGame(m_nRows,m_nColumns);
            
            for(int i = 0 ; i < m_nRows; ++i)
            {
                game.setField(i,col[i]);
            }

        }

        public void PlayGame()
        {
            string sLayout;
            Console.WriteLine("Welcome to Minesweeper");
            Console.Write("Enter the minefield layout : ");
            sLayout = Console.ReadLine();
            
            ParseInput(sLayout);
          

           while( !game.IsGameover()  && !game.gamecomplete())
           {
               string options;
               Console.Write("Enter option : ");
               options = Console.ReadLine();
               ParseOption(options);
              
           }

           if (game.IsGameover())
               Console.WriteLine("Oops, you stepped on a mine ! Game over!");

           else if (game.gamecomplete())
               Console.WriteLine("Wow,you cleared the minefield ! Game over !");

        }



        public int GetNumberOfRows()
        {
            return m_nRows;
        }

        public int GetNumberOfColumns()
        {
            return m_nColumns;
        }

        public void ParseOption(string options)
        {
            char c = options[0];
            switch(c)
            {
                case 'o':
                    game.UpdateField(c, options[2] - '0', options[4] - '0'); 

                    break;
                case 'f':
                    game.UpdateField(c, options[2] - '0', options[4] - '0');
                    break;
            }

        }
    }
}

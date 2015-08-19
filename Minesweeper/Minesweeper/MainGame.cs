using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    class MainGame
    {
        private char m_cOption;
        private int m_X;
        private int m_Y;
        private char[][] m_cField;
        private char[][] m_cDisplayGrid;
        private int m_nRows;
        private int m_nColumns;
        private bool m_BGameOver;
        public MainGame()
        {
          
        }

        public MainGame(int r, int c)
        {
            m_BGameOver = false;
            m_cOption = 'o';
            m_X = m_Y = 0;
            setRows(r);
            setColumns(c);
          
            InitField();
        }

        public void UpdateField(char op, int x, int y)
        {
            setOption(op);
            setX(x);
            setY(y);
            UpdateGrid();
        }

        private void setOption(char option)
        {
            m_cOption = option;
        }

        private void setX(int x)
        {
            m_X = x;

        }

        private void setY(int y)
        {
            m_Y = y;
        }


        public void setRows(int r)
        {
            m_nRows = r;
        }

        public void setColumns(int c)
        {
            m_nColumns = c;
        }

        public void setField(int index, string values)
        {
            
                for(int j = 0; j < m_nColumns; ++j)
                {
                    m_cField[index][j] = values[j];
                }
            
        }


        public bool gamecomplete()
        {
            return (m_cField[m_nRows - 1][ m_nColumns - 1] == '0');
        }
        public void InitField()
        {
            m_cField = new char[m_nRows][];
            m_cDisplayGrid = new char[m_nColumns][];

            for (int i = 0; i < m_nRows; ++i)
            {
                m_cField[i] = new char[m_nColumns];
                m_cDisplayGrid[i] = new char[m_nColumns];
            }


            for (int i = 0; i < m_nRows; ++i)
            {
                for (int j = 0; j < m_nColumns; ++j)
                {
                    m_cField[i][j] = '0';
                    m_cDisplayGrid[i][j] = 'x';
                }
            }
        }

        public void DisplayGrid()
        {
            for(int i = 0 ; i < m_nRows; ++i)
            {
                for(int j = 0 ; j < m_nColumns ; ++j)
                {
                    Console.Write(m_cField[i][j]);
                }
                Console.WriteLine();
            }
        }

        public void DisplayGrid2()
        {
            for (int i = 0; i < m_nRows; ++i)
            {
                for (int j = 0; j < m_nColumns; ++j)
                {
                    Console.Write(m_cDisplayGrid[i][j]);
                }
                Console.WriteLine();
            }
        }

        public bool IsGameover()
        {
            return m_BGameOver;
        }

        public void UpdateGrid()
        {
            if (m_cOption == 'o')
            {
                if (m_cField[m_X][m_Y] == 'm')
                {
                    // you lose the game
                    m_BGameOver = true;
                    DisplayGrid();
                }
                else
                {
                    int val = m_cField[m_X][m_Y] -'0';
                    val += (m_cField[m_X - 1][m_Y] - '0') +
                            (m_cField[m_X + 1][m_Y] - '0') +
                            (m_cField[m_X][m_Y - 1] - '0') +
                            (m_cField[m_X][m_Y + 1] - '0');

                    m_cField[m_X][m_Y] = Convert.ToChar(val);
                    m_cDisplayGrid[m_X][m_Y] = Convert.ToChar(val); 
                    DisplayGrid2();
                }
            }
            else
            {
                m_cField[m_X][m_Y] = m_cOption;
                m_cDisplayGrid[m_X][m_Y] = m_cOption;
                DisplayGrid2();
            }
        }
    }
}

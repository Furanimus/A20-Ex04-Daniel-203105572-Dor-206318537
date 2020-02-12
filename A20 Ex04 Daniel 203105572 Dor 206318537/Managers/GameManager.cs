using A20_Ex04_Daniel_203105572_Dor_206318537.Components;
using A20_Ex04_Daniel_203105572_Dor_206318537.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A20_Ex04_Daniel_203105572_Dor_206318537.Managers
{
     public class GameManager : RegisteredComponent
     {
          private const string k_Title = @"Score: {0}   Bet: {1}";
          private readonly IInputManager r_InputManager;
          private bool m_isDreidelSpinning;
          private int m_Score;
          private Keys m_Bet;

          public GameManager(Game i_Game)
               : base(i_Game, int.MaxValue)
          {
               r_InputManager = i_Game.Services.GetService(typeof(IInputManager)) as IInputManager;
          }

          public override void Update(GameTime i_GameTime)
          {
               Game.Window.Title = string.Format(k_Title, m_Score, m_Bet.ToString());

               if(!m_isDreidelSpinning)
               {
                    readPlayerBet();

                    if (r_InputManager.KeyPressed(Keys.Space))
                    {
                         m_isDreidelSpinning = true;
                         startDreidelsSpinRound();
                    }
               }
               
               base.Update(i_GameTime);
          }

          
          private void startDreidelsSpinRound()
          {

          }

          private void readPlayerBet()
          {
               if(r_InputManager.KeyPressed(Keys.B))
               {
                    m_Bet = Keys.B;
               }
               if(r_InputManager.KeyPressed(Keys.D))
               {
                    m_Bet = Keys.D;
               }
               if(r_InputManager.KeyPressed(Keys.V))
               {
                    m_Bet = Keys.V;
               }
               if(r_InputManager.KeyPressed(Keys.P))
               {
                    m_Bet = Keys.P;
               }
          }

     }
}

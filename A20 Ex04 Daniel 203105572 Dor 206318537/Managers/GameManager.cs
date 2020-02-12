using A20_Ex04_Daniel_203105572_Dor_206318537.Components;
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
          private readonly InputManager r_InputManager;
          private int m_Score;
          private Keys m_Bet;

          public GameManager(Game i_Game)
               : base(i_Game, int.MaxValue)
          {
               r_InputManager = i_Game.Services.GetService(typeof(InputManager)) as InputManager;
          }

          public override void Update(GameTime i_GameTime)
          {
               Game.Window.Title = string.Format(k_Title, m_Score, m_Bet.ToString());

               readPlayerBet();

               base.Update(i_GameTime);
          }

          private void readPlayerBet()
          {
               
          }

     }
}

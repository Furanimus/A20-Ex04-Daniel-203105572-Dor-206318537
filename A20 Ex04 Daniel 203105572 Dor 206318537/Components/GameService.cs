using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace A20_Ex04_Daniel_203105572_Dor_206318537.Components
{
     public abstract class GameService : RegisteredComponent
     {
          public GameService(Game i_Game, int i_UpdateOrder)
              : base(i_Game, i_UpdateOrder)
          {
               RegisterAsService();
          }

          public GameService(Game i_Game)
              : base(i_Game)
          {
               RegisterAsService();
          }

          protected virtual void RegisterAsService()
          {
               this.Game.Services.AddService(this.GetType(), this);
          }
     }
}

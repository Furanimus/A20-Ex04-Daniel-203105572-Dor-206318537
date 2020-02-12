using A20_Ex04_Daniel_203105572_Dor_206318537.Components;
using A20_Ex04_Daniel_203105572_Dor_206318537.Interfaces;
using A20_Ex04_Daniel_203105572_Dor_206318537.Models;
using A20_Ex04_Daniel_203105572_Dor_206318537.Utils;
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
          private readonly IRandomBehavior r_RandomBehavior;
          private bool m_isGameSpinState;
          private int m_Score;
          private int m_DreidelStoppedCount;
          private float m_TimeSinceStartRound;
          private Keys m_Bet;
          private float k_VelocityToSubstruct = 0.1f;

          public GameManager(Game i_Game)
               : base(i_Game, int.MaxValue)
          {
               r_InputManager = i_Game.Services.GetService(typeof(IInputManager)) as IInputManager;
               r_RandomBehavior = i_Game.Services.GetService(typeof(IRandomBehavior)) as IRandomBehavior;
          }

          public override void Update(GameTime i_GameTime)
          {
               Game.Window.Title = string.Format(k_Title, m_Score, m_Bet.ToString());

               if (!m_isGameSpinState)
               {
                    readPlayerBet();

                    if (r_InputManager.KeyPressed(Keys.Space) && m_Bet != 0)
                    {
                         m_isGameSpinState = true;
                         startDreidelSpinRound();
                    }
               }
               else
               {
                    m_TimeSinceStartRound += (float)i_GameTime.ElapsedGameTime.TotalSeconds;

                    foreach (Object3D component in (Game as BaseGame).World)
                    {
                         if (component is Dreidel)
                         {
                              if (!(component as Dreidel).IsIdle)
                              {
                                   lowerDreidelAngularVelocity(component as Dreidel, i_GameTime);
                              }
                              else
                              {
                                   component.AngularVelocity = Vector3.Zero;
                                   //fixDreidelFacing();
                              }
                         }
                    }

                    if (m_DreidelStoppedCount == (Game as BaseGame).World.Count)
                    {
                         m_isGameSpinState = !m_isGameSpinState;
                         //checkScore();
                    }
               }

               base.Update(i_GameTime);
          }

          private void fixDreidelFacing(Dreidel i_Dreidel)
          {
               float yRotation = i_Dreidel.Rotations.Y % MathHelper.TwoPi;



          }

          private void lowerDreidelAngularVelocity(Dreidel i_Dreidel, GameTime i_GameTime)
          {
               float delta = getYRotationDelta(i_Dreidel.AngularVelocity.Y % MathHelper.TwoPi);
               float velocity = (delta / m_TimeSinceStartRound) - ((m_TimeSinceStartRound * k_VelocityToSubstruct + k_VelocityToSubstruct * (float)Math.Pow(m_TimeSinceStartRound, 2)) / 2);
               i_Dreidel.AngularVelocity = new Vector3(0, MathHelper.Clamp(velocity, 0, int.MaxValue), 0);
               // rotation % 2Pi = 280deg | 270 < 280 <= 360 | delta = 360 - 280 = 80 | this.velocity = delta / total_time ...
               // v = 20/total_time - (total_time * velocity_to_substract + velocity_to_substract * total_time^2)/ 2 * total_time

               //i_Dreidel.AngularVelocity = new Vector3(0, 0.8f, 0) * (float)i_GameTime.ElapsedGameTime.TotalSeconds;

               //// current deg: 70 | 0 < 70 < 90 | 90 - 70 = 20, 0 - 70 = 70
               //if (i_Dreidel.AngularVelocity.Y < 0)
               //{
               //     (i_Dreidel as Dreidel).IsIdle = true;
               //     i_Dreidel.AngularVelocity = Vector3.Zero;
               //     m_DreidelStoppedCount++;
               //     //fixDreidelFacing();
               //}
          }

          private float getYRotationDelta(float i_CurrentYRotation)
          {
               if (i_CurrentYRotation <= MathHelper.PiOver2 && i_CurrentYRotation > 0)
               {
                    return MathHelper.PiOver2 - i_CurrentYRotation;
               }
               else if (i_CurrentYRotation <= MathHelper.Pi && i_CurrentYRotation > MathHelper.PiOver2)
               {
                    return MathHelper.Pi - i_CurrentYRotation;
               }
               else if (i_CurrentYRotation <= MathHelper.ToRadians(270) && i_CurrentYRotation > MathHelper.Pi)
               {
                    return MathHelper.ToRadians(270) - i_CurrentYRotation;
               }
               else
               {
                    return MathHelper.TwoPi - i_CurrentYRotation;
               }

          }

          private void startDreidelSpinRound()
          {
               setRandomAngularVelocityToDreidels();
          }

          private void setRandomAngularVelocityToDreidels()
          {
               foreach (Object3D dreidel in (Game as BaseGame).World)
               {
                    dreidel.AngularVelocity = r_RandomBehavior.GenerateRandomAngularVelocityY();
                    (dreidel as Dreidel).IsIdle = false;
               }
          }

          private void readPlayerBet()
          {
               if (r_InputManager.KeyPressed(Keys.B))
               {
                    m_Bet = Keys.B;
               }
               if (r_InputManager.KeyPressed(Keys.D))
               {
                    m_Bet = Keys.D;
               }
               if (r_InputManager.KeyPressed(Keys.V))
               {
                    m_Bet = Keys.V;
               }
               if (r_InputManager.KeyPressed(Keys.P))
               {
                    m_Bet = Keys.P;
               }
          }

     }
}

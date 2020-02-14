using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using A20_Ex04_Daniel_203105572_Dor_206318537.Components;
using A20_Ex04_Daniel_203105572_Dor_206318537.Interfaces;
using A20_Ex04_Daniel_203105572_Dor_206318537.Models;
using A20_Ex04_Daniel_203105572_Dor_206318537.Utils;

namespace A20_Ex04_Daniel_203105572_Dor_206318537.Managers
{
     public class GameManager : RegisteredComponent
     {
          private const string k_Title = @"Score: {0}   Bet: {1}";
          private const int k_DreidelsCount = 6;
          private const int k_LetterCount = 4;
          private readonly IInputManager r_InputManager;
          private readonly IRandomBehavior r_RandomBehavior;
          private readonly List<eDreidelLetter> r_DreidelsRandomLetters = new List<eDreidelLetter>(k_DreidelsCount);
          private bool m_TakeBet = true;
          private bool m_IsSpinning = false;
          private int m_Score;
          private int m_DreidelStoppedCount;
          private eDreidelLetter m_Bet = eDreidelLetter.None;
          private string m_BetStr;
          private List<float> m_DreidelsDistancesToEndPoint = new List<float>(k_DreidelsCount);
          private List<float> m_DreidelsInitialVelocity = new List<float>(k_DreidelsCount);
          private List<bool> m_DreidelsStopped = new List<bool>(k_DreidelsCount);
          private List<float> m_DreidelsInitialRotation = new List<float>(k_DreidelsCount);

          public GameManager(Game i_Game)
               : base(i_Game, int.MaxValue)
          {
               r_InputManager = i_Game.Services.GetService(typeof(IInputManager)) as IInputManager;
               r_RandomBehavior = i_Game.Services.GetService(typeof(IRandomBehavior)) as IRandomBehavior;
          }

          public override void Update(GameTime i_GameTime)
          {
               Game.Window.Title = string.Format(k_Title, m_Score, m_BetStr);

               if (m_TakeBet)
               {
                    takeBet();
               }
               else
               {
                    if (m_IsSpinning == true)
                    {
                         spinDreidels();

                         if (m_DreidelStoppedCount == 6)
                         {
                              updateScore();
                              m_DreidelStoppedCount = 0;
                              m_IsSpinning = false;
                              m_TakeBet = true;
                              m_Bet = eDreidelLetter.None;
                              m_BetStr = string.Empty;
                         }
                    }
               }

               base.Update(i_GameTime);
          }

          private void updateScore()
          {
               foreach(eDreidelLetter letter in r_DreidelsRandomLetters)
               {
                    if(letter == m_Bet)
                    {
                         m_Score++;
                    }
               }
          }

          private void chooseRandomLetters()
          {
               for(int i = 0; i < k_DreidelsCount; i++)
               {
                    eDreidelLetter letter = (eDreidelLetter)r_RandomBehavior.GetRandomIntegerNumber(0, k_LetterCount);

                    if (r_DreidelsRandomLetters.Count < k_DreidelsCount)
                    {
                         r_DreidelsRandomLetters.Add(letter);
                    }
                    else
                    {
                         r_DreidelsRandomLetters[i] = letter;
                    }
               }
          }

          private void restartSpin()
          {
               Composite3D world = (this.Game as BaseGame).World;

               for (int i = 0; i < m_DreidelsStopped.Count; i++)
               {
                    Composite3D dreidel = world[i] as Composite3D;

                    m_DreidelsStopped[i] = false;
                    m_DreidelsDistancesToEndPoint[i] = generateRandomDistanceLength(i);
                    m_DreidelsInitialVelocity[i] = (float)r_RandomBehavior.GetRandomDoubleNumber(10, 25);
                    dreidel.AngularVelocity = new Vector3(0, m_DreidelsInitialVelocity[i], 0);
                    m_DreidelsInitialRotation[i] = dreidel.Rotations.Y;
               }
          }

          private void spinDreidels()
          {
               int current = 0;
               Composite3D world = (this.Game as BaseGame).World;

               foreach(Object3D component in world)
               {
                    if(component is Dreidel)
                    {
                         if (m_DreidelsDistancesToEndPoint.Count < current + 1)
                         {
                              m_DreidelsStopped.Add(false);
                              m_DreidelsInitialRotation.Add(component.Rotations.Y);
                              m_DreidelsDistancesToEndPoint.Add(generateRandomDistanceLength(current));
                              m_DreidelsInitialVelocity.Add((float)r_RandomBehavior.GetRandomDoubleNumber(10, 25));
                              component.AngularVelocity = new Vector3(0, m_DreidelsInitialVelocity[current], 0);
                         }

                         if (!m_DreidelsStopped[current])
                         {
                              if (component.AngularVelocity.Y <= 0.2f)
                              {
                                   if (component.Rotations.Y >= m_DreidelsInitialRotation[current] + m_DreidelsDistancesToEndPoint[current])
                                   {
                                        component.AngularVelocity = Vector3.Zero;
                                        m_DreidelStoppedCount++;
                                        m_DreidelsStopped[current] = true;
                                   }
                              }
                              else
                              {
                                   float percentageToDecrease = 1 - ((component.Rotations.Y - m_DreidelsInitialRotation[current]) / m_DreidelsDistancesToEndPoint[current]);
                                   component.AngularVelocity = new Vector3(0, m_DreidelsInitialVelocity[current] * percentageToDecrease, 0);
                              }
                         }

                         current++;
                    }
               }
          }

          private float generateRandomDistanceLength(int i_CurrentDreidel)
          {
               Object3D dreidel = (this.Game as BaseGame).World[i_CurrentDreidel];
               float offsetFromZeroRadians = dreidel.Rotations.Y % MathHelper.TwoPi;
               float circlesCount = MathHelper.TwoPi * r_RandomBehavior.GetRandomIntegerNumber(3, 7);
               float rotationsToLetter = MathHelper.PiOver2 * (4 - (float)r_DreidelsRandomLetters[i_CurrentDreidel]);

               return rotationsToLetter - offsetFromZeroRadians + circlesCount;
          }

          private void takeBet()
          {
               if (r_InputManager.KeyPressed(Keys.B))
               {
                    m_Bet = eDreidelLetter.N;
                    m_BetStr = "נ";
               }

               if (r_InputManager.KeyPressed(Keys.D))
               {
                    m_Bet = eDreidelLetter.G;
                    m_BetStr = "ג";
               }

               if (r_InputManager.KeyPressed(Keys.V))
               {
                    m_BetStr = "ה";
                    m_Bet = eDreidelLetter.H;
               }

               if (r_InputManager.KeyPressed(Keys.P))
               {
                    m_BetStr = "פ";
                    m_Bet = eDreidelLetter.P;
               }

               if(r_InputManager.KeyPressed(Keys.Space))
               {
                    if (m_Bet != eDreidelLetter.None)
                    {
                         chooseRandomLetters();
                         restartSpin();
                         m_TakeBet = false;
                         m_IsSpinning = true;
                    }
               }
          }
     }
}

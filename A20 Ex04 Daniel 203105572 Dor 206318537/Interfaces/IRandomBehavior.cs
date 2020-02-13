using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A20_Ex04_Daniel_203105572_Dor_206318537.Interfaces
{
     public interface IRandomBehavior
     {
          bool Roll();

          bool Roll(int i_RandomFactor, int i_RandomMin, int i_RandomMax);

          Action DelayedAction { get; set; }

          void TryInvokeDelayedAction();

          int GetRandomIntegerNumber(int i_Min, int i_Max);

          TimeSpan GetRandomIntervalMilliseconds(int i_MillisecondsMaxVal);

          TimeSpan GetRandomIntervalSeconds(int i_SecondsMaxVal);

          Vector3 GenerateRandomVector3();

          double GetRandomDoubleNumber(int i_Min, int i_Max);
     }
}

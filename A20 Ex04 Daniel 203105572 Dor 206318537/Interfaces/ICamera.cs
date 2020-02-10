using Microsoft.Xna.Framework;

namespace A20_Ex04_Daniel_203105572_Dor_206318537.Interfaces
{
     public interface ICamera
     {
          Matrix ViewMatrix { get; }

          Matrix FieldOfView { get; set; }

          Vector3 Position { get; set; }

          Vector3 TargetPosition { get; set; }
     }
}
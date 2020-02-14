using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using A20_Ex04_Daniel_203105572_Dor_206318537.Interfaces;
using A20_Ex04_Daniel_203105572_Dor_206318537.Managers;
using A20_Ex04_Daniel_203105572_Dor_206318537.Models;
using A20_Ex04_Daniel_203105572_Dor_206318537.Utils;

namespace A20_Ex04_Daniel_203105572_Dor_206318537
{
     public class GameDradleSpin : BaseGame
     {
          private readonly IRandomBehavior r_RandomBehavior;

          public GameDradleSpin()
          {
               Content.RootDirectory = "Content";
               r_RandomBehavior = this.Services.GetService(typeof(IRandomBehavior)) as IRandomBehavior;
               GameManager r_GameManager = new GameManager(this);
          }

          protected override void Initialize()
          {
               Camera.Position = new Vector3(0, 0, 50);
               Camera.TargetPosition = new Vector3(0, 0, 0);

               World.AddComponent(new ColorDreidel(this, 1));
               World[0].Position = r_RandomBehavior.GenerateRandomVector3();

               World.AddComponent(new ColorDreidel(this, 1));
               World[1].Position = r_RandomBehavior.GenerateRandomVector3();

               World.AddComponent(new TextureDreidel(this, 1));
               World[2].Position = r_RandomBehavior.GenerateRandomVector3();

               World.AddComponent(new TextureDreidel(this, 1));
               World[3].Position = r_RandomBehavior.GenerateRandomVector3();

               World.AddComponent(new BufferAndIndexDreidel(this, 1));
               World[4].Position = r_RandomBehavior.GenerateRandomVector3();

               World.AddComponent(new BufferAndIndexDreidel(this, 1));
               World[5].Position = r_RandomBehavior.GenerateRandomVector3();

               base.Initialize();
          }

          protected override void Update(GameTime i_GameTime)
          {
               if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
               {
                    Exit();
               }

               base.Update(i_GameTime);
          }

          protected override void Draw(GameTime gameTime)
          {
               GraphicsDevice.Clear(Color.CornflowerBlue);

               base.Draw(gameTime);
          }
     }
}

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace AN
{
    public class Camera
    {
        public static Vector2 Position;

        public static float Zoom;

        public static float Rotation;

        public static Vector2 Origin;

        private static bool UpdateMatrix;

        public static float CameraSpeed;

        public static float MaxZoom { get; set; }

        public static float MinZoom { get; set; }

        public static Rectangle Viewport { get; set; }

        public static Rectangle WorldRect { get; set; }

        public static Matrix Transform = Matrix.Identity;

        public static float MaxWorldScale;
        
        public static float MinWorldScale;



        public Camera() {
            Initialize();
        }

        public static void Initialize()
        {

            MaxWorldScale = .6f;

            MinWorldScale = 2f;

            CameraSpeed = 4f;

            Rotation = 0.0f;

            Position = new Vector2(0, 0);

            ZoomBy(1f);

            Origin = new Vector2(Viewport.Width / 2, Viewport.Height / 2);

        }

        public static void ZoomBy(float amount)
        {

            Zoom += amount;

            Zoom = MathHelper.Clamp(Zoom, MaxZoom, MinZoom);

            UpdateMatrix = true;

        }

        public static void Update(KeyboardState current)           
        {

            if (current.IsKeyDown(Keys.Left))

{

                Position += new Vector2(-CameraSpeed, 0);

                UpdateMatrix = true;

}

            if (current.IsKeyDown(Keys.Right))

{

                Position += new Vector2(CameraSpeed, 0);

                UpdateMatrix = true;

}

            if (current.IsKeyDown(Keys.Up))

{

                Position += new Vector2(0, -CameraSpeed);

                UpdateMatrix = true;

}

            if (current.IsKeyDown(Keys.Down))

{

                Position += new Vector2(0, CameraSpeed);

                UpdateMatrix = true;

}
            /*
            if (newState.IsKeyDown(Keys.W))

                Zoom(0.03f);

            if (newState.IsKeyDown(Keys.S))

                Zoom(-0.03f);
            */
            if (current.IsKeyDown(Keys.D))

{

                Rotation += MathHelper.ToRadians(1);

                UpdateMatrix = true;

}

            if (current.IsKeyDown(Keys.A))

{

                Rotation -= MathHelper.ToRadians(1);

                UpdateMatrix = true;

}

            if (Position.X < Viewport.Left / Zoom)

                Position.X = Viewport.Left / Zoom;

            if (Position.Y < Viewport.Top / Zoom)

                Position.Y = Viewport.Top / Zoom;
   
   
            if (Position.X > WorldRect.Width - Viewport.Right / Zoom)

                Position.X = WorldRect.Width - Viewport.Right / Zoom;

            if (Position.Y > WorldRect.Height - Viewport.Bottom / Zoom)

                Position.Y = WorldRect.Height - Viewport.Bottom / Zoom;

        }

        public static Matrix TransformMatrix()

        {

            if (UpdateMatrix)

{

            Transform = Matrix.CreateTranslation(new Vector3(-Position, 0)) *

                        Matrix.CreateRotationZ(Rotation) *

                        Matrix.CreateScale(new Vector3(Zoom, Zoom, 1)) *

                        Matrix.CreateTranslation(new Vector3(Origin, 0));

             UpdateMatrix = false;

}

                       return Transform;

        }

    }

}
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MoshiRendering.Animation;
using BonerRun.Core;
namespace BonerRun
{
    public class Player : AnimatedGameObject
    {



        private const float runningSpeed = 5.5f;
        private const float gravity = 0.55f;
        private const float jumpSpeed = 20;

        public Rectangle hitbox
        {
            get { return new Rectangle((int)position.X, (int)position.Y, (int)getcurrentAnimation().size.X, (int)getcurrentAnimation().size.Y); }
        }


        Vector2 velocity;

        bool inJump;


        public Player(GameManager parentManager):base(parentManager)
        {

            parent = parentManager.renderCore;


            layer = 2;
            camAffected = true;

            spriteSheet = parentManager.game.Content.Load<Texture2D>("Graphic/Player/Player");


            animations.Add(new Animation(this,11,new Vector2(96,96),true,Vector2.Zero,9));
        }


        public void Jump()
        {
            if (!inJump)
            {
                inJump = true;
                velocity = new Vector2(0, -jumpSpeed);
            }
        }

        public void ShortHop()
        {
            if (!inJump)
            {
                inJump = true;
                velocity = new Vector2(0, -jumpSpeed/2);
            }
        }


        public void Update()
        {
            position = new Vector2(position.X + runningSpeed, position.Y);

            if (inJump)
            {
                velocity = new Vector2(velocity.X, velocity.Y + gravity);
                if (Feed() > parent.settings.screensize.Y)
                {
                    inJump = false;
                    position = new Vector2(position.X, parent.settings.screensize.Y - getcurrentAnimation().size.Y);
                    velocity = new Vector2(velocity.X, 0);
                }

            }


            position += velocity;
        }


        public void Reset()
        {
            inJump = false;
            velocity = Vector2.Zero;
        }

        public override void render()
        {
            parent.renderer.renderAnimation(this, SpriteEffects.FlipHorizontally);
        }


        private int Feed()
        {
            return (int)position.Y + (int)getcurrentAnimation().size.Y;
        }

    }
}
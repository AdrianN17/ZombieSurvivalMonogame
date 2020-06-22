using System;
using System.Collections.Generic;
using System.Threading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Nez;
using Nez.PhysicsShapes;
using Nez.Sprites;
using Nez.Textures;
using Nez.Timers;
using ZombieSurvival.CustomLibs;

namespace Entidades
{
    public class Personaje : Component, IUpdatable, ITriggerListener
    {
        //variables
        public int _hp = 10;
        public float _velocidad = 200;
        public int _indexBala = 0;


        //variables monogame-nez
        public SpriteAnimator _animator;

        public CircleCollider _circleCollider;

        public VirtualIntegerAxis _xAxisInput;
        public VirtualIntegerAxis _yAxisInput;
        public VirtualButton _fireInput;
        public VirtualButton _runInput;

        public VirtualButton _weapon1Input;
        public VirtualButton _weapon2Input;
        public VirtualButton _weapon3Input;

        public Mover _mover;

        SubpixelVector2 _subpixelV2 = new SubpixelVector2();


        //variables auxiliares - funciones

        public Arma _arma;


        



        public override void OnAddedToEntity()
        {
            var texture = Entity.Scene.Content.Load<Texture2D>("sprites");

            var sprites = crearSprites(texture);

            _animator = Entity.AddComponent(new SpriteAnimator(sprites[0]));

            _animator.AddAnimation("none", new[]
            {
                sprites[0]
            });

            _animator.AddAnimation("correr", new[]
            {
                sprites[1]
            });

            _animator.AddAnimation("arma1", new[]
            {
                sprites[2]
            });

            _animator.AddAnimation("arma2", new[]
            {
                sprites[3]
            });

            _animator.AddAnimation("arma3", new[]
            {
                sprites[4]
            });

            _animator.AddAnimation("recarga", new[]
            {
                sprites[5]
            });


            _circleCollider = Entity.AddComponent(new CircleCollider(15));

            _mover = Entity.AddComponent(new Mover());


            Controles();

            _arma = new Arma(Entity);


            

        }

        public override void OnRemovedFromEntity()
        {
            _xAxisInput.Deregister();
            _yAxisInput.Deregister();
            _fireInput.Deregister();
            _fireInput.Deregister();

            _weapon1Input.Deregister();
            _weapon2Input.Deregister();
            _weapon3Input.Deregister();
        }

        void Controles()
        {
            _xAxisInput = new VirtualIntegerAxis();
            _xAxisInput.AddKeyboardKeys(VirtualInput.OverlapBehavior.TakeNewer, Keys.A, Keys.D);

            _yAxisInput = new VirtualIntegerAxis();
            _yAxisInput.AddKeyboardKeys(VirtualInput.OverlapBehavior.TakeNewer, Keys.W, Keys.S);

            _fireInput = new VirtualButton();
            _fireInput.AddMouseLeftButton();

            _runInput = new VirtualButton();
            _runInput.AddKeyboardKey(Keys.Space);

            _weapon1Input = new VirtualButton();
            _weapon1Input.AddKeyboardKey(Keys.D1);
            _weapon2Input = new VirtualButton();
            _weapon2Input.AddKeyboardKey(Keys.D2);
            _weapon3Input = new VirtualButton();
            _weapon3Input.AddKeyboardKey(Keys.D3);



        }

        public List<Sprite> crearSprites(Texture2D textura)
        {
            var sprites = new List<Sprite>();

            //stand
            sprites.Add(new Sprite(textura,
                        new Rectangle(251, 0, 33, 43)));

            //hold
            sprites.Add(new Sprite(textura,
                        new Rectangle(211, 0, 35, 43)));

            //gun
            sprites.Add(new Sprite(textura,
                        new Rectangle(59, 0, 49, 43)));
            //machine
            sprites.Add(new Sprite(textura,
                        new Rectangle(113, 0, 49, 43)));
            //silencer
            sprites.Add(new Sprite(textura,
                        new Rectangle(0, 0, 54, 43)));
            //reload
            sprites.Add(new Sprite(textura,
                        new Rectangle(167, 0, 39, 43)));



            return sprites;
        }

        public void Update()
        {
            var dt = Time.DeltaTime;

            _arma.Update(dt);

            var moveVec = new Vector2(_xAxisInput.Value, _yAxisInput.Value);

            var movement = _velocidad * moveVec * dt;

            var mousePos = Entity.Scene.Camera.MouseToWorldPoint();


            var center = Transform.Position;
            var angle = (float)Math.Atan2(mousePos.Y - center.Y, mousePos.X - center.X);

            Transform.Rotation = angle;



            cambiarArmas();
            crearBala();
            animaciones(moveVec);


            _mover.CalculateMovement(ref movement, out var res);
            
            if(res.Collider!=null)
            {
                Console.WriteLine(res.Collider.Entity.Name);
            }

            _subpixelV2.Update(ref movement);
            _mover.ApplyMovement(movement);

        }

        public void animaciones(Vector2 movimiento)
        {


            if(movimiento == Vector2.Zero)
            {
                _animator.Play("none");
            }
            else
            {
                _animator.Play("correr");
            }
            
            if (_fireInput.IsDown)
            {
                _animator.Play("arma"+ (_indexBala + 1));
            }
        }

        public void cambiarArmas()
        {
            if(_weapon1Input.IsPressed)
            {
                _arma.stopShoot();
                _indexBala = 0;
            }
            else if (_weapon2Input.IsPressed)
            {
                _arma.stopShoot();
                _indexBala = 1;
            }
            else if (_weapon3Input.IsPressed)
            {
                _arma.stopShoot();
                _indexBala = 2;
            }
        }

        public void crearBala()
        {
            if (_fireInput.IsPressed)
            {
                _arma.shoot(_indexBala);
            }
            else if (_fireInput.IsReleased)
            {
                _arma.stopShoot();
            }
        }

    
        void ITriggerListener.OnTriggerEnter(Collider other, Collider local)
        {
            Console.WriteLine("OnTriggerEnter: {0}", other.Entity.Name);
        }

        void ITriggerListener.OnTriggerExit(Collider other, Collider local)
        {
            Console.WriteLine("OnTriggerExit: {0}", other.Entity.Name);
        }




    }
}
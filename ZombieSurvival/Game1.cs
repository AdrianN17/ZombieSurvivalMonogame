using Entidades;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Nez;
using Nez.PhysicsShapes;
using Nez.Tiled;
using System;
using ZombieSurvival.CustomLibs;
using static Nez.Scene;

namespace ZombieSurvival
{

    public class Game1 : Core
    {
        Entity player;

        public Game1()
        {
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            base.Initialize();

            
            Scene myScene = Scene.CreateWithDefaultRenderer(Color.Black);

            myScene.SetDesignResolution(320, 320, SceneResolutionPolicy.ShowAllPixelPerfect);
            Screen.SetSize(320 * 3, 320 * 3);

            //tilemap

            var tiledEntity = myScene.CreateEntity("tilemap");
            var map = Content.LoadTiledMap("Content/tiled/mapa.tmx");
            var tiledMapRenderer = tiledEntity.AddComponent(new TiledMapRenderer(map));
            tiledMapRenderer.SetLayersToRender(new[] { "Base"});

            tiledMapRenderer.RenderLayer = 10;

            var objectGroup = map.GetObjectGroup("Colisiones");

            var defaultCollidable = myScene.CreateEntity("DefaultCollidable");
            ObjectGroup.LeerTmx(objectGroup, defaultCollidable);

            //camara

            var topLeft = new Vector2(map.TileWidth, map.TileWidth);
            var bottomRight = new Vector2(map.TileWidth * (map.Width - 1),
                map.TileWidth * (map.Height - 1));
            tiledEntity.AddComponent(new CameraBounds(topLeft, bottomRight));


            //player

            player = myScene.CreateEntity("Player", new Vector2(100, 100));
            player.AddComponent(new Personaje());
            myScene.Camera.Entity.AddComponent(new FollowCamera(player));

            /*var bala = myScene.CreateEntity("Bala", new Vector2(200, 100));
            bala.AddComponent(new CircleCollider(5));
            bala.AddComponent(new ProjectileMover());
            bala.AddComponent(new Proyectil());*/

            Scene = myScene;

            Core.DebugRenderEnabled = true;
            

            
        }

        protected override void LoadContent()
        {
            // TODO: use this.Content to load your game content here

        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /*protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            

            base.Update(gameTime);

        }*/

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.LightGreen);
            // TODO: Add your drawing code here
            
            base.Draw(gameTime);
        }
    }

}
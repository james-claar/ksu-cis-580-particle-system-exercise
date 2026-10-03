using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ParticleSystemExercise;

public class ParticleSystemExampleGame : Game, IParticleEmitter
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    MouseState _priorMouseState;
    ExplosionParticleSystem _explosions;
    FireworkParticleSystem _fireworks;

    public Vector2 Position { get; set; }
    public Vector2 Velocity { get; set; }

    public ParticleSystemExampleGame()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        RainParticleSystem rain = new RainParticleSystem(this, new Rectangle(100, -20, 500, 10));
        Components.Add(rain);

        _explosions = new ExplosionParticleSystem(this, 20);
        Components.Add(_explosions);

        _fireworks = new FireworkParticleSystem(this, 20);
        Components.Add(_fireworks);

        PixieParticleSystem pixie = new PixieParticleSystem(this, this);
        Components.Add(pixie);

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here
        MouseState currentMouse = Mouse.GetState();
        Vector2 mousePosition = new Vector2(currentMouse.X, currentMouse.Y);

        if(currentMouse.LeftButton == ButtonState.Pressed && _priorMouseState.LeftButton == ButtonState.Released)
        {
            _explosions.PlaceExplosion(mousePosition);
        }

        if(currentMouse.RightButton == ButtonState.Pressed && _priorMouseState.RightButton == ButtonState.Released)
        {
            _fireworks.PlaceFirework(mousePosition);
        }

        Velocity = mousePosition - Position;
        Position = mousePosition;

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Black);

        // TODO: Add your drawing code here

        base.Draw(gameTime);
    }
}

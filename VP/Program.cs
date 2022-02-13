using System;
using System.Numerics;
using Raylib_cs;

Raylib.InitWindow(1024, 768, "Game");
Raylib.SetTargetFPS(60);

Texture2D playerTexture = Raylib.LoadTexture("Player.png");
Rectangle player = new Rectangle(256, 192, playerTexture.width, playerTexture.height);
Texture2D goblinTexture = Raylib.LoadTexture("Goblin.png");
Rectangle goblin = new Rectangle(512, 384, goblinTexture.width, goblinTexture.height);
Texture2D snakeTexture = Raylib.LoadTexture("Snake.png");
Rectangle snake = new Rectangle(768, 300, snakeTexture.width, snakeTexture.height);

bool menu = true;
bool fightSelect = false;
Random generator = new Random();

bool goblinFight = false;
int goblinHP = 100;
int goblinATK = generator.Next(10, 25);

float speed = 3f;
Vector2 movement = new Vector2();

Rectangle Start = new Rectangle(100, 20, 100, 20);

while (!Raylib.WindowShouldClose())
{
    if (menu == true)
    {
        Raylib.BeginDrawing();
        Raylib.ClearBackground(Color.WHITE);
        Raylib.DrawRectangle(256, 192, 500, 100, Color.BLACK);
        if (Raylib.IsKeyDown(KeyboardKey.KEY_ENTER))
        {
            menu = false;
            fightSelect = true;
        }

        Raylib.EndDrawing();
    }

    if (fightSelect == true)
    {
        Raylib.BeginDrawing();


        Raylib.ClearBackground(Color.WHITE);
        Raylib.DrawTexture(playerTexture, (int)player.x, (int)player.y, Color.WHITE);

        movement = ReadMovement(speed);
        player.x += movement.X;
        player.y += movement.Y;


        Raylib.DrawTexture(goblinTexture, 512, 384, Color.WHITE);
        Raylib.DrawTexture(snakeTexture, 768, 300, Color.WHITE);

        Raylib.EndDrawing();
    }

    if (fightSelect == true)
    {
        if (Raylib.CheckCollisionRecs(player, goblin))
        {
            fightSelect = false;
            goblinFight = true;
        }
        if (Raylib.CheckCollisionRecs(player, snake))
        {
            fightSelect = false;
            snakeFight = true;
        }
    }

    
    
    if (goblinFight == true)
    {
        Raylib.BeginDrawing();

        Raylib.ClearBackground(Color.DARKBROWN);
        Raylib.DrawTexture(goblinTexture, 768, 192, Color.WHITE);
        Raylib.DrawRectangle(64, 512, 896, 256, Color.GRAY);
        Raylib.DrawText(goblinHP.ToString(), 768, 255, 40, Color.BLACK);

        Raylib.EndDrawing();
    }



    static Vector2 ReadMovement(float speed)
    {
        Vector2 movement = new Vector2();

        if (Raylib.IsKeyDown(KeyboardKey.KEY_W)) movement.Y = -speed;
        if (Raylib.IsKeyDown(KeyboardKey.KEY_S)) movement.Y = speed;
        if (Raylib.IsKeyDown(KeyboardKey.KEY_A)) movement.X = -speed;
        if (Raylib.IsKeyDown(KeyboardKey.KEY_D)) movement.X = speed;

        return movement;
    }

}

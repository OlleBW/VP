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

Vector2 movement = new Vector2();
string MenuText = "Press ENTER To Start";
string Heal = "Press ENTER to Heal";
string EnterToFight = "Press ENTER For Fight Options";
string Abilities = "Press S For Skills and Abilities";
string gobHPleft = "The goblins HP is now ";
string gobHPleft2 = "Press C To Continue";
string playerHPleft = "Your HP is now ";
string playerHPleft2 = "Press ENTER To Continue";
Rectangle Start = new Rectangle(100, 20, 100, 20);
Random generator = new Random();
int playerHP = 100;
int playerATK = generator.Next(10, 50);
int goblinHP = 100;
int goblinATK = generator.Next(10, 25);
float speed = 3f;
bool Skills = false;
bool menu = true;
bool gobFight = false;
bool fightSelect = false;
bool FightOptions = false;
bool Fight = false;
bool playerTurn = false;
bool gobTurn = false;

while (!Raylib.WindowShouldClose())
{
    if (menu == true)
    {
        Raylib.BeginDrawing();
        Raylib.ClearBackground(Color.WHITE);
        Raylib.DrawRectangle(256, 192, 500, 100, Color.BLACK);
        Raylib.DrawText(MenuText, 256, 192, 44, Color.WHITE);
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
        if (Raylib.CheckCollisionRecs(player, goblin))
        {
            Fight = true;
            fightSelect = false;
            gobFight = true;
        }
    }

    while (Fight == true)
    {
        if (gobFight == true)
        {
            playerTurn = true;
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.DARKBROWN);
            Raylib.DrawTexture(goblinTexture, 768, 192, Color.WHITE);
            Raylib.DrawRectangle(64, 512, 896, 256, Color.GRAY);
            Raylib.DrawText(goblinHP.ToString(), 768, 255, 40, Color.BLACK);

            Raylib.DrawText(EnterToFight, 68, 512, 25, Color.BLACK);
            Raylib.DrawText(Abilities, 68, 640, 25, Color.BLACK);
            Raylib.EndDrawing();
            if (Raylib.IsKeyPressed(KeyboardKey.KEY_ENTER))
            {
                gobFight = false;
                FightOptions = true;
            }
        }

        if (FightOptions == true)
        {
            if (playerTurn == true && Raylib.IsKeyPressed(KeyboardKey.KEY_ENTER))
            {
                playerTurn = false;
                goblinHP = goblinHP - playerATK;

                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.DARKBROWN);
                Raylib.DrawTexture(goblinTexture, 768, 192, Color.WHITE);
                Raylib.DrawRectangle(64, 512, 896, 256, Color.GRAY);
                Raylib.DrawText(goblinHP.ToString(), 768, 255, 40, Color.BLACK);

                Raylib.DrawText(gobHPleft + goblinHP.ToString(), 68, 512, 25, Color.BLACK);
                Raylib.DrawText(gobHPleft2, 68, 542, 25, Color.BLACK);
                Raylib.EndDrawing();

                gobTurn = true;
            }

            if (Raylib.IsKeyPressed(KeyboardKey.KEY_C) && gobTurn == true)
            {
                playerHP = playerHP - goblinATK;

                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.DARKBROWN);
                Raylib.DrawTexture(goblinTexture, 768, 192, Color.WHITE);
                Raylib.DrawRectangle(64, 512, 896, 256, Color.GRAY);
                Raylib.DrawText(goblinHP.ToString(), 768, 255, 40, Color.BLACK);

                Raylib.DrawText(playerHPleft + playerHP.ToString(), 68, 512, 25, Color.BLACK);
                Raylib.DrawText(playerHPleft2, 68, 542, 25, Color.BLACK);
                Raylib.EndDrawing();

                gobFight = true;
            }
        }
        if (Skills == true)
        {
            Raylib.BeginDrawing();

            Raylib.ClearBackground(Color.DARKBROWN);
            Raylib.DrawTexture(goblinTexture, 768, 192, Color.WHITE);
            Raylib.DrawRectangle(64, 512, 896, 256, Color.GRAY);
            Raylib.DrawText(goblinHP.ToString(), 768, 255, 40, Color.BLACK);
            Raylib.DrawText(Heal, 68, 512, 25, Color.BLACK);


            Raylib.EndDrawing();
        }
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
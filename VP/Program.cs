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

Rectangle Start = new Rectangle(100, 20, 100, 20);

Random generator = new Random();

Vector2 movement = new Vector2();
string menuText = "Press ENTER To Start";
string heal = "Press ENTER to Heal";
string enterToFight = "Press ENTER For Fight Options";
string enterToAttack = "Press ENTER for normal Attack";
string abilitiesTxt = "Press S For Skills and Abilities";
string gobHPleft = "The goblins HP is now ";
string pressEnter = "Press ENTER To Continue";
string playerHPleft = "Your HP is now ";
string HP = "HP: ";

string died = "You Died! Press ENTER to retry";
string victory = "You Won! Press ENTER to continue";

float speed = 3f;
int playerHP = 100;
int playerATK = generator.Next(10, 50);
int goblinHP = 100;
int goblinATK = generator.Next(10, 25);
bool skills = false;
bool menu = true;
bool gobFight = false;
bool fightSelect = false;
bool startOptions = true;
bool fightOptions = false;
bool playerTurn = true;
bool gobTurn = false;
bool gobTurn2 = false;

while (!Raylib.WindowShouldClose())
{
    if (menu == true)
    {
        Raylib.BeginDrawing();
        Raylib.ClearBackground(Color.WHITE);
        Raylib.DrawRectangle(256, 192, 500, 100, Color.BLACK);
        Raylib.DrawText(menuText, 256, 192, 40, Color.WHITE);
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
        Raylib.DrawText(HP + playerHP, 40, 40, 40, Color.BLACK);
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
            fightSelect = false;
            gobFight = true;
        }
    }

    if (gobFight == true)
    {
        if (playerTurn == true)
        {
            Raylib.BeginDrawing();
            if (startOptions == true)
            {
                Raylib.DrawText(HP + playerHP, 40, 40, 40, Color.BLACK);
                Raylib.ClearBackground(Color.DARKBROWN);
                Raylib.DrawTexture(goblinTexture, 768, 192, Color.WHITE);
                Raylib.DrawRectangle(64, 512, 896, 256, Color.GRAY);
                Raylib.DrawText(goblinHP.ToString(), 768, 255, 40, Color.BLACK);

                Raylib.DrawText(enterToFight, 68, 512, 25, Color.BLACK);
                Raylib.DrawText(abilitiesTxt, 68, 640, 25, Color.BLACK);
                if (Raylib.IsKeyPressed(KeyboardKey.KEY_ENTER))
                {
                    startOptions = false;
                    fightOptions = true;
                }
                if (Raylib.IsKeyPressed(KeyboardKey.KEY_S))
                {
                    startOptions = false;
                    skills = true;
                }
                Raylib.EndDrawing();
            }
            if (fightOptions == true)
            {
                Raylib.DrawText(HP + playerHP, 40, 40, 40, Color.BLACK);
                Raylib.ClearBackground(Color.DARKBROWN);
                Raylib.DrawTexture(goblinTexture, 768, 192, Color.WHITE);
                Raylib.DrawRectangle(64, 512, 896, 256, Color.GRAY);
                Raylib.DrawText(goblinHP.ToString(), 768, 255, 40, Color.BLACK);
                Raylib.DrawText(enterToAttack, 68, 512, 25, Color.BLACK);
                if (Raylib.IsKeyPressed(KeyboardKey.KEY_ENTER))
                {
                    fightOptions = false;
                    playerTurn = false;
                    goblinHP = goblinHP - playerATK;

                    gobTurn = true;
                }
                Raylib.EndDrawing();
            }
            if (skills == true)
            {
                Raylib.DrawText(HP + playerHP, 40, 40, 40, Color.BLACK);
                Raylib.ClearBackground(Color.DARKBROWN);
                Raylib.DrawTexture(goblinTexture, 768, 192, Color.WHITE);
                Raylib.DrawRectangle(64, 512, 896, 256, Color.GRAY);
                Raylib.DrawText(goblinHP.ToString(), 768, 255, 40, Color.BLACK);
                Raylib.DrawText(heal, 68, 512, 25, Color.BLACK);

                Raylib.EndDrawing();
            }
        }

        if (gobTurn == true)
        {
            Raylib.BeginDrawing();

            Raylib.DrawText(HP + playerHP, 40, 40, 40, Color.BLACK);
            Raylib.ClearBackground(Color.DARKBROWN);
            Raylib.DrawTexture(goblinTexture, 768, 192, Color.WHITE);
            Raylib.DrawRectangle(64, 512, 896, 256, Color.GRAY);
            Raylib.DrawText(goblinHP.ToString(), 768, 255, 40, Color.BLACK);

            Raylib.DrawText(gobHPleft + goblinHP.ToString(), 68, 512, 25, Color.BLACK);
            Raylib.DrawText(pressEnter, 68, 542, 25, Color.BLACK);

            if (Raylib.IsKeyPressed(KeyboardKey.KEY_ENTER))
            {
                playerHP = playerHP - goblinATK;
                gobTurn = false;
                gobTurn2 = true;
            }

            Raylib.EndDrawing();
        }
        if (gobTurn2 == true)
        {
            Raylib.BeginDrawing();

            Raylib.DrawText(HP + playerHP, 40, 40, 40, Color.BLACK);
            Raylib.ClearBackground(Color.DARKBROWN);
            Raylib.DrawTexture(goblinTexture, 768, 192, Color.WHITE);
            Raylib.DrawRectangle(64, 512, 896, 256, Color.GRAY);
            Raylib.DrawText(goblinHP.ToString(), 768, 255, 40, Color.BLACK);

            Raylib.DrawText(playerHPleft + playerHP.ToString(), 68, 512, 25, Color.BLACK);
            Raylib.DrawText(pressEnter, 68, 542, 25, Color.BLACK);

            if (Raylib.IsKeyPressed(KeyboardKey.KEY_ENTER))
            {
                gobTurn2 = false;
                playerTurn = true;
            }

            Raylib.EndDrawing();
        }


        if (playerHP <= 0)
        {
            Raylib.ClearBackground(Color.WHITE);
            Raylib.DrawText(died, 256, 192, 40, Color.BLACK);
            gobFight = false;
        }
        if (goblinHP <= 0)
        {
            Raylib.ClearBackground(Color.WHITE);
            Raylib.DrawText(victory, 256, 192, 40, Color.BLACK);
            gobFight = false;
        }
    }

    // if fightnow == true
    // if din turn
    // kolla om vi är i anfallsläge
    // kolla om trycker på attack-knapp
    // gör skada
    // Ändra vems tur det är

    // kolla om vi trycker på skills-knapp
    // ändra till skills-läge
    // kolla om vi är i skills-läge
    // Visa skills
    // Kolla om vi trycker på skills-knapp
    // Använd skill
    // Ändra vems tur det är
    // Kolla om vi trycker på anfallsknapp
    // ändra till anfallsläge

    // om fiendens tur
    // timer?
    // gör skada
    // ändra vems tur det är
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
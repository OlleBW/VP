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



room currentRoom = room.menu;
menus currentMenu = menus.start;
turn turn = turn.player;


while (!Raylib.WindowShouldClose())
{
    if (currentRoom == room.menu)
    {
        Raylib.BeginDrawing();
        Raylib.ClearBackground(Color.WHITE);
        Raylib.DrawRectangle(256, 192, 500, 100, Color.BLACK);
        Raylib.DrawText(menuText, 256, 192, 40, Color.WHITE);
        if (Raylib.IsKeyDown(KeyboardKey.KEY_ENTER))
        {
            currentRoom = room.fightselect;
        }
        Raylib.EndDrawing();
    }

    if (currentRoom == room.fightselect)
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
            currentRoom = room.fight;
        }
    }

    if (currentRoom == room.fight)
    {
        if (turn == turn.player)
        {
            Raylib.BeginDrawing();
            if (currentMenu == menus.start)
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
                    currentMenu = menus.atk;
                }
                if (Raylib.IsKeyPressed(KeyboardKey.KEY_S))
                {
                    currentMenu = menus.skills;
                }
                Raylib.EndDrawing();
            }
            if (currentMenu == menus.atk)
            {
                Raylib.DrawText(HP + playerHP, 40, 40, 40, Color.BLACK);
                Raylib.ClearBackground(Color.DARKBROWN);
                Raylib.DrawTexture(goblinTexture, 768, 192, Color.WHITE);
                Raylib.DrawRectangle(64, 512, 896, 256, Color.GRAY);
                Raylib.DrawText(goblinHP.ToString(), 768, 255, 40, Color.BLACK);
                Raylib.DrawText(enterToAttack, 68, 512, 25, Color.BLACK);
                if (Raylib.IsKeyPressed(KeyboardKey.KEY_ENTER))
                {
                    goblinHP = goblinHP - playerATK;
                    turn = turn.goblin;
                }
                Raylib.EndDrawing();
            }
            if (currentMenu == menus.skills)
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
        if (turn == turn.goblin)
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
                if (goblinHP <= 0)
                {
                    currentRoom = room.fightend;
                }
                else if (goblinHP >= 0)
                {
                    turn = turn.goblinResult;
                }
            }

            Raylib.EndDrawing();
        }
        if (turn == turn.goblinResult)
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
                if (playerHP <= 0)
                {
                    currentRoom = room.fightend;
                }
                else if (playerHP >= 0)
                {
                    turn = turn.player;
                    currentMenu = menus.start;
                }
            }
            Raylib.EndDrawing();
        }

        if (playerHP <= 0 || goblinHP <= 0)
        {
            playerHP = 0;
            goblinHP = 0;
            currentRoom = room.fightend;
        }
    }

    else if (currentRoom == room.fightend)
    {
        Raylib.BeginDrawing();

        if (playerHP <= 0)
        {
            Raylib.ClearBackground(Color.WHITE);
            Raylib.DrawText(died, 256, 192, 40, Color.BLACK);
            if (Raylib.IsKeyPressed(KeyboardKey.KEY_ENTER))
            {
                playerHP = 100;
                goblinHP = 100;
                currentRoom = room.fight;
            }
        }
        if (goblinHP <= 0)
        {
            Raylib.ClearBackground(Color.WHITE);
            Raylib.DrawText(victory, 256, 192, 40, Color.BLACK);
            if (Raylib.IsKeyPressed(KeyboardKey.KEY_ENTER))
            {
                playerHP = 100;
                currentRoom = room.fightselect;
            }
        }
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
enum room { menu, fightselect, fight, fightend }
enum menus { start, atk, skills }
enum turn { player, goblin, goblinResult }



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
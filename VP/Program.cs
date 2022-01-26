using System;
using Raylib_cs;

Raylib.InitWindow(1024, 768, "Game");
Raylib.SetTargetFPS(60);

Texture2D playerTexture = Raylib.LoadTexture("Circle.png");
//Rectangle player = new Rectangle(100, 50, playerTexture.width, playerTexture.height);
Rectangle player = new Rectangle(100, 50, 25, 25);
bool menu = true;


Rectangle Start = new Rectangle(100, 20, 100, 20);

while (!Raylib.WindowShouldClose())
{
    if(menu == true)
    {
    Raylib.BeginDrawing();
    Raylib.ClearBackground(Color.WHITE);
    Raylib.DrawRectangle(256, 192, 500, 100, Color.BLACK);
    if(Raylib.IsKeyDown(KeyboardKey.KEY_ENTER))
    {
        menu = false;
    }

    Raylib.EndDrawing();
    }
   
    if(menu != true)
    {
    Raylib.BeginDrawing();
    Raylib.ClearBackground(Color.WHITE);
    Raylib.DrawTexture(playerTexture, 256, 192, Color.BLACK);

    Raylib.EndDrawing();
    }
}

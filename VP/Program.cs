using System;
using Raylib_cs;

Raylib.InitWindow(1024, 768, "Game");
Raylib.SetTargetFPS(60);

Texture2D playerTexture = Raylib.LoadTexture("Circle.png");
Rectangle player = new Rectangle(100, 50, playerTexture.width, playerTexture.height);

Rectangle Start = new Rectangle(100, 20, 100, 20);

while (!Raylib.WindowShouldClose())
{
    Raylib.BeginDrawing();
    Raylib.ClearBackground(Color.WHITE);
    Raylib.DrawTexture(playerTexture, 50, 50, Color.BLACK);

    Raylib.EndDrawing();
}
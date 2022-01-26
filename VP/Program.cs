﻿using System;
using System.Numerics;
using Raylib_cs;

Raylib.InitWindow(1024, 768, "Game");
Raylib.SetTargetFPS(60);

Texture2D playerTexture = Raylib.LoadTexture("Player.png");
Rectangle player = new Rectangle(256, 192, playerTexture.width, playerTexture.height);
bool menu = true;
float speed = 3f;
Vector2 movement = new Vector2();

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
    Raylib.DrawTexture(playerTexture, (int)player.x, (int)player.y, Color.WHITE);
    
    movement = ReadMovement(speed);

    player.x += movement.X;
    player.y += movement.Y;

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

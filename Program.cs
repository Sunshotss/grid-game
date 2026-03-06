// See https://aka.ms/new-console-template for more information

using Raylib_cs;
using System.Numerics;

class Program
{
    static void Main()
    {
        int width  = 800; 
        int height = 450; 
        int kube = 20;
        int row = width  / kube;  //40
        int col = height / kube;  //22,5
        int x = 2;
        int y = 2;

        //a = floor
        //b = wall
        //c = door
        //d = 

        char[,] map =
        {
            {'b','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','b','b','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','b' },
            {'a','a','a','a','b','b','b','b','a','a','a','a','a','a','a','a','a','a','a','a','b','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','b' },
            {'a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','b' },
            {'a','a','a','b','b','b','b','b','a','a','a','a','a','a','a','a','a','a','a','a','b','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','b' },
            {'a','a','a','b','b','b','b','b','a','a','a','a','a','a','a','a','a','a','a','a','b','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','b' },
            {'a','a','b','b','b','b','b','b','a','a','a','a','a','a','a','a','a','a','a','a','b','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','b' },
            {'a','a','b','b','b','b','b','b','a','a','a','a','a','a','a','a','a','a','a','a','b','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','b' },
            {'a','a','b','b','b','b','b','b','a','a','a','a','a','a','a','a','a','a','a','a','b','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','b' },
            {'a','a','b','b','b','b','b','b','a','a','a','a','a','a','a','a','a','a','a','a','b','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','b' },
            {'a','a','b','b','b','b','b','b','a','a','a','a','a','a','a','a','a','a','a','a','b','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','b' },
            {'a','a','b','b','b','b','b','b','a','a','a','a','a','a','a','a','a','a','a','a','b','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','b' },
            {'a','a','b','b','b','b','b','b','a','a','a','a','a','a','a','a','a','a','a','a','b','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','b' },
            {'a','a','b','b','b','b','b','b','a','a','a','a','a','a','a','a','a','a','a','a','b','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','b' },
            {'a','a','b','b','b','b','b','b','a','a','a','a','a','a','a','a','a','a','a','a','b','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','b' },
            {'a','a','b','b','b','b','b','b','a','a','a','a','a','a','a','a','a','a','a','a','b','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','b' },
            {'a','a','b','b','b','b','b','b','a','a','a','a','a','a','a','a','a','a','a','a','b','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','b' },
            {'a','a','b','b','b','b','b','b','a','a','a','a','a','a','a','a','a','a','a','a','b','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','b' },
            {'a','a','b','b','b','b','b','b','a','a','a','a','a','a','a','a','b','a','a','a','b','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','b' },
            {'a','a','a','b','b','b','b','b','a','a','a','a','a','a','a','a','b','a','a','a','b','a','a','a','a','a','a','a','a','a','a','a','b','a','a','a','a','a','a','b' },
            {'b','a','a','a','a','a','a','a','a','a','a','a','a','a','a','b','b','b','a','b','b','a','a','a','a','a','a','a','a','a','a','a','b','a','a','a','a','a','a','b' },
            {'a','a','b','b','b','b','b','b','a','a','a','a','a','a','a','a','b','a','a','a','b','a','a','a','a','a','a','a','a','a','a','a','b','a','a','a','a','a','a','b' },
            {'b','a','a','a','a','a','a','a','a','a','a','a','a','a','a','b','b','b','a','b','b','a','a','a','a','a','a','a','a','a','a','b','b','b','a','a','a','a','a','b' }
        };
        
        Color Colors(int clor)
        {
            if (clor == 0) return Color.Black;
            if (clor == 1) return Color.Gray;
            if (clor == 2) return Color.White;
            if (clor == 3) return Color.Blue;
            if (clor == 4) return Color.SkyBlue;
            if (clor == 5) return Color.Red;

            return Color.Black;
        }
        
        Raylib.InitWindow(800, 450, "game i made");

        while (!Raylib.WindowShouldClose())
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Colors(0));
            Raylib.SetTargetFPS(60);

            /*
            Vector2 mouse = Raylib.GetMousePosition();
            if (Raylib.IsMouseButtonDown(MouseButton.Left))
            {
                Raylib.DrawText($"Mouse: {mouse.X}, {mouse.Y}", 20, 90, 20, Color.Gray);
            }
            Raylib.DrawCircle(x, y, 15, Color.Blue);
            */
            
            if (Raylib.IsKeyPressed(KeyboardKey.W)) 
            {
                if (map[y - 1, x] != 'b') { y -= 1; }
            }
            if (Raylib.IsKeyPressed(KeyboardKey.A))
            {
                if (map[y, x - 1] != 'b') { x -= 1; }
            }
            if (Raylib.IsKeyPressed(KeyboardKey.S))
            {
                if (map[y + 1, x] != 'b') { y += 1; }
            }
            if (Raylib.IsKeyPressed(KeyboardKey.D))
            {
                if (map[y, x + 1] != 'b') { x += 1; }
            }



            for ( int i = 0; i <= row - 1; i++ ) 
            {
                for ( int j = 0; j <= col - 1; j++ ) 
                {
                    if (map[j,i] == 'a') 
                    {
                        Raylib.DrawRectangle(i * kube, j * kube, kube, kube, Colors(3));
                    }
                }
            }
            Raylib.DrawRectangle(x * kube, y * kube, kube, kube, Colors(4));



            Raylib.EndDrawing();
        }
        Raylib.CloseWindow();
    }
}

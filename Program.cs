// See https://aka.ms/new-console-template for more information

using Raylib_cs;
using System.Numerics;
using System.Runtime.InteropServices;

class enemy
{
    public int ex;
    public int ey;
    public int health;
    public enemy(int x, int y)
    {
        ex = x;
        ey = y;
        health = 4;
    }

}

class Program
{
    static void Main()
    {
        Random rnd = new Random();
        int width  = 1200; 
        int height = 600; 
        int kube = 15;
        int row = width  / kube;  //80
        int col = height / kube;  //40
        int x = 2;
        int y = 2;
        int fx = x;
        int fy = y;


        List<enemy> elist = new List<enemy>();

        //a = floor
        //b = wall
        //c = door
        //d = shadow
        //e = enemy
        char[,] map =
        {
            {'b','b','b','b','b','b','b','b','b','b','b','b','b','b','b','b','b','b','b','b','b','b','b','b','b','b','b','b','b','b','b','b','b','b','b','b','b','b','b','b','b','b','b','b','b','b','b','b','b','b','b','b','b','b','b','b','b','b','b','b','b','b','b','b','b','b','b','b','b','b','b','b','b','b','b','b','b','b','b','b' },
            {'b','a','a','a','a','a','a','b','a','a','a','a','a','a','b','a','a','a','a','a','a','a','a','a','b','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','b' },
            {'b','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','b','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','b' },
            {'b','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','b','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','b' },
            {'b','a','a','a','a','a','a','b','a','a','a','a','a','a','b','a','a','a','a','a','a','a','a','a','b','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','b' },
            {'b','a','a','a','a','a','a','b','a','a','a','a','a','a','b','a','a','a','a','a','a','a','a','a','b','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','b' },
            {'b','a','a','a','a','a','a','b','a','a','a','a','a','a','b','a','a','a','a','a','a','a','a','a','b','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','b' },
            {'b','a','a','a','a','a','a','b','b','a','a','a','b','b','b','b','b','b','b','a','a','a','b','b','b','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','b' },
            {'b','a','a','a','a','a','a','b','a','a','a','a','a','a','a','a','a','b','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','b' },
            {'b','a','a','a','a','a','a','b','a','a','a','a','a','a','a','a','a','b','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','b' },
            {'b','a','a','a','a','a','a','b','a','a','a','a','a','a','a','a','a','b','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','b' },
            {'b','a','a','a','a','a','a','b','a','a','a','a','a','a','a','a','a','b','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','b' },
            {'b','a','a','a','a','a','a','b','a','a','a','a','a','a','a','a','a','b','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','b' },
            {'b','a','a','a','a','a','a','b','a','a','a','a','a','a','a','a','a','b','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','b' },
            {'b','a','a','a','a','a','a','b','a','a','a','a','a','a','a','a','a','b','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','b' },
            {'b','a','a','a','a','a','a','b','a','d','d','a','a','a','a','a','a','b','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','b' },
            {'b','a','a','a','a','a','a','b','a','d','d','a','a','a','a','a','a','b','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','b' },
            {'b','a','a','a','a','a','a','b','a','d','d','a','a','a','a','a','a','b','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','b' },
            {'b','a','a','a','a','a','a','b','a','a','a','a','a','a','a','a','a','b','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','b' },
            {'b','a','a','a','a','a','a','b','a','a','a','a','a','a','a','a','a','b','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','b' },
            {'b','a','a','a','a','a','a','b','a','a','a','a','a','a','a','a','a','b','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','b' },
            {'b','a','a','a','a','a','a','b','a','a','a','a','a','a','a','a','a','b','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','b' },
            {'b','a','a','a','a','a','a','b','a','a','a','a','a','a','a','a','a','b','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','b' },
            {'b','a','a','a','a','a','a','b','a','a','a','a','a','a','a','a','a','b','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','b' },
            {'b','a','a','a','a','a','a','b','a','a','a','a','a','a','a','a','a','b','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','b' },
            {'b','a','a','a','a','a','a','b','a','a','a','a','a','a','a','a','a','b','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','b' },
            {'b','a','a','a','a','a','a','b','a','a','a','a','a','a','a','a','a','b','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','b' },
            {'b','a','a','a','a','a','a','b','a','a','a','a','a','a','a','a','a','b','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','b' },
            {'b','a','a','a','a','a','a','b','a','a','a','a','a','a','a','a','a','b','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','b' },
            {'b','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','b' },
            {'b','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','b' },
            {'b','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','b' },
            {'b','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','b' },
            {'b','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','b' },
            {'b','a','a','a','a','a','a','b','a','a','a','a','a','a','a','a','a','b','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','b' },
            {'b','a','a','a','a','a','a','b','a','a','a','a','a','a','a','a','a','b','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','b' },
            {'b','a','a','a','a','a','a','b','a','a','a','a','a','a','a','a','a','b','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','b' },
            {'b','a','a','a','a','a','a','b','a','a','a','a','a','a','a','a','a','b','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','b' },
            {'b','a','a','a','a','a','a','b','a','a','a','a','a','a','a','a','a','b','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','b' },
            {'b','b','b','b','b','b','b','b','b','b','b','b','b','b','b','b','b','b','b','b','b','b','b','b','b','b','b','b','b','b','b','b','b','b','b','b','b','b','b','b','b','b','b','b','b','b','b','b','b','b','b','b','b','b','b','b','b','b','b','b','b','b','b','b','b','b','b','b','b','b','b','b','b','b','b','b','b','b','b','b' }
        };

        char[,] fmap;
        fmap = (char[,])map.Clone();

        Color Colors(int clor)
        {
            if (clor == 0) return Color.Black;
            if (clor == 1) return Color.Gray;
            if (clor == 2) return Color.White;
            if (clor == 3) return Color.Blue;
            if (clor == 4) return Color.SkyBlue;
            if (clor == 5) return Color.Maroon;
            ;

            return Color.Black;
        }

        elist.Add(new enemy(5, 9));
        elist.Add(new enemy(8, 3));
        elist.Add(new enemy(20, 5));


        Raylib.InitWindow(width, height, "game i made");

        while (!Raylib.WindowShouldClose())
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Colors(3));
            Raylib.SetTargetFPS(60);

            /*
            Vector2 mouse = Raylib.GetMousePosition();
            if (Raylib.IsMouseButtonDown(MouseButton.Left))
            {
                Raylib.DrawText($"Mouse: {mouse.X}, {mouse.Y}", 20, 90, 20, Color.Gray);
            }
            Raylib.DrawCircle(x, y, 15, Color.Blue);
            */
            
            
            fmap = map;

            foreach (enemy e in elist)
            {
                fmap[e.ey, e.ex] = 'e';
            }


            if (Raylib.IsKeyPressed(KeyboardKey.W)) 
            {
                if (fmap[y - 1, x] != 'b') { y -= 1; }
            }
            if (Raylib.IsKeyPressed(KeyboardKey.A))
            {
                if (fmap[y, x - 1] != 'b') { x -= 1; }
            }
            if (Raylib.IsKeyPressed(KeyboardKey.S))
            {
                if (fmap[y + 1, x] != 'b') { y += 1; }
            }
            if (Raylib.IsKeyPressed(KeyboardKey.D))
            {
                if (fmap[y, x + 1] != 'b') { x += 1; }
            }

            if (Raylib.IsKeyPressed(KeyboardKey.Up))
            {
                while (true) { fy--; if (fmap[fy, fx] == 'e') { fmap[fy, fx] = 'a'; break; } if (fmap[fy, fx] == 'b') break; }
            }
            if (Raylib.IsKeyPressed(KeyboardKey.Left))
            {
                while (true) { fx--; if (fmap[fy, fx] == 'e') { fmap[fy, fx] = 'a'; break; } if (fmap[fy, fx] == 'b') break; }
            }
            if (Raylib.IsKeyPressed(KeyboardKey.Down))
            {
                while (true) { fy++; if (fmap[fy, fx] == 'e') { fmap[fy, fx] = 'a'; break; } if (fmap[fy, fx] == 'b') break; }
            }
            if (Raylib.IsKeyPressed(KeyboardKey.Right))
            {
                while (true) { fx++; if (fmap[fy, fx] == 'e') { fmap[fy, fx] = 'a'; break; } if (fmap[fy, fx] == 'b') break; }
            }
            

            foreach (enemy e in elist)
            {
                Raylib.DrawRectangle(e.ex * kube, e.ey * kube, kube, kube, Colors(5));
                if (e.ex == fx && e.ey == fy) { e.health -= 1; }
                if (e.health <= 0) { e.ey = 0; e.ex = 0; }
            }

            fx = x;
            fy = y;

            for ( int i = 0; i <= row - 1; i++ ) 
            {
                for ( int j = 0; j <= col - 1; j++ ) 
                {
                    if (fmap[j,i] == 'b') 
                    {
                        Raylib.DrawRectangle(i * kube, j * kube, kube, kube, Colors(0));
                    }
                    if (fmap[j,i] == 'd')
                    {
                        Raylib.DrawRectangle(i * kube, j * kube, kube, kube, Colors(1));
                    }
                    if (fmap[j, i] == 'c')
                    {
                        Raylib.DrawRectangle(i * kube, j * kube, kube, kube, Colors(5));
                    }
                }
            }
            
            


            Raylib.DrawRectangle(x * kube, y * kube, kube, kube, Colors(4));

            Raylib.EndDrawing();
        }
        Raylib.CloseWindow();
    }
}

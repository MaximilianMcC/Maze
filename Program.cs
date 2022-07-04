class Program
{

    static void Main(string[] args)
    {
        Console.CursorVisible = false;

        Player player = new Player();
        player.Skin = '☻';

        // Make the map
        List<Wall> map = MapHelper.GenerateMap("./map.txt");
        MapHelper.ListCoordinates(map);
        string mapString = MapHelper.GetMapString("./map.txt");
        
        while (true)
        {
            // Reset the screen
            Console.Clear();
            Console.WriteLine(mapString);

            // Draw the player
            Console.SetCursorPosition(player.X, player.Y);
            Console.WriteLine(player.Skin);

            // Get input
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.UpArrow:
                    player.Y--;
                    if (MapHelper.Collision(player, map)) player.Y++;
                    break;

                case ConsoleKey.DownArrow:
                    player.Y++;
                    if (MapHelper.Collision(player, map)) player.Y--;
                    break;

                case ConsoleKey.LeftArrow:
                    player.X--;
                    if (MapHelper.Collision(player, map)) player.X++;
                    break;

                case ConsoleKey.RightArrow:
                    player.X++;
                    if (MapHelper.Collision(player, map)) player.X--;
                    break;
            }


            Console.SetCursorPosition(0, 20);
            Console.WriteLine($"Player Coordinates: {player.X},{player.Y}");
        }
    }

}
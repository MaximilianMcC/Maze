class MapHelper
{
    // Check for collision
    public static bool Collision(Player player, List<Wall> coordinatesList)
    {
        // Loop through all coordinates
        foreach (Wall wall in coordinatesList)
        {
            // Check for if they collide
            if ((player.X == wall.X && player.Y == wall.Y) && wall.Solid == true) return true;
        }
        // Default
        return false;
    }

    // Generate a map
    public static List<Wall> GenerateMap(string mapFileName)
    {
        List<Wall> walls = new List<Wall>();

        // Get the map file
        string[] mapFile = File.ReadAllLines(mapFileName);

        // Loop through everything in the map
        for (int i = 0; i < mapFile.Length; i++) // Y
        {
            for (int j = 0; j < mapFile[i].Length; j++) // X
            {
                // Make the wall
                Wall wall = new Wall();
                wall.X = j;
                wall.Y = i;

                // Check for if the current wall is solid
                char currentCharacter = mapFile[i][j];
                if (currentCharacter == '#') wall.Solid = true;
                else wall.Solid = false;

                // Add the wall to the list
                walls.Add(wall);
            }
        }

        return walls;
    }

    // Draw the map with code
    // public static void DrawMap(List<Wall> map)
    // {
    //     foreach (Wall wall in map)
    //     {
    //         Console.SetCursorPosition(wall.X, wall.Y);
    //         if (wall.Solid == true) Console.WriteLine("█");
    //     }
    // }

    // Draw the map from the file
    public static string GetMapString(string mapFileName)
    {
        string map = File.ReadAllText(mapFileName);
        map = map.Replace("#", "█");
        return map;
    }


    // Show all map coordinates
    public static void ListCoordinates(List<Wall> map)
    {
        Console.WriteLine("Showing all wall coordinates in current map:");
        int counter = 0;
        foreach (Wall wall in map)
        {
            counter++;
            Console.WriteLine($"{counter} | Wall | X {wall.X} | Y {wall.Y} | Solid {wall.Solid}");
        }
        Console.ReadKey();
        Console.Clear();
    }
}
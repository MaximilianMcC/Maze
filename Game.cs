class Coordinates
{
    public int X { get; set; }
    public int Y { get; set; }
}

class Player : Coordinates
{
    public char Skin { get; set; }
}

class Wall : Coordinates
{
    public bool Solid { get; set; }
}
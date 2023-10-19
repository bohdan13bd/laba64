using System;
using System.Collections.Generic;

abstract class GraphicPrimitive
{
    public int X { get; set; }
    public int Y { get; set; }

    public GraphicPrimitive(int x, int y)
    {
        X = x;
        Y = y;
    }

    public abstract void Draw();
    public abstract void Move(int x, int y);
    public abstract void Scale(float factor);
}

class Circle : GraphicPrimitive
{
    public int Radius { get; set; }

    public Circle(int x, int y, int radius) : base(x, y)
    {
        Radius = radius;
    }

    public override void Draw()
    {
        Console.WriteLine($"Draw a circle at ({X}, {Y}) with radius {Radius}");
    }

    public override void Move(int x, int y)
    {
        X += x;
        Y += y;
    }

    public override void Scale(float factor)
    {
        Radius = (int)(Radius * factor);
    }
}

class Rectangle : GraphicPrimitive
{
    public int Width { get; set; }
    public int Height { get; set; }

    public Rectangle(int x, int y, int width, int height) : base(x, y)
    {
        Width = width;
        Height = height;
    }

    public override void Draw()
    {
        Console.WriteLine($"Draw a rectangle at ({X}, {Y}) with width {Width} and height {Height}");
    }

    public override void Move(int x, int y)
    {
        X += x;
        Y += y;
    }

    public override void Scale(float factor)
    {
        Width = (int)(Width * factor);
        Height = (int)(Height * factor);
    }
}

class Triangle : GraphicPrimitive
{
    public int SideLength { get; set; }

    public Triangle(int x, int y, int sideLength) : base(x, y)
    {
        SideLength = sideLength;
    }

    public override void Draw()
    {
        Console.WriteLine($"Draw a triangle at ({X}, {Y}) with side length {SideLength}");
    }

    public override void Move(int x, int y)
    {
        X += x;
        Y += y;
    }

    public override void Scale(float factor)
    {
        SideLength = (int)(SideLength * factor);
    }
}

class Group : GraphicPrimitive
{
    private List<GraphicPrimitive> primitives = new List<GraphicPrimitive>();

    public Group(int x, int y) : base(x, y) { }

    public void AddPrimitive(GraphicPrimitive primitive)
    {
        primitives.Add(primitive);
    }

    public override void Draw()
    {
        Console.WriteLine($"Draw a group at ({X}, {Y})");
        foreach (var primitive in primitives)
        {
            primitive.Draw();
        }
    }

    public override void Move(int x, int y)
    {
        X += x;
        Y += y;
        foreach (var primitive in primitives)
        {
            primitive.Move(x, y);
        }
    }

    public override void Scale(float factor)
    {
        foreach (var primitive in primitives)
        {
            primitive.Scale(factor);
        }
    }
}

class GraphicsEditor
{
    private List<GraphicPrimitive> primitives = new List<GraphicPrimitive>();

    public void AddPrimitive(GraphicPrimitive primitive)
    {
        primitives.Add(primitive);
    }

    public void DrawAll()
    {
        foreach (var primitive in primitives)
        {
            primitive.Draw();
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        GraphicsEditor editor = new GraphicsEditor();

        Circle circle = new Circle(10, 10, 5);
        Rectangle rectangle = new Rectangle(20, 20, 8, 6);
        Triangle triangle = new Triangle(30, 30, 7);

        editor.AddPrimitive(circle);
        editor.AddPrimitive(rectangle);
        editor.AddPrimitive(triangle);

        Group group = new Group(50, 50);
        group.AddPrimitive(circle);
        group.AddPrimitive(rectangle);

        editor.AddPrimitive(group);

        editor.DrawAll();

        circle.Scale(2.0f);
        editor.DrawAll();
    }
}

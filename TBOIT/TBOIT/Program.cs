using System;
using System.Collections.Generic;

namespace TBOIT
{
    
    class Program
    {

        public static Red red = new Red();
        public static Blue blue = new Blue();
        public static Black black = new Black();
        static void Main(string[] args)
        {
            red.Print(); blue.Print(); black.Print(); Console.Write("\n");
            while (red._nActualHearts < 15)
            {
                Console.Write("Add or Remove Hearts: ");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "Add":
                    case "add":
                        Console.Write("Write type Heart to add: ");
                        string typeHeartsToAdd = Console.ReadLine();
                        Console.Write("Write Hearts to add: ");
                        int heartsToAdd = int.Parse(Console.ReadLine());
                        switch (typeHeartsToAdd)
                        {
                            case "Red": // red heart
                            case "red": // red heart
                            case "R": // red heart
                            case "r": // red heart
                                AddHearts(heartsToAdd, red);
                                break;
                            case "Blue": // blue heart
                            case "blue": // blue heart
                            case "B": // blue heart
                            case "b": // blue heart
                                AddHearts(heartsToAdd, blue);
                                break;
                            case "Negro": // black heart
                            case "negro": // black heart
                            case "N": // black heart
                            case "n": // black heart
                                AddHearts(heartsToAdd, black);
                                break;
                        }
                        break;
                    case "Remove":
                    case "remove":
                        Console.Write("Write Hearts to remove: ");
                        int heartsToRemove = int.Parse(Console.ReadLine());
                        RemoveHearts(heartsToRemove, black);
                        break;
                }
            }
        }
        static void AddHearts(int heartsToAdd, Heart typeHeart) {
            typeHeart.AddHearts(heartsToAdd);
            red.Print();
            if(blue._nActualHearts != 0) blue.Print();
            if (black._nActualHearts != 0) black.Print();
            Console.Write("\n");
        }
        static void RemoveHearts(int heartsToRemove, Heart typeHeart)
        {
            if (typeHeart == black)
            {
                if (black._nActualHearts - heartsToRemove <= -1)
                {
                    blue.RemoveHearts(Math.Abs(black._nActualHearts - heartsToRemove));
                    if(blue._nActualHearts <= -1)
                    {
                        red.RemoveHearts(Math.Abs(blue._nActualHearts));
                        blue._nActualHearts = 0;
                    }
                }
            }
            typeHeart.RemoveHearts(heartsToRemove);
            red.Print();
            if (blue._nActualHearts != 0) blue.Print();
            if (black._nActualHearts != 0) black.Print();
            Console.Write("\n");
        }
    }
}

public abstract class Heart
{
    public abstract int _nActualHearts { get; set; }
    public abstract int _nTotalHearts { get; set; }
    public abstract void RemoveHearts(int i);
    public abstract void AddHearts(int i);
    public abstract string Name();
    public void Print()
    {
        if (_nActualHearts % 2 == 0)
        {
            for (int i = 0; i < _nActualHearts / 2; i++)
            {
                string cadena = Name();
                Console.Write(cadena);
                Console.Write(1);
            }
        }
        else
        {
            for (int i = 0; i < _nActualHearts / 2; i++)
            {
                string cadena = Name();
                Console.Write(cadena);
                Console.Write(1);
            }
            string cadena1 = Name();
            Console.Write(cadena1);

        }
        if (_nActualHearts != 0) Console.Write(" ");
    }

}
public class Red : Heart
{
    private int nActualHearts = 4;
    private int nTotalHearts = 6;

    public override int _nActualHearts {
        get {
            return nActualHearts;
        }
        set {
            nActualHearts = value;
        }
    }
    public override int _nTotalHearts
    {
        get
        {
            return nTotalHearts;
        }
        set
        {
            nTotalHearts = value;
        }
    }
    public override void AddHearts(int heartsToAdd)
    {
        nActualHearts += heartsToAdd;
        if (nActualHearts >= nTotalHearts) nActualHearts = nTotalHearts;
    }
    public override void RemoveHearts(int heartsToRemove)
    {
        nActualHearts -= Math.Abs(heartsToRemove); 
        if (nActualHearts <= 0) nActualHearts = 0;
    }
    public override string Name()
    {
        return "R";
    }
}
public class Blue : Heart
{
    private int nActualHearts = 2;
    private int nTotalHearts = 4;
    public override int _nActualHearts
    {
        get
        {
            return nActualHearts;
        }
        set
        {
            nActualHearts = value;
        }
    }
    public override int _nTotalHearts
    {
        get
        {
            return nTotalHearts;
        }
        set
        {
            nTotalHearts = value;
        }
    }
    public override void AddHearts(int heartsToAdd)
    {
        nActualHearts += heartsToAdd;
    }
    public override void RemoveHearts(int heartsToRemove) 
    {
        nActualHearts -= heartsToRemove; 
    }
    public override string Name()
    {
        return "B";
    }
}
public class Black : Heart
{
    private int nActualHearts = 2;
    private int nTotalHearts = 4;
    public override int _nActualHearts
    {
        get
        {
            return nActualHearts;
        }
        set
        {
            nActualHearts = value;
        }
    }
    public override int _nTotalHearts
    {
        get
        {
            return nTotalHearts;
        }
        set
        {
            nTotalHearts = value;
        }
    }
    public override void AddHearts(int heartsToAdd)
    {
        nActualHearts += heartsToAdd;
    }
    public override void RemoveHearts(int heartsToRemove)
    {
        nActualHearts -= heartsToRemove;
        if (nActualHearts <= 0) nActualHearts = 0;
    }
    public override string Name()
    {
        return "N";
    }
}

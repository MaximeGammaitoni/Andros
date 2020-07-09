using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InputConfig
{
    public interface IInputConfig
    {
        KeyCode Up { get; set; }
        KeyCode Down { get; set; }
        KeyCode Left { get; set; }
        KeyCode Right { get; set; }
    }
    public abstract class BasePlayerInput : IInputConfig
    {
        public KeyCode Up { get; set; }   //1
        public KeyCode Down { get; set; }  //2
        public KeyCode Left { get; set; }  //3
        public KeyCode Right { get; set; }  //4
    }

    public class Player1Input : BasePlayerInput
    {
        public Player1Input()
        {
            Up = KeyCode.UpArrow;
            Down = KeyCode.DownArrow;
            Left = KeyCode.LeftArrow;
            Right = KeyCode.RightArrow;
        }
    }
    public class Player2Input : BasePlayerInput
    {
        public Player2Input()
        {
            Up = KeyCode.Z;//Check keybord type later
            Down = KeyCode.S;
            Left = KeyCode.Q;
            Right = KeyCode.D;
        }
    }
    public class Player3Input : BasePlayerInput
    {
        public Player3Input()
        {
            Up = KeyCode.T;
            Down = KeyCode.G;
            Left = KeyCode.F;
            Right = KeyCode.H;
        }
    }
    public class Player4Input : BasePlayerInput
    {
        public Player4Input()
        {
            Up = KeyCode.I;
            Down = KeyCode.K;
            Left = KeyCode.J;
            Right = KeyCode.L;
        }
    }
}

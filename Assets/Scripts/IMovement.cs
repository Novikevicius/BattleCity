using System;
using UnityEngine;
using BattleCity.Miscellaneous;

namespace BattleCity
{
    public interface IMovement
    {
        void MoveUp();
        void MoveDown();
        void MoveLeft();
        void MoveRight();
    }
}

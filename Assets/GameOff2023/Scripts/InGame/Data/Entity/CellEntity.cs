using System;
using UnityEngine;

namespace GameOff2023.InGame.Data.Entity
{
    [Serializable]
    public sealed class CellEntity
    {
        public ObjectType type;
        public int x;
        public int y;

        public Vector3 position => new Vector3(x, y);
    }
}
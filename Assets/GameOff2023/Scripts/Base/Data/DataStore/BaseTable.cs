using System.Collections.Generic;
using UnityEngine;

namespace GameOff2023.Base.Data.DataStore
{
    public abstract class BaseTable<T> : ScriptableObject where T : ScriptableObject
    {
        [SerializeField] private List<T> dataList = default;

        public List<T> data => dataList;
    }
}
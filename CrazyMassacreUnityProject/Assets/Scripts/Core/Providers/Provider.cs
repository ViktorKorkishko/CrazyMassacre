using UnityEngine;

namespace Core.Providers
{
    public abstract class Provider<Key, Value> : MonoBehaviour
    {
        [SerializeField] private Value[] _data;

        public Value this[Key key] => _data[(int)(object)key - 1];
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Providers
{
    public abstract class EnumSafeProviderScriptable<T, Value> : ProviderScriptable<T, Value> where T : Enum
    {
        public override Value this[T key] => Data[GetIndex(key)];
        protected abstract Value[] Data { get; }

        private List<T> ids = null;
        private List<T> Ids
        {
            get
            {
                if (ids == null || ids.Count == 0) ids = Helpers.EnumsHelper.GetValues<T>().ToList();
                return ids;
            }
        }

        private int GetIndex(T key)
        {
            var index = Ids.IndexOf(key) - 1; // -1 because of none key
            return index;
        }
    }
}

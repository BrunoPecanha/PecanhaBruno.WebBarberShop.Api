using System;
using System.Collections.Generic;

namespace Pecanha.WebBarberShopp.Infra.CrossCutting.Utils {
    public class GenericComparator<T> : IEqualityComparer<T> {

        public Func<T, T, bool> _Equals { get; }
        public Func<T, int> _GetHashCode { get; }


        public GenericComparator(Func<T, T, bool> _metodoEquals, Func<T, int> _getHashCode) {
            this._Equals = _metodoEquals;
            this._GetHashCode = _getHashCode;
        }

        public  bool Equals(T x, T y) {
            return this._Equals(x, y);
        }

        public int GetHashCode(T obj) {
            return _GetHashCode(obj);
        }
    }
}


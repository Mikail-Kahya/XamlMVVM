using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EX01_Pokemon.Model;
namespace EX01_Pokemon.Model.Comparers
{
    class PokemonTypeComparer : IEqualityComparer<Pokemon>
    {
        public bool Equals(Pokemon? x, Pokemon? y)
        {
            //Check whether the compared object is null.
            if (Object.ReferenceEquals(x, null) ||
                object.ReferenceEquals(y, null)) 
                return false;

            return x.Type == y.Type;
        }

        public int GetHashCode(Pokemon obj)
        {
            //Check whether the object is null
            if (Object.ReferenceEquals(obj, null)) return 0;

            return obj.Id;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using EX01_Pokemon.Model;
using EX01_Pokemon.Repository;

namespace EX01_Pokemon.ViewModel
{
    public class OverViewPageVM : ObservableObject
    {
        public List<string> PokemonTypes { get; private set; }
        public List<Pokemon> Pokemon { get; private set; }

        public OverViewPageVM()
        {
            PokemonRepository repo = new PokemonRepository("Resources/Data/pokemons.json");
            PokemonTypes = repo.Types;
            Pokemon = repo.Pokemon;
        }
    }
}

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
        private PokemonRepository _repo = new PokemonRepository("Resources/Data/pokemons.json");
        private string _selectedType = "";
        private Pokemon _selectedPokemon;
        private List<string> _pokemonTypes;
        private List<Pokemon> _pokemon;

        public List<string> PokemonTypes
        {
            get => _pokemonTypes;
            private set
            {
                _pokemonTypes = value;
                OnPropertyChanged(nameof(PokemonTypes));
            }
        }

        public List<Pokemon> Pokemon
        {
            get => _pokemon;
            private set
            {
                _pokemon = value;
                OnPropertyChanged(nameof(Pokemon));
            }
        }

        public string SelectedType
        {
            get => _selectedType;
            set
            {
                _selectedType = value;
                Pokemon = _repo.GetAllPokemon(_selectedType);
            }
        }

        public Pokemon SelectedPokemon
        {
            get => _selectedPokemon;
            set => _selectedPokemon = value;
        }

        public OverViewPageVM()
        {
            PokemonTypes = _repo.Types;
            Pokemon = _repo.Pokemon;
        }
    }
}

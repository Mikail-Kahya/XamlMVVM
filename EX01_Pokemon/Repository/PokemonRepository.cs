using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EX01_Pokemon.Model;
using EX01_Pokemon.Model.Comparers;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace EX01_Pokemon.Repository
{
    public class PokemonRepository
    {
        private List<Pokemon> _pokemon = new List<Pokemon>();
        private List<string> _types = new List<string>();
        public List<Pokemon> Pokemon => _pokemon;
        public List<string> Types => _types;

        public List<Pokemon> GetAllPokemon(string type)
        {
            List<Pokemon> pokemonList = new List<Pokemon>();
            foreach (var pokemon in _pokemon)
            {
                if (pokemon.Type == type)
                    pokemonList.Add(pokemon);
            }

            return pokemonList;
        }

        public PokemonRepository(string pokemonFile)
        {
            _pokemon = JsonConvert.DeserializeObject<List<Pokemon>>(GetJsonString(pokemonFile));
            foreach (Pokemon uniquePokemon in _pokemon.DistinctBy(pokemon => pokemon.Type))
               _types.Add(uniquePokemon.Type);
        }

        private string? GetJsonString(string file)
        {
            // executing assembly
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            // generated embedded resource name: namespace.subfolder.filename
            string resourceName = "EX01_Pokemon." + file.Replace('/', '.');

            using Stream? stream = assembly.GetManifestResourceStream(resourceName);
            using var reader = new StreamReader(stream);
            return reader.ReadToEnd();
        }
    }
}

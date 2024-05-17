using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using EX01_Pokemon.Model;

namespace EX01_Pokemon.ViewModel
{
    internal class DetailPageVM : ObservableObject
    {
        public Pokemon Pokemon { get; set; } = new Pokemon()
        {
            Id = 136,
            Name = "Flareon",
            Type = "Fire",
            Height = 136,
            Weight = 9
        };
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EX01_Pokemon.Model;
using EX01_Pokemon.View;

namespace EX01_Pokemon.ViewModel
{
    internal class MainViewModel : ObservableObject
    {
        private Page _currentPage = new OverViewPage();
        public string CommandText => "navigate";
        public OverViewPage MainPage { get; private set; } = new OverViewPage();
        public DetailPage PokePage { get; private set; } = new DetailPage();

        public Page CurrentPage
        {
            get => _currentPage;
            private set
            {
                _currentPage = value;
                OnPropertyChanged(nameof(CurrentPage));
            }
        }

        public RelayCommand SwitchPageCommand { get; private set; }

        public MainViewModel()
        {
            SwitchPageCommand = new RelayCommand(SwitchPage);
        }

        private void SwitchPage()
        {
            //check the current visible page type
            if (CurrentPage is OverViewPage) //overview page -> go to details page
            {
                MainPage = CurrentPage as OverViewPage;
                //Get the selected pokemon
                OverViewPageVM? overViewVM = MainPage.DataContext as OverViewPageVM;
                Pokemon selectedPokemon = overViewVM?.SelectedPokemon;
                
                if (selectedPokemon == null) 
                    return;

                DetailPageVM? detailVM = PokePage.DataContext as DetailPageVM;
                detailVM.Pokemon = selectedPokemon;

                CurrentPage = PokePage;
            }
            else
            {
                CurrentPage = MainPage;
            }
        }
    }
}

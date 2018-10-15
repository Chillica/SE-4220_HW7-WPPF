using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SE_4220_HW7_WPF.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public BindingList<Character> Characters { get; set; }
        public List<string> CharacterTraits { get; set; }
        public CmdViewModel cmdsVM;

        public MainViewModel()
        {
            DateTime date1 = new DateTime(1994, 8, 29);
            DateTime date2 = new DateTime(1968, 2, 1);
            DateTime date3 = new DateTime(1975, 12, 3);
            DateTime date4 = new DateTime(1981, 4, 21);

            Characters = new BindingList<Character>(new[]
{
                new Character{FirstName="Jim",LastName="Bob", Born=date1, Height="123.45", Weight="300lbs"},
                new Character{FirstName="Joe",LastName="Bob", Born=date2, Height="223.45", Weight="178lbs"},
                new Character{FirstName="Jack",LastName="Bob", Born=date3, Height="323.45", Weight="400kgs"},
                new Character{FirstName="Jill",LastName="Bob", Born=date4, Height="423.45", Weight="138lbs"},
            }.ToList());

            CharacterTraits = new List<string>(new[]{
                "Basic Overview",
                "Physical Characteristics",
                "Intellectual, Mental, Personality Attitudes",
                "Emotional",
                "Spiritual"
            });


            cmdsVM = new CmdViewModel();
        }

        public string SelectedTrait { get; set; }
        public List<string> TraitList
        {
            get { return CharacterTraits; }
            //set { SetField(ref SelectedTrait, value); }
        }

        private Character selectedCharacter;
        public Character SelectedCharacter
        {
            get { return selectedCharacter; }
            set { SetField(ref selectedCharacter, value); }
        }

        public CmdViewModel CmdsVm
        {
            get { return cmdsVM; }
        }

        #region INotifyPropertyChanged Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
                return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
        #endregion
    }
}

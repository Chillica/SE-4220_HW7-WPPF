using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SE_4220_HW7_WPF.ViewModel
{
    class MainViewModel
    {
        public BindingList<Character> Characters { get; set; }
        public CmdsViewModel cmdsVM;

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
            cmdsVM = new CmdsViewModel();
        }
        public CmdsViewModel CmdsVm
        {
            get { return cmdsVM; }
        }

        private Character selectedCharacter;
        public Character SelectedCharacter
        {
            get { return selectedCharacter; }
            set { SetField(ref selectedCharacter, value); }
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

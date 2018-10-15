using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SE_4220_HW7_WPF;
using SE_4220_HW7_WPF.ViewModel;

namespace Tests
{
    [TestFixture]
    public class Tests
    {
        Character character = new Character();
        MainViewModel vm = new MainViewModel();
        CmdViewModel cvm = new CmdViewModel();

        [Test]
        public void IsCharSelected()
        {
            vm.SelectedCharacter = character;
            Assert.IsNotNull(vm.SelectedCharacter);
        }

        [Test]
        public void IsCharListOpen()
        {
            cvm.IsCharListOpen = true;
            Assert.True(cvm.IsCharListOpen);
        }
    }
}

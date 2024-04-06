using Demo.MVVM;
using System.Windows.Input;

namespace Demo
{
    public class ViewModel : ViewModelBase
    {
        public ICommand ShowCommand => new RelayCommand(execute => Show());
        private void Show()
        {
            BoundText = "set from code";
        }


        private string boundText;

		public string BoundText
		{
			get { return boundText; }
			set { boundText = value; OnPropertyChanged(); }
		}
        public ViewModel()
        {
            boundText = "hi";
        }
    }
}

using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using MaterialDesignColors.WpfExample.Domain;
using MaterialDesignThemes.Wpf;


namespace JobControlCenter.Domain
{
    public class DialogsViewModel : INotifyPropertyChanged
    {

        public DialogsViewModel()
        {
        }

        public ICommand RunDialogCommand => new AnotherCommandImplementation(ExecuteRunDialog);
        SampleDialog view;
        private async void ExecuteRunDialog(object o)
        {
            //let's set up a little MVVM, cos that's what the cool kids are doing:
            view = new SampleDialog
            {
                DataContext = new SampleDialogViewModel()
            };

            //show the dialog
            var result = await DialogHost.Show(view, "RootDialog", ClosingEventHandler);
        }

        private void ClosingEventHandler(object sender, DialogClosingEventArgs eventArgs)
        {
            if (!Equals(eventArgs.Parameter, true)) return;

            view.AddSandbox();
            
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

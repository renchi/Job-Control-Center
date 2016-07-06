using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using JobControlCenter.Domain;
using MaterialDesignThemes.Wpf;


namespace JobControlCenter.Domain
{
    public class DialogsViewModel : INotifyPropertyChanged
    {
        public DialogsViewModel()
        {
        }

        public ICommand RunDialogCommand => new AnotherCommandImplementation(ExecuteRunDialog);


        private async void ExecuteRunDialog(object o)
        {
            //let's set up a little MVVM, cos that's what the cool kids are doing:
            var view = new SampleDialog
            {
                DataContext = new SampleDialogViewModel()
            };

            //show the dialog
            //var result = await DialogHost.Show(view, "RootDialog", ClosingEventHandler);
            //var result = await DialogHost.Show(view, "RootDialog", ClosingEventHandler);
            //check the result...
          //  Console.WriteLine("Dialog was closed, the CommandParameter used to close it was: " + (result ?? "NULL"));
        }

        private void ClosingEventHandler(object sender, DialogClosingEventArgs eventArgs)
        {
            Console.WriteLine("You can intercept the closing event, and cancel here.");
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

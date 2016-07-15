using System;
using System.ComponentModel;
using MaterialDesignColors.WpfExample.Domain;

namespace JobControlCenter.Domain
{
    public class SampleDialogViewModel : INotifyPropertyChanged
    {
        private string _name;
        private string _path;

        public string Name
        {
            get { return _name; }
            set
            {
                this.MutateVerbose(ref _name, value, RaisePropertyChanged());
            }
        }

        public string Path
        {
            get { return _path; }
            set
            {
                this.MutateVerbose(ref _path, value, RaisePropertyChanged());
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private Action<PropertyChangedEventArgs> RaisePropertyChanged()
        {
            return args => PropertyChanged?.Invoke(this, args);
        }
    }
}

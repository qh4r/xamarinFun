using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using App1.Annotations;
using App1.Helpers;

namespace App1.ViewModel
{ 
    public class MainViewModel : INotifyPropertyChanged
    {
        #region Private Fields

        private string couter;

        #endregion

        #region Public Properties

        public string Couter
        {
            get { return couter; }
            set
            {
                couter = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand IncrementCommand => new RelayCommand(() =>
        {
            var x = Convert.ToInt32(String.IsNullOrWhiteSpace(Couter) ? "0" : Couter);
            Couter = (x += 1).ToString();
        });

        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
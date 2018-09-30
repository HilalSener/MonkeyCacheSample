using System.ComponentModel;
using System.Runtime.CompilerServices;
using CacheSample.Model;

namespace CacheSample.ViewModel
{
    public class CurrencyPageViewModel : INotifyPropertyChanged
    {
        public CurrencyPageViewModel()
        {
            GetCurrency();
        }

        public async void GetCurrency()
        {
            Details = await App.apiServices.GetCurrencyAsync();
        }

        private CurrencyModel _detail;

        public CurrencyModel Details
        {
            get
            {
                if (_detail == null)
                    _detail = new CurrencyModel();
                return _detail;
            }

            set
            {
                _detail = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

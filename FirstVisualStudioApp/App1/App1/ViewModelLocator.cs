using App1.ViewModel;

namespace App1
{
    public class ViewModelLocator
    {
        public MainViewModel Main
        {
            get { return new MainViewModel();}   
        }
    }
}
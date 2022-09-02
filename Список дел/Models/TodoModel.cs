using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
namespace Список_дел.Models
{
    class TodoModel:INotifyPropertyChanged
    {

        private bool isDone;
        private string _text;

        public DateTime CreationDate { get; set; } = DateTime.Now;
        public bool IsDone
        {
            get { return isDone; }
            set
            {
                if (isDone == value)
                    return;
                isDone = value;
                OnPropertyChanged("IsDone");
            }
        }

        public string _Text
        {
            get { return _text; }
            set
            {
                if (_text == value)
                    return;
                _text = value;
                OnPropertyChanged("_Text");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName="")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
                

            
        }
    }
}

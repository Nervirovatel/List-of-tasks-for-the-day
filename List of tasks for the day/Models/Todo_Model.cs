using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List_of_tasks_for_the_day.Models
{
    class Todo_Model : INotifyPropertyChanged
    {

        private bool is_Done;
        private string _Text;


        public DateTime CreationDate { get; set; } = DateTime.Now;

        public bool IsDone
        {
            get { return is_Done; }
            set 
            {
                if (is_Done == value)
                 return;
                
                is_Done = value;
                OnPropertyChanged("IsDone");
            }
            
        }

        public string Text
        {
            get { return _Text; }
            set 
            {
                if (_Text == value)
                    return;
                
                _Text = value;
                OnPropertyChanged("Text");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));    
        }
    }
}

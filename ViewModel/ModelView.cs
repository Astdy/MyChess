using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Chess.Model;
using Chess.View;
using System.Windows.Controls.Primitives;
using System.Windows.Controls;

namespace Chess.ViewModel
{
    internal class ModelView : INotifyPropertyChanged
    {
        public ModelView(UniformGrid uniformGrid)
        {
            regulator = new Regulator(uniformGrid , Click);
            buttons = regulator.getButtons();
        }
        private Regulator regulator;
        private Button[] buttons;
        public RelayCommand click;
        public RelayCommand Click
        {
            get
            {
                return click ?? new RelayCommand(obj =>
            {
            int indexButton;
            if (int.TryParse(obj.ToString(), out indexButton))
            {
                Image Image = buttons[indexButton].Content as Image;
                regulator.clickToCell(indexButton);

            }
            else
            {
                throw new ArgumentNullException();
            }
        });
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}

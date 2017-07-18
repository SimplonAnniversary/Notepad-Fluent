using NotepadUwp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotepadUwp.ViewModels
{
    public class TextDataViewModel : NotificationBase<TextDataModel>
    {
        public TextDataViewModel(TextDataModel data = null) : base(data) { }

        public string Text
        {
            get { return This.Text; }
            set { SetProperty(This.Text, value, () => This.Text = value); }
        }

        public string SelectedText
        {
            get { return This.SelectedText; }
            set { SetProperty(This.SelectedText, value, () => This.SelectedText = value); }
        }
    }
}

using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Common.Annotations;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;

namespace Common.Models
{
    public class BaseModel : INotifyPropertyChanged, IModel
    {
        public Guid Id { get; private set; }

        public BaseModel()
        {
            this.Id = Guid.NewGuid();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

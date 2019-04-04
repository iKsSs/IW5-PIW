using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Common.Annotations;

namespace Common.Models
{
    public interface IModel : INotifyPropertyChanged
    {
        Guid Id { get; }
    }
}

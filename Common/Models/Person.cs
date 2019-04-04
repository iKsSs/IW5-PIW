using System;

namespace Common.Models
{
    public class Person : BaseModel
    {
        private string _address;
        private string _name;
        private DateTime? _born;
        private byte[] _portrait;

        public string Address
        {
            get { return _address; }
            set
            {
                if (this._address != value)
                {
                    this._address = value;
                    this.OnPropertyChanged();
                }
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                if (this._name != value)
                {
                    this._name = value;
                    this.OnPropertyChanged();
                }
            }
        }

        public DateTime? Born
        {
            get { return _born; }
            set
            {
                if (this._born != value)
                {
                    this._born = value;
                    this.OnPropertyChanged();
                }
            }
        }

        public byte[] Portrait
        {
            get { return _portrait; }
            set
            {
                if (this._portrait != value)
                {
                    this._portrait = value;
                    this.OnPropertyChanged();
                }
            }
        }
    }
}

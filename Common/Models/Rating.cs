using System;

namespace Common.Models
{
    public class Rating : BaseModel
    {
        private string _comment;
        private DateTime _date;
        private int _value;

        public string Comment
        {
            get { return _comment; }
            set
            {
                if (this._comment != value)
                {
                    this._comment = value;
                    this.OnPropertyChanged();
                }
            }
        }

        public DateTime Date
        {
            get { return _date; }
            set
            {
                if (this._date != value)
                {
                    this._date = value;
                    this.OnPropertyChanged();
                }
            }
        }

        public int Value
        {
            get { return _value; }
            set
            {
                if (value < 0 || value > 5)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Value can be from 1 to 5.");
                }

                if (this._value != value)
                {
                    this._value = value;
                    this.OnPropertyChanged();
                }
            }
        }

        //Navigation property
        public User User { get; set; }
        public Movie Movie { get; set; }

        public override string ToString()
        {
            return $"ID: {base.Id} Value: {this._value}";
        }
    }
}

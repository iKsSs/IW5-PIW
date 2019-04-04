using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using Common.Models;

namespace Windows.Converter
{
    internal class ListPersonToStringConverter : IValueConverter
    {
        public object Convert( object value, Type targetType, object parameter, CultureInfo culture )
        {
            var ActorsValue = value as HashSet<Actor>;

            var directorsValue = value as HashSet<Director>;

            string str = string.Empty;

            if (null != ActorsValue)
            {
                return ActorsValue.Aggregate(str, (current, actor) => current + (actor.Name + ", "));
            }

            if (null != directorsValue)
            {
                return directorsValue.Aggregate(str, (current, director) => current + (director.Name + ", "));
            }

            return string.Empty;
        }

        public object ConvertBack( object value, Type targetType, object parameter, CultureInfo culture )
        {
            throw new NotImplementedException();
        }
    }
}

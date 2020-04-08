using H5ProjectChatDesktop.Models;
using H5ProjectChatDesktop.Views;
using System;
using System.Diagnostics;
using System.Globalization;

namespace H5ProjectChatDesktop.ValueConverters
{
    public class ApplicationPageValueConverter : BaseValueConverter<ApplicationPageValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch((ApplicationPage)value)
            {
                case ApplicationPage.Login:
                    return new Login();

                case ApplicationPage.Chat:
                    return new Chat();

                case ApplicationPage.Registra:
                    return new Registration();

                default:
                    Debugger.Break();
                    return null;
            }
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

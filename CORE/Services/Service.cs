using CORE.Models;
using System.Globalization;

namespace CORE.Services
{
    public abstract class Service
    {
        private string _culture;

        protected string Culture
        {
            get{
                return _culture;
            }
            set{
                _culture = value;
                Thread.CurrentThread.CurrentCulture = new CultureInfo(_culture);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(_culture);
            }
        }
    }
}
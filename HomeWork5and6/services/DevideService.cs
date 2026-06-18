using HomeWork5and6.Domains;
using HomeWork5and6.Domains.Entities;

namespace HomeWork5and6.services
{
    public class DevideService
    {
        
        public bool TryDivide(double dividend, double divisor, out double result)
        {
            if (divisor == 0)
            {
                result = 0;

                return false; // Деление на ноль невозможно
            }

            result = dividend / divisor;

            return true;
        }
    }
}

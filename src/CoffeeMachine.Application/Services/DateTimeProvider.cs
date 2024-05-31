using CoffeeMachine.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachine.Application.Services
{
    public class DateTimeProvider : IDateTimeProvider
    {
        private DateTime? _customDateTime;

        public DateTime Now => _customDateTime ?? DateTime.Now;

        public void SetCustomDate(DateTime dateTime)
        {
            _customDateTime = dateTime;
        }

        public void ResetDate()
        {
            _customDateTime = null;
        }
    }
}

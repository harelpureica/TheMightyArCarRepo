using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheMightyArCar.Infrastructure.Services.Popups
{
    public interface IPopupFactory
    {
        IPopup CreatePopup();

        public PopupsEnums.PopupType FactoryType { get; }
    }
}

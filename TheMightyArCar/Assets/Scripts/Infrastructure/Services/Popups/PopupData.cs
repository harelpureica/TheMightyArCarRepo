using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheMightyArCar.Infrastructure.Services.Popups
{ 
    public class PopupData
    {
        #region Fields
        private List<object> data;

        private PopupsCloseToken closeToken;

        #endregion

        #region Properties
        public List<object> Data => data;

        public PopupsCloseToken CloseToken => closeToken;

        #endregion
        #region Constructor
        public PopupData(PopupsCloseToken closeToken,List<object> data)
        {
            this.closeToken = closeToken;
            this.data = data;
        }
        #endregion

       
    }
}

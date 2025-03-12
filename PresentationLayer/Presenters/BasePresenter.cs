using PresentationLayer.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Presenters
{
    public class BasePresenter : IBasePresenter
    {
        private ILogin_Form _Login_Form;

        public BasePresenter()
        {

        }

        BasePresenter(ILogin_Form login_Form)
        {
            _Login_Form = login_Form;

        }
    }
}

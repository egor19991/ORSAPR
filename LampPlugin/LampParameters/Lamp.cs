using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LampParameters
{
    /// <summary>
    /// В теории класс должен содержать данные лампы и объединить все части лампы !!Прототип
    /// </summary>
    public class Lamp
    {
        // Неправильно !!!!!! Но работает
       // private Body _body = new Body();


       //Не уверен что так можно делать  
        public Body Body
        {
            get
            {
                return _body2;
            }
            set
            {
                _body2 = value;
            }
        }

        //public SocketPlatform SocketPlatform
        //{
        //    get;
        //    set;
        //}

        //public Tube Tube
        //{
        //    get;
        //    set;
        //}


        // Что-то вроде как похоже на агрегацию, но это не точно !!
        private Body _body2;

        public Lamp()
        {
            this._body2 = new Body{};

        }


    }

    
}

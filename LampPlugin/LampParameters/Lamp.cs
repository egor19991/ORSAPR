using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
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

        // Что-то вроде как похоже на агрегацию, но это не точно !!
        private Body _body;

        private SocketPlatform _socketPlatform;

        private Tube _tube;

        //Не уверен что так можно делать  
        public Body Body
        {
            get
            {
                return _body;
            }
            set
            {
                _body = value;
            }
        }

        public SocketPlatform SocketPlatform
        {
            get
            {
                return _socketPlatform;
            }
            set
            {
                _socketPlatform = value;
            }
        }

        public Tube Tube
        {
            get
            {
                return _tube;
            }
            set
            {
                _tube = value;
            }
        }

        public int HoleLength()
        {
            if (_body.Height >0 && _socketPlatform.Height >0 && _tube.Height >0 )
            {
                return _body.Height + _socketPlatform.Height + _tube.Height;
            }
            else
            {
                throw new ArgumentException("Empty value Body or SocketPlatform or Tube");
            }
        }

        public void Avg()
        {
            _body.AvgValue();
            _socketPlatform.AvgValue();
            _tube.AvgValue();
        }

        public void MaxValue()
        {
            _body.MaxValue();
            _socketPlatform.MaxValue();
            _tube.MaxValue();
        }

        public void MinValue()
        {
            _body.MinValue();
            _socketPlatform.MinValue();
            _tube.MinValue();
        }

        public Lamp()
        {
            this._body = new Body{};
            this._socketPlatform = new SocketPlatform();
            this._tube = new Tube();
        }
    }

    
}

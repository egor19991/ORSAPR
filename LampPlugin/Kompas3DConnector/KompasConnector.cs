using Kompas6API5;
using Kompas6Constants3D;
using System;
using System.Runtime.InteropServices;

namespace Kompas3DConnector
{
    /// <summary>
    /// Класс для соединения с Компас 3D
    /// </summary>
    public class KompasConnector
    {
        /// <summary>
        /// Поле, хранящее данные о 3D детали
        /// </summary>
        private ksDocument3D _document3d;

        /// <summary>
        /// Поле предназназначено для свизи с API Компас 
        /// </summary>
        private KompasObject _kompasObject;

        /// <summary>
        /// Поле для создание интерфейса
        /// </summary>
        private static KompasConnector _instance;

        /// <summary>
        /// Поле, для работы с частями детали 
        /// </summary>
        private ksPart _kompasPart;

        /// <summary>
        /// Свойство для реализации интерфейса API Компас 
        /// </summary>
        public static KompasConnector Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new KompasConnector();
                //_instance.InitializationKompas();
                return _instance;
            }
        }

        /// <summary>
        /// Свойство для реализации связи с API Компас
        /// </summary>
        public KompasObject KompasObject
        {
            get { return _kompasObject; }
            set { _kompasObject = value; }
        }

        /// <summary>
        /// Сойство для реализации связи с частями детали
        /// </summary>
        public ksPart KompasPart
        {
            get { return _kompasPart; }
            set { _kompasPart = value; }
        }

        /// <summary>
        /// Сойство для реализации связи с 3D эскизом
        /// </summary>
        public ksDocument3D Document3D
        {
            get { return _document3d; }
            set { _document3d = value; }
        }

        /// <summary>
        /// Метод запуска Компас в режиме детали, инициализации свойств Document3D, KompasPart и KompasObject
        /// </summary>
        public void InitializationKompas()
        {
            if (_kompasObject == null)
            {
                #if __LIGHT_VERSION__
                Type t = Type.GetTypeFromProgID("KOMPASLT.Application.5");
                #else
                Type t = Type.GetTypeFromProgID("KOMPAS.Application.5");
                #endif
                _kompasObject = (KompasObject)Activator.CreateInstance(t);
                _document3d = (Document3D)_kompasObject.Document3D();
                _document3d.Create(false, false);
                _kompasPart = (ksPart)_document3d.GetPart((short)Part_Type.pTop_Part);
            }
            if (_kompasObject != null)
            {
                _kompasObject.Visible = true;
                _kompasObject.ActivateControllerAPI();
            }
        }

        /// <summary>
        /// Метод для выгрузки и выхода и компаса
        /// </summary>
        public void UnloadKompas()
        {
            if (_kompasObject != null)
            {
                _kompasObject.Quit();
                Marshal.ReleaseComObject(_kompasObject);
            }
        }

        /// <summary>
        /// Конструктор класса
        /// </summary>
        private KompasConnector() { }
    }
}

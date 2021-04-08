using Kompas6API5;
using Kompas6Constants3D;
using System;
using System.Runtime.InteropServices;

namespace Kompas3DConnector
{
    /// <summary>
    /// Класс для соединения с API Компас-3D
    /// </summary>
    public class KompasConnector
    {
        /// <summary>
        /// Поле для создание интерфейса
        /// </summary>
        private static KompasConnector _instance;

        /// <summary>
        /// Свойство для реализации интерфейса API Компас 
        /// </summary>
        public static KompasConnector Instance
        {
            get
            {
                 //TODO: RSDN
                if (_instance == null)
                    _instance = new KompasConnector();
                return _instance;
            }
        }

        /// <summary>
        /// Свойство для реализации связи с API Компас
        /// </summary>
        public KompasObject KompasObject { get; set; }

        /// <summary>
        /// Сойство для реализации связи с частями детали
        /// </summary>
        public ksPart KompasPart { get; set; }

        /// <summary>
        /// Сойство для реализации связи с 3D эскизом
        /// </summary>
        public ksDocument3D Document3D { get; set; }

         //TODO: RSDN
        /// <summary>
        /// Метод запуска Компас в режиме детали, инициализации свойств Document3D, KompasPart и KompasObject
        /// </summary>
        public void InitializationKompas()
        {
            try
            {
                if (KompasObject != null)
                {
                    Document3D.close();
                }
                if (KompasObject == null)
                {
                    #if __LIGHT_VERSION__
                    Type t = Type.GetTypeFromProgID("KOMPASLT.Application.5");
                    #else
                    Type t = Type.GetTypeFromProgID("KOMPAS.Application.5");
                    #endif
                    KompasObject = (KompasObject)Activator.CreateInstance(t);
                }
                Document3D = (Document3D)KompasObject.Document3D();
                Document3D.Create(false, true);
                KompasPart = (ksPart)Document3D.GetPart((short)Part_Type.pTop_Part);
                KompasObject.Visible = true;
                KompasObject.ActivateControllerAPI();
            }
            catch (Exception e)
            {
                KompasObject = null;
                InitializationKompas();
            }
        }

        /// <summary>
        /// Метод для выгрузки и выхода из компаса
        /// </summary>
        public void UnloadKompas()
        {
            try
            {
                if (KompasObject != null)
                {
                    KompasObject.Quit();
                    Marshal.ReleaseComObject(KompasObject);
                }
            }
            catch (Exception e)
            {
                Marshal.ReleaseComObject(KompasObject);
            }
        }

        /// <summary>
        /// Конструктор класса
        /// </summary>
        private KompasConnector() { }
    }
}

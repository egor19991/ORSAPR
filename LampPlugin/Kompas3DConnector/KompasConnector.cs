using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KompasAPI7;
using Kompas6API5;
using Kompas6Constants3D;
using KAPITypes;

namespace Kompas3DConnector
{
    public class KompasConnector
    {
        //private KompasObject _kompas;
        //private ksDocument3D _document3D;

        //public  void OpenKompas()
        //{
        //    if (_kompas == null)
        //    {
        //        #if __LIGHT_VERSION__
        //        Type t = Type.GetTypeFromProgID("KOMPASLT.Application.5");
        //        #else
        //        Type t = Type.GetTypeFromProgID("KOMPAS.Application.5");
        //        #endif
        //        _kompas = (KompasObject) Activator.CreateInstance(t);
        //        //_kompas.CreateInstance("KOMPAS.Application.5");

        //        ////Создаем деталь
        //        //ksDocument3D Document3D;
        //        //Document3D = (Document3D)_kompas.Document3D();
        //        //Document3D.Create(false, false);
        //    }
        //    if (_kompas != null)
        //    {
        //        _kompas.Visible = true;
        //        _kompas.ActivateControllerAPI();
        //        _document3D = (Document3D)_kompas.Document3D();
        //        _document3D.Create(false, false);
        //    }
        //}

        private KompasConnector()
        {
        }

        private static KompasConnector instance;

        public static KompasConnector Instance
        {
            get
            {
                if (instance == null)
                    instance = new KompasConnector();
                return instance;
            }
        }

        private KompasObject _kompasObject;

        public KompasObject KompasObject
        {
            get { return _kompasObject; }
            set { _kompasObject = value; }
        }

        //private ksDocument2D document2d;

        //public ksDocument2D Document2D
        //{
        //    get { return document2d; }
        //    set { document2d = value; }
        //}

        private ksPart _kompasPart;

        public ksPart KompasPart
        {
            get { return _kompasPart; }
            set { _kompasPart = value; }
        }

        private ksDocument3D _document3d;

        public ksDocument3D Document3D
        {
            get { return _document3d; }
            set { _document3d = value; }
        }

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
                //_kompas.CreateInstance("KOMPAS.Application.5");

                ////Создаем деталь
                
                _document3d = (Document3D)_kompasObject.Document3D();
                _document3d.Create(false, false);
            }
            if (_kompasObject != null)
            {
                _kompasObject.Visible = true;
                _kompasObject.ActivateControllerAPI();
                _kompasPart = (ksPart)_document3d.GetPart((short)Part_Type.pTop_Part);
            }
        }

    }

}

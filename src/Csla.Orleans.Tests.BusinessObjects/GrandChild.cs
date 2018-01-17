﻿using System;
using System.Data;

namespace Csla.Orleans.Tests.BusinessObjects
{
    [Serializable()]
    public class GrandChild : BusinessBase<GrandChild>
    {
        private string _data = "";

        protected override object GetIdValue()
        {
            return _data;
        }

        public string Data
        {
            get { return _data; }
            set
            {
                if (_data != value)
                {
                    _data = value;
                    MarkDirty();
                }
            }
        }

        internal static GrandChild NewGrandChild(string data)
        {
            GrandChild obj = new GrandChild();
            obj._data = data;
            return obj;
        }

        internal static GrandChild GetGrandChild(IDataReader dr)
        {
            GrandChild obj = new GrandChild();
            obj.Fetch(dr);
            return obj;
        }

        public GrandChild()
        {
            //prevent direct creation
            MarkAsChild();
        }

        private void Fetch(IDataReader dr)
        {
            MarkOld();
        }

        internal void Update(IDbTransaction tr)
        {
            if (IsDeleted)
            {
                //we would delete here
                MarkNew();
            }
            else
            {
                if (IsNew)
                {
                    //we would insert here
                }
                else
                {
                    //we would update here
                }
                MarkOld();
            }
        }

        protected override void OnDeserialized(System.Runtime.Serialization.StreamingContext context)
        {
            base.OnDeserialized(context);
            Csla.ApplicationContext.GlobalContext.Add("GCDeserialized", "GC Deserialized");
        }
    }
}

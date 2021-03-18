using System.Collections.Generic;

namespace GFT.OrderApp.Domain.Base
{
    public abstract class ValueObject
    {
        protected abstract IEnumerable<object> GetAtomicValues();

        public bool ValueEquals(object obj)
        {
            if (obj == null || obj.GetType() != GetType())
            {
                return false;
            }

            ValueObject obj2 = (ValueObject)obj;
            IEnumerator<object> enumerator = GetAtomicValues().GetEnumerator();
            IEnumerator<object> enumerator2 = obj2.GetAtomicValues().GetEnumerator();
            while (enumerator.MoveNext() && enumerator2.MoveNext())
            {
                if ((enumerator.Current == null) ^ (enumerator2.Current == null))
                {
                    return false;
                }

                if (enumerator.Current != null && !enumerator.Current.Equals(enumerator2.Current))
                {
                    return false;
                }
            }

            if (!enumerator.MoveNext())
            {
                return !enumerator2.MoveNext();
            }

            return false;
        }
    }
}

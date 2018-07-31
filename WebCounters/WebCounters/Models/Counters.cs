using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebCounters.Models
{
    abstract public class BaseCounter
    {

        public int NextValue { get => getNextValue(); }

        protected abstract int getNextValue();

    }

    public class NormalCounter : BaseCounter
    {
        //Normalna zmienna - zmienna obiektu
        private int counter = 0;

        protected override int getNextValue()
        {
            return counter++;
        }

    }

    public class StaticCounter : BaseCounter
    {
        //Zmienna statyczna - zmienna klasy
        private static int counter = 0;

        protected override int getNextValue()
        {
            return counter++;
        }
    }
}
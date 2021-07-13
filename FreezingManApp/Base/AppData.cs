using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreezingManApp.Base
{
    class AppData
    {
        /// <summary>
        /// Контекст данных
        /// </summary>
        private static FreezingManDBEntities context;

        /// <summary>
        /// Получение контекста данных
        /// </summary>
        /// <returns> Контекст данных </returns>
        public static FreezingManDBEntities GetContext()
        {
            if (context == null)
            {
                context = new FreezingManDBEntities();
            }

            return context;
        }
    }
}

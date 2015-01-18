using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;

namespace ExampleApplicationCSharp.Extension
{
    public static class AutoMapperExtension
    {
        /// <summary>
        /// AutoMapper擴充方法, 可使target class重複mapping多個source class
        /// </summary>
        /// <typeparam name="TSource">source class</typeparam>
        /// <typeparam name="TDestination">target class</typeparam>
        /// <param name="destination">target class instance</param>
        /// <param name="source">source class instance</param>
        /// <returns>mapping完成的target class instance</returns>
        public static TDestination Map<TSource, TDestination>(this TDestination destination, TSource source)
        {
            return Mapper.Map(source, destination);
        }
    }
}

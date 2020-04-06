using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
namespace SAVNI_CRM.Application.AutoMapper
{
    public static class MapperHelper<TSource, TDestination> where TSource : class
    {
        /// <summary>
        /// Convetir el objeto TSource a un objeto TDestination, que retorna un TDestination
        /// </summary>
        /// <param name="source">Objeto a convertir</param>
        /// <returns></returns>
        public static TDestination ObjectTo(TSource source)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TSource, TDestination>();
            });
            IMapper iMapper = config.CreateMapper();

            return iMapper.Map<TSource, TDestination>(source);
        }

        /// <summary>
        /// Copia los datos de TSource en el mismo espacio en memoria de TDestination
        /// </summary>
        /// <param name="source">Objeto con los datos a modificar</param>
        /// <param name="destination">Objecto al cual se van a copiar</param>
        public static void CopyTo(TSource source, ref TDestination destination)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TSource, TDestination>();
            });
            IMapper iMapper = config.CreateMapper();

            iMapper.Map<TSource, TDestination>(source, destination);
        }
    }
}

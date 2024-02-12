using AutoMapper;
using API_Libros_BL.Models;
using API_Libros_BL.DTO;


namespace API_Libros_BL.DTO
{
    public class MapperConfig
    {
        public static MapperConfiguration MapperConfiguration()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Autor, AutorDTO>();//GET
                cfg.CreateMap<AutorDTO, Autor>();//POST-PUT

                cfg.CreateMap<Editorial, EditorialDTO>();
                cfg.CreateMap<EditorialDTO, Editorial>();

                cfg.CreateMap<Genero, GeneroDTO>();
                cfg.CreateMap<GeneroDTO, Genero>();

                cfg.CreateMap<Libro, LibroDTO>();
                cfg.CreateMap<LibroDTO, Libro>();
            });
        }
    }
}
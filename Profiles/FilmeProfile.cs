using AutoMapper;
using FilmesApi.Data.Dtos;
using FilmesApi.Models;

namespace FilmesApi.Profiles;

public class FilmesProfile : Profile
{
   public FilmesProfile()
   {
     CreateMap<CreateFilmeDto , Filme>();
   }
}
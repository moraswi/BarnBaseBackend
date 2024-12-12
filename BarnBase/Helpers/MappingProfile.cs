using AutoMapper;
using BarnBase.Dtos;
using BarnBase.Models;
using Microsoft.Extensions.Logging;

namespace BarnBase.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AnimalDto, Animal>();

            CreateMap<FixedPriceSaleDto, FixedPriceSale>();

            CreateMap<UserDto, User>();
            CreateMap<User, UserLoginDto>();

            CreateMap<LogInDto, User>();
            CreateMap<GetUserDto, User>();

            CreateMap<WeightDto, Weight>();
            CreateMap<BreedingDto, Breeding>();

            CreateMap<FavouriteDto, FavouriteSale>();
            CreateMap<AddFavouriteSaleDto, FavouriteSale>();

            CreateMap<TaskDto, NoteTask>();

            CreateMap<AnimalImageDto, AnamilImage>();
            CreateMap<AnimalDocumentDto, AnimalDocuments>();

        }
        
    }
}

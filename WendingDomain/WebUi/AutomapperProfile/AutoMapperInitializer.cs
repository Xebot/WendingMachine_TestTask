using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Contracts.DTO;
using WebUi.Models;

namespace WebUi.AutomapperProfile
{
    public static class AutoMapperInitializer
    {
        public static void Initialize()
        {
            Mapper.Initialize(config =>
            {
                
                config.CreateMap<WendingMachineDto, WendingMachineViewModel>();
                config.CreateMap<DrinkDto, DrinksViewModel>();
                config.CreateMap<CoinStorageDto, CoinStorageViewModel>();
                config.CreateMap<CreateDrinkViewModel, DrinkDto>();
            });
        }
    }
}




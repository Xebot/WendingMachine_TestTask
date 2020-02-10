using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Contracts.DTO;
using WendingDomain.Entities;

namespace WendingDomain.AutomapperProfiles
{
    public static class AutoMapperInitializer
    {
        public static void Initialize()
        {
            Mapper.Initialize(config =>
            {
                config.CreateMap<Drink, DrinkDto>();
                config.CreateMap<DrinkDto, Drink>();
                config.CreateMap<WendingMachine, WendingMachineDto>();
                config.CreateMap<WendingMachineDto, WendingMachine>();
                config.CreateMap<CoinStorage, CoinStorageDto>();
                
            });
        }
    }
}

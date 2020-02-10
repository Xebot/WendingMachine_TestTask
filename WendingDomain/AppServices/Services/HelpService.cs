using System;
using WendingDomain.RepositoryInterfaces;
using WebApi.Contracts.DTO;
using AutoMapper;

namespace AppServices.Services
{
    public class HelpService : Interfaces.IHelpService
    {
        protected readonly ICoinRepository _coinRepository;
        protected readonly ICoinStorageRepository _coinStorageRepositpory;
        protected readonly IServiceProvider _serviceProvider;


        public HelpService(ICoinRepository coinRepository, ICoinStorageRepository coinStorageRepositpory, IServiceProvider serviceProvider)
        {
            _coinRepository = coinRepository;
            _coinStorageRepositpory = coinStorageRepositpory;
            _serviceProvider = serviceProvider;
        }

        public void MakeNotAvailableCoin (decimal value)
        {
            _coinStorageRepositpory.GetCoin(value).isAvailable = false;
            _coinStorageRepositpory.Update(_coinStorageRepositpory.GetAllCoins());
            
        }
        public void MakeAvailableCoin(decimal value)
        {
            _coinStorageRepositpory.GetCoin(value).isAvailable = true;
            _coinStorageRepositpory.Update(_coinStorageRepositpory.GetAllCoins());

        }

        public void FillCoinStorage()
        {
            throw new NotImplementedException();
        }
        public CoinStorageDto GetAllCoins()
        {
            var storage = _coinStorageRepositpory.GetAllCoins();     
                
            return Mapper.Map<CoinStorageDto>(storage);

        }

        public void AddCoins()
        {
            throw new NotImplementedException();
        }
    }
}

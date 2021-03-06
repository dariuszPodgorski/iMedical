using AutoMapper;
using iMedical.Models;
using iMedicalApi.Models;
using iMedicalAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iMedicalApi.Services
{
    public interface IPriceListService
    {
        int Create(CreatePriceListDto dto);
        bool Delete(int id);
        IEnumerable<PriceListDto> GetAll();
        PriceListDto GetById(int id);
    }

    public class PriceListService : IPriceListService
    {
        private readonly iMedical_angContext _dbContext;
        private readonly IMapper _mapper;

        public PriceListService(iMedical_angContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public PriceListDto GetById(int id)
        {
            var priceList = _dbContext
               .PriceLists
               .FirstOrDefault(r => r.IdPriceList == id);

            if (priceList is null)
            {
                return null;
            }

            var result = _mapper.Map<PriceListDto>(priceList);
            return result;
        }

        public IEnumerable<PriceListDto> GetAll()
        {
            var priceList = _dbContext
                .PriceLists
                .ToList();

            var priceListDtos = _mapper.Map<List<PriceListDto>>(priceList);

            return priceListDtos;
        }


        public int Create(CreatePriceListDto dto)
        {
            var priceList = _mapper.Map<PriceList>(dto);
            _dbContext.PriceLists.Add(priceList);
            _dbContext.SaveChanges();

            return priceList.IdPriceList;
        }

        public bool Delete(int id)
        {
            var priceList = _dbContext
             .PriceLists
             .FirstOrDefault(r => r.IdPriceList == id);

            if (priceList is null) return false;

            _dbContext.PriceLists.Remove(priceList);
            _dbContext.SaveChanges();

            return true;


        }

    }
}

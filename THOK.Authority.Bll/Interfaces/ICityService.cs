﻿using THOK.Authority.DbModel;

namespace THOK.Authority.Bll.Interfaces
{
    public interface ICityService : IService<AUTH_CITY>
    {
        object GetDetails(int page, int rows, string cityName, string description, string isActive);

        bool Add(string cityName, string description, bool isActive);        

        bool Delete(string cityID);

        bool Save(string cityID, string cityName, string description, bool isActive);

        object GetCityByCityID(string cityID);

        object GetDetails(string userID, string cityID, string systemID);
    }
}

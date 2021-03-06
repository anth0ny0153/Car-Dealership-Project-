﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FinalCapstoneGCCarDealership.Models;

namespace FinalCapstoneGCCarDealership.Controllers
{
    public class CarController : ApiController
    {
        [HttpGet]
        public List<Car> SearchByMake(string carMake)
        {
            CarDBEntities ORM = new CarDBEntities();
            return ORM.Cars.Where(c => c.carMake.Contains(carMake)).ToList();
        }
        [HttpGet]
        public List<Car> SearchByModel(string carModel)
        {
            CarDBEntities ORM = new CarDBEntities();
            return ORM.Cars.Where(c => c.carModel.Contains(carModel)).ToList();
        }
        [HttpGet]
        public List<Car> SearchByYear(string carYear)
        {
            CarDBEntities ORM = new CarDBEntities();
            return ORM.Cars.Where(c => c.carYear.Contains(carYear)).ToList();
        }
        [HttpGet]
        public List<Car> SearchByColor(string carColor)
        {
            CarDBEntities ORM = new CarDBEntities();
            return ORM.Cars.Where(c => c.carColor.Contains(carColor)).ToList();
        }
        [HttpGet]
        public List<Car> SearchByMultiple(string carMake, string carModel, string carYear, string carColor)
        {
            CarDBEntities ORM = new CarDBEntities();

            List<Car> MakeList = ORM.Cars.Where(c => c.carMake.Contains(carMake)).ToList();
            List<Car> ModelList = ORM.Cars.Where(c => c.carModel.Contains(carModel)).ToList();
            List<Car> YearList = ORM.Cars.Where(c => c.carYear.Contains(carYear)).ToList();
            List<Car> ColorList = ORM.Cars.Where(c => c.carColor.Contains(carColor)).ToList();

            if (carMake == null)
                {
                MakeList.Clear();
                //maybe make carMake required
            }
            if (carModel == null)
                {
                ModelList = new List<Car>(MakeList);
                }
                if (carYear == null)
                {
                YearList = new List<Car>(ModelList);
                }
                if (carColor == null)
                {
                ColorList = new List<Car>(YearList);
                }
                List<Car> ResultList = MakeList.Intersect(ModelList).Intersect(YearList).Intersect(ColorList).ToList();
                return ResultList;
            
        }
    }
}

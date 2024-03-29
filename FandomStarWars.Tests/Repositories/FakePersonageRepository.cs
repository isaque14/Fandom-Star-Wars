﻿using FandomStarWars.Domain.Entities;
using FandomStarWars.Domain.Interfaces;
using System.Xml.Linq;

namespace FandomStarWars.Tests.Repositories
{
    public class FakePersonageRepository : IPersonageRepository
    {
        public async Task CreateAsync(Personage personage)
        {
            
        }

        public async Task DeleteAsync(Personage personage)
        {
            
        }

        public Task<IEnumerable<Personage>> GetAllAsync()
        {
            var personagesMock = new List<Personage>();

            personagesMock.Add(new Personage(
            1,
            "teste",
            "164",
            "70",
            "black",
            "black",
            "green",
            "data",
            "male",
            "earth"));

            personagesMock.Add(new Personage(
           2,
           "teste",
           "164",
           "70",
           "black",
           "black",
           "green",
           "data",
           "male",
           "earth"));

            personagesMock.Add(new Personage(
           3,
           "teste",
           "164",
           "70",
           "black",
           "black",
           "green",
           "data",
           "male",
           "earth"));

            personagesMock.Add(new Personage(
           4,
           "teste",
           "164",
           "70",
           "black",
           "black",
           "green",
           "data",
           "male",
           "earth"));

            return Task.FromResult(personagesMock as IEnumerable<Personage>);
        }

        public Task<Personage> GetByIdAsync(int id)
        {
            var personageMock = new Personage(
            1,
            "teste",
            "164",
            "70",
            "black",
            "black",
            "green",
            "data",
            "male",
            "earth");

            return Task.FromResult(personageMock);
        }

        public Task<Personage> GetByNameAsync(string name)
        {
            var personageMock = new Personage(
            1,
            "Isaque",
            "164",
            "70",
            "black",
            "black",
            "green",
            "data",
            "male",
            "earth");

            return Task.FromResult(personageMock);
        }

        public async Task UpdateAsync(Personage personage)
        {
            
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltraPlayApi.Data;
using UltraPlayApi.Data.Models;
using UltraPlayApi.Services.Interfaces;
using UltraPlayApi.Services.AutoMapper;
using AutoMapper;

namespace UltraPlayApi.Services.Implementations
{
    public class SportServices : ISportServices
    {
        private readonly ApplicationDbContext context;

        public SportServices(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task AddSportAsync(Sport sport)
        {
            await this.context.Sports.AddAsync(sport);
            await this.context.SaveChangesAsync();
        }

        public T GetFirstSport<T>(IMapper mapper = null) =>
            this.context.Sports
            .To<T>(mapper)
            .FirstOrDefault();

        public Sport GetFirstSport(IMapper mapper = null) =>
            this.context.Sports
            .FirstOrDefault();

        public int GetSportId() =>
            this.context.Sports
            .Select(x => x.Id)
            .FirstOrDefault();
    }
}
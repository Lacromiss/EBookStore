using Core.Entities;
using Core.Repositories.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementations
{
    public class TestService : ITestService
    {
        private readonly ITestRepositories _testRepositories;
        public TestService(ITestRepositories testRepositories)
        {
            _testRepositories= testRepositories;
            
        }
        public Task AddAsync(Test entity)
        {
            _testRepositories.AddAsync(entity);
            _testRepositories.SaveAsync(entity.Id);
        }

        public Task<List<Test>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Test> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public int Save(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Test entity)
        {
            throw new NotImplementedException();
        }
    }
}

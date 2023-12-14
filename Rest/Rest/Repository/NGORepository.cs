using Dapper;
using Microsoft.AspNetCore.Mvc;
using Rest.Contracts.Repository;
using Rest.DTO;
using Rest.Entity;
using Rest.Infrastructure;

namespace Rest.Repository
{
    public class NGORepository : Connection, INGORepository
    {
        
        public async Task Add(NGODTO ngo)
        {
            string sql = @"INSERT INTO NGO(NgoName, Site, HeadPerson, Telephone, Email, Password, CityId, CausesId)
                            VALUES(@NgoName, @Site, @HeadPerson, @Telephone, @Email, @Password, @CityId, @CausesId)";
            await Execute(sql, ngo);
        }

        public async Task Delete(int id)
        {
            string sql = "DELETE FROM NGO WHERE Id = @id";
            await Execute(sql, new {id});
        }

        public async Task<IEnumerable<NGOEntity>> Get()
        {
            string sql = "SELECT * FROM NGO";
            return await GetConnection().QueryAsync<NGOEntity>(sql);
        }

        public async Task<NGOEntity> GetById(int id)
        {
            string sql = "SELECT * FROM NGO WHERE Id = @id";
            return await GetConnection().QueryFirstAsync<NGOEntity>(sql, new {id});
        }

        public async Task Update(NGOEntity ngo)
        {
            string sql = @"UPDATE NGO SET NgoName = @NgoName,
                                          Site = @Site, 
                                          HeadPerson = @HeadPerson, 
                                          Telephone = @Telephone, 
                                          Email = @Email, 
                                          Password = @Password, 
                                          CityId = @CityId, 
                                          CausesId = @CausesId
                                          WHERE Id = @Id";
            await Execute(sql, ngo);
                                          
        }
    }
}

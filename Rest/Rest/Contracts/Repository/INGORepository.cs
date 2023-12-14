﻿using Rest.DTO;
using Rest.Entity;

namespace Rest.Contracts.Repository
{
    public interface INGORepository
    {
        Task Add(NGODTO ngo);

        Task Update(NGOEntity ngo);

        Task <IEnumerable<NGOEntity>> GetAll();

        Task <NGOEntity> GetById(int id);

        Task Delete(int id);
    }
}
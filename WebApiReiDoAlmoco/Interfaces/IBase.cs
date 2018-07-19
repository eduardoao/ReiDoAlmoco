using System.Collections.Generic;
using WebApiReiDoAlmoco.Models;

namespace WebApiReiDoAlmoco.Interfaces
{
    public interface IBase
    {
        BaseModel Adicionar(BaseModel baseModel);
        IEnumerable<BaseModel> RetornarTodos();
        void Remover(BaseModel baseModel);
    }
}

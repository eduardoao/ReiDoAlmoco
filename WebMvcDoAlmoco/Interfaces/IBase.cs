using System.Collections.Generic;
using WebMvcDoAlmoco.Models;


namespace WebMvcReiDoAlmoco.Interfaces
{
    public interface IBase
    {
        void Adicionar(BaseModel baseModel);
        IList<BaseModel> RetornarTodos();
        void Remover(BaseModel baseModel);
    }
}

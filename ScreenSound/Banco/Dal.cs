namespace ScreenSound.Banco;

internal class Dal<T> where T : class
{
    private readonly ScreenSoundContext context;

    public Dal(ScreenSoundContext context)
    {
        this.context = context;
    }

    public IEnumerable<T> Listar()
    {
        return context.Set<T>().ToList();
    }

    public void Adicionar(T objeto)
    {
            context.Set<T>().Add(objeto);
            context.SaveChanges();
    }

    public void Atualizar(T objeto)
    {
        context.Set<T>().Update(objeto);
        context.SaveChanges();
    }

    public void Deletar(T objeto)
    {
        context.Set<T>().Remove(objeto);
        context.SaveChanges();
    }
    
    public T? RecuperarPor(Func<T,bool> condicao)
    {
        return context.Set<T>().FirstOrDefault(condicao);
    }
}
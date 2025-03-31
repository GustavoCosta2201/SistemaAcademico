namespace SistemaAcademico.Data
{
    public class DAL<T> where T : class
    {
        public readonly AcademicoContext Context;
        public DAL(AcademicoContext context)
        {
            Context = context; 
        }


        public IEnumerable<T> GetAll() {

            return Context.Set<T>().ToList();

        }

        public void AddItem(T item)
        {
            Context.Set<T>().Add(item);  
            Context.SaveChanges();
        }

        public void RemoveItem(T item)
        {
            Context.Set<T>().Remove(item);
            Context.SaveChanges();  
        }

        public void UpdateItem(T item)
        {
            Context.Set<T>().Update(item);
            Context.SaveChanges();
        }

        public T? GetItem(Func<T, bool> preject)
        {
            return Context.Set<T>().FirstOrDefault(preject);

        }
    }

}

using System;

namespace Task_10._3._2
{
    internal class Program
    {
        public interface ICreatable
        {
            void Create();
        }

        public interface IDeletable
        {
            void Delete();
        }

        public interface IUpdatable
        {
            void Update();
        }
        public class Entity : ICreatable, IDeletable, IUpdatable
        {
            public void Create()
            {
                throw new NotImplementedException();
            }

            public void Delete()
            {
                throw new NotImplementedException();
            }

            public void Update()
            {
                throw new NotImplementedException();
            }
        }
        static void Main(string[] args)
        {
            ICreatable creatable = new Entity();
            creatable.Create(); // доступен только один метод

            Entity entity = new(); // доступны все реализуемые методы
            entity.Create();
            entity.Delete();
            entity.Update();

            Console.ReadKey();
        }
    }
}

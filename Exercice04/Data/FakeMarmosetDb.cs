using Exercice04.Models;
using static Exercice04.Models.Marmoset;

namespace Exercice04.Data
{
    public class FakeMarmosetDb
    {
        public List<Marmoset> _marmosets { get; } = new List<Marmoset>();
        private int _lastId = 0; // pour faire un équivalent d'IDENTITY ou AUTO INCREMENT


        public FakeMarmosetDb()
        {
            _marmosets = new List<Marmoset>() // équivalent du data seed (données par défaut)
            {
                new Marmoset { Id = ++_lastId, Name = "Yagami", Color = (MarmosetColor)1},
                new Marmoset { Id = ++_lastId, Name = "Kusanagi", Color = (MarmosetColor)2},
                new Marmoset { Id = ++_lastId, Name = "Mishima", Color = (MarmosetColor)3},
            };
        }

        public List<Marmoset> GetAll()
        {
            return _marmosets;
        }

        public Marmoset? GetById(int id)
        {
            return _marmosets.FirstOrDefault(c => c.Id == id);
        }

        public bool Add(Marmoset marmoset)
        {
            marmoset.Id = ++_lastId;
            _marmosets.Add(marmoset);
            return true; // l'ajout s'est bien passé
        }

        public bool Edit(Marmoset marmoset)
        {
            var marmosetFromDb = GetById(marmoset.Id);

            if (marmosetFromDb == null)
                return false;

            marmosetFromDb.Name = marmoset.Name;

            return true;
        }

        public bool Delete(int id)
        {
            var marmoset = GetById(id);

            if (marmoset == null)
                return false;

            _marmosets.Remove(marmoset);

            return true;
        }

    }
}
